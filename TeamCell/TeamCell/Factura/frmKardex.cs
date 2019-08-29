using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Controller.Controllers;
namespace TeamCell.Factura
{
    public partial class frmKardex : Form
    {
        int _idBodega = 0;
        List<GrdKardexTotalizado> listTotal = new List<GrdKardexTotalizado>();
        List<GrdKardexXBodega> listBodega = new List<GrdKardexXBodega>();
        WarehouseController warCont = new WarehouseController();

        public frmKardex()
        {
            InitializeComponent();
        }
        private void fillComboBodega()
        {
            cbxBodega.DataSource = warCont.getWarehouse();
            cbxBodega.DisplayMember = "Name";
            cbxBodega.ValueMember = "IdWarehouse";
        }
        public Boolean IsNumeric(object valor)
        {
            int result;
            return int.TryParse(valor.ToString(), out result);
        }
        private class GrdKardexTotalizado
        {
            public int IdKardex {get;set;}
            public string Bodega { get; set; }
            public string Documento { get; set; }
            public string Producto { get; set; }
            public decimal CantidadEntrada { get; set; }
            public decimal CantidadSalida { get; set; }
            public decimal stockActualizado { get; set; }
        }
        private class GrdKardexXBodega
        {
            public int IdKardex { get; set; }
            public string Documento { get; set; }
            public string Producto { get; set; }
            public decimal CantidadEntrada { get; set; }
            public decimal CantidadSalida { get; set; }
            public decimal stockActualizado { get; set; }
        }

        private void kardexTotalizado()
        {
            KardexController kardexCont = new KardexController();
            List<dynamic> _kardexTotal = kardexCont.GetKardexTotalizado();
            GrdKardexTotalizado _tableTotal = new GrdKardexTotalizado();
            if (_kardexTotal != null)
            {
                //foreach (var list in _kardexTotal)
                //{
                //    //var objAccessor = new ObjectAccessor.Create(list); // es una mala práctica pero es solo para ver si funciona
                //    //_tableTotal.IdKardex = objAccessor["IdKardex"];
                //    //_tableTotal.Bodega = objAccessor["wareHouse"];
                //    //_tableTotal.Documento = objAccessor["Document"];
                //    //_tableTotal.Producto = objAccessor["product"];
                //    //_tableTotal.CantidadEntrada = objAccessor["EntryAmount"];
                //    //_tableTotal.CantidadSalida = objAccessor["OutputAmount"];
                //    //_tableTotal.stockActualizado = objAccessor["Stock"];
                //    //listTotal.Add(_tableTotal);
                //    //_tableTotal.IdKardex = list.IdKardex;
                //    //_tableTotal.Bodega = list.wareHouse;
                //    //_tableTotal.Documento = list.Document;
                //    //_tableTotal.Producto = list.product;
                //    //_tableTotal.CantidadEntrada = list.EntryAmount;
                //    //_tableTotal.CantidadSalida = list.OutputAmount;
                //    //_tableTotal.stockActualizado = list.Stock;
                //    //listTotal.Add(_tableTotal);
                //}
            }
            
            grdcTotal.DataSource = null;
            grdcTotal.DataSource = _kardexTotal;
        }

        private void kardexXBodega(int idbodega)
        {
            KardexController kardexCont = new KardexController();
            dynamic _kardexTotal = kardexCont.GetKardexByIdWareHouse(idbodega);
            //GrdKardexXBodega _tableTotal = new GrdKardexXBodega();
            //if (_kardexTotal != null)
            //{
            //    _tableTotal.IdKardex = _kardexTotal.IdKardex;
            //    _tableTotal.Documento = _kardexTotal.Document;
            //    _tableTotal.Producto = _kardexTotal.product;
            //    _tableTotal.CantidadEntrada = _kardexTotal.EntryAmount;
            //    _tableTotal.CantidadSalida = _kardexTotal.OutputAmount;
            //    _tableTotal.stockActualizado = _kardexTotal.Stock;
            //    listBodega.Add(_tableTotal);
            //}
            grdcBodega.DataSource = null;
            grdcBodega.DataSource = _kardexTotal;
        }

        private void frmKardex_Load(object sender, EventArgs e)
        {
            fillComboBodega();
            kardexTotalizado();
        }

        private void cbxBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsNumeric(cbxBodega.SelectedValue))
            {
                _idBodega = (int)cbxBodega.SelectedValue;
                if (_idBodega != 0)
                {
                    kardexXBodega(_idBodega);
                }
            }
        }
    }
}
