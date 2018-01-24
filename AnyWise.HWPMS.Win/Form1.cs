using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.BLL;
using AnyWise.HWPMS.Facade;
using AnyWise.Framework.ControlUtil.Facade;

namespace AnyWise.HWPMS.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public void LoadTree()
        {
            try
            {
                this.treeLxmlb.Nodes.Clear();//清空所有节点，以便重新加载
                List<XmlbInfo> xmlbList = CallerFactory<IXmlbService>.Instance.Find("");
                this.treeLxmlb.DataSource = xmlbList;
                //TreeListNode node = tl_TableMaintain.AppendNode(null, -1);
                //node.SetValue(treeListColumn1, "表结构维护");
                //LoadTreeCtrl(node, "-1");
                //TreeListProperty(tl_TableMaintain);//调用方法，设置属性
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTree();
        }
        //private void LoadTreeCtrl(TreeListNode pnode, string parentkey)
        //{
        //    try
        //    {
        //        int index = 0;
        //        List<erp_dev_table> dv = _snList.Where(o => o.parent_key.Trim() == parentkey.Trim()).ToList();//根据父级id获取子节点循环加载
        //        foreach (erp_dev_table rv in dv)
        //        {
        //            TreeListNode node = pnode.TreeList.AppendNode(rv.table_key, pnode);
        //            node.SetValue(0, rv.table_name_english);
        //            node.Tag = rv;
        //            LoadTreeCtrl(node, Command.Instance.Getstring(rv.table_key));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
        
        ///// <summary>
        ///// 设置treeList的属性
        ///// </summary>
        ///// <param name="tl"></param>
        //private void TreeListProperty(TreeList tl)
        //{
        //    tl.OptionsView.ShowColumns = false;//是否显示选中的行
        //    tl.OptionsBehavior.Editable = false;//不可编辑
        //    tl.OptionsView.ShowHorzLines = false;//OptionsView提供对树状列表的显示选项,设置水平线是否显示
        //    tl.OptionsView.ShowIndicator = false;//节点的指示面板是否显示
        //    tl.OptionsView.ShowVertLines = false;//垂直线条是否显示
        //    //设置treeList的折叠样式为 +  - 号
        //    tl.LookAndFeel.UseDefaultLookAndFeel = false;
        //    tl.LookAndFeel.UseWindowsXPTheme = true;
        //    tl.OptionsSelection.InvertSelection = true;//聚焦的样式是否只适用于聚焦细胞或所有细胞除了聚焦对象，失去焦点后
        //}
    }
}
