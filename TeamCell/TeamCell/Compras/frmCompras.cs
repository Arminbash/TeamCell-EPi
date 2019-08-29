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
    public partial class frmCompras : Form
    {
        List<DetallesGrd> listProd = new List<DetallesGrd>();
        WarehouseController warCont = new WarehouseController();
        ProviderControlles provCont = new ProviderControlles();
        PurchaseController pursCont = new PurchaseController();
        DetailPurchaseController detPurCont = new DetailPurchaseController();
        KardexController kardCont = new KardexController();
        CostingAverageController costAveCont = new CostingAverageController();
        CostingWeightedController cosWeiCont = new CostingWeightedController();

        public frmCompras()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            listProd.Clear();
            grdcDetalles.DataSource = null;
            txtNoFactura.Text = "";
            dtFechaFactura.DateTime = DateTime.Now;

            cbBodega.DataSource = warCont.getWarehouse();
            cbBodega.DisplayMember = "Name";
            cbBodega.ValueMember = "IdWarehouse";

            cbProveedor.DataSource = provCont.getProvider();
            cbProveedor.DisplayMember = "NameProvider";
            cbProveedor.ValueMember = "IdProvider";

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

        private void frmCompras_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(grdDetalles.GetFocusedRowCellValue(colIdProducto) != null)
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
            idProducto =(int) grdDetalles.GetRowCellValue(e.RowHandle, colIdProducto);
            CalcularGrid(idProducto);
        }

        private void CalcularGrid(int idProducto)
        {
          decimal Cantidad=  listProd.Where(x => x.IdProducto == idProducto).FirstOrDefault().Cantidad;
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
                Purchases pur = new Purchases();
                pur.IdEmployee = frmMain.idEmpleado;
                pur.IdProvider = (int)cbProveedor.SelectedValue;
                pur.IdWarehouse = (int)cbBodega.SelectedValue;
                pur.Factura = txtNoFactura.Text;
                pur.EntryDate = DateTime.Now;
                pur.PurchaseDate = dtFechaFactura.DateTime;

                if (pursCont.AddOrUpdatePurchases(pur))
                {
                    foreach (DetallesGrd x in listProd)
                    {
                        DetailPurchase det = new DetailPurchase();
                        det.IdProduct = x.IdProducto;
                        det.Quantity = x.Cantidad;
                        det.Cost = x.Costo;
                        det.IVA = x.IVA;
                        det.Desc = x.Desc;
                        det.IdPurchases = pur.IdPurchases;
                        detPurCont.AddOrUpdateDetailPurchase(det);

                        Kardex kard = new Kardex();
                        kard.IdDocument = pur.IdPurchases;
                        kard.Document = "Compra";
                        kard.IdProducto = x.IdProducto;
                        kard.EntryAmount = x.Cantidad;
                        kard.OutputAmount = 0;
                        kard.Stock = kardCont.GetStockActual(x.IdProducto) + x.Cantidad;
                        kard.IdWarehouse = pur.IdWarehouse;
                        kardCont.AddOrUpdateClient(kard);

                        CostingAverage costAver = new CostingAverage();
                        costAver.IdKardex = kard.IdKardex;
                        costAver.Cost = 0;
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
            catch(Exception ex)
            {
                MessageBox.Show("ocurrio un error al guardar.");
                Limpiar();
            }

        }
    }
}
