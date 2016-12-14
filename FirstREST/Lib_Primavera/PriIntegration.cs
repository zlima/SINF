using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interop.ErpBS900;
using Interop.StdPlatBS900;
using Interop.StdBE900;
using Interop.GcpBE900;
using ADODB;

namespace FirstREST.Lib_Primavera
{
    public class PriIntegration
    {
        

        # region Cliente

        public static List<Model.Cliente> ListaClientes()
        {
            
            
            StdBELista objList;

            List<Model.Cliente> listClientes = new List<Model.Cliente>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = PriEngine.Engine.Consulta("SELECT Cliente, Nome, Moeda, NumContrib as NumContribuinte, Fac_Mor, Pais, Situacao  FROM  CLIENTES");

                
                while (!objList.NoFim())
                {
                    listClientes.Add(new Model.Cliente
                    {
                        CodCliente = objList.Valor("Cliente"),
                        NomeCliente = objList.Valor("Nome"),
                        Moeda = objList.Valor("Moeda"),
                        NumContribuinte = objList.Valor("NumContribuinte"),
                        Morada = objList.Valor("Fac_Mor"),
                        Pais = objList.Valor("Pais"),
                        Situacao = objList.Valor("Situacao")

                    });
                    objList.Seguinte();

                }

                return listClientes;
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.Cliente GetCliente(string codCliente)
        {
            

            GcpBECliente objCli = new GcpBECliente();


            Model.Cliente myCli = new Model.Cliente();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == true)
                {
                    objCli = PriEngine.Engine.Comercial.Clientes.Edita(codCliente);
                    myCli.CodCliente = objCli.get_Cliente();
                    myCli.NomeCliente = objCli.get_Nome();
                    myCli.Moeda = objCli.get_Moeda();
                    myCli.NumContribuinte = objCli.get_NumContribuinte();
                    myCli.Morada = objCli.get_Morada();
                    myCli.Pais = objCli.get_Pais();
                    myCli.Situacao = objCli.get_Situacao();
                    return myCli;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.RespostaErro UpdCliente(Lib_Primavera.Model.Cliente cliente)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
           

            GcpBECliente objCli = new GcpBECliente();

            try
            {

                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {

                    if (PriEngine.Engine.Comercial.Clientes.Existe(cliente.CodCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        objCli = PriEngine.Engine.Comercial.Clientes.Edita(cliente.CodCliente);
                        objCli.set_EmModoEdicao(true);

                        objCli.set_Nome(cliente.NomeCliente);
                        objCli.set_NumContribuinte(cliente.NumContribuinte);
                        objCli.set_Moeda(cliente.Moeda);
                        objCli.set_Morada(cliente.Morada);

                        PriEngine.Engine.Comercial.Clientes.Actualiza(objCli);

                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;

                }

            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }


        public static Lib_Primavera.Model.RespostaErro DelCliente(string codCliente)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBECliente objCli = new GcpBECliente();


            try
            {

                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {
                    if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        PriEngine.Engine.Comercial.Clientes.Remove(codCliente);
                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }

                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }


        public static List<Model.TotalClientes> TotalClientes()
        {


            StdBELista objList;

            List<Model.TotalClientes> totalClientes = new List<Model.TotalClientes>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = PriEngine.Engine.Consulta("SELECT COUNT(*) as totalclientes  FROM  CLIENTES");

                totalClientes.Add(new Model.TotalClientes
                {
                    totalclientes = objList.Valor("totalclientes")
                
                });


                return totalClientes;
                }

                 else
                return null;

            }
          
       



        public static Lib_Primavera.Model.RespostaErro InsereClienteObj(Model.Cliente cli)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            

            GcpBECliente myCli = new GcpBECliente();

            try
            {
                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {

                    myCli.set_Cliente(cli.CodCliente);
                    myCli.set_Nome(cli.NomeCliente);
                    myCli.set_NumContribuinte(cli.NumContribuinte);
                    myCli.set_Moeda(cli.Moeda);
                    myCli.set_Morada(cli.Morada);

                    PriEngine.Engine.Comercial.Clientes.Actualiza(myCli);

                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }


        }

       

        #endregion Cliente;   // -----------------------------  END   CLIENTE    -----------------------

        #region Funcionario
        
        public static List<Model.Funcionario> ListaFuncionarios()
        {

            StdBELista objList;

            Model.Funcionario func = new Model.Funcionario();
            List<Model.Funcionario> listFuncionarios = new List<Model.Funcionario>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT DATEDIFF(dy, DataNascimento, getdate()) as Idade, Funcionarios.Distrito, Distritos.Distrito, Distritos.Descricao as DistritoDesc, Codigo as CodFunc, Nome as NomeFunc, Sexo as SexoFunc, VencimentoMensal as OrdenadoMensal, HorasSemana as HorasMes FROM  FUNCIONARIOS, DISTRITOS WHERE funcionarios.Distrito = distritos.Distrito");
                while (!objList.NoFim())

                {
                    func = new Model.Funcionario();
                    func.CodFunc = objList.Valor("CodFunc");
                    func.NomeFunc = objList.Valor("NomeFunc");
                    func.OrdenadoMensal = objList.Valor("OrdenadoMensal");
                    func.HorasMes = objList.Valor("HorasMes");
                    func.Distrito = objList.Valor("DistritoDesc");
                    func.Idade = objList.Valor("Idade")/365;
                    if (objList.Valor("SexoFunc") == "1")
                        func.Sexo = "Feminino";
                    else
                        func.Sexo = "Masculino";
                   

                        listFuncionarios.Add(func);
                    objList.Seguinte();
                }

                return listFuncionarios;

            }
            else
            {
                return null;

            }

        }
        
        #endregion

        #region TopCliente
        public static List<Model.TopCliente> ListaTopCliente(long nr)
        {

            StdBELista objList;

            Model.TopCliente tc = new Model.TopCliente();
            List<Model.TopCliente> listTC = new List<Model.TopCliente>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT TOP " + nr + " Entidade as CodCliente, Nome as NomeCliente, Morada as MoradaCliente, sum(TotalMerc) as RendimentoCliente FROM CabecDoc WHERE TipoDoc = 'FA' GROUP BY Nome, Entidade, Morada ORDER BY RendimentoCliente DESC");    
                while (!objList.NoFim())

                {
                    tc = new Model.TopCliente();
                    tc.CodCliente = objList.Valor("CodCliente");
                    tc.NomeCliente = objList.Valor("NomeCliente");
                    tc.MoradaCliente = objList.Valor("MoradaCliente");
                    tc.RendimentoCliente= objList.Valor("RendimentoCliente");

                    listTC.Add(tc);
                    objList.Seguinte();
                }

                return listTC;

            }
            else
            {
                return null;

            }

        }

        #endregion
        
        #region Artigo

        public static Lib_Primavera.Model.Artigo GetArtigo(string codArtigo)
        {
            
            GcpBEArtigo objArtigo = new GcpBEArtigo();
            Model.Artigo myArt = new Model.Artigo();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                if (PriEngine.Engine.Comercial.Artigos.Existe(codArtigo) == false)
                {
                    return null;
                }
                else
                {
                    objArtigo = PriEngine.Engine.Comercial.Artigos.Edita(codArtigo);
                    myArt.CodArtigo = objArtigo.get_Artigo();
                    myArt.DescArtigo = objArtigo.get_Descricao();
                    myArt.StockActual = objArtigo.get_StkActual();

                    return myArt;
                }
                
            }
            else
            {
                return null;
            }

        }

