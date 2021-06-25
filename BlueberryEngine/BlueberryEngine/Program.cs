using System;

namespace eboatwright {
    public static class Program {
        [STAThread]
        static void Main() {
            using (var main = new Main())
                main.Run();
        }
    }
}
