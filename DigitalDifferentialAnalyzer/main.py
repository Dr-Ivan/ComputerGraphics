import sys

from PyQt5.QtWidgets import (QApplication, QMainWindow, QWidget, QPushButton, QLineEdit, QHBoxLayout, QFormLayout)
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas
from matplotlib.figure import Figure


class DDAVisualizer(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Цифровой дифференциальный анализатор")
        self.setGeometry(100, 100, 800, 600)

        central_widget = QWidget()
        self.setCentralWidget(central_widget)
        main_layout = QHBoxLayout(central_widget)

        control_panel = QWidget()
        control_layout = QFormLayout(control_panel)

        self.x0_input = QLineEdit("0")
        self.y0_input = QLineEdit("0")
        self.x1_input = QLineEdit("12")
        self.y1_input = QLineEdit("10")

        control_layout.addRow("Начало X:", self.x0_input)
        control_layout.addRow("Начало Y:", self.y0_input)
        control_layout.addRow("Конец X:", self.x1_input)
        control_layout.addRow("Конец Y:", self.y1_input)

        draw_btn = QPushButton("Нарисовать отрезок")
        draw_btn.clicked.connect(self.draw_line)
        control_layout.addRow(draw_btn)

        self.figure = Figure(figsize=(5, 5), dpi=100)
        self.canvas = FigureCanvas(self.figure)

        main_layout.addWidget(control_panel, 1)
        main_layout.addWidget(self.canvas, 3)

        self.ax = self.figure.add_subplot(111)
        self.ax.grid(True)
        self.ax.set_title("Алгоритм ЦДА")
        self.ax.set_xlabel("X")
        self.ax.set_ylabel("Y")
        self.ax.axis('equal')
        self.canvas.draw()

    @staticmethod
    def calculate_points(x0, y0, x1, y1):
        delta_x = x1 - x0
        delta_y = y1 - y0
        step = max(abs(delta_x), abs(delta_y))
        dx = delta_x / step
        dy = delta_y / step

        points = []
        x, y = x0, y0
        while x <= x1:
            points.append((round(x), round(y)))
            x += dx
            y += dy
        return points

    def draw_line(self):
        try:
            x0 = int(self.x0_input.text())
            y0 = int(self.y0_input.text())
            x1 = int(self.x1_input.text())
            y1 = int(self.y1_input.text())
            points = self.calculate_points(x0, y0, x1, y1)

            self.ax.clear()
            x_vals = [p[0] for p in points]
            y_vals = [p[1] for p in points]
            self.ax.plot(x_vals, y_vals, 'go-', linewidth=2, markersize=5)
            self.ax.grid(True)
            self.ax.set_title("Алгоритм ЦДА")
            self.ax.set_xlabel("X")
            self.ax.set_ylabel("Y")
            self.ax.axis('equal')
            self.canvas.draw()

        except ValueError:
            print("Ошибка ввода данных")


if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = DDAVisualizer()
    window.show()
    sys.exit(app.exec_())
