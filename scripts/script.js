console.log("[PulseAPK] Custom Frida script loaded (pre-Java)");

Java.perform(function () {
    var TAG = "PulseAPK-FridaScript";

    function logInfo(message) {
        try {
            var Log = Java.use("android.util.Log");
            Log.i(TAG, message);
        } catch (e) {
            console.log("[PulseAPK] " + message);
        }
    }

    function logError(message, error) {
        try {
            var Log = Java.use("android.util.Log");
            Log.e(TAG, message + " :: " + error);
        } catch (e) {
            console.error("[PulseAPK] " + message + " :: " + error);
        }
    }

    try {
        logInfo("Custom Frida script is active (Java runtime ready).");

        var hasShownToast = false;
        var Activity = Java.use("android.app.Activity");
        var Toast = Java.use("android.widget.Toast");
        var StringClass = Java.use("java.lang.String");
        var onResume = Activity.onResume.overload();

        onResume.implementation = function () {
            onResume.call(this);
            logInfo("Activity.onResume intercepted: " + this.getClass().getName());

            if (!hasShownToast) {
                hasShownToast = true;
                var activity = this;
                Java.scheduleOnMainThread(function () {
                    Toast.makeText(
                        activity,
                        StringClass.$new("Frida script active"),
                        Toast.LENGTH_LONG.value
                    ).show();
                });
                logInfo("Displayed one-time confirmation toast from Frida script.");
            }
        };

        logInfo("Hooked android.app.Activity.onResume successfully.");
    } catch (error) {
        logError("Failed to initialize Frida custom script", error);
    }
});
