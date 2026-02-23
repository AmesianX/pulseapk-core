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

**PulseAPK** on professionaalne Androidi pöördprojekteerimise ja turvaanalüüsi GUI, mis on ehitatud Avalonia (.NET 8) abil. See ühendab `apktool`-i toore jõu täiustatud staatilise analüüsiga, pakkudes kõrge jõudlusega, küberpungi stiilis kasutajaliidest. PulseAPK sujuvamaks teeb kogu töövoo dekompileerimisest analüüsi, ümberehituse ja allkirjastamiseni.

[Vaata demo YouTube'is](https://youtu.be/Mkdt0c-7Wwg)

PulseAPK on korraldatud ühe akna töövoona, mille ülanavigatsioonis on tööriistad: **Decompile**, **Build**, **Analyser**, **Settings** ja **About**. Iga jaotis katab ühe APK elutsükli etapi, et saaksid liikuda dekodeerimiselt analüüsile ja allkirjastamisele rakendusest lahkumata.

## Põhifunktsioonid

- **🛡️ Staatiline turvaanalüüs**: skaneerib Smali koodi automaatselt haavatavuste suhtes, sh root-tuvastus, emulaatori kontrollid, kõvakodeeritud mandaatandmed ja ebaturvaline SQL/HTTP kasutus.
- **⚙️ Dünaamiline reeglimootor**: täielikult kohandatavad analüüsireeglid `smali_analysis_rules.json` kaudu. Tuvastusmustreid saab muuta ilma rakendust taaskäivitamata. Vahemälu tagab optimaalse jõudluse.
- **🚀 Kaasaegne UI/UX**: reageeriv tume kasutajaliides tõhusa töö jaoks koos reaalajas konsooli tagasisidega.
- **📦 Täielik töövoog**: dekompileeri, analüüsi, muuda, ehita uuesti ja allkirjasta APK-sid ühes keskkonnas.
- **⚡ Turvaline ja töökindel**: sisaldab nutikat valideerimist ja kokkujooksmiste ennetamist tööruumi ja andmete kaitseks.
- **🔧 Täielikult seadistatav**: halda tööriistateid (Java, Apktool), tööruumi sätteid ja analüüsiparameetreid hõlpsalt.

## Täiustatud võimalused

### Turvaanalüüs
PulseAPK sisaldab sisseehitatud staatilist analüsaatorit, mis skaneerib dekompileeritud koodi levinud turvaindikaatorite suhtes:
- **Root-tuvastus**: tuvastab Magisk-, SuperSU- ja levinud root-binaaride kontrolle.
- **Emulaatori tuvastus**: leiab QEMU, Genymotioni ja kindlate süsteemiomaduste kontrolle.
- **Tundlikud andmed**: skaneerib kõvakodeeritud API-võtmeid, tokeneid ja Basic Auth päiseid.
- **Ebaturvaline võrgundus**: märgib HTTP kasutuse ja võimalikud andmelekkepunktid.

*Reeglid on defineeritud failis `smali_analysis_rules.json` ja neid saab kohandada vastavalt vajadustele.*

### APK haldus
- **Dekompleerimine**: dekodeeri ressursid ja lähtekoodid seadistatavate valikutega.
- **Ümberehitus**: ehita muudetud projektid tagasi kehtivateks APK-deks.
- **Allkirjastamine**: integreeritud keystore haldus ümberehitatud APK-de allkirjastamiseks, et need oleksid installimiseks valmis.

## Eeldused

1.  **Java Runtime Environment (JRE)**: vajalik `apktool`-i jaoks. Veendu, et `java` on süsteemi `PATH`-is.
2.  **Apktool**: laadi `apktool.jar` alla aadressilt [ibotpeaches.github.io](https://ibotpeaches.github.io/Apktool/).
3.  **Ubersign (Uber APK Signer)**: vajalik ümberehitatud APK-de allkirjastamiseks. Laadi uusim `uber-apk-signer.jar` [GitHub releases](https://github.com/patrickfav/uber-apk-signer/releases) lehelt.
4.  **.NET 8.0 Runtime**: vajalik PulseAPK käitamiseks toetatud platvormidel (Windows, Linux ja macOS).

## Kiirstart

1.  **Laadi alla ja ehita**
    ```powershell
    dotnet build
    dotnet run
    ```

2.  **Seadistamine**
    - Ava **Settings**.
    - Seo `apktool.jar` asukoht.
    - PulseAPK tuvastab Java paigalduse automaatselt keskkonnamuutujate põhjal.

3.  **APK analüüs**
    - **Dekompleeri** siht-APK Decompile vahelehel.
    - Lülitu **Analysis** vahelehele.
    - Vali dekompileeritud projekti kaust.
    - Klõpsa **Analyze Smali**, et luua turvaraport.

4.  **Muuda ja ehita uuesti**
    - Redigeeri projektikausta faile.
    - Kasuta **Build** vahelehte uue APK ehitamiseks.
    - Kasuta **Sign** vahelehte väljundi APK allkirjastamiseks.


## Ekraanipildid

### 1) Dekompileerimise töövoog
![PulseAPK dekompileerimise vaade](images/pulse_apk_decompile.png)
- Sellel ekraanil valid sisend-APK ja väljundkausta ning käivitad dekompileerimise.
- Lihtne voog: vali APK -> määra väljundtee -> klõpsa decompile.

### 2) Ehitamise töövoog
![PulseAPK ehitamise vaade](images/pulse_apk_build.png)
- Sellel ekraanil ehitatakse dekompileeritud projekt uuesti uueks APK-ks.
- Lihtne voog: vali projekti kaust -> määra väljundi nimi/tee -> klõpsa build (vajadusel lülita allkirjastamine sisse).

### 3) Staatilise analüüsi tulemused
![PulseAPK analüüsi väljund](images/pulse_apk_analysis.png)
- See vaade näitab Smali/staatilise analüüsi turvaleide.
- Lihtne voog: kõigepealt dekompileeri -> ava analüüsi vahekaart/väljund -> vaata tulemused üle ja ekspordi aruanne.


## Tehniline arhitektuur

PulseAPK kasutab selget MVVM (Model-View-ViewModel) arhitektuuri:

- **Core**: .NET 8.0, Avalonia.
- **Analysis**: kohandatud regex-põhine staatilise analüüsi mootor koos kuumtaaslaetavate reeglitega.
- **Services**: eraldi teenused Apktooli integratsiooniks, failisüsteemi jälgimiseks ja sätete haldamiseks.

## Litsents

See projekt on avatud lähtekoodiga ja saadaval [Apache License 2.0](LICENSE.md) alusel.

### ❤️ Toeta projekti

Kui PulseAPK on sinu jaoks kasulik, saad arendust toetada, vajutades lehe ülaosas nuppu "Support".

Ka repositooriumi tähistamine tähega aitab palju.

### Panustamine

Ootame panuseid! Palun arvesta, et kõik panustajad peavad allkirjastama [Contributor License Agreement (CLA)](CLA.md), et nende töö oleks seaduslikult levitatav.
Pull requesti esitamisega nõustud CLA tingimustega.
