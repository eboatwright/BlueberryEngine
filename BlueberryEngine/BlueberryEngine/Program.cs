using System;

namespace eboatwright.Example {
    public static class Program {
        [STAThread]
        static void Main() {
            using (var main = new Main())
                main.Run();
        }
    }
}
