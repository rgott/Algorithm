using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Numerics
{
    public partial class NumberUtils
    {
        static readonly Map<string, int> Lower = new Map<string, int>() {
             { "Zero", 0 }
            ,{ "One", 1 }
            ,{ "Two", 2 }
            ,{ "Three", 3 }
            ,{ "Four", 4 }
            ,{ "Five", 5 }
            ,{ "Six", 6 }
            ,{ "Seven", 7 }
            ,{ "Eight", 8 }
            ,{ "Nine", 9 }
            ,{ "Ten", 10 }
            ,{ "Eleven", 11 }
            ,{ "Twelve", 12 }
            ,{ "Thirteen", 13 }
            ,{ "Fourteen", 14 }
            ,{ "Fifteen", 15 }
            ,{ "Sixteen", 16 }
            ,{ "Seventeen", 17 }
            ,{ "Eighteen", 18 }
            ,{ "Nineteen", 19 }
            ,{ "Twenty",20 }
            ,{ "Thirty",30 }
            ,{ "Fourty",40 }
            ,{ "Fifty",50 }
            ,{ "Sixty",60 }
            ,{ "Seventy",70 }
            ,{ "Eighty",80 }
            ,{ "Ninety",90 }};

        static readonly Map<string, int> Higher = new Map<string, int>(){
             { "Hundred", 2 }
            ,{ "Thousand",3 }
            ,{ "Million",6 }
            ,{ "Billion",9 }
            ,{ "Trillion",12 }
            ,{ "Quadrillion",15 }
            ,{ "Quintillion",18 }
            ,{ "Sextillion",21 }
            ,{ "Septillion",24 }
            ,{ "Octillion",27 }
            ,{ "Nonillion",30 }
            ,{ "Decillion",33 }
            ,{ "Undecillion",36 }
            ,{ "Duodecillion",39 }
            ,{ "Tredecillion",42 }
            ,{ "Quattuordecillion",45 }
            ,{ "Quindecillion",48 }
            ,{ "Sexdecillion",51 }
            ,{ "Septendecillion",54 }
            ,{ "Octodecillion",57 }
            ,{ "Novemdecillion",60 }
            ,{ "Vigintillion", 63 }
            ,{ "Unvigintillion", 66 }
            ,{ "Duovigintillion", 69 }
            ,{ "Trevigintillion", 72 }
            ,{ "Quattuorvigintillion", 75 }
            ,{ "Quinvigintillion", 78 }
            ,{ "Sexvigintillion", 71 }
            ,{ "Septenvigintillion", 84 }
            ,{ "Octovigintillion", 87 }
            ,{ "Novemvigintillion", 90 }
            ,{ "Trigintillion", 93 }
            ,{ "Untrigintillion", 96 }
            ,{ "Duotrigintillion", 99 }
            ,{ "Tretrigintillion", 102 }
            ,{ "Quattuortrigintillion", 105 }
            ,{ "Quintrigintillion", 108 }
            ,{ "Sextrigintillion", 111 }
            ,{ "Septentrigintillion", 114 }
            ,{ "Octotrigintillion", 117 }
            ,{ "Novemtrigintillion", 120 }
            ,{ "Quadragintillion", 123 }
            ,{ "Unquadragintillion", 126 }
            ,{ "Duoquadragintillion", 129 }
            ,{ "Trequadragintillion", 132 }
            ,{ "Quattuorquadragintillion", 135 }
            ,{ "Quinquadragintillion", 138 }
            ,{ "Sexquadragintillion", 141 }
            ,{ "Septenquadragintillion", 144 }
            ,{ "Octoquadragintillion", 147 }
            ,{ "Novemquadragintillion", 150 }
            ,{ "Quinquagintillion", 153 }
            ,{ "Unquinquagintillion", 156 }
            ,{ "Duoquinquagintillion", 159 }
            ,{ "Trequinquagintillion", 162 }
            ,{ "Quattuorquinquagintillion", 165 }
            ,{ "Quinquinquagintillion", 168 }
            ,{ "Sexquinquagintillion", 171 }
            ,{ "Septenquinquagintillion", 174 }
            ,{ "Octoquinquagintillion", 177 }
            ,{ "Novemquinquagintillion", 180 }
            ,{ "Sexagintillion", 183 }
            ,{ "Unsexagintillion", 186 }
            ,{ "Duosexagintillion", 189 }
            ,{ "Tresexagintillion", 192 }
            ,{ "Quattuorsexagintillion", 195 }
            ,{ "Quinsexagintillion", 198 }
            ,{ "Sexsexagintillion", 201 }
            ,{ "Septensexagintillion", 204 }
            ,{ "Octosexagintillion", 207 }
            ,{ "Novemsexagintillion", 210 }
            ,{ "Septuagintillion", 213 }
            ,{ "Unseptuagintillion", 216 }
            ,{ "Duoseptuagintillion", 219 }
            ,{ "Treseptuagintillion", 222 }
            ,{ "Quattuorseptuagintillion", 225 }
            ,{ "Quinseptuagintillion", 228 }
            ,{ "Sexseptuagintillion", 231 }
            ,{ "Septenseptuagintillion", 234 }
            ,{ "Octoseptuagintillion", 237 }
            ,{ "Novemseptuagintillion", 240 }
            ,{ "Octogintillion", 243 }
            ,{ "Unoctogintillion", 246 }
            ,{ "Duooctogintillion", 249 }
            ,{ "Treoctogintillion", 252 }
            ,{ "Quattuoroctogintillion", 255 }
            ,{ "Quinoctogintillion", 258 }
            ,{ "Sexoctogintillion", 261 }
            ,{ "Septenoctogintillion", 264 }
            ,{ "Octooctogintillion", 267 }
            ,{ "Novemoctogintillion", 270 }
            ,{ "Nonagintillion", 273 }
            ,{ "Unnonagintillion", 276 }
            ,{ "Duononagintillion", 279 }
            ,{ "Trenonagintillion", 282 }
            ,{ "Quattuornonagintillion", 285 }
            ,{ "Quinnonagintillion", 288 }
            ,{ "Sexnonagintillion", 291 }
            ,{ "Septennonagintillion", 294 }
            ,{ "Octononagintillion", 297 }
            ,{ "Novemnonagintillion", 300 }
            ,{ "Centillion", 303 }
        };
    }
}
