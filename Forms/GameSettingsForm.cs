/* Copyright (C) 2019-2020 Nemirtingas
   This file is part of the SmartGoldbergEmu Launcher

   The SmartGoldbergEmu Launcher is free software; you can redistribute it and/or
   modify it under the terms of the GNU Lesser General Public
   License as published by the Free Software Foundation; either
   version 3 of the License, or (at your option) any later version.

   The SmartGoldbergEmu Launcher is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
   Lesser General Public License for more details.

   You should have received a copy of the GNU Lesser General Public
   License along with the SmartGoldbergEmu Launcher; if not, see
   <http://www.gnu.org/licenses/>.
 */
using HeaderReader;
using OSUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics.Eventing.Reader;
using static SmartGoldbergEmu.GameSettingsForm;
using System.Security.Policy;
using System.Threading;
using System.Runtime.InteropServices.ComTypes;

namespace SmartGoldbergEmu
{
    public partial class GameSettingsForm : Form
    {
        static Dictionary<string, List<string>> steamapi_hashsmap = new Dictionary<string, List<string>>
        {
            ["steam_api.dll"] = new List<string>{
                "bdadec82e81744aec226bd43bf755fab12e92a19522a8728da2bce87528bcf8c",//100
                "ae3bb5af60abb6072b62d37e51af1ad4520a417263027e9df65378f44ced49d7",//101
                "2548a60d677970efd11fcfe4049971726c366515d9cae781775a00c3a9f0eb88",//102
                "4a04b41dcdd87b681633325d4fc11ed670b81f9acc25f4292069cfd9d75a1b8d",//103
                "f52cc64c0b7c513cdb75d2919023a06c06ca141f79b5101a86a7992b54a36401",//104
                "8637ef955d8e86be85f2f3070f7ba94c95fb4c8c845ee2450ee066933f582e13",//105
                "8640d75aa8024df84d26101dc11d6f70fd431cff3810a397ab1633283281ecf3",//106
                "57b47b822e4c3a29031dec7b613cfb5c86f56018e00a7a004f0e155576507080",//107
                "59ed854645eaa237463eb22f3c5a25f726d7cb2f29440f00a1ec0a4d73d0207a",//108
                "8d567f209dffdac48e3f65acdf94b33d076b908df63eb531602437987a708b82",//109
                "106f8d28bcb48cc97993a71e8f221895df23e01cd90f03df53de0ffa4faf59aa",//110
                "9efe2c8336325f6f186af073213b84f6258643517d175bc8432e196b70722394",//111
                "83dbdd0abfac699b5c8670334554458406ee1d12f701abd762fd0cb5e1738c6f",//112
                "11c7a5df676ffe1aa0a498103d061e8c594a3d9df3b9cc23e5b5f642b12f7163",//113
                "28888816852342910d98f293c3fea5e704ff8177f8fa5e53f76135d48fb23a99",//114
                "fad5e776959f16666ea2b4ee544cadd37240a1dc35297aa3b63a14492050ef3f",//115
                "fa91d03d2a73939b6354c7eaf8062eb1dcdfd1b826cb1db35dfbaffebb65e9b9",//116
                "901f65de91d76c2865ac0dcb15c7055a8dd9467b583e1f5932a09123b359802a",//117
                "b537ed9f0c7dafd722490ee6c1d07318cc19d88bd7a81c3a44d17a154d3db6bb",//118
                "b0fd893eaa8a225510389e04c0802312539a01fd2eb3a1a8a38005cee7f1d10f",//119
                "61846524e09e81eeed65629cf3d65668773c377efefb236088d366c9068aee63",//120
                "b55054a9d9287c704b8e0ad3acfef1ea5c3fa6982b20b7e36466dc76a6ad8925",//121
                "8c073e0d2ca39d1e986bec348f988303357be5c495ccf6e0415802b86eae3534",//122
                "abfedd473b3f4a9597bbdc90d20f4b6f696bb2ebb937a03177461df695430ad6",//123a
                "6756b377865f55e1c8c8a21526f87559741f204036ce33e5be594d3e13b53bce",//125
                "716d8eff89d52b88f033e1a3c5b1fcf926dc33bf60f1490e187688e0c332410b",//126a
                "0aa533ac3ab500992d9c21905c8194afe7695dd893ed2512033089d5165bcfe9",//127
                "fd16fba7a64afdcfcad2a935337432400c8c528e3f210a6672254f75d39bad7e",//128
                "4c83d75fcaa6166be46f0bf3c0acdf6b5ffeadff673ab64a7cdeac8ff3f21ac1",//129a
                "5896ec292aba68619e3e18a720573feaf8f2bcb47bf8013c0eec8b1f8448b82e",//130
                "025a1fd2b3e81a1a3d474b1707e3696cbc1a0ff2dee65c4f74b186e688f01ec9",//131
                "586eaa7a024ec2de2ac1d8732e7d5824f3a6ec1467ea0165023f805c06b49925",//132
                "3648e216ecf0c6a474b07e79d39394911bfb9b5c85a52c20886aec1e9709f82d",//133b
                "0bdba265a140a963464b4fad889d7a8dede05aba8c914ab2e83026255b6a2f41",//134
                "7cc4c0c0d49389630516a1ecb8107e89f61b6ce3a72a41bbde1042b85abdfcdd",//135
                "64eb5531bbee05db713dcd47e4a74c59e27bf067b0cfe9603eeaea5a4601fe90",//135a
                "3e3915b8c3baf012cceb3baa4e7ce0966d61939d76a6f1120f276627e09f9022",//136
                "5d58f6ea6d46d44cc8422f3bc0f76b9a95f5e7e14007887a8e1cf54fa77a8eac",//137
                "dc204ea6ad73ae127a2f6977055f861dc9c850a3c14d66e0810b8650cc1340a0",//138a
                "5b6ef90f822209180ed5cafecb90af849ee84bcf6281eeb21be2f89b3b5c89b6",//139
                "fe302b9cf000b5b56b8f48df9a6737fc43b1c225db91306e92c779cae0d2908d",//140
                "af17df745250d1814eaa274fff7b0faeb43381e6762e026267e5859778477abd",//141
                "d99d425793f588fbc15f91c7765977cdd642b477be01dac41c0388ab6a5d492d",//142
                "765fb6498ba7d262e63b2dba19c09f63de4dd0a092b5499828ec8949aa183f82",//143
                "765fb6498ba7d262e63b2dba19c09f63de4dd0a092b5499828ec8949aa183f82",//144
                "d085fd53025946cb33bd44adcd022a2f9ca9e804035b1a3cf67d04126b94ce5b",//145
                "14a33924adc495f3c27dde65ae4a8007c8acdc1454fcf87f02d12040cd751741",//146
            },
            ["steam_api64.dll"] = new List<string>{
                "439a0c94c03bc465a62f188a797950d6c144ee95380b888ef4e1695ae4dff7bd",//111
                "f7385a23e05b834f5a95bb79ad3a47d810848598355af176e4837e111ddd3737",//112
                "fa7d1199682a0bf4ff7c94746cf36b99410c7ebe4379f0123adc2be3fd121ec2",//113
                "34bf3de77e465c40187eed288e198a6b004af10e2f981f40178ada1df31dacfa",//114
                "eef45bfff054893645d323e972fa036309476baf4d4c75c6cc5cda8dfe8edfae",//115
                "21b25725681f34fd282f66bfd5befc8f120f20b6efc9fdc5904aa9d1e589c9c9",//116
                "d8a70aca9cd9a58deade73a1410b040b61f65cce959f194b93b5a9decc6d859a",//117
                "489a616cd84cbbfc516f71067bf4ce7596811f2526624501faf5ebf190eef906",//118
                "04150dc67ea3dcceb465884ed9df5c6ed5eb0953575560475d1434186180b596",//119
                "8ab1b0786e8cc05417027177d6f8436eecd937cbc194f5e5a60b2e24ccc517da",//120
                "64089b81a09d15743694f8d2d76cdddcff7f86a2560948e8398fdab90c648e7c",//121
                "7481fb3e322524f97ffef44b242f3a42ef53462bf79b1f3370d973089bcc3fec",//122
                "fc20547408a7c34f0bd4946a34c21aab48a75e3b98dce9e55969f486d37b212f",//123a
                "1890beb1f46ba0b234b3fdc71f014bc53119d0c543943ae997abd7a3027a0a9a",//125
                "2c742b07f3153ff6f52f2744a8ad03eb6d614ff87466bfb3a8bfa8cdd8a2706d",//126a
                "18005605f0e9f60fa47390e7fb174a3aef1ab00b5088f8d3b3419f57b3cb5e6f",//127
                "f9e0ef76a8b23adcec217476b639874d3b9a46740e2c84bf2772a017990b75be",//128
                "d103ecc2a6f862daf08d7a47cb732697ba0512aba2f757336d48cbee32b19f5f",//129a
                "b81e6554c17c3f68e0285b0d6ec5f43aa26e8f7195f5f881806539277a91d853",//130
                "7aeb040d3d53b715eb1715f1caa49e30c10341ddbcc380cb82bc6a0b1fea0134",//131
                "fcdbedff3ca84c987a5968b08ba957b9f88b78736e3570f6157ac6f8ce0302ce",//132
                "08bd0152356e5619ee56a6714ac951b6800dbb21821693a4efaf85278442c60a",//133b
                "81321a5cb72ae3f81243fd0b0d8928a063ca09129ab0878573bd36a28422ec4c",//134
                "e61f3a4c3833ce48629d48d655c124f0ed552198d5a6cf82eb2f431688c00d2a",//135
                "0ee64af072052ab95438fb8e054a68e4d392de941ef867a0124992aafccc7938",//135a
                "5c6dabbd723a284d6b9a70303678c60421485bceb51def107f273f0f3730ed28",//136
                "71af8666392acad2080a816b9f1196fe9ccb950e1db8a549f8312c4d231f55a8",//137
                "f12cf470954d9d956f7d44f9eb84659890c5722a021548ab88710340c0965230",//138a
                "38f6a1dd1e738e142160322638dae7b88dabcc30eea3f15c58eb08c5341f9b29",//139
                "a0a5ac6dcd3d9255bb9c71bae3a71b6bf90c56f4fce46ff0d65533d7ef89b8d8",//140
                "2197363bfcf05fbdee84afd7dec6d58721587cb3dbf57c0f02b38e82c5cb5d41",//141
                "b8246e1a629b945fe526b24c3e4f002c4f6eb86aa1b5ed9744399f22a0d2ca9f",//142
                "e61ac9a9ac216d56abc70aaeefedc11708ef45aa1aa48f1dd313adfd9aa99150",//143
                "e61ac9a9ac216d56abc70aaeefedc11708ef45aa1aa48f1dd313adfd9aa99150",//144
                "240a76316437a6732335df2c649596275b6ee7c3e27b9ae10baff1f6e4a8df8e",//145
                "f1eb582e607a1e43cdb1654bfb7cb29ad46f6728b3fb89a14f7727e0e8daab69",//146
            },
            ["libsteam_api.so"] = new List<string>{
                // linux 32 bits
                "759fda30fadc1ebb94af842ae261090fdd69f748a8c806f3b817e0472d5e4a1c",//106
                "759fda30fadc1ebb94af842ae261090fdd69f748a8c806f3b817e0472d5e4a1c",//107
                "0821feea4c48182c54990dedd7de5fc69fa09bfc6c2776a7a46675329981e85f",//108
                "7faa5a8362442f65b2e2fb0cde1617fa7d06d9bb8510a4950c3155b3e78c7aaf",//109
                "2ad1bf50e18fe5d7fd4949889f8acf223678342f5dfeabc60dfe8a2bef59b6d5",//110
                "15b1bc4a7668468ca2eabcaa076a1b15b9e9d3da632fcc561e7d1371fc5c70f9",//111
                "8a3966f9e8554af389797eb027400e67138e22e83b589a6ec32020cde92eb5cb",//112
                "71028ec1a4c0eb3bc041661c081ad81c0730a4577716c617d53e634f3219e886",//113
                "2c5783cd8aaddec4a141b57e65a2ad7435477dd5535206da0b6dfb147967d100",//114
                "6376c1f2d025bedb5e5a0d4d716a666ad4a335defe237f3bfd18400dc2d7e8da",//115
                "e7d5e152132ec990f82c05f46e32add1eb08c15c1a3725236ac1e45ae277bf9a",//116
                "3dcbb667cd87c266586c7aca5c54634113830e4b5c0074e591219fd8a9dc96c6",//117
                "82f4bb6d6e3eea9be99015295204dfe01dadabe5de6e67452aa47c28640e9c5b",//118
                "3de58c539bc114e283f387d536e73f8cab23333a65987c78758696512de036f7",//119
                "28b0458c99768a1eff8e426ae8696843b3092dd8624a20e063609a937f008d66",//120
                "59bb558e1ded979210e73ff59078ae7470dce39809355781dd77b3a3659a03f8",//121
                "1f376606509d32d1b6fc94e345638c339aa7dcec9dd244b65342459664023d2f",//122
                "86992dd3c183fc8ad5ee5ec93d9336d589031d3758a0309e2503f32e546c135a",//123a
                "50e951d294c19153b7e04afa02b5271b2ea2ec30a861ed9aace8c102224e914f",//125
                "0558da5827961194559aaa6747d9123fe3a903d7fac6f5b6b89d00de935d551c",//126a
                "cf4475a2528a5e944f092ea8cb0215ab8816c3ed141c7039233993233c669533",//127
                "83c02f3b64c97f7bef0d34af9f90945d88e7a030b2ac2782445dcc39bfa78e22",//128
                "6438aeb632f43fd97decac5054b6767332bcbe2d3d0f67e3407c3eb51d15a0f9",//129a
                "a1161d1763c87fc2459e02eba9d2438cc6f7c222b3705ff7e71b88119f266397",//130
                "6810a98e5afdb011ded9c46911276d2cd8f24e2d12adb871add5445467dc7dc7",//131
                "85c2c78de2a105a1efdf702929b6542f57a5bd8368bc625e7f7ad3b12e5d93e4",//132
                "0197fe3ab4e8f95ee74f05765a1b30c5d287d00b65b9745eb83b89628b3202d0",//133b
                "8d601e70ba1e344ad34d41da6a64b01d17c95bb384ccbb4eaf23dd2c3a8752dc",//134
                "3c7f53c202c2f11b4c14347079e1aec895860ca21e3640d9f887ce60c86f23cb",//135
                "023d6eb885f81511a46e4d6197c9eeb1a774691a943dffc4bbbc2b6a8d73c61e",//135a
                "84a4bd6d397178934b93848e373187153989d05b9746a0a957edd0a18a3ad798",//136
                "e04ba87f2585f6404687018c1977aabe2a528e14d6520578c85e182b05c9485e",//137
                "9ca30e71c01e97c0731069f9e282749c61bc373fbe42e4c5716abe305a4d296f",//138a
                "9dce42fdb03a378264d7d0b30d9bcf7fd1e34a4355217c74dc3070ebd3deca18",//139
                "3eac397604987251815fbd1d6bb2fe852ecd6a7e1bc41006743f92a097ceddcd",//140
                "4d0a7713899be8cc8232d88a817964e4424a9de0f243b2afb73963610ce716fa",//141
                "0a429d5d6e82025b83b4a05fc5d70a4997af264592870fe25482964e9e1d73b6",//142
                "e878ff1facbcf74751ae9f1ce47cb074ed6e21001a3118c60ff3e174fe2abb52",//143
                "e878ff1facbcf74751ae9f1ce47cb074ed6e21001a3118c60ff3e174fe2abb52",//144
                "295c7888bd7ab80f44fba0f5a64ca9e52995e175288b53085e57ce7d0968dd32",//145
                "b207088245ac1d49c6e5aaa8b80720bda6eb866af422a23d95b46c8846115cce",//146
                // linux 64 bits
                "cf204804785cab40950be9704066df48a82c00fd485a4a03210c39badef7dc90",//126a
                "601bb40efe85ba1abef433103660488eaa43cf913351add117c172068a184472",//127
                "515e9697933f9e2584daf4691ddcd94a6ec8694b1480e7c5e19d45627c25642b",//128
                "8a3278b8905576f4856bd0ea55964bf0ffa28ec12b3b1c19d74a0153ddc15e9b",//129a
                "fcee334d65b412cb3e518b98aef2a828be0c3cd035f9c36e74d805564f67fc1f",//130
                "6e9a5ac980affba29f1d0468c09aeda454c4ce6b7a2701420a08588e987362f9",//131
                "988cd7191c5d38a6e71a2b2f7322d44a088c5d6922141a30217af4fb43372259",//132
                "54e435a9256d93f0e1dd1960fe3dd4da9c6cd21004b005186bef30b1428f194a",//133b
                "acb705c7006a7c0ef615c64a0e038f30e9366aa5c22a7bb5cb5137411d5c29d6",//134
                "79130b2d8881a1f4bd5acc6e2b1be343ed8d04b4c014d70544557290bbf54509",//135
                "13189167d2ef6078f2d7555727b410ba7b1a750a27456b48cea8505bd6f1b216",//135a
                "9799a43c6a2d32b9404c05af2858ddd9d86a7379778d8af4bfbcf0be043456c0",//136
                "1005f5142e8fd4bec0e79ad709b6cb5bd2d14a8576e3ceecdbd22bbe203c601f",//137
                "7cdcda1258f30b80120af56f2c945f1cadeee449693f5fb12dc52541acdf727c",//138a
                "07b2b9fb8d6108001fcfd424c74146d6802344e6d02bbc128e76b0e4ac068e92",//139
                "cbd8a4eb08c42df2bd2323c297ff392294abd85ae06086cebb40f38a3959b4bc",//140
                "086c22c5a2dc6d8b4da0c3334ffd1641c0d614160e7e3073bd42fbbdf39a1dcf",//141
                "402fa02b6ca9b105955445d58ef1b0cf7c81036fa82e44929b29fe4dda793813",//142
                "df8351b5ec197098960c7e107e807ebf1611af73271d0e3bb164f2d587225663",//143
                "df8351b5ec197098960c7e107e807ebf1611af73271d0e3bb164f2d587225663",//144
                "d329759ce31f90530868bc5c199a330ae197563b5a12a89d8e9c5c06299995e9",//145
                "528430be2727b3d5e04e7401f1fca662726d705fcc952f6c6b16c6b5c942b481",//146
            },
            ["libsteam_api.dylib"] = new List<string>{
                "bd706d6742718da29092fd76fe9598334a96ad1aa61436099e6526d45f957f22",//109
                "cb4d5189534b67ed18f23dfb36dc90a3c41384180aaebba882f376f39d1ca619",//110
                "b9a49e125cd20f02324e57cd1331ae195a0166007cc4b813f55ab528805edccd",//111
                "d1b7ee13c010115f6a4ab492050e43560f421545bcb743bf61f880ec8376bb28",//112
                "ea7b9766fbff14c51adf4c30a20e199380afc903cfcbbc7e3b1dd209f7c4c0c1",//113
                "c148c351738efb75cd0656d328f78050ccf91584e71f00e1068a5a53cc527778",//114
                "83f36bd0a34b4b48c9df13de7be29ef631a05c526f804e2f08035fec108a84f8",//115
                "687b8aa83a83c43d132479e4f27d49e7bd9202778472999770aba8cc1e6a1e42",//116
                "707191942297aaea8cd401d6d79e050ddae4d2bbcaebf68b104fae5e1d1af63e",//117
                "045bff7d772015024348fd1ea8c61178c9af80ed3f8812a0683099e5922d4b39",//118
                "883ff14ab687fbcb84387d128440adb8ff06fb08638f9fd77ce8c51b40cf13e3",//119
                "c2fde13c9e751dfcd9fdcb1521176f5bc9d4811240037be143374487f2c3e72c",//120
                "26d8a7c5140c1ce6ad890f13354b597dd30ebbbac0537de1bedfbf2b2c82a683",//121
                "21bd8e40f5cb6ce4b419f9096ad2ad1db0148f2cad9e95b97a2b306de08f8bfb",//122
                "d8e58b6512519717c3fcf32a3cc433739731076d363f5421e6e089ce3f9b8d57",//123a
                "b36a5865cca76d2ecc1fb8ee86b1196137f3f0fae14c7ddce9b14d0b6e829607",//125
                "3047e4e2259cd53d239e526f9578414f1f187a4da9aa66d90d5a5c70f222fca1",//126a
                "bdf90f6deb355fd68374534e3ced7665fad5523c3a738ee70a29d1aa54e05960",//127
                "740cbccfe381bf87e690e6683095cc9376fe332487cfff2fbf8941d25ff4235d",//128
                "bc28d3f83b2ed02e2952cfbe12e2ea1f4c5c8f8f70688630ddb6831c9f4caf05",//129a
                "cc82161cd343e66603bebdf72a92eb051b70e28e668457d5d0512fb15242a119",//130
                "35fc0065a2b6f8fdde96d96938a792dcdb6f38c57af257b8827237752e78b1fd",//131
                "6a3cad487e9d52aa7e481242a74a00d3aec7f0dfff5b64ba62307a0360a3efeb",//132
                "97ea54ddea58dcb346b28dfb69c726df1f8ca59c86f71e0e7d6a0843e2829928",//133b
                "6d0ccd48b969c7f39a8fff36cd49bb40d2fc87ffff1fbc4eb2db3d8d95300c28",//134
                "966d653fe8b9e94f47d6ed9c40a6908b447a051e9bb067c8018d57ed9f41207e",//135
                "b170c4cef801608bca7530e33ea082027857d9c09bea729873dee97f60e046d6",//135a
                "097d761ae58b3fcc270e945db2e32ee1dc13cfe6351f331f1de93dd20d8ed5f4",//136
                "c224bdca2e4abce7f8c54c1f387c6b40fc9478e72546a5befaed22d7dab61fc8",//137
                "baad1f85bba07ea2e0c0d85924ab2a288cac4252a0c4aef817def6ff81d033ed",//138a
                "cc088fccdd0c8d7129905f683fd80e38405d6ed332b65f3e9b4604e557d902c5",//139
                "d7cbeb6338c6067bb662961bffaa8d2ec300893a24f03a7183ee1df57aa15185",//140
                "bbf06bad9a5df00e1d065da0638b4c9f1cd320ffdcb9a39ad9c6da2be1d26ba1",//141
                "41dc3afbe16368e0e54624d561ed45ab85186e7e8641176d81dfdf4b414068f9",//142
                "1baed9e65c5f583b685c91cf4231d8e96be9748f908752a0c1b65ff2106dc85e",//143
                "1baed9e65c5f583b685c91cf4231d8e96be9748f908752a0c1b65ff2106dc85e",//144
                "60b52babbb2a132f9377d4f0a829aeb5b8c5295b0792f2cfe4dacec7a49e1c51",//145
                "dd19abd471149617d5b85e390d707806f689b96ee67e014f32769b4cf18e2a1c",//146
            }
        };
        public GameConfig Modified_app { get; private set; }


        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public void SetApp(GameConfig app)
        {
            game_name_edit.Text = app.AppName;
            game_folder_edit.Text = app.StartFolder;
            game_exe_edit.Text = app.Path;
            game_appid_edit.Text = app.AppId.ToString();
            game_parameters_edit.Text = app.Parameters;
            x64_checkbox.Checked = app.UseX64;
            local_save_edit.Text = app.LocalSave;
            foreach (string ip in app.CustomBroadcasts)
            {
                try
                {
                    ip_listBox.Items.Add(IPAddress.Parse(ip));
                }
                catch { }
            }
            foreach (string env_var in app.EnvVars)
            {
                listBox_env_var.Items.Add(env_var);
            }

            switch (OSDetector.GetOS())
            {
                case OsId.Windows:
                    break;
                case OsId.Linux:
                    textBox_env_var_key.Cue = "LD_PRELOAD";
                    textBox_env_var_value.Cue = Path.Combine(OSFuncs.GetEmuApiFolder(app.UseX64), OSFuncs.GetSteamAPIName(app.UseX64));
                    break;
                case OsId.MacOSX:
                    textBox_env_var_key.Cue = "DYLD_PRELOAD";
                    textBox_env_var_value.Cue = Path.Combine(OSFuncs.GetEmuApiFolder(app.UseX64), OSFuncs.GetSteamAPIName(app.UseX64));
                    break;
            }

            ExecutableHeaderReader reader;
            if ((reader = new PeHeaderReader(app.Path)).IsValidHeader ||
                (reader = new ElfHeaderReader(app.Path)).IsValidHeader ||
                (reader = new MachOHeaderReader(app.Path)).IsValidHeader)
            {
                x64_checkbox.Checked = !reader.Is32BitHeader;
            }

            checkBox_disableOverlay.Checked = app.DisableOverlay;
            checkBox_DisableNetworking.Checked = app.DisableNetworking;
            checkBox_DisableLANOnly.Checked = app.DisableLANOnly;
            checkbox_offline.Checked = app.Offline;
            checkBox_EnableHTTP.Checked = app.EnableHTTP;
            checkBox_DisableAvatar.Checked = app.DisableAvatar;
            checkBox_DisableAchNotif.Checked = app.DisableAchNotif;
            checkBox_DisableSQuery.Checked = app.DisableSQuery;

            Modified_app = app.Clone();

            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (game_appid_edit.Text != "0")
            {
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "DLC.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "DLC.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        DLC_add.Text = streamReader.ReadToEnd();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "DLC.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "DLC.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        DLC_add.Text = streamReader.ReadToEnd();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "subscribed_groups.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "subscribed_groups.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        sg_add.Text = streamReader.ReadToEnd();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "stats.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "stats.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        stat_add.Text = streamReader.ReadToEnd();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "app_paths.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "app_paths.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        Apppt_add.Text = streamReader.ReadToEnd();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "depots.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "depots.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        depots_add.Text = streamReader.ReadToEnd();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "force_account_name.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "force_account_name.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        force_account_name_add.Text = streamReader.ReadLine();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "force_language.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "force_language.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        force_langugae_add.Text = streamReader.ReadLine();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "force_listen_port.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "force_listen_port.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        force_listen_port_add.Text = streamReader.ReadLine();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "force_steamid.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "force_steamid.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        force_steamidpoigri_add.Text = streamReader.ReadLine();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "subscribed_groups_clans.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "subscribed_groups_clans.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        clan_tag_add.Text = streamReader.ReadLine();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "remote", "serverbrowser.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "remote", "serverbrowser.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        Server_add.Text = streamReader.ReadLine();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "remote", "serverbrowser_favorites.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "remote", "serverbrowser_favorites.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        FavServ_add.Text = streamReader.ReadLine();
                    }
                }
                if (File.Exists(Path.Combine(game_emu_folder, "remote", "serverbrowser_history.txt")))
                {
                    using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(game_emu_folder, "remote", "serverbrowser_history.txt"), FileMode.Open), Encoding.ASCII))
                    {
                        HisServ_add.Text = streamReader.ReadLine();
                    }
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);

            Directory.CreateDirectory(Path.Combine(game_emu_folder, "steam_settings"));
            Directory.CreateDirectory(Path.Combine(game_emu_folder, "remote"));

            PisanjeDLC();

            Pisanjesg();

            Pisanjestat();

            Pisanjeappt();

            Pisanjedepo();

            Pisanje_force_language();

            Pisanje_force_listen_port();

            Pisanje_force_steamid();

            Pisanje_force_account_name_add();

            Pisanje_clan_tag();

            Pisanje_Server();

            Pisanje_FavServ();

            Pisanje_HisServ();

            if (Is_app_valid())
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Browse_game_exe_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Game executables (*.exe)|*.exe;|All Files|*.*",
                FilterIndex = 1,
                Multiselect = false,
                CheckFileExists = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                game_exe_edit.Text = openFileDialog.FileName;
            }
        }

        private void Browse_start_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                Description = "Game start folder",
                SelectedPath = game_folder_edit.Text
            };
            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                game_folder_edit.Text = openFolderDialog.SelectedPath;
            }
        }

        private bool Is_app_valid()
        {
            if (game_folder_edit.Text.Length == 0 || !Directory.Exists(game_folder_edit.Text))
            {
                MessageBox.Show("Start folder " + game_folder_edit.Text + " does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (game_exe_edit.Text.Length == 0 || !File.Exists(game_exe_edit.Text))
            {
                MessageBox.Show("Game exe " + game_exe_edit.Text + " does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    Modified_app.AppId = Convert.ToUInt64(game_appid_edit.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Game exe " + game_exe_edit.Text + " does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            Modified_app.UseX64 = x64_checkbox.Checked;
            Modified_app.DisableOverlay = checkBox_disableOverlay.Checked;
            Modified_app.DisableNetworking = checkBox_DisableNetworking.Checked;
            Modified_app.DisableLANOnly = checkBox_DisableLANOnly.Checked;
            Modified_app.EnableHTTP = checkBox_EnableHTTP.Checked;
            Modified_app.DisableSQuery = checkBox_DisableSQuery.Checked;
            Modified_app.DisableAchNotif = checkBox_DisableAchNotif.Checked;
            Modified_app.DisableAvatar = checkBox_DisableAvatar.Checked;
            Modified_app.Offline = checkbox_offline.Checked;
            Modified_app.AppName = game_name_edit.Text;
            Modified_app.Path = game_exe_edit.Text;
            Modified_app.StartFolder = game_folder_edit.Text;
            Modified_app.LocalSave = local_save_edit.Text;
            Modified_app.Parameters = game_parameters_edit.Text;
            Modified_app.CustomBroadcasts = new List<string>();
            Modified_app.EnvVars = new List<string>();

            foreach (IPAddress ip in ip_listBox.Items)
            {
                Modified_app.CustomBroadcasts.Add(ip.ToString());
            }

            foreach (string env_var in listBox_env_var.Items)
            {
                Modified_app.EnvVars.Add(env_var);
            }

            return true;
        }

        private void Add_broadcast(string text)
        {
            try
            {
                Add_ip_to_list(text);
            }
            catch
            {
                MessageBox.Show("Invalid IP Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_broadcast_button_Click(object sender, EventArgs e)
        {
            Add_broadcast(ip_textBox.Text);
            ip_textBox.Text = "";
        }

        private void Remove_broadcast_button_Click(object sender, EventArgs e)
        {
            Del_ip_from_list((IPAddress)ip_listBox.SelectedItem);
        }

        private void Clear_broadcast_button_Click(object sender, EventArgs e)
        {
            ip_listBox.Items.Clear();
        }

        private void Ip_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Add_broadcast(ip_textBox.Text);
                ip_textBox.Text = "";
            }
        }

        private void Ip_listBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Del_ip_from_list((IPAddress)ip_listBox.SelectedItem);
            }
        }

        static public bool Is_original_steam_api(string path)
        {
            if (File.Exists(path))
            {
                string file_name = Path.GetFileName(path);

                SHA256 checksum = SHA256.Create();
                // Create a fileStream for the file.
                FileStream fileStream = File.Open(path, FileMode.Open);
                // Be sure it's positioned to the beginning of the stream.
                fileStream.Position = 0;
                // Compute the hash of the fileStream.
                StringBuilder string_builder = new StringBuilder();

                foreach (byte b in checksum.ComputeHash(fileStream))
                    string_builder.Append(b.ToString("X2"));

                string file_hash = string_builder.ToString().ToLower();

                // Close the file.
                fileStream.Close();

                foreach (KeyValuePair<string, List<string>> entry in steamapi_hashsmap)
                {
                    foreach (string hash in entry.Value)
                    {
                        if (hash.Equals(file_hash))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        static public List<string> Get_interfaces(string path)
        {
            List<string> interfaces = new List<string>();

            if (File.Exists(path))
            {
                // Create a fileStream for the file.
                FileStream fileStream = File.Open(path, FileMode.Open);

                long size = fileStream.Length;
                byte[] buffer = new byte[size];

                fileStream.Read(buffer, 0, buffer.Length);
                StringBuilder sbuilder = new StringBuilder();

                foreach (byte b in buffer)
                {
                    sbuilder.Append(Convert.ToChar(b));
                }

                string binary_buffer = sbuilder.ToString();

                string[] interface_names = new string[] {
                    "SteamClient",
                    "SteamGameServer",
                    "SteamGameServerStats",
                    "SteamUser",
                    "SteamFriends",
                    "SteamUtils",
                    "SteamMatchMaking",
                    "SteamMatchMakingServers",
                    "STEAMUSERSTATS_INTERFACE_VERSION",
                    "STEAMAPPS_INTERFACE_VERSION",
                    "SteamNetworking",
                    "STEAMREMOTESTORAGE_INTERFACE_VERSION",
                    "STEAMSCREENSHOTS_INTERFACE_VERSION",
                    "STEAMHTTP_INTERFACE_VERSION",
                    "STEAMUNIFIEDMESSAGES_INTERFACE_VERSION",
                    "STEAMUGC_INTERFACE_VERSION",
                    "STEAMAPPLIST_INTERFACE_VERSION",
                    "STEAMMUSIC_INTERFACE_VERSION",
                    "STEAMMUSICREMOTE_INTERFACE_VERSION",
                    "STEAMHTMLSURFACE_INTERFACE_VERSION_",
                    "STEAMINVENTORY_INTERFACE_V",
                    "SteamController",
                    "SteamMasterServerUpdater",
                    "STEAMVIDEO_INTERFACE_V",
                    "STEAMCONTROLLER_INTERFACE_VERSION"};

                foreach (string iface in interface_names)
                {
                    Regex rx = new Regex(iface + "\\d{3}");

                    MatchCollection matches = rx.Matches(binary_buffer);

                    foreach (Match match in matches)
                    {
                        interfaces.Add(match.ToString());
                    }
                }
            }

            return interfaces;
        }

        private void Add_ip_to_list(string str_ip)
        {
            if (!str_ip.Equals(""))
            {
                IPAddress ip = IPAddress.Parse(str_ip);
                ip_listBox.Items.Add(ip);
            }
        }

        private void Del_ip_from_list(IPAddress ip)
        {
            if (ip != null)
            {
                ip_listBox.Items.Remove(ip);
            }
        }

        private void Button_add_env_var_Click(object sender, EventArgs e)
        {
            if (textBox_env_var_key.Text.Equals(""))
            {
                MessageBox.Show("An env var must have a name", "Invalid Env Var", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox_env_var_value.Text.Equals(""))
            {
                if (MessageBox.Show("An empty env var value will clear it before starting the game, are you sure ?", "Null env var value", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            }

            for (int i = 0; i < listBox_env_var.Items.Count; ++i)
            {
                int pos = ((string)listBox_env_var.Items[i]).IndexOf('=');
                if (pos != -1 && ((string)listBox_env_var.Items[i]).Substring(0, pos) == textBox_env_var_key.Text)
                {
                    listBox_env_var.Items[i] = textBox_env_var_key.Text.Trim() + "=" + textBox_env_var_value.Text.Trim();
                    textBox_env_var_key.Text = "";
                    textBox_env_var_value.Text = "";
                    return;
                }
            }

            listBox_env_var.Items.Add(textBox_env_var_key.Text.Trim() + "=" + textBox_env_var_value.Text.Trim());
            textBox_env_var_key.Text = "";
            textBox_env_var_value.Text = "";
        }

        private void Button_remove_env_var_Click(object sender, EventArgs e)
        {
            Remove_env_var_value((string)listBox_env_var.SelectedItem);
        }

        private void Button_clear_env_var_Click(object sender, EventArgs e)
        {
            listBox_env_var.Items.Clear();
        }

        private void Remove_env_var_value(string value)
        {
            if (value != null)
            {
                listBox_env_var.Items.Remove(value);
            }
        }

        void PisanjeDLC()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(DLC_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "DLC.txt"))) File.Delete(Path.Combine(game_emu_folder, "steam_settings", "DLC.txt"));
            }
            else
            {
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "DLC.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(DLC_add.Text);
                tw.Close();
            }
        }

        void Pisanjesg()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(sg_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "subscribed_groups.txt"))) File.Delete(Path.Combine(game_emu_folder, "steam_settings", "subscribed_groups.txt"));
            }
            else
            {
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "subscribed_groups.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(sg_add.Text);
                tw.Close();
            }
        }

        void Pisanjestat()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(stat_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "stats.txt"))) File.Delete(Path.Combine(game_emu_folder, "steam_settings", "stats.txt"));
            }
            else
            {
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "stats.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(stat_add.Text);
                tw.Close();
            }
        }

        void Pisanjeappt()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(Apppt_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "app_paths.txt"))) File.Delete(Path.Combine(game_emu_folder, "steam_settings", "app_paths.txt"));
            }
            else
            {
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "app_paths.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(Apppt_add.Text);
                tw.Close();
            }
        }

        void Pisanjedepo()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(depots_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "depots.txt"))) File.Delete(Path.Combine(game_emu_folder, "steam_settings", "depots.txt"));
            }
            else
            {
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "depots.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(depots_add.Text);
                tw.Close();
            }
        }
        void Pisanje_force_account_name_add()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(force_account_name_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "force_account_name.txt"))) File.Delete(Path.Combine(game_emu_folder, "steam_settings", "force_account_name.txt"));
            }
            else
            {
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "force_account_name.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(force_account_name_add.Text);
                tw.Close();
            }

        }
        void Pisanje_force_language()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(force_langugae_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "force_language.txt"))) File.Delete(Path.Combine(game_emu_folder, "steam_settings", "force_language.txt"));
            }
            else{
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "force_language.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(force_langugae_add.Text);
                tw.Close();
            }
             
        }
        void Pisanje_force_listen_port()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(force_listen_port_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "force_listen_port.txt"))) File.Delete(Path.Combine(game_emu_folder, "steam_settings", "force_listen_port.txt"));
            }
            else
            {
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "force_listen_port.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(force_listen_port_add.Text);
                tw.Close();
            }

        }
        void Pisanje_force_steamid()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(force_steamidpoigri_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "force_steamid.txt"))) File.Delete(Path.Combine(game_emu_folder, "steam_settings", "force_steamid.txt"));
            }
            else
            {
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "force_steamid.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(force_steamidpoigri_add.Text);
                tw.Close();
            }

        }

        void Pisanje_clan_tag()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(clan_tag_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "subscribed_groups_clans.txt"))) File.Delete(Path.Combine(game_emu_folder, "steam_settings", "subscribed_groups_clans.txt"));
            }
            else
            {
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "subscribed_groups_clans.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(clan_tag_add.Text);
                tw.Close();
            }

        }
        void Pisanje_Server()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(Server_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "remote", "serverbrowser.txt"))) File.Delete(Path.Combine(game_emu_folder, "remote", "serverbrowser.txt"));
            }
            else
            {
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "remote", "serverbrowser.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(Server_add.Text);
                tw.Close();
            }

        }
        void Pisanje_FavServ()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(FavServ_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "remote", "serverbrowser_favorites.txt"))) File.Delete(Path.Combine(game_emu_folder, "remote", "serverbrowser_favorites.txt"));
            }
            else
            {
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "remote", "serverbrowser_favorites.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(FavServ_add.Text);
                tw.Close();
            }

        }
        void Pisanje_HisServ()
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            if (string.IsNullOrEmpty(HisServ_add.Text))
            {
                if (File.Exists(Path.Combine(game_emu_folder, "remote", "serverbrowser_history.txt"))) File.Delete(Path.Combine(game_emu_folder, "remote", "serverbrowser_history.txt"));
            }
            else
            {
                TextWriter tw = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "remote", "serverbrowser_history.txt"), FileMode.Create), Encoding.ASCII);
                tw.WriteLine(HisServ_add.Text);
                tw.Close();
            }

        }

        private void Mods_Click(object sender, EventArgs e)
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            Directory.CreateDirectory(Path.Combine(game_emu_folder, "steam_settings", "mods"));
        }

        private void DLLfold_Click(object sender, EventArgs e)
        {
            string game_emu_folder = Path.Combine("games", game_appid_edit.Text);
            Directory.CreateDirectory(Path.Combine(game_emu_folder, "steam_settings", "load_dlls"));
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            WebClient web = new WebClient();
            string manipulirano,webadresa;
            webadresa = "https://store.steampowered.com/api/appdetails?appids="+game_appid_edit.Text+"&filters=basic";  
            //System.IO.Stream stream = web.OpenRead("https://store.steampowered.com/api/appdetails?appids=251160&filters=basic");
            System.IO.Stream stream = web.OpenRead(webadresa);
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            {
                manipulirano = reader.ReadToEnd();
                var rjecnik = JsonConvert.DeserializeObject<Dictionary<string, Drugi>>(manipulirano);
                if (rjecnik[game_appid_edit.Text].Data != null)
                {
                    if (rjecnik[game_appid_edit.Text].Data.Dlc != null)
                    {
                        DLC_add.Text = string.Join(" = 0" + System.Environment.NewLine, rjecnik[game_appid_edit.Text].Data.Dlc) + " = 0";
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Appid has no DLC", "No DLC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("Appid is not valid?", "Not valid Appid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetgamenameBUT_Click(object sender, EventArgs e)
        {
            WebClient web = new WebClient();
            string manipulirano, webadresa;
            webadresa = "https://store.steampowered.com/api/appdetails?appids=" + game_appid_edit.Text + "&filters=basic";
            System.IO.Stream stream = web.OpenRead(webadresa);
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            {
                manipulirano = reader.ReadToEnd();
                var rjecnik = JsonConvert.DeserializeObject<Dictionary<string, Drugi>>(manipulirano);
                if (rjecnik[game_appid_edit.Text].Data != null)
                {
                    game_name_edit.Text = rjecnik[game_appid_edit.Text].Data.Name;
                }
                else
                {
                    DialogResult res = MessageBox.Show("Appid is not valid?", "Not valid Appid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetStats_Click(object sender, EventArgs e)
        {
            WebClient web = new WebClient();
            string manipulirano, webadresa;
            webadresa = "https://raw.githubusercontent.com/Nemirtingas/games-infos-datas/main/steam/" + game_appid_edit.Text + "/stats_db.json";
            //Primjer "https://raw.githubusercontent.com/Nemirtingas/games-infos-datas/main/steam/244450/stats_db.json"
            System.IO.Stream stream = web.OpenRead(webadresa);
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                {
                    manipulirano = reader.ReadToEnd();
                    stat_add.Text = "";
                    List<Stats> rjecnik = JsonConvert.DeserializeObject<List<Stats>>(manipulirano);
                    if (rjecnik.Count > 0)
                    {
                        for (int brojac = 0; brojac < rjecnik.Count; brojac++)
                        {
                            Stats name = rjecnik[brojac];
                            stat_add.AppendText(name.Name + "=" + name.Type + "=" + name.Defaultvalue + System.Environment.NewLine);
                        }
                    }
                }
            }
        }

        private void DLCinfo_gameinfo_Click(object sender, EventArgs e)
        {
            WebClient web = new WebClient();
            string manipulirano, webadresa;
            webadresa = "https://raw.githubusercontent.com/Nemirtingas/games-infos-datas/main/steam/" + game_appid_edit.Text + "/" + game_appid_edit.Text + ".json";
            //Stranica "https://raw.githubusercontent.com/Nemirtingas/games-infos-datas/main/steam/244450/244450.json"
            System.IO.Stream stream = web.OpenRead(webadresa);
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            {
                manipulirano = reader.ReadToEnd();
                var rjecnik = JsonConvert.DeserializeObject<Prvi>(manipulirano);

                /*if (rjecnik[game_appid_edit.Text].Dlcs != null)
                {
                    if (rjecnik[game_appid_edit.Text].Dlcs != null)
                    {
                        DLC_add.Text = string.Join(" = 0" + System.Environment.NewLine, rjecnik[game_appid_edit.Text].Dlcs) + " = 0";
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Appid has no DLC", "No DLC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("Appid is not valid?", "Not valid Appid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
            }
        }

        public partial class Prvi
        {
            [JsonProperty("Dlcs")]
            public Dictionary<string, Dlcs> Dlcs { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("AppId")]
            public long AppId { get; set; }

            [JsonProperty("ImageUrl")]
            public Uri ImageUrl { get; set; }

            [JsonProperty("Languages")]
            public string[] Languages { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }
        }

        public partial class Dlcs
        {
            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("AppId")]
            public long AppId { get; set; }

            [JsonProperty("ImageUrl")]
            public Uri ImageUrl { get; set; }

            [JsonProperty("MainAppId")]
            public long MainAppId { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("Languages", NullValueHandling = NullValueHandling.Ignore)]
            public string[] Languages { get; set; }
        }

        public class Drugi
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("data")]
            public Data Data { get; set; }
        }

        public class Data
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("steam_appid")]
            public int SteamAppid { get; set; }

            [JsonProperty("is_free")]
            public bool IsFree { get; set; }

            [JsonProperty("dlc")]
            public List<int> Dlc { get; set; }
        }

        public partial class Stats
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("defaultvalue")]
            public long Defaultvalue { get; set; }
        }
    }
}
