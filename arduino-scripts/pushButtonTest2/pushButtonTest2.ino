const int NUM_SLIDERS = 2;
const int analogInputs[NUM_SLIDERS] = {A0, A1};
int analogSliderValues[NUM_SLIDERS];

const int buttonPin = 2;
bool buttonState = false;
bool lastButtonState = false;
bool toggledState = false;
unsigned long lastDebounceTime = 0;
unsigned long debounceDelay = 50;

String outputLine = "";

void setup() {
  outputLine.reserve(32);
  Serial.begin(9600);
  for (int i = 0; i < NUM_SLIDERS; i++) {
    pinMode(analogInputs[i], INPUT);
  }

  pinMode(buttonPin, INPUT_PULLUP); // Dahili pull-up
  delay(2000);  // Bilgisayar ile bağlantı otursun
  Serial.println("DEEJ_DEVICE_READY");
}

void loop() {
  outputLine.remove(0);
  readSliders();
  handleButton();
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

void handleButton() {
  int reading = digitalRead(buttonPin);
  
  if (reading != lastButtonState) {
    lastDebounceTime = millis();
  }

  if ((millis() - lastDebounceTime) > debounceDelay) {
    if (reading != buttonState) {
      buttonState = reading;

      if (buttonState == LOW) { // LOW çünkü pull-up var
        toggledState = !toggledState;
      }
    }
  }

  lastButtonState = reading;

  if (toggledState) {
    outputLine += String("|MUTE_ON");
  } else {
    outputLine += String("|MUTE_OFF");
  }
}
