<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="ASPBatNet.Models" %> 
<%@ Import Namespace="ASPBatNet.Controllers" %> 

<script runat="server">
    void Logon_Click(object sender, EventArgs e)
    {

        KorisniciController korisnici = new KorisniciController();
        var tabelaKorisnika = korisnici.GetKorisnici().ToList();

        TehnologijeController tehnologije = new TehnologijeController();
        var tabelaTehnologija = tehnologije.GetTehnologije().ToList();

        NotifikacijeController notifikacije = new NotifikacijeController();
        var tabelaNotifikacija = notifikacije.GetNotifikacije().ToList();

        PorukeController poruke = new PorukeController();
        var tabelaPoruka = poruke.GetPoruke().ToList();

        ProjektiController projekti = new ProjektiController();
        var tabelaProjekata = projekti.GetProjekti().ToList();

        ASPBatNetModel.SviProjekti = tabelaProjekata;

        foreach (Korisnici k in tabelaKorisnika)
        {
            string hashPass = KorisniciController.CreateMD5(UserPass.Text);
            if ((UserName.Text == k.username) &&
                    (hashPass == k.sifra) &&
                    k.obrisan != true)
            {
                if (k.CV == null)
                {
                    ASPBatNetModel.Naziv = "Ime i prezime: ";
                    ASPBatNetModel.Datum = "Datum rođenja: ";
                }
                else
                {
                    ASPBatNetModel.Naziv = "Naziv firme: ";
                    ASPBatNetModel.Datum = "Datum osnivanja: ";
                }
                ASPBatNetModel.Username = k.username;
                ASPBatNetModel.Email = k.email;
                ASPBatNetModel.Github_Link = k.github_link;
                ASPBatNetModel.Bodovi = k.bodovi.GetValueOrDefault();
                ASPBatNetModel.Naziv += k.naziv;
                ASPBatNetModel.Datum += k.datum.GetValueOrDefault().DateTime.Date.ToShortDateString();
                ASPBatNetModel.CV = k.CV;
                ASPBatNetModel.Website = k.website;
                ASPBatNetModel.Kod = k.kodovi_id;

                List<string> kontakti_id = new List<string>();
                List<string> tehnologije_id = new List<string>();
                List<string> notifikacije_id = new List<string>();
                List<string> poruke_id = new List<string>();
                List<string> projekti_id = new List<string>();

                if(k.kontakti_id != null)
                    kontakti_id = k.kontakti_id.Split(',').ToList();
                if(k.tehnologije_id != null)
                    tehnologije_id = k.tehnologije_id.Split(',').ToList();
                if(k.notifikacije_id != null)
                    notifikacije_id = k.notifikacije_id.Split(',').ToList();
                if(k.poruke_id != null)
                    poruke_id = k.poruke_id.Split(',').ToList();
                if(k.projekti_id != null)
                    projekti_id = k.projekti_id.Split(',').ToList();

                ASPBatNetModel.Kontakti= new List<Korisnici>();
                foreach (string idKontakta in kontakti_id)
                    ASPBatNetModel.Kontakti.Add(tabelaKorisnika.Find(x => x.id == idKontakta));

                ASPBatNetModel.ListaTehnologija = new List<Tehnologije>();
                foreach (string idTehnologije in tehnologije_id)
                    ASPBatNetModel.ListaTehnologija.Add(tabelaTehnologija.Find(x => x.id == idTehnologije));

                ASPBatNetModel.ListaNotifikacija = new List<Notifikacije>();
                foreach (string idNotifikacije in notifikacije_id)
                    ASPBatNetModel.ListaTehnologija.Add(tabelaTehnologija.Find(x => x.id == idNotifikacije));

                ASPBatNetModel.ListaPoruka = new List<Poruke>();
                foreach (string idPoruke in poruke_id)
                    ASPBatNetModel.ListaTehnologija.Add(tabelaTehnologija.Find(x => x.id == idPoruke));

                ASPBatNetModel.ListaProjekata = new List<Projekti>();
                foreach (string idProjekta in projekti_id)
                    ASPBatNetModel.ListaProjekata.Add(tabelaProjekata.Find(x => x.id == idProjekta));

                ASPBatNetModel.Quote = "Put your quote here";
                ASPBatNetModel.Image = "https://www.vccircle.com/wp-content/uploads/2017/03/default-profile.png";
                ASPBatNetModel.Visibility = new List<string>();

                for (int i = 0; i < 6; i++)
                    ASPBatNetModel.Visibility.Add("hidden");

                /*for (int i = 0; i < ASPBatNetModel.ListaProjekata.Count; i++)
                    ASPBatNetModel.Visibility[i] = "visible";*/

                Projekti dummyProjekat = new Projekti();
                dummyProjekat.naslov = "";
                for (int i = ASPBatNetModel.ListaProjekata.Count; i < 5; i++)
                    ASPBatNetModel.ListaProjekata.Add(dummyProjekat);
                //Response.Redirect("Home/Index");

                FormsAuthentication.RedirectFromLoginPage
                   (UserName.Text, Persist.Checked);
            }
        }
        Msg.Text = "Invalid credentials. Please try again.";
    }
</script>

<html>
<head id="Head1" runat="server">
  <title>Prijava na BatNet</title>
  <link rel="stylesheet" href="Content/Site.css" type="text/css" />
    <link rel="stylesheet" href="Content/bootstrap.css" type="text/css" />
</head>
<body class="container">
    <h1 id="greetingMessage">Dobrodošli na BatNet!</h1>
    <form id="form1" runat="server" style="width:30vh; margin-left:40vh; margin-top:10vh;">
        <table style="text-align:center; vertical-align: central;">
            <tr>
                <td style="left:-20px;">
                    <asp:TextBox placeholder="Username" ID="UserName" runat="server" CssClass="input-lg" Width="200"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    ControlToValidate="UserName"
                    Display="Dynamic" 
                    ErrorMessage="Ne može biti prazno." 
                    runat="server"
                    ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td>
                    <span style="visibility:hidden">AAAAAA</span>
                    <asp:TextBox placeholder="Password" ID="UserPass" TextMode="Password" runat="server" CssClass="input-lg" Width="200"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    ControlToValidate="UserPass"
                    Display="Dynamic" 
                    ErrorMessage="Ne može biti prazno." 
                    runat="server"
                    ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td>
                    <span style="visibility:hidden">AAAAAA</span>
                    <span style="font-family: Verdana; color: #fff; text-shadow: 1px 0 0 #000, 0 -1px 0 #000, 0 1px 0 #000, -1px 0 0 #000;">Zapamti podatke?</span>
                    <asp:CheckBox ID="Persist" runat="server" />
                </td>
            </tr>
            <tr><td><span style="visibility:hidden">AAA</span></td></tr>
            <tr>
                <td>
                    <span style="visibility:hidden">AAAAA</span>
                    <asp:Button ID="Submit1" OnClick="Logon_Click" Text="Prijavi se" 
                    runat="server" CssClass="btn btn-info" />
                </td>
            </tr>
        </table>
        

        
        <div>
            
        </div>
                
        
        <asp:Label ID="Msg" ForeColor="red" runat="server" />
    </form>  
</body>
</html>