-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 10-10-2020 a las 22:15:25
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.4.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `supermercado`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `Dni` int(255) NOT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Apellido` varchar(255) NOT NULL,
  `Telefono` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`Dni`, `Nombre`, `Apellido`, `Telefono`) VALUES
(14454738, 'Alicia', 'Yolanda', 1156906299),
(21212123, 'Liiana', 'Rodriguez', 1123454767),
(22222222, 'Marco', 'Al', 116789987),
(22222256, 'Mark', 'LIma', 1167897444),
(44053096, 'Rosio', 'Scabini', 1146457889),
(44756956, 'luciasda', 'aew', 2147483647),
(48053096, 'Rosio', 'Scabini', 11378709),
(66666666, 'Mario', 'lirio', 1145455667),
(98765432, 'Melina', 'Scabini', 1157358615),
(1536925814, 'Leonel', 'Messi', 1145785612),
(1661616666, 'José', 'Molina', 1432646466),
(2147483647, 'Susana', 'ruso', 1145555555);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle_factura`
--

CREATE TABLE `detalle_factura` (
  `ID` int(11) NOT NULL,
  `ID_factura` int(11) NOT NULL,
  `Codigo_producto` int(11) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `Total_producto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `detalle_factura`
--

INSERT INTO `detalle_factura` (`ID`, `ID_factura`, `Codigo_producto`, `Cantidad`, `Total_producto`) VALUES
(3, 14, 8, 4, 172),
(4, 14, 2, 10, 1000),
(9, 13, 8, 3, 129),
(13, 13, 2, 7, 600),
(14, 13, 8, 6, 258),
(18, 14, 4, 50, 4500),
(19, 14, 2, 71, 7100),
(20, 14, 2, 81, 8100),
(21, 14, 9, 5, 1500),
(22, 17, 8, 5, 215);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle_ingreso_mercaderia`
--

CREATE TABLE `detalle_ingreso_mercaderia` (
  `ID` int(11) NOT NULL,
  `ID_detalle_ingreso` int(255) NOT NULL,
  `Codigo_producto` int(255) NOT NULL,
  `Cantidad` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `detalle_ingreso_mercaderia`
--

INSERT INTO `detalle_ingreso_mercaderia` (`ID`, `ID_detalle_ingreso`, `Codigo_producto`, `Cantidad`) VALUES
(6, 5, 8, 60),
(7, 5, 11, 40),
(8, 5, 2, 500),
(9, 5, 8, 50),
(12, 5, 11, 40),
(14, 5, 11, 40),
(15, 5, 2, 60),
(16, 5, 2, 60),
(17, 5, 2, 50),
(18, 5, 2, 40),
(19, 5, 2, 100),
(20, 5, 2, 1),
(25, 4, 2, 100),
(26, 4, 4, 100),
(27, 4, 2, 60),
(28, 4, 4, 70),
(29, 4, 4, 30),
(30, 4, 4, 50);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleados`
--

CREATE TABLE `empleados` (
  `Dni` int(11) NOT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Apellido` varchar(255) NOT NULL,
  `Nacimiento` datetime NOT NULL,
  `Domicilio` varchar(255) NOT NULL,
  `Sexo` varchar(11) NOT NULL,
  `Telefono` int(11) NOT NULL,
  `Cargo` varchar(255) NOT NULL,
  `Fecha_contratacion` datetime NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Contraseña` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `empleados`
--

INSERT INTO `empleados` (`Dni`, `Nombre`, `Apellido`, `Nacimiento`, `Domicilio`, `Sexo`, `Telefono`, `Cargo`, `Fecha_contratacion`, `Email`, `Contraseña`) VALUES
(11111111, 'Samuel', 'Escudero', '1990-10-05 00:00:00', 'Alberti 1621', 'M', 1145867876, 'Auxiliar Compras', '2020-10-30 00:00:00', 'sam@gmail.com', 'sameil56'),
(11456456, 'lkasdjfkas', 'kljkljl', '2020-10-04 00:00:00', 'jkljklj 4545', 'M', 2147483647, 'Carnicero', '2020-10-14 00:00:00', 'kasdfa@gmail.com', 'qwerty12'),
(27854512, 'Lau', 'Sinclair', '2020-02-04 00:00:00', 'Av Corrientes', 'F', 1165545888, 'Auxiliar de ventas ', '2020-10-01 00:00:00', 'lau@gmail.com', 'lauren12'),
(44457894, 'Martín', 'Palermo', '2020-10-05 00:00:00', 'Sarmiento 45', 'Otro', 1154526532, 'Almacén', '2020-10-04 00:00:00', 'Palermo', 'bokita12'),
(44756058, 'Melina', 'Scabini', '2020-06-16 00:00:00', 'San Martín 151', 'F', 1157358615, 'Gerente', '2003-04-09 00:00:00', 'melina09321@gmail.com', 'meli09321'),
(444578945, 'Martín', 'Palermo', '2020-10-05 00:00:00', 'Sarmiento 45', 'Otro', 1154526532, 'Almacén', '2020-10-04 00:00:00', 'Palermo', 'bokita12'),
(2147483647, 'Freddy ', 'Mercury', '2020-10-07 00:00:00', 'Remedios de escalada 62', 'M', 1145784512, 'Atención al cliende', '1953-07-16 00:00:00', 'freddy@gmail.com', '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `factura`
--

CREATE TABLE `factura` (
  `ID` int(255) NOT NULL,
  `Fecha_emision` datetime NOT NULL,
  `Dni_empleado` int(255) NOT NULL,
  `Dni_cliente` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `factura`
--

INSERT INTO `factura` (`ID`, `Fecha_emision`, `Dni_empleado`, `Dni_cliente`) VALUES
(13, '2020-10-01 00:00:00', 27854512, 14454738),
(14, '2020-10-08 00:00:00', 44457894, 14454738),
(15, '2020-10-10 00:00:00', 27854512, 14454738),
(16, '2020-10-08 00:00:00', 27854512, 14454738),
(17, '2020-10-08 00:00:00', 44457894, 44756956);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ingreso_mercaderia`
--

CREATE TABLE `ingreso_mercaderia` (
  `ID` int(255) NOT NULL,
  `ID_provedor` int(255) NOT NULL,
  `Costo_total` int(255) NOT NULL,
  `Fecha_entrega` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ingreso_mercaderia`
--

INSERT INTO `ingreso_mercaderia` (`ID`, `ID_provedor`, `Costo_total`, `Fecha_entrega`) VALUES
(3, 4, 200, '2020-10-07'),
(4, 3, 73700, '2020-10-02'),
(5, 3, 73700, '2020-10-02'),
(6, 4, 9000, '2020-10-09'),
(8, 4, 600, '2020-10-02');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `Codigo` int(255) NOT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Precio` int(255) NOT NULL,
  `Stock` int(255) NOT NULL,
  `Categoria` varchar(255) NOT NULL,
  `Imagen` longblob NOT NULL,
  `Marca` varchar(255) NOT NULL,
  `Unidad` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`Codigo`, `Nombre`, `Precio`, `Stock`, `Categoria`, `Imagen`, `Marca`, `Unidad`) VALUES
(2, 'Pan', 100, 48, 'Procesados', 0xffd8ffe000104a46494600010100000100010000ffdb0084000b07080a0a0a0d0a0a0d0d0d0d0d0d0f0e0d0d0d0d150d0d0d0f27232929271726252c3133352c2e2f2f25262a3e2b2f35373a3b3a2a3441464038463f393a37010c0c0c100f101d12121d37211d253737373737373737373737373737373737373737373737373737373737373737373737373737373737373737373737373737ffc000110800b7011303012200021101031101ffc4001b00000203010101000000000000000000000003020405010607ffc4004010000102040204090a05040301000000000200030104122211321321425205314161627172c1f0235181829192a1a2b1e11433b2d1d20643c2f115e2f224ffc400190100030101010000000000000000000000000304020105ffc4002611000300020202020105010100000000000001020311122104314151221332617181b114ffda000c03010002110311003f00faaa1085a3a08421000842100084210008421000842100084210008421000842100084210008421000848989c619b5c31ab746e2fb2abff2ed5d646dbb8f325564997a6cd2c755da468a167870dca16f8fa91faab6c4d32ffe518c7a394bd8bb3926bd30ac753ed31a842130c821084002108400210840021084002108400210840021084002108400210840021084002108400217705c8a0010abb93f2cd94449c8550e8c4be8a93ffd4320d968c626e96eb6397af892de485eda36b1d3f499aa85905fd40c535685ff0070757c5365b86d87728390f763f48ae2cd0de933af0da5b68d2591373d30e1c45a8d0d65ab6e3cfcd04e9899d3f931b436aeb8bad701b114bbbe5d4b3533c7ba466c6579fb56ae14a5437545eb254f9bccb843890d594a959a1f8922a9b9a748aaca45dcbceba4ab4d176396d6f66a9314943515b94b9bad0dc746550fbd5446959b17f845b2ba247c7b304d1e15abc93815110e521a75f7c16552df437836becdf96e142b71bc69b8b6feeb4db31706a6e38892f2f2ce0965853eb2b6c4ff00e18ee8ea2cc357c70e45662f25aeabd12e5f193fdbecdf42832eb6f040c2350929abd3df6881ad74c10842e80210840021084002108400210840021084002108400210840021579c9d6a586a3cc5940739f543bd63bf3f3331c512680b64337a63c7ecc12326698ebdbfa43231552dfa46d3b392edd503702050cc355450f471acd7b87aea1860cfa4568fb157969316eeb6adaff6ac4046ab737654ef364a5f5ff472c78e5fd8839ce137a3c74766d1877fc52824e6dcb9c72a8ef15cb42036dc833a452dcb7ee9b18b26bf6a4bfc32dc92734642e19e5cda855484936c8d5817e9d6b50e608565f09ba4e0f652af1ccad8c8c954f452999a112d18c2a11dd2a4463e3156a4dc72a10c736eaa2ccbd4e693c0f8c568cb08e9c698dc21f0c525d6fd1475e8d66e91a7777949c322216c69e9155975452207fc8bb97029d9cc451abc7a15337d6911d4f7b65d7659b78746575b9beeb1e63831e961222889b5f38c3bf05a6c4dd242d1090f4b32b748b83494169a9c8b5f2653a87bf83cd32ed37098988e1edeb4e7259b981ba3012f9bae0b4e7f8304bcab30be9f7a1e6592262db9a37214ba3987be11e5829eb0b9fe8a2337214cb2ecb1538554f56b863c9056cd8d250431a4b6a9ef871454e5de1a63a4e2e95b8415c101a7e84973d8e742f81e69c967744e642f18af4515804cd38558534f8d6aff00074d8952d6388ec173f997a3e3e5d7e3443e463e5f94ff00a5f42228571182108400210840021084002145d74591271c8d222b1a7786b65bb0778b317ec95796616e99a88aa7a46d1108e621876ad4a29b971ccf343ebc179b6e685e2ab1a8b78b1ef44c9b834e8fc73a95f98be114af13bd367a80704b2c611ec9409497926a6889cd1942edea56b3332f37bc5dab87ecb51e5cd7b472fc573e99aeaacf4f36c0ef19650fdfcd0554f84ca9b5b2af77656789d553ae46a322b8be905bacc9ad4b17385a7ba4762c13a5175f3a8cb77679a1ccac8c044691878e74b973b7a49c31b54e92f68736fd036254dd9948469a88971b3a848777e8870e915a49196d9289db72a8f1d39531d73c9ecf49557cd0f408591aaae8d550f6535c3b6d55e07992afb4323a6765a024a236cd8963695bdac314d68291b7d5499868888778494b49a9fe8a2697234e3f983bc4368f56088010d5fab7a2bb28750dd9854c93e34e7684ded5680ae2eced73abb2ef895c3c7b5fed5107044aeaaef745304b479a1aaa865d98266f4f92ff004c6b6b4cd40359bc2d282e08d30b8aaa7ad589599d3554ecfd7995ac6a4ddaa917a72cf2307deb8661ba0c7288944870861cbab0eae6e357a4e7088682a4b669e6e78722bb3d25a4222a2ea69aa9f347187c579de146dc6447471bc769bf3a8b2c397c91563b4fa66f3ad8b81a1c7a4118e3ab992e45a368e205c85021de873fb53f83889f96122810110c0aecd08a70324581f2ed0d3c6b53be9a3aeb49a3598734818ed652eb5359f26ed07496d5a5dd15a3182f5715f29d9e7649e34710842698042108005c32111222ca399762b3f855db45adecdd5e6f6fd1669e96cea5b667cfcd14c39d01ca3df1e75545a122112cc5d2a7d8ac4614a93623b5012b94371c9ee8aa6b8ad239094644b20db9bad1194a8b8be6f1ad4e31ab2ed54980b0f1cfd1d575f6578c1e646d0abb577c55670666a2317a8ab2896ce3c8b5611de5213122bbc412de15f0d8c595aef45094370463a7f1e94e3065c4d79b1a7c9c2edd4a1951aaacb1f9571cd4faecef29aedf42f464de5a487e6fba20fece05953c408524dda4a92fe4bbfa9c576738727d12170846a2ca23b3e6ef5d7caa1111baafa75a5938d90f1dbe9ef51c6d116cc69ecc56bf516ba39fa6f64a276f69517dfda4d780884698fbb7162a83ed10d54c4b7aefb2e734ce707f44cceda4554376eaba5f6483e101d902221dacaaa4c4fd2256154445b5e74bacb3f66d62a37259dba9f1c49c50a887b4b1a42674cd0ba31bc2d2f471f8e75aed1d422487da3be996c614d29fb5da55c8adab6b6549a3daf556a524f4669b63639872ff00961fba63d4d2292e80908398544256ff00af4a22e955753fe49bbd184878bba3a74701a47308abb8dc34c732cb6a92e5aaadacdf05a011d18d58da2b93bd856b43df027048497999c907bf1c056880f9421dec22bd434750f12ad3f2a2e0d5b4370f5fecb792794f4622b8b2949968291c21816cfa7ceaf69044a1d25812cf4c393730d946d021d1b6434d218611e4f3c16c444883ab2a965b5d1434993763763e38d6949bba46a05cb0b49631bc518047086bcdcdab8d5a9398164a18f1194048bcdc7847dba953832a542f2e3dc7f26a21762b8bd221042108022715e7e69fd23a45986ab7aa1a96af0bcc68658cb68fc98fa78fe0bca14c68eed9efd6a3f27370d228c18b96d9a5517caa559095254ecfdd54957f48ddc9ae8138e8b831ed55ed845256454b6863869e996c223b5b29f1abe65465c8847ca6622f863abe0ac8b94faab48cb1ea1088d56a20e2844ea2a72ddef2e3d7c8226312e966f8a22fd348dbd2e8f88ae810d5d943c76db01ed2e35f4cd6fec09cb7f8a589d455636ee90dded498b9489559b6529b0cc25555bd57325537b1932b459762c90f10fadf64a719962b72f649667e15e272a13220ca23ceb45b96a46ef7929b75ed21dc54fa643f04e5da273fcb054df0986ee722250de1e5f843d8b5e0db76eee6ecc54cdad25a8e1d740b2e9f67987a5c5e1a76bd3f582c9e10e0a79ba89ba8e9fed91545e88f2af553529a23b616fe94a782a152d7255a651a9a5b478de089dd0bfa32a86bb484ada62bd44b1db6ac4e15e0e272e185fb243e35a97034f9542dbd698d225dd15562a4d1364872cf54c95434aeb642254eced244b12ecc429744b669a531fa15f25a38793fe3d4b92c42e5d766a4b7949a2a87b2a4014ff9749765d27d1c7ad13064448a9ed175c7eaad370b69f5925a21a88b0cddd04d81dc9ab5ec5bfa2d04765370a8695580d586c9313d8b6b479ee169171b7c5fae81d75f4a1e85a5250f254946a865ab7a099c21a321f296d1753b25f64a66055008e5fac39922d29a7a1d2db9ec542171b5e652a48a14fb50fdaee1bcba023afa4933d3d146fad9b2c956dc0b1c757c54952e088952e8e234c0ea1f3c31d715762bd7c75ca533ccc93c69a042109864f35fd4735907644625dcbcd3ae96969d95b7fd4e054b4e0f64baa11c7bd6195c56e615e4797fbdecf53c54b82d16e0e908daaf7074c1399ad2a56706c8e6b6e569870728a9229cb1b529a2d4409b21223aaedebbd29a2f9178faac69999d0cd8d51b486d22cb8f8faab82eb6e5258dc3b4394b5e38453e7324f4fa15585eb6bb3520e968c69cb4aacecd5396044425b397dabac6904b46594c7366bfcd1f36a5c2abcd55a597cfaf57dd3abb42174c94bcd543a4c4b769da57408691ecfd1624b01325514086adef6c56934f090896d18fbbe35ae475a3b4f645f3112bad1f1ad3c23e4fa5e3ecb39e329899d18fe5066e947915d28d242430daf82ea9edb0e5d68641ba46a1cc36a646a7a9aa368ddbb5732e046ae5f3aee1509530a69f990a41d0d10dd8298525e38a2bace5ddb72a8b60425bd562baa43904e08d356196e58ef3e2396115e84dbaaee8e55933327b493e443e9a1de3daf4cca79ba86a2f9b3712f3fc2d29a3ff00e96614906c8ed43ccbd7b8cacce1263c9908a8fb87b2b7aa5a15c1339a6681c18e61bbae0b54bca0af27c04652f36eca165aa0e0f547c7c17a7663955a9fc90d2d1665a349d2594855901b6925546e4c6dc2d252597bd765e9e9fa38d6d16e236dbb2b86e179aab77aef62aaebb48d4377fb568202422594b5744ba9326953728c54b9498d0121112decdd156800b3635248c2d11dddd4f04e99154cadc22dd4d1116efbd0e55c916c45a0218c4844691eaf3e2ad10556e39941a674234e350d2b953b7b055a5a284fc089d879a9effb293502c7ad13c5743a431f5546254eb1f7546faa6cb276e522df04daeb90c73fd7c456a14163cac7ca8972d70bbebf05b115e978d5b9d11790bf2d914210a91079be1b649c604873015443bc186bee8fa179a36cb4948ffd497b338ac6e1390bb4acfac3df05079585d7e4bfd2cf1b329fc598c07496d5cad331b877540a9b87692ca04d90d3552bcc6b45dec670837508eacb9ad555d07191d2336ef6e961ccafc0ea2bb2d2b9026cad2435d9d9a6968ef064fd56bd6fe95ac4f65a6350f72c836469ed7caabb66f4b895370f763cbed5d9a72b466a153da3d04c32dcdb64db9508ecd3690c61cb08f72e31262cb6d55790e6732fb70f62cd929e17b9692f755d07cb2ddfab573a7ce4df7a27ac6d7433f0bb4dd235097b70c3d8a12ccb8cb62d942aa48aa2d9c2318c7dbc89717a6366234f8c315389cc10d246223d9ef5d597bde99cfd3fe50d13d1f952cbb234ddcf8a6b14da4d9d550fd397082a66c917f7089318686911c4846ade8772e2c95cb7a37c278fb2db512aa923a6e8965ab57772fb7995b9788e6dec69eac55317996e9d2188a6373f2ee7e59d54f5f7a7452f96855c3f84cd1c04921e0a852d87ea21dd21f18a78d24254e54cad5cf42d6e1f667c5abb89674fb65b5b5f55bae0fbcb1b85885ba8cb67122e3e2c238c7528b262491563c8db3c14dbfa1e1727364686cbd1087d22bd849bb50f4978b725c9c709cde2222f4af41c09324422db99807de843f654d63d4a6be0572e4d9bec9ef2640a92e8a505d726460974ba3a9f63e17096aecf4a11e54e681c11ac6350fcc31e55500f64bd54f098d1952594beab936b7b3b52f5a1f3735f87112c08aa2a4a91faab12d33a4ec97adf154e06445a3ba92f18f12251c6ea3a6355d4f2f26ad49d191b626a348d4222a6a185454fc570f28d4b811a87894bd29cc5a31e7c7ca06bd94c6c878b9542782931daa45663b3be5291d9ddda82f3e9f1b67a313ca11ae25e529cbfe4b7423508c7cf082f3cd1d4205ab2d4b7a5ff00283b22aff11f6c8fca5d22684215c46639259c15a36d20c161a3a8ca9b90a8b48dda5bbb24a91866aa1956e941577e5c494997c69aee7a65519dae9988db44d9555d4294eb044e691b8ad07e51c1ca930dd2b7e550d62a9f68ae7227da67034839915895a49b08db4aaefb645bbf1a4961ad1a4f65578445cd20c29212f57d8acca039984ca9253316dc1a4a1774bf7506a1495b0ffb2cb4b66f93d0c75f9b6f904877945c9d7846d808fcbad308c72a8b8025ba45aad5cadfc367275f291c19a982e5a6a4970dc111d65576bcfc69806986dd43d2fd3ca94f93ec62693f4560170846aa969cb80e6e2a47e292194750a6d622ba99aa7b2f30e10908f8c16a098d3da15952ee090ab80748fad72af1534479a767449cfee6f153d4bcf7f50cc1154c0ede6e8c211eff00dd6fbce5b52f3d3ac13933a4f1e7ef4ec6b95684d3d4eccd624ed414b93242e0ecad606974d8a95dc5689f9764a45d17044b6b695d82c76e052ced5b259bf75acc9890a8ee38bd0d55bece18aed6256929185b6a4440ba4a5c92d3e8a71b4d765e953a69aae1de4d26444a2e33011ab1a8698dd18aaac9ef655a32f11a6d4cc35be8c659f93b2cfdb55d7536e52f8a7bf1f265eedaa20d0e6da4b9ea85af279f57c756315526f8bd9334b97455e100a86ae8ac069871c7c8778aee3e25e99d6ea1a7a290dca88ddf3292a1bad96e3caa6744a5d8189000f67d1c71d6b6d569096a06b2e38e51dd82b315e8f8f1c676fe48335f2ad7d021085489146daae6d2baa240b80669b6944d2d326524d85c68ea6669b2abb92c259a0b549924a36961c9a5462b927bb121554d879bcd0a96f9b0926d245609af81d39a9181021fcb2810faa98350f4856a392e259a0ab9ca53f971a7f4a9ebc56bf6b1f39d7ca338e972926d4a3121e926392f4dd8525bc3fb24c49cda81171ddb3f653563a9f65136abd1d846a1abf640c69ccb91b72c105b54e64a723131ba7fd3e35a646a211abff3e859ae113655624a6c4d5596adefa2cf166ffa351b7046d575b7b64a2b10205555897655d6ce912daf9896a768cd24cbee3953948a0657693251922a5c286cdbbdaf955f105eaf8d0e6793f93cccf49d697c19672c9440b609a4a725552e49f663b8cd4290c9fe1ca92c9b25bbf65aae4a90aaee3355a504ba9daec64d68e89652ff00c92688895ca880392f96e0ddddea5725cc486d8ff21525c34fb1d3434413da0214a08ab0d25cca66dd344e13223ca29b03b6a4b097a8aa6dbf58958190aae70cbb23e4c7f754cc5311552568c088ad5725a529c08fdd4f6996dbcb0a532314e9c293db31591fa4118a8c5118ae278a04210ba008421000b9115d42008c41409a14d42e0154a5d24e5c96860a31146836649cba49b04b6c9b14b297159726951826d732aaeca0e61b497a339514a3915878f7ecd4e4d1e60d870792a49a692da125e9cf8392cb82aa53df8b2fd743e7c86bd9e5c9aab96aab37178f329030d896c8d3d63c9e20bd27fc2b659a09ad703cb8ec0a5af0ff0091bffad7d180c4ab8f179387ade20b5e4f82b47739717cab59b9711b4614a70b6a8c7e34c77ec45f9355d150184f1693a02a582a12276c4e89722d27a177470a84c259c9092bd82305cd06cc93e0d2d9492e07222ab296f0952b7305dc171c266953463b5c1b302571dbe39968b12a2df4893d0b2b14a7b481dd35a3b0462b884cd193b8ae210ba00842100084210008421000842100084210008421000842100182e6084200e528a5750800a518210800c17508400210840021084002108400210840021084002108400210840021084002108401ffd9, 'La esperanza', 'Kg'),
(4, 'dasdf', 90, 219, 'Bebidas', '', 'Manaos', 'l'),
(8, 'Detergente naranja', 43, 29, 'Higiene', '', 'Ala', 'l'),
(9, 'Milanesas de carne', 300, 25, 'Carnes', '', 'La vaquita feliz', 'kg'),
(11, 'Gaseosa', 80, 60, 'Bebidas', '', 'Manaos', 'l');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedores`
--

CREATE TABLE `proveedores` (
  `ID` int(11) NOT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Direccion` varchar(255) NOT NULL,
  `Telefono` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `proveedores`
--

INSERT INTO `proveedores` (`ID`, `Nombre`, `Direccion`, `Telefono`) VALUES
(3, 'Sol', 'Av Cordoba 720', 1178457947),
(4, 'Marinas', 'Av Misiones 4200', 1112345678),
(5, 'Jaimito ', 'Habana 4600', 1142425363);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`Dni`);

--
-- Indices de la tabla `detalle_factura`
--
ALTER TABLE `detalle_factura`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_factura` (`ID_factura`),
  ADD KEY `Codigo_producto` (`Codigo_producto`);

--
-- Indices de la tabla `detalle_ingreso_mercaderia`
--
ALTER TABLE `detalle_ingreso_mercaderia`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_detalle_ingreso` (`ID_detalle_ingreso`),
  ADD KEY `Codigo_producto` (`Codigo_producto`);

--
-- Indices de la tabla `empleados`
--
ALTER TABLE `empleados`
  ADD PRIMARY KEY (`Dni`);

--
-- Indices de la tabla `factura`
--
ALTER TABLE `factura`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Dni_empleado` (`Dni_empleado`),
  ADD KEY `Dni_cliente` (`Dni_cliente`) USING BTREE;

--
-- Indices de la tabla `ingreso_mercaderia`
--
ALTER TABLE `ingreso_mercaderia`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_provedor` (`ID_provedor`);

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`Codigo`);

--
-- Indices de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  ADD PRIMARY KEY (`ID`) USING BTREE;

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `detalle_factura`
--
ALTER TABLE `detalle_factura`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT de la tabla `detalle_ingreso_mercaderia`
--
ALTER TABLE `detalle_ingreso_mercaderia`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT de la tabla `factura`
--
ALTER TABLE `factura`
  MODIFY `ID` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT de la tabla `ingreso_mercaderia`
--
ALTER TABLE `ingreso_mercaderia`
  MODIFY `ID` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `Codigo` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `detalle_factura`
--
ALTER TABLE `detalle_factura`
  ADD CONSTRAINT `detalle_factura_ibfk_1` FOREIGN KEY (`ID_factura`) REFERENCES `factura` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `detalle_factura_ibfk_2` FOREIGN KEY (`Codigo_producto`) REFERENCES `productos` (`Codigo`) ON DELETE CASCADE;

--
-- Filtros para la tabla `detalle_ingreso_mercaderia`
--
ALTER TABLE `detalle_ingreso_mercaderia`
  ADD CONSTRAINT `detalle_ingreso_mercaderia_ibfk_1` FOREIGN KEY (`ID_detalle_ingreso`) REFERENCES `ingreso_mercaderia` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `detalle_ingreso_mercaderia_ibfk_2` FOREIGN KEY (`Codigo_producto`) REFERENCES `productos` (`Codigo`) ON DELETE CASCADE;

--
-- Filtros para la tabla `factura`
--
ALTER TABLE `factura`
  ADD CONSTRAINT `factura_ibfk_1` FOREIGN KEY (`Dni_empleado`) REFERENCES `empleados` (`Dni`) ON DELETE CASCADE,
  ADD CONSTRAINT `factura_ibfk_2` FOREIGN KEY (`Dni_cliente`) REFERENCES `clientes` (`Dni`) ON DELETE CASCADE;

--
-- Filtros para la tabla `ingreso_mercaderia`
--
ALTER TABLE `ingreso_mercaderia`
  ADD CONSTRAINT `ingreso_mercaderia_ibfk_1` FOREIGN KEY (`ID_provedor`) REFERENCES `proveedores` (`ID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
