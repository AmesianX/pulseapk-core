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

**PulseAPK** es una GUI de nivel profesional para ingeniería inversa de Android y análisis de seguridad, creada con Avalonia (.NET 8). Combina el poder de `apktool` con capacidades avanzadas de análisis estático, envueltas en una interfaz de alto rendimiento con estética cyberpunk. PulseAPK optimiza todo el flujo de trabajo desde la decompilación hasta el análisis, la recompilación y la firma.

[Ver la demo en YouTube](https://youtu.be/Mkdt0c-7Wwg)

PulseAPK está organizado como un flujo de trabajo en una sola ventana con navegación superior para cada herramienta: **Decompile**, **Build**, **Analyser**, **Settings** y **About**. Cada sección cubre una etapa del ciclo de vida del APK para que puedas pasar de la decodificación al análisis y firmado sin salir de la aplicación.

## Funcionalidades clave

- **🛡️ Análisis de seguridad estático**: Escanea automáticamente el código Smali en busca de vulnerabilidades, incluida la detección de root, comprobaciones de emulador, credenciales codificadas y uso inseguro de SQL/HTTP.
- **⚙️ Motor de reglas dinámico**: Reglas de análisis totalmente personalizables a través de `smali_analysis_rules.json`. Modifica los patrones de detección al vuelo sin reiniciar la aplicación. Usa caché para un rendimiento óptimo.
- **🚀 UI/UX moderno**: Interfaz oscura y adaptable diseñada para la eficiencia, con salida de consola en tiempo real.
- **📦 Flujo de trabajo completo**: Decompila, analiza, edita, recompila y firma APKs en un único entorno.
- **⚡ Seguro y robusto**: Incluye validación inteligente y prevención de fallos para proteger tu espacio de trabajo y tus datos.
- **🔧 Totalmente configurable**: Gestiona rutas de herramientas (Java, Apktool), ajustes del espacio de trabajo y parámetros de análisis con facilidad.

## Capacidades avanzadas

### Análisis de seguridad
PulseAPK incluye un analizador estático integrado que escanea el código decompilado en busca de indicadores de seguridad comunes:
- **Detección de root**: Identifica comprobaciones de Magisk, SuperSU y binarios de root comunes.
- **Detección de emulador**: Encuentra comprobaciones de QEMU, Genymotion y propiedades específicas del sistema.
- **Datos sensibles**: Escanea claves API, tokens y encabezados basic auth codificados.
- **Red insegura**: Marca el uso de HTTP y posibles puntos de fuga de datos.

*Las reglas se definen en `smali_analysis_rules.json` y se pueden personalizar según tus necesidades.*

### Gestión de APK
- **Decompilación**: Decodifica recursos y fuentes sin esfuerzo con opciones configurables.
- **Recompilación**: Reconstruye tus proyectos modificados en APKs válidos.
- **Firma**: Gestión integrada de keystore para firmar APKs recompilados y dejarlos listos para instalar en dispositivos.

## Requisitos previos

1.  **Java Runtime Environment (JRE)**: Necesario para `apktool`. Asegúrate de que `java` esté en tu `PATH`.
2.  **Apktool**: Descarga `apktool.jar` desde [ibotpeaches.github.io](https://ibotpeaches.github.io/Apktool/).
3.  **Ubersign (Uber APK Signer)**: Necesario para firmar APKs recompilados. Descarga la última versión de `uber-apk-signer.jar` desde las [releases de GitHub](https://github.com/patrickfav/uber-apk-signer/releases).
4.  **.NET 8.0 Runtime**: Necesario para ejecutar PulseAPK en plataformas compatibles (Windows, Linux y macOS).

## Guía de inicio rápido

1.  **Descargar y compilar**
    ```powershell
    dotnet build
    dotnet run
    ```

2.  **Configuración**
    - Abre **Settings**.
    - Indica la ruta de `apktool.jar`.
    - PulseAPK detectará automáticamente tu instalación de Java según las variables de entorno.

3.  **Analizar un APK**
    - **Decompila** tu APK objetivo en la pestaña Decompile.
    - Cambia a la pestaña **Analysis**.
    - Selecciona la carpeta del proyecto decompilado.
    - Haz clic en **Analyze Smali** para generar un informe de seguridad.

4.  **Modificar y recompilar**
    - Edita los archivos en la carpeta del proyecto.
    - Usa la pestaña **Build** para recompilar en un nuevo APK.
    - Usa la pestaña **Sign** para firmar el APK resultante.


## Capturas de pantalla

### 1) Flujo de decompilación
![Pantalla de decompilación de PulseAPK](images/pulse_apk_decompile.png)
- Esta pantalla se usa para elegir el APK de entrada y la carpeta de salida, y luego ejecutar la decompilación.
- Flujo simple: seleccionar APK -> definir ruta de salida -> pulsar decompile.

### 2) Flujo de compilación
![Pantalla de compilación de PulseAPK](images/pulse_apk_build.png)
- Esta pantalla se usa para recompilar un proyecto decompilado en un nuevo APK.
- Flujo simple: seleccionar carpeta del proyecto -> elegir nombre/ruta de salida -> pulsar build (y activar firma si hace falta).

### 3) Resultados del análisis estático
![Salida de análisis de PulseAPK](images/pulse_apk_analysis.png)
- Esta vista muestra hallazgos de seguridad del análisis Smali/estático.
- Flujo simple: primero decompilar -> abrir pestaña/salida de análisis -> revisar hallazgos y exportar informe.

## Arquitectura técnica

PulseAPK utiliza una arquitectura MVVM (Model-View-ViewModel) limpia:

- **Core**: .NET 8.0, Avalonia.
- **Analysis**: Motor de análisis estático personalizado basado en regex con reglas recargables en caliente.
- **Services**: servicios dedicados para la interacción con Apktool, el monitoreo del sistema de archivos y la gestión de configuraciones.

## Licencia

Este proyecto es de código abierto y está disponible bajo la [Apache License 2.0](LICENSE.md).

### ❤️ Apoya el proyecto

Si PulseAPK te resulta útil, puedes apoyar su desarrollo pulsando el botón "Support" en la parte superior.

Dar una estrella al repositorio también ayuda mucho.

### Contribuciones

¡Damos la bienvenida a las contribuciones! Ten en cuenta que todos los colaboradores deben firmar nuestro [Contributor License Agreement (CLA)](CLA.md) para que su trabajo pueda distribuirse legalmente.
Al enviar un pull request, aceptas los términos del CLA.
