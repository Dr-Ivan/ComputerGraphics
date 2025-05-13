import sys
import numpy as np
from PyQt5.QtWidgets import (
    QApplication, QMainWindow, QLabel, QPushButton,
    QFileDialog, QVBoxLayout, QSlider, QWidget, QHBoxLayout
)
from PyQt5.QtGui import QPixmap, QImage
from PyQt5.QtCore import Qt
import cv2


def rgb_to_hsl(r, g, b):
    r /= 255
    g /= 255
    b /= 255
    max_c = max(r, g, b)
    min_c = min(r, g, b)
    l = (max_c + min_c) / 2
    if max_c == min_c:
        s = 0
        h = 0
    else:
        d = max_c - min_c
        s = d / (2 - max_c - min_c) if l > 0.5 else d / (max_c + min_c)
        if max_c == r:
            h = (g - b) / d + (6 if g < b else 0)
        elif max_c == g:
            h = (b - r) / d + 2
        else:
            h = (r - g) / d + 4
        h /= 6
    return h, s, l


def hsl_to_rgb(h, s, l):
    def hue_to_rgb(p, q, t):
        if t < 0:
            t += 1
        if t > 1:
            t -= 1
        if t < 1/6:
            return p + (q - p) * 6 * t
        if t < 1/2:
            return q
        if t < 2/3:
            return p + (q - p) * (2/3 - t) * 6
        return p

    if s == 0:
        r = g = b = l
    else:
        q = l * (1 + s) if l < 0.5 else l + s - l * s
        p = 2 * l - q
        r = hue_to_rgb(p, q, h + 1/3)
        g = hue_to_rgb(p, q, h)
        b = hue_to_rgb(p, q, h - 1/3)
    return int(r * 255), int(g * 255), int(b * 255)


class ImageEditor(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Редактор HSL и RGB")
        self.setGeometry(100, 100, 1200, 800)

        self.image = None
        self.modified_image = None

        self.image_label = QLabel()
        self.image_label.setAlignment(Qt.AlignCenter)

        self.open_button = QPushButton("Открыть изображение")
        self.open_button.clicked.connect(self.open_image)

        self.apply_button = QPushButton("Применить изменения")
        self.apply_button.clicked.connect(self.apply_changes)

        self.save_button = QPushButton("Сохранить изображение")
        self.save_button.clicked.connect(self.save_image)

        self.hue_slider = self.create_slider("Оттенок")
        self.saturation_slider = self.create_slider("Насыщенность")
        self.lightness_slider = self.create_slider("Яркость")

        sliders_layout = QVBoxLayout()
        sliders_layout.addWidget(self.open_button)
        sliders_layout.addWidget(self.apply_button)
        sliders_layout.addWidget(self.save_button)
        sliders_layout.addWidget(self.hue_slider['label'])
        sliders_layout.addWidget(self.hue_slider['slider'])
        sliders_layout.addWidget(self.saturation_slider['label'])
        sliders_layout.addWidget(self.saturation_slider['slider'])
        sliders_layout.addWidget(self.lightness_slider['label'])
        sliders_layout.addWidget(self.lightness_slider['slider'])

        main_layout = QHBoxLayout()
        main_layout.addLayout(sliders_layout, 1)
        main_layout.addWidget(self.image_label, 4)

        container = QWidget()
        container.setLayout(main_layout)
        self.setCentralWidget(container)

    def create_slider(self, name):
        label = QLabel(f"{name}: 0")
        slider = QSlider(Qt.Horizontal)
        slider.setMinimum(-100)
        slider.setMaximum(100)
        slider.setValue(0)
        slider.valueChanged.connect(lambda value, l=label, n=name: l.setText(f"{n}: {value}"))
        return {"label": label, "slider": slider}

    def open_image(self):
        file_path, _ = QFileDialog.getOpenFileName(self, "Открыть изображение", "", "Images (*.png *.jpg *.jpeg)")
        if file_path:
            self.image = cv2.cvtColor(cv2.imread(file_path), cv2.COLOR_BGR2RGB)
            self.modified_image = self.image.copy()
            self.update_image()

    def apply_changes(self):
        if self.image is None:
            return

        img = self.image.copy()
        hue_shift = self.hue_slider['slider'].value() / 100
        sat_shift = self.saturation_slider['slider'].value() / 100
        light_shift = self.lightness_slider['slider'].value() / 100

        result = np.zeros_like(img)
        for i in range(img.shape[0]):
            for j in range(img.shape[1]):
                r, g, b = img[i, j]
                h, s, l = rgb_to_hsl(r, g, b)
                h = (h + hue_shift) % 1.0
                s = min(max(s + sat_shift, 0), 1)
                l = min(max(l + light_shift, 0), 1)
                r_new, g_new, b_new = hsl_to_rgb(h, s, l)
                result[i, j] = [r_new, g_new, b_new]

        self.modified_image = result
        self.update_image()

    def update_image(self):
        if self.modified_image is None:
            return

        height, width, channel = self.modified_image.shape
        bytes_per_line = 3 * width
        q_image = QImage(self.modified_image.data, width, height, bytes_per_line, QImage.Format_RGB888)
        pixmap = QPixmap.fromImage(q_image)
        self.image_label.setPixmap(pixmap.scaled(
            self.image_label.size(), Qt.KeepAspectRatio, Qt.SmoothTransformation
        ))

    def save_image(self):
        if self.modified_image is None:
            return

        file_path, _ = QFileDialog.getSaveFileName(self, "Сохранить изображение", "", "PNG Files (*.png);;JPEG Files (*.jpg)")
        if file_path:
            img_to_save = cv2.cvtColor(self.modified_image, cv2.COLOR_RGB2BGR)
            cv2.imwrite(file_path, img_to_save)


if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = ImageEditor()
    window.show()
    sys.exit(app.exec_())
