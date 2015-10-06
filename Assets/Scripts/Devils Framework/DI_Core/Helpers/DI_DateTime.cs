// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System;

namespace DI.Core.Helpers
{
	public static class DI_DateTime
	{
		public static TimeSpan diffTime(DateTime start, DateTime end)
		{
			return end.Subtract(start);
		}
	}
}