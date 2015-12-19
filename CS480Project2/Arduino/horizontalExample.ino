#include <Servo.h>

float voltage;
Servo horizontalServo;
Servo verticalServo;

int horizontalAngle = 0;
int verticalAngle = 90;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  horizontalServo.attach(8);
  verticalServo.attach(9);
  verticalServo.write(98);
  verticalServo.detach();
}

void loop() {
  // Pan left
  for (horizontalAngle = 0; horizontalAngle <= 180; horizontalAngle += 1) {
    horizontalServo.write(horizontalAngle);
    delay(100);
    voltage = analogRead(0);
    String space = " ";
    String output = voltage + space + horizontalAngle + space + (verticalAngle - 90);
    Serial.println(output);
  }
  // Pan right
  for (horizontalAngle = 180; horizontalAngle >= 0; horizontalAngle -= 1) {
    horizontalServo.write(horizontalAngle);
    delay(100);
    voltage = analogRead(0);
    String space = " ";
    String output = voltage + space + horizontalAngle + space + (verticalAngle - 90);
    Serial.println(output);
  }
}
