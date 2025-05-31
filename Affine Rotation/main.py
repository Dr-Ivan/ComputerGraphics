import sys
import math
from PyQt5.QtWidgets import (
    QApplication, QWidget, QVBoxLayout, QHBoxLayout, QPushButton,
    QTableWidget, QTableWidgetItem, QLabel, QSpinBox, QDoubleSpinBox
)
from PyQt5.QtCore import Qt
import matplotlib.pyplot as plt


def multiply_matrices(a, b):
    result = [[0] * len(b[0]) for _ in range(len(a))]
    for i in range(len(a)):
        for j in range(len(b[0])):
            for k in range(len(b)):
                result[i][j] += a[i][k] * b[k][j]
    return result


class AffineRotationApp(QWidget):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Аффинный поворот фигуры")
        self.setGeometry(100, 100, 600, 400)

        self.layout = QVBoxLayout()
        self.table = QTableWidget(3, 2)
        self.table.setHorizontalHeaderLabels(["X", "Y"])
        self.layout.addWidget(QLabel("Введите координаты точек:"))
        self.layout.addWidget(self.table)

        add_row_btn = QPushButton("Добавить точку")
        add_row_btn.clicked.connect(self.add_point_row)
        self.layout.addWidget(add_row_btn)

        angle_layout = QHBoxLayout()
        angle_layout.addWidget(QLabel("Угол поворота (градусы):"))
        self.angle_input = QSpinBox()
        self.angle_input.setRange(-360, 360)
        angle_layout.addWidget(self.angle_input)
        self.layout.addLayout(angle_layout)

        center_layout = QHBoxLayout()
        center_layout.addWidget(QLabel("Центр поворота (X, Y):"))
        self.center_x_input = QDoubleSpinBox()
        self.center_y_input = QDoubleSpinBox()
        self.center_x_input.setRange(-10000, 10000)
        self.center_y_input.setRange(-10000, 10000)
        center_layout.addWidget(self.center_x_input)
        center_layout.addWidget(self.center_y_input)
        self.layout.addLayout(center_layout)

        rotate_btn = QPushButton("Повернуть и отобразить")
        rotate_btn.clicked.connect(self.perform_rotation)
        self.layout.addWidget(rotate_btn)

        self.setLayout(self.layout)


    def add_point_row(self):
        current_rows = self.table.rowCount()
        self.table.insertRow(current_rows)


    def get_points(self):
        points = []
        for row in range(self.table.rowCount()):
            try:
                x_item = self.table.item(row, 0)
                y_item = self.table.item(row, 1)
                if x_item and y_item:
                    x = float(x_item.text())
                    y = float(y_item.text())
                    points.append([x, y])
            except ValueError:
                continue
        return points
    

    def perform_rotation(self):
        points = self.get_points()
        if not points:
            return

        angle_deg = self.angle_input.value()
        angle_rad = math.radians(angle_deg)

        cx = self.center_x_input.value()
        cy = self.center_y_input.value()

        translate_to_origin = [
            [1, 0, -cx],
            [0, 1, -cy],
            [0, 0, 1]
        ]

        rotation_matrix = [
            [math.cos(angle_rad), -math.sin(angle_rad), 0],
            [math.sin(angle_rad),  math.cos(angle_rad), 0],
            [0, 0, 1]
        ]

        translate_back = [
            [1, 0, cx],
            [0, 1, cy],
            [0, 0, 1]
        ]

        combined = multiply_matrices(translate_back, multiply_matrices(rotation_matrix, translate_to_origin))
        rotated = []
        for x, y in points:
            vector = [[x], [y], [1]]
            result = multiply_matrices(combined, vector)
            rotated.append([result[0][0], result[1][0]])

        self.plot(points, rotated)



    def plot(self, original, rotated):
        ox, oy = zip(*original)
        rx, ry = zip(*rotated)

        plt.figure(figsize=(6, 6))
        plt.plot(ox + (ox[0],), oy + (oy[0],), 'bo-', label="Оригинал")
        plt.plot(rx + (rx[0],), ry + (ry[0],), 'ro-', label="После поворота")
        plt.title("Аффинный поворот фигуры")
        plt.xlabel("X")
        plt.ylabel("Y")
        plt.legend()
        plt.grid(True)
        plt.axis('equal')
        plt.show()


if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = AffineRotationApp()
    window.show()
    sys.exit(app.exec_())
