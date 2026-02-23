# PulseAPK

<p align="center">
  🌍 <strong>Languages</strong><br>
  <a href="README.md">English</a> |
  <a href="README.de.md">Deutsch</a> |
  <a href="README.es.md">Español</a> |
  <a href="README.fr.md">Français</a> |
  <a href="README.he.md">עברית</a> |
  <a href="README.ko.md">한국어</a> |
  <a href="README.be.md">Беларуская</a> |
  <a href="README.fi.md">Suomi</a> |
  <a href="README.lv.md">Latviešu</a> |
  <a href="README.et.md">Eesti</a> |
  <a href="README.lt.md">Lietuvių</a> |
  <a href="README.cs.md">Čeština</a> |
  <a href="README.sk.md">Slovenčina</a> |
  <a href="README.hu.md">Magyar</a> |
  <a href="README.ar.md">العربية</a> |
  <a href="README.pt.md">Português</a> |
  <a href="README.ru.md">Русский</a> |
  <a href="README.uk.md">Українська</a> |
  <a href="README.zh.md">中文</a>
</p>

**PulseAPK** yra profesionali Android atvirkštinės inžinerijos ir saugumo analizės grafinė sąsaja, sukurta naudojant Avalonia (.NET 8). Ji sujungia `apktool` galią su pažangiomis statinės analizės galimybėmis, pateiktomis didelio našumo, kiberpanko įkvėptoje sąsajoje. PulseAPK supaprastina visą darbo eigą nuo dekompiliavimo iki analizės, perkompiliavimo ir pasirašymo.

