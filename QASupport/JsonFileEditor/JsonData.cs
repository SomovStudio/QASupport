using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QASupport.JsonFileEditor
{
    class JsonData
    {
        public const int TOKEN_END = 0;
        public const int TOKEN_STRING_START = 1;
        public const int TOKEN_VALUE_START = 2;

        public const int TYPE_OTHER = 0;
        public const int TYPE_OBJECT = 1;
        public const int TYPE_ARRAY = 2;
        public const int TYPE_STRING = 3;

        public static TreeNode SetDataInTreeView(string jsonText, string filename)
        {
            /*	Определяем коды спец. символов 
			 * 	- новая строка 	- 851981 и 655370
			 *	- пробел		- 2097184
			 *	- табуляция		- 589833
			 */
            int charSpace = ' '.GetHashCode();
            int charTab = '	'.GetHashCode();
            char[] arrayCharsNewLine = Environment.NewLine.ToCharArray();
            int charNewLine1 = 0;
            int charNewLine2 = 0;
            if (arrayCharsNewLine.Length > 0) charNewLine1 = arrayCharsNewLine[0].GetHashCode();
            if (arrayCharsNewLine.Length > 1) charNewLine2 = arrayCharsNewLine[1].GetHashCode();


            /*
			 * Заполняем дерево данными из файла
			 */
            TreeNode tree = new TreeNode(filename);
            TreeNode node;

            char c;
            int level = 0;
            string key = null;
            string value = null;
            string token = null;
            int tokenStatus = TOKEN_END;
            int tokenType = TYPE_OTHER;
            int lastTokenStatus = TOKEN_END;
            bool thisIsArray = false;

            int count = jsonText.Length;
            for (int i = 0; i < count; i++)
            {
                c = jsonText[i];

                // УЗЛЫ
                if (c == '{' && tokenType != TYPE_STRING)
                {
                    if (key == null) node = new TreeNode("{ }");
                    else node = new TreeNode(key + ": { }");
                    node.Text = node.Text.Trim();
                    JsonData.GetNodeAtLevel(tree, level).Nodes.Add(node);   // СОХРАНЕНИЕ ТОКЕНА В ДЕРЕВЕ
                    key = null;
                    value = null;
                    token = null;
                    tokenStatus = TOKEN_END;
                    level++;
                }
                else if (c == '}' && tokenType != TYPE_STRING)
                {
                    if (token != null)
                    {
                        value = token;
                        if (tokenType == TYPE_OTHER && thisIsArray == true && value[0] != '"') value = '"' + value;
                        if (key == null)
                        {
                            if (value[0] != '"' && Char.IsDigit(value[0]) == false) value = '"' + value;
                            node = new TreeNode(value);
                        }
                        else node = new TreeNode(key + ": " + value);
                        node.Text = node.Text.Trim();
                        JsonData.GetNodeAtLevel(tree, level).Nodes.Add(node);   // СОХРАНЕНИЕ ТОКЕНА В ДЕРЕВЕ
                    }
                    key = null;
                    value = null;
                    token = null;
                    tokenStatus = TOKEN_END;
                    level--;
                    continue;
                }
                else if (c == '}' && tokenType == TYPE_STRING)
                {
                    //MessageBox.Show("["+ tokenType + "]["+ tokenStatus + "]["+ thisIsArray + "]:" + key + "|" + token);
                }
                else if (c == '[' && tokenType != TYPE_STRING)
                {
                    thisIsArray = true;
                    if (key == null) node = new TreeNode("[ ]");
                    else node = new TreeNode(key + ": [ ]");
                    node.Text = node.Text.Trim();
                    JsonData.GetNodeAtLevel(tree, level).Nodes.Add(node);   // СОХРАНЕНИЕ ТОКЕНА В ДЕРЕВЕ
                    key = null;
                    value = null;
                    token = null;
                    tokenStatus = TOKEN_END;
                    level++;
                }
                else if (c == ']' && tokenType != TYPE_STRING)
                {
                    thisIsArray = false;
                    if (token != null)
                    {
                        value = token;
                        if (tokenType == TYPE_OTHER && thisIsArray == true && value[0] != '"') value = '"' + value;
                        if (key != null && lastTokenStatus != TOKEN_VALUE_START) node = new TreeNode(key + ": " + value);
                        else
                        {
                            if (value[0] != '"' && Char.IsDigit(value[0]) == false) value = '"' + value;
                            node = new TreeNode(value);
                        }
                        node.Text = node.Text.Trim();
                        JsonData.GetNodeAtLevel(tree, level).Nodes.Add(node);   // СОХРАНЕНИЕ ТОКЕНА В ДЕРЕВЕ	
                    }
                    key = null;
                    value = null;
                    token = null;
                    tokenStatus = TOKEN_END;
                    lastTokenStatus = TOKEN_END;
                    level--;
                    continue;
                }

                // ТОКЕН
                // Формируется значение тип которого строка
                if (tokenStatus == TOKEN_STRING_START &&
                        c.GetHashCode() != charNewLine1 &&
                        c.GetHashCode() != charNewLine2) token += c;
                // Формируем значение тип которого любое значение
                else if (tokenStatus == TOKEN_VALUE_START &&
                        //c.GetHashCode() != charSpace && 
                        c.GetHashCode() != charTab &&
                        c.GetHashCode() != charNewLine1 &&
                        c.GetHashCode() != charNewLine2) token += c;

                // ФЛАГИ
                if (c == '"' && tokenStatus == TOKEN_END && thisIsArray == false) // Начало токена строка
                {
                    tokenStatus = TOKEN_STRING_START;
                    tokenType = TYPE_STRING;
                    token = c.ToString();
                }
                else if (c == '"' && tokenStatus == TOKEN_VALUE_START && thisIsArray == false)
                {
                    if (tokenType != TYPE_STRING) tokenType = TYPE_STRING;
                    else tokenType = TYPE_OTHER;
                }
                else if (c == '"' && tokenStatus == TOKEN_STRING_START && thisIsArray == false) // Завершение токена строка
                {
                    string cLast = token.Substring(token.Length - 2);
                    if (cLast != "\\\"")
                    {
                        tokenType = TYPE_OTHER;
                        tokenStatus = TOKEN_END;
                    }
                }
                else if (c == '"' && thisIsArray == true)
                {
                    if (token != null)
                    {
                        string cLast = token.Substring(token.Length - 2);
                        if (cLast != "\\\"" && tokenType == TYPE_STRING) tokenType = TYPE_OTHER;
                        else tokenType = TYPE_STRING;
                    }
                    else
                    {
                        tokenType = TYPE_STRING;
                    }
                }
                else if (c == ':' && tokenStatus == TOKEN_END)
                {
                    tokenStatus = TOKEN_VALUE_START;
                    token = null;
                }
                else if (c == ',' && tokenStatus != TOKEN_STRING_START && tokenStatus == TOKEN_VALUE_START)
                {
                    tokenStatus = TOKEN_END;
                    tokenType = TYPE_OTHER;
                }
                else if (tokenStatus == TOKEN_END &&
                        c.GetHashCode() != charSpace &&
                        c.GetHashCode() != charTab &&
                        c.GetHashCode() != charNewLine1 &&
                        c.GetHashCode() != charNewLine2 &&
                        c != '{' && c != '}' &&
                        c != '[' && c != ']' &&
                        c != ':' && c != ',')
                {
                    tokenStatus = TOKEN_VALUE_START;
                    lastTokenStatus = TOKEN_VALUE_START;    // lastTokenStatus - для массива
                    token = c.ToString();
                }

                // СОХРАНЕНИЕ ТОКЕНА В ДЕРЕВЕ
                if (token != null && tokenStatus == TOKEN_END)
                {
                    if (key == null && lastTokenStatus != TOKEN_VALUE_START)
                    {
                        key = token;
                        token = null;
                    }
                    else if (value == null)
                    {
                        value = token;
                        token = null;

                        if (tokenType == TYPE_OTHER && thisIsArray == true && value[0] != '"' && Char.IsDigit(value[0]) == false) value = '"' + value;
                        
                        if (key == null) node = new TreeNode(value);
                        else node = new TreeNode(key + ": " + value);
                        node.Text = node.Text.Trim();
                        JsonData.GetNodeAtLevel(tree, level).Nodes.Add(node);

                        key = null;
                        value = null;
                        token = null;

                        tokenStatus = TOKEN_END;
                        lastTokenStatus = TOKEN_END;
                    }
                }
            }

            return tree;
        }

        public static TreeNode GetNodeAtLevel(TreeNode tree, int level)
        {
            if (tree.Nodes.Count <= 0) return tree;
            if (level == 0) return tree;

            TreeNode node = null;
            for (int i = 0; i < (level + 1); i++)
            {
                if (node == null) node = tree;
                else if (node.Nodes.Count > 0) node = node.Nodes[node.Nodes.Count - 1];
                else return node;
            }
            return node;
        }

        public static int indexTextLine = 0;
        public static string GetTextFromTreeView(TreeNode node, int nodeLevel)
        {
            string jsonText = "";
            int typeNode = TYPE_OTHER;
            char lastChar = node.Text[node.Text.Length - 1];
            if (lastChar == '}') // Определяем узел объекта { }
            {
                jsonText += AddTab(nodeLevel);
                jsonText += node.Text.Remove(node.Text.Length - 1, 1) + Environment.NewLine;
                typeNode = TYPE_OBJECT;
                node.Tag = indexTextLine;
            }
            else if (lastChar == ']') // Определяем узел массива [ ]
            {
                jsonText += AddTab(nodeLevel);
                jsonText += node.Text.Remove(node.Text.Length - 1, 1) + Environment.NewLine;
                typeNode = TYPE_ARRAY;
                node.Tag = indexTextLine;
            }
            else
            {
                jsonText += AddTab(nodeLevel);
                jsonText += node.Text + Environment.NewLine;
                typeNode = TYPE_OTHER;
                node.Tag = indexTextLine;
            }

            int count = node.Nodes.Count;
            TreeNode changeNode;
            for (int i = 0; i < count; i++)
            {
                changeNode = node.Nodes[i];
                indexTextLine++;
                changeNode.Tag = indexTextLine;

                if (changeNode.Nodes.Count > 0)
                {
                    jsonText += GetTextFromTreeView(changeNode, nodeLevel + 1);
                    if (i < (count - 1)) jsonText += "," + Environment.NewLine;
                    else jsonText += Environment.NewLine;
                }
                else
                {
                    jsonText += AddTab(nodeLevel);
                    jsonText += changeNode.Text + Environment.NewLine;
                }
            }

            jsonText += AddTab(nodeLevel);
            if (typeNode == TYPE_OBJECT)
            {
                jsonText += "}";
                indexTextLine++;
            }
            else if (typeNode == TYPE_ARRAY)
            {
                jsonText += "]";
                indexTextLine++;
            }

            return jsonText;
        }

        public static string AddTab(int level)
        {
            string tab = "";
            if (level <= 0) return tab;
            for (int i = 0; i < level; i++) tab += "    ";
            return tab;
        }

        public static List<string> ValidateJson(string key, string value)
        {
            List<string> error = new List<string>();

            if (key != null && key != "" && (value == null || value == "")) error.Add("Ключу " + key + " не присвоено значение");

            if (key != null && key != "")
            {
                if (key[0] != '"' && key[key.Length - 1] != '"') error.Add("Ключь " + key + " должен быть прописан в двойных кавычках");
                else if (key[0] != '"') error.Add("Вы забыли поставить двойные кавычки перед ключем " + key);
                else if (key[key.Length - 1] != '"') error.Add("Вы забыли поставить двойные кавычки после ключа " + key);
            }
            if (value != null && value != "")
            {

            }
            else
            {

            }

            return error;
        }
    }
}
