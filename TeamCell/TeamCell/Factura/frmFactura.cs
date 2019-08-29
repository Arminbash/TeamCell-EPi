using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller.Controllers;
using Model.Models;
using TeamCell.Notificacion;

namespace TeamCell
{
    public partial class frmFactura : Form
    {
        List<DetallesGrd> listProd = new List<DetallesGrd>();
        BilingController pursCont = new BilingController();
        DetailBilingController detPurCont = new DetailBilingController();
        KardexController kardCont = new KardexController();
        CostingAverageController costAveCont = new CostingAverageController();
        CostingWeightedController cosWeiCont = new CostingWeightedController();
        ClientController clieCont = new ClientController();
        WarehouseController warCont = new WarehouseController();


        public frmFactura()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            listProd.Clear();
            grdcDetalles.DataSource = null;
            txtNoFactura.Text = "";
            fillClientAndWareHouse();
        }
        private void fillClientAndWareHouse()
        {
            cbBodega.DataSource = warCont.getWarehouse();
            cbBodega.DisplayMember = "Name";
            cbBodega.ValueMember = "IdWarehouse";

            dtFechaFactura.DateTime = DateTime.Now;

            cbCliente.DataSource = clieCont.GetClient();
            cbCliente.DisplayMember = "Name";
            cbCliente.ValueMember = "Id";

        }
        private class DetallesGrd
        {
            public int IdDetalle { get; set; }
            public int IdProducto { get; set; }
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public decimal Cantidad { get; set; }
            public decimal Costo { get; set; }
            public decimal Desc { get; set; }
            public decimal Subtotal { get; set; }
            public decimal IVA { get; set; }
            public decimal Total { get; set; }

        }
        private void frmFactura_Load(object sender, EventArgs e)
        {
            fillClientAndWareHouse();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int idProducto = 0;
            frmGrdProductos frm = new frmGrdProductos();
            frm.ShowDialog();
            idProducto = frm.idProducto;
            frm.Dispose();
            if (idProducto != 0)
            {
                Product prod = new Product();
                ProductController prodCont = new ProductController();
                prod = prodCont.getIdProduct(idProducto);
                DetallesGrd det = new DetallesGrd();
                det.IdProducto = prod.IdProducto;
                det.Codigo = prod.Codigo;
                det.Nombre = prod.Name;
                det.Cantidad = 0;
                det.Costo = 0;
                det.Desc = 0;
                det.Subtotal = 0;
                det.IVA = 0;
                det.Total = 0;
                listProd.Add(det);
            }
            grdcDetalles.DataSource = null;
            grdcDetalles.DataSource = listProd;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdDetalles.GetFocusedRowCellValue(colIdProducto) != null)
            {
                int idProducto = 0;
                idProducto = (int)grdDetalles.GetFocusedRowCellValue(colIdProducto);
                listProd.Remove(listProd.Find(x => x.IdProducto == idProducto));
                grdcDetalles.DataSource = null;
                grdcDetalles.DataSource = listProd;
            }
        }

        private void grdDetalles_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int idProducto = 0;
            idProducto = (int)grdDetalles.GetRowCellValue(e.RowHandle, colIdProducto);
            CalcularGrid(idProducto);
        }

        private void CalcularGrid(int idProducto)
        {
            decimal Cantidad = listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().Cantidad;
            decimal Costo = listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().Costo;
            decimal Descuento = listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().Desc;
            decimal IVA = listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().IVA;
            decimal subtotal = (Cantidad * Costo) * (1 - (Descuento / 100));
            decimal Total = subtotal * (1 + (IVA / 100));
            listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().Subtotal = subtotal;
            listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().Total = Total;
            grdcDetalles.DataSource = null;
            grdcDetalles.DataSource = listProd;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Billing pur = new Billing();
                pur.IdEmployee = frmMain.idEmpleado;
                pur.IdClient = (int)cbCliente.SelectedValue;
                pur.NoFactura = txtNoFactura.Text;
                pur.DateBilling = DateTime.Now;

                if (pursCont.AddOrUpdateBilling(pur))
                {
                    foreach (DetallesGrd x in listProd)
                    {
                        DetailBilling det = new DetailBilling();
                        det.IdProduct = x.IdProducto;
                        det.Quantity = x.Cantidad;
                        det.Cost = x.Costo;
                        det.IVA = x.IVA;
                        det.Desc = x.Desc;
                        det.IdBilling = pur.IdBilling;
                        detPurCont.AddOrUpdateDetailBilling(det);

                        Kardex kard = new Kardex();
                        kard.IdDocument = pur.IdBilling;
                        kard.Document = "Factura";
                        kard.IdProducto = x.IdProducto;
                        kard.EntryAmount = 0;
                        kard.OutputAmount = x.Cantidad;
                        kard.Stock = kardCont.GetStockActual(x.IdProducto) - x.Cantidad;
                        kard.IdWarehouse =(int) cbBodega.SelectedValue;
                        kardCont.AddOrUpdateClient(kard);

                        CostingAverage costAver = new CostingAverage();
                        costAver.IdKardex = kard.IdKardex;
                        costAver.Cost = costAveCont.getCalcularPromedioSimple(x.IdProducto);
                        costAveCont.AddOrUpdateCostingAverage(costAver);

                        CostingWeighted costWeig = new CostingWeighted();
                        costWeig.IdKardex = kard.IdKardex;
                        costWeig.Cost = 0;
                        cosWeiCont.AddOrUpdateCostingWeighted(costWeig);
                    }
                }

                FrmSuccess.ConfirmacionFrom("Guardado Correctamente.");
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ocurrio un error al guardar.");
                Limpiar();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