        public static List<Model.Artigo> ListaArtigos()
        {
                        
            StdBELista objList;

            Model.Artigo art = new Model.Artigo();
            List<Model.Artigo> listArts = new List<Model.Artigo>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();

                objList = PriEngine.Engine.Consulta("SELECT Artigo, Descricao, STKActual FROM  ARTIGO");

                while (!objList.NoFim())
                {
                    art = new Model.Artigo();
                    art.CodArtigo = objList.Valor("Artigo");
                    art.DescArtigo = objList.Valor("Descricao");
                    art.StockActual = objList.Valor("STKActual");
                    
                   

                    listArts.Add(art);
                    objList.Seguinte();
                }

                return listArts;

            }
            else
            {
                return null;

            }

        }

        #endregion Artigo

        #region DocCompra
        

        public static List<Model.DocCompra> VGR_List()
        {
                
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();
            Model.LinhaDocCompra lindc = new Model.LinhaDocCompra();
            List<Model.LinhaDocCompra> listlindc = new List<Model.LinhaDocCompra>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, NumDocExterno, Entidade, DataDoc, NumDoc, TotalMerc, Serie From CabecCompras where TipoDoc='VGR'");
                while (!objListCab.NoFim())
                {
                    dc = new Model.DocCompra();
                    dc.id = objListCab.Valor("id");
                    dc.NumDocExterno = objListCab.Valor("NumDocExterno");
                    dc.Entidade = objListCab.Valor("Entidade");
                    dc.NumDoc = objListCab.Valor("NumDoc");
                    dc.Data = objListCab.Valor("DataDoc");
                    dc.TotalMerc = objListCab.Valor("TotalMerc");
                    dc.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecCompras, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido, Armazem, Lote from LinhasCompras where IdCabecCompras='" + dc.id + "' order By NumLinha");
                    listlindc = new List<Model.LinhaDocCompra>();

                    while (!objListLin.NoFim())
                    {
                        lindc = new Model.LinhaDocCompra();
                        lindc.IdCabecDoc = objListLin.Valor("idCabecCompras");
                        lindc.CodArtigo = objListLin.Valor("Artigo");
                        lindc.DescArtigo = objListLin.Valor("Descricao");
                        lindc.Quantidade = objListLin.Valor("Quantidade");
                        lindc.Unidade = objListLin.Valor("Unidade");
                        lindc.Desconto = objListLin.Valor("Desconto1");
                        lindc.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindc.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindc.TotalLiquido = objListLin.Valor("PrecoLiquido");
                        lindc.Armazem = objListLin.Valor("Armazem");
                        lindc.Lote = objListLin.Valor("Lote");

                        listlindc.Add(lindc);
                        objListLin.Seguinte();
                    }

                    dc.LinhasDoc = listlindc;
                    
                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }

                
        public static Model.RespostaErro VGR_New(Model.DocCompra dc)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            

            GcpBEDocumentoCompra myGR = new GcpBEDocumentoCompra();
            GcpBELinhaDocumentoCompra myLin = new GcpBELinhaDocumentoCompra();
            GcpBELinhasDocumentoCompra myLinhas = new GcpBELinhasDocumentoCompra();

            PreencheRelacaoCompras rl = new PreencheRelacaoCompras();
            List<Model.LinhaDocCompra> lstlindv = new List<Model.LinhaDocCompra>();

            try
            {
                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myGR.set_Entidade(dc.Entidade);
                    myGR.set_NumDocExterno(dc.NumDocExterno);
                    myGR.set_Serie(dc.Serie);
                    myGR.set_Tipodoc("VGR");
                    myGR.set_TipoEntidade("F");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dc.LinhasDoc;
                    //PriEngine.Engine.
                   
                    //al.Compras.PreencheDadosRelacionados(myGR,rl);
                    PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(myGR);
                    foreach (Model.LinhaDocCompra lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Compras.AdicionaLinha(myGR, lin.CodArtigo, lin.Quantidade, lin.Armazem, "", lin.PrecoUnitario, lin.Desconto);
                    }


                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Compras.Actualiza(myGR, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }


        #endregion DocCompra

        #region DocsVenda

      /*  public static Model.RespostaErro Encomendas_New(Model.DocVenda dv)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBEDocumentoVenda myEnc = new GcpBEDocumentoVenda();
             
            GcpBELinhaDocumentoVenda myLin = new GcpBELinhaDocumentoVenda();

            GcpBELinhasDocumentoVenda myLinhas = new GcpBELinhasDocumentoVenda();
             
            PreencheRelacaoVendas rl = new PreencheRelacaoVendas();
            List<Model.LinhaDocVenda> lstlindv = new List<Model.LinhaDocVenda>();
            
            try
            {
                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myEnc.set_Entidade(dv.Entidade);
                    myEnc.set_Serie(dv.Serie);
                    myEnc.set_Tipodoc("ECL");
                    myEnc.set_TipoEntidade("C");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dv.LinhasDoc;
                    //PriEngine.Engine.Comercial.Vendas.PreencheDadosRelacionados(myEnc, rl);
                    PriEngine.Engine.Comercial.Vendas.PreencheDadosRelacionados(myEnc);
                    foreach (Model.LinhaDocVenda lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Vendas.AdicionaLinha(myEnc, lin.CodArtigo, lin.Quantidade, "", "", lin.PrecoUnitario, lin.Desconto);
                    }


                   // PriEngine.Engine.Comercial.Compras.TransformaDocumento(

                    PriEngine.Engine.IniciaTransaccao();
                    //PriEngine.Engine.Comercial.Vendas.Edita Actualiza(myEnc, "Teste");
                    PriEngine.Engine.Comercial.Vendas.Actualiza(myEnc, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }*/



        public static List<Model.DocVenda> Encomendas_List(string typeDoc, string dateBegin, string dateEnd)
        {
            
            StdBELista objListCab;
            StdBELista objListLin;
            StdBELista objListCab2;
            Model.DocVenda dv = new Model.DocVenda();
            List<Model.DocVenda> listdv = new List<Model.DocVenda>();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new
            List<Model.LinhaDocVenda>();

            Model.ClienteFac cf = new Model.ClienteFac();
           

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {


                objListCab = PriEngine.Engine.Consulta("SELECT id, Entidade, Data, ModoPag ,NumDoc,TotalIva, TotalDesc ,TotalMerc, Serie, Morada, Localidade, CodPostal, CodPostalLocalidade, DataVencimento From CabecDoc where TipoDoc LIKE '" + typeDoc + "' and Data>='" + dateBegin + "' and Data<='" + dateEnd + "'");
                while (!objListCab.NoFim())
                {
                    dv = new Model.DocVenda();
                    dv.id = objListCab.Valor("id");
                    dv.Entidade = objListCab.Valor("Entidade");
                    dv.NumDoc = objListCab.Valor("NumDoc");
                    dv.Data = objListCab.Valor("Data");
                    dv.TotalMerc = objListCab.Valor("TotalMerc");
                    dv.Serie = objListCab.Valor("Serie");
                    dv.TotalIva = objListCab.Valor("TotalIva");
                    dv.DataVencimento = objListCab.Valor("DataVencimento");
                    dv.TotalDesc = objListCab.Valor("TotalDesc");
                    dv.ModoPag = objListCab.Valor("ModoPag");
                    objListCab2 = PriEngine.Engine.Consulta("SELECT Nome, Fac_Tel , NumContrib, ModoPag, Pais FROM Clientes where Cliente LIKE '"+dv.Entidade+"'");
                    cf=new Model.ClienteFac();
                    cf.Nome = objListCab2.Valor("Nome");
                    cf.Morada = objListCab.Valor("Morada");
                    cf.Telefone = objListCab2.Valor("Fac_Tel");
                    cf.NumContribuinte = objListCab2.Valor("NumContrib");
                    cf.Pais = objListCab2.Valor("Pais");
                    cf.Local = objListCab.Valor("Localidade");
                    cf.CodPostal = objListCab.Valor("CodPostal");
                    cf.CodPostalLocalidade = objListCab.Valor("CodPostalLocalidade");

                    
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, TaxaIva ,Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                    listlindv = new List<Model.LinhaDocVenda>();

                    while (!objListLin.NoFim())
                    {
                        lindv = new Model.LinhaDocVenda();
                        lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                        lindv.CodArtigo = objListLin.Valor("Artigo");
                        lindv.DescArtigo = objListLin.Valor("Descricao");
                        lindv.Quantidade = objListLin.Valor("Quantidade");
                        lindv.Unidade = objListLin.Valor("Unidade");
                        lindv.Desconto = objListLin.Valor("Desconto1");
                        lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");
                        lindv.TaxaIva = objListLin.Valor("TaxaIva");
                        

                        listlindv.Add(lindv);
                        objListLin.Seguinte();
                    }

                    dv.Cliente = cf;
                    dv.LinhasDoc = listlindv;
                    listdv.Add(dv);
                    objListCab.Seguinte();
                }
            }
            return listdv;
        }


       

        public static Model.DocVenda Encomenda_Get(string numdoc)
        {
            
            
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                

                string st = "SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where TipoDoc='ECL' and NumDoc='" + numdoc + "'";
                objListCab = PriEngine.Engine.Consulta(st);
                dv = new Model.DocVenda();
                dv.id = objListCab.Valor("id");
                dv.Entidade = objListCab.Valor("Entidade");
                dv.NumDoc = objListCab.Valor("NumDoc");
                dv.Data = objListCab.Valor("Data");
                dv.TotalMerc = objListCab.Valor("TotalMerc");
                dv.Serie = objListCab.Valor("Serie");
                objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                listlindv = new List<Model.LinhaDocVenda>();

                while (!objListLin.NoFim())
                {
                    lindv = new Model.LinhaDocVenda();
                    lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                    lindv.CodArtigo = objListLin.Valor("Artigo");
                    lindv.DescArtigo = objListLin.Valor("Descricao");
                    lindv.Quantidade = objListLin.Valor("Quantidade");
                    lindv.Unidade = objListLin.Valor("Unidade");
                    lindv.Desconto = objListLin.Valor("Desconto1");
                    lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                    lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                    lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");
                    listlindv.Add(lindv);
                    objListLin.Seguinte();
                }

                dv.LinhasDoc = listlindv;
                return dv;
            }
            return null;
        }

        #endregion DocsVenda

        #region fornecedores
        public static List<Model.Fornecedor> ListaFornecedores()
        {

            StdBELista objList;

            Model.Fornecedor forn = new Model.Fornecedor();
            List<Model.Fornecedor> listForn = new List<Model.Fornecedor>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT Fornecedor, Nome, Moeda, NumContrib , ModoPag, CondPag, TotalDeb FROM  FORNECEDORES");

                while (!objList.NoFim())
                {
                    forn = new Model.Fornecedor();
                    listForn.Add(new Model.Fornecedor
                {
                    CodFornecedor = objList.Valor("Fornecedor"),
                    Nome = objList.Valor("Nome"),
                    Moeda = objList.Valor("Moeda"),
                    NumContrib = objList.Valor("NumContrib"),
                    ModoPag = objList.Valor("ModoPag"),
                    CondPag = objList.Valor("CondPag"),
                    TotalDeb = objList.Valor("TotalDeb")
                    
                });
                    objList.Seguinte();

                    
                }
             return listForn;
            }
            else
                return null;
        }

         
        #endregion

