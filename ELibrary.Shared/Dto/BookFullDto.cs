﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto
{
	public class BookFullDto : BookShortDto
	{
		public List<LibraryNestedDto> AvailableInLibraries { get; set; }
	}
}
