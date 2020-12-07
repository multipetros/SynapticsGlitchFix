using System;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace SynapticsGlitchFix{	
	class Program{
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
	
		public static void Main(string[] args){
			RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Synaptics\SynTPEnh", true) ;
			Console.WriteLine("Synaptics Scroll Glitch Fix // by Petros Kyladitis\n") ;
			if(key != null){
				key.SetValue("UseScrollCursor", 0, RegistryValueKind.DWord) ;
				Console.Write("Fix applied!\n------------\nYou must log-off windows to reload the driver.\nDo you want to do it now? [y/n]: ") ;
				if(Console.ReadLine().ToLower().StartsWith("y")){
					ExitWindowsEx(0, 0) ;
				}				
			}else{
				Console.Write("Synaptics Software not found installed.\nIt's not possible to apply the fix.\nPress any key to continue . . . ");
				Console.ReadKey(true);
			}
		}
	}
}