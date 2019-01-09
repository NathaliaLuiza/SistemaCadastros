using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaNegocio;	


namespace SistemaCadastros
{
    //INCIO VALIDAÇÕES
    public partial class frmContatos : Form
    {
        private bool eNovo = false;
        private bool eEditar = false;
                

        public frmContatos()
        {
            InitializeComponent();            
        }

        private void MensagemOK(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema NorthWind",MessageBoxButtons.OK);
        }

        private void MensagemErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema NorthWind", MessageBoxButtons.AbortRetryIgnore);
        }

        private void Limpar()
        {
            this.txtNome.Text = string.Empty;
            this.txtCodigo.Text = string.Empty;
            this.txtTipo.Text = string.Empty;
            this.txtCompania.Text = string.Empty;

        }


        private void Habilitar(bool valor)
        {
            this.txtNome.ReadOnly = !valor;
            this.txtCodigo.ReadOnly = !valor;
            this.txtTipo.ReadOnly = !valor;
            this.txtCompania.ReadOnly = !valor;
        }

        private void Botoes()
        {
            if(this.eNovo || this.eEditar)
            {
                this.Habilitar(true);
                this.btnNovo.Enabled = false;
                this.btnSalvar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;                
            }
            else
            {
                this.Habilitar(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        private void OcultarColunas()
        {
            this.dataGridView1.Columns[0].Visible = false;            
        }

        private void Mostrar()
        {
            this.dataGridView1.DataSource = NContatos.Mostrar();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataGridView1.Rows.Count);
        
        }

        private void BuscarNome()
        {
            this.dataGridView1.DataSource = NContatos.BuscarNome(this.txtNomeLista.Text);
           // this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataGridView1.Rows.Count);

        }

        private void EditarRegistro()
        {
            this.dataGridView1.DataSource = NContatos.Editar(this.txtNome.Text, this.txtTipo.Text, this.txtCompania.Text);
        }


        private void ExcluirNome()
        {
            this.dataGridView1.DataSource = NContatos.Excluir(dataGridView1.CurrentRow.Index);
        }
        
        //FINAL VALIDAÇÕES

        private void frmContatos_Load(object sender, EventArgs e)
        {
            
            // TODO: esta linha de código carrega dados na tabela 'northwindDataSet.Contacts'. Você pode movê-la ou removê-la conforme necessário.
            this.contactsTableAdapter.Fill(this.northwindDataSet.Contacts);
            // TODO: esta linha de código carrega dados na tabela 'nORTHWNDDataSet.Customers'. Você pode movê-la ou removê-la conforme necessário.
            this.customersTableAdapter.Fill(this.nORTHWNDDataSet.Customers);

            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botoes();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nORTHWNDDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void txtNomeLista_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.eNovo = true;
            this.eEditar = false;
            this.Botoes();
            this.Limpar();
            this.Habilitar(true);
            this.txtNome.Focus();
            txtCodigo.Enabled = false;

        }

        private void btnEditar_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCodigo.Text.Equals(""))
                {
                    this.MensagemErro("Selecione um registro para inserir");
                }

                else
                {
                    this.eEditar = true;
                    this.eNovo = false;
                    this.Botoes();
                    this.Habilitar(true);
                    this.txtNome.Focus();
                    txtCodigo.Enabled = false;                    
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        }
        

        private void btnSalvar_Click(object sender, EventArgs e)
        {
           try
           {
                string resp = "";
                if (this.txtNome.Text == string.Empty)
                {
                    MensagemErro("Preencha todos os campos");

                }
                else
                {
                    if (this.eNovo)
                    {
                        resp = NContatos.Inserir(this.txtNome.Text.Trim().ToUpper(), this.txtTipo.Text.Trim(), this.txtCompania.Text.Trim());
                    }
                    else
                    {
                        resp = NContatos.Editar(this.txtNome.Text.Trim(), this.txtTipo.Text.Trim(), this.txtCompania.Text.Trim());
                                                
                        this.txtNome.Text.Trim().ToUpper();
                        this.txtTipo.Text.Trim();
                        this.txtCompania.Text.Trim();
                    }

                    if (resp.Equals("OK"))
                    {
                        if (this.eNovo || this.eEditar)
                        { 
                        this.MensagemOK("Registro salvo com sucesso");
                        }
                        else
                        {
                            this.MensagemErro("Erro");

                        }
                    }
                    else
                    {
                        this.MensagemErro(resp);
                    }

                    if(this.eEditar == true)
                    {
                        this.MensagemOK("Registro salvo com sucesso");
                    }

                    this.eNovo = false;
                    this.eEditar = false;
                    this.Botoes();
                    this.Limpar();
                    this.Mostrar();

                }
                
                
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtCodigo.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells[0].Value);
            this.txtNome.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value);
            this.txtTipo.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells[2].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.txtCodigo.Text.Equals(""));
            {
                this.MensagemErro("Selecione um registro para inserir");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            this.ExcluirNome();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

   

    }
}
