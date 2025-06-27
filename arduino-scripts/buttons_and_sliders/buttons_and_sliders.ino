const int NUM_SLIDERS = 2;
const int analogInputs[NUM_SLIDERS] = {A0, A1};
int analogSliderValues[NUM_SLIDERS];

const int buttonPin1 = 2;
bool buttonState1 = false;
bool lastButtonState1 = false;
bool toggledState1 = false;
unsigned long lastDebounceTime1 = 0;
unsigned long debounceDelay1 = 50;

const int buttonPin2 = 3;
bool buttonState2 = false;
bool lastButtonState2 = false;
bool toggledState2 = false;
unsigned long lastDebounceTime2 = 0;
unsigned long debounceDelay2 = 50;

String outputLine = "";

void setup() {
  outputLine.reserve(32);
  Serial.begin(9600);
  for (int i = 0; i < NUM_SLIDERS; i++) {
    pinMode(analogInputs[i], INPUT);
  }

  pinMode(buttonPin1, INPUT_PULLUP);
  pinMode(buttonPin2, INPUT_PULLUP);
  delay(2000);
  Serial.println("DEEJ_DEVICE_READY");
}

void loop() {
  outputLine.remove(0);
  readSliders();
  handleButton1();
  handleButton2();
  Serial.println(outputLine);
  delay(10);
}

void readSliders() {
  for (int i = 0; i < NUM_SLIDERS; i++) {
    analogSliderValues[i] = analogRead(analogInputs[i]);
    outputLine += String(analogSliderValues[i]);
    if (i < NUM_SLIDERS - 1) outputLine += "|";
  }
}

void handleButton1() {
  int reading = digitalRead(buttonPin1);
  
  if (reading != lastButtonState1) {
    lastDebounceTime1 = millis();
  }

  if ((millis() - lastDebounceTime1) > debounceDelay1) {
    if (reading != buttonState1) {
      buttonState1 = reading;

      if (buttonState1 == LOW) {
        toggledState1 = !toggledState1;
      }
    }
  }

  lastButtonState1 = reading;

  if (toggledState1) {
    outputLine += String("|MUTE_ON");
  } else {
    outputLine += String("|MUTE_OFF");
  }
}

void handleButton2() {
  int reading = digitalRead(buttonPin2);
  
  if (reading != lastButtonState2) {
    lastDebounceTime2 = millis();
  }

  if ((millis() - lastDebounceTime2) > debounceDelay2) {
    if (reading != buttonState2) {
      buttonState2 = reading;

      if (buttonState2 == LOW) {
        toggledState2 = !toggledState2;
      }
    }
  }

  lastButtonState2 = reading;

  if (toggledState2) {
    outputLine += String("|MUTE_ON");
  } else {
    outputLine += String("|MUTE_OFF");
  }
}
