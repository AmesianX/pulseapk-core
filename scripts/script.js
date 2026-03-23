console.log("[PulseAPK] Safe sample script loaded");

setTimeout(function () {
    Java.perform(function () {
        console.log("[PulseAPK] Java runtime ready; installing MainActivity.onResume hook");

        try {
            var MainActivity = Java.use("com.example.app.MainActivity");
            var origOnResume = MainActivity.onResume.overload();

            origOnResume.implementation = function () {
                console.log("[PulseAPK] MainActivity.onResume intercepted");
                return origOnResume.call(this);
            };

            console.log("[PulseAPK] Hook installed successfully");
        } catch (error) {
            console.error("[PulseAPK] Failed to install hook: " + error);
        }
    });
}, 500);