        #region topvenda

        public static List<Model.TopVenda> ListaTopVenda(long nr)
        {

            StdBELista objList;

            Model.TopVenda tv = new Model.TopVenda();
            List<Model.TopVenda> listTV = new List<Model.TopVenda>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT TOP " + nr + " LinhasDoc.Artigo, Artigo.Descricao as NomeArtigo, sum(Quantidade) AS QuantidadeArtigo FROM LinhasDoc LEFT JOIN CabecDoc on LinhasDoc.IdCabecDoc = CabecDoc.Id left join Artigo on LinhasDoc.Artigo = Artigo.Artigo WHERE CabecDoc.TipoDoc = 'FA' AND LinhasDoc.Artigo <> 'NULL' Group by LinhasDoc.Artigo, Artigo.Descricao ORDER BY QuantidadeArtigo DESC");
                while (!objList.NoFim())

                //" Artigo, Descricao as NomeArtigo, Quantidade as QuantidadeArtigo FROM LinhasDoc ORDER BY Quantidade DESC");
                {
                    tv = new Model.TopVenda();
                    tv.CodArtigo = objList.Valor("Artigo");
                    tv.NomeArtigo = objList.Valor("NomeArtigo");
                    tv.QuantidadeArtigo = objList.Valor("QuantidadeArtigo");

                    listTV.Add(tv);
                    objList.Seguinte();
                }

                return listTV;

            }
            else
            {
                return null;

            }

        }
        #endregion

        #region topRendimento

        public static List<Model.TopRendimento> ListaTopRendimento(long nr)
        {

            StdBELista objList;

            Model.TopRendimento tr = new Model.TopRendimento();
            List<Model.TopRendimento> listTR = new List<Model.TopRendimento>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT TOP " + nr + " LinhasDoc.Artigo, Artigo.Descricao as NomeArtigo, sum(Quantidade) AS QuantidadeArtigo, PrecUnit*sum(Quantidade) as Rendimento, PrecUnit FROM LinhasDoc LEFT JOIN CabecDoc on LinhasDoc.IdCabecDoc = CabecDoc.Id left join Artigo on LinhasDoc.Artigo = Artigo.Artigo WHERE CabecDoc.TipoDoc = 'FA' AND LinhasDoc.Artigo <> 'NULL' Group by LinhasDoc.Artigo, Artigo.Descricao, LinhasDoc.PrecUnit ORDER BY Rendimento DESC");
                while (!objList.NoFim())

                //" Artigo, Descricao as NomeArtigo, Quantidade as QuantidadeArtigo FROM LinhasDoc ORDER BY Quantidade DESC");
                {
                    tr = new Model.TopRendimento();
                    tr.CodArtigo = objList.Valor("Artigo");
                    tr.NomeArtigo = objList.Valor("NomeArtigo");
                    tr.QuantidadeArtigo = objList.Valor("QuantidadeArtigo");
                    tr.PrecUnitArtigo = objList.Valor("PrecUnit");
                    tr.RendimentoArtigo = objList.Valor("Rendimento");


                    listTR.Add(tr);
                    objList.Seguinte();
                }

                return listTR;

            }
            else
            {
                return null;

            }

        }
        #endregion

        #region TopCategorias
        public static List<Model.TopCategoria> ListaTopCategorias(long nr)
        {
                StdBELista objList;

            Model.TopCategoria tc = new Model.TopCategoria();
            List<Model.TopCategoria> listTC = new List<Model.TopCategoria>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT TOP " + nr +" Artigo.Familia as Categoria, Familias.Descricao, SUM(PrecoLiquido) as totalCat FROM LinhasDoc LEFT JOIN CabecDoc ON LinhasDoc.IdCabecDoc=CabecDoc.ID LEFT JOIN Artigo ON LinhasDoc.Artigo = Artigo.Artigo LEFT JOIN Familias on Artigo.Familia = Familias.Familia WHERE CabecDoc.TipoDoc = 'FA' AND Artigo.Artigo <> 'NULL' AND Artigo.Familia <> 'NULL' group by Artigo.Familia, Familias.Descricao order by totalCat desc") ;
        
         while (!objList.NoFim())

          
                {
                    tc = new Model.TopCategoria();
                    tc.CodFamilia = objList.Valor("Categoria");
                    tc.Descricao = objList.Valor("descricao");
                    tc.TotalVend = objList.Valor("totalCat");
                 

                    listTC.Add(tc);
                    objList.Seguinte();
                }

                return listTC;

            }
            else
            {
                return null;

            }

        }
        #endregion

        #region TotalIncome
        public static List<Model.TotalIncome> ListaIncome()
        {

            StdBELista objList;

            Model.TotalIncome inc = new Model.TotalIncome();
            List<Model.TotalIncome> listINC = new List<Model.TotalIncome>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT sum(TotalMerc) as Valor, sum(TotalIva) as iva, sum(TotalDesc) as desconto FROM CabecDoc WHERE TipoDoc = 'FA'");
                while (!objList.NoFim())

                {
                    inc = new Model.TotalIncome();
                    inc.Valor = objList.Valor("Valor") + objList.Valor("iva") - objList.Valor("desconto");
                 
                    listINC.Add(inc);
                    objList.Seguinte();
                }

                return listINC;

            }
            else
            {
                return null;

            }

        }

        #endregion
  
        #region TotalOutcome
        public static List<Model.TotalOutcome> ListaOutcome()
        {

            StdBELista objList;

            Model.TotalOutcome outc = new Model.TotalOutcome();
            List<Model.TotalOutcome> listOUT = new List<Model.TotalOutcome>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT sum(PrecUnit*Quantidade) as Valor FROM LinhasCompras");
                while (!objList.NoFim())
                {
                    outc = new Model.TotalOutcome();
                    outc.Valor = objList.Valor("Valor");

                    listOUT.Add(outc);
                    objList.Seguinte();
                }

                return listOUT;

            }
            else
            {
                return null;

            }

        }

        #endregion

        #region TotalIncomeByMonth

        public static List<Model.TotalIncomeByMonth> ListaIncomeByMonth(double mes, double ano)
        {

            StdBELista objList;

            Model.TotalIncomeByMonth incMonth = new Model.TotalIncomeByMonth();
            List<Model.TotalIncomeByMonth> listINCmonth = new List<Model.TotalIncomeByMonth>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT COALESCE (sum(TotalMerc),0) as Valor, (sum(TotalIva),0) as iva,(sum(TotalDesc),0) as desconto  FROM [CabecDoc] WHERE (TipoDoc = 'FA') AND month(Data) = " + mes + " AND year(Data) = " + ano + "");
                                                                                                                    

                while (!objList.NoFim())

                {
                    incMonth = new Model.TotalIncomeByMonth();
                    incMonth.ValorInc = objList.Valor("Valor") + objList.Valor("iva") - objList.Valor("desconto");

                    listINCmonth.Add(incMonth);
                    objList.Seguinte();
                }

                return listINCmonth;

            }
            else
            {
                return null;

            }

        }

        public static List<Model.TotalIncomeByMonth> ListaIncomeLasMonths(string dateBegin)
        {

            StdBELista objList;
            StdBELista objList2;
           

            DateTime date = DateTime.Parse(dateBegin).AddMonths(-12);
            var dateEnd = date.ToString("yyyy-MM-ddTHH:mm:ss");

            
            Model.TotalIncomeByMonth incMonth = new Model.TotalIncomeByMonth();
            List<Model.TotalIncomeByMonth> listINCmonth = new List<Model.TotalIncomeByMonth>();

          

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT sum(TotalMerc) as Valor,sum(TotalIva) as iva, sum(TotalDesc) as desconto, Month(Data) as data FROM [CabecDoc] WHERE (TipoDoc = 'FA') AND Data<='" + dateBegin + "' and Data>='" + dateEnd + "' GROUP BY Month(Data)");
                objList2 = PriEngine.Engine.Consulta("SELECT sum(TotalMerc) as Valor,sum(TotalIva) as iva, sum(TotalDesc) as desconto, Month(DataDoc) as data FROM [CabecCompras]  WHERE DataDoc<='" + dateBegin + "' and DataDoc>='" + dateEnd + "' GROUP BY Month(DataDoc)");
                int count = 1;
                
             
                while (!objList.NoFim())
                {
                    if (count == objList.Valor("data"))
                    {
                        incMonth = new Model.TotalIncomeByMonth();
                        incMonth.ValorInc = Math.Abs(objList.Valor("Valor") + objList.Valor("iva") - objList.Valor("desconto"));
                        incMonth.Date = objList.Valor("data");
                        listINCmonth.Add(incMonth);
                        objList.Seguinte();
                        count++;
                    }
                    else
                    {
                        incMonth = new Model.TotalIncomeByMonth();
                        incMonth.ValorInc = 0;
                        incMonth.Date =count;
                        listINCmonth.Add(incMonth);
                       
                        count++;
                    }
                   
                }

                int count2 = 1;
                while (!objList2.NoFim())
                {
                    if (count2 == objList2.Valor("data"))
                    {
                        incMonth = new Model.TotalIncomeByMonth();
                        incMonth.ValorOut = Math.Abs(objList2.Valor("Valor") + objList2.Valor("iva") - objList2.Valor("desconto"));
                        incMonth.Date = objList2.Valor("data");
                        listINCmonth.Add(incMonth);
                        objList2.Seguinte();
                        count2++;
                    }
                    else
                    {
                        incMonth = new Model.TotalIncomeByMonth();
                        incMonth.ValorOut = 0;
                        incMonth.Date = count2;
                        listINCmonth.Add(incMonth);

                        count2++;
                    }
                }
                if (count <= 12)
                {
                    while (count <= 12)
                    {
                        incMonth = new Model.TotalIncomeByMonth();
                        incMonth.ValorInc = 0;
                        incMonth.Date = count;
                        listINCmonth.Add(incMonth);

                        count++;
                    }
                }
                if (count2 <= 12)
                {
                    while (count2 <= 12)
                    {
                        incMonth = new Model.TotalIncomeByMonth();
                        incMonth.ValorOut = 0;
                        incMonth.Date = count2;
                        listINCmonth.Add(incMonth);

                        count++;
                    }
                }

      

                return listINCmonth;

            }
            else
            {
                return null;

            }

        }



        #endregion
  
        #region TotalOutcomeByMonth

        public static List<Model.TotalOutcomeByMonth> ListaOutcomeByMonth(double mes, double ano)
        {

            StdBELista objList;

            Model.TotalOutcomeByMonth outMonth = new Model.TotalOutcomeByMonth();
            List<Model.TotalOutcomeByMonth> listOUTmonth = new List<Model.TotalOutcomeByMonth>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT COALESCE (sum(PrecUnit*Quantidade),0) as Valor FROM [LinhasDoc] WHERE month(Data) = " + mes + " AND year(Data) = " + ano + "");

                while (!objList.NoFim())

                {
                    outMonth = new Model.TotalOutcomeByMonth();
                    outMonth.Valor = objList.Valor("Valor");

                    listOUTmonth.Add(outMonth);
                    objList.Seguinte();
                }

                return listOUTmonth;

            }
            else
            {
                return null;

            }

        }

        #endregion

        #region TotalNovosClientes

        public static List<Model.TotalNovosClientes> ListaNovosClientes()
        {

            StdBELista objList;

            Model.TotalNovosClientes tnc = new Model.TotalNovosClientes();
            List<Model.TotalNovosClientes> listTNC = new List<Model.TotalNovosClientes>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT Cliente as CodCliente, Nome as NomeCliente, Fac_Mor as MoradaCliente, DataCriacao as DataCriacaoCliente  FROM Clientes WHERE DATEDIFF(dy, DataCriacao, getdate()) <= 90 GROUP BY Cliente, Nome, DataCriacao, Fac_Mor ORDER BY DataCriacao DESC");    
                while (!objList.NoFim())
                {
                    tnc = new Model.TotalNovosClientes();
                    tnc.CodCliente = objList.Valor("CodCliente");
                    tnc.NomeCliente = objList.Valor("NomeCliente");
                    tnc.MoradaCliente = objList.Valor("MoradaCliente");
                    tnc.DataCriacaoCliente = objList.Valor("DataCriacaoCliente");

                    listTNC.Add(tnc);
                    objList.Seguinte();
                }

                return listTNC;

            }
            else
            {
                return null;

            }

        }

        #endregion  

        #region neworders

        public static List<Model.OrdersCount> OrdersCount()
        {
            StdBELista objList;
            List<Model.OrdersCount> ordrscnt = new List<Model.OrdersCount>();
            Model.OrdersCount oc = new Model.OrdersCount();
           

            
            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT COUNT(*) as CountOrders FROM CabecDoc WHERE TipoDoc = 'ECL' ");
                oc = new Model.OrdersCount();
                oc.CountOrders = objList.Valor("CountOrders");
                ordrscnt.Add(oc);
            }

            return ordrscnt;

        }


        public static List<Model.NewOrdersNumber> NewOrdersCount()
        {
            StdBELista objList;
            List<Model.NewOrdersNumber> ordrscnt = new List<Model.NewOrdersNumber>();
            Model.NewOrdersNumber oc = new Model.NewOrdersNumber();



            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objList = PriEngine.Engine.Consulta(" SELECT ( SELECT COUNT(*) FROM CabecDoc WHERE TipoDoc = 'ECL' and Data >= DATEADD(month,-1,GETDATE())) as CountOrders, ( SELECT COUNT(*) FROM CabecDoc WHERE TipoDoc = 'ECL' and Data >= DATEADD(month,-2,GETDATE())) as CountOrdersb");

               


                oc = new Model.NewOrdersNumber();
                oc.CountOrders = objList.Valor("CountOrders");
               
                var CountOrdersa = objList.Valor("CountOrders");
                var CountOrdersb = objList.Valor("CountOrdersb");
                oc.Increment = CountOrdersa - (CountOrdersb - CountOrdersa);
                ordrscnt.Add(oc);
            }

            return ordrscnt;

        }

        #endregion 

        #region accounts
        public static List<Model.GetAccountsPayable> GetAccountsPayable()
        {
            StdBELista objList;
            List<Model.GetAccountsPayable> pyblcnt = new List<Model.GetAccountsPayable>();
            Model.GetAccountsPayable oc = new Model.GetAccountsPayable();



            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT SUM(TotalDeb) as accountspayable FROM Fornecedores WHERE TotalDeb < 0 ");
                oc = new Model.GetAccountsPayable();
                oc.accountspayable = objList.Valor("accountspayable");
                pyblcnt.Add(oc);
            }

            return pyblcnt;

        }

        public static List<Model.GetAccountsReceivable> GetAccountsReceivable()
        {
            StdBELista objList;
            List<Model.GetAccountsReceivable> pyblcnt = new List<Model.GetAccountsReceivable>();
            Model.GetAccountsReceivable oc = new Model.GetAccountsReceivable();



            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT SUM(TotalDeb) as accountsreceivable FROM Clientes WHERE TotalDeb < 0 ");
                oc = new Model.GetAccountsReceivable();
                oc.accountsreceivable = objList.Valor("accountsreceivable");
                pyblcnt.Add(oc);
            }

            return pyblcnt;

        }
        #endregion

        #region Dashboard
        public static List<Model.Dashboard> GetDashboard()
        {
            StdBELista objList;
            StdBELista objList2;
            StdBELista objList3;
            StdBELista objList4;
            StdBELista objList5;
            StdBELista objList6;
            List<Model.Dashboard> pyblcnt = new List<Model.Dashboard>();
            Model.Dashboard oc = new Model.Dashboard();
            Model.TopCliente tc = new Model.TopCliente();
            List<Model.TopCliente> ltc = new List<Model.TopCliente>();
            Model.TopCategoria tcat = new Model.TopCategoria();
            List<Model.TopCategoria> ltcat = new List<Model.TopCategoria>();
            Model.TopVenda tvend = new Model.TopVenda();
            List<Model.TopVenda> ltvend = new List<Model.TopVenda>();
            


            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT (SELECT SUM(TotalDeb) FROM Clientes WHERE TotalDeb < 0) as accountsreceivable,( SELECT SUM(TotalDeb) FROM Fornecedores WHERE TotalDeb < 0) as accountspayable, (SELECT COUNT(Cliente) FROM Clientes WHERE DATEDIFF(dy, DataCriacao, getdate()) <= 90) as countcli, (SELECT COUNT(*) FROM CabecDoc WHERE TipoDoc = 'ECL') as totalorders ");
                objList3 = PriEngine.Engine.Consulta("SELECT TOP 5 Nome as NomeCliente, Morada as MoradaCliente, sum(TotalMerc) as RendimentoCliente FROM CabecDoc WHERE TipoDoc = 'FA' GROUP BY Nome, Morada ORDER BY RendimentoCliente DESC");    
                objList2 = PriEngine.Engine.Consulta(" SELECT ( SELECT COUNT(*) FROM CabecDoc WHERE TipoDoc = 'ECL' and Data >= DATEADD(month,-1,GETDATE())) as CountOrders, ( SELECT COUNT(*) FROM CabecDoc WHERE TipoDoc = 'ECL' and Data >= DATEADD(month,-2,GETDATE())) as CountOrdersb");
                objList4 = PriEngine.Engine.Consulta("SELECT TOP 7 Artigo.Familia as Categoria, Familias.Descricao, SUM(PrecoLiquido) as totalCat FROM LinhasDoc LEFT JOIN CabecDoc ON LinhasDoc.IdCabecDoc=CabecDoc.ID LEFT JOIN Artigo ON LinhasDoc.Artigo = Artigo.Artigo LEFT JOIN Familias on Artigo.Familia = Familias.Familia WHERE CabecDoc.TipoDoc = 'FA' AND Artigo.Artigo <> 'NULL' AND Artigo.Familia <> 'NULL' group by Artigo.Familia, Familias.Descricao order by totalCat desc");
                objList5 = PriEngine.Engine.Consulta("SELECT TOP 5 LinhasDoc.Artigo, Artigo.Descricao as NomeArtigo, sum(Quantidade) AS QuantidadeArtigo FROM LinhasDoc LEFT JOIN CabecDoc on LinhasDoc.IdCabecDoc = CabecDoc.Id left join Artigo on LinhasDoc.Artigo = Artigo.Artigo WHERE CabecDoc.TipoDoc = 'FA' AND LinhasDoc.Artigo <> 'NULL' Group by LinhasDoc.Artigo, Artigo.Descricao ORDER BY QuantidadeArtigo DESC");
                objList6 = PriEngine.Engine.Consulta("SELECT COUNT(*) as cnt FROM CabecDoc WHERE TipoDoc = 'FA'");
                oc = new Model.Dashboard();
                oc.AccountsReceivable = objList.Valor("accountsreceivable");
                oc.AccountsPayable = objList.Valor("accountspayable");
                oc.NewClients = objList.Valor("countcli");
                oc.Orders = objList.Valor("totalorders");
                oc.newOrders = objList2.Valor("CountOrders");
                oc.CountFac = objList6.Valor("cnt");
                
                int count = 1;
                while (!objList3.NoFim())
                {
                    tc = new Model.TopCliente();
                    tc.Numbercnt = count;
                    tc.NomeCliente = objList3.Valor("NomeCliente");
                    tc.MoradaCliente = objList3.Valor("MoradaCliente");
                    tc.RendimentoCliente = objList3.Valor("RendimentoCliente");

                    ltc.Add(tc);
                    objList3.Seguinte();
                    count++;
                }

                oc.TopClientes = ltc;

                while (!objList4.NoFim())
                {
                    tcat = new Model.TopCategoria();
                    tcat.CodFamilia = objList4.Valor("Categoria");
                    tcat.Descricao = objList4.Valor("descricao");
                    tcat.TotalVend = objList4.Valor("totalCat");


                    ltcat.Add(tcat);
                    objList4.Seguinte();
                }

                oc.TopFamilia = ltcat;


                int cnt2 = 1;
                
                while (!objList5.NoFim())

                //" Artigo, Descricao as NomeArtigo, Quantidade as QuantidadeArtigo FROM LinhasDoc ORDER BY Quantidade DESC");
                {
                    tvend = new Model.TopVenda();
                    tvend.Numbercnt = cnt2;
                    tvend.CodArtigo = objList5.Valor("Artigo");
                    tvend.NomeArtigo = objList5.Valor("NomeArtigo");
                    tvend.QuantidadeArtigo = objList5.Valor("QuantidadeArtigo");

                    ltvend.Add(tvend);
                    objList5.Seguinte();
                    cnt2++;
                }

                oc.TopProducts = ltvend;


                var CountOrdersa = objList2.Valor("CountOrders");
                var CountOrdersb = objList2.Valor("CountOrdersb");
                oc.Increment = CountOrdersa - (CountOrdersb - CountOrdersa);

               
                pyblcnt.Add(oc);
                
            }

            return pyblcnt;

        }

        #endregion

     
       


    }
}