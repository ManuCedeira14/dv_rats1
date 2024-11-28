using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetSplit
{
                           //<Idioma, ID, Valor>
    public static Dictionary<Language, Dictionary<string, string>> LoadCSV(string sheet, string source)
    {
        var codex = new Dictionary<Language, Dictionary<string, string>>();

        var langColumn = new Dictionary<int, Language>();

        var idColumn = 0;

        var rows = sheet.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

        bool firstLine = true;

        foreach (var row in rows)
        {
            var cells = row.Split(',');

            if (firstLine)
            {
                firstLine = false;

                for (int i = 0; i < cells.Length; i++)
                {
                    if (!cells[i].Contains("ID"))
                    {
                        try
                        {
                            langColumn[i] = (Language)Enum.Parse(typeof(Language), cells[i]);
                        }
                        catch (Exception e)
                        {
                            Debug.LogError($"SOURCE: {source}");
                            Debug.LogError($"{e.ToString()}");
                            continue;
                        }

                        var language = langColumn[i];

                        if (!codex.ContainsKey(language))
                        {
                            codex[language] = new Dictionary<string, string>();
                        }
                    }
                    else
                    {
                        idColumn = i;
                    }
                }

                continue;
            }

            //Row 1  [ID] [SPANISH] [ENGLISH]

            // [ID_Play] [Jugar] [Play]

            for (int i = 0;i < cells.Length;i++) 
            {
                if (i == idColumn) continue;

                if (!langColumn.ContainsKey(i)) continue;

                //[SPANISH] [ENGLISH]
                var lang = langColumn[i];
                //[ID_Play]
                var id = cells[idColumn];
                //[Jugar] [Play]
                var textValue = cells[i];

                codex[lang][id] = textValue;
            }
        }

        return codex;
    }
}
