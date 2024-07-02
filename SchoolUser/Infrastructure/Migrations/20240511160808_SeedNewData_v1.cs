using System.Security.Cryptography;
using System.Text;
using SchoolUser.Domain.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class SeedNewData_v1 : Migration
    {
        private readonly string _pepper = "PasswordHashSaltPepperIterationForSchoolManagementSystemPortal";
        private readonly int _iteration = 3;
        private readonly int _otpLength = 6;
        private readonly int _passwordLength = 8;

        #region Batch
        Guid Batch1 = new Guid("2d1e3e91-ce0e-4e51-9c49-6c39ff4d9c16");
        Guid Batch2 = new Guid("44e8d76a-ca78-4ab0-94a7-830d7cd37256");
        Guid Batch3 = new Guid("4ed1ebdb-bee1-46c8-8da3-e620c4bf12d7");
        Guid Batch4 = new Guid("debf4cb9-af2a-46b6-9ea5-4681486b532a");
        Guid Batch5 = new Guid("9be8c650-13ed-43b7-8f70-f0d8c52bb7b9");
        Guid Batch6 = new Guid("f1efb34e-0a51-42e7-8c15-02ad452f555d");
        #endregion

        #region ClassStream
        Guid ClassStream1 = new Guid("f7ba57b4-dd52-4a4c-b6f8-45125c364502");
        Guid ClassStream2 = new Guid("909361dd-7700-4e2e-b9da-0d4235a909e8");
        #endregion

        #region ClassCategory
        Guid ClassCategory1 = new Guid("fa10aa19-4115-4acb-8a1b-1ab101feb4a9");
        Guid ClassCategory2 = new Guid("1708a954-8b95-40d6-9bbd-2f75ff77ebd9");
        Guid ClassCategory3 = new Guid("26b0bb7c-403f-44d7-83c5-48bd7b5d30ca");
        Guid ClassCategory4 = new Guid("7fc667be-fafe-4bba-9329-70d1aaab29dc");
        Guid ClassCategory5 = new Guid("d8625dd1-4b9c-451d-90da-7f620bf3e7b6");
        Guid ClassCategory6 = new Guid("ff051f38-7213-4d32-be48-c0a16c17c635");
        Guid ClassCategory7 = new Guid("4ed1ebdb-bee1-46c8-8da3-e620c4bf12d7");
        Guid ClassCategory8 = new Guid("debf4cb9-af2a-46b6-9ea5-4681486b532a");
        Guid ClassCategory9 = new Guid("9be8c650-13ed-43b7-8f70-f0d8c52bb7b9");
        Guid ClassCategory10 = new Guid("f1efb34e-0a51-42e7-8c15-02ad452f555d");
        Guid ClassCategory11 = new Guid("60de5489-7819-48c2-98c3-e24443027908");
        Guid ClassCategory12 = new Guid("44f85452-1f5a-48b9-b918-b9ce5e524f92");
        #endregion

        #region Subject
        Guid Subject1 = new Guid("f9830b30-c761-4c42-825c-74fdd3df65ab");
        Guid Subject2 = new Guid("6c6d6faf-ca7c-47bb-8116-df67a78b9a1a");
        Guid Subject3 = new Guid("f7286e2b-d1e0-4a86-ad6b-62c2fdd53c18");
        Guid Subject4 = new Guid("dc3916d8-de66-4980-add7-bd17c3515c44");
        Guid Subject5 = new Guid("5ee55784-143c-41c7-9888-644a2c90979c");
        Guid Subject6 = new Guid("9fa34eb8-bc77-4b89-8abc-482f881683f0");
        Guid Subject7 = new Guid("03102356-c6e9-4259-9969-bd8b4835b28b");
        Guid Subject8 = new Guid("2cf81e7b-c1ea-43b0-b9af-149f628a7003");
        #endregion

        #region ClassSubject
        Guid ClassSubject1 = new Guid("4c6fe73b-8e2e-4a4e-8645-25a7fc85db63");
        Guid ClassSubject2 = new Guid("b08901ad-51d8-48ae-b2d5-e65c7eece0ae");
        Guid ClassSubject3 = new Guid("f20e400f-e05a-418f-b08d-4663b2ba0e22");
        Guid ClassSubject4 = new Guid("3d55eb70-aeec-4aae-9aaa-3c4d568a6d30");
        Guid ClassSubject5 = new Guid("a0c43464-473e-4db7-a61b-a8aaf036aafe");
        Guid ClassSubject6 = new Guid("c0d25057-649e-41ec-bb70-b57da2cfab2b");
        Guid ClassSubject7 = new Guid("daa9a15a-f07f-4df2-9151-4a4de7110cb3");
        Guid ClassSubject8 = new Guid("a77bb839-07bc-47ba-b28b-e41fa355a35b");
        Guid ClassSubject9 = new Guid("686cf848-8cda-4791-85f7-43e25fb7db5c");
        Guid ClassSubject10 = new Guid("17cb3e61-7593-4a52-81ec-4b5db0d0489e");
        Guid ClassSubject11 = new Guid("bc8a83f2-18f7-44ad-ac60-cfe4ad601fdf");
        Guid ClassSubject12 = new Guid("f82b3dd9-3439-4d65-a000-10dd2128119c");
        Guid ClassSubject13 = new Guid("c8aefee3-2ce0-4d30-9278-214dbc2dbb17");
        Guid ClassSubject14 = new Guid("5c27a09c-3a37-421e-a0ce-b202444e1ce2");
        Guid ClassSubject15 = new Guid("ef57ba16-74a6-41a8-9066-193a91e9e34b");
        Guid ClassSubject16 = new Guid("bcf2b1ea-77ca-4159-b4b9-da052a285b0a");
        Guid ClassSubject17 = new Guid("74b1463d-8c0f-489b-b3bd-b551ee7341aa");
        Guid ClassSubject18 = new Guid("d9450901-d7bc-4cd3-b22c-80ea45717269");
        Guid ClassSubject19 = new Guid("48fde1ff-9b08-47d8-ae7b-635be6f0baef");
        Guid ClassSubject20 = new Guid("60e3c648-d922-413c-b82d-c6d6adde68a8");
        Guid ClassSubject21 = new Guid("15940a61-05bd-4aae-bdae-7b84776ddb9d");
        Guid ClassSubject22 = new Guid("fbb2a2a4-7b80-4f55-aff3-d2f6aeee8357");
        Guid ClassSubject23 = new Guid("907dddc1-f73b-43b2-92b2-66dd9a568c0f");
        Guid ClassSubject24 = new Guid("30bd9a53-d023-4bd1-9a40-496c7c53ffe8");
        Guid ClassSubject25 = new Guid("9bf39ddc-8e11-4424-8059-bbd2bfac9f27");
        Guid ClassSubject26 = new Guid("e85e931f-4f8a-470d-97e7-165fb016fa46");
        Guid ClassSubject27 = new Guid("a3b2767f-4549-45da-bc14-73841f9adebe");
        Guid ClassSubject28 = new Guid("e8c5516b-327b-44f2-95a7-89841b972afe");
        Guid ClassSubject29 = new Guid("829c3596-46a7-44e7-b656-546760543111");
        Guid ClassSubject30 = new Guid("e7ad8e52-02f8-4e0e-a93a-76c85434b931");
        Guid ClassSubject31 = new Guid("9a81a387-51f1-4cb3-a7da-5b7d4e4f2af4");
        Guid ClassSubject32 = new Guid("ffb6e551-a54b-4a89-9b89-00659e711f2e");
        Guid ClassSubject33 = new Guid("3e6e883c-ff6c-4b27-ae1f-6ff00b2ff0e3");
        Guid ClassSubject34 = new Guid("a10238c0-690f-4c51-aaaa-b4fc5c6a18fc");
        Guid ClassSubject35 = new Guid("4c76b425-dd0a-497b-b03c-4989458fa326");
        Guid ClassSubject36 = new Guid("2b6469fc-913e-4000-b51f-4d859d30e76f");
        Guid ClassSubject37 = new Guid("5b5f515f-8990-495d-b948-a4013494c365");
        Guid ClassSubject38 = new Guid("2426db38-658d-403f-8563-c83a07fded38");
        Guid ClassSubject39 = new Guid("ae08ca5f-b8c4-4aaa-b727-6080ac27122e");
        Guid ClassSubject40 = new Guid("63de929f-7148-4b46-ab1e-bbfac30a570f");
        Guid ClassSubject41 = new Guid("47e472bc-07c4-4350-b46c-839ebd7555d8");
        Guid ClassSubject42 = new Guid("4e80a7f7-d5a8-4fb2-a90e-cc53d6cc8d70");
        Guid ClassSubject43 = new Guid("c2620ffd-9aa0-4f8e-b5ed-1d4500d26212");
        Guid ClassSubject44 = new Guid("bac7468d-cf42-44f3-9291-da89bbc176fc");
        Guid ClassSubject45 = new Guid("5a1edab5-0341-4332-9580-9838d7d08b8b");
        Guid ClassSubject46 = new Guid("5672066b-b3d2-4360-8032-9f0b843bf9ca");
        Guid ClassSubject47 = new Guid("37e13020-b0f8-4172-8f56-8a000c27220b");
        Guid ClassSubject48 = new Guid("85cd8459-ffe4-4ac1-bde1-5de59aaf59e5");
        #endregion

        #region  User

        Guid User1 = new Guid("81e4ceaf-db33-4cd3-87be-98a517bf6c0d");
        Guid User2 = new Guid("fd8c63b6-df12-43e1-8725-76d340e7a7de");
        Guid User3 = new Guid("e62d228d-cefb-4952-bf99-c7268853a9eb");
        Guid User4 = new Guid("92f9ce90-31d1-4b87-929d-dbb15a4edced");
        Guid User5 = new Guid("f22404fe-bdce-4caf-a0e8-960a953bb910");
        Guid User6 = new Guid("4654e7f0-9439-40b5-92fe-2ba8e1b7baef");
        Guid User7 = new Guid("a2a97080-a62f-4540-9e90-f3c88da1c520");
        Guid User8 = new Guid("086b3a50-4e37-4577-b71f-2ae519eabd79");
        Guid User9 = new Guid("8669a13b-9b03-45af-9a31-f2fbb5ab528f");
        Guid User10 = new Guid("fa5e0082-378b-43f3-86a0-c91ced6d3fd4");
        Guid User11 = new Guid("7f6687c7-9750-4cd0-8156-c636ed0e389d");
        Guid User12 = new Guid("3c79efc9-4fd8-42d0-a75b-1f7548b6b675");
        Guid User13 = new Guid("8a539656-321e-41ff-bcc0-16509ac3ee8f");
        Guid User14 = new Guid("6ea434c9-dd8d-4b37-bd5f-aa49b2804178");
        Guid User15 = new Guid("74b6e938-7933-45b7-b90f-fa52c37407a7");
        Guid User16 = new Guid("3b040984-06ef-45a3-b8f1-54ff819f24e7");

        Guid User17 = new Guid("d9a16622-b1f7-4cbc-85ad-93a8300f6911");
        Guid User18 = new Guid("55af6aeb-d60e-499d-8633-9591b08053be");
        Guid User19 = new Guid("3f29c5a4-2a4d-46e0-a299-19c05bf67ff1");
        Guid User20 = new Guid("0d507b0d-670c-49a2-bdbe-91937c3c87d2");
        Guid User21 = new Guid("ed66f081-9e18-4b67-b632-000f731e93b8");
        Guid User22 = new Guid("08d5a73d-83ea-48cc-b0d0-8896781c2686");
        Guid User23 = new Guid("a7cafdaa-0684-494f-a0a4-eb90e2eb5d29");
        Guid User24 = new Guid("685e1a22-361e-47c1-8283-6a0df8473849");
        Guid User25 = new Guid("7ea1daec-f604-472e-8715-9dbe7b8b7b92");
        Guid User26 = new Guid("a8900ccc-2108-4d28-bcbd-f59ad6fc5d52");
        Guid User27 = new Guid("d3ea24db-491d-4d50-9683-efc258ba933a");
        Guid User28 = new Guid("70c975b3-9cd6-4e04-b3e5-2f410ef262e2");
        Guid User29 = new Guid("f80da198-9c20-43c0-bac3-e2d534b35eb9");
        Guid User30 = new Guid("931ef490-5c37-46ed-81fc-948b18fbb599");
        Guid User31 = new Guid("2b583d4f-a93b-4645-9c7f-e35fdab3ec7b");
        Guid User32 = new Guid("8391c7f0-4e42-4a31-88d8-6066a285afd6");
        Guid User33 = new Guid("715f06af-554c-4baf-ae1a-4162307286d4");
        Guid User34 = new Guid("07089403-a7e2-4f07-a2b5-2868f428657b");
        Guid User35 = new Guid("ee915f90-5426-480d-8ba8-b4fecf9a8bf6");
        Guid User36 = new Guid("1b9607bb-501a-4b0d-a510-ee9abc48cfb4");
        Guid User37 = new Guid("4963c433-995e-48ed-9d64-100e7bc278e9");
        Guid User38 = new Guid("de763ddc-4a61-432e-8fcc-0f580c3747ed");
        Guid User39 = new Guid("6833d54f-9975-453b-b145-f7d07252d446");
        Guid User40 = new Guid("86b50de6-5299-4b18-b02e-3b0ca10430ea");
        Guid User41 = new Guid("626db38b-c271-45bd-907b-e6087e2b6bd3");
        Guid User42 = new Guid("ac130868-a3c9-49e7-9031-fea7a9bda9db");
        Guid User43 = new Guid("b7291576-52ff-4732-8f49-57e73e82a3c3");
        Guid User44 = new Guid("189dacdc-70f8-47db-b309-63cc452caa08");
        Guid User45 = new Guid("489aa053-8c3f-4867-947b-d09c0ab6eedc");
        Guid User46 = new Guid("4c59f5fe-af77-4e0e-b48b-5e646340a4d7");
        Guid User47 = new Guid("1078e598-6dda-42fe-a068-7023a267e349");
        Guid User48 = new Guid("95546d18-8c91-42e1-aefd-a193a229ac09");
        Guid User49 = new Guid("9355b508-33e1-40fc-9f8e-009fa14d853e");
        Guid User50 = new Guid("343b5c87-4254-4345-b6d0-1ef769febc96");
        Guid User51 = new Guid("b55255e0-629e-4ef1-90a4-d7cc47044003");
        Guid User52 = new Guid("2c3724b7-a51d-4d49-ae03-a21706dc5324");
        Guid User53 = new Guid("2bd2160e-3f00-4601-9b39-ec853b0b7a12");
        Guid User54 = new Guid("dd3b79e0-d6a3-43c4-a4e3-e1a1e8fcb400");
        Guid User55 = new Guid("5a94126f-ef02-4053-81a7-8dbdfc0f0f82");
        Guid User56 = new Guid("013f77c0-7b4a-4313-b120-629339f8b854");
        Guid User57 = new Guid("95ceb9bc-4d64-4708-93ca-26b0a07423d8");
        Guid User58 = new Guid("6f5087bc-7ac8-427f-bbff-f44146bab444");
        Guid User59 = new Guid("660b8374-24d7-4a4a-a1af-73c3f8e96613");
        Guid User60 = new Guid("91c8d694-32f3-4fc5-9a1a-d6bb1eb451ce");
        Guid User61 = new Guid("94be8c6c-de1e-43ab-ae60-9fa66941f878");
        Guid User62 = new Guid("9aa87a26-f1d4-4beb-9ee6-4b109d3c6cfd");
        Guid User63 = new Guid("b43b4968-33a7-4ed4-9f2f-bfe5b65a7f25");
        Guid User64 = new Guid("01c4604c-4576-4302-b5e8-d60d0269a7df");
        Guid User65 = new Guid("8cf5497d-0e24-4730-8f68-4085aa87817c");
        Guid User66 = new Guid("646a8b94-e517-4a40-be28-b2f83dca3c51");
        Guid User67 = new Guid("60358324-75ea-45ad-8a85-3247a22b3c35");
        Guid User68 = new Guid("b5b3bc2b-a3ec-4ef9-a24f-a2005aee2228");
        Guid User69 = new Guid("5710ec8e-c08e-4dbf-952c-26ae541dc447");
        Guid User70 = new Guid("cf853711-122e-440d-8263-8a532b78afbc");
        Guid User71 = new Guid("e5e04b25-8369-4042-bef1-8cc175747e06");
        Guid User72 = new Guid("2642a9a7-1a60-4ffc-9a40-0615d0941ddd");
        Guid User73 = new Guid("f6de783a-9ca8-43a8-918c-e95fe94eac69");
        Guid User74 = new Guid("56ad99a0-6492-452e-b6f8-bb5e9303774d");
        Guid User75 = new Guid("c101408b-f7d4-40a6-be9f-273fb8b81329");
        Guid User76 = new Guid("bbf93bab-9847-4b6d-8fb8-d19cfc14001b");
        #endregion

        #region Teacher
        Guid Teacher1 = new Guid("09458a6c-d313-4bee-b66f-19c0ff543c44");
        Guid Teacher2 = new Guid("0218e6c6-9b1c-44c3-9ac2-95b2fda929f7");
        Guid Teacher3 = new Guid("77a14da8-1caa-4ad0-9cd3-4208cfc3ac66");
        Guid Teacher4 = new Guid("39b703bc-9cc0-4974-be21-cf4327e9f6b4");
        Guid Teacher5 = new Guid("953785b4-12d2-4ca0-a65e-70230c5880c5");
        Guid Teacher6 = new Guid("8bc1831c-1c7f-4a43-a04b-3aae0a7bfe7d");
        Guid Teacher7 = new Guid("5d6e3425-d473-47e0-b20d-6ac256c1baa9");
        Guid Teacher8 = new Guid("8b1f6bae-fe3e-4cca-9bfa-6ff4856bf790");
        Guid Teacher9 = new Guid("d455d687-5783-490c-abf3-92ea550fb2f6");
        Guid Teacher10 = new Guid("a5649831-2968-4985-a3d2-08025ec365a6");
        Guid Teacher11 = new Guid("62d4224a-f21d-4adc-9826-e12ed32af95e");
        Guid Teacher12 = new Guid("29861f16-863d-415d-9965-8f0ac0dbb0d7");
        Guid Teacher13 = new Guid("6c96331c-aa01-47e6-9aa7-9ebe3d23a527");
        Guid Teacher14 = new Guid("70b43a46-90a4-4154-a977-9de8cb3d6464");
        Guid Teacher15 = new Guid("507b51fa-905f-4d00-a6df-f1c68608c3a4");
        Guid Teacher16 = new Guid("148b8e31-7684-4974-bde4-744c9171f606");
        #endregion

        #region Student
        Guid Student1 = new Guid("aca69ac4-2bd2-4d9b-b84f-56a0793d9f40");
        Guid Student2 = new Guid("7f588c68-3fa5-4fbf-b9af-a21f1656c957");
        Guid Student3 = new Guid("6e1ec7d1-8311-410d-850a-9cbdaf598728");
        Guid Student4 = new Guid("692c94cf-fb77-43a8-a0ff-734770cf5078");
        Guid Student5 = new Guid("5162685a-869f-49d5-8d8a-6956f032344d");
        Guid Student6 = new Guid("7bf293b0-b5b6-4538-b0dc-80479d473c3e");
        Guid Student7 = new Guid("46b55249-3dba-4ca7-8786-75c12bc9a5c9");
        Guid Student8 = new Guid("077875b7-5198-41e1-b3b7-d3345b8c82f2");
        Guid Student9 = new Guid("23ee9929-0324-47b1-979e-cb8a334bd8c9");
        Guid Student10 = new Guid("984af5e6-48b8-4396-a2a3-ec4ae7015062");
        Guid Student11 = new Guid("b6a95766-3422-4ede-920a-eee089028323");
        Guid Student12 = new Guid("e97266a3-c160-448e-a1b9-985bef7385dd");
        Guid Student13 = new Guid("500a3272-daf2-41a0-afe1-06e50bb7dbb2");
        Guid Student14 = new Guid("67da72fb-74fc-4dcc-b817-feee349eb68a");
        Guid Student15 = new Guid("19d39def-272a-4cc3-bbc0-b62b95b504c4");
        Guid Student16 = new Guid("00fab99e-3c20-4b31-b52d-ab3dce9087d5");
        Guid Student17 = new Guid("b8461da6-29cf-40f8-aef7-41fb547b180f");
        Guid Student18 = new Guid("89d27a99-96ce-4798-96c9-8b3693b4396d");
        Guid Student19 = new Guid("21504568-db0b-4585-8571-61fb45e7a591");
        Guid Student20 = new Guid("8b57255a-25fa-4271-ac00-b113b3f5a075");
        Guid Student21 = new Guid("01c21eae-856c-44cc-a70c-4e45c17e4e9c");
        Guid Student22 = new Guid("a3c8e25b-b512-434b-8fa3-0e66ffa41c2c");
        Guid Student23 = new Guid("fe003217-07db-4f75-8cb5-1502a080eed4");
        Guid Student24 = new Guid("a38bf59f-bea4-454f-8467-2b253087c319");
        Guid Student25 = new Guid("b756d61f-eac9-4fbd-bfd0-256e86b803b6");
        Guid Student26 = new Guid("8144c05d-0eee-4135-97c0-a67271de0379");
        Guid Student27 = new Guid("a841a47c-7a8f-4d57-9323-f2e88a3801bc");
        Guid Student28 = new Guid("4098aebd-284e-4d6d-b321-c773eb564a06");
        Guid Student29 = new Guid("ba2113ba-15d1-4f60-bd05-76e53606204b");
        Guid Student30 = new Guid("3d8b6dd9-d316-4c0c-a162-43d4e7d37f87");
        Guid Student31 = new Guid("a36998d9-2d64-403d-8010-f85a1e223234");
        Guid Student32 = new Guid("7edbb423-f7d8-42ea-9457-e161b73e2bb7");
        Guid Student33 = new Guid("67351ad7-7cbf-4bfa-b786-f0ee9039b9f8");
        Guid Student34 = new Guid("b613f2bd-af52-43a3-9b92-da5f88d53481");
        Guid Student35 = new Guid("f6526308-8de0-4f68-bca3-84e4fc72a1b6");
        Guid Student36 = new Guid("5c9b57aa-3fd1-4eda-8707-289dee52ce74");
        Guid Student37 = new Guid("178e6f7c-a8e0-4f81-9c4e-5d6f565082e3");
        Guid Student38 = new Guid("67e57dd9-0a7b-41c0-bf18-d75247ec3e9e");
        Guid Student39 = new Guid("53bbdbb2-a8f9-4277-bde5-8fe312def5df");
        Guid Student40 = new Guid("3616fb89-0ce7-4959-a9d7-13aea5f0b6b4");
        Guid Student41 = new Guid("7026fdf8-9a5c-41db-a206-90181ac2d0fa");
        Guid Student42 = new Guid("afb29af0-d2af-4c26-9fde-2f603c785fdb");
        Guid Student43 = new Guid("7479d023-f07f-4439-bd10-f8e0a580b030");
        Guid Student44 = new Guid("fd873b40-10a4-40bb-9a0f-1fbdc6e7c9be");
        Guid Student45 = new Guid("2b55b5ce-b5dd-4f98-8a7e-f81eed04ea58");
        Guid Student46 = new Guid("bbbb868c-5041-43ce-a83a-6d098531aeb9");
        Guid Student47 = new Guid("ce00edbb-2403-41f5-b4d1-05c374421381");
        Guid Student48 = new Guid("1c53824a-5263-4b56-a114-520090f99378");
        Guid Student49 = new Guid("7ae99302-dfc6-49b9-b4bd-17960ea77d83");
        Guid Student50 = new Guid("43c6ecce-a7ad-4477-8a91-8bd45b2f55b2");
        Guid Student51 = new Guid("59e69c5a-0fef-445d-bb43-f29a024a2c3b");
        Guid Student52 = new Guid("255fc014-878d-4cac-abd0-8947be6bb8ec");
        Guid Student53 = new Guid("5f690c82-1771-4931-be84-0833d67b9a35");
        Guid Student54 = new Guid("c15fb460-efa6-4582-af21-a1651fd6d14f");
        Guid Student55 = new Guid("39daaf9f-d650-456d-97e1-8fe5186059eb");
        Guid Student56 = new Guid("796ae0df-8485-41cd-b3cf-431f1fc138b4");
        Guid Student57 = new Guid("eb2f86c7-e5d3-4919-bf3b-0ec90faca990");
        Guid Student58 = new Guid("a7521676-f3a8-47cb-acef-d67df115d281");
        Guid Student59 = new Guid("ec8265e8-c976-441f-a648-e90738eb334b");
        Guid Student60 = new Guid("41968e63-3e0c-45f6-9b33-8c2943b6209f");
        #endregion

        #region ClassSubjectTeacher
        Guid ClassSubjectTeacher1 = new Guid("02ec2945-02cb-4d42-9ad3-bfd8323610eb");
        Guid ClassSubjectTeacher2 = new Guid("90ecb98c-b64e-413f-9dab-386a365820b4");
        Guid ClassSubjectTeacher3 = new Guid("c03d98ef-fc52-4faa-a893-0e0b4c8ca6ff");
        Guid ClassSubjectTeacher4 = new Guid("c4eabd57-1892-40b9-8b2f-7dc28fe71133");
        Guid ClassSubjectTeacher5 = new Guid("1e594a38-bf4e-4b53-a268-5d35e67b04d8");
        Guid ClassSubjectTeacher6 = new Guid("a2fba04e-bd3f-4957-8a14-b272469741b6");
        Guid ClassSubjectTeacher7 = new Guid("197fdf02-07c8-40b1-ab43-c865c8120d7d");
        Guid ClassSubjectTeacher8 = new Guid("bad12310-f3e8-48a1-a2fe-99e12837e06f");
        Guid ClassSubjectTeacher9 = new Guid("115c8805-3c3d-416e-8208-02b9ac9ace7f");
        Guid ClassSubjectTeacher10 = new Guid("bd8b795e-7704-4276-aaee-7751fe2b8493");
        Guid ClassSubjectTeacher11 = new Guid("3d44861b-7d48-458e-9fd8-42f503b2f652");
        Guid ClassSubjectTeacher12 = new Guid("3cc80845-adde-4f46-b614-7285bc7b8ec9");
        Guid ClassSubjectTeacher13 = new Guid("a9bee6cf-a969-4a4d-a6e9-959fc39f1b6d");
        Guid ClassSubjectTeacher14 = new Guid("d89b1ffe-48f9-4572-83f7-8302d0b47080");
        Guid ClassSubjectTeacher15 = new Guid("cb516a7b-a2da-458e-b374-128b84df3189");
        Guid ClassSubjectTeacher16 = new Guid("f6fa124f-d90c-41f1-aa9a-94d3faddc33e");
        Guid ClassSubjectTeacher17 = new Guid("9b77e0a7-17f4-4aac-8461-736533b78a99");
        Guid ClassSubjectTeacher18 = new Guid("d44df945-7057-42a6-a2d3-e0f3b2df0f64");
        Guid ClassSubjectTeacher19 = new Guid("78d1b9be-1ae8-4995-b54a-b50ffe738d2f");
        Guid ClassSubjectTeacher20 = new Guid("2aebd936-7aba-4a0d-a539-85ebf5ba7219");
        Guid ClassSubjectTeacher21 = new Guid("e66614f4-707f-4c52-838d-a7a13fd66998");
        Guid ClassSubjectTeacher22 = new Guid("0347e8dc-bf52-4dfd-99a0-025ef4c72672");
        Guid ClassSubjectTeacher23 = new Guid("9200eebe-520e-486f-b355-d5f354f2e488");
        Guid ClassSubjectTeacher24 = new Guid("ce524cbd-6d0f-493d-9336-0bf02f4a2795");
        Guid ClassSubjectTeacher25 = new Guid("34025e73-b8f1-42cd-b616-dece764205a7");
        Guid ClassSubjectTeacher26 = new Guid("a0a717c5-a34c-4561-b42c-f10dfa5018ef");
        Guid ClassSubjectTeacher27 = new Guid("eaef3a6a-7bbe-410d-a790-589cdd59e026");
        Guid ClassSubjectTeacher28 = new Guid("3fb4d32a-dafb-4b7c-b19e-28c06119efa3");
        Guid ClassSubjectTeacher29 = new Guid("c213d14f-7c33-4a42-b590-22e7193ba152");
        Guid ClassSubjectTeacher30 = new Guid("fa39fb51-1323-4b81-8d6f-70cb147c8007");
        Guid ClassSubjectTeacher31 = new Guid("5e12b0be-d44e-462b-93d7-787152f1c964");
        Guid ClassSubjectTeacher32 = new Guid("02caedea-6864-4ef0-8cd2-8edd205da85b");
        Guid ClassSubjectTeacher33 = new Guid("7c3d178a-79ff-4c24-8527-d824a0f084e0");
        Guid ClassSubjectTeacher34 = new Guid("cffbb547-f44c-4a6f-9675-23e873387ea7");
        Guid ClassSubjectTeacher35 = new Guid("bb35d63f-689e-416a-b95b-cf1f7f23013c");
        Guid ClassSubjectTeacher36 = new Guid("13c3d1e6-19a7-4b14-ba3e-3e229253451e");
        Guid ClassSubjectTeacher37 = new Guid("1efb8e2c-634b-4314-ad51-33cca1689511");
        Guid ClassSubjectTeacher38 = new Guid("8bf59a5b-79dc-4832-acf5-f6c9eb94a9c5");
        Guid ClassSubjectTeacher39 = new Guid("c1bc6d3e-e59a-4be5-a4ef-fd5b5a0e1dcd");
        Guid ClassSubjectTeacher40 = new Guid("8c1ee445-aefd-41f5-be11-f2f3bbfdceb5");
        Guid ClassSubjectTeacher41 = new Guid("962c016d-d509-4a1c-8b3b-4581b14cbb37");
        Guid ClassSubjectTeacher42 = new Guid("55211c81-51f5-4493-ad71-e4d437b838d1");
        Guid ClassSubjectTeacher43 = new Guid("e805a3fb-9577-4c44-8dce-76f0304feda5");
        Guid ClassSubjectTeacher44 = new Guid("864d4bfb-bf21-4e62-8097-8daf9b9beb99");
        Guid ClassSubjectTeacher45 = new Guid("a86fc271-1ca2-4144-b79d-67d8fbf5051c");
        Guid ClassSubjectTeacher46 = new Guid("c6f46afe-c62d-4c93-bea8-b5f95b691f0b");
        Guid ClassSubjectTeacher47 = new Guid("6ddbe791-5add-411e-9b46-0aac3dfd8109");
        Guid ClassSubjectTeacher48 = new Guid("af036f48-9af5-45b7-a274-49e608525480");
        #endregion

        #region ClassSubjectStudent

        Guid ClassSubjectStudent1 = new Guid("a2f59575-4e37-48d3-81b6-261dddb51415");
        Guid ClassSubjectStudent2 = new Guid("9b9543fd-ca79-4d88-b853-247242ca8bac");
        Guid ClassSubjectStudent3 = new Guid("389a780e-3712-45df-89c8-55d930c90463");
        Guid ClassSubjectStudent4 = new Guid("526fee77-f553-4748-8ebd-5672ae401be2");
        Guid ClassSubjectStudent5 = new Guid("368e4d7b-5ba7-409c-8579-bbc32b48d668");
        Guid ClassSubjectStudent6 = new Guid("d98e8a85-3192-48e4-ba56-3e79537d9355");
        Guid ClassSubjectStudent7 = new Guid("a102912e-8a02-48b7-815b-a69b09006360");
        Guid ClassSubjectStudent8 = new Guid("540a46ee-f7b1-4595-8e9d-e6802bbb7d0d");
        Guid ClassSubjectStudent9 = new Guid("1f00b88d-97f3-4802-8e69-9f7ff23baace");
        Guid ClassSubjectStudent10 = new Guid("0a11f0dd-c8d8-4300-ab05-669f2361d877");
        Guid ClassSubjectStudent11 = new Guid("ebf42dfe-0f05-41e7-b48b-92c8b7d99d7d");
        Guid ClassSubjectStudent12 = new Guid("e717d524-d12b-4683-a9c5-0164576c37eb");
        Guid ClassSubjectStudent13 = new Guid("58ad4284-67dd-4b24-ac1b-2eab45f31393");
        Guid ClassSubjectStudent14 = new Guid("9f203c85-5472-439e-a971-3b04f213f99f");
        Guid ClassSubjectStudent15 = new Guid("26cbe11f-ee8d-4bd8-9db1-faa240837337");
        Guid ClassSubjectStudent16 = new Guid("06df1fb9-3c7b-4ef5-af94-e2423c672e87");
        Guid ClassSubjectStudent17 = new Guid("3493e1c2-6126-47d6-8205-01ed795383ad");
        Guid ClassSubjectStudent18 = new Guid("eee4087b-7317-42bd-a55f-54ec7f922679");
        Guid ClassSubjectStudent19 = new Guid("016763b1-fe31-4c2f-be88-6e549b6c178f");
        Guid ClassSubjectStudent20 = new Guid("56dbdc3d-f1ef-4a80-9757-d1d61dbb32ef");
        Guid ClassSubjectStudent21 = new Guid("dcc6549a-4899-4d82-9fd8-bef615a8c39e");
        Guid ClassSubjectStudent22 = new Guid("3fab95c6-9fa4-449b-b1ef-4a4a4d415e23");
        Guid ClassSubjectStudent23 = new Guid("2b0f30d4-55ab-4d07-89b8-23d44d9cc52f");
        Guid ClassSubjectStudent24 = new Guid("99b01c37-2dbb-4677-86b9-d0010ae8c181");
        Guid ClassSubjectStudent25 = new Guid("099186ec-340e-46b6-9bfa-941bf044f820");
        Guid ClassSubjectStudent26 = new Guid("fb68e86e-5758-417a-97fe-e66a327d8a20");
        Guid ClassSubjectStudent27 = new Guid("3536b281-86da-4450-b20e-3764d4377699");
        Guid ClassSubjectStudent28 = new Guid("4a790d1c-b8db-41c6-ab26-a4402e698068");
        Guid ClassSubjectStudent29 = new Guid("6d25a2d7-c0b2-4004-a0d2-045098c654b9");
        Guid ClassSubjectStudent30 = new Guid("2acc1fb4-6354-4cb5-a0fc-aabea0c33dbe");
        Guid ClassSubjectStudent31 = new Guid("96590e93-b3f5-465b-9066-b07d6a929615");
        Guid ClassSubjectStudent32 = new Guid("e84eab9f-ec3c-4ee8-82d3-c642e274213f");
        Guid ClassSubjectStudent33 = new Guid("171aa316-cee8-4174-a65c-6d5dc814856d");
        Guid ClassSubjectStudent34 = new Guid("aa75e9ce-6626-460d-b25a-cd33d616d4f1");
        Guid ClassSubjectStudent35 = new Guid("9519ce84-3211-4bfc-8261-bcdcbed9dc9e");
        Guid ClassSubjectStudent36 = new Guid("a41769b6-f988-4196-b685-5e7720a18f97");
        Guid ClassSubjectStudent37 = new Guid("fcfa0d01-6b4e-431d-a66a-760c2d1e4640");
        Guid ClassSubjectStudent38 = new Guid("62569377-c4a8-43b1-99e4-14225a049a85");
        Guid ClassSubjectStudent39 = new Guid("1bbd69c3-da14-467d-9bc4-2b7b19a3b845");
        Guid ClassSubjectStudent40 = new Guid("0c6ff445-972d-47bf-bd3f-3886ebe3900b");
        Guid ClassSubjectStudent41 = new Guid("b56144e2-2211-496f-87da-8d87ebc4aada");
        Guid ClassSubjectStudent42 = new Guid("1332a19b-06a8-4375-a31d-cb0f1adc071a");
        Guid ClassSubjectStudent43 = new Guid("01e5b760-3aff-450a-8a33-c44d4884805a");
        Guid ClassSubjectStudent44 = new Guid("1bbb0362-ab0d-4a9e-8c6e-ffda9e007d19");
        Guid ClassSubjectStudent45 = new Guid("ed60c2bf-dd14-4d41-b54c-31dd533b2e3a");
        Guid ClassSubjectStudent46 = new Guid("fbb9b414-3d53-476d-83fb-cc955f3558fc");
        Guid ClassSubjectStudent47 = new Guid("57d41ca5-27d6-44b6-ac8b-f350bf5b2215");
        Guid ClassSubjectStudent48 = new Guid("10e585f5-cc9f-4ca7-9b3f-e570e7f186f2");
        Guid ClassSubjectStudent49 = new Guid("d56d129d-4193-44b2-a337-283a0dc06400");
        Guid ClassSubjectStudent50 = new Guid("3b5e7e6f-a965-4db0-9e61-2ce133df2bde");
        Guid ClassSubjectStudent51 = new Guid("992affa3-55e8-4fdc-b30e-821984ecc532");
        Guid ClassSubjectStudent52 = new Guid("b36e26bc-9fb8-470f-840c-d22f9dde229b");
        Guid ClassSubjectStudent53 = new Guid("19a076c4-1efb-419e-bd76-adc95fd37cb2");
        Guid ClassSubjectStudent54 = new Guid("88e3d7a1-9353-4c9c-bba1-140169e80602");
        Guid ClassSubjectStudent55 = new Guid("fe6115fe-60e7-4997-9744-c174e5d650fa");
        Guid ClassSubjectStudent56 = new Guid("1803f80d-a589-47c5-83a2-c9404a4310e1");
        Guid ClassSubjectStudent57 = new Guid("dc61abe8-9127-4576-8dd6-60ab0817b89f");
        Guid ClassSubjectStudent58 = new Guid("1a77d46c-d706-480c-9e3c-1fbbd43d2cd5");
        Guid ClassSubjectStudent59 = new Guid("29e4dfa0-0f6b-400a-b5d1-1af9ccc8de1b");
        Guid ClassSubjectStudent60 = new Guid("10ee7db5-3d01-44a2-aad5-302e06b14a3c");
        Guid ClassSubjectStudent61 = new Guid("a40b789c-bdc0-486b-b9e4-4db93cf39b43");
        Guid ClassSubjectStudent62 = new Guid("571a7733-bd16-4c73-81a5-8b2b48a89c3f");
        Guid ClassSubjectStudent63 = new Guid("f5d70fd2-a7a2-4867-ba9d-5ade5e1c759b");
        Guid ClassSubjectStudent64 = new Guid("b884c1d4-c1ce-47fb-8271-473304ee63c6");
        Guid ClassSubjectStudent65 = new Guid("3540380d-dee4-461f-b1c4-94d0572f0b78");
        Guid ClassSubjectStudent66 = new Guid("71b89643-21fa-47a5-a40d-81b1a6f1038b");
        Guid ClassSubjectStudent67 = new Guid("a041ffc8-bd39-435d-928a-0b3ec033fff2");
        Guid ClassSubjectStudent68 = new Guid("04798c75-751b-4dd2-bc3c-7402c965ac1a");
        Guid ClassSubjectStudent69 = new Guid("2f9939ca-c9c9-4ca9-9dbe-9be473d1bdda");
        Guid ClassSubjectStudent70 = new Guid("c7829b7c-eb46-4303-9595-b94a7d357269");
        Guid ClassSubjectStudent71 = new Guid("4a3cc0c1-f153-4bd0-bac4-9bcf4aef1424");
        Guid ClassSubjectStudent72 = new Guid("7b6ba744-1e0b-456c-a71c-5c8cbb2335a8");
        Guid ClassSubjectStudent73 = new Guid("ddc7364d-626f-4de2-a28e-ddef746935e3");
        Guid ClassSubjectStudent74 = new Guid("8377dfac-d04b-4f8e-ab1c-6ca22eb18520");
        Guid ClassSubjectStudent75 = new Guid("d50f0806-f530-416d-ae2f-17da89b25caa");
        Guid ClassSubjectStudent76 = new Guid("0cb1b3b2-f028-47d0-8985-73546a654599");
        Guid ClassSubjectStudent77 = new Guid("fa51c9ad-8fcf-4127-904e-0f0f0d7b1cab");
        Guid ClassSubjectStudent78 = new Guid("3110cdd0-76d6-4f1d-92a5-6fa141683f12");
        Guid ClassSubjectStudent79 = new Guid("28bed177-d626-46a2-8626-4ab50a6b4201");
        Guid ClassSubjectStudent80 = new Guid("2743d1b6-e475-45fa-a87a-5d05df9faa82");
        Guid ClassSubjectStudent81 = new Guid("6c730bd0-0860-49fa-be98-f44161aabe3b");
        Guid ClassSubjectStudent82 = new Guid("9ba965a2-7afe-4a3e-bb66-d4dfcf05adbc");
        Guid ClassSubjectStudent83 = new Guid("bedf8adf-3ffe-48dd-8faf-8262959eea81");
        Guid ClassSubjectStudent84 = new Guid("e4d5660a-9231-4d4a-80f1-f6e57d4884da");
        Guid ClassSubjectStudent85 = new Guid("90edce61-b096-4b77-a3bc-f155b411ee9e");
        Guid ClassSubjectStudent86 = new Guid("a3681297-272b-4757-9d48-c9f0af1f4324");
        Guid ClassSubjectStudent87 = new Guid("74749268-323c-44ee-8995-980d5c26aa8f");
        Guid ClassSubjectStudent88 = new Guid("ba7c80b4-43e7-4178-80d9-fdbbfafc0593");
        Guid ClassSubjectStudent89 = new Guid("74858ed0-cc91-4076-87aa-a9770eff4259");
        Guid ClassSubjectStudent90 = new Guid("3cb32df4-8829-4aa8-8a63-7a8f7eb5d24b");
        Guid ClassSubjectStudent91 = new Guid("162f0273-2f0e-46d9-86c4-b35d6619fb55");
        Guid ClassSubjectStudent92 = new Guid("fd896362-a273-4a4a-8103-cc69e379168b");
        Guid ClassSubjectStudent93 = new Guid("6642f5be-26b5-458d-85ee-4f4ba1d4dc77");
        Guid ClassSubjectStudent94 = new Guid("e6b15032-6a9c-4b1e-bfdb-8a32e18b733d");
        Guid ClassSubjectStudent95 = new Guid("1d98b213-5472-4ce7-93f4-6cd384dbab9b");
        Guid ClassSubjectStudent96 = new Guid("88791298-78d8-4dc3-a4b8-220325806ba8");
        Guid ClassSubjectStudent97 = new Guid("94ca9719-5577-4892-b29d-065b282bbffd");
        Guid ClassSubjectStudent98 = new Guid("4f354910-a939-452f-9764-7350f2057c83");
        Guid ClassSubjectStudent99 = new Guid("c4900e11-8212-46a1-8c6a-c2a775f9f510");
        Guid ClassSubjectStudent100 = new Guid("fb7db125-313a-4c9a-a083-a0896ad52ea7");
        Guid ClassSubjectStudent101 = new Guid("3d3cdd47-e828-4fd1-bfe0-d1713b040b1f");
        Guid ClassSubjectStudent102 = new Guid("4bb21f54-4733-48b6-aebc-994ef9fb988a");
        Guid ClassSubjectStudent103 = new Guid("3ddaca1f-dceb-4410-a21d-555a1a67591b");
        Guid ClassSubjectStudent104 = new Guid("9429698b-3634-4ab0-8c2c-e42e999e3ae4");
        Guid ClassSubjectStudent105 = new Guid("ad288f02-a3ee-4776-b2b1-3d394976025a");
        Guid ClassSubjectStudent106 = new Guid("e17464aa-8326-4b65-8167-3a00ed3ed75b");
        Guid ClassSubjectStudent107 = new Guid("fe019398-a4fc-436c-809c-3777b160a593");
        Guid ClassSubjectStudent108 = new Guid("c6a56e00-a664-4d57-abf8-6aa7449b69cd");
        Guid ClassSubjectStudent109 = new Guid("528bd666-c3df-47f3-a655-8a553d5e1152");
        Guid ClassSubjectStudent110 = new Guid("428600a5-86ed-4d6d-b464-40cf2304a543");
        Guid ClassSubjectStudent111 = new Guid("37a34646-e6f1-4de0-9fa2-e62cad88b904");
        Guid ClassSubjectStudent112 = new Guid("fee203c2-7699-469d-924e-6259ead7f79f");
        Guid ClassSubjectStudent113 = new Guid("0d6a8bd0-7114-4917-bab0-ac137f8e98cd");
        Guid ClassSubjectStudent114 = new Guid("4fa7e9aa-9412-4ca6-9a52-90b691000457");
        Guid ClassSubjectStudent115 = new Guid("d78b2df2-2586-4c3a-aab0-dddd60424489");
        Guid ClassSubjectStudent116 = new Guid("261817f4-08d8-4c35-99de-d281ac20e1d5");
        Guid ClassSubjectStudent117 = new Guid("94284d7b-980d-4302-ad31-9d0d70a377ef");
        Guid ClassSubjectStudent118 = new Guid("4e988571-33c7-43a6-b5ba-eb5e0b2d5832");
        Guid ClassSubjectStudent119 = new Guid("c6b14a67-b4a1-4c1d-b0ee-69466ee2d1d7");
        Guid ClassSubjectStudent120 = new Guid("aa5aa512-cae9-44f7-9de2-15e25f6c5323");

        #endregion

        #region Role
        Guid teacherRoleId = new Guid("30909974-D5C8-4F98-B12C-2F5D56C84257");
        Guid studentRoleId = new Guid("F704B160-7A18-4B85-A393-7728F72261F5");
        #endregion

        #region UserRole 
        Guid UserRole1 = new Guid("8b9e0c2f-2625-4ed0-9ab2-aebab39ae9ef");
        Guid UserRole2 = new Guid("120b36c3-bc6d-4ce8-9fd7-3e8dfb0e7cf7");
        Guid UserRole3 = new Guid("79a8447c-2689-4cc0-9029-23fa40103389");
        Guid UserRole4 = new Guid("c0299fc6-55e6-4cce-ab1c-c9a8c45bdded");
        Guid UserRole5 = new Guid("e87a7156-d9c9-42e1-99a9-9b08ab981c22");
        Guid UserRole6 = new Guid("be4f501f-ce44-4094-af0f-077f01ff8d2b");
        Guid UserRole7 = new Guid("a767d674-83d0-4714-af81-3223498f8766");
        Guid UserRole8 = new Guid("0776b41f-5589-4741-be2d-7a89b6c544b1");
        Guid UserRole9 = new Guid("9fea8d1f-4cc4-4e88-8ec8-f7d39bfe724f");
        Guid UserRole10 = new Guid("f94e173c-8377-4b41-ac47-e60e2992e9bd");
        Guid UserRole11 = new Guid("109ac284-ab6b-4fb4-aeae-9df59bc082ac");
        Guid UserRole12 = new Guid("08c22550-4a19-477b-8ce9-7e4e4971b5c9");
        Guid UserRole13 = new Guid("66d48e0d-5c8e-4560-8781-932b41fe84b5");
        Guid UserRole14 = new Guid("66194e4d-c2a2-4b97-978d-7f90adfd6354");
        Guid UserRole15 = new Guid("b71c17e6-049b-4471-86f7-c54004fbeebe");
        Guid UserRole16 = new Guid("ca7fe6d6-0723-4fe8-a754-d018386cce04");
        Guid UserRole17 = new Guid("8b4a00fb-57e6-4b8c-aaf5-8251ab444799");
        Guid UserRole18 = new Guid("b3468d39-6a15-4c03-9d20-1cdbbfbd3e26");
        Guid UserRole19 = new Guid("9b46049d-5733-4c07-a00c-513b873ca7c7");
        Guid UserRole20 = new Guid("5481f74b-b168-4ef7-9eb9-5477f4d159a2");
        Guid UserRole21 = new Guid("c4686468-ac29-49a6-90ab-e20aaf6538bb");
        Guid UserRole22 = new Guid("f217000d-bcee-4b37-926f-e1410ffd9efc");
        Guid UserRole23 = new Guid("b4329533-8254-4442-9189-4e721ddb7f7d");
        Guid UserRole24 = new Guid("5dd7f6f7-1b54-43e7-87ea-4f82cc1af5e6");
        Guid UserRole25 = new Guid("dba42ad8-0ef3-4dd2-811f-ffe1be3e57b8");
        Guid UserRole26 = new Guid("d94f6870-9761-4e2f-a6fe-6b38692ff287");
        Guid UserRole27 = new Guid("93e94f58-8b92-4f61-b158-bbee6494a481");
        Guid UserRole28 = new Guid("bd82aaf3-71a1-477f-9fb4-820fc2316df2");
        Guid UserRole29 = new Guid("f6ceed7b-ca8e-4377-9ca9-6f0d4b99ffad");
        Guid UserRole30 = new Guid("37822019-f2d6-4aab-87a8-96dc3e5b4fa0");
        Guid UserRole31 = new Guid("4d55ce71-9913-435e-965a-b6bf96e1f3a2");
        Guid UserRole32 = new Guid("1ccf93b6-d687-49c2-991e-ec44a2771038");
        Guid UserRole33 = new Guid("01b3dd91-3c32-47b1-ae9e-a3cf50564f7f");
        Guid UserRole34 = new Guid("f5b635b0-c879-4316-b62c-c42ef2b14834");
        Guid UserRole35 = new Guid("3a1f671d-8a82-4233-9dac-7a60fbc1a33d");
        Guid UserRole36 = new Guid("ba68cbe5-8a6b-49aa-aa99-097b29813860");
        Guid UserRole37 = new Guid("b4951181-a59b-44d1-8b5a-f48e65cc471b");
        Guid UserRole38 = new Guid("62eac8e3-aa41-4ea2-b18e-42368b16851e");
        Guid UserRole39 = new Guid("7e9710f0-2040-48b7-ace6-0dffa725ce61");
        Guid UserRole40 = new Guid("05cffdf1-7b84-4ce3-87ad-c2d2d4660ff7");
        Guid UserRole41 = new Guid("44ec0abc-d6a3-47de-878b-e8aa22e97b44");
        Guid UserRole42 = new Guid("12f57181-4b56-4045-a08b-5aba72bc1258");
        Guid UserRole43 = new Guid("04272955-29c0-4b15-97f7-87ef95d059ee");
        Guid UserRole44 = new Guid("2d3faf85-112e-49d4-972b-401dc904f703");
        Guid UserRole45 = new Guid("a02e1abe-e7f5-408b-b50b-c46fecb51b7d");
        Guid UserRole46 = new Guid("6e165948-d178-4517-acba-479682f935fa");
        Guid UserRole47 = new Guid("67b62a01-cdfe-45df-9af6-22c48f9bc65d");
        Guid UserRole48 = new Guid("191a8f61-7646-46bd-ad02-600844a92e91");
        Guid UserRole49 = new Guid("12ddd940-6055-460c-97b1-d850375fb638");
        Guid UserRole50 = new Guid("1c2ea813-09af-4882-9b6e-9542239c3839");
        Guid UserRole51 = new Guid("9a3d36ae-fb13-4261-a3a3-00660e13d94a");
        Guid UserRole52 = new Guid("3b5e012d-49d2-4969-8384-089651f3ed3f");
        Guid UserRole53 = new Guid("d0a1704e-57f9-4265-9548-e4fb469528a9");
        Guid UserRole54 = new Guid("a2265770-9d4e-4e10-8f78-f359865195d5");
        Guid UserRole55 = new Guid("e9c74480-a485-4ed4-8dd9-e46a9e426691");
        Guid UserRole56 = new Guid("9ee5aa15-8785-45c9-878a-04be83ce7d6b");
        Guid UserRole57 = new Guid("aad6cb0e-e859-4e03-9910-f49e0f51ffeb");
        Guid UserRole58 = new Guid("632ef36b-9f9e-492c-84b6-f1978c32623e");
        Guid UserRole59 = new Guid("a8528fa6-e3c8-407e-a020-20750b1ff673");
        Guid UserRole60 = new Guid("f7c181df-1f4f-4508-80d5-6ef2ece35a3b");
        Guid UserRole61 = new Guid("986af4b8-0740-4c34-a305-b1b58a8d3f62");
        Guid UserRole62 = new Guid("23db0910-a7b3-4b45-96c2-667bed741a3c");
        Guid UserRole63 = new Guid("c3369ac8-6ec8-4538-b364-652b5324d220");
        Guid UserRole64 = new Guid("b5984508-78df-4c60-9811-17e463607d97");
        Guid UserRole65 = new Guid("7b311d74-24e7-425d-8c76-bf10bdac1d80");
        Guid UserRole66 = new Guid("a2009b98-02b1-4480-87b5-8cb463cd42d6");
        Guid UserRole67 = new Guid("e6535894-68ca-442b-b1b3-45b6d003813f");
        Guid UserRole68 = new Guid("6393b96e-70ef-4e36-8b4b-2f471b6c2693");
        Guid UserRole69 = new Guid("d3acc128-1aae-40bb-b43a-78c666886493");
        Guid UserRole70 = new Guid("dcd49862-b2ee-4443-b2ea-6cf5e6c62fb7");
        Guid UserRole71 = new Guid("b5b8093a-fe03-41ec-b444-7ed39e78a4cb");
        Guid UserRole72 = new Guid("386da418-bc1c-4c3c-9249-d1a6cad44691");
        Guid UserRole73 = new Guid("7b7c5883-58d9-46e2-9485-e7a48b1dc297");
        Guid UserRole74 = new Guid("e39c1296-bda8-4ac8-9549-8b4e3ffaa7b3");
        Guid UserRole75 = new Guid("bd1ddce0-4fca-49a0-9e55-eaf6bfe61cb0");
        Guid UserRole76 = new Guid("70748878-cf0a-47e4-a430-a701e49148da");

        #endregion


        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<Guid> UserGuids = new List<Guid>
            {
                User1, User2, User3, User4, User5, User6, User7, User8, User9, User10, User11, User12, User13, User14, User15, User16,
                User17, User18, User19, User20, User21, User22, User23, User24, User25, User26, User27, User28, User29, User30, User31, User32,
                User33, User34, User35, User36, User37, User38, User39, User40, User41, User42, User43, User44, User45, User46, User47, User48,
                User49, User50, User51, User52, User53, User54, User55, User56, User57, User58, User59, User60, User61, User62, User63, User64,
                User65, User66, User67, User68, User69, User70, User71, User72, User73, User74, User75, User76
            };

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "BatchTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { Batch1, "1" },
                    { Batch2, "2"},
                    { Batch3, "3"},
                    { Batch4, "4"},
                    { Batch5, "5"},
                    { Batch6, "6"},
                }
            );

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "ClassStreamTable",
                columns: new[] { "Id", "Name", "Code" },
                values: new object[,]
                {
                    { ClassStream1, "Art", "A" },
                    { ClassStream2, "Science", "B"},
                }
            );

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "ClassCategoryTable",
                columns: new[] { "Id", "Code", "BatchId", "ClassStreamId" },
                values: new object[,]
                {
                    { ClassCategory1, "1-A", Batch1, ClassStream1 },
                    { ClassCategory2, "1-B", Batch1, ClassStream2 },
                    { ClassCategory3, "2-A", Batch2, ClassStream1 },
                    { ClassCategory4, "2-B", Batch2, ClassStream2 },
                    { ClassCategory5, "3-A", Batch3, ClassStream1 },
                    { ClassCategory6, "3-B", Batch3, ClassStream2 },
                    { ClassCategory7, "4-A", Batch4, ClassStream1 },
                    { ClassCategory8, "4-B", Batch4, ClassStream2 },
                    { ClassCategory9, "5-A", Batch5, ClassStream1 },
                    { ClassCategory10, "5-B", Batch5, ClassStream2 },
                    { ClassCategory11, "6-A", Batch6, ClassStream1 },
                    { ClassCategory12, "6-B", Batch6, ClassStream2 },
                }
            );

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "SubjectTable",
                columns: new[] { "Id", "Name", "Code" },
                values: new object[,]
                {
                    { Subject1, "Malay", "BM" },
                    { Subject2, "English", "BI" },
                    { Subject3, "Mandarin", "ME" },
                    { Subject4, "Tamil", "TE" },
                    { Subject5, "Chemistry", "CHE" },
                    { Subject6, "Biology", "BIO" },
                    { Subject7, "Physic", "PHY" },
                    { Subject8, "Mathematic", "MATH" },
                }
            );

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "ClassSubjectTable",
                columns: new[] { "Id", "Code", "ClassCategoryId", "SubjectId" },
                values: new object[,]
                {
                    { ClassSubject1, "1-A-BM", ClassCategory1, Subject1 },
                    { ClassSubject2, "1-A-BI", ClassCategory1, Subject2 },
                    { ClassSubject3, "1-A-ME", ClassCategory1, Subject3},
                    { ClassSubject4, "1-A-TE", ClassCategory1, Subject4 },
                    { ClassSubject5, "1-B-CHE", ClassCategory2, Subject5 },
                    { ClassSubject6, "1-B-BIO", ClassCategory2, Subject6 },
                    { ClassSubject7, "1-B-PHY", ClassCategory2, Subject7 },
                    { ClassSubject8, "1-B-MATH", ClassCategory2, Subject8 },

                    { ClassSubject9, "2-A-BM", ClassCategory3, Subject1 },
                    { ClassSubject10, "2-A-BI", ClassCategory3, Subject2 },
                    { ClassSubject11, "2-A-ME", ClassCategory3, Subject3},
                    { ClassSubject12, "2-A-TE", ClassCategory3, Subject4 },
                    { ClassSubject13, "2-B-CHE", ClassCategory4, Subject5 },
                    { ClassSubject14, "2-B-BIO", ClassCategory4, Subject6 },
                    { ClassSubject15, "2-B-PHY", ClassCategory4, Subject7 },
                    { ClassSubject16, "2-B-MATH", ClassCategory4, Subject8 },

                    { ClassSubject17, "3-A-BM", ClassCategory5, Subject1 },
                    { ClassSubject18, "3-A-BI", ClassCategory5, Subject2 },
                    { ClassSubject19, "3-A-ME", ClassCategory5, Subject3},
                    { ClassSubject20, "3-A-TE", ClassCategory5, Subject4 },
                    { ClassSubject21, "3-B-CHE", ClassCategory6, Subject5 },
                    { ClassSubject22, "3-B-BIO", ClassCategory6, Subject6 },
                    { ClassSubject23, "3-B-PHY", ClassCategory6, Subject7 },
                    { ClassSubject24, "3-B-MATH", ClassCategory6, Subject8 },

                    { ClassSubject25, "4-A-BM", ClassCategory7, Subject1 },
                    { ClassSubject26, "4-A-BI", ClassCategory7, Subject2 },
                    { ClassSubject27, "4-A-ME", ClassCategory7, Subject3},
                    { ClassSubject28, "4-A-TE", ClassCategory7, Subject4 },
                    { ClassSubject29, "4-B-CHE", ClassCategory8, Subject5 },
                    { ClassSubject30, "4-B-BIO", ClassCategory8, Subject6 },
                    { ClassSubject31, "4-B-PHY", ClassCategory8, Subject7 },
                    { ClassSubject32, "4-B-MATH", ClassCategory8, Subject8 },

                    { ClassSubject33, "5-A-BM", ClassCategory9, Subject1 },
                    { ClassSubject34, "5-A-BI", ClassCategory9, Subject2 },
                    { ClassSubject35, "5-A-ME", ClassCategory9, Subject3},
                    { ClassSubject36, "5-A-TE", ClassCategory9, Subject4 },
                    { ClassSubject37, "5-B-CHE", ClassCategory10, Subject5 },
                    { ClassSubject38, "5-B-BIO", ClassCategory10, Subject6 },
                    { ClassSubject39, "5-B-PHY", ClassCategory10, Subject7 },
                    { ClassSubject40, "5-B-MATH", ClassCategory10, Subject8 },

                    { ClassSubject41, "6-A-BM", ClassCategory11, Subject1 },
                    { ClassSubject42, "6-A-BI", ClassCategory11, Subject2 },
                    { ClassSubject43, "6-A-ME", ClassCategory11, Subject3},
                    { ClassSubject44, "6-A-TE", ClassCategory11, Subject4 },
                    { ClassSubject45, "6-B-CHE", ClassCategory12, Subject5 },
                    { ClassSubject46, "6-B-BIO", ClassCategory12, Subject6 },
                    { ClassSubject47, "6-B-PHY", ClassCategory12, Subject7 },
                    { ClassSubject48, "6-B-MATH", ClassCategory12, Subject8 },
                }
            );

            #region UserCreationLoop

            List<User> UserObjects = new List<User>();

            for (int i = 0; i < 76; i++)
            {
                Random rnd = new Random();
                DateTime randomDate;
                int currentYear = DateTime.Now.Year;
                var user = new User();
                string randomPassword;

                if (i < 16)
                {
                    randomDate = new DateTime(rnd.Next(1980, 2000), rnd.Next(1, 13), rnd.Next(1, 29));
                    user.FullName = $"Teacher {i}";
                    user.EmailAddress = $"teacher{i}@example.com";
                }
                else if (i < 26)
                {
                    randomDate = new DateTime(2011, rnd.Next(1, 13), rnd.Next(1, 29));
                    user.FullName = $"Student {i}";
                    user.EmailAddress = $"student{i}@example.com";
                }
                else if (i < 36)
                {
                    randomDate = new DateTime(2012, rnd.Next(1, 13), rnd.Next(1, 29));
                    user.FullName = $"Student {i}";
                    user.EmailAddress = $"student{i}@example.com";
                }
                else if (i < 46)
                {
                    randomDate = new DateTime(2013, rnd.Next(1, 13), rnd.Next(1, 29));
                    user.FullName = $"Student {i}";
                    user.EmailAddress = $"student{i}@example.com";
                }
                else if (i < 56)
                {
                    randomDate = new DateTime(2014, rnd.Next(1, 13), rnd.Next(1, 29));
                    user.FullName = $"Student {i}";
                    user.EmailAddress = $"student{i}@example.com";
                }
                else if (i < 66)
                {
                    randomDate = new DateTime(2015, rnd.Next(1, 13), rnd.Next(1, 29));
                    user.FullName = $"Student {i}";
                    user.EmailAddress = $"student{i}@example.com";
                }
                else
                {
                    randomDate = new DateTime(2016, rnd.Next(1, 13), rnd.Next(1, 29));
                    user.FullName = $"Student {i}";
                    user.EmailAddress = $"student{i}@example.com";
                }

                user.Id = UserGuids[i];
                user.IsConfirmedEmail = true;
                user.MobileNumber = "0123456789";
                user.BirthDate = randomDate.ToString("dd-MM-yyyy");
                user.Age = currentYear - randomDate.Year;

                var dividend = i + 1;
                var divideBalance = dividend % 2;

                if (divideBalance != 0)
                {
                    user.Gender = "male";
                }
                else
                {
                    user.Gender = "female";
                }

                #region randomPassword
                const string alphabetChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                char[] password = new char[_passwordLength];

                for (int j = 0; j < _passwordLength; j++)
                {
                    password[j] = alphabetChars[rnd.Next(alphabetChars.Length)];
                }

                randomPassword = new string(password);
                #endregion

                #region generateSalt
                using var rng = RandomNumberGenerator.Create();
                var byteSalt = new byte[16];
                rng.GetBytes(byteSalt);
                user.PasswordSalt = Convert.ToBase64String(byteSalt);
                #endregion

                #region generateHash
                for (int j = 0; j < _iteration; j++)
                {
                    using var sha256 = SHA256.Create();
                    var passwordSaltPepper = $"{randomPassword}{user.PasswordSalt}{_pepper}";
                    var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
                    var byteHash = sha256.ComputeHash(byteValue);
                    randomPassword = Convert.ToBase64String(byteHash);
                }

                user.PasswordHash = randomPassword;
                #endregion

                #region verificationNumber
                const string numberChars = "0123456789";
                char[] otp = new char[_otpLength];

                for (int j = 0; j < _otpLength; j++)
                {
                    otp[j] = numberChars[rnd.Next(numberChars.Length)];
                }

                user.VerificationNumber = new string(otp);
                #endregion

                user.VerificationExpiration = DateTime.Now.AddHours(48);
                user.TokenExpiration = DateTime.Now;
                user.CreatedBy = "Initial Data Seeding";
                user.CreatedAt = DateTime.Now.ToString("dd-MM-yyyy");

                UserObjects.Add(user);
            }
            #endregion

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "UserTable",
                columns: new[] { "Id", "FullName", "EmailAddress", "IsConfirmedEmail", "MobileNumber", "BirthDate", "Gender", "Age", "PasswordSalt", "PasswordHash", "VerificationNumber", "VerificationExpiration", "AccessToken", "RefreshToken", "TokenExpiration", "CreatedBy", "CreatedAt" },
                values: new object[,]
               {
                    { User1, UserObjects[0].FullName, UserObjects[0].EmailAddress, UserObjects[0].IsConfirmedEmail, UserObjects[0].MobileNumber, UserObjects[0].BirthDate, UserObjects[0].Gender, UserObjects[0].Age, UserObjects[0].PasswordSalt, UserObjects[0].PasswordHash, UserObjects[0].VerificationNumber, UserObjects[0].VerificationExpiration, UserObjects[0].AccessToken, UserObjects[0].RefreshToken, UserObjects[0].TokenExpiration, UserObjects[0].CreatedBy, UserObjects[0].CreatedAt },
                    { User2, UserObjects[1].FullName, UserObjects[1].EmailAddress, UserObjects[1].IsConfirmedEmail, UserObjects[1].MobileNumber, UserObjects[1].BirthDate, UserObjects[1].Gender, UserObjects[1].Age, UserObjects[1].PasswordSalt, UserObjects[1].PasswordHash, UserObjects[1].VerificationNumber, UserObjects[1].VerificationExpiration, UserObjects[1].AccessToken, UserObjects[1].RefreshToken, UserObjects[1].TokenExpiration, UserObjects[1].CreatedBy, UserObjects[1].CreatedAt },
                    { User3, UserObjects[2].FullName, UserObjects[2].EmailAddress, UserObjects[2].IsConfirmedEmail, UserObjects[2].MobileNumber, UserObjects[2].BirthDate, UserObjects[2].Gender, UserObjects[2].Age, UserObjects[2].PasswordSalt, UserObjects[2].PasswordHash, UserObjects[2].VerificationNumber, UserObjects[2].VerificationExpiration, UserObjects[2].AccessToken, UserObjects[2].RefreshToken, UserObjects[2].TokenExpiration, UserObjects[2].CreatedBy, UserObjects[2].CreatedAt },
                    { User4, UserObjects[3].FullName, UserObjects[3].EmailAddress, UserObjects[3].IsConfirmedEmail, UserObjects[3].MobileNumber, UserObjects[3].BirthDate, UserObjects[3].Gender, UserObjects[3].Age, UserObjects[3].PasswordSalt, UserObjects[3].PasswordHash, UserObjects[3].VerificationNumber, UserObjects[3].VerificationExpiration, UserObjects[3].AccessToken, UserObjects[3].RefreshToken, UserObjects[3].TokenExpiration, UserObjects[3].CreatedBy, UserObjects[3].CreatedAt },
                    { User5, UserObjects[4].FullName, UserObjects[4].EmailAddress, UserObjects[4].IsConfirmedEmail, UserObjects[4].MobileNumber, UserObjects[4].BirthDate, UserObjects[4].Gender, UserObjects[4].Age, UserObjects[4].PasswordSalt, UserObjects[4].PasswordHash, UserObjects[4].VerificationNumber, UserObjects[4].VerificationExpiration, UserObjects[4].AccessToken, UserObjects[4].RefreshToken, UserObjects[4].TokenExpiration, UserObjects[4].CreatedBy, UserObjects[4].CreatedAt },
                    { User6, UserObjects[5].FullName, UserObjects[5].EmailAddress, UserObjects[5].IsConfirmedEmail, UserObjects[5].MobileNumber, UserObjects[5].BirthDate, UserObjects[5].Gender, UserObjects[5].Age, UserObjects[5].PasswordSalt, UserObjects[5].PasswordHash, UserObjects[5].VerificationNumber, UserObjects[5].VerificationExpiration, UserObjects[5].AccessToken, UserObjects[5].RefreshToken, UserObjects[5].TokenExpiration, UserObjects[5].CreatedBy, UserObjects[5].CreatedAt },
                    { User7, UserObjects[6].FullName, UserObjects[6].EmailAddress, UserObjects[6].IsConfirmedEmail, UserObjects[6].MobileNumber, UserObjects[6].BirthDate, UserObjects[6].Gender, UserObjects[6].Age, UserObjects[6].PasswordSalt, UserObjects[6].PasswordHash, UserObjects[6].VerificationNumber, UserObjects[6].VerificationExpiration, UserObjects[6].AccessToken, UserObjects[6].RefreshToken, UserObjects[6].TokenExpiration, UserObjects[6].CreatedBy, UserObjects[6].CreatedAt },
                    { User8, UserObjects[7].FullName, UserObjects[7].EmailAddress, UserObjects[7].IsConfirmedEmail, UserObjects[7].MobileNumber, UserObjects[7].BirthDate, UserObjects[7].Gender, UserObjects[7].Age, UserObjects[7].PasswordSalt, UserObjects[7].PasswordHash, UserObjects[7].VerificationNumber, UserObjects[7].VerificationExpiration, UserObjects[7].AccessToken, UserObjects[7].RefreshToken, UserObjects[7].TokenExpiration, UserObjects[7].CreatedBy, UserObjects[7].CreatedAt },
                    { User9, UserObjects[8].FullName, UserObjects[8].EmailAddress, UserObjects[8].IsConfirmedEmail, UserObjects[8].MobileNumber, UserObjects[8].BirthDate, UserObjects[8].Gender, UserObjects[8].Age, UserObjects[8].PasswordSalt, UserObjects[8].PasswordHash, UserObjects[8].VerificationNumber, UserObjects[8].VerificationExpiration, UserObjects[8].AccessToken, UserObjects[8].RefreshToken, UserObjects[8].TokenExpiration, UserObjects[8].CreatedBy, UserObjects[8].CreatedAt },
                    { User10, UserObjects[9].FullName, UserObjects[9].EmailAddress, UserObjects[9].IsConfirmedEmail, UserObjects[9].MobileNumber, UserObjects[9].BirthDate, UserObjects[9].Gender, UserObjects[9].Age, UserObjects[9].PasswordSalt, UserObjects[9].PasswordHash, UserObjects[9].VerificationNumber, UserObjects[9].VerificationExpiration, UserObjects[9].AccessToken, UserObjects[9].RefreshToken, UserObjects[9].TokenExpiration, UserObjects[9].CreatedBy, UserObjects[9].CreatedAt },
                    { User11, UserObjects[10].FullName, UserObjects[10].EmailAddress, UserObjects[10].IsConfirmedEmail, UserObjects[10].MobileNumber, UserObjects[10].BirthDate, UserObjects[10].Gender, UserObjects[10].Age, UserObjects[10].PasswordSalt, UserObjects[10].PasswordHash, UserObjects[10].VerificationNumber, UserObjects[10].VerificationExpiration, UserObjects[10].AccessToken, UserObjects[10].RefreshToken, UserObjects[10].TokenExpiration, UserObjects[10].CreatedBy, UserObjects[10].CreatedAt },
                    { User12, UserObjects[11].FullName, UserObjects[11].EmailAddress, UserObjects[11].IsConfirmedEmail, UserObjects[11].MobileNumber, UserObjects[11].BirthDate, UserObjects[11].Gender, UserObjects[11].Age, UserObjects[11].PasswordSalt, UserObjects[11].PasswordHash, UserObjects[11].VerificationNumber, UserObjects[11].VerificationExpiration, UserObjects[11].AccessToken, UserObjects[11].RefreshToken, UserObjects[11].TokenExpiration, UserObjects[11].CreatedBy, UserObjects[11].CreatedAt },
                    { User13, UserObjects[12].FullName, UserObjects[12].EmailAddress, UserObjects[12].IsConfirmedEmail, UserObjects[12].MobileNumber, UserObjects[12].BirthDate, UserObjects[12].Gender, UserObjects[12].Age, UserObjects[12].PasswordSalt, UserObjects[12].PasswordHash, UserObjects[12].VerificationNumber, UserObjects[12].VerificationExpiration, UserObjects[12].AccessToken, UserObjects[12].RefreshToken, UserObjects[12].TokenExpiration, UserObjects[12].CreatedBy, UserObjects[12].CreatedAt },
                    { User14, UserObjects[13].FullName, UserObjects[13].EmailAddress, UserObjects[13].IsConfirmedEmail, UserObjects[13].MobileNumber, UserObjects[13].BirthDate, UserObjects[13].Gender, UserObjects[13].Age, UserObjects[13].PasswordSalt, UserObjects[13].PasswordHash, UserObjects[13].VerificationNumber, UserObjects[13].VerificationExpiration, UserObjects[13].AccessToken, UserObjects[13].RefreshToken, UserObjects[13].TokenExpiration, UserObjects[13].CreatedBy, UserObjects[13].CreatedAt },
                    { User15, UserObjects[14].FullName, UserObjects[14].EmailAddress, UserObjects[14].IsConfirmedEmail, UserObjects[14].MobileNumber, UserObjects[14].BirthDate, UserObjects[14].Gender, UserObjects[14].Age, UserObjects[14].PasswordSalt, UserObjects[14].PasswordHash, UserObjects[14].VerificationNumber, UserObjects[14].VerificationExpiration, UserObjects[14].AccessToken, UserObjects[14].RefreshToken, UserObjects[14].TokenExpiration, UserObjects[14].CreatedBy, UserObjects[14].CreatedAt },
                    { User16, UserObjects[15].FullName, UserObjects[15].EmailAddress, UserObjects[15].IsConfirmedEmail, UserObjects[15].MobileNumber, UserObjects[15].BirthDate, UserObjects[15].Gender, UserObjects[15].Age, UserObjects[15].PasswordSalt, UserObjects[15].PasswordHash, UserObjects[15].VerificationNumber, UserObjects[15].VerificationExpiration, UserObjects[15].AccessToken, UserObjects[15].RefreshToken, UserObjects[15].TokenExpiration, UserObjects[15].CreatedBy, UserObjects[15].CreatedAt },
                    { User17, UserObjects[16].FullName, UserObjects[16].EmailAddress, UserObjects[16].IsConfirmedEmail, UserObjects[16].MobileNumber, UserObjects[16].BirthDate, UserObjects[16].Gender, UserObjects[16].Age, UserObjects[16].PasswordSalt, UserObjects[16].PasswordHash, UserObjects[16].VerificationNumber, UserObjects[16].VerificationExpiration, UserObjects[16].AccessToken, UserObjects[16].RefreshToken, UserObjects[16].TokenExpiration, UserObjects[16].CreatedBy, UserObjects[16].CreatedAt },
                    { User18, UserObjects[17].FullName, UserObjects[17].EmailAddress, UserObjects[17].IsConfirmedEmail, UserObjects[17].MobileNumber, UserObjects[17].BirthDate, UserObjects[17].Gender, UserObjects[17].Age, UserObjects[17].PasswordSalt, UserObjects[17].PasswordHash, UserObjects[17].VerificationNumber, UserObjects[17].VerificationExpiration, UserObjects[17].AccessToken, UserObjects[17].RefreshToken, UserObjects[17].TokenExpiration, UserObjects[17].CreatedBy, UserObjects[17].CreatedAt },
                    { User19, UserObjects[18].FullName, UserObjects[18].EmailAddress, UserObjects[18].IsConfirmedEmail, UserObjects[18].MobileNumber, UserObjects[18].BirthDate, UserObjects[18].Gender, UserObjects[18].Age, UserObjects[18].PasswordSalt, UserObjects[18].PasswordHash, UserObjects[18].VerificationNumber, UserObjects[18].VerificationExpiration, UserObjects[18].AccessToken, UserObjects[18].RefreshToken, UserObjects[18].TokenExpiration, UserObjects[18].CreatedBy, UserObjects[18].CreatedAt },
                    { User20, UserObjects[19].FullName, UserObjects[19].EmailAddress, UserObjects[19].IsConfirmedEmail, UserObjects[19].MobileNumber, UserObjects[19].BirthDate, UserObjects[19].Gender, UserObjects[19].Age, UserObjects[19].PasswordSalt, UserObjects[19].PasswordHash, UserObjects[19].VerificationNumber, UserObjects[19].VerificationExpiration, UserObjects[19].AccessToken, UserObjects[19].RefreshToken, UserObjects[19].TokenExpiration, UserObjects[19].CreatedBy, UserObjects[19].CreatedAt },
                    { User21, UserObjects[20].FullName, UserObjects[20].EmailAddress, UserObjects[20].IsConfirmedEmail, UserObjects[20].MobileNumber, UserObjects[20].BirthDate, UserObjects[20].Gender, UserObjects[20].Age, UserObjects[20].PasswordSalt, UserObjects[20].PasswordHash, UserObjects[20].VerificationNumber, UserObjects[20].VerificationExpiration, UserObjects[20].AccessToken, UserObjects[20].RefreshToken, UserObjects[20].TokenExpiration, UserObjects[20].CreatedBy, UserObjects[20].CreatedAt },
                    { User22, UserObjects[21].FullName, UserObjects[21].EmailAddress, UserObjects[21].IsConfirmedEmail, UserObjects[21].MobileNumber, UserObjects[21].BirthDate, UserObjects[21].Gender, UserObjects[21].Age, UserObjects[21].PasswordSalt, UserObjects[21].PasswordHash, UserObjects[21].VerificationNumber, UserObjects[21].VerificationExpiration, UserObjects[21].AccessToken, UserObjects[21].RefreshToken, UserObjects[21].TokenExpiration, UserObjects[21].CreatedBy, UserObjects[21].CreatedAt },
                    { User23, UserObjects[22].FullName, UserObjects[22].EmailAddress, UserObjects[22].IsConfirmedEmail, UserObjects[22].MobileNumber, UserObjects[22].BirthDate, UserObjects[22].Gender, UserObjects[22].Age, UserObjects[22].PasswordSalt, UserObjects[22].PasswordHash, UserObjects[22].VerificationNumber, UserObjects[22].VerificationExpiration, UserObjects[22].AccessToken, UserObjects[22].RefreshToken, UserObjects[22].TokenExpiration, UserObjects[22].CreatedBy, UserObjects[22].CreatedAt },
                    { User24, UserObjects[23].FullName, UserObjects[23].EmailAddress, UserObjects[23].IsConfirmedEmail, UserObjects[23].MobileNumber, UserObjects[23].BirthDate, UserObjects[23].Gender, UserObjects[23].Age, UserObjects[23].PasswordSalt, UserObjects[23].PasswordHash, UserObjects[23].VerificationNumber, UserObjects[23].VerificationExpiration, UserObjects[23].AccessToken, UserObjects[23].RefreshToken, UserObjects[23].TokenExpiration, UserObjects[23].CreatedBy, UserObjects[23].CreatedAt },
                    { User25, UserObjects[24].FullName, UserObjects[24].EmailAddress, UserObjects[24].IsConfirmedEmail, UserObjects[24].MobileNumber, UserObjects[24].BirthDate, UserObjects[24].Gender, UserObjects[24].Age, UserObjects[24].PasswordSalt, UserObjects[24].PasswordHash, UserObjects[24].VerificationNumber, UserObjects[24].VerificationExpiration, UserObjects[24].AccessToken, UserObjects[24].RefreshToken, UserObjects[24].TokenExpiration, UserObjects[24].CreatedBy, UserObjects[24].CreatedAt },
                    { User26, UserObjects[25].FullName, UserObjects[25].EmailAddress, UserObjects[25].IsConfirmedEmail, UserObjects[25].MobileNumber, UserObjects[25].BirthDate, UserObjects[25].Gender, UserObjects[25].Age, UserObjects[25].PasswordSalt, UserObjects[25].PasswordHash, UserObjects[25].VerificationNumber, UserObjects[25].VerificationExpiration, UserObjects[25].AccessToken, UserObjects[25].RefreshToken, UserObjects[25].TokenExpiration, UserObjects[25].CreatedBy, UserObjects[25].CreatedAt },
                    { User27, UserObjects[26].FullName, UserObjects[26].EmailAddress, UserObjects[26].IsConfirmedEmail, UserObjects[26].MobileNumber, UserObjects[26].BirthDate, UserObjects[26].Gender, UserObjects[26].Age, UserObjects[26].PasswordSalt, UserObjects[26].PasswordHash, UserObjects[26].VerificationNumber, UserObjects[26].VerificationExpiration, UserObjects[26].AccessToken, UserObjects[26].RefreshToken, UserObjects[26].TokenExpiration, UserObjects[26].CreatedBy, UserObjects[26].CreatedAt },
                    { User28, UserObjects[27].FullName, UserObjects[27].EmailAddress, UserObjects[27].IsConfirmedEmail, UserObjects[27].MobileNumber, UserObjects[27].BirthDate, UserObjects[27].Gender, UserObjects[27].Age, UserObjects[27].PasswordSalt, UserObjects[27].PasswordHash, UserObjects[27].VerificationNumber, UserObjects[27].VerificationExpiration, UserObjects[27].AccessToken, UserObjects[27].RefreshToken, UserObjects[27].TokenExpiration, UserObjects[27].CreatedBy, UserObjects[27].CreatedAt },
                    { User29, UserObjects[28].FullName, UserObjects[28].EmailAddress, UserObjects[28].IsConfirmedEmail, UserObjects[28].MobileNumber, UserObjects[28].BirthDate, UserObjects[28].Gender, UserObjects[28].Age, UserObjects[28].PasswordSalt, UserObjects[28].PasswordHash, UserObjects[28].VerificationNumber, UserObjects[28].VerificationExpiration, UserObjects[28].AccessToken, UserObjects[28].RefreshToken, UserObjects[28].TokenExpiration, UserObjects[28].CreatedBy, UserObjects[28].CreatedAt },
                    { User30, UserObjects[29].FullName, UserObjects[29].EmailAddress, UserObjects[29].IsConfirmedEmail, UserObjects[29].MobileNumber, UserObjects[29].BirthDate, UserObjects[29].Gender, UserObjects[29].Age, UserObjects[29].PasswordSalt, UserObjects[29].PasswordHash, UserObjects[29].VerificationNumber, UserObjects[29].VerificationExpiration, UserObjects[29].AccessToken, UserObjects[29].RefreshToken, UserObjects[29].TokenExpiration, UserObjects[29].CreatedBy, UserObjects[29].CreatedAt },
                    { User31, UserObjects[30].FullName, UserObjects[30].EmailAddress, UserObjects[30].IsConfirmedEmail, UserObjects[30].MobileNumber, UserObjects[30].BirthDate, UserObjects[30].Gender, UserObjects[30].Age, UserObjects[30].PasswordSalt, UserObjects[30].PasswordHash, UserObjects[30].VerificationNumber, UserObjects[30].VerificationExpiration, UserObjects[30].AccessToken, UserObjects[30].RefreshToken, UserObjects[30].TokenExpiration, UserObjects[30].CreatedBy, UserObjects[30].CreatedAt },
                    { User32, UserObjects[31].FullName, UserObjects[31].EmailAddress, UserObjects[31].IsConfirmedEmail, UserObjects[31].MobileNumber, UserObjects[31].BirthDate, UserObjects[31].Gender, UserObjects[31].Age, UserObjects[31].PasswordSalt, UserObjects[31].PasswordHash, UserObjects[31].VerificationNumber, UserObjects[31].VerificationExpiration, UserObjects[31].AccessToken, UserObjects[31].RefreshToken, UserObjects[31].TokenExpiration, UserObjects[31].CreatedBy, UserObjects[31].CreatedAt },
                    { User33, UserObjects[32].FullName, UserObjects[32].EmailAddress, UserObjects[32].IsConfirmedEmail, UserObjects[32].MobileNumber, UserObjects[32].BirthDate, UserObjects[32].Gender, UserObjects[32].Age, UserObjects[32].PasswordSalt, UserObjects[32].PasswordHash, UserObjects[32].VerificationNumber, UserObjects[32].VerificationExpiration, UserObjects[32].AccessToken, UserObjects[32].RefreshToken, UserObjects[32].TokenExpiration, UserObjects[32].CreatedBy, UserObjects[32].CreatedAt },
                    { User34, UserObjects[33].FullName, UserObjects[33].EmailAddress, UserObjects[33].IsConfirmedEmail, UserObjects[33].MobileNumber, UserObjects[33].BirthDate, UserObjects[33].Gender, UserObjects[33].Age, UserObjects[33].PasswordSalt, UserObjects[33].PasswordHash, UserObjects[33].VerificationNumber, UserObjects[33].VerificationExpiration, UserObjects[33].AccessToken, UserObjects[33].RefreshToken, UserObjects[33].TokenExpiration, UserObjects[33].CreatedBy, UserObjects[33].CreatedAt },
                    { User35, UserObjects[34].FullName, UserObjects[34].EmailAddress, UserObjects[34].IsConfirmedEmail, UserObjects[34].MobileNumber, UserObjects[34].BirthDate, UserObjects[34].Gender, UserObjects[34].Age, UserObjects[34].PasswordSalt, UserObjects[34].PasswordHash, UserObjects[34].VerificationNumber, UserObjects[34].VerificationExpiration, UserObjects[34].AccessToken, UserObjects[34].RefreshToken, UserObjects[34].TokenExpiration, UserObjects[34].CreatedBy, UserObjects[34].CreatedAt },
                    { User36, UserObjects[35].FullName, UserObjects[35].EmailAddress, UserObjects[35].IsConfirmedEmail, UserObjects[35].MobileNumber, UserObjects[35].BirthDate, UserObjects[35].Gender, UserObjects[35].Age, UserObjects[35].PasswordSalt, UserObjects[35].PasswordHash, UserObjects[35].VerificationNumber, UserObjects[35].VerificationExpiration, UserObjects[35].AccessToken, UserObjects[35].RefreshToken, UserObjects[35].TokenExpiration, UserObjects[35].CreatedBy, UserObjects[35].CreatedAt },
                    { User37, UserObjects[36].FullName, UserObjects[36].EmailAddress, UserObjects[36].IsConfirmedEmail, UserObjects[36].MobileNumber, UserObjects[36].BirthDate, UserObjects[36].Gender, UserObjects[36].Age, UserObjects[36].PasswordSalt, UserObjects[36].PasswordHash, UserObjects[36].VerificationNumber, UserObjects[36].VerificationExpiration, UserObjects[36].AccessToken, UserObjects[36].RefreshToken, UserObjects[36].TokenExpiration, UserObjects[36].CreatedBy, UserObjects[36].CreatedAt },
                    { User38, UserObjects[37].FullName, UserObjects[37].EmailAddress, UserObjects[37].IsConfirmedEmail, UserObjects[37].MobileNumber, UserObjects[37].BirthDate, UserObjects[37].Gender, UserObjects[37].Age, UserObjects[37].PasswordSalt, UserObjects[37].PasswordHash, UserObjects[37].VerificationNumber, UserObjects[37].VerificationExpiration, UserObjects[37].AccessToken, UserObjects[37].RefreshToken, UserObjects[37].TokenExpiration, UserObjects[37].CreatedBy, UserObjects[37].CreatedAt },
                    { User39, UserObjects[38].FullName, UserObjects[38].EmailAddress, UserObjects[38].IsConfirmedEmail, UserObjects[38].MobileNumber, UserObjects[38].BirthDate, UserObjects[38].Gender, UserObjects[38].Age, UserObjects[38].PasswordSalt, UserObjects[38].PasswordHash, UserObjects[38].VerificationNumber, UserObjects[38].VerificationExpiration, UserObjects[38].AccessToken, UserObjects[38].RefreshToken, UserObjects[38].TokenExpiration, UserObjects[38].CreatedBy, UserObjects[38].CreatedAt },
                    { User40, UserObjects[39].FullName, UserObjects[39].EmailAddress, UserObjects[39].IsConfirmedEmail, UserObjects[39].MobileNumber, UserObjects[39].BirthDate, UserObjects[39].Gender, UserObjects[39].Age, UserObjects[39].PasswordSalt, UserObjects[39].PasswordHash, UserObjects[39].VerificationNumber, UserObjects[39].VerificationExpiration, UserObjects[39].AccessToken, UserObjects[39].RefreshToken, UserObjects[39].TokenExpiration, UserObjects[39].CreatedBy, UserObjects[39].CreatedAt },
                    { User41, UserObjects[40].FullName, UserObjects[40].EmailAddress, UserObjects[40].IsConfirmedEmail, UserObjects[40].MobileNumber, UserObjects[40].BirthDate, UserObjects[40].Gender, UserObjects[40].Age, UserObjects[40].PasswordSalt, UserObjects[40].PasswordHash, UserObjects[40].VerificationNumber, UserObjects[40].VerificationExpiration, UserObjects[40].AccessToken, UserObjects[40].RefreshToken, UserObjects[40].TokenExpiration, UserObjects[40].CreatedBy, UserObjects[40].CreatedAt },
                    { User42, UserObjects[41].FullName, UserObjects[41].EmailAddress, UserObjects[41].IsConfirmedEmail, UserObjects[41].MobileNumber, UserObjects[41].BirthDate, UserObjects[41].Gender, UserObjects[41].Age, UserObjects[41].PasswordSalt, UserObjects[41].PasswordHash, UserObjects[41].VerificationNumber, UserObjects[41].VerificationExpiration, UserObjects[41].AccessToken, UserObjects[41].RefreshToken, UserObjects[41].TokenExpiration, UserObjects[41].CreatedBy, UserObjects[41].CreatedAt },
                    { User43, UserObjects[42].FullName, UserObjects[42].EmailAddress, UserObjects[42].IsConfirmedEmail, UserObjects[42].MobileNumber, UserObjects[42].BirthDate, UserObjects[42].Gender, UserObjects[42].Age, UserObjects[42].PasswordSalt, UserObjects[42].PasswordHash, UserObjects[42].VerificationNumber, UserObjects[42].VerificationExpiration, UserObjects[42].AccessToken, UserObjects[42].RefreshToken, UserObjects[42].TokenExpiration, UserObjects[42].CreatedBy, UserObjects[42].CreatedAt },
                    { User44, UserObjects[43].FullName, UserObjects[43].EmailAddress, UserObjects[43].IsConfirmedEmail, UserObjects[43].MobileNumber, UserObjects[43].BirthDate, UserObjects[43].Gender, UserObjects[43].Age, UserObjects[43].PasswordSalt, UserObjects[43].PasswordHash, UserObjects[43].VerificationNumber, UserObjects[43].VerificationExpiration, UserObjects[43].AccessToken, UserObjects[43].RefreshToken, UserObjects[43].TokenExpiration, UserObjects[43].CreatedBy, UserObjects[43].CreatedAt },
                    { User45, UserObjects[44].FullName, UserObjects[44].EmailAddress, UserObjects[44].IsConfirmedEmail, UserObjects[44].MobileNumber, UserObjects[44].BirthDate, UserObjects[44].Gender, UserObjects[44].Age, UserObjects[44].PasswordSalt, UserObjects[44].PasswordHash, UserObjects[44].VerificationNumber, UserObjects[44].VerificationExpiration, UserObjects[44].AccessToken, UserObjects[44].RefreshToken, UserObjects[44].TokenExpiration, UserObjects[44].CreatedBy, UserObjects[44].CreatedAt },
                    { User46, UserObjects[45].FullName, UserObjects[45].EmailAddress, UserObjects[45].IsConfirmedEmail, UserObjects[45].MobileNumber, UserObjects[45].BirthDate, UserObjects[45].Gender, UserObjects[45].Age, UserObjects[45].PasswordSalt, UserObjects[45].PasswordHash, UserObjects[45].VerificationNumber, UserObjects[45].VerificationExpiration, UserObjects[45].AccessToken, UserObjects[45].RefreshToken, UserObjects[45].TokenExpiration, UserObjects[45].CreatedBy, UserObjects[45].CreatedAt },
                    { User47, UserObjects[46].FullName, UserObjects[46].EmailAddress, UserObjects[46].IsConfirmedEmail, UserObjects[46].MobileNumber, UserObjects[46].BirthDate, UserObjects[46].Gender, UserObjects[46].Age, UserObjects[46].PasswordSalt, UserObjects[46].PasswordHash, UserObjects[46].VerificationNumber, UserObjects[46].VerificationExpiration, UserObjects[46].AccessToken, UserObjects[46].RefreshToken, UserObjects[46].TokenExpiration, UserObjects[46].CreatedBy, UserObjects[46].CreatedAt },
                    { User48, UserObjects[47].FullName, UserObjects[47].EmailAddress, UserObjects[47].IsConfirmedEmail, UserObjects[47].MobileNumber, UserObjects[47].BirthDate, UserObjects[47].Gender, UserObjects[47].Age, UserObjects[47].PasswordSalt, UserObjects[47].PasswordHash, UserObjects[47].VerificationNumber, UserObjects[47].VerificationExpiration, UserObjects[47].AccessToken, UserObjects[47].RefreshToken, UserObjects[47].TokenExpiration, UserObjects[47].CreatedBy, UserObjects[47].CreatedAt },
                    { User49, UserObjects[48].FullName, UserObjects[48].EmailAddress, UserObjects[48].IsConfirmedEmail, UserObjects[48].MobileNumber, UserObjects[48].BirthDate, UserObjects[48].Gender, UserObjects[48].Age, UserObjects[48].PasswordSalt, UserObjects[48].PasswordHash, UserObjects[48].VerificationNumber, UserObjects[48].VerificationExpiration, UserObjects[48].AccessToken, UserObjects[48].RefreshToken, UserObjects[48].TokenExpiration, UserObjects[48].CreatedBy, UserObjects[48].CreatedAt },
                    { User50, UserObjects[49].FullName, UserObjects[49].EmailAddress, UserObjects[49].IsConfirmedEmail, UserObjects[49].MobileNumber, UserObjects[49].BirthDate, UserObjects[49].Gender, UserObjects[49].Age, UserObjects[49].PasswordSalt, UserObjects[49].PasswordHash, UserObjects[49].VerificationNumber, UserObjects[49].VerificationExpiration, UserObjects[49].AccessToken, UserObjects[49].RefreshToken, UserObjects[49].TokenExpiration, UserObjects[49].CreatedBy, UserObjects[49].CreatedAt },
                    { User51, UserObjects[50].FullName, UserObjects[50].EmailAddress, UserObjects[50].IsConfirmedEmail, UserObjects[50].MobileNumber, UserObjects[50].BirthDate, UserObjects[50].Gender, UserObjects[50].Age, UserObjects[50].PasswordSalt, UserObjects[50].PasswordHash, UserObjects[50].VerificationNumber, UserObjects[50].VerificationExpiration, UserObjects[50].AccessToken, UserObjects[50].RefreshToken, UserObjects[50].TokenExpiration, UserObjects[50].CreatedBy, UserObjects[50].CreatedAt },
                    { User52, UserObjects[51].FullName, UserObjects[51].EmailAddress, UserObjects[51].IsConfirmedEmail, UserObjects[51].MobileNumber, UserObjects[51].BirthDate, UserObjects[51].Gender, UserObjects[51].Age, UserObjects[51].PasswordSalt, UserObjects[51].PasswordHash, UserObjects[51].VerificationNumber, UserObjects[51].VerificationExpiration, UserObjects[51].AccessToken, UserObjects[51].RefreshToken, UserObjects[51].TokenExpiration, UserObjects[51].CreatedBy, UserObjects[51].CreatedAt },
                    { User53, UserObjects[52].FullName, UserObjects[52].EmailAddress, UserObjects[52].IsConfirmedEmail, UserObjects[52].MobileNumber, UserObjects[52].BirthDate, UserObjects[52].Gender, UserObjects[52].Age, UserObjects[52].PasswordSalt, UserObjects[52].PasswordHash, UserObjects[52].VerificationNumber, UserObjects[52].VerificationExpiration, UserObjects[52].AccessToken, UserObjects[52].RefreshToken, UserObjects[52].TokenExpiration, UserObjects[52].CreatedBy, UserObjects[52].CreatedAt },
                    { User54, UserObjects[53].FullName, UserObjects[53].EmailAddress, UserObjects[53].IsConfirmedEmail, UserObjects[53].MobileNumber, UserObjects[53].BirthDate, UserObjects[53].Gender, UserObjects[53].Age, UserObjects[53].PasswordSalt, UserObjects[53].PasswordHash, UserObjects[53].VerificationNumber, UserObjects[53].VerificationExpiration, UserObjects[53].AccessToken, UserObjects[53].RefreshToken, UserObjects[53].TokenExpiration, UserObjects[53].CreatedBy, UserObjects[53].CreatedAt },
                    { User55, UserObjects[54].FullName, UserObjects[54].EmailAddress, UserObjects[54].IsConfirmedEmail, UserObjects[54].MobileNumber, UserObjects[54].BirthDate, UserObjects[54].Gender, UserObjects[54].Age, UserObjects[54].PasswordSalt, UserObjects[54].PasswordHash, UserObjects[54].VerificationNumber, UserObjects[54].VerificationExpiration, UserObjects[54].AccessToken, UserObjects[54].RefreshToken, UserObjects[54].TokenExpiration, UserObjects[54].CreatedBy, UserObjects[54].CreatedAt },
                    { User56, UserObjects[55].FullName, UserObjects[55].EmailAddress, UserObjects[55].IsConfirmedEmail, UserObjects[55].MobileNumber, UserObjects[55].BirthDate, UserObjects[55].Gender, UserObjects[55].Age, UserObjects[55].PasswordSalt, UserObjects[55].PasswordHash, UserObjects[55].VerificationNumber, UserObjects[55].VerificationExpiration, UserObjects[55].AccessToken, UserObjects[55].RefreshToken, UserObjects[55].TokenExpiration, UserObjects[55].CreatedBy, UserObjects[55].CreatedAt },
                    { User57, UserObjects[56].FullName, UserObjects[56].EmailAddress, UserObjects[56].IsConfirmedEmail, UserObjects[56].MobileNumber, UserObjects[56].BirthDate, UserObjects[56].Gender, UserObjects[56].Age, UserObjects[56].PasswordSalt, UserObjects[56].PasswordHash, UserObjects[56].VerificationNumber, UserObjects[56].VerificationExpiration, UserObjects[56].AccessToken, UserObjects[56].RefreshToken, UserObjects[56].TokenExpiration, UserObjects[56].CreatedBy, UserObjects[56].CreatedAt },
                    { User58, UserObjects[57].FullName, UserObjects[57].EmailAddress, UserObjects[57].IsConfirmedEmail, UserObjects[57].MobileNumber, UserObjects[57].BirthDate, UserObjects[57].Gender, UserObjects[57].Age, UserObjects[57].PasswordSalt, UserObjects[57].PasswordHash, UserObjects[57].VerificationNumber, UserObjects[57].VerificationExpiration, UserObjects[57].AccessToken, UserObjects[57].RefreshToken, UserObjects[57].TokenExpiration, UserObjects[57].CreatedBy, UserObjects[57].CreatedAt },
                    { User59, UserObjects[58].FullName, UserObjects[58].EmailAddress, UserObjects[58].IsConfirmedEmail, UserObjects[58].MobileNumber, UserObjects[58].BirthDate, UserObjects[58].Gender, UserObjects[58].Age, UserObjects[58].PasswordSalt, UserObjects[58].PasswordHash, UserObjects[58].VerificationNumber, UserObjects[58].VerificationExpiration, UserObjects[58].AccessToken, UserObjects[58].RefreshToken, UserObjects[58].TokenExpiration, UserObjects[58].CreatedBy, UserObjects[58].CreatedAt },
                    { User60, UserObjects[59].FullName, UserObjects[59].EmailAddress, UserObjects[59].IsConfirmedEmail, UserObjects[59].MobileNumber, UserObjects[59].BirthDate, UserObjects[59].Gender, UserObjects[59].Age, UserObjects[59].PasswordSalt, UserObjects[59].PasswordHash, UserObjects[59].VerificationNumber, UserObjects[59].VerificationExpiration, UserObjects[59].AccessToken, UserObjects[59].RefreshToken, UserObjects[59].TokenExpiration, UserObjects[59].CreatedBy, UserObjects[59].CreatedAt },
                    { User61, UserObjects[60].FullName, UserObjects[60].EmailAddress, UserObjects[60].IsConfirmedEmail, UserObjects[60].MobileNumber, UserObjects[60].BirthDate, UserObjects[60].Gender, UserObjects[60].Age, UserObjects[60].PasswordSalt, UserObjects[60].PasswordHash, UserObjects[60].VerificationNumber, UserObjects[60].VerificationExpiration, UserObjects[60].AccessToken, UserObjects[60].RefreshToken, UserObjects[60].TokenExpiration, UserObjects[60].CreatedBy, UserObjects[60].CreatedAt },
                    { User62, UserObjects[61].FullName, UserObjects[61].EmailAddress, UserObjects[61].IsConfirmedEmail, UserObjects[61].MobileNumber, UserObjects[61].BirthDate, UserObjects[61].Gender, UserObjects[61].Age, UserObjects[61].PasswordSalt, UserObjects[61].PasswordHash, UserObjects[61].VerificationNumber, UserObjects[61].VerificationExpiration, UserObjects[61].AccessToken, UserObjects[61].RefreshToken, UserObjects[61].TokenExpiration, UserObjects[61].CreatedBy, UserObjects[61].CreatedAt },
                    { User63, UserObjects[62].FullName, UserObjects[62].EmailAddress, UserObjects[62].IsConfirmedEmail, UserObjects[62].MobileNumber, UserObjects[62].BirthDate, UserObjects[62].Gender, UserObjects[62].Age, UserObjects[62].PasswordSalt, UserObjects[62].PasswordHash, UserObjects[62].VerificationNumber, UserObjects[62].VerificationExpiration, UserObjects[62].AccessToken, UserObjects[62].RefreshToken, UserObjects[62].TokenExpiration, UserObjects[62].CreatedBy, UserObjects[62].CreatedAt },
                    { User64, UserObjects[63].FullName, UserObjects[63].EmailAddress, UserObjects[63].IsConfirmedEmail, UserObjects[63].MobileNumber, UserObjects[63].BirthDate, UserObjects[63].Gender, UserObjects[63].Age, UserObjects[63].PasswordSalt, UserObjects[63].PasswordHash, UserObjects[63].VerificationNumber, UserObjects[63].VerificationExpiration, UserObjects[63].AccessToken, UserObjects[63].RefreshToken, UserObjects[63].TokenExpiration, UserObjects[63].CreatedBy, UserObjects[63].CreatedAt },
                    { User65, UserObjects[64].FullName, UserObjects[64].EmailAddress, UserObjects[64].IsConfirmedEmail, UserObjects[64].MobileNumber, UserObjects[64].BirthDate, UserObjects[64].Gender, UserObjects[64].Age, UserObjects[64].PasswordSalt, UserObjects[64].PasswordHash, UserObjects[64].VerificationNumber, UserObjects[64].VerificationExpiration, UserObjects[64].AccessToken, UserObjects[64].RefreshToken, UserObjects[64].TokenExpiration, UserObjects[64].CreatedBy, UserObjects[64].CreatedAt },
                    { User66, UserObjects[65].FullName, UserObjects[65].EmailAddress, UserObjects[65].IsConfirmedEmail, UserObjects[65].MobileNumber, UserObjects[65].BirthDate, UserObjects[65].Gender, UserObjects[65].Age, UserObjects[65].PasswordSalt, UserObjects[65].PasswordHash, UserObjects[65].VerificationNumber, UserObjects[65].VerificationExpiration, UserObjects[65].AccessToken, UserObjects[65].RefreshToken, UserObjects[65].TokenExpiration, UserObjects[65].CreatedBy, UserObjects[65].CreatedAt },
                    { User67, UserObjects[66].FullName, UserObjects[66].EmailAddress, UserObjects[66].IsConfirmedEmail, UserObjects[66].MobileNumber, UserObjects[66].BirthDate, UserObjects[66].Gender, UserObjects[66].Age, UserObjects[66].PasswordSalt, UserObjects[66].PasswordHash, UserObjects[66].VerificationNumber, UserObjects[66].VerificationExpiration, UserObjects[66].AccessToken, UserObjects[66].RefreshToken, UserObjects[66].TokenExpiration, UserObjects[66].CreatedBy, UserObjects[66].CreatedAt },
                    { User68, UserObjects[67].FullName, UserObjects[67].EmailAddress, UserObjects[67].IsConfirmedEmail, UserObjects[67].MobileNumber, UserObjects[67].BirthDate, UserObjects[67].Gender, UserObjects[67].Age, UserObjects[67].PasswordSalt, UserObjects[67].PasswordHash, UserObjects[67].VerificationNumber, UserObjects[67].VerificationExpiration, UserObjects[67].AccessToken, UserObjects[67].RefreshToken, UserObjects[67].TokenExpiration, UserObjects[67].CreatedBy, UserObjects[67].CreatedAt },
                    { User69, UserObjects[68].FullName, UserObjects[68].EmailAddress, UserObjects[68].IsConfirmedEmail, UserObjects[68].MobileNumber, UserObjects[68].BirthDate, UserObjects[68].Gender, UserObjects[68].Age, UserObjects[68].PasswordSalt, UserObjects[68].PasswordHash, UserObjects[68].VerificationNumber, UserObjects[68].VerificationExpiration, UserObjects[68].AccessToken, UserObjects[68].RefreshToken, UserObjects[68].TokenExpiration, UserObjects[68].CreatedBy, UserObjects[68].CreatedAt },
                    { User70, UserObjects[69].FullName, UserObjects[69].EmailAddress, UserObjects[69].IsConfirmedEmail, UserObjects[69].MobileNumber, UserObjects[69].BirthDate, UserObjects[69].Gender, UserObjects[69].Age, UserObjects[69].PasswordSalt, UserObjects[69].PasswordHash, UserObjects[69].VerificationNumber, UserObjects[69].VerificationExpiration, UserObjects[69].AccessToken, UserObjects[69].RefreshToken, UserObjects[69].TokenExpiration, UserObjects[69].CreatedBy, UserObjects[69].CreatedAt },
                    { User71, UserObjects[70].FullName, UserObjects[70].EmailAddress, UserObjects[70].IsConfirmedEmail, UserObjects[70].MobileNumber, UserObjects[70].BirthDate, UserObjects[70].Gender, UserObjects[70].Age, UserObjects[70].PasswordSalt, UserObjects[70].PasswordHash, UserObjects[70].VerificationNumber, UserObjects[70].VerificationExpiration, UserObjects[70].AccessToken, UserObjects[70].RefreshToken, UserObjects[70].TokenExpiration, UserObjects[70].CreatedBy, UserObjects[70].CreatedAt },
                    { User72, UserObjects[71].FullName, UserObjects[71].EmailAddress, UserObjects[71].IsConfirmedEmail, UserObjects[71].MobileNumber, UserObjects[71].BirthDate, UserObjects[71].Gender, UserObjects[71].Age, UserObjects[71].PasswordSalt, UserObjects[71].PasswordHash, UserObjects[71].VerificationNumber, UserObjects[71].VerificationExpiration, UserObjects[71].AccessToken, UserObjects[71].RefreshToken, UserObjects[71].TokenExpiration, UserObjects[71].CreatedBy, UserObjects[71].CreatedAt },
                    { User73, UserObjects[72].FullName, UserObjects[72].EmailAddress, UserObjects[72].IsConfirmedEmail, UserObjects[72].MobileNumber, UserObjects[72].BirthDate, UserObjects[72].Gender, UserObjects[72].Age, UserObjects[72].PasswordSalt, UserObjects[72].PasswordHash, UserObjects[72].VerificationNumber, UserObjects[72].VerificationExpiration, UserObjects[72].AccessToken, UserObjects[72].RefreshToken, UserObjects[72].TokenExpiration, UserObjects[72].CreatedBy, UserObjects[72].CreatedAt },
                    { User74, UserObjects[73].FullName, UserObjects[73].EmailAddress, UserObjects[73].IsConfirmedEmail, UserObjects[73].MobileNumber, UserObjects[73].BirthDate, UserObjects[73].Gender, UserObjects[73].Age, UserObjects[73].PasswordSalt, UserObjects[73].PasswordHash, UserObjects[73].VerificationNumber, UserObjects[73].VerificationExpiration, UserObjects[73].AccessToken, UserObjects[73].RefreshToken, UserObjects[73].TokenExpiration, UserObjects[73].CreatedBy, UserObjects[73].CreatedAt },
                    { User75, UserObjects[74].FullName, UserObjects[74].EmailAddress, UserObjects[74].IsConfirmedEmail, UserObjects[74].MobileNumber, UserObjects[74].BirthDate, UserObjects[74].Gender, UserObjects[74].Age, UserObjects[74].PasswordSalt, UserObjects[74].PasswordHash, UserObjects[74].VerificationNumber, UserObjects[74].VerificationExpiration, UserObjects[74].AccessToken, UserObjects[74].RefreshToken, UserObjects[74].TokenExpiration, UserObjects[74].CreatedBy, UserObjects[74].CreatedAt },
                    { User76, UserObjects[75].FullName, UserObjects[75].EmailAddress, UserObjects[75].IsConfirmedEmail, UserObjects[75].MobileNumber, UserObjects[75].BirthDate, UserObjects[75].Gender, UserObjects[75].Age, UserObjects[75].PasswordSalt, UserObjects[75].PasswordHash, UserObjects[75].VerificationNumber, UserObjects[75].VerificationExpiration, UserObjects[75].AccessToken, UserObjects[75].RefreshToken, UserObjects[75].TokenExpiration, UserObjects[75].CreatedBy, UserObjects[75].CreatedAt },
               }
            );

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "TeacherTable",
                columns: new[] { "Id", "ServiceStatus", "IsAvailable", "UserId", "ClassCategoryId" },
                values: new object[,]
                {
                    { Teacher1, "permanent", true, User1, ClassCategory1 },
                    { Teacher2, "permanent", true, User2, ClassCategory2 },
                    { Teacher3, "permanent", true, User3, ClassCategory3 },
                    { Teacher4, "permanent", true, User4, ClassCategory4 },
                    { Teacher5, "permanent", true, User5, ClassCategory5 },
                    { Teacher6, "permanent", true, User6, ClassCategory6 },
                    { Teacher7, "permanent", true, User7, ClassCategory7 },
                    { Teacher8, "permanent", true, User8, ClassCategory8 },
                    { Teacher9, "permanent", true, User9, ClassCategory9 },
                    { Teacher10, "permanent", true, User10, ClassCategory10 },
                    { Teacher11, "permanent", true, User11, ClassCategory11 },
                    { Teacher12, "permanent", true, User12, ClassCategory12 },
                    { Teacher13, "permanent", true, User13, null },
                    { Teacher14, "permanent", true, User14, null },
                    { Teacher15, "permanent", true, User15, null },
                    { Teacher16, "permanent", true, User16, null },
                }
            );

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "StudentTable",
                columns: new[] { "Id", "EntranceYear", "GraduatedYear", "UserId", "ClassCategoryId" },
                values: new object[,]
               {
                    { Student1, "2011", "2016", User17, ClassCategory11 },
                    { Student2, "2011", "2016", User18, ClassCategory11 },
                    { Student3, "2011", "2016", User19, ClassCategory11 },
                    { Student4, "2011", "2016", User20, ClassCategory11 },
                    { Student5, "2011", "2016", User21, ClassCategory11 },
                    { Student6, "2011", "2016", User22, ClassCategory12 },
                    { Student7, "2011", "2016", User23, ClassCategory12 },
                    { Student8, "2011", "2016", User24, ClassCategory12 },
                    { Student9, "2011", "2016", User25, ClassCategory12 },
                    { Student10, "2011", "2016", User26, ClassCategory12 },

                    { Student11, "2012", "2017", User27, ClassCategory9 },
                    { Student12, "2012", "2017", User28, ClassCategory9 },
                    { Student13, "2012", "2017", User29, ClassCategory9 },
                    { Student14, "2012", "2017", User30, ClassCategory9 },
                    { Student15, "2012", "2017", User31, ClassCategory9 },
                    { Student16, "2012", "2017", User32, ClassCategory10 },
                    { Student17, "2012", "2017", User33, ClassCategory10 },
                    { Student18, "2012", "2017", User34, ClassCategory10 },
                    { Student19, "2012", "2017", User35, ClassCategory10 },
                    { Student20, "2012", "2017", User36, ClassCategory10 },

                    { Student21, "2013", "2018", User37, ClassCategory7 },
                    { Student22, "2013", "2018", User38, ClassCategory7 },
                    { Student23, "2013", "2018", User39, ClassCategory7 },
                    { Student24, "2013", "2018", User40, ClassCategory7 },
                    { Student25, "2013", "2018", User41, ClassCategory7 },
                    { Student26, "2013", "2018", User42, ClassCategory8 },
                    { Student27, "2013", "2018", User43, ClassCategory8 },
                    { Student28, "2013", "2018", User44, ClassCategory8 },
                    { Student29, "2013", "2018", User45, ClassCategory8 },
                    { Student30, "2013", "2018", User46, ClassCategory8 },

                    { Student31, "2014", "2019", User47, ClassCategory5 },
                    { Student32, "2014", "2019", User48, ClassCategory5 },
                    { Student33, "2014", "2019", User49, ClassCategory5 },
                    { Student34, "2014", "2019", User50, ClassCategory5 },
                    { Student35, "2014", "2019", User51, ClassCategory5 },
                    { Student36, "2014", "2019", User52, ClassCategory6 },
                    { Student37, "2014", "2019", User53, ClassCategory6 },
                    { Student38, "2014", "2019", User54, ClassCategory6 },
                    { Student39, "2014", "2019", User55, ClassCategory6 },
                    { Student40, "2014", "2019", User56, ClassCategory6 },

                    { Student41, "2015", "2020", User57, ClassCategory3 },
                    { Student42, "2015", "2020", User58, ClassCategory3 },
                    { Student43, "2015", "2020", User59, ClassCategory3 },
                    { Student44, "2015", "2020", User60, ClassCategory3 },
                    { Student45, "2015", "2020", User61, ClassCategory3 },
                    { Student46, "2015", "2020", User62, ClassCategory4 },
                    { Student47, "2015", "2020", User63, ClassCategory4 },
                    { Student48, "2015", "2020", User64, ClassCategory4 },
                    { Student49, "2015", "2020", User65, ClassCategory4 },
                    { Student50, "2015", "2020", User66, ClassCategory4 },

                    { Student51, "2016", "2021", User67, ClassCategory1 },
                    { Student52, "2016", "2021", User68, ClassCategory1 },
                    { Student53, "2016", "2021", User69, ClassCategory1 },
                    { Student54, "2016", "2021", User70, ClassCategory1 },
                    { Student55, "2016", "2021", User71, ClassCategory1 },
                    { Student56, "2016", "2021", User72, ClassCategory2 },
                    { Student57, "2016", "2021", User73, ClassCategory2 },
                    { Student58, "2016", "2021", User74, ClassCategory2 },
                    { Student59, "2016", "2021", User75, ClassCategory2 },
                    { Student60, "2016", "2021", User76, ClassCategory2 },
               }
            );

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "ClassSubjectTeacherTable",
                columns: new[] { "Id", "ClassSubjectId", "TeacherId" },
                values: new object[,]
               {
                    { ClassSubjectTeacher1, ClassSubject1, Teacher1 },
                    { ClassSubjectTeacher2, ClassSubject2, Teacher2 },
                    { ClassSubjectTeacher3, ClassSubject3, Teacher3 },
                    { ClassSubjectTeacher4, ClassSubject4, Teacher4 },
                    { ClassSubjectTeacher5, ClassSubject5, Teacher5 },
                    { ClassSubjectTeacher6, ClassSubject6, Teacher6 },
                    { ClassSubjectTeacher7, ClassSubject7, Teacher7 },
                    { ClassSubjectTeacher8, ClassSubject8, Teacher8 },

                    { ClassSubjectTeacher9, ClassSubject9, Teacher1 },
                    { ClassSubjectTeacher10, ClassSubject10, Teacher2 },
                    { ClassSubjectTeacher11, ClassSubject11, Teacher3 },
                    { ClassSubjectTeacher12, ClassSubject12, Teacher4 },
                    { ClassSubjectTeacher13, ClassSubject13, Teacher5 },
                    { ClassSubjectTeacher14, ClassSubject14, Teacher6 },
                    { ClassSubjectTeacher15, ClassSubject15, Teacher7 },
                    { ClassSubjectTeacher16, ClassSubject16, Teacher8 },

                    { ClassSubjectTeacher17, ClassSubject17, Teacher1 },
                    { ClassSubjectTeacher18, ClassSubject18, Teacher2 },
                    { ClassSubjectTeacher19, ClassSubject19, Teacher3 },
                    { ClassSubjectTeacher20, ClassSubject20, Teacher4 },
                    { ClassSubjectTeacher21, ClassSubject21, Teacher5 },
                    { ClassSubjectTeacher22, ClassSubject22, Teacher6 },
                    { ClassSubjectTeacher23, ClassSubject23, Teacher7 },
                    { ClassSubjectTeacher24, ClassSubject24, Teacher8 },

                    { ClassSubjectTeacher25, ClassSubject25, Teacher9 },
                    { ClassSubjectTeacher26, ClassSubject26, Teacher10 },
                    { ClassSubjectTeacher27, ClassSubject27, Teacher11 },
                    { ClassSubjectTeacher28, ClassSubject28, Teacher12 },
                    { ClassSubjectTeacher29, ClassSubject29, Teacher13 },
                    { ClassSubjectTeacher30, ClassSubject30, Teacher14 },
                    { ClassSubjectTeacher31, ClassSubject31, Teacher15 },
                    { ClassSubjectTeacher32, ClassSubject32, Teacher16 },

                    { ClassSubjectTeacher33, ClassSubject33, Teacher9 },
                    { ClassSubjectTeacher34, ClassSubject34, Teacher10 },
                    { ClassSubjectTeacher35, ClassSubject35, Teacher11 },
                    { ClassSubjectTeacher36, ClassSubject36, Teacher12 },
                    { ClassSubjectTeacher37, ClassSubject37, Teacher13 },
                    { ClassSubjectTeacher38, ClassSubject38, Teacher14 },
                    { ClassSubjectTeacher39, ClassSubject39, Teacher15 },
                    { ClassSubjectTeacher40, ClassSubject40, Teacher16 },

                    { ClassSubjectTeacher41, ClassSubject41, Teacher9 },
                    { ClassSubjectTeacher42, ClassSubject42, Teacher10 },
                    { ClassSubjectTeacher43, ClassSubject43, Teacher11 },
                    { ClassSubjectTeacher44, ClassSubject44, Teacher12 },
                    { ClassSubjectTeacher45, ClassSubject45, Teacher13 },
                    { ClassSubjectTeacher46, ClassSubject46, Teacher14 },
                    { ClassSubjectTeacher47, ClassSubject47, Teacher15 },
                    { ClassSubjectTeacher48, ClassSubject48, Teacher16 }
               }
            );

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "ClassSubjectStudentTable",
                columns: new[] { "Id", "ClassSubjectId", "StudentId" },
                values: new object[,]
                {
                    { ClassSubjectStudent1, ClassSubject41, Student1 },
                    { ClassSubjectStudent2, ClassSubject41, Student2 },
                    { ClassSubjectStudent3, ClassSubject41, Student3  },
                    { ClassSubjectStudent4, ClassSubject41, Student4  },
                    { ClassSubjectStudent5, ClassSubject42, Student5  },
                    { ClassSubjectStudent6, ClassSubject42, Student1  },
                    { ClassSubjectStudent7, ClassSubject43, Student2  },
                    { ClassSubjectStudent8, ClassSubject43, Student3  },
                    { ClassSubjectStudent9, ClassSubject44, Student4  },
                    { ClassSubjectStudent10, ClassSubject44, Student5  },

                    { ClassSubjectStudent11, ClassSubject45, Student6  },
                    { ClassSubjectStudent12, ClassSubject45, Student7  },
                    { ClassSubjectStudent13, ClassSubject45, Student8  },
                    { ClassSubjectStudent14, ClassSubject45, Student9  },
                    { ClassSubjectStudent15, ClassSubject46, Student10  },
                    { ClassSubjectStudent16, ClassSubject46, Student6  },
                    { ClassSubjectStudent17, ClassSubject47, Student7  },
                    { ClassSubjectStudent18, ClassSubject47, Student8  },
                    { ClassSubjectStudent19, ClassSubject48, Student9  },
                    { ClassSubjectStudent20, ClassSubject48, Student10  },

                    { ClassSubjectStudent21, ClassSubject33, Student11 },
                    { ClassSubjectStudent22, ClassSubject33, Student12 },
                    { ClassSubjectStudent23, ClassSubject33, Student13 },
                    { ClassSubjectStudent24, ClassSubject33, Student14 },
                    { ClassSubjectStudent25, ClassSubject34, Student15 },
                    { ClassSubjectStudent26, ClassSubject34, Student11 },
                    { ClassSubjectStudent27, ClassSubject35, Student12 },
                    { ClassSubjectStudent28, ClassSubject35, Student13 },
                    { ClassSubjectStudent29, ClassSubject36, Student14 },
                    { ClassSubjectStudent30, ClassSubject36, Student15 },

                    { ClassSubjectStudent31, ClassSubject37, Student16 },
                    { ClassSubjectStudent32, ClassSubject37, Student17 },
                    { ClassSubjectStudent33, ClassSubject37, Student18 },
                    { ClassSubjectStudent34, ClassSubject37, Student19 },
                    { ClassSubjectStudent35, ClassSubject38, Student20 },
                    { ClassSubjectStudent36, ClassSubject38, Student16 },
                    { ClassSubjectStudent37, ClassSubject39, Student17 },
                    { ClassSubjectStudent38, ClassSubject39, Student18 },
                    { ClassSubjectStudent39, ClassSubject40, Student19 },
                    { ClassSubjectStudent40, ClassSubject40, Student20 },

                    { ClassSubjectStudent41, ClassSubject25, Student21 },
                    { ClassSubjectStudent42, ClassSubject25, Student22 },
                    { ClassSubjectStudent43, ClassSubject25, Student23 },
                    { ClassSubjectStudent44, ClassSubject25, Student24 },
                    { ClassSubjectStudent45, ClassSubject26, Student25 },
                    { ClassSubjectStudent46, ClassSubject26, Student21 },
                    { ClassSubjectStudent47, ClassSubject27, Student22 },
                    { ClassSubjectStudent48, ClassSubject27, Student23 },
                    { ClassSubjectStudent49, ClassSubject28, Student24 },
                    { ClassSubjectStudent50, ClassSubject28, Student25 },

                    { ClassSubjectStudent51, ClassSubject29, Student26 },
                    { ClassSubjectStudent52, ClassSubject29, Student27 },
                    { ClassSubjectStudent53, ClassSubject29, Student28 },
                    { ClassSubjectStudent54, ClassSubject29, Student29 },
                    { ClassSubjectStudent55, ClassSubject30, Student30 },
                    { ClassSubjectStudent56, ClassSubject30, Student26 },
                    { ClassSubjectStudent57, ClassSubject31, Student27 },
                    { ClassSubjectStudent58, ClassSubject31, Student28 },
                    { ClassSubjectStudent59, ClassSubject32, Student29 },
                    { ClassSubjectStudent60, ClassSubject32, Student30 },

                    { ClassSubjectStudent61, ClassSubject17, Student31 },
                    { ClassSubjectStudent62, ClassSubject17, Student32 },
                    { ClassSubjectStudent63, ClassSubject17, Student33 },
                    { ClassSubjectStudent64, ClassSubject17, Student34 },
                    { ClassSubjectStudent65, ClassSubject18, Student35 },
                    { ClassSubjectStudent66, ClassSubject18, Student31 },
                    { ClassSubjectStudent67, ClassSubject19, Student32 },
                    { ClassSubjectStudent68, ClassSubject19, Student33 },
                    { ClassSubjectStudent69, ClassSubject20, Student34 },
                    { ClassSubjectStudent70, ClassSubject20, Student35 },

                    { ClassSubjectStudent71, ClassSubject21, Student36 },
                    { ClassSubjectStudent72, ClassSubject21, Student37 },
                    { ClassSubjectStudent73, ClassSubject21, Student38 },
                    { ClassSubjectStudent74, ClassSubject21, Student39 },
                    { ClassSubjectStudent75, ClassSubject22, Student40 },
                    { ClassSubjectStudent76, ClassSubject22, Student36 },
                    { ClassSubjectStudent77, ClassSubject23, Student37 },
                    { ClassSubjectStudent78, ClassSubject23, Student38 },
                    { ClassSubjectStudent79, ClassSubject24, Student39 },
                    { ClassSubjectStudent80, ClassSubject24, Student40 },

                    { ClassSubjectStudent81, ClassSubject9, Student41 },
                    { ClassSubjectStudent82, ClassSubject9, Student42 },
                    { ClassSubjectStudent83, ClassSubject9, Student43 },
                    { ClassSubjectStudent84, ClassSubject9, Student44 },
                    { ClassSubjectStudent85, ClassSubject10, Student45 },
                    { ClassSubjectStudent86, ClassSubject10, Student41 },
                    { ClassSubjectStudent87, ClassSubject11, Student42 },
                    { ClassSubjectStudent88, ClassSubject11, Student43 },
                    { ClassSubjectStudent89, ClassSubject12, Student44 },
                    { ClassSubjectStudent90, ClassSubject12, Student45 },

                    { ClassSubjectStudent91, ClassSubject13, Student46 },
                    { ClassSubjectStudent92, ClassSubject13, Student47 },
                    { ClassSubjectStudent93, ClassSubject13, Student48 },
                    { ClassSubjectStudent94, ClassSubject13, Student49 },
                    { ClassSubjectStudent95, ClassSubject14, Student50 },
                    { ClassSubjectStudent96, ClassSubject14, Student46 },
                    { ClassSubjectStudent97, ClassSubject15, Student47 },
                    { ClassSubjectStudent98, ClassSubject15, Student48 },
                    { ClassSubjectStudent99, ClassSubject16, Student49 },
                    { ClassSubjectStudent100, ClassSubject16, Student50 },

                    { ClassSubjectStudent101, ClassSubject1, Student51 },
                    { ClassSubjectStudent102, ClassSubject1, Student52 },
                    { ClassSubjectStudent103, ClassSubject1, Student53 },
                    { ClassSubjectStudent104, ClassSubject1, Student54 },
                    { ClassSubjectStudent105, ClassSubject2, Student55 },
                    { ClassSubjectStudent106, ClassSubject2, Student51 },
                    { ClassSubjectStudent107, ClassSubject3, Student52 },
                    { ClassSubjectStudent108, ClassSubject3, Student53 },
                    { ClassSubjectStudent109, ClassSubject4, Student54 },
                    { ClassSubjectStudent110, ClassSubject4, Student55 },

                    { ClassSubjectStudent111, ClassSubject5, Student56 },
                    { ClassSubjectStudent112, ClassSubject5, Student57 },
                    { ClassSubjectStudent113, ClassSubject5, Student58 },
                    { ClassSubjectStudent114, ClassSubject5, Student59 },
                    { ClassSubjectStudent115, ClassSubject6, Student60 },
                    { ClassSubjectStudent116, ClassSubject6, Student56 },
                    { ClassSubjectStudent117, ClassSubject7, Student57 },
                    { ClassSubjectStudent118, ClassSubject7, Student58 },
                    { ClassSubjectStudent119, ClassSubject8, Student59 },
                    { ClassSubjectStudent120, ClassSubject8, Student60 }
                }
            );

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "RoleTable",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { teacherRoleId, "teacher" },
                    { studentRoleId, "student" },
                }
            );

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "UserRoleTable",
                columns: new[] { "Id", "UserId", "RoleId" },
                values: new object[,]
                {
                    { UserRole1, User1, teacherRoleId },
                    { UserRole2, User2, teacherRoleId },
                    { UserRole3, User3, teacherRoleId },
                    { UserRole4, User4, teacherRoleId },
                    { UserRole5, User5, teacherRoleId },
                    { UserRole6, User6, teacherRoleId },
                    { UserRole7, User7, teacherRoleId },
                    { UserRole8, User8, teacherRoleId },
                    { UserRole9, User9, teacherRoleId },
                    { UserRole10, User10, teacherRoleId },
                    { UserRole11, User11, teacherRoleId },
                    { UserRole12, User12, teacherRoleId },
                    { UserRole13, User13, teacherRoleId },
                    { UserRole14, User14, teacherRoleId },
                    { UserRole15, User15, teacherRoleId },
                    { UserRole16, User16, teacherRoleId },

                    { UserRole17, User17, studentRoleId },
                    { UserRole18, User18, studentRoleId },
                    { UserRole19, User19, studentRoleId },
                    { UserRole20, User20, studentRoleId },
                    { UserRole21, User21, studentRoleId },
                    { UserRole22, User22, studentRoleId },
                    { UserRole23, User23, studentRoleId },
                    { UserRole24, User24, studentRoleId },
                    { UserRole25, User25, studentRoleId },
                    { UserRole26, User26, studentRoleId },
                    { UserRole27, User27, studentRoleId },
                    { UserRole28, User28, studentRoleId },
                    { UserRole29, User29, studentRoleId },
                    { UserRole30, User30, studentRoleId },
                    { UserRole31, User31, studentRoleId },
                    { UserRole32, User32, studentRoleId },
                    { UserRole33, User33, studentRoleId },
                    { UserRole34, User34, studentRoleId },
                    { UserRole35, User35, studentRoleId },
                    { UserRole36, User36, studentRoleId },
                    { UserRole37, User37, studentRoleId },
                    { UserRole38, User38, studentRoleId },
                    { UserRole39, User39, studentRoleId },
                    { UserRole40, User40, studentRoleId },
                    { UserRole41, User41, studentRoleId },
                    { UserRole42, User42, studentRoleId },
                    { UserRole43, User43, studentRoleId },
                    { UserRole44, User44, studentRoleId },
                    { UserRole45, User45, studentRoleId },
                    { UserRole46, User46, studentRoleId },
                    { UserRole47, User47, studentRoleId },
                    { UserRole48, User48, studentRoleId },
                    { UserRole49, User49, studentRoleId },
                    { UserRole50, User50, studentRoleId },
                    { UserRole51, User51, studentRoleId },
                    { UserRole52, User52, studentRoleId },
                    { UserRole53, User53, studentRoleId },
                    { UserRole54, User54, studentRoleId },
                    { UserRole55, User55, studentRoleId },
                    { UserRole56, User56, studentRoleId },
                    { UserRole57, User57, studentRoleId },
                    { UserRole58, User58, studentRoleId },
                    { UserRole59, User59, studentRoleId },
                    { UserRole60, User60, studentRoleId },
                    { UserRole61, User61, studentRoleId },
                    { UserRole62, User62, studentRoleId },
                    { UserRole63, User63, studentRoleId },
                    { UserRole64, User64, studentRoleId },
                    { UserRole65, User65, studentRoleId },
                    { UserRole66, User66, studentRoleId },
                    { UserRole67, User67, studentRoleId },
                    { UserRole68, User68, studentRoleId },
                    { UserRole69, User69, studentRoleId },
                    { UserRole70, User70, studentRoleId },
                    { UserRole71, User71, studentRoleId },
                    { UserRole72, User72, studentRoleId },
                    { UserRole73, User73, studentRoleId },
                    { UserRole74, User74, studentRoleId },
                    { UserRole75, User75, studentRoleId },
                    { UserRole76, User76, studentRoleId },
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "UserRoleTable", keyColumn: "Id", keyValues: new object[]
            {
                UserRole1, UserRole2, UserRole3, UserRole4, UserRole5, UserRole6, UserRole7, UserRole8, UserRole9, UserRole10,
                UserRole11, UserRole12, UserRole13, UserRole14, UserRole15, UserRole16, UserRole17, UserRole18, UserRole19, UserRole20,
                UserRole21, UserRole22, UserRole23, UserRole24, UserRole25, UserRole26, UserRole27, UserRole28, UserRole29, UserRole30,
                UserRole31, UserRole32, UserRole33, UserRole34, UserRole35, UserRole36, UserRole37, UserRole38, UserRole39, UserRole40,
                UserRole41, UserRole42, UserRole43, UserRole44, UserRole45, UserRole46, UserRole47, UserRole48, UserRole49, UserRole50,
                UserRole51, UserRole52, UserRole53, UserRole54, UserRole55, UserRole56, UserRole57, UserRole58, UserRole59, UserRole60,
                UserRole61, UserRole62, UserRole63, UserRole64, UserRole65, UserRole66, UserRole67, UserRole68, UserRole69, UserRole70,
                UserRole71, UserRole72, UserRole73, UserRole74, UserRole75, UserRole76
            });

            migrationBuilder.DeleteData(schema: "SchoolUser", table: "RoleTable", keyColumn: "Id", keyValues: new object[]
            {
                teacherRoleId, studentRoleId
            });

            // Remove data from ClassSubjectStudentTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "ClassSubjectStudentTable", keyColumn: "Id", keyValues: new object[]
            {
                ClassSubjectStudent1, ClassSubjectStudent2, ClassSubjectStudent3, ClassSubjectStudent4, ClassSubjectStudent5,
                ClassSubjectStudent6, ClassSubjectStudent7, ClassSubjectStudent8, ClassSubjectStudent9, ClassSubjectStudent10,
                ClassSubjectStudent11, ClassSubjectStudent12, ClassSubjectStudent13, ClassSubjectStudent14, ClassSubjectStudent15,
                ClassSubjectStudent16, ClassSubjectStudent17, ClassSubjectStudent18, ClassSubjectStudent19, ClassSubjectStudent20,
                ClassSubjectStudent21, ClassSubjectStudent22, ClassSubjectStudent23, ClassSubjectStudent24, ClassSubjectStudent25,
                ClassSubjectStudent26, ClassSubjectStudent27, ClassSubjectStudent28, ClassSubjectStudent29, ClassSubjectStudent30,
                ClassSubjectStudent31, ClassSubjectStudent32, ClassSubjectStudent33, ClassSubjectStudent34, ClassSubjectStudent35,
                ClassSubjectStudent36, ClassSubjectStudent37, ClassSubjectStudent38, ClassSubjectStudent39, ClassSubjectStudent40,
                ClassSubjectStudent41, ClassSubjectStudent42, ClassSubjectStudent43, ClassSubjectStudent44, ClassSubjectStudent45,
                ClassSubjectStudent46, ClassSubjectStudent47, ClassSubjectStudent48, ClassSubjectStudent49, ClassSubjectStudent50,
                ClassSubjectStudent51, ClassSubjectStudent52, ClassSubjectStudent53, ClassSubjectStudent54, ClassSubjectStudent55,
                ClassSubjectStudent56, ClassSubjectStudent57, ClassSubjectStudent58, ClassSubjectStudent59, ClassSubjectStudent60,
                ClassSubjectStudent61, ClassSubjectStudent62, ClassSubjectStudent63, ClassSubjectStudent64, ClassSubjectStudent65,
                ClassSubjectStudent66, ClassSubjectStudent67, ClassSubjectStudent68, ClassSubjectStudent69, ClassSubjectStudent70,
                ClassSubjectStudent71, ClassSubjectStudent72, ClassSubjectStudent73, ClassSubjectStudent74, ClassSubjectStudent75,
                ClassSubjectStudent76, ClassSubjectStudent77, ClassSubjectStudent78, ClassSubjectStudent79, ClassSubjectStudent80,
                ClassSubjectStudent81, ClassSubjectStudent82, ClassSubjectStudent83, ClassSubjectStudent84, ClassSubjectStudent85,
                ClassSubjectStudent86, ClassSubjectStudent87, ClassSubjectStudent88, ClassSubjectStudent89, ClassSubjectStudent90,
                ClassSubjectStudent91, ClassSubjectStudent92, ClassSubjectStudent93, ClassSubjectStudent94, ClassSubjectStudent95,
                ClassSubjectStudent96, ClassSubjectStudent97, ClassSubjectStudent98, ClassSubjectStudent99, ClassSubjectStudent100,
                ClassSubjectStudent101, ClassSubjectStudent102, ClassSubjectStudent103, ClassSubjectStudent104, ClassSubjectStudent105,
                ClassSubjectStudent106, ClassSubjectStudent107, ClassSubjectStudent108, ClassSubjectStudent109, ClassSubjectStudent110,
                ClassSubjectStudent111, ClassSubjectStudent112, ClassSubjectStudent113, ClassSubjectStudent114, ClassSubjectStudent115,
                ClassSubjectStudent116, ClassSubjectStudent117, ClassSubjectStudent118, ClassSubjectStudent119, ClassSubjectStudent120,
            });

            // Remove data from ClassSubjectTeacherTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "ClassSubjectTeacherTable", keyColumn: "Id", keyValues: new object[]
            {
                ClassSubjectTeacher1, ClassSubjectTeacher2, ClassSubjectTeacher3, ClassSubjectTeacher4,
                ClassSubjectTeacher5, ClassSubjectTeacher6, ClassSubjectTeacher7, ClassSubjectTeacher8,
                ClassSubjectTeacher9, ClassSubjectTeacher10, ClassSubjectTeacher11, ClassSubjectTeacher12,
                ClassSubjectTeacher13, ClassSubjectTeacher14, ClassSubjectTeacher15, ClassSubjectTeacher16,
                ClassSubjectTeacher17, ClassSubjectTeacher18, ClassSubjectTeacher19, ClassSubjectTeacher20,
                ClassSubjectTeacher21, ClassSubjectTeacher22, ClassSubjectTeacher23, ClassSubjectTeacher24,
                ClassSubjectTeacher25, ClassSubjectTeacher26, ClassSubjectTeacher27, ClassSubjectTeacher28,
                ClassSubjectTeacher29, ClassSubjectTeacher30, ClassSubjectTeacher31, ClassSubjectTeacher32,
                ClassSubjectTeacher33, ClassSubjectTeacher34, ClassSubjectTeacher35, ClassSubjectTeacher36,
                ClassSubjectTeacher37, ClassSubjectTeacher38, ClassSubjectTeacher39, ClassSubjectTeacher40,
                ClassSubjectTeacher41, ClassSubjectTeacher42, ClassSubjectTeacher43, ClassSubjectTeacher44,
                ClassSubjectTeacher45, ClassSubjectTeacher46, ClassSubjectTeacher47, ClassSubjectTeacher48
            });

            // Remove data from StudentTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "StudentTable", keyColumn: "Id", keyValues: new object[]
            {
                Student1, Student2, Student3, Student4, Student5, Student6, Student7, Student8, Student9, Student10,
                Student11, Student12, Student13, Student14, Student15, Student16, Student17, Student18, Student19, Student20,
                Student21, Student22, Student23, Student24, Student25, Student26, Student27, Student28, Student29, Student30,
                Student31, Student32, Student33, Student34, Student35, Student36, Student37, Student38, Student39, Student40,
                Student41, Student42, Student43, Student44, Student45, Student46, Student47, Student48, Student49, Student50,
                Student51, Student52, Student53, Student54, Student55, Student56, Student57, Student58, Student59, Student60
            });

            // Remove data from TeacherTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "TeacherTable", keyColumn: "Id", keyValues: new object[]
            {
                Teacher1, Teacher2, Teacher3, Teacher4, Teacher5, Teacher6, Teacher7, Teacher8,
                Teacher9, Teacher10, Teacher11, Teacher12, Teacher13, Teacher14, Teacher15, Teacher16
            });

            // Remove data from UserTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "UserTable", keyColumn: "Id", keyValues: new object[]
            {
                User1, User2, User3, User4, User5, User6, User7, User8, User9, User10,
                User11, User12, User13, User14, User15, User16, User17, User18, User19, User20,
                User21, User22, User23, User24, User25, User26, User27, User28, User29, User30,
                User31, User32, User33, User34, User35, User36, User37, User38, User39, User40,
                User41, User42, User43, User44, User45, User46, User47, User48, User49, User50,
                User51, User52, User53, User54, User55, User56, User57, User58, User59, User60,
                User61, User62, User63, User64, User65, User66, User67, User68, User69, User70,
                User71, User72, User73, User74, User75, User76
            });

            // Remove data from ClassSubjectTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "ClassSubjectTable", keyColumn: "Id", keyValues: new object[]
            {
                ClassSubject1, ClassSubject2, ClassSubject3, ClassSubject4, ClassSubject5,
                ClassSubject6, ClassSubject7, ClassSubject8, ClassSubject9, ClassSubject10,
                ClassSubject11, ClassSubject12, ClassSubject13, ClassSubject14, ClassSubject15,
                ClassSubject16, ClassSubject17, ClassSubject18, ClassSubject19, ClassSubject20,
                ClassSubject21, ClassSubject22, ClassSubject23, ClassSubject24, ClassSubject25,
                ClassSubject26, ClassSubject27, ClassSubject28, ClassSubject29, ClassSubject30,
                ClassSubject31, ClassSubject32, ClassSubject33, ClassSubject34, ClassSubject35,
                ClassSubject36, ClassSubject37, ClassSubject38, ClassSubject39, ClassSubject40,
                ClassSubject41, ClassSubject42, ClassSubject43, ClassSubject44, ClassSubject45,
                ClassSubject46, ClassSubject47, ClassSubject48
            });

            // Remove data from SubjectTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "SubjectTable", keyColumn: "Id", keyValues: new object[]
            {
                Subject1, Subject2, Subject3, Subject4, Subject5, Subject6, Subject7, Subject8
            });

            // Remove data from ClassTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "ClassCategoryTable", keyColumn: "Id", keyValues: new object[]
            {
                ClassCategory1, ClassCategory2, ClassCategory3, ClassCategory4, ClassCategory5, ClassCategory6,
                ClassCategory7, ClassCategory8, ClassCategory9, ClassCategory10, ClassCategory11, ClassCategory12
            });

            // Remove data from StreamTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "ClassStreamTable", keyColumn: "Id", keyValues: new object[]
            {
                ClassStream1, ClassStream2
            });

            // Remove data from BatchTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "BatchTable", keyColumn: "Id", keyValues: new object[]
            {
                Batch1, Batch2, Batch3, Batch4, Batch5, Batch6
            });

        }
    }
}
