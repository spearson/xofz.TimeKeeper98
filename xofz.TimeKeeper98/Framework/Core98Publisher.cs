namespace xofz.TimeKeeper98.Framework
{
    using System;
    using System.IO;
    using System.Reflection;
    using xofz.Framework;

    public class Core98Publisher
    {
        public Core98Publisher(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual bool Publish()
        {
            var container = Assembly.GetExecutingAssembly();
            var resourceName = nameof(xofz) + '.' + @"Core98" + '.' + @"dll";
            extractResource:
            using (var s = container.GetManifestResourceStream(resourceName))
            {
                if (s == null)
                {
                    return false;
                }

                var buffer = new byte[0xFFFFFF];
                using (var reader = new BinaryReader(s))
                {
                    var bytesRead = reader.Read(buffer, 0, buffer.Length);
                    var data = new byte[bytesRead];
                    Array.Copy(buffer, data, data.Length);
                    try
                    {
                        File.WriteAllBytes(resourceName, data);
                        if (resourceName.Contains(@".pdb"))
                        {
                            // done
                            return true;
                        }

                        resourceName =
                            nameof(xofz) + '.' + @"Core98" + '.' + @"pdb";
                        goto extractResource;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        protected readonly MethodRunner runner;
    }
}
