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

**PulseAPK** é uma GUI de nível profissional para engenharia reversa e análise de segurança no Android, construída com Avalonia (.NET 8). Ela combina o poder bruto do `apktool` com recursos avançados de análise estática, envoltos em uma interface de alto desempenho com inspiração cyberpunk. O PulseAPK simplifica todo o fluxo de trabalho, da decompilação à análise, reconstrução e assinatura.

[Assista à demo no YouTube](https://youtu.be/Mkdt0c-7Wwg)

O PulseAPK é organizado em um fluxo de trabalho de janela única com navegação superior para cada ferramenta: **Decompile**, **Build**, **Analyser**, **Settings** e **About**. Cada seção cobre uma etapa do ciclo de vida do APK para que você vá da decodificação à análise e assinatura sem sair do app.

## Principais recursos

- **🛡️ Análise de segurança estática**: Varre automaticamente o código Smali em busca de vulnerabilidades, incluindo detecção de root, verificações de emulador, credenciais codificadas e uso inseguro de SQL/HTTP.
- **⚙️ Motor de regras dinâmico**: Regras de análise totalmente personalizáveis via `smali_analysis_rules.json`. Modifique padrões de detecção em tempo real sem reiniciar o aplicativo. Usa cache para desempenho ideal.
- **🚀 UI/UX moderno**: Interface escura e responsiva projetada para eficiência, com feedback de console em tempo real.
- **📦 Fluxo de trabalho completo**: Descompilar, analisar, editar, recompilar e assinar APKs em um ambiente unificado.
- **⚡ Seguro e robusto**: Inclui validação inteligente e prevenção de falhas para proteger seu workspace e dados.
- **🔧 Totalmente configurável**: Gerencie caminhos de ferramentas (Java, Apktool), configurações do workspace e parâmetros de análise com facilidade.

## Capacidades avançadas

### Análise de segurança
O PulseAPK inclui um analisador estático embutido que varre o código decompilado em busca de indicadores de segurança comuns:
- **Detecção de root**: Identifica verificações para Magisk, SuperSU e binários de root comuns.
- **Detecção de emulador**: Encontra verificações para QEMU, Genymotion e propriedades específicas do sistema.
- **Dados sensíveis**: Varre chaves de API, tokens e cabeçalhos basic auth codificados.
- **Rede insegura**: Sinaliza o uso de HTTP e possíveis pontos de vazamento de dados.

*As regras são definidas em `smali_analysis_rules.json` e podem ser personalizadas conforme suas necessidades.*

### Gerenciamento de APK
- **Descompilação**: Decodifique recursos e fontes com opções configuráveis.
- **Recompilação**: Reconstrua seus projetos modificados em APKs válidos.
- **Assinatura**: Gerenciamento integrado de keystore para assinar APKs recompilados, garantindo que estejam prontos para instalação no dispositivo.

## Pré-requisitos

1.  **Java Runtime Environment (JRE)**: Necessário para `apktool`. Garanta que `java` esteja no seu `PATH`.
2.  **Apktool**: Baixe `apktool.jar` em [ibotpeaches.github.io](https://ibotpeaches.github.io/Apktool/).
3.  **Ubersign (Uber APK Signer)**: Necessário para assinar APKs recompilados. Baixe a versão mais recente de `uber-apk-signer.jar` nos [releases do GitHub](https://github.com/patrickfav/uber-apk-signer/releases).
4.  **.NET 8.0 Runtime**: Necessário para executar o PulseAPK em plataformas compatíveis (Windows, Linux e macOS).

## Guia de início rápido

1.  **Baixar e compilar**
    ```powershell
    dotnet build
    dotnet run
    ```

2.  **Configuração**
    - Abra **Settings**.
    - Informe o caminho para `apktool.jar`.
    - O PulseAPK detectará automaticamente sua instalação do Java com base nas variáveis de ambiente.

3.  **Analisar um APK**
    - **Descompile** seu APK alvo na aba Decompile.
    - Vá para a aba **Analysis**.
    - Selecione a pasta do projeto decompilado.
    - Clique em **Analyze Smali** para gerar um relatório de segurança.

4.  **Modificar e recompilar**
    - Edite arquivos na pasta do projeto.
    - Use a aba **Build** para recompilar em um novo APK.
    - Use a aba **Sign** para assinar o APK de saída.


## Capturas de tela

### 1) Fluxo de decompilação
![Tela de decompilação do PulseAPK](images/pulse_apk_decompile.png)
- Esta tela é usada para escolher o APK de entrada e a pasta de saída, e então executar a decompilação.
- Fluxo simples: selecionar APK -> definir caminho de saída -> clicar em decompile.

### 2) Fluxo de build
![Tela de build do PulseAPK](images/pulse_apk_build.png)
- Esta tela é usada para recompilar um projeto decompilado em um novo APK.
- Fluxo simples: selecionar pasta do projeto -> escolher nome/caminho de saída -> clicar em build (e habilitar assinatura se necessário).

### 3) Resultados da análise estática
![Saída de análise do PulseAPK](images/pulse_apk_analysis.png)
- Esta visualização mostra os achados de segurança da análise Smali/estática.
- Fluxo simples: primeiro decompilar -> abrir aba/saída de análise -> revisar achados e exportar relatório.

## Arquitetura técnica

O PulseAPK utiliza uma arquitetura MVVM (Model-View-ViewModel) limpa:

- **Core**: .NET 8.0, Avalonia.
- **Analysis**: Motor de análise estática personalizado baseado em regex com regras de recarga a quente.
- **Services**: serviços dedicados para interação com Apktool, monitoramento do sistema de arquivos e gerenciamento de configurações.

## Licença

Este projeto é open source e está disponível sob a [Apache License 2.0](LICENSE.md).

### ❤️ Apoie o projeto

Se o PulseAPK for útil para você, pode apoiar seu desenvolvimento clicando no botão "Support" no topo.

Dar uma estrela ao repositório também ajuda bastante.

### Contribuições

Aceitamos contribuições! Observe que todos os colaboradores devem assinar nosso [Contributor License Agreement (CLA)](CLA.md) para que seu trabalho possa ser distribuído legalmente.
Ao enviar um pull request, você concorda com os termos do CLA.
