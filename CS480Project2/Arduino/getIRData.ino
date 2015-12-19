#include <Servo.h>

float voltage;

Servo horizontalServo;
Servo verticalServo;

int horizontalAngle = 0;
int verticalAngle = 0;
bool goingUp = true;
bool goingLeft = true;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  horizontalServo.attach(8);
  verticalServo.attach(9);
}

void loop() {
  // Pan left
  for (horizontalAngle = 0; horizontalAngle <= 180; horizontalAngle += 10) {
    horizontalServo.write(horizontalAngle);
    delay(15);
    for (verticalAngle = 0; verticalAngle <= 180; verticalAngle += 1) {
      verticalServo.write(verticalAngle);
      voltage = analogRead(0);
      String space = " ";
      String output = voltage + space + horizontalAngle + space + (verticalAngle - 90);
      Serial.println(output);
      delay(15);
    }
    for (verticalAngle = 180; verticalAngle >= 0; verticalAngle -= 1) {
      verticalServo.write(verticalAngle);
      voltage = analogRead(0);
      String space = " ";
      String output = voltage + space + horizontalAngle + space + (verticalAngle - 90);
      Serial.println(output);
      delay(15);
    }
  }
  // Pan right
  for (horizontalAngle = 180; horizontalAngle >= 0; horizontalAngle -= 10) {
    horizontalServo.write(horizontalAngle);
    delay(15);
    for (verticalAngle = 0; verticalAngle <= 180; verticalAngle += 1) {
      verticalServo.write(verticalAngle);
      voltage = analogRead(0);
      String space = " ";
      String output = voltage + space + horizontalAngle + space + (verticalAngle - 90);
      Serial.println(output);
      delay(15);
    }
    for (verticalAngle = 180; verticalAngle >= 0; verticalAngle -= 1) {
      verticalServo.write(verticalAngle);
      voltage = analogRead(0);
      String space = " ";
      String output = voltage + space + horizontalAngle + space + (verticalAngle - 90);
      Serial.println(output);
      delay(15);
    }
  }
}
