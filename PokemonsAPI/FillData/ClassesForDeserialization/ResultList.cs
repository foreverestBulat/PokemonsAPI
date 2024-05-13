using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillData.ClassesForDeserialization;

public class ResultList
{
    public int Count { get; set; }
    public List<Item> Results { get; set; }
}
