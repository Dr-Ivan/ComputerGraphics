import sys

from PIL import Image
from PyQt5 import QtCore, QtGui, QtWidgets
from PyQt5.QtGui import QPixmap
from PyQt5.QtWidgets import QFileDialog


class ImageRotater(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(1111, 900)
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.openButton = QtWidgets.QPushButton(self.centralwidget)
        self.openButton.setGeometry(QtCore.QRect(0, 0, 250, 60))
        font = QtGui.QFont()
        font.setPointSize(12)
        font.setBold(True)
        font.setWeight(75)
        self.openButton.setFont(font)
        self.openButton.setObjectName("openButton")
        self.label = QtWidgets.QLabel(self.centralwidget)
        self.label.setGeometry(QtCore.QRect(260, 0, 111, 60))
        font = QtGui.QFont()
        font.setPointSize(12)
        self.label.setFont(font)
        self.label.setObjectName("label")
        self.comboBox = QtWidgets.QComboBox(self.centralwidget)
        self.comboBox.setGeometry(QtCore.QRect(380, 20, 61, 22))
        self.comboBox.setObjectName("comboBox")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.label_2 = QtWidgets.QLabel(self.centralwidget)
        self.label_2.setGeometry(QtCore.QRect(450, 0, 111, 60))
        font = QtGui.QFont()
        font.setPointSize(12)
        self.label_2.setFont(font)
        self.label_2.setObjectName("label_2")
        self.pushButton = QtWidgets.QPushButton(self.centralwidget)
        self.pushButton.setGeometry(QtCore.QRect(570, 0, 181, 60))
        font = QtGui.QFont()
        font.setPointSize(12)
        font.setBold(True)
        font.setWeight(75)
        self.pushButton.setFont(font)
        self.pushButton.setObjectName("pushButton")
        self.imgLabel = QtWidgets.QLabel(self.centralwidget)
        self.imgLabel.setGeometry(QtCore.QRect(20, 80, 1000, 500))
        self.imgLabel.setObjectName("imgLabel")
        MainWindow.setCentralWidget(self.centralwidget)
        self.statusbar = QtWidgets.QStatusBar(MainWindow)
        self.statusbar.setObjectName("statusbar")
        MainWindow.setStatusBar(self.statusbar)

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)
        self.pushButton.setDisabled(True)
        self.openButton.clicked.connect(self.load_image)
        self.pushButton.clicked.connect(self.rotate_image)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "Image rotater by Ivan D."))
        self.openButton.setText(_translate("MainWindow", "Открыть BMP файл"))
        self.label.setText(_translate("MainWindow", "Поворот на"))
        self.comboBox.setItemText(0, _translate("MainWindow", "45"))
        self.comboBox.setItemText(1, _translate("MainWindow", "90"))
        self.comboBox.setItemText(2, _translate("MainWindow", "180"))
        self.comboBox.setItemText(3, _translate("MainWindow", "200"))
        self.label_2.setText(_translate("MainWindow", "градусов."))
        self.pushButton.setText(_translate("MainWindow", "Повернуть!"))
        self.imgLabel.setText(_translate("MainWindow", " "))

    def load_image(self):
        file_name = QFileDialog.getOpenFileName(None, 'Открыть BMP', './', "Image *.bmp")
        if file_name:
            try:
                self.image = Image.open(file_name[0])
                im = self.image.convert("RGBA")
                data = im.tobytes("raw", "RGBA")
                qim = QtGui.QImage(data, im.size[0], im.size[1], QtGui.QImage.Format_RGBA8888)
                self.pixmap = QPixmap(qim)
                if self.pixmap.isNull():
                    raise ValueError("Ошибка: не удалось загрузить изображение.")
            except Exception as ex:
                self.imgLabel.setText(f"Ошибка: {str(ex)}")
            else:
                self.imgLabel.resize(self.image.size[0], self.image.size[1])
                self.imgLabel.setPixmap(self.pixmap)
                self.pushButton.setEnabled(True)
        else:
            self.imgLabel.setText("Файл не выбран.")

    def rotate_image(self):
        degrees = int(self.comboBox.currentText())
        im_rotated = self.image.rotate(-degrees, expand=True)
        self.image = im_rotated
        im = self.image.convert("RGBA")
        data = im.tobytes("raw", "RGBA")
        qim = QtGui.QImage(data, im.size[0], im.size[1], QtGui.QImage.Format_RGBA8888)
        self.pixmap = QPixmap(qim)
        self.imgLabel.resize(self.image.size[0], self.image.size[1])
        self.imgLabel.setPixmap(self.pixmap)


if __name__ == "__main__":
    app = QtWidgets.QApplication(sys.argv)
    MainWindow = QtWidgets.QMainWindow()
    ui = ImageRotater()
    ui.setupUi(MainWindow)
    MainWindow.show()
    sys.exit(app.exec_())
