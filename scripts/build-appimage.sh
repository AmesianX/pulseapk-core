#!/usr/bin/env bash
set -euo pipefail

repo_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
project_path="${repo_root}/src/PulseAPK.Avalonia/PulseAPK.Avalonia.csproj"

app_name="PulseAPK"
entry_exe="PulseAPK.Avalonia"
config="${CONFIGURATION:-Release}"
rid="${RID:-linux-x64}"

out_root="${repo_root}/artifacts/linux/${rid}"
publish_dir="${out_root}/publish"
appdir="${out_root}/AppDir"
appimage_path="${out_root}/${app_name}-${rid}.AppImage"

if ! command -v dotnet >/dev/null 2>&1; then
  echo "dotnet is required but was not found in PATH." >&2
  exit 1
fi

if ! command -v appimagetool >/dev/null 2>&1; then
  echo "appimagetool is required to build an AppImage (https://appimage.github.io/)." >&2
  exit 1
fi

rm -rf "${publish_dir}" "${appdir}"
mkdir -p "${publish_dir}" "${appdir}/usr/bin" "${appdir}/usr/share/icons/hicolor/256x256/apps"

dotnet publish "${project_path}" \
  -c "${config}" \
  -r "${rid}" \
  --self-contained true \
  -o "${publish_dir}"

cp -a "${publish_dir}/." "${appdir}/usr/bin/"

if [[ ! -x "${appdir}/usr/bin/${entry_exe}" ]]; then
  echo "Expected executable '${entry_exe}' was not found in ${publish_dir}." >&2
  exit 1
fi

cat > "${appdir}/AppRun" <<'EOF'
#!/usr/bin/env bash
set -e
here="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
exec "${here}/usr/bin/PulseAPK.Avalonia" "$@"
EOF
chmod +x "${appdir}/AppRun"

cat > "${appdir}/${app_name}.desktop" <<EOF
[Desktop Entry]
Type=Application
Name=${app_name}
Exec=${entry_exe}
Icon=${app_name}
Categories=Development;Utility;
Terminal=false
EOF

icon_src="${repo_root}/Resources/CyberUnpack.png"
if [[ -f "${icon_src}" ]]; then
  cp "${icon_src}" "${appdir}/${app_name}.png"
  cp "${icon_src}" "${appdir}/usr/share/icons/hicolor/256x256/apps/${app_name}.png"
fi

arch="${rid##*-}"
case "${arch}" in
  x64) appimage_arch="x86_64" ;;
  arm64) appimage_arch="aarch64" ;;
  *) appimage_arch="${arch}" ;;
esac

ARCH="${appimage_arch}" appimagetool "${appdir}" "${appimage_path}"

echo "AppImage created: ${appimage_path}"
