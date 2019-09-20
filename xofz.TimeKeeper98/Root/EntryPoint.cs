namespace xofz.TimeKeeper98.Root
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    internal static class EntryPoint
    {
        [STAThread]
        private static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += currentDomain_AssemblyResolve;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var bootstrapper = new Bootstrapper();
            bootstrapper.Bootstrap();

            Application.Run(bootstrapper.Shell as Form);
        }

        private static Assembly currentDomain_AssemblyResolve(
            object sender, 
            ResolveEventArgs e)
        {
            var name = e?.Name;
            if (name == null)
            {
                return null;
            }

            var assemblyName = new AssemblyName(name);
            if (name.EndsWith(@"Retargetable=Yes"))
            {
                return Assembly.Load(assemblyName);
            }

            var container = Assembly.GetExecutingAssembly();
            var path = assemblyName.Name + @".dll";

            using (var stream = container.GetManifestResourceStream(path))
            {
                if (stream == null)
                {
                    return null;
                }

                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                return Assembly.Load(bytes);
            }
        }
    }
}
