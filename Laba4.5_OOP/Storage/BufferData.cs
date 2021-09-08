using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Storage
{
    static public class BufferData
    {
      public static  Guid id_reader { get; set; }
      public static  Guid id_book { get; set; }
      public static  Guid libraryId { get; set; }
      public static  Guid id_author { get; set; }
      public static  Guid id_category { get; set; }
      public static string NameBook { get; set; }
      public static string NameView { get; set; }
      public static string ViewBookUpdateOrAdd { get; set; }
    }
}
