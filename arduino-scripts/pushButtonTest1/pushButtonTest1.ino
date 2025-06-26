int butonDurumu = LOW;
int count = 0;
bool isPressing = false;

void setup() {
  pinMode(2, INPUT_PULLUP);  // D2 pinini giriş ve dahili pull-up ile ayarla
  Serial.begin(9600);        // Seri haberleşmeyi başlat
}

void loop() {
  butonDurumu = digitalRead(2);  // Butonun bağlı olduğu pini oku

  if (butonDurumu == LOW) {
    count++;
    if (!isPressing) {
      Serial.print("Durum değişti: ");
      Serial.println(count);
      isPressing = true;
    }
  }
  else {
    isPressing = false;
  }
}