[Žiūrėti demonstraciją YouTube](https://youtu.be/Mkdt0c-7Wwg)

PulseAPK organizuotas kaip vieno lango darbo eiga su viršutine navigacija kiekvienam įrankiui: **Decompile**, **Build**, **Analyser**, **Settings** ir **About**. Kiekvienas skyrius apima vieną APK gyvavimo ciklo etapą, kad galėtumėte pereiti nuo dekodavimo prie analizės ir pasirašymo nepalikdami programos.

## Pagrindinės funkcijos

- **🛡️ Statinė saugumo analizė**: automatiškai skenuoja Smali kodą dėl pažeidžiamumų, įskaitant root aptikimą, emuliatoriaus patikras, įkoduotus prisijungimo duomenis ir nesaugų SQL/HTTP naudojimą.
- **⚙️ Dinaminis taisyklių variklis**: visiškai pritaikomos analizės taisyklės per `smali_analysis_rules.json`. Aptikimo šablonus galima keisti neperkraunant programos. Talpykla užtikrina optimalų našumą.
- **🚀 Moderni UI/UX**: responsyvi, tamsi sąsaja efektyviam darbui su realaus laiko konsolės grįžtamuoju ryšiu.
- **📦 Pilna darbo eiga**: dekompiliuokite, analizuokite, redaguokite, perkompiliuokite ir pasirašykite APK vienoje aplinkoje.
- **⚡ Saugus ir patikimas**: apima išmanų tikrinimą ir avarijų prevencijos mechanizmus, kurie saugo darbo erdvę ir duomenis.
- **🔧 Visiškai konfigūruojamas**: lengvai valdykite įrankių kelius (Java, Apktool), darbo erdvės nustatymus ir analizės parametrus.

## Išplėstinės galimybės

### Saugumo analizė
PulseAPK turi integruotą statinį analizatorių, kuris skenuoja dekompiliuotą kodą ieškodamas dažnų saugumo indikatorių:
- **Root aptikimas**: identifikuoja Magisk, SuperSU ir įprastų root binarinių failų patikras.
- **Emuliatoriaus aptikimas**: randa QEMU, Genymotion ir specifinių sistemos savybių patikras.
- **Jautrūs duomenys**: skenuoja įkoduotus API raktus, žetonus ir Basic Auth antraštes.
- **Nesaugus tinklas**: pažymi HTTP naudojimą ir galimus duomenų nutekėjimo taškus.

*Taisyklės apibrėžtos `smali_analysis_rules.json` faile ir gali būti pritaikytos jūsų poreikiams.*

### APK valdymas
- **Dekompliavimas**: lengvai dekoduokite resursus ir šaltinius su konfigūruojamomis parinktimis.
- **Perkompiliavimas**: perkompiliuoja pakeistus projektus į galiojančius APK.
- **Pasirašymas**: integruotas keystore valdymas pasirašo perkompiliuotus APK, kad jie būtų paruošti diegimui.

## Reikalavimai

1.  **Java Runtime Environment (JRE)**: reikalinga `apktool`. Įsitikinkite, kad `java` yra sistemos `PATH`.
2.  **Apktool**: atsisiųskite `apktool.jar` iš [ibotpeaches.github.io](https://ibotpeaches.github.io/Apktool/).
3.  **Ubersign (Uber APK Signer)**: reikalinga perkompiliuotiems APK pasirašyti. Atsisiųskite naujausią `uber-apk-signer.jar` iš [GitHub releases](https://github.com/patrickfav/uber-apk-signer/releases).
4.  **.NET 8.0 Runtime**: reikalinga PulseAPK paleisti palaikomose platformose (Windows, Linux ir macOS).

## Greito paleidimo gidas

1.  **Atsisiųsti ir sukurti**
    ```powershell
    dotnet build
    dotnet run
    ```

2.  **Nustatymas**
    - Atidarykite **Settings**.
    - Nurodykite `apktool.jar` kelią.
    - PulseAPK automatiškai aptiks Java diegimą pagal aplinkos kintamuosius.

3.  **APK analizė**
    - **Dekompliuokite** tikslinį APK Decompile skirtuke.
    - Pereikite į **Analysis** skirtuką.
    - Pasirinkite dekompiliuoto projekto aplanką.
    - Spustelėkite **Analyze Smali**, kad sugeneruotumėte saugumo ataskaitą.

4.  **Keiskite ir perkompiliuokite**
    - Redaguokite failus projekto aplanke.
    - Naudokite **Build** skirtuką naujam APK sukurti.
    - Naudokite **Sign** skirtuką išvesties APK pasirašyti.


## Ekrano nuotraukos

### 1) Dekompiliavimo eiga
![PulseAPK dekompiliavimo ekranas](images/pulse_apk_decompile.png)
- Šiame ekrane pasirenkate įvesties APK ir išvesties aplanką, tada paleidžiate dekompiliavimą.
- Paprasta eiga: pasirinkti APK -> nustatyti išvesties kelią -> spustelėti decompile.

### 2) Kompiliavimo eiga
![PulseAPK kompiliavimo ekranas](images/pulse_apk_build.png)
- Šiame ekrane dekompiliuotas projektas perkompiliuojamas į naują APK.
- Paprasta eiga: pasirinkti projekto aplanką -> nustatyti išvesties pavadinimą/kelią -> spustelėti build (ir prireikus įjungti pasirašymą).

### 3) Statinės analizės rezultatai
![PulseAPK analizės išvestis](images/pulse_apk_analysis.png)
- Ši peržiūra rodo Smali/statinės analizės saugumo radinius.
- Paprasta eiga: pirmiausia dekompiliuoti -> atidaryti analizės skirtuką/išvestį -> peržiūrėti radinius ir eksportuoti ataskaitą.


## Techninė architektūra

PulseAPK naudoja švarią MVVM (Model-View-ViewModel) architektūrą:

- **Core**: .NET 8.0, Avalonia.
- **Analysis**: pasirinktinis regex pagrindu veikiantis statinės analizės variklis su karštu taisyklių įkėlimu.
- **Services**: skirti servisai Apktool integracijai, failų sistemos stebėjimui ir nustatymų valdymui.

## Licencija

Šis projektas yra atvirojo kodo ir platinamas pagal [Apache License 2.0](LICENSE.md).

### ❤️ Paremkite projektą

Jei PulseAPK jums naudingas, galite paremti jo vystymą paspausdami „Support“ mygtuką puslapio viršuje.

Žvaigždutės suteikimas repozitorijui taip pat labai padeda.

### Prisidėjimas

Laukiame indėlių! Atkreipkite dėmesį, kad visi prisidedantys asmenys privalo pasirašyti [Contributor License Agreement (CLA)](CLA.md), kad jų darbas galėtų būti teisėtai platinamas.
Pateikdami pull request, sutinkate su CLA sąlygomis.
