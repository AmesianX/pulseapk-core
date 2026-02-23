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

**PulseAPK** היא ממשק גרפי מקצועי להנדסה לאחור של Android ולניתוח אבטחה, בנוי עם Avalonia (.NET 8). הוא משלב את העוצמה של `apktool` עם יכולות ניתוח סטטי מתקדמות, עטוף בממשק מהיר בהשראת סייברפאנק. PulseAPK מייעל את כל תהליך העבודה מפירוק ועד ניתוח, בנייה מחדש וחתימה.

[צפו בדמו ביוטיוב](https://youtu.be/Mkdt0c-7Wwg)

PulseAPK מאורגן כזרימת עבודה בחלון יחיד עם ניווט עליון לכל כלי: **Decompile**, **Build**, **Analyser**, **Settings** ו-**About**. כל חלק מתמקד בשלב אחד במחזור החיים של APK כדי שתוכלו לעבור מפענוח לניתוח ולחתימה בלי לצאת מהיישום.

## תכונות מרכזיות

- **🛡️ ניתוח אבטחה סטטי**: סריקה אוטומטית של קוד Smali לאיתור חולשות, כולל זיהוי Root, בדיקות אמולטור, אישורים קשיחים ושימוש לא מאובטח ב-SQL/HTTP.
- **⚙️ מנוע חוקים דינמי**: חוקים ניתנים להתאמה מלאה דרך `smali_analysis_rules.json`. אפשר לשנות דפוסי זיהוי בלי להפעיל מחדש את האפליקציה. משתמש בקאשינג לביצועים מיטביים.
- **🚀 ממשק מודרני**: ממשק כהה ותגובתי שמיועד ליעילות, עם משוב קונסולה בזמן אמת.
- **📦 תהליך עבודה מלא**: פירוק, ניתוח, עריכה, בנייה מחדש וחתימה של APKs בסביבה אחת.
- **⚡ בטוח ועמיד**: כולל אימות חכם ומנגנוני מניעת קריסה להגנה על סביבת העבודה והנתונים.
- **🔧 ניתן להגדרה מלאה**: ניהול נתיבי כלים (Java, Apktool), הגדרות סביבת עבודה ופרמטרי ניתוח בקלות.

## יכולות מתקדמות

### ניתוח אבטחה
PulseAPK כולל מנתח סטטי מובנה שסורק קוד מפורק לאיתור אינדיקטורים אבטחתיים נפוצים:
- **זיהוי Root**: מזהה בדיקות עבור Magisk, SuperSU וקבצי Root נפוצים.
- **זיהוי אמולטור**: מאתר בדיקות עבור QEMU, Genymotion ומאפייני מערכת ספציפיים.
- **נתונים רגישים**: סורק מפתחות API קשיחים, טוקנים וכותרות Basic Auth.
- **רשת לא מאובטחת**: מסמן שימוש ב-HTTP ונקודות דליפת מידע אפשריות.

*החוקים מוגדרים ב-`smali_analysis_rules.json` וניתנים להתאמה לצרכים שלך.*

### ניהול APK
- **פירוק**: פענוח משאבים וקוד מקור עם אפשרויות ניתנות להגדרה.
- **בנייה מחדש**: בניית פרויקטים ששונו ל-APK תקין.
- **חתימה**: ניהול Keystore מובנה לחתימת APKים שנבנו מחדש, כדי שיהיו מוכנים להתקנה.

## דרישות מקדימות

1.  **Java Runtime Environment (JRE)**: נדרש עבור `apktool`. ודאו ש-`java` נמצא ב-`PATH` של המערכת.
2.  **Apktool**: הורידו את `apktool.jar` מ-[ibotpeaches.github.io](https://ibotpeaches.github.io/Apktool/).
3.  **Ubersign (Uber APK Signer)**: נדרש לחתימת APKs שנבנו מחדש. הורידו את הגרסה האחרונה של `uber-apk-signer.jar` מ-[GitHub releases](https://github.com/patrickfav/uber-apk-signer/releases).
4.  **.NET 8.0 Runtime**: נדרש להרצת PulseAPK בפלטפורמות נתמכות (Windows, Linux ו-macOS).

## מדריך התחלה מהירה

1.  **הורדה ובנייה**
    ```powershell
    dotnet build
    dotnet run
    ```

2.  **הגדרה**
    - פתחו את **Settings**.
    - הגדירו את הנתיב ל-`apktool.jar`.
    - PulseAPK יזהה אוטומטית את התקנת Java לפי משתני סביבה.

3.  **ניתוח APK**
    - **פרקו** את ה-APK היעד בלשונית Decompile.
    - עברו ללשונית **Analysis**.
    - בחרו את תיקיית הפרויקט שפורקה.
    - לחצו על **Analyze Smali** כדי ליצור דוח אבטחה.

4.  **שינוי ובנייה מחדש**
    - ערכו קבצים בתיקיית הפרויקט.
    - השתמשו בלשונית **Build** כדי לבנות APK חדש.
    - השתמשו בלשונית **Sign** כדי לחתום על ה-APK שנוצר.


## צילומי מסך

### 1) תהליך דה-קומפילציה
![מסך דה-קומפילציה של PulseAPK](images/pulse_apk_decompile.png)
- במסך זה בוחרים APK קלט ותיקיית פלט, ואז מפעילים דה-קומפילציה.
- זרימה פשוטה: לבחור APK -> להגדיר נתיב פלט -> ללחוץ decompile.

### 2) תהליך בנייה
![מסך בנייה של PulseAPK](images/pulse_apk_build.png)
- במסך זה בונים מחדש פרויקט מפורק ל-APK חדש.
- זרימה פשוטה: לבחור תיקיית פרויקט -> להגדיר שם/נתיב פלט -> ללחוץ build (ולהפעיל חתימה לפי הצורך).

### 3) תוצאות ניתוח סטטי
![פלט ניתוח של PulseAPK](images/pulse_apk_analysis.png)
- תצוגה זו מציגה ממצאי אבטחה מניתוח Smali/ניתוח סטטי.
- זרימה פשוטה: קודם לבצע דה-קומפילציה -> לפתוח את לשונית/פלט הניתוח -> לעבור על הממצאים ולייצא דוח.


## ארכיטקטורה טכנית

PulseAPK משתמש בארכיטקטורת MVVM (Model-View-ViewModel) נקייה:

- **Core**: .NET 8.0, Avalonia.
- **Analysis**: מנוע ניתוח סטטי מבוסס Regex עם חוקים לטעינה מחדש.
- **Services**: שירותים ייעודיים לאינטראקציה עם Apktool, ניטור מערכת קבצים וניהול הגדרות.

## רישיון

הפרויקט הוא קוד פתוח וזמין תחת [Apache License 2.0](LICENSE.md).

### ❤️ תמיכה בפרויקט

אם PulseAPK שימושי עבורך, אפשר לתמוך בפיתוחו על ידי לחיצה על כפתור "Support" בראש העמוד.

גם סימון כוכב למאגר עוזר מאוד.

### תרומה

נשמח לתרומות! שימו לב שכל התורמים חייבים לחתום על [Contributor License Agreement (CLA)](CLA.md) כדי להבטיח שעבודתם תוכל להיות מופצת בצורה חוקית.
בשליחת Pull Request, אתם מסכימים לתנאי ה-CLA.
