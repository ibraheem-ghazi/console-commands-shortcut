using ConsoleCommandsShortcut.Structs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCommandsShortcut.Helpers
{
    internal class CommandsHelper
    {
        internal static void ActivateCommand(ConsoleCommand cmd)
        {
            if (cmd.Shortcut==null || String.IsNullOrWhiteSpace(cmd.Shortcut))
            {
                return;
            }
            DeactivateCommand(cmd);
            File.WriteAllLines(GeneralHelper.IncludePath + cmd.Shortcut + ".bat", new String[] { "@echo off",cmd.Command.Replace("{p}","%*"),"@echo on" });
            File.WriteAllLines(GeneralHelper.IncludePath + cmd.Shortcut, new String[] { "#!/usr/bin/env sh", cmd.Command.Replace("{p}", "\"$@\"") });
        }

        internal static void DeactivateCommand(ConsoleCommand cmd)
        {
            if (cmd.Shortcut == null || String.IsNullOrWhiteSpace(cmd.Shortcut))
            {
                return;
            }

            if (File.Exists(GeneralHelper.IncludePath + cmd.Shortcut))
            {
                File.Delete(GeneralHelper.IncludePath + cmd.Shortcut);
            }
            if (File.Exists(GeneralHelper.IncludePath + cmd.Shortcut +".bat"))
            {
                File.Delete(GeneralHelper.IncludePath + cmd.Shortcut + ".bat");
            }
        }
    }
}
