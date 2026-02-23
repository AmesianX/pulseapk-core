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

**PulseAPK** je profesionálne GUI na reverzné inžinierstvo Androidu a bezpečnostnú analýzu, postavené na Avalonia (.NET 8). Spája surovú silu `apktool` s pokročilými možnosťami statickej analýzy v rýchlom, cyberpunkom inšpirovanom rozhraní. PulseAPK zjednodušuje celý pracovný postup od dekompilácie cez analýzu, prestavbu až po podpis.

[Pozrieť demo na YouTube](https://youtu.be/Mkdt0c-7Wwg)

PulseAPK je organizovaný ako workflow v jednom okne s hornou navigáciou pre každý nástroj: **Decompile**, **Build**, **Analyser**, **Settings** a **About**. Každá sekcia pokrýva jednu fázu životného cyklu APK, aby ste mohli prechádzať od dekódovania k analýze a podpisu bez opustenia aplikácie.

## Kľúčové funkcie

- **🛡️ Statická bezpečnostná analýza**: automaticky skenuje Smali kód na zraniteľnosti, vrátane detekcie rootu, kontrol emulátora, natvrdo zakódovaných prihlasovacích údajov a nezabezpečeného použitia SQL/HTTP.
- **⚙️ Dynamický engine pravidiel**: úplne prispôsobiteľné analytické pravidlá cez `smali_analysis_rules.json`. Vzory detekcie možno meniť bez reštartu aplikácie. Kešovanie zabezpečuje optimálny výkon.
- **🚀 Moderné UI/UX**: responzívne tmavé rozhranie navrhnuté pre efektivitu so spätnou väzbou konzoly v reálnom čase.
- **📦 Kompletný workflow**: dekompilácia, analýza, úpravy, prestavba a podpis APK v jednom prostredí.
- **⚡ Bezpečné a robustné**: zahŕňa inteligentnú validáciu a prevenciu pádov na ochranu pracovného priestoru a dát.
- **🔧 Plne konfigurovateľné**: správa ciest nástrojov (Java, Apktool), nastavení pracovného priestoru a analytických parametrov.

## Pokročilé možnosti

### Bezpečnostná analýza
PulseAPK obsahuje vstavaný statický analyzátor, ktorý skenuje dekompilovaný kód na bežné bezpečnostné indikátory:
- **Detekcia rootu**: identifikuje kontroly Magisk, SuperSU a bežných root binárnych súborov.
- **Detekcia emulátora**: nachádza kontroly QEMU, Genymotion a špecifických systémových vlastností.
- **Citlivé údaje**: skenuje natvrdo zakódované API kľúče, tokeny a hlavičky Basic Auth.
- **Nezabezpečené siete**: označuje používanie HTTP a potenciálne miesta úniku dát.

*Pravidlá sú definované v `smali_analysis_rules.json` a dajú sa prispôsobiť vašim potrebám.*

### Správa APK
- **Dekomplikácia**: jednoduché dekódovanie zdrojov a kódu s konfigurovateľnými voľbami.
- **Prestavba**: prestavia upravené projekty do platných APK.
- **Podpisovanie**: integrovaná správa keystore na podpisovanie prestavaných APK, aby boli pripravené na inštaláciu.

## Požiadavky

1.  **Java Runtime Environment (JRE)**: vyžaduje sa pre `apktool`. Uistite sa, že `java` je v `PATH`.
2.  **Apktool**: stiahnite `apktool.jar` z [ibotpeaches.github.io](https://ibotpeaches.github.io/Apktool/).
3.  **Ubersign (Uber APK Signer)**: vyžaduje sa na podpisovanie prestavaných APK. Stiahnite najnovší `uber-apk-signer.jar` z [GitHub releases](https://github.com/patrickfav/uber-apk-signer/releases).
4.  **.NET 8.0 Runtime**: vyžaduje sa na spustenie PulseAPK na podporovaných platformách (Windows, Linux a macOS).

## Rýchly štart

1.  **Stiahnuť a zostaviť**
    ```powershell
    dotnet build
    dotnet run
    ```

2.  **Nastavenie**
    - Otvorte **Settings**.
    - Nastavte cestu k `apktool.jar`.
    - PulseAPK automaticky zistí inštaláciu Javy na základe premenných prostredia.

3.  **Analýza APK**
    - **Dekomplikujte** cieľový APK v karte Decompile.
    - Prepnite na kartu **Analysis**.
    - Vyberte priečinok dekompilovaného projektu.
    - Kliknite na **Analyze Smali**, aby sa vytvorila bezpečnostná správa.

4.  **Úpravy a prestavba**
    - Upravte súbory v priečinku projektu.
    - Použite kartu **Build** na zostavenie nového APK.
    - Použite kartu **Sign** na podpis výstupného APK.


## Snímky obrazovky

### 1) Workflow dekompilácie
![Obrazovka dekompilácie PulseAPK](images/pulse_apk_decompile.png)
- Táto obrazovka slúži na výber vstupného APK a výstupného priečinka a následné spustenie dekompilácie.
- Jednoduchý postup: vybrať APK -> nastaviť výstupnú cestu -> kliknúť na decompile.

### 2) Workflow zostavenia
![Obrazovka zostavenia PulseAPK](images/pulse_apk_build.png)
- Táto obrazovka slúži na prestavbu dekompilovaného projektu do nového APK.
- Jednoduchý postup: vybrať priečinok projektu -> nastaviť názov/cestu výstupu -> kliknúť na build (a podľa potreby zapnúť podpis).

### 3) Výsledky statickej analýzy
![Výstup analýzy PulseAPK](images/pulse_apk_analysis.png)
- Toto zobrazenie ukazuje bezpečnostné nálezy zo Smali/statickej analýzy.
- Jednoduchý postup: najprv dekompilovať -> otvoriť kartu/výstup analýzy -> skontrolovať nálezy a exportovať report.


## Technická architektúra

PulseAPK používa čistú MVVM (Model-View-ViewModel) architektúru:

- **Core**: .NET 8.0, Avalonia.
- **Analysis**: vlastný regexový statický analyzátor s pravidlami pre hot reload.
- **Services**: dedikované služby pre integráciu Apktool, monitoring súborového systému a správu nastavení.

## Licencia

Tento projekt je open-source a dostupný pod licenciou [Apache License 2.0](LICENSE.md).

### ❤️ Podporte projekt

Ak je PulseAPK pre vás užitočný, môžete podporiť jeho vývoj stlačením tlačidla "Support" hore.

Hviezdička repozitára tiež veľmi pomáha.

### Prispievanie

Príspevky vítame! Upozorňujeme, že všetci prispievatelia musia podpísať [Contributor License Agreement (CLA)](CLA.md), aby ich práca mohla byť legálne distribuovaná.
Odoslaním pull requestu súhlasíte s podmienkami CLA.
