﻿// <file>
//     <copyright see="prj:///Doc/copyright.txt"/>
//     <license see="prj:///Doc/license.txt"/>
//     <owner name="Christian Hornung" email="c-hornung@gmx.de"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using ICSharpCode.Core;

namespace Hornung.ResourceToolkit.ResourceFileContent
{
	/// <summary>
	/// Finds localized resources that follow the standard .NET pattern
	/// MyResources.(culture).(extension).
	/// </summary>
	public class DefaultFileLocalizedResourcesFinder : ILocalizedResourcesFinder
	{
		/// <summary>
		/// Gets localized resources that belong to the master resource file.
		/// </summary>
		/// <param name="fileName">The name of the master resource file.</param>
		/// <returns>A dictionary of culture names and associated resource file contents, or <c>null</c>, if there are none.</returns>
		public IDictionary<string, IResourceFileContent> GetLocalizedContents(string fileName)
		{
			#if DEBUG
			LoggingService.Debug("ResourceToolkit: DefaultFileLocalizedResourcesFinder.GetLocalizedContents called, fileName: '"+fileName+"'");
			#endif
			
			string fileNameWithoutExtension = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName));
			string culture = Path.GetExtension(fileNameWithoutExtension);
			if (!String.IsNullOrEmpty(culture)) {
				try {
					CultureInfo.GetCultureInfo(culture);
					// the specified file is a localized resource file itself
					LoggingService.Debug("ResourceToolkit: DefaultFileLocalizedResourcesFinder.GetLocalizedContents: Returning null for file '"+fileName+"' because it has been detected as being a localized resource file itself.");
					return null;
				} catch (ArgumentException) {
				}
			}
			
			return FindLocalizedResourceFiles(fileNameWithoutExtension, Path.GetExtension(fileName));
		}
		
		/// <summary>
		/// Finds all localized resource files that follow the pattern
		/// &lt;<paramref name="fileNameWithoutExtension"/>&gt;.&lt;culture&gt;&lt;<paramref name="extension"/>&gt;.
		/// </summary>
		/// <param name="fileNameWithoutExtension">The full path and name of the master resource file without extension.</param>
		/// <param name="extension">The extension of the master resource file (with leading dot).</param>
		/// <returns>A dictionary of culture names and associated resource file contents.</returns>
		public static IDictionary<string, IResourceFileContent> FindLocalizedResourceFiles(string fileNameWithoutExtension, string extension)
		{
			Dictionary<string, IResourceFileContent> list = new Dictionary<string, IResourceFileContent>();
			
			#if DEBUG
			LoggingService.Debug("ResourceToolkit: Finding localized resource files (DefaultFileLocalizedResourcesFinder.FindLocalizedResourceFiles).");
			LoggingService.Debug(" -> fileNameWithoutExtension: '"+fileNameWithoutExtension+"'");
			LoggingService.Debug(" -> extension:                '"+extension+"'");
			#endif
			
			foreach (string fileName in Directory.GetFiles(Path.GetDirectoryName(fileNameWithoutExtension), Path.GetFileName(fileNameWithoutExtension)+".*"+extension)) {
				#if DEBUG
				LoggingService.Debug(" -> possible file: '"+fileName+"'");
				#endif
				
				string culture = Path.GetExtension(Path.GetFileNameWithoutExtension(fileName));
				#if DEBUG
				LoggingService.Debug("    -> culture = '"+(culture ?? "<null>")+"'");
				#endif
				
				if (!String.IsNullOrEmpty(culture)) {
					
					try {
						
						CultureInfo ci = CultureInfo.GetCultureInfo(culture.Substring(1));	// need to remove leading dot from culture
						IResourceFileContent content = ResourceFileContentRegistry.GetResourceFileContent(fileName);
						if (content != null) {
							#if DEBUG
							LoggingService.Debug("    -> culture name: '"+ci.Name+"'");
							#endif
							list.Add(ci.Name, content);
						}
						
					} catch (ArgumentException) {
						continue;
					}
					
				}
				
			}
			
			return list;
		}
		
		// ********************************************************************************************************************************
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DefaultFileLocalizedResourcesFinder"/> class.
		/// </summary>
		public DefaultFileLocalizedResourcesFinder()
		{
		}
	}
}
