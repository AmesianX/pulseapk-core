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

**PulseAPK** on Androidin käänteismallinnuksen ja turvallisuusanalyysin ammattitason GUI, joka on rakennettu Avalonia (.NET 8):lla. Se yhdistää `apktool`-työkalun raakavoiman edistyneisiin staattisen analyysin ominaisuuksiin ja tarjoaa suorituskykyisen, kyberpunk-henkisen käyttöliittymän. PulseAPK sujuvoittaa koko työnkulun purkamisesta analyysiin, uudelleenrakennukseen ja allekirjoittamiseen.

[Katso demo YouTubessa](https://youtu.be/Mkdt0c-7Wwg)

PulseAPK on järjestetty yhden ikkunan työnkuluksi, jossa on ylävalikossa työkalut: **Decompile**, **Build**, **Analyser**, **Settings** ja **About**. Jokainen osio kattaa APK:n elinkaaren yhden vaiheen, jotta voit siirtyä dekoodauksesta analyysiin ja allekirjoitukseen poistumatta sovelluksesta.

## Avainominaisuudet

- **🛡️ Staattinen turvallisuusanalyysi**: skannaa Smali-koodin haavoittuvuuksien varalta, mukaan lukien root-tunnistus, emulaattoritarkistukset, kovakoodatut tunnistetiedot ja turvaton SQL/HTTP-käyttö.
- **⚙️ Dynaaminen sääntökone**: täysin muokattavat analyysisäännöt `smali_analysis_rules.json`-tiedostolla. Tunnistusmalleja voi muuttaa ilman uudelleenkäynnistystä. Välimuisti parantaa suorituskykyä.
- **🚀 Moderni UI/UX**: responsiivinen tumma käyttöliittymä tehokasta työskentelyä varten, reaaliaikaisella konsolipalautteella.
- **📦 Täydellinen työnkulku**: purku, analyysi, muokkaus, uudelleenrakennus ja APK-allekirjoitus yhdessä ympäristössä.
- **⚡ Turvallinen ja luotettava**: älykäs validointi ja kaatumisen estomekanismit suojaavat työtilaa ja dataa.
- **🔧 Täysin konfiguroitava**: hallitse työkalupolut (Java, Apktool), työtilan asetukset ja analyysiparametrit helposti.

## Edistyneet ominaisuudet

### Turvallisuusanalyysi
PulseAPK sisältää sisäänrakennetun staattisen analysoijan, joka skannaa puretun koodin yleisten turvallisuusindikaattorien varalta:
- **Root-tunnistus**: tunnistaa Magisk-, SuperSU- ja yleiset root-binaarit.
- **Emulaattoritunnistus**: löytää QEMU-, Genymotion- ja tietyt järjestelmäominaisuuksien tarkistukset.
- **Arkaluonteiset tiedot**: skannaa kovakoodatut API-avaimet, tokenit ja Basic Auth -otsikot.
- **Turvaton verkotus**: merkitsee HTTP-käytön ja mahdolliset tietovuotokohdat.

*Säännöt määritellään `smali_analysis_rules.json`-tiedostossa ja ne voidaan räätälöidä tarpeisiisi.*

### APK-hallinta
- **Purku**: dekoodaa resurssit ja lähdekoodit helposti muokattavilla asetuksilla.
- **Uudelleenrakennus**: rakentaa muokatut projektit takaisin kelvollisiksi APK-tiedostoiksi.
- **Allekirjoitus**: integroitu keystore-hallinta allekirjoittaa uudelleenrakennetut APK:t asennusvalmiiksi.

## Esivaatimukset

1.  **Java Runtime Environment (JRE)**: vaaditaan `apktool`-työkalulle. Varmista, että `java` on järjestelmän `PATH`-polussa.
2.  **Apktool**: lataa `apktool.jar` osoitteesta [ibotpeaches.github.io](https://ibotpeaches.github.io/Apktool/).
3.  **Ubersign (Uber APK Signer)**: vaaditaan uudelleenrakennettujen APK:iden allekirjoittamiseen. Lataa uusin `uber-apk-signer.jar` [GitHub releases](https://github.com/patrickfav/uber-apk-signer/releases) -sivulta.
4.  **.NET 8.0 Runtime**: vaaditaan PulseAPK:n suorittamiseen tuetuilla alustoilla (Windows, Linux ja macOS).

## Pika-aloitus

1.  **Lataa ja rakenna**
    ```powershell
    dotnet build
    dotnet run
    ```

2.  **Määritys**
    - Avaa **Settings**.
    - Määritä `apktool.jar`-polku.
    - PulseAPK tunnistaa Java-asennuksen automaattisesti ympäristömuuttujien perusteella.

3.  **APK:n analysointi**
    - **Pura** kohde-APK Decompile-välilehdellä.
    - Siirry **Analysis**-välilehdelle.
    - Valitse purettu projektikansio.
    - Napsauta **Analyze Smali** luodaksesi turvallisuusraportin.

4.  **Muokkaa ja rakenna uudelleen**
    - Muokkaa projektikansion tiedostoja.
    - Käytä **Build**-välilehteä uuden APK:n rakentamiseen.
    - Käytä **Sign**-välilehteä tulos-APK:n allekirjoittamiseen.


## Kuvakaappaukset

### 1) Dekompiloinnin työnkulku
![PulseAPK dekompilointinäkymä](images/pulse_apk_decompile.png)
- Tässä näkymässä valitset syöte-APK:n ja tuloskansion ja käynnistät dekompiloinnin.
- Yksinkertainen kulku: valitse APK -> aseta tulospolku -> klikkaa decompile.

### 2) Build-työnkulku
![PulseAPK build-näkymä](images/pulse_apk_build.png)
- Tässä näkymässä dekompiloitu projekti rakennetaan uudeksi APK:ksi.
- Yksinkertainen kulku: valitse projektikansio -> aseta tulosnimi/-polku -> klikkaa build (ja ota allekirjoitus käyttöön tarvittaessa).

### 3) Staattisen analyysin tulokset
![PulseAPK analyysituloste](images/pulse_apk_analysis.png)
- Tämä näkymä näyttää Smali-/staattisen analyysin turvallisuushavainnot.
- Yksinkertainen kulku: dekompiloi ensin -> avaa analyysivälilehti/tuloste -> käy havainnot läpi ja vie raportti.


## Tekninen arkkitehtuuri

PulseAPK hyödyntää selkeää MVVM-arkkitehtuuria (Model-View-ViewModel):

- **Core**: .NET 8.0, Avalonia.
- **Analysis**: oma regex-pohjainen staattinen analyysimoottori, jossa säännöt voidaan ladata uudelleen.
- **Services**: omistetut palvelut Apktool-integraatiolle, tiedostojärjestelmän seurannalle ja asetusten hallinnalle.

## Lisenssi

Tämä projekti on avointa lähdekoodia ja saatavilla [Apache License 2.0](LICENSE.md) -lisenssillä.

### ❤️ Tue projektia

Jos PulseAPK on sinulle hyödyllinen, voit tukea kehitystä painamalla yläreunan "Support"-painiketta.

Myös tähden antaminen repositoriolle auttaa paljon.

### Osallistuminen

Otamme mielellämme vastaan kontribuutioita! Huomioithan, että kaikkien osallistujien on allekirjoitettava [Contributor License Agreement (CLA)](CLA.md), jotta heidän työnsä voidaan jakaa laillisesti.
Pull requestin lähettämällä hyväksyt CLA:n ehdot.
