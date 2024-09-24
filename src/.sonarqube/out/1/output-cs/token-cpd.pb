Эv
wC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\UnitOfWork\UnitOfWorkSetup\UnitOfWorks.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

UnitOfWork '
.' (
IUnitOfWorkSetup( 8
;8 9
public 
class 
UnitOfWorks 
: 
IUnitOfWorks '
{ 
private		 
readonly		 

FOVContext		 
_context		  (
;		( )
private

 
readonly

 %
IIngredientTypeRepository

 .%
_ingredientTypeRepository

/ H
;

H I
private 
readonly (
IIngredientGeneralRepository 1(
_ingredientGeneralRepository2 N
;N O
private 
readonly 
ITableRepository %
_tableRepository& 6
;6 7
private 
readonly !
IRestaurantRepository *!
_restaurantRepository+ @
;@ A
private 
readonly %
IProductGeneralRepository .%
_productGeneralRepository/ H
;H I
private 
readonly /
#IProductIngredientGeneralRepository 8/
#_productIngredientGeneralRepository9 \
;\ ]
private 
readonly 
ICategoryRepository (
_categoryRepository) <
;< =
private 
readonly 
IProductRepository '
_productRepository( :
;: ;
private 
readonly !
IIngredientRepository *!
_ingredientRepository+ @
;@ A
private 
readonly (
IProductIngredientRepository 1(
_productIngredientRepository2 N
;N O
private 
readonly 
ICustomerRepository (
_customerRepository) <
;< =
private 
readonly 
IEmployeeRepository (
_employeeRepository) <
;< =
private 
readonly +
IIngrdientTransactionRepository 4+
_ingrdientTransactionRepository5 T
;T U
private 
readonly #
IProductComboRepository ,#
_productComboRepository- D
;D E
private 
readonly 
IComboRepository %
_comboRepository& 6
;6 7
private 
readonly 
IOrderRepository %
_orderRepository& 6
;6 7
private 
readonly "
IOrderDetailRepository +"
_orderDetailRepository, B
;B C
private 
readonly 
IShiftRepository %
_shiftRepository& 6
;6 7
private 
readonly %
IWaiterScheduleRepository .%
_waiterScheduleRepository/ H
;H I
private 
readonly  
IGroupUserRepository ) 
_groupUserRepository* >
;> ?
private 
readonly #
IGroupMessageRepository ,#
_groupMessageRepository- D
;D E
private 
readonly  
IGroupChatRepository ) 
_groupChatRepository* >
;> ?
private   
readonly   #
IProductImageRepository   ,#
_productImageRepository  - D
;  D E
private!! 
readonly!! 
IRatingRepository!! &
_ratingRepository!!' 8
;!!8 9
private"" 
readonly"" 
IPaymentRepository"" '
_paymentRepository""( :
;"": ;
private## 
readonly## !
IAttendanceRepository## *!
_attendanceRepository##+ @
;##@ A
private$$ 
readonly$$ %
IIngredientUnitRepository$$ .%
_ingredientUnitRepository$$/ H
;$$H I
private%% 
readonly%% -
!INewProductRecommendLogRepository%% 6-
!_newProductRecommendLogRepository%%7 X
;%%X Y
private&& 
readonly&& *
INewProductRecommendRepository&& 3*
_newProductRecommendRepository&&4 R
;&&R S
public(( 

UnitOfWorks(( 
((( 

FOVContext(( !
context((" )
,(() *%
IIngredientTypeRepository((+ D$
ingredientTypeRepository((E ]
,((] ^(
IIngredientGeneralRepository((_ {(
ingredientGeneralRepository	((| Ч
,
((Ч Ш'
IProductGeneralRepository
((Щ ▓&
productGeneralRepository
((│ ╦
,
((╦ ╠1
#IProductIngredientGeneralRepository
((═ Ё0
"productIngredientGeneralRepository
((ё У
,
((У Ф
ITableRepository
((Х е
tableRepository
((ж ╡
,
((╡ ╢#
IRestaurantRepository
((╖ ╠"
restaurantRepository
((═ с
,
((с т!
ICategoryRepository
((у Ў 
categoryRepository
((ў Й
,
((Й К 
IProductRepository
((Л Э
productRepository
((Ю п
,
((п ░#
IIngredientRepository
((▒ ╞"
ingredientRepository
((╟ █
,
((█ ▄*
IProductIngredientRepository
((▌ ∙)
productIngredientRepository
((· Х
,
((Х Ц!
ICustomerRepository
((Ч к 
customerRepository
((л ╜
,
((╜ ╛!
IEmployeeRepository
((┐ ╥ 
employeeRepository
((╙ х
,
((х ц-
IIngrdientTransactionRepository
((ч Ж,
ingrdientTransactionRepository
((З е
,
((е ж%
IProductComboRepository
((з ╛$
productComboRepository
((┐ ╒
,
((╒ ╓
IComboRepository
((╫ ч
comboRepository
((ш ў
,
((ў °
IOrderRepository
((∙ Й
orderRepository
((К Щ
,
((Щ Ъ$
IOrderDetailRepository
((Ы ▒#
orderDetailRepository
((▓ ╟
,
((╟ ╚
IShiftRepository
((╔ ┘
shiftRepository
((┌ щ
,
((щ ъ'
IWaiterScheduleRepository
((ы Д&
waiterScheduleRepository
((Е Э
,
((Э Ю 
IGroupChatRepository)) 
groupChatRepository)) 0
,))0 1#
IGroupMessageRepository))2 I"
groupMessageRepository))J `
,))` a 
IGroupUserRepository))b v 
groupUserRepository	))w К
,
))К Л#
IProductImageRepository** "
productImageRepository**  6
,**6 7
IRatingRepository++ 
ratingRepository++ *
,++* +
IPaymentRepository++, >
paymentRepository++? P
,++P Q!
IAttendanceRepository++R g 
attendanceRepository++h |
,++| }&
IIngredientUnitRepository	++~ Ч&
ingredientUnitRepository
++Ш ░
,
++░ ▒,
INewProductRecommendRepository
++▓ ╨+
newProductRecommendRepository
++╤ ю
,
++ю я/
!INewProductRecommendLogRepository
++Ё С.
 newProductRecommendLogRepository
++Т ▓
)
++▓ │
{,, 
_context-- 
=-- 
context-- 
;-- %
_ingredientTypeRepository.. !
=.." #$
ingredientTypeRepository..$ <
;..< =(
_ingredientGeneralRepository// $
=//% &'
ingredientGeneralRepository//' B
;//B C
_tableRepository00 
=00 
tableRepository00 *
;00* +!
_restaurantRepository11 
=11  
restaurantRepository11  4
;114 5%
_productGeneralRepository22 !
=22" #$
productGeneralRepository22$ <
;22< =/
#_productIngredientGeneralRepository33 +
=33, -.
"productIngredientGeneralRepository33. P
;33P Q
_categoryRepository44 
=44 
categoryRepository44 0
;440 1
_productRepository55 
=55 
productRepository55 .
;55. /!
_ingredientRepository66 
=66  
ingredientRepository66  4
;664 5(
_productIngredientRepository77 $
=77% &'
productIngredientRepository77' B
;77B C
_customerRepository88 
=88 
customerRepository88 0
;880 1
_employeeRepository99 
=99 
employeeRepository99 0
;990 1+
_ingrdientTransactionRepository:: '
=::( )*
ingrdientTransactionRepository::* H
;::H I#
_productComboRepository;; 
=;;  !"
productComboRepository;;" 8
;;;8 9
_comboRepository<< 
=<< 
comboRepository<< *
;<<* +
_orderRepository== 
=== 
orderRepository== *
;==* +"
_orderDetailRepository>> 
=>>  !
orderDetailRepository>>! 6
;>>6 7
_shiftRepository?? 
=?? 
shiftRepository?? *
;??* +%
_waiterScheduleRepository@@ !
=@@" #$
waiterScheduleRepository@@$ <
;@@< = 
_groupChatRepositoryAA 
=AA 
groupChatRepositoryAA 2
;AA2 3#
_groupMessageRepositoryBB 
=BB  !"
groupMessageRepositoryBB" 8
;BB8 9 
_groupUserRepositoryCC 
=CC 
groupUserRepositoryCC 2
;CC2 3#
_productImageRepositoryDD 
=DD  !"
productImageRepositoryDD" 8
;DD8 9
_ratingRepositoryEE 
=EE 
ratingRepositoryEE ,
;EE, -
_paymentRepositoryFF 
=FF 
paymentRepositoryFF .
;FF. /!
_attendanceRepositoryGG 
=GG  
attendanceRepositoryGG  4
;GG4 5%
_ingredientUnitRepositoryHH !
=HH" #$
ingredientUnitRepositoryHH$ <
;HH< =!
_attendanceRepositoryII 
=II  
attendanceRepositoryII  4
;II4 5-
!_newProductRecommendLogRepositoryJJ )
=JJ* +,
 newProductRecommendLogRepositoryJJ, L
;JJL M*
_newProductRecommendRepositoryKK &
=KK' ()
newProductRecommendRepositoryKK) F
;KKF G
}LL 
publicMM 
%
IIngredientTypeRepositoryMM $$
IngredientTypeRepositoryMM% =
=>MM> @%
_ingredientTypeRepositoryMMA Z
;MMZ [
publicNN 
(
IIngredientGeneralRepositoryNN ''
IngredientGeneralRepositoryNN( C
=>NND F(
_ingredientGeneralRepositoryNNG c
;NNc d
publicOO 

ITableRepositoryOO 
TableRepositoryOO +
=>OO, .
_tableRepositoryOO/ ?
;OO? @
publicPP 
!
IRestaurantRepositoryPP   
RestaurantRepositoryPP! 5
=>PP6 8!
_restaurantRepositoryPP9 N
;PPN O
publicRR 
%
IProductGeneralRepositoryRR $$
ProductGeneralRepositoryRR% =
=>RR> @%
_productGeneralRepositoryRRA Z
;RRZ [
publicTT 
/
#IProductIngredientGeneralRepositoryTT ..
"ProductIngredientGeneralRepositoryTT/ Q
=>TTR T/
#_productIngredientGeneralRepositoryTTU x
;TTx y
publicVV 

ICategoryRepositoryVV 
CategoryRepositoryVV 1
=>VV2 4
_categoryRepositoryVV5 H
;VVH I
publicXX 

IProductRepositoryXX 
ProductRepositoryXX /
=>XX0 2
_productRepositoryXX3 E
;XXE F
publicZZ 
!
IIngredientRepositoryZZ   
IngredientRepositoryZZ! 5
=>ZZ6 8!
_ingredientRepositoryZZ9 N
;ZZN O
public\\ 
(
IProductIngredientRepository\\ ''
ProductIngredientRepository\\( C
=>\\D F(
_productIngredientRepository\\G c
;\\c d
public^^ 

IEmployeeRepository^^ 
EmployeeRepository^^ 1
=>^^2 4
_employeeRepository^^5 H
;^^H I
public`` 

ICustomerRepository`` 
CustomerRepository`` 1
=>``2 4
_customerRepository``5 H
;``H I
publicbb 
+
IIngrdientTransactionRepositorybb *+
IngredientTransactionRepositorybb+ J
=>bbK M+
_ingrdientTransactionRepositorybbN m
;bbm n
publicdd 
#
IProductComboRepositorydd ""
ProductComboRepositorydd# 9
=>dd: <#
_productComboRepositorydd= T
;ddT U
publicff 

IComboRepositoryff 
ComboRepositoryff +
=>ff, .
_comboRepositoryff/ ?
;ff? @
publichh 

IOrderRepositoryhh 
OrderRepositoryhh +
=>hh, .
_orderRepositoryhh/ ?
;hh? @
publicjj 
"
IOrderDetailRepositoryjj !!
OrderDetailRepositoryjj" 7
=>jj8 :"
_orderDetailRepositoryjj; Q
;jjQ R
publickk 

IShiftRepositorykk 
ShiftRepositorykk +
=>kk, .
_shiftRepositorykk/ ?
;kk? @
publicll 
%
IWaiterScheduleRepositoryll $$
WaiterScheduleRepositoryll% =
=>ll> @%
_waiterScheduleRepositoryllA Z
;llZ [
publicnn 
 
IGroupChatRepositorynn 
GroupChatRepositorynn  3
=>nn4 6 
_groupChatRepositorynn7 K
;nnK L
publicpp 
#
IGroupMessageRepositorypp ""
GroupMessageRepositorypp# 9
=>pp: <#
_groupMessageRepositorypp= T
;ppT U
publicrr 
 
IGroupUserRepositoryrr 
GroupUserRepositoryrr  3
=>rr4 6 
_groupUserRepositoryrr7 K
;rrK L
publictt 
#
IProductImageRepositorytt ""
ProductImageRepositorytt# 9
=>tt: <#
_productImageRepositorytt= T
;ttT U
publicvv 

IPaymentRepositoryvv 
PaymentRepositoryvv /
=>vv0 2
_paymentRepositoryvv3 E
;vvE F
publicxx 
!
IAttendanceRepositoryxx   
AttendanceRepositoryxx! 5
=>xx6 8!
_attendanceRepositoryxx9 N
;xxN O
publiczz 
%
IIngredientUnitRepositoryzz $$
IngredientUnitRepositoryzz% =
=>zz> @%
_ingredientUnitRepositoryzzA Z
;zzZ [
public|| 
-
!INewProductRecommendLogRepository|| ,,
 NewProductRecommendLogRepository||- M
=>||N P-
!_newProductRecommendLogRepository||Q r
;||r s
public~~ 
*
INewProductRecommendRepository~~ ))
NewProductRecommendRepository~~* G
=>~~H J*
_newProductRecommendRepository~~K i
;~~i j
public
АА 

async
АА 
Task
АА 
<
АА 
int
АА 
>
АА 
SaveChangeAsync
АА *
(
АА* +
)
АА+ ,
{
ББ 
return
ВВ 
await
ВВ 
_context
ВВ 
.
ВВ 
SaveChangesAsync
ВВ .
(
ВВ. /
)
ВВ/ 0
;
ВВ0 1
}
ГГ 
}ДД Р&
yC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\UnitOfWork\IUnitOfWorkSetup\IUnitOfWorks.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

UnitOfWork '
.' (
IUnitOfWorkSetup( 8
;8 9
public 
	interface 
IUnitOfWorks 
{ 
public		 
#
IProductImageRepository		 ""
ProductImageRepository		# 9
{		: ;
get		< ?
;		? @
}		A B
public

 
%
IIngredientTypeRepository

 $$
IngredientTypeRepository

% =
{

> ?
get

@ C
;

C D
}

E F
public 
(
IIngredientGeneralRepository ''
IngredientGeneralRepository( C
{D E
getF I
;I J
}K L
public 

ITableRepository 
TableRepository +
{, -
get. 1
;1 2
}3 4
public 
!
IRestaurantRepository   
RestaurantRepository! 5
{6 7
get8 ;
;; <
}= >
public 
%
IProductGeneralRepository $$
ProductGeneralRepository% =
{> ?
get@ C
;C D
}E F
public 
/
#IProductIngredientGeneralRepository ..
"ProductIngredientGeneralRepository/ Q
{R S
getT W
;W X
}Y Z
public 
(
IProductIngredientRepository ''
ProductIngredientRepository( C
{D E
getF I
;I J
}K L
public 

IProductRepository 
ProductRepository /
{0 1
get2 5
;5 6
}7 8
public 

IEmployeeRepository 
EmployeeRepository 1
{2 3
get4 7
;7 8
}9 :
public 

ICustomerRepository 
CustomerRepository 1
{2 3
get4 7
;7 8
}9 :
public 
!
IIngredientRepository   
IngredientRepository! 5
{6 7
get8 ;
;; <
}= >
public 

ICategoryRepository 
CategoryRepository 1
{2 3
get4 7
;7 8
}9 :
public 

IOrderRepository 
OrderRepository +
{, -
get. 1
;1 2
}3 4
public 
"
IOrderDetailRepository !!
OrderDetailRepository" 7
{8 9
get: =
;= >
}? @
public 

IShiftRepository 
ShiftRepository +
{, -
get. 1
;1 2
}3 4
public 
%
IWaiterScheduleRepository $$
WaiterScheduleRepository% =
{> ?
get@ C
;C D
}E F
public   
+
IIngrdientTransactionRepository   *+
IngredientTransactionRepository  + J
{  K L
get  M P
;  P Q
}  R S
public"" 
#
IProductComboRepository"" ""
ProductComboRepository""# 9
{"": ;
get""< ?
;""? @
}""A B
public$$ 
 
IGroupChatRepository$$ 
GroupChatRepository$$  3
{$$4 5
get$$6 9
;$$9 :
}$$; <
public&& 
#
IGroupMessageRepository&& ""
GroupMessageRepository&&# 9
{&&: ;
get&&< ?
;&&? @
}&&A B
public)) 
 
IGroupUserRepository)) 
GroupUserRepository))  3
{))4 5
get))6 9
;))9 :
})); <
public** 

IComboRepository** 
ComboRepository** +
{**, -
get**. 1
;**1 2
}**3 4
public++ 

IPaymentRepository++ 
PaymentRepository++ /
{++0 1
get++2 5
;++5 6
}++7 8
public,, 
!
IAttendanceRepository,,   
AttendanceRepository,,! 5
{,,6 7
get,,8 ;
;,,; <
},,= >
public.. 
%
IIngredientUnitRepository.. $$
IngredientUnitRepository..% =
{..> ?
get..@ C
;..C D
}..E F
public11 
-
!INewProductRecommendLogRepository11 ,,
 NewProductRecommendLogRepository11- M
{11N O
get11P S
;11S T
}11U V
public33 
*
INewProductRecommendRepository33 ))
NewProductRecommendRepository33* G
{33H I
get33J M
;33M N
}33O P
public55 

Task55 
<55 
int55 
>55 
SaveChangeAsync55 $
(55$ %
)55% &
;55& '
}66 о
БC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\WaiterScheduleRepository.cs
	namespace

 	
FOV


 
.

 
Infrastructure

 
.

 

Repository

 '
.

' (
Repositories

( 4
;

4 5
public 
class $
WaiterScheduleRepository %
:& '
GenericRepository( 9
<9 :
WaiterSchedule: H
>H I
,I J%
IWaiterScheduleRepositoryK d
{ 
public 
$
WaiterScheduleRepository #
(# $

FOVContext$ .
context/ 6
)6 7
:8 9
base: >
(> ?
context? F
)F G
{ 
} 
} в
xC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\TableRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class 
TableRepository 
: 
GenericRepository 0
<0 1
Table1 6
>6 7
,7 8
ITableRepository9 I
{ 
private 
readonly 

FOVContext 
_context  (
;( )
public 

TableRepository 
( 

FOVContext %
context& -
)- .
:/ 0
base1 5
(5 6
context6 =
)= >
{ 
_context 
= 
context 
; 
} 
public 

async 
Task 
< 
int 
? 
> &
GetHighestTableNumberAsync 6
(6 7
Guid7 ;
restaurantId< H
)H I
{ 
return 
await 
_context 
. 
Tables $
.	 

Where
 
( 
t 
=> 
t 
. 
RestaurantId #
==$ &
restaurantId' 3
)3 4
.	 

Select
 
( 
t 
=> 
( 
int 
? 
) 
t 
. 
TableNumber )
)) *
.	 

MaxAsync
 
( 
) 
?? 
$num 
; 
} 
} А
xC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\ShiftRepository.cs
	namespace

 	
FOV


 
.

 
Infrastructure

 
.

 

Repository

 '
.

' (
Repositories

( 4
;

4 5
public 
class 
ShiftRepository 
: 
GenericRepository 0
<0 1
Shift1 6
>6 7
,7 8
IShiftRepository9 I
{ 
public 

ShiftRepository 
( 

FOVContext %
context& -
)- .
:/ 0
base1 5
(5 6
context6 =
)= >
{ 
} 
} Й
}C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\RestaurantRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public		 
class		  
RestaurantRepository		 !
:		" #
GenericRepository		$ 5
<		5 6

Restaurant		6 @
>		@ A
,		A B!
IRestaurantRepository		C X
{

 
private 
readonly 

FOVContext 
_context  (
;( )
public 
 
RestaurantRepository 
(  

FOVContext  *
context+ 2
)2 3
:4 5
base6 :
(: ;
context; B
)B C
{ 
_context 
= 
context 
; 
} 
public 

async 
Task 
< 
bool 
> 
AnyAsync $
($ %

Expression% /
</ 0
Func0 4
<4 5

Restaurant5 ?
,? @
boolA E
>E F
>F G
	predicateH Q
)Q R
{ 
return 
await 
_context 
. 
Restaurants )
.) *
AnyAsync* 2
(2 3
	predicate3 <
)< =
;= >
} 
} Е
yC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\RatingRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class 
RatingRepository 
: 
GenericRepository  1
<1 2
Rating2 8
>8 9
,9 :
IRatingRepository; L
{ 
public 

RatingRepository 
( 

FOVContext &
context' .
). /
:0 1
base2 6
(6 7
context7 >
)> ?
{		 
}

 
} К
zC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\ProductRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class 
ProductRepository 
:  
GenericRepository! 2
<2 3
Product3 :
>: ;
,; <
IProductRepository= O
{ 
public 

ProductRepository 
( 

FOVContext '
context( /
)/ 0
:1 2
base3 7
(7 8
context8 ?
)? @
{		 
}

 
} ╜
ДC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\ProductIngredientRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class '
ProductIngredientRepository (
:) *
GenericRepository+ <
<< =
ProductIngredient= N
>N O
,O P(
IProductIngredientRepositoryQ m
{ 
public 
'
ProductIngredientRepository &
(& '

FOVContext' 1
context2 9
)9 :
:; <
base= A
(A B
contextB I
)I J
{		 
}

 
} с
ЛC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\ProductIngredientGeneralRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class .
"ProductIngredientGeneralRepository /
:0 1
GenericRepository2 C
<C D$
ProductIngredientGeneralD \
>\ ]
,] ^0
#IProductIngredientGeneralRepository	_ В
{ 
public		 
.
"ProductIngredientGeneralRepository		 -
(		- .

FOVContext		. 8
context		9 @
)		@ A
:		B C
base		D H
(		H I
context		I P
)		P Q
{

 
} 
} г
C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\ProductImageRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class "
ProductImageRepository #
:$ %
GenericRepository& 7
<7 8
ProductImage8 D
>D E
,E F#
IProductImageRepositoryG ^
{ 
public 
"
ProductImageRepository !
(! "

FOVContext" ,
context- 4
)4 5
:6 7
base8 <
(< =
context= D
)D E
{		 
}

 
} └B
БC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\ProductGeneralRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public		 
class		 $
ProductGeneralRepository		 %
:		& '
GenericRepository		( 9
<		9 :
ProductGeneral		: H
>		H I
,		I J%
IProductGeneralRepository		K d
{

 
private 
readonly 

FOVContext 
_context  (
;( )
public 
$
ProductGeneralRepository #
(# $

FOVContext$ .
context/ 6
)6 7
:8 9
base: >
(> ?
context? F
)F G
{ 
_context 
= 
context 
; 
} 
public 

List 
< 
ProductCheckDTO 
>  

GetProduct! +
(+ ,
Guid, 0
restaurantId1 =
)= >
=>? A
GetProductsB M
(M N
_contextN V
,V W
restaurantIdX d
)d e
.e f
ToListf l
(l m
)m n
;n o
public 

List 
< 
ComboCheckDTO 
> 
GetCombo '
(' (
Guid( ,
restaurantId- 9
)9 :
=>; =
	GetCombos> G
(G H
_contextH P
,P Q
restaurantIdR ^
)^ _
._ `
ToList` f
(f g
)g h
;h i
public 

static 
IEnumerable 
< 
ComboCheckDTO +
>+ ,
	GetCombos- 6
(6 7

FOVContext7 A
contextB I
,I J
GuidK O
RestaurantIdP \
)\ ]
{ 
var 
productAvailability 
=  !
context" )
.) *
Products* 2
. 
Where 
( 
p 
=> 
p 
. 
RestaurantId &
==' )
RestaurantId* 6
)6 7
. 
Select 
( 
p 
=> 
new 
{ 
p 
. 
Id 
, 
MinCreatable 
= 
context &
.& '
ProductIngredients' 9
. 
Select 
( 
pi 
=> !
pi" $
.$ %

Ingredient% /
./ 0
IngredientAmount0 @
/A B
piC E
.E F
QuantityF N
)N O
. 
DefaultIfEmpty #
(# $
$num$ %
)% &
.   
Min   
(   
)   
}!! 
)!! 
."" 
ToDictionary"" 
("" 
p"" 
=>"" 
p""  
.""  !
Id""! #
,""# $
p""% &
=>""' )
p""* +
.""+ ,
MinCreatable"", 8
)""8 9
;""9 :
var%% 
	comboData%% 
=%% 
context%% 
.%%  
Combos%%  &
.&& 
Where&& 
(&& 
c&& 
=>&& 
c&& 
.&& 
RestaurantId&& &
==&&' )
RestaurantId&&* 6
)&&6 7
.'' 
Select'' 
('' 
combo'' 
=>'' 
new''  
{(( 
combo)) 
.)) 
Id)) 
,)) 
Products** 
=** 
context** "
.**" #
ProductCombos**# 0
.++ 
Where++ 
(++ 
cp++ 
=>++  
cp++! #
.++# $
ComboId++$ +
==++, .
combo++/ 4
.++4 5
Id++5 7
)++7 8
.,, 
Select,, 
(,, 
cp,, 
=>,, !
new,," %
{-- 
cp.. 
... 
	ProductId.. $
,..$ %
}// 
)// 
.// 
ToList// 
(// 
)// 
}00 
)00 
.11 

AsParallel11 
(11 
)11 
.22 
Select22 
(22 
combo22 
=>22 
{33 
int44 
	minCombos44 
=44 
(44  !
int44! $
)44$ %
combo44% *
.44* +
Products44+ 3
.55 
Select55 
(55 
product55 #
=>55$ &
productAvailability55' :
.55: ;
TryGetValue55; F
(55F G
product55G N
.55N O
	ProductId55O X
,55X Y
out55Z ]
decimal55^ e
	available55f o
)55o p
?66 
	available66 #
/66$ %
$num66& '
:77 
$num77 
)77 
.88 
DefaultIfEmpty88 #
(88# $
$num88$ %
)88% &
.99 
Min99 
(99 
)99 
;99 
return;; 
new;; 
ComboCheckDTO;; (
(;;( )
combo;;) .
.;;. /
Id;;/ 1
,;;1 2
	minCombos;;3 <
);;< =
;;;= >
}<< 
)<< 
.== 
ToList== 
(== 
)== 
;== 
return?? 
	comboData?? 
;?? 
}@@ 
publicBB 

staticBB 
IEnumerableBB 
<BB 
ProductCheckDTOBB -
>BB- .
GetProductsBB/ :
(BB: ;

FOVContextBB; E
contextBBF M
,BBM N
GuidBBO S
RestaurantIdBBT `
)BB` a
{CC 
varEE 
productDataEE 
=EE 
contextEE !
.EE! "
ProductsEE" *
.FF 
WhereFF 
(FF 
xFF 
=>FF 
xFF 
.FF 
RestaurantIdFF &
==FF' )
RestaurantIdFF* 6
)FF6 7
.GG 
SelectGG 
(GG 
productGG 
=>GG 
newGG "
{HH 
productII 
.II 
IdII 
,II 
IngredientsJJ 
=JJ 
contextJJ %
.JJ% &
ProductIngredientsJJ& 8
.KK 
WhereKK 
(KK 
piKK 
=>KK  
piKK! #
.KK# $
	ProductIdKK$ -
==KK. 0
productKK1 8
.KK8 9
IdKK9 ;
)KK; <
.LL 
SelectLL 
(LL 
piLL 
=>LL !
newLL" %
IngredientCheckDTOLL& 8
(LL8 9
piMM 
.MM 
IngredientIdMM '
,MM' (
piNN 
.NN 
QuantityNN #
,NN# $
piOO 
.OO 

IngredientOO %
.OO% &
IngredientAmountOO& 6
)PP 
)PP 
.PP 
ToListPP 
(PP 
)PP 
}QQ 
)QQ 
.RR 
ToListRR 
(RR 
)RR 
;RR 
varUU 
resultUU 
=UU 
productDataUU  
.VV 
SelectVV 
(VV 
productVV 
=>VV 
{WW 
intYY 
minCreatableYY  
=YY! "
(YY# $
intYY$ '
)YY' (
productYY( /
.YY/ 0
IngredientsYY0 ;
.ZZ 
MinZZ 
(ZZ 
iZZ 
=>ZZ 
iZZ 
.ZZ  
TotalQuantityZZ  -
/ZZ. /
iZZ0 1
.ZZ1 2
QuantityNeededZZ2 @
)ZZ@ A
;ZZA B
return\\ 
new\\ 
ProductCheckDTO\\ *
(\\* +
product\\+ 2
.\\2 3
Id\\3 5
,\\5 6
minCreatable\\7 C
)\\C D
;\\D E
}]] 
)]] 
.^^ 
ToList^^ 
(^^ 
)^^ 
;^^ 
return`` 
result`` 
;`` 
}aa 
}bb г
C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\ProductComboRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class "
ProductComboRepository #
:$ %
GenericRepository& 7
<7 8
ProductCombo8 D
>D E
,E F#
IProductComboRepositoryG ^
{ 
public 
"
ProductComboRepository !
(! "

FOVContext" ,
context- 4
)4 5
:6 7
base8 <
(< =
context= D
)D E
{		 
}

 
} Ь
zC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\PaymentRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class 
PaymentRepository 
:  
GenericRepository! 2
<2 3
Payments3 ;
>; <
,< =
IPaymentRepository> P
{ 
private 
readonly 

FOVContext 
_context  (
;( )
public 

PaymentRepository 
( 

FOVContext '
context( /
)/ 0
:1 2
base3 7
(7 8
context8 ?
)? @
{ 
_context 
= 
context 
; 
} 
public 

async 
Task 
< 
Payments 
> "
GetFirstOrDefaultAsync  6
(6 7
Func7 ;
<; <
Payments< D
,D E
boolF J
>J K
	predicateL U
)U V
{ 
return 
await 
_context 
. 
Payments &
.& '
AsQueryable' 2
(2 3
)3 4
.4 5
FirstOrDefaultAsync5 H
(H I
pI J
=>K M
	predicateN W
(W X
pX Y
)Y Z
)Z [
;[ \
} 
public 

async 
Task 
< 
Payments 
> #
GetPaymentByTxnRefAsync  7
(7 8
string8 >
txnRef? E
)E F
{ 
return 
await 
_context 
. 
Payments &
.& '
FirstOrDefaultAsync' :
(: ;
p; <
=>= ?
p@ A
.A B
	VnpTxnRefB K
==L N
txnRefO U
)U V
;V W
} 
} ╤
xC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\OrderRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class 
OrderRepository 
: 
GenericRepository 0
<0 1
Order1 6
>6 7
,7 8
IOrderRepository9 I
{ 
private 
readonly 

FOVContext 
_context  (
;( )
public 

OrderRepository 
( 

FOVContext %
context& -
)- .
:/ 0
base1 5
(5 6
context6 =
)= >
{ 
_context 
= 
context 
; 
} 
public 

async 
Task 
< 
Order 
> 
GetByTableIdAsync .
(. /
Guid/ 3
tableId4 ;
); <
{ 
return 
await 
_context 
. 
Orders $
. 
FirstOrDefaultAsync 1
(1 2
o2 3
=>4 6
o7 8
.8 9
TableId9 @
==A C
tableIdD K
)K L
;L M
} 
} х
~C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\OrderDetailRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class !
OrderDetailRepository "
:# $
GenericRepository% 6
<6 7
OrderDetail7 B
>B C
,C D"
IOrderDetailRepositoryE [
{ 
private 
readonly 

FOVContext 
_context  (
;( )
public 
!
OrderDetailRepository  
(  !

FOVContext! +
context, 3
)3 4
:5 6
base7 ;
(; <
context< C
)C D
{ 
_context 
= 
context 
; 
} 
public 

async 
Task 
< 
List 
< 
OrderDetail &
>& '
>' (
GetByOrderIdAsync) :
(: ;
Guid; ?
orderId@ G
)G H
{ 
return 
await 
_context 
. 
OrderDetails *
. 
Where 
( 
od 
=> 
od 
. 
OrderId #
==$ &
orderId' .
). /
. 
ToListAsync 
( 
) 
; 
} 
} ╟
ЖC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\NewProductRecommendRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class )
NewProductRecommendRepository *
:+ ,
GenericRepository- >
<> ?
NewProductRecommend? R
>R S
,S T*
INewProductRecommendRepositoryU s
{ 
public 
)
NewProductRecommendRepository (
(( )

FOVContext) 3
context4 ;
); <
:= >
base? C
(C D
contextD K
)K L
{		 
}

 
} ╓
ЙC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\NewProductRecommendLogRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class ,
 NewProductRecommendLogRepository -
:. /
GenericRepository0 A
<A B"
NewProductRecommendLogB X
>X Y
,Y Z-
!INewProductRecommendLogRepository[ |
{ 
public 
,
 NewProductRecommendLogRepository +
(+ ,

FOVContext, 6
context7 >
)> ?
:@ A
baseB F
(F G
contextG N
)N O
{		 
}

 
} о
БC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\IngredientUnitRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class $
IngredientUnitRepository %
:& '
GenericRepository( 9
<9 :
IngredientUnit: H
>H I
,I J%
IIngredientUnitRepositoryK d
{ 
public 
$
IngredientUnitRepository #
(# $

FOVContext$ .
context/ 6
)6 7
:8 9
base: >
(> ?
context? F
)F G
{		 
}

 
} ╥
БC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\IngredientTypeRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class $
IngredientTypeRepository %
:& '
GenericRepository( 9
<9 :
IngredientType: H
>H I
,I J%
IIngredientTypeRepositoryK d
{		 
private

 
readonly

 

FOVContext

 
_context

  (
;

( )
public 
$
IngredientTypeRepository #
(# $

FOVContext$ .
context/ 6
)6 7
:8 9
base: >
(> ?
context? F
)F G
{ 
_context 
= 
context 
; 
} 
public 

async 
Task &
UpdateParentIngredientType 0
(0 1
Guid1 5
parentId6 >
,> ?
int@ C
rightD I
)I J
{ 
var 
category 
= 
await 
_context %
.% &
IngredientTypes& 5
.5 6
FirstOrDefaultAsync6 I
(I J
xJ K
=>L N
xO P
.P Q
IdQ S
==T V
parentIdW _
)_ `
;` a
_context 
. 
IngredientTypes  
.  !
Where! &
(& '
x' (
=>) +
x, -
.- .
IngredientMain. <
=== ?
category@ H
.H I
IngredientMainI W
&&X Z
x[ \
.\ ]
Right] b
>=c e
rightf k
)k l
.l m
ExecuteUpdatem z
(z {
x{ |
=>} 
x
А Б
.
Б В
SetProperty
В Н
(
Н О
b
О П
=>
Р Т
b
У Ф
.
Ф Х
Right
Х Ъ
,
Ъ Ы
b
Ь Э
=>
Ю а
b
б в
.
в г
Right
г и
+
й к
$num
л м
)
м н
)
н о
;
о п
_context 
. 
IngredientTypes  
.  !
Where! &
(& '
x' (
=>) +
x, -
.- .
IngredientMain. <
=== ?
category@ H
.H I
IngredientMainI W
&&X Z
x[ \
.\ ]
Left] a
>b c
rightd i
)i j
.j k
ExecuteUpdatek x
(x y
xy z
=>{ }
x~ 
.	 А
SetProperty
А Л
(
Л М
b
М Н
=>
О Р
b
С Т
.
Т У
Left
У Ч
,
Ч Ш
b
Щ Ъ
=>
Ы Э
b
Ю Я
.
Я а
Right
а е
+
ж з
$num
и й
)
й к
)
к л
;
л м
} 
} °
}C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\IngredientRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class  
IngredientRepository !
:" #
GenericRepository$ 5
<5 6

Ingredient6 @
>@ A
,A B!
IIngredientRepositoryC X
{		 
private

 
readonly

 

FOVContext

 
_context

  (
;

( )
public 
 
IngredientRepository 
(  

FOVContext  *
context+ 2
)2 3
:4 5
base6 :
(: ;
context; B
)B C
{ 
_context 
= 
context 
; 
} 
public 

async 
Task 
HandleExpried #
(# $
)$ %
{ 
var 
ingredienttypes 
= 
_context &
.& '
IngredientTypes' 6
.6 7
ToList7 =
(= >
)> ?
;? @
foreach 
( 
var 
ingredientType #
in$ &
ingredienttypes' 6
)6 7
{ 	
foreach 
( 
var 

ingredient #
in$ &
ingredientType' 5
.5 6
Ingredients6 A
)A B
{ 
foreach 
( 
var 
transaction (
in) +

ingredient, 6
.6 7"
IngredientTransactions7 M
.M N
WhereN S
(S T
xT U
=>V X
xY Z
.Z [
	IsDeleted[ d
==e g
falseh m
)m n
)n o
{ 
if 
( 
transaction #
.# $
TransactionDate$ 3
.3 4
AddDays4 ;
(; <
ingredientType< J
.J K
ExpiredTimeK V
)V W
>=X Z
DateTime[ c
.c d
UtcNowd j
)j k
{ 

Ingredient "
updateIngredient# 3
=4 5
await6 ;
_context< D
.D E
IngredientsE P
.P Q 
SingleOrDefaultAsyncQ e
(e f
xf g
=>h j
xk l
.l m
Idm o
==p r

ingredients }
.} ~
Id	~ А
)
А Б
??
В Д
throw
Е К
new
Л О
	Exception
П Ш
(
Ш Щ
)
Щ Ъ
;
Ъ Ы
updateIngredient (
.( )!
UpdateExpriedQuantity) >
(> ?
transaction? J
.J K
QuantityK S
)S T
;T U
_context    
.    !
Ingredients  ! ,
.  , -
Update  - 3
(  3 4
updateIngredient  4 D
)  D E
;  E F
}"" 
}## 
}%% 
}&& 	
}'' 
}(( ╜
ДC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\IngredientGeneralRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class '
IngredientGeneralRepository (
:) *
GenericRepository+ <
<< =
IngredientGeneral= N
>N O
,O P(
IIngredientGeneralRepositoryQ m
{		 
public

 
'
IngredientGeneralRepository

 &
(

& '

FOVContext

' 1
context

2 9
)

9 :
:

; <
base

= A
(

A B
context

B I
)

I J
{ 
} 
} ═
ЗC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\IngrdientTransactionRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class *
IngrdientTransactionRepository +
:, -
GenericRepository. ?
<? @!
IngredientTransaction@ U
>U V
,V W+
IIngrdientTransactionRepositoryX w
{ 
public 
*
IngrdientTransactionRepository )
() *

FOVContext* 4
context5 <
)< =
:> ?
base@ D
(D E
contextE L
)L M
{		 
}

 
} Ц
|C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\GroupUserRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
internal 
class	 
GroupUserRepository "
:# $
GenericRepository% 6
<6 7
	GroupUser7 @
>@ A
,A B 
IGroupUserRepositoryC W
{ 
public 

GroupUserRepository 
( 

FOVContext )
context* 1
)1 2
:3 4
base5 9
(9 :
context: A
)A B
{		 
}

 
} е
C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\GroupMessageRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
internal 
class	 "
GroupMessageRepository %
:& '
GenericRepository( 9
<9 :
GroupMessage: F
>F G
,G H#
IGroupMessageRepositoryI `
{ 
public 
"
GroupMessageRepository !
(! "

FOVContext" ,
context- 4
)4 5
:6 7
base8 <
(< =
context= D
)D E
{		 
}

 
} Ц
|C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\GroupChatRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
internal 
class	 
GroupChatRepository "
:# $
GenericRepository% 6
<6 7
	GroupChat7 @
>@ A
,A B 
IGroupChatRepositoryC W
{ 
public 

GroupChatRepository 
( 

FOVContext )
context* 1
)1 2
:3 4
base5 9
(9 :
context: A
)A B
{		 
}

 
} ЧT
zC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\GenericRepository.cs
	namespace		 	
FOV		
 
.		 
Infrastructure		 
.		 

Repository		 '
.		' (
Repositories		( 4
;		4 5
public 
class 
GenericRepository 
< 
TEntity &
>& '
:( )
IGenericRepository* <
<< =
TEntity= D
>D E
whereF K
TEntityL S
:T U
BaseAuditableEntityV i
{ 
	protected 
DbSet 
< 
TEntity 
> 
_dbSet #
;# $
public 

GenericRepository 
( 

FOVContext '
context( /
)/ 0
{ 
_dbSet 
= 
context 
. 
Set 
< 
TEntity $
>$ %
(% &
)& '
;' (
} 
public 

async 
Task 
< 
TEntity 
> 
AddAsync '
(' (
TEntity( /
entity0 6
)6 7
{ 
entity 
. 
Created 
= 
CurrentTime $
.$ %

RecentTime% /
;/ 0
var 
result 
= 
await 
_dbSet !
.! "
AddAsync" *
(* +
entity+ 1
)1 2
;2 3
return 
result 
. 
Entity 
; 
} 
public 

async 
Task 
AddRangeAsync #
(# $
List$ (
<( )
TEntity) 0
>0 1
entities2 :
): ;
{ 
foreach 
( 
var 
entity 
in 
entities '
)' (
{ 	
entity 
. 
Created 
= 
CurrentTime (
.( )

RecentTime) 3
;3 4
} 	
await   
_dbSet   
.   
AddRangeAsync   "
(  " #
entities  # +
)  + ,
;  , -
}!! 
public## 

async## 
Task## 
<## 
TEntity## 
?## 
>## 
FirstOrDefaultAsync##  3
(##3 4

Expression##4 >
<##> ?
Func##? C
<##C D
TEntity##D K
,##K L
bool##M Q
>##Q R
>##R S

expression##T ^
,##^ _
params##` f

Expression##g q
<##q r
Func##r v
<##v w
TEntity##w ~
,##~ 
object
##А Ж
>
##Ж З
>
##З И
[
##И Й
]
##Й К
includes
##Л У
)
##У Ф
=>$$ 
await$$	 
includes$$ 
.%% 
	Aggregate%% 
(%% 
_dbSet%% 
!%% 
.%% 
AsQueryable%% *
(%%* +
)%%+ ,
,%%, -
(%%. /
entity%%/ 5
,%%5 6
property%%7 ?
)%%? @
=>%%A C
entity%%D J
!%%J K
.%%K L
Include%%L S
(%%S T
property%%T \
)%%\ ]
)%%] ^
.%%^ _
AsNoTracking%%_ k
(%%k l
)%%l m
.&& 
Where&& 
(&& 

expression&& 
!&& 
)&& 
.'' 
FirstOrDefaultAsync''  
(''  !
)''! "
;''" #
public)) 

async)) 
Task)) 
<)) 
List)) 
<)) 
TEntity)) "
>))" #
>))# $
GetAllAsync))% 0
())0 1
params))1 7

Expression))8 B
<))B C
Func))C G
<))G H
TEntity))H O
,))O P
object))Q W
>))W X
>))X Y
[))Y Z
]))Z [
includes))\ d
)))d e
=>))f h
await** 	
includes**
 
.** 
	Aggregate** 
(** 
_dbSet** #
.**# $
AsQueryable**$ /
(**/ 0
)**0 1
,**1 2
(**3 4
entity**4 :
,**: ;
property**< D
)**D E
=>**F H
entity**I O
.**O P
Include**P W
(**W X
property**X `
)**` a
.**a b
IgnoreAutoIncludes**b t
(**t u
)**u v
)**v w
.++ 
OrderByDescending++ 
(++ 
x++ 
=>++ 
x++ 
.++ 
Created++ %
)++% &
.,, 
ToListAsync,, 
(,, 
),, 
;,, 
public// 

async// 
Task// 
<// 
TEntity// 
?// 
>// 
GetByIdAsync//  ,
(//, -
Guid//- 1
id//2 4
,//4 5
params//6 <

Expression//= G
<//G H
Func//H L
<//L M
TEntity//M T
,//T U
object//V \
>//\ ]
>//] ^
[//^ _
]//_ `
includes//a i
)//i j
{00 
return11 
await11 
includes11 
.22 
	Aggregate22 
(22 
_dbSet22 
.22 
AsQueryable22 )
(22) *
)22* +
,22+ ,
(22- .
entity22. 4
,224 5
property226 >
)22> ?
=>22@ B
entity22C I
.22I J
Include22J Q
(22Q R
property22R Z
)22Z [
)22[ \
.33 
AsNoTracking33 
(33 
)33 
.44 
FirstOrDefaultAsync44  
(44  !
x44! "
=>44# %
x44& '
.44' (
Id44( *
.44* +
Equals44+ 1
(441 2
id442 4
)444 5
)445 6
;446 7
}55 
public77 

void77 
Remove77 
(77 
TEntity77 
entity77 %
)77% &
{88 
_dbSet99 
.99 
Remove99 
(99 
entity99 
)99 
;99 
}:: 
public<< 

async<< 
Task<< 
<<< 

Pagination<<  
<<<  !
TEntity<<! (
><<( )
><<) *
ToPagination<<+ 7
(<<7 8
int<<8 ;

pageNumber<<< F
=<<G H
$num<<I J
,<<J K
int<<L O
pageSize<<P X
=<<Y Z
$num<<[ ]
)<<] ^
{== 
var>> 
	itemCount>> 
=>> 
await>> 
_dbSet>> $
.>>$ %

CountAsync>>% /
(>>/ 0
)>>0 1
;>>1 2
var?? 
items?? 
=?? 
await?? 
_dbSet??  
.??  !
Skip??! %
(??% &

pageNumber??& 0
*??1 2
pageSize??3 ;
)??; <
.@@  !
Take@@! %
(@@% &
pageSize@@& .
)@@. /
.AA  !
AsNoTrackingAA! -
(AA- .
)AA. /
.BB  !
ToListAsyncBB! ,
(BB, -
)BB- .
;BB. /
varDD 
resultDD 
=DD 
newDD 

PaginationDD #
<DD# $
TEntityDD$ +
>DD+ ,
(DD, -
)DD- .
{EE 	
	PageIndexFF 
=FF 

pageNumberFF "
,FF" #
PageSizeGG 
=GG 
pageSizeGG 
,GG  
TotalItemsCountHH 
=HH 
	itemCountHH '
,HH' (
ItemsII 
=II 
itemsII 
,II 
}JJ 	
;JJ	 

returnLL 
resultLL 
;LL 
}MM 
publicOO 

voidOO 
UpdateOO 
(OO 
TEntityOO 
entityOO %
)OO% &
{PP 
entityQQ 
.QQ 
LastModifiedQQ 
=QQ 
CurrentTimeQQ )
.QQ) *

RecentTimeQQ* 4
;QQ4 5
_dbSetRR 
.RR 
UpdateRR 
(RR 
entityRR 
)RR 
;RR 
}SS 
publicUU 

voidUU 
UpdateRangeUU 
(UU 
ListUU  
<UU  !
TEntityUU! (
>UU( )
entitiesUU* 2
)UU2 3
{VV 
foreachWW 
(WW 
varWW 
entityWW 
inWW 
entitiesWW '
)WW' (
{XX 	
entityYY 
.YY 
LastModifiedYY 
=YY  !
CurrentTimeYY" -
.YY- .

RecentTimeYY. 8
;YY8 9
}ZZ 	
_dbSet[[ 
.[[ 
UpdateRange[[ 
([[ 
entities[[ #
)[[# $
;[[$ %
}\\ 
public^^ 

async^^ 
Task^^ 
<^^ 
List^^ 
<^^ 
TEntity^^ "
>^^" #
>^^# $

WhereAsync^^% /
(^^/ 0

Expression^^0 :
<^^: ;
Func^^; ?
<^^? @
TEntity^^@ G
,^^G H
bool^^I M
>^^M N
>^^N O

expression^^P Z
,^^Z [
params^^\ b

Expression^^c m
<^^m n
Func^^n r
<^^r s
TEntity^^s z
,^^z {
object	^^| В
>
^^В Г
>
^^Г Д
[
^^Д Е
]
^^Е Ж
includes
^^З П
)
^^П Р
=>__ 
await__ 
includes__ 
.`` 
	Aggregate`` 
(`` 
_dbSet`` 
!`` 
.`` 
AsQueryable`` $
(``$ %
)``% &
,``& '
(``( )
entity``) /
,``/ 0
property``1 9
)``9 :
=>``; =
entity``> D
.``D E
Include``E L
(``L M
property``M U
)``U V
)``V W
.``W X
AsNoTracking``X d
(``d e
)``e f
.aa 
Whereaa 
(aa 

expressionaa 
!aa 
)aa 
.bb 
OrderByDescendingbb 
(bb 
xbb 
=>bb 
xbb 
.bb  
Createdbb  '
)bb' (
.cc 
ToListAsynccc 
(cc 
)cc 
;cc 
}dd П
{C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\EmployeeRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class 
EmployeeRepository 
:  !
GenericRepository" 3
<3 4
Employee4 <
>< =
,= >
IEmployeeRepository? R
{ 
public 

EmployeeRepository 
( 

FOVContext (
context) 0
)0 1
:2 3
base4 8
(8 9
context9 @
)@ A
{		 
}

 
} П
{C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\CustomerRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class 
CustomerRepository 
:  !
GenericRepository" 3
<3 4
Customer4 <
>< =
,= >
ICustomerRepository? R
{ 
public 

CustomerRepository 
( 

FOVContext (
context) 0
)0 1
:2 3
base4 8
(8 9
context9 @
)@ A
{		 
}

 
} А
xC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\ComboRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class 
ComboRepository 
: 
GenericRepository 0
<0 1
Combo1 6
>6 7
,7 8
IComboRepository9 I
{ 
public 

ComboRepository 
( 

FOVContext %
context& -
)- .
:/ 0
base1 5
(5 6
context6 =
)= >
{		 
}

 
} └
{C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\CategoryRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class 
CategoryRepository 
:  !
GenericRepository" 3
<3 4
Category4 <
>< =
,= >
ICategoryRepository? R
{		 
private 
readonly 

FOVContext 
_context  (
;( )
public 

CategoryRepository 
( 

FOVContext (
context) 0
)0 1
:2 3
base4 8
(8 9
context9 @
)@ A
{ 
_context 
= 
context 
; 
} 
} ў
}C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\AttendanceRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
Repositories( 4
;4 5
public 
class  
AttendanceRepository !
:" #
GenericRepository$ 5
<5 6

Attendance6 @
>@ A
,A B!
IAttendanceRepositoryC X
{ 
private 
readonly 

FOVContext 
_context  (
;( )
public 
 
AttendanceRepository 
(  

FOVContext  *
context+ 2
)2 3
:4 5
base6 :
(: ;
context; B
)B C
{ 
_context 
= 
context 
; 
} 
public 

async 
Task 
< 

Attendance  
?  !
>! "-
!GetByEmployeeScheduleAndDateAsync# D
(D E
GuidE I

employeeIdJ T
,T U
GuidV Z
waiterScheduleId[ k
,k l
DateOnlym u
datev z
)z {
{ 
return 
await 
_context 
. 
Attendances )
. 
Where 
( 
a 
=> 
a 
. 

EmployeeId $
==% '

employeeId( 2
&& 
a 
. 
WaiterScheduleId *
==+ -
waiterScheduleId. >
&& 
a 
. 
CheckInTime %
.% &
Date& *
==+ -
date. 2
.2 3

ToDateTime3 =
(= >
TimeOnly> F
.F G
MinValueG O
)O P
.P Q
DateQ U
)U V
. 
FirstOrDefaultAsync  
(  !
)! "
;" #
} 
} К
ГC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IWaiterScheduleRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public		 
	interface		 %
IWaiterScheduleRepository		 *
:		+ ,
IGenericRepository		- ?
<		? @
WaiterSchedule		@ N
>		N O
{

 
} ╙
zC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\ITableRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public

 
	interface

 
ITableRepository

 !
:

" #
IGenericRepository

$ 6
<

6 7
Table

7 <
>

< =
{ 
public 

Task 
< 
int 
? 
> &
GetHighestTableNumberAsync 0
(0 1
Guid1 5
restaurantId6 B
)B C
;C D
} ю
zC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IShiftRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public		 
	interface		 
IShiftRepository		 !
:		" #
IGenericRepository		$ 6
<		6 7
Shift		7 <
>		< =
{

 
} ╕
C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IRestaurantRepository.cs
	namespace		 	
FOV		
 
.		 
Infrastructure		 
.		 

Repository		 '
.		' (
IRepositories		( 5
;		5 6
public 
	interface !
IRestaurantRepository &
:' (
IGenericRepository) ;
<; <

Restaurant< F
>F G
{ 
Task 
< 	
bool	 
> 
AnyAsync 
( 

Expression "
<" #
Func# '
<' (

Restaurant( 2
,2 3
bool4 8
>8 9
>9 :
	predicate; D
)D E
;E F
} ё
{C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IRatingRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface 
IRatingRepository "
:# $
IGenericRepository% 7
<7 8
Rating8 >
>> ?
{ 
} Ї
|C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IProductRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface 
IProductRepository #
:$ %
IGenericRepository& 8
<8 9
Product9 @
>@ A
{ 
} Ч
ЖC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IProductIngredientRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface (
IProductIngredientRepository -
:. /
IGenericRepository0 B
<B C
ProductIngredientC T
>T U
{V W
}X Yи
НC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IProductIngredientGeneralRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface /
#IProductIngredientGeneralRepository 4
:5 6
IGenericRepository7 I
<I J$
ProductIngredientGeneralJ b
>b c
{ 
} Д
БC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IProductImageRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface #
IProductImageRepository (
:) *
IGenericRepository+ =
<= >
ProductImage> J
>J K
{ 
} К
ГC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IProductGeneralRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface %
IProductGeneralRepository *
:+ ,
IGenericRepository- ?
<? @
ProductGeneral@ N
>N O
{ 
}		 Д
БC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IProductComboRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface #
IProductComboRepository (
:) *
IGenericRepository+ =
<= >
ProductCombo> J
>J K
{ 
} ╩
|C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IPaymentRepository.cs
	namespace		 	
FOV		
 
.		 
Infrastructure		 
.		 

Repository		 '
.		' (
IRepositories		( 5
;		5 6
public

 
	interface

 
IPaymentRepository

 #
:

$ %
IGenericRepository

& 8
<

8 9
Payments

9 A
>

A B
{ 
Task 
< 	
Payments	 
> "
GetFirstOrDefaultAsync )
() *
Func* .
<. /
Payments/ 7
,7 8
bool9 =
>= >
	predicate? H
)H I
;I J
Task 
< 	
Payments	 
> #
GetPaymentByTxnRefAsync *
(* +
string+ 1
txnRef2 8
)8 9
;9 :
} д
zC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IOrderRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public		 
	interface		 
IOrderRepository		 !
:		" #
IGenericRepository		$ 6
<		6 7
Order		7 <
>		< =
{

 
Task 
< 	
Order	 
> 
GetByTableIdAsync !
(! "
Guid" &
tableId' .
). /
;/ 0
} э
АC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IOrderDetailRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public		 
	interface		 "
IOrderDetailRepository		 '
:		( )
IGenericRepository		* <
<		< =
OrderDetail		= H
>		H I
{

 
Task 
< 	
List	 
< 
OrderDetail 
> 
> 
GetByOrderIdAsync -
(- .
Guid. 2
orderId3 :
): ;
;; <
} Щ
ИC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\INewProductRecommendRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface *
INewProductRecommendRepository /
:0 1
IGenericRepository2 D
<D E
NewProductRecommendE X
>X Y
{ 
} в
ЛC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\INewProductRecommendLogRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface -
!INewProductRecommendLogRepository 2
:3 4
IGenericRepository5 G
<G H"
NewProductRecommendLogH ^
>^ _
{ 
} К
ГC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IIngredientUnitRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface %
IIngredientUnitRepository *
:+ ,
IGenericRepository- ?
<? @
IngredientUnit@ N
>N O
{ 
} ╠
ГC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IIngredientTypeRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface %
IIngredientTypeRepository *
:+ ,
IGenericRepository- ?
<? @
IngredientType@ N
>N O
{ 
Task &
UpdateParentIngredientType	 #
(# $
Guid$ (
parentId) 1
,1 2
int3 6
right7 <
)< =
;= >
} ¤
C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IIngredientRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface !
IIngredientRepository &
:' (
IGenericRepository) ;
<; <

Ingredient< F
>F G
{ 
} У
ЖC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IIngredientGeneralRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface (
IIngredientGeneralRepository -
:. /
IGenericRepository0 B
<B C
IngredientGeneralC T
>T U
{ 
} Э
ЙC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IIngrdientTransactionRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface +
IIngrdientTransactionRepository 0
:1 2
IGenericRepository3 E
<E F!
IngredientTransactionF [
>[ \
{ 
} ·
~C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IGroupUserRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface  
IGroupUserRepository %
:& '
IGenericRepository( :
<: ;
	GroupUser; D
>D E
{ 
} Д
БC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IGroupMessageRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface #
IGroupMessageRepository (
:) *
IGenericRepository+ =
<= >
GroupMessage> J
>J K
{ 
} ·
~C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IGroupChatRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface  
IGroupChatRepository %
:& '
IGenericRepository( :
<: ;
	GroupChat; D
>D E
{ 
} ▒
|C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IGenericRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
{ 
public 

	interface 
IGenericRepository '
<' (
TEntity( /
>/ 0
where1 6
TEntity7 >
:? @
BaseAuditableEntityA T
{ 
Task		 
<		 
List		 
<		 
TEntity		 
>		 
>		 
GetAllAsync		 '
(		' (
params		( .

Expression		/ 9
<		9 :
Func		: >
<		> ?
TEntity		? F
,		F G
object		H N
>		N O
>		O P
[		P Q
]		Q R
includes		S [
)		[ \
;		\ ]
Task

 
<

 
TEntity

 
?

 
>

 
GetByIdAsync

 #
(

# $
Guid

$ (
id

) +
,

+ ,
params

- 3

Expression

4 >
<

> ?
Func

? C
<

C D
TEntity

D K
,

K L
object

M S
>

S T
>

T U
[

U V
]

V W
includes

X `
)

` a
;

a b
Task 
< 
List 
< 
TEntity 
> 
> 

WhereAsync &
(& '

Expression' 1
<1 2
Func2 6
<6 7
TEntity7 >
,> ?
bool@ D
>D E
>E F

expressionG Q
,Q R
paramsS Y

ExpressionZ d
<d e
Funce i
<i j
TEntityj q
,q r
objects y
>y z
>z {
[{ |
]| }
includes	~ Ж
)
Ж З
;
З И
Task 
< 
TEntity 
? 
> 
FirstOrDefaultAsync *
(* +

Expression+ 5
<5 6
Func6 :
<: ;
TEntity; B
,B C
boolD H
>H I
>I J

expressionK U
,U V
paramsW ]

Expression^ h
<h i
Funci m
<m n
TEntityn u
,u v
objectw }
>} ~
>~ 
[	 А
]
А Б
includes
В К
)
К Л
;
Л М
Task 
< 
TEntity 
> 
AddAsync 
( 
TEntity &
entity' -
)- .
;. /
void 
Update 
( 
TEntity 
entity "
)" #
;# $
void 
UpdateRange 
( 
List 
< 
TEntity %
>% &
entities' /
)/ 0
;0 1
Task 
AddRangeAsync 
( 
List 
<  
TEntity  '
>' (
entities) 1
)1 2
;2 3
Task 
< 

Pagination 
< 
TEntity 
>  
>  !
ToPagination" .
(. /
int/ 2

pageNumber3 =
=> ?
$num@ A
,A B
intC F
pageSizeG O
=P Q
$numR T
)T U
;U V
void 
Remove 
( 
TEntity 
entity "
)" #
;# $
} 
} ў
}C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IEmployeeRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface 
IEmployeeRepository $
:% &
IGenericRepository' 9
<9 :
Employee: B
>B C
{ 
} ў
}C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\ICustomerRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface 
ICustomerRepository $
:% &
IGenericRepository' 9
<9 :
Customer: B
>B C
{ 
} ю
zC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IComboRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface 
IComboRepository !
:" #
IGenericRepository$ 6
<6 7
Combo7 <
>< =
{ 
} ў
}C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\ICategoryRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public 
	interface 
ICategoryRepository $
:% &
IGenericRepository' 9
<9 :
Category: B
>B C
{ 
} ┴
C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IAttendanceRepository.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Repository '
.' (
IRepositories( 5
;5 6
public		 
	interface		 !
IAttendanceRepository		 &
:		' (
IGenericRepository		) ;
<		; <

Attendance		< F
>		F G
{

 
Task 
< 	

Attendance	 
> -
!GetByEmployeeScheduleAndDateAsync 6
(6 7
Guid7 ;

employeeId< F
,F G
GuidH L
waiterScheduleIdM ]
,] ^
DateOnly_ g
dateh l
)l m
;m n
} еж
yC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Migrations\20240924073936_EmployeeDomain.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 

Migrations '
{		 
public 

partial 
class 
EmployeeDomain '
:( )
	Migration* 3
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str ?
,? @
table 
: 
$str (
)( )
;) *
migrationBuilder 
. 

DeleteData '
(' (
table 
: 
$str $
,$ %
	keyColumn 
: 
$str 
,  
keyValue 
: 
$str @
)@ A
;A B
migrationBuilder 
. 

DeleteData '
(' (
table 
: 
$str $
,$ %
	keyColumn 
: 
$str 
,  
keyValue 
: 
$str @
)@ A
;A B
migrationBuilder 
. 

DeleteData '
(' (
table 
: 
$str $
,$ %
	keyColumn   
:   
$str   
,    
keyValue!! 
:!! 
$str!! @
)!!@ A
;!!A B
migrationBuilder## 
.## 
AlterColumn## (
<##( )
Guid##) -
>##- .
(##. /
name$$ 
:$$ 
$str$$ "
,$$" #
table%% 
:%% 
$str%% (
,%%( )
type&& 
:&& 
$str&& 
,&& 
nullable'' 
:'' 
false'' 
,''  
defaultValue(( 
:(( 
new(( !
Guid((" &
(((& '
$str((' M
)((M N
,((N O

oldClrType)) 
:)) 
typeof)) "
())" #
Guid))# '
)))' (
,))( )
oldType** 
:** 
$str** 
,**  
oldNullable++ 
:++ 
true++ !
)++! "
;++" #
migrationBuilder-- 
.-- 
	AddColumn-- &
<--& '
byte--' +
>--+ ,
(--, -
name.. 
:.. 
$str.. 
,.. 
table// 
:// 
$str// "
,//" #
type00 
:00 
$str00  
,00  !
nullable11 
:11 
false11 
,11  
defaultValue22 
:22 
(22 
byte22 #
)22# $
$num22$ %
)22% &
;22& '
migrationBuilder44 
.44 

UpdateData44 '
(44' (
table55 
:55 
$str55 
,55  
	keyColumn66 
:66 
$str66 
,66  
keyValue77 
:77 
new77 
Guid77 "
(77" #
$str77# I
)77I J
,77J K
column88 
:88 
$str88 %
,88% &
value99 
:99 
new99 
DateTime99 #
(99# $
$num99$ (
,99( )
$num99* ,
,99, -
$num99. 0
,990 1
$num992 3
,993 4
$num995 7
,997 8
$num999 ;
,99; <
$num99= @
,99@ A
DateTimeKind99B N
.99N O
Utc99O R
)99R S
.99S T
AddTicks99T \
(99\ ]
$num99] a
)99a b
)99b c
;99c d
migrationBuilder;; 
.;; 

UpdateData;; '
(;;' (
table<< 
:<< 
$str<< 
,<<  
	keyColumn== 
:== 
$str== 
,==  
keyValue>> 
:>> 
new>> 
Guid>> "
(>>" #
$str>># I
)>>I J
,>>J K
column?? 
:?? 
$str?? %
,??% &
value@@ 
:@@ 
new@@ 
DateTime@@ #
(@@# $
$num@@$ (
,@@( )
$num@@* ,
,@@, -
$num@@. 0
,@@0 1
$num@@2 3
,@@3 4
$num@@5 7
,@@7 8
$num@@9 ;
,@@; <
$num@@= @
,@@@ A
DateTimeKind@@B N
.@@N O
Utc@@O R
)@@R S
.@@S T
AddTicks@@T \
(@@\ ]
$num@@] a
)@@a b
)@@b c
;@@c d
migrationBuilderBB 
.BB 

UpdateDataBB '
(BB' (
tableCC 
:CC 
$strCC 
,CC  
	keyColumnDD 
:DD 
$strDD 
,DD  
keyValueEE 
:EE 
newEE 
GuidEE "
(EE" #
$strEE# I
)EEI J
,EEJ K
columnFF 
:FF 
$strFF %
,FF% &
valueGG 
:GG 
newGG 
DateTimeGG #
(GG# $
$numGG$ (
,GG( )
$numGG* ,
,GG, -
$numGG. 0
,GG0 1
$numGG2 3
,GG3 4
$numGG5 7
,GG7 8
$numGG9 ;
,GG; <
$numGG= @
,GG@ A
DateTimeKindGGB N
.GGN O
UtcGGO R
)GGR S
.GGS T
AddTicksGGT \
(GG\ ]
$numGG] a
)GGa b
)GGb c
;GGc d
migrationBuilderII 
.II 

UpdateDataII '
(II' (
tableJJ 
:JJ 
$strJJ "
,JJ" #
	keyColumnKK 
:KK 
$strKK 
,KK  
keyValueLL 
:LL 
newLL 
GuidLL "
(LL" #
$strLL# I
)LLI J
,LLJ K
columnsMM 
:MM 
newMM 
[MM 
]MM 
{MM  
$strMM! +
,MM+ ,
$strMM- 5
}MM6 7
,MM7 8
valuesNN 
:NN 
newNN 
objectNN "
[NN" #
]NN# $
{NN% &
newNN' *
DateTimeNN+ 3
(NN3 4
$numNN4 8
,NN8 9
$numNN: ;
,NN; <
$numNN= ?
,NN? @
$numNNA B
,NNB C
$numNND F
,NNF G
$numNNH J
,NNJ K
$numNNL O
,NNO P
DateTimeKindNNQ ]
.NN] ^
UtcNN^ a
)NNa b
.NNb c
AddTicksNNc k
(NNk l
$numNNl p
)NNp q
,NNq r
(NNs t
byteNNt x
)NNx y
$numNNy z
}NN{ |
)NN| }
;NN} ~
migrationBuilderPP 
.PP 

UpdateDataPP '
(PP' (
tableQQ 
:QQ 
$strQQ "
,QQ" #
	keyColumnRR 
:RR 
$strRR 
,RR  
keyValueSS 
:SS 
newSS 
GuidSS "
(SS" #
$strSS# I
)SSI J
,SSJ K
columnsTT 
:TT 
newTT 
[TT 
]TT 
{TT  
$strTT! +
,TT+ ,
$strTT- 5
}TT6 7
,TT7 8
valuesUU 
:UU 
newUU 
objectUU "
[UU" #
]UU# $
{UU% &
newUU' *
DateTimeUU+ 3
(UU3 4
$numUU4 8
,UU8 9
$numUU: ;
,UU; <
$numUU= ?
,UU? @
$numUUA B
,UUB C
$numUUD F
,UUF G
$numUUH J
,UUJ K
$numUUL O
,UUO P
DateTimeKindUUQ ]
.UU] ^
UtcUU^ a
)UUa b
.UUb c
AddTicksUUc k
(UUk l
$numUUl p
)UUp q
,UUq r
(UUs t
byteUUt x
)UUx y
$numUUy z
}UU{ |
)UU| }
;UU} ~
migrationBuilderWW 
.WW 

UpdateDataWW '
(WW' (
tableXX 
:XX 
$strXX "
,XX" #
	keyColumnYY 
:YY 
$strYY 
,YY  
keyValueZZ 
:ZZ 
newZZ 
GuidZZ "
(ZZ" #
$strZZ# I
)ZZI J
,ZZJ K
columns[[ 
:[[ 
new[[ 
[[[ 
][[ 
{[[  
$str[[! +
,[[+ ,
$str[[- 5
}[[6 7
,[[7 8
values\\ 
:\\ 
new\\ 
object\\ "
[\\" #
]\\# $
{\\% &
new\\' *
DateTime\\+ 3
(\\3 4
$num\\4 8
,\\8 9
$num\\: ;
,\\; <
$num\\= ?
,\\? @
$num\\A B
,\\B C
$num\\D F
,\\F G
$num\\H J
,\\J K
$num\\L O
,\\O P
DateTimeKind\\Q ]
.\\] ^
Utc\\^ a
)\\a b
.\\b c
AddTicks\\c k
(\\k l
$num\\l p
)\\p q
,\\q r
(\\s t
byte\\t x
)\\x y
$num\\y z
}\\{ |
)\\| }
;\\} ~
migrationBuilder^^ 
.^^ 
AddForeignKey^^ *
(^^* +
name__ 
:__ 
$str__ ?
,__? @
table`` 
:`` 
$str`` (
,``( )
columnaa 
:aa 
$straa $
,aa$ %
principalTablebb 
:bb 
$strbb  +
,bb+ ,
principalColumncc 
:cc  
$strcc! %
,cc% &
onDeletedd 
:dd 
ReferentialActiondd +
.dd+ ,
Cascadedd, 3
)dd3 4
;dd4 5
}ee 	
	protectedhh 
overridehh 
voidhh 
Downhh  $
(hh$ %
MigrationBuilderhh% 5
migrationBuilderhh6 F
)hhF G
{ii 	
migrationBuilderjj 
.jj 
DropForeignKeyjj +
(jj+ ,
namekk 
:kk 
$strkk ?
,kk? @
tablell 
:ll 
$strll (
)ll( )
;ll) *
migrationBuildernn 
.nn 

DropColumnnn '
(nn' (
nameoo 
:oo 
$stroo 
,oo 
tablepp 
:pp 
$strpp "
)pp" #
;pp# $
migrationBuilderrr 
.rr 
AlterColumnrr (
<rr( )
Guidrr) -
>rr- .
(rr. /
namess 
:ss 
$strss "
,ss" #
tablett 
:tt 
$strtt (
,tt( )
typeuu 
:uu 
$struu 
,uu 
nullablevv 
:vv 
truevv 
,vv 

oldClrTypeww 
:ww 
typeofww "
(ww" #
Guidww# '
)ww' (
,ww( )
oldTypexx 
:xx 
$strxx 
)xx  
;xx  !
migrationBuilderzz 
.zz 

InsertDatazz '
(zz' (
table{{ 
:{{ 
$str{{ $
,{{$ %
columns|| 
:|| 
new|| 
[|| 
]|| 
{||  
$str||! %
,||% &
$str||' :
,||: ;
$str||< N
,||N O
$str||P W
,||W X
$str||Y i
,||i j
$str||k v
,||v w
$str	||x В
,
||В Г
$str
||Д Ф
,
||Ф Х
$str
||Ц в
,
||в г
$str
||д ╡
,
||╡ ╢
$str
||╖ ╦
,
||╦ ╠
$str
||═ █
,
||█ ▄
$str
||▌ ъ
,
||ъ ы
$str
||ь В
,
||В Г
$str
||Д У
,
||У Ф
$str
||Х з
,
||з и
$str
||й │
}
||┤ ╡
,
||╡ ╢
values}} 
:}} 
new}} 
object}} "
[}}" #
,}}# $
]}}$ %
{~~ 
{ 
$str <
,< =
$num> ?
,? @
$strA O
,O P
$strQ e
,e f
trueg k
,k l
$strm t
,t u
$strv 
,	 А
true
Б Е
,
Е Ж
null
З Л
,
Л М
$str
Н б
,
б в
$str
г л
,
л м
$str
н В
,
В Г
$str
Д Р
,
Р С
true
Т Ц
,
Ц Ч
$str
Ш д
,
д е
false
ж л
,
л м
$str
н ╡
}
╢ ╖
,
╖ ╕
{
АА 
$str
АА <
,
АА< =
$num
АА> ?
,
АА? @
$str
ААA O
,
ААO P
$str
ААQ f
,
ААf g
true
ААh l
,
ААl m
$str
ААn v
,
ААv w
$str
ААx }
,
АА} ~
trueАА Г
,ААГ Д
nullААЕ Й
,ААЙ К
$strААЛ а
,ААа б
$strААв н
,ААн о
$strААп Е
,ААЕ Ж
$strААЗ У
,ААУ Ф
trueААХ Щ
,ААЩ Ъ
$strААЫ з
,ААз и
falseААй о
,ААо п
$strАА░ ╗
}АА╝ ╜
,АА╜ ╛
{
ББ 
$str
ББ <
,
ББ< =
$num
ББ> ?
,
ББ? @
$str
ББA O
,
ББO P
$str
ББQ e
,
ББe f
true
ББg k
,
ББk l
$str
ББm t
,
ББt u
$str
ББv {
,
ББ{ |
trueББ} Б
,БББ В
nullББГ З
,ББЗ И
$strББЙ Э
,ББЭ Ю
$strББЯ й
,ББй к
$strББл А
,ББА Б
$strББВ О
,ББО П
trueББР Ф
,ББФ Х
$strББЦ в
,ББв г
falseББд й
,ББй к
$strББл ╡
}ББ╢ ╖
}
ВВ 
)
ВВ 
;
ВВ 
migrationBuilder
ДД 
.
ДД 

UpdateData
ДД '
(
ДД' (
table
ЕЕ 
:
ЕЕ 
$str
ЕЕ 
,
ЕЕ  
	keyColumn
ЖЖ 
:
ЖЖ 
$str
ЖЖ 
,
ЖЖ  
keyValue
ЗЗ 
:
ЗЗ 
new
ЗЗ 
Guid
ЗЗ "
(
ЗЗ" #
$str
ЗЗ# I
)
ЗЗI J
,
ЗЗJ K
column
ИИ 
:
ИИ 
$str
ИИ %
,
ИИ% &
value
ЙЙ 
:
ЙЙ 
new
ЙЙ 
DateTime
ЙЙ #
(
ЙЙ# $
$num
ЙЙ$ (
,
ЙЙ( )
$num
ЙЙ* ,
,
ЙЙ, -
$num
ЙЙ. 0
,
ЙЙ0 1
$num
ЙЙ2 3
,
ЙЙ3 4
$num
ЙЙ5 7
,
ЙЙ7 8
$num
ЙЙ9 :
,
ЙЙ: ;
$num
ЙЙ< ?
,
ЙЙ? @
DateTimeKind
ЙЙA M
.
ЙЙM N
Utc
ЙЙN Q
)
ЙЙQ R
.
ЙЙR S
AddTicks
ЙЙS [
(
ЙЙ[ \
$num
ЙЙ\ `
)
ЙЙ` a
)
ЙЙa b
;
ЙЙb c
migrationBuilder
ЛЛ 
.
ЛЛ 

UpdateData
ЛЛ '
(
ЛЛ' (
table
ММ 
:
ММ 
$str
ММ 
,
ММ  
	keyColumn
НН 
:
НН 
$str
НН 
,
НН  
keyValue
ОО 
:
ОО 
new
ОО 
Guid
ОО "
(
ОО" #
$str
ОО# I
)
ООI J
,
ООJ K
column
ПП 
:
ПП 
$str
ПП %
,
ПП% &
value
РР 
:
РР 
new
РР 
DateTime
РР #
(
РР# $
$num
РР$ (
,
РР( )
$num
РР* ,
,
РР, -
$num
РР. 0
,
РР0 1
$num
РР2 3
,
РР3 4
$num
РР5 7
,
РР7 8
$num
РР9 :
,
РР: ;
$num
РР< ?
,
РР? @
DateTimeKind
РРA M
.
РРM N
Utc
РРN Q
)
РРQ R
.
РРR S
AddTicks
РРS [
(
РР[ \
$num
РР\ `
)
РР` a
)
РРa b
;
РРb c
migrationBuilder
ТТ 
.
ТТ 

UpdateData
ТТ '
(
ТТ' (
table
УУ 
:
УУ 
$str
УУ 
,
УУ  
	keyColumn
ФФ 
:
ФФ 
$str
ФФ 
,
ФФ  
keyValue
ХХ 
:
ХХ 
new
ХХ 
Guid
ХХ "
(
ХХ" #
$str
ХХ# I
)
ХХI J
,
ХХJ K
column
ЦЦ 
:
ЦЦ 
$str
ЦЦ %
,
ЦЦ% &
value
ЧЧ 
:
ЧЧ 
new
ЧЧ 
DateTime
ЧЧ #
(
ЧЧ# $
$num
ЧЧ$ (
,
ЧЧ( )
$num
ЧЧ* ,
,
ЧЧ, -
$num
ЧЧ. 0
,
ЧЧ0 1
$num
ЧЧ2 3
,
ЧЧ3 4
$num
ЧЧ5 7
,
ЧЧ7 8
$num
ЧЧ9 :
,
ЧЧ: ;
$num
ЧЧ< ?
,
ЧЧ? @
DateTimeKind
ЧЧA M
.
ЧЧM N
Utc
ЧЧN Q
)
ЧЧQ R
.
ЧЧR S
AddTicks
ЧЧS [
(
ЧЧ[ \
$num
ЧЧ\ `
)
ЧЧ` a
)
ЧЧa b
;
ЧЧb c
migrationBuilder
ЩЩ 
.
ЩЩ 

UpdateData
ЩЩ '
(
ЩЩ' (
table
ЪЪ 
:
ЪЪ 
$str
ЪЪ "
,
ЪЪ" #
	keyColumn
ЫЫ 
:
ЫЫ 
$str
ЫЫ 
,
ЫЫ  
keyValue
ЬЬ 
:
ЬЬ 
new
ЬЬ 
Guid
ЬЬ "
(
ЬЬ" #
$str
ЬЬ# I
)
ЬЬI J
,
ЬЬJ K
column
ЭЭ 
:
ЭЭ 
$str
ЭЭ "
,
ЭЭ" #
value
ЮЮ 
:
ЮЮ 
new
ЮЮ 
DateTime
ЮЮ #
(
ЮЮ# $
$num
ЮЮ$ (
,
ЮЮ( )
$num
ЮЮ* +
,
ЮЮ+ ,
$num
ЮЮ- /
,
ЮЮ/ 0
$num
ЮЮ1 2
,
ЮЮ2 3
$num
ЮЮ4 6
,
ЮЮ6 7
$num
ЮЮ8 9
,
ЮЮ9 :
$num
ЮЮ; >
,
ЮЮ> ?
DateTimeKind
ЮЮ@ L
.
ЮЮL M
Utc
ЮЮM P
)
ЮЮP Q
.
ЮЮQ R
AddTicks
ЮЮR Z
(
ЮЮZ [
$num
ЮЮ[ _
)
ЮЮ_ `
)
ЮЮ` a
;
ЮЮa b
migrationBuilder
аа 
.
аа 

UpdateData
аа '
(
аа' (
table
бб 
:
бб 
$str
бб "
,
бб" #
	keyColumn
вв 
:
вв 
$str
вв 
,
вв  
keyValue
гг 
:
гг 
new
гг 
Guid
гг "
(
гг" #
$str
гг# I
)
ггI J
,
ггJ K
column
дд 
:
дд 
$str
дд "
,
дд" #
value
ее 
:
ее 
new
ее 
DateTime
ее #
(
ее# $
$num
ее$ (
,
ее( )
$num
ее* +
,
ее+ ,
$num
ее- /
,
ее/ 0
$num
ее1 2
,
ее2 3
$num
ее4 6
,
ее6 7
$num
ее8 9
,
ее9 :
$num
ее; >
,
ее> ?
DateTimeKind
ее@ L
.
ееL M
Utc
ееM P
)
ееP Q
.
ееQ R
AddTicks
ееR Z
(
ееZ [
$num
ее[ _
)
ее_ `
)
ее` a
;
ееa b
migrationBuilder
зз 
.
зз 

UpdateData
зз '
(
зз' (
table
ии 
:
ии 
$str
ии "
,
ии" #
	keyColumn
йй 
:
йй 
$str
йй 
,
йй  
keyValue
кк 
:
кк 
new
кк 
Guid
кк "
(
кк" #
$str
кк# I
)
ккI J
,
ккJ K
column
лл 
:
лл 
$str
лл "
,
лл" #
value
мм 
:
мм 
new
мм 
DateTime
мм #
(
мм# $
$num
мм$ (
,
мм( )
$num
мм* +
,
мм+ ,
$num
мм- /
,
мм/ 0
$num
мм1 2
,
мм2 3
$num
мм4 6
,
мм6 7
$num
мм8 9
,
мм9 :
$num
мм; >
,
мм> ?
DateTimeKind
мм@ L
.
ммL M
Utc
ммM P
)
ммP Q
.
ммQ R
AddTicks
ммR Z
(
ммZ [
$num
мм[ _
)
мм_ `
)
мм` a
;
ммa b
migrationBuilder
оо 
.
оо 
AddForeignKey
оо *
(
оо* +
name
пп 
:
пп 
$str
пп ?
,
пп? @
table
░░ 
:
░░ 
$str
░░ (
,
░░( )
column
▒▒ 
:
▒▒ 
$str
▒▒ $
,
▒▒$ %
principalTable
▓▓ 
:
▓▓ 
$str
▓▓  +
,
▓▓+ ,
principalColumn
││ 
:
││  
$str
││! %
)
││% &
;
││& '
}
┤┤ 	
}
╡╡ 
}╢╢ √Ь
qC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Migrations\20240920085405_Domain.cs
	namespace		 	
FOV		
 
.		 
Infrastructure		 
.		 

Migrations		 '
{

 
public 

partial 
class 
Domain 
:  !
	Migration" +
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str #
,# $
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
string& ,
>, -
(- .
type. 2
:2 3
$str4 :
,: ;
nullable< D
:D E
falseF K
)K L
,L M
Name 
= 
table  
.  !
Column! '
<' (
string( .
>. /
(/ 0
type0 4
:4 5
$str6 N
,N O
	maxLengthP Y
:Y Z
$num[ ^
,^ _
nullable` h
:h i
truej n
)n o
,o p
NormalizedName "
=# $
table% *
.* +
Column+ 1
<1 2
string2 8
>8 9
(9 :
type: >
:> ?
$str@ X
,X Y
	maxLengthZ c
:c d
$nume h
,h i
nullablej r
:r s
truet x
)x y
,y z
ConcurrencyStamp $
=% &
table' ,
., -
Column- 3
<3 4
string4 :
>: ;
(; <
type< @
:@ A
$strB H
,H I
nullableJ R
:R S
trueT X
)X Y
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 5
,5 6
x7 8
=>9 ;
x< =
.= >
Id> @
)@ A
;A B
} 
) 
; 
migrationBuilder 
. 
CreateTable (
(( )
name   
:   
$str   #
,  # $
columns!! 
:!! 
table!! 
=>!! !
new!!" %
{"" 
Id## 
=## 
table## 
.## 
Column## %
<##% &
string##& ,
>##, -
(##- .
type##. 2
:##2 3
$str##4 :
,##: ;
nullable##< D
:##D E
false##F K
)##K L
,##L M
	FirstName$$ 
=$$ 
table$$  %
.$$% &
Column$$& ,
<$$, -
string$$- 3
>$$3 4
($$4 5
type$$5 9
:$$9 :
$str$$; A
,$$A B
nullable$$C K
:$$K L
false$$M R
)$$R S
,$$S T
LastName%% 
=%% 
table%% $
.%%$ %
Column%%% +
<%%+ ,
string%%, 2
>%%2 3
(%%3 4
type%%4 8
:%%8 9
$str%%: @
,%%@ A
nullable%%B J
:%%J K
false%%L Q
)%%Q R
,%%R S
UserName&& 
=&& 
table&& $
.&&$ %
Column&&% +
<&&+ ,
string&&, 2
>&&2 3
(&&3 4
type&&4 8
:&&8 9
$str&&: R
,&&R S
	maxLength&&T ]
:&&] ^
$num&&_ b
,&&b c
nullable&&d l
:&&l m
true&&n r
)&&r s
,&&s t
NormalizedUserName'' &
=''' (
table'') .
.''. /
Column''/ 5
<''5 6
string''6 <
>''< =
(''= >
type''> B
:''B C
$str''D \
,''\ ]
	maxLength''^ g
:''g h
$num''i l
,''l m
nullable''n v
:''v w
true''x |
)''| }
,''} ~
Email(( 
=(( 
table(( !
.((! "
Column((" (
<((( )
string(() /
>((/ 0
(((0 1
type((1 5
:((5 6
$str((7 O
,((O P
	maxLength((Q Z
:((Z [
$num((\ _
,((_ `
nullable((a i
:((i j
true((k o
)((o p
,((p q
NormalizedEmail)) #
=))$ %
table))& +
.))+ ,
Column)), 2
<))2 3
string))3 9
>))9 :
()): ;
type)); ?
:))? @
$str))A Y
,))Y Z
	maxLength))[ d
:))d e
$num))f i
,))i j
nullable))k s
:))s t
true))u y
)))y z
,))z {
EmailConfirmed** "
=**# $
table**% *
.*** +
Column**+ 1
<**1 2
bool**2 6
>**6 7
(**7 8
type**8 <
:**< =
$str**> G
,**G H
nullable**I Q
:**Q R
false**S X
)**X Y
,**Y Z
PasswordHash++  
=++! "
table++# (
.++( )
Column++) /
<++/ 0
string++0 6
>++6 7
(++7 8
type++8 <
:++< =
$str++> D
,++D E
nullable++F N
:++N O
true++P T
)++T U
,++U V
SecurityStamp,, !
=,," #
table,,$ )
.,,) *
Column,,* 0
<,,0 1
string,,1 7
>,,7 8
(,,8 9
type,,9 =
:,,= >
$str,,? E
,,,E F
nullable,,G O
:,,O P
true,,Q U
),,U V
,,,V W
ConcurrencyStamp-- $
=--% &
table--' ,
.--, -
Column--- 3
<--3 4
string--4 :
>--: ;
(--; <
type--< @
:--@ A
$str--B H
,--H I
nullable--J R
:--R S
true--T X
)--X Y
,--Y Z
PhoneNumber.. 
=..  !
table.." '
...' (
Column..( .
<... /
string../ 5
>..5 6
(..6 7
type..7 ;
:..; <
$str..= C
,..C D
nullable..E M
:..M N
true..O S
)..S T
,..T U 
PhoneNumberConfirmed// (
=//) *
table//+ 0
.//0 1
Column//1 7
<//7 8
bool//8 <
>//< =
(//= >
type//> B
://B C
$str//D M
,//M N
nullable//O W
://W X
false//Y ^
)//^ _
,//_ `
TwoFactorEnabled00 $
=00% &
table00' ,
.00, -
Column00- 3
<003 4
bool004 8
>008 9
(009 :
type00: >
:00> ?
$str00@ I
,00I J
nullable00K S
:00S T
false00U Z
)00Z [
,00[ \

LockoutEnd11 
=11  
table11! &
.11& '
Column11' -
<11- .
DateTimeOffset11. <
>11< =
(11= >
type11> B
:11B C
$str11D ^
,11^ _
nullable11` h
:11h i
true11j n
)11n o
,11o p
LockoutEnabled22 "
=22# $
table22% *
.22* +
Column22+ 1
<221 2
bool222 6
>226 7
(227 8
type228 <
:22< =
$str22> G
,22G H
nullable22I Q
:22Q R
false22S X
)22X Y
,22Y Z
AccessFailedCount33 %
=33& '
table33( -
.33- .
Column33. 4
<334 5
int335 8
>338 9
(339 :
type33: >
:33> ?
$str33@ I
,33I J
nullable33K S
:33S T
false33U Z
)33Z [
}44 
,44 
constraints55 
:55 
table55 "
=>55# %
{66 
table77 
.77 

PrimaryKey77 $
(77$ %
$str77% 5
,775 6
x777 8
=>779 ;
x77< =
.77= >
Id77> @
)77@ A
;77A B
}88 
)88 
;88 
migrationBuilder:: 
.:: 
CreateTable:: (
(::( )
name;; 
:;; 
$str;; "
,;;" #
columns<< 
:<< 
table<< 
=><< !
new<<" %
{== 
Id>> 
=>> 
table>> 
.>> 
Column>> %
<>>% &
Guid>>& *
>>>* +
(>>+ ,
type>>, 0
:>>0 1
$str>>2 8
,>>8 9
nullable>>: B
:>>B C
false>>D I
)>>I J
,>>J K
CategoryName??  
=??! "
table??# (
.??( )
Column??) /
<??/ 0
string??0 6
>??6 7
(??7 8
type??8 <
:??< =
$str??> D
,??D E
nullable??F N
:??N O
false??P U
)??U V
,??V W
	IsDeleted@@ 
=@@ 
table@@  %
.@@% &
Column@@& ,
<@@, -
bool@@- 1
>@@1 2
(@@2 3
type@@3 7
:@@7 8
$str@@9 B
,@@B C
nullable@@D L
:@@L M
false@@N S
)@@S T
,@@T U
CreatedAA 
=AA 
tableAA #
.AA# $
ColumnAA$ *
<AA* +
DateTimeOffsetAA+ 9
>AA9 :
(AA: ;
typeAA; ?
:AA? @
$strAAA [
,AA[ \
nullableAA] e
:AAe f
falseAAg l
)AAl m
,AAm n
	CreatedByBB 
=BB 
tableBB  %
.BB% &
ColumnBB& ,
<BB, -
stringBB- 3
>BB3 4
(BB4 5
typeBB5 9
:BB9 :
$strBB; A
,BBA B
nullableBBC K
:BBK L
trueBBM Q
)BBQ R
,BBR S
LastModifiedCC  
=CC! "
tableCC# (
.CC( )
ColumnCC) /
<CC/ 0
DateTimeOffsetCC0 >
>CC> ?
(CC? @
typeCC@ D
:CCD E
$strCCF `
,CC` a
nullableCCb j
:CCj k
falseCCl q
)CCq r
,CCr s
LastModifiedByDD "
=DD# $
tableDD% *
.DD* +
ColumnDD+ 1
<DD1 2
stringDD2 8
>DD8 9
(DD9 :
typeDD: >
:DD> ?
$strDD@ F
,DDF G
nullableDDH P
:DDP Q
trueDDR V
)DDV W
}EE 
,EE 
constraintsFF 
:FF 
tableFF "
=>FF# %
{GG 
tableHH 
.HH 

PrimaryKeyHH $
(HH$ %
$strHH% 4
,HH4 5
xHH6 7
=>HH8 :
xHH; <
.HH< =
IdHH= ?
)HH? @
;HH@ A
}II 
)II 
;II 
migrationBuilderKK 
.KK 
CreateTableKK (
(KK( )
nameLL 
:LL 
$strLL '
,LL' (
columnsMM 
:MM 
tableMM 
=>MM !
newMM" %
{NN 
IdOO 
=OO 
tableOO 
.OO 
ColumnOO %
<OO% &
GuidOO& *
>OO* +
(OO+ ,
typeOO, 0
:OO0 1
$strOO2 8
,OO8 9
nullableOO: B
:OOB C
falseOOD I
)OOI J
,OOJ K
IngredientNamePP "
=PP# $
tablePP% *
.PP* +
ColumnPP+ 1
<PP1 2
stringPP2 8
>PP8 9
(PP9 :
typePP: >
:PP> ?
$strPP@ F
,PPF G
nullablePPH P
:PPP Q
falsePPR W
)PPW X
,PPX Y!
IngredientDescriptionQQ )
=QQ* +
tableQQ, 1
.QQ1 2
ColumnQQ2 8
<QQ8 9
stringQQ9 ?
>QQ? @
(QQ@ A
typeQQA E
:QQE F
$strQQG M
,QQM N
nullableQQO W
:QQW X
falseQQY ^
)QQ^ _
,QQ_ `
IngredientMainRR "
=RR# $
tableRR% *
.RR* +
ColumnRR+ 1
<RR1 2
stringRR2 8
>RR8 9
(RR9 :
typeRR: >
:RR> ?
$strRR@ F
,RRF G
nullableRRH P
:RRP Q
falseRRR W
)RRW X
,RRX Y
ParentIdSS 
=SS 
tableSS $
.SS$ %
ColumnSS% +
<SS+ ,
GuidSS, 0
>SS0 1
(SS1 2
typeSS2 6
:SS6 7
$strSS8 >
,SS> ?
nullableSS@ H
:SSH I
trueSSJ N
)SSN O
,SSO P
LeftTT 
=TT 
tableTT  
.TT  !
ColumnTT! '
<TT' (
intTT( +
>TT+ ,
(TT, -
typeTT- 1
:TT1 2
$strTT3 <
,TT< =
nullableTT> F
:TTF G
falseTTH M
)TTM N
,TTN O
RightUU 
=UU 
tableUU !
.UU! "
ColumnUU" (
<UU( )
intUU) ,
>UU, -
(UU- .
typeUU. 2
:UU2 3
$strUU4 =
,UU= >
nullableUU? G
:UUG H
falseUUI N
)UUN O
,UUO P
ExpiredTimeVV 
=VV  !
tableVV" '
.VV' (
ColumnVV( .
<VV. /
intVV/ 2
>VV2 3
(VV3 4
typeVV4 8
:VV8 9
$strVV: C
,VVC D
nullableVVE M
:VVM N
falseVVO T
)VVT U
,VVU V
	IsDeletedWW 
=WW 
tableWW  %
.WW% &
ColumnWW& ,
<WW, -
boolWW- 1
>WW1 2
(WW2 3
typeWW3 7
:WW7 8
$strWW9 B
,WWB C
nullableWWD L
:WWL M
falseWWN S
)WWS T
,WWT U
CreatedXX 
=XX 
tableXX #
.XX# $
ColumnXX$ *
<XX* +
DateTimeOffsetXX+ 9
>XX9 :
(XX: ;
typeXX; ?
:XX? @
$strXXA [
,XX[ \
nullableXX] e
:XXe f
falseXXg l
)XXl m
,XXm n
	CreatedByYY 
=YY 
tableYY  %
.YY% &
ColumnYY& ,
<YY, -
stringYY- 3
>YY3 4
(YY4 5
typeYY5 9
:YY9 :
$strYY; A
,YYA B
nullableYYC K
:YYK L
trueYYM Q
)YYQ R
,YYR S
LastModifiedZZ  
=ZZ! "
tableZZ# (
.ZZ( )
ColumnZZ) /
<ZZ/ 0
DateTimeOffsetZZ0 >
>ZZ> ?
(ZZ? @
typeZZ@ D
:ZZD E
$strZZF `
,ZZ` a
nullableZZb j
:ZZj k
falseZZl q
)ZZq r
,ZZr s
LastModifiedBy[[ "
=[[# $
table[[% *
.[[* +
Column[[+ 1
<[[1 2
string[[2 8
>[[8 9
([[9 :
type[[: >
:[[> ?
$str[[@ F
,[[F G
nullable[[H P
:[[P Q
true[[R V
)[[V W
}\\ 
,\\ 
constraints]] 
:]] 
table]] "
=>]]# %
{^^ 
table__ 
.__ 

PrimaryKey__ $
(__$ %
$str__% 9
,__9 :
x__; <
=>__= ?
x__@ A
.__A B
Id__B D
)__D E
;__E F
}`` 
)`` 
;`` 
migrationBuilderbb 
.bb 
CreateTablebb (
(bb( )
namecc 
:cc 
$strcc #
,cc# $
columnsdd 
:dd 
tabledd 
=>dd !
newdd" %
{ee 
Idff 
=ff 
tableff 
.ff 
Columnff %
<ff% &
Guidff& *
>ff* +
(ff+ ,
typeff, 0
:ff0 1
$strff2 8
,ff8 9
nullableff: B
:ffB C
falseffD I
)ffI J
,ffJ K
RestaurantNamegg "
=gg# $
tablegg% *
.gg* +
Columngg+ 1
<gg1 2
stringgg2 8
>gg8 9
(gg9 :
typegg: >
:gg> ?
$strgg@ F
,ggF G
nullableggH P
:ggP Q
falseggR W
)ggW X
,ggX Y
Addresshh 
=hh 
tablehh #
.hh# $
Columnhh$ *
<hh* +
stringhh+ 1
>hh1 2
(hh2 3
typehh3 7
:hh7 8
$strhh9 ?
,hh? @
nullablehhA I
:hhI J
falsehhK P
)hhP Q
,hhQ R
Statusii 
=ii 
tableii "
.ii" #
Columnii# )
<ii) *
byteii* .
>ii. /
(ii/ 0
typeii0 4
:ii4 5
$strii6 @
,ii@ A
nullableiiB J
:iiJ K
falseiiL Q
)iiQ R
,iiR S
RestaurantPhonejj #
=jj$ %
tablejj& +
.jj+ ,
Columnjj, 2
<jj2 3
stringjj3 9
>jj9 :
(jj: ;
typejj; ?
:jj? @
$strjjA G
,jjG H
nullablejjI Q
:jjQ R
falsejjS X
)jjX Y
,jjY Z
RestataurantCodekk $
=kk% &
tablekk' ,
.kk, -
Columnkk- 3
<kk3 4
stringkk4 :
>kk: ;
(kk; <
typekk< @
:kk@ A
$strkkB H
,kkH I
nullablekkJ R
:kkR S
falsekkT Y
)kkY Z
,kkZ [
	IsDeletedll 
=ll 
tablell  %
.ll% &
Columnll& ,
<ll, -
boolll- 1
>ll1 2
(ll2 3
typell3 7
:ll7 8
$strll9 B
,llB C
nullablellD L
:llL M
falsellN S
)llS T
,llT U
Createdmm 
=mm 
tablemm #
.mm# $
Columnmm$ *
<mm* +
DateTimeOffsetmm+ 9
>mm9 :
(mm: ;
typemm; ?
:mm? @
$strmmA [
,mm[ \
nullablemm] e
:mme f
falsemmg l
)mml m
,mmm n
	CreatedBynn 
=nn 
tablenn  %
.nn% &
Columnnn& ,
<nn, -
stringnn- 3
>nn3 4
(nn4 5
typenn5 9
:nn9 :
$strnn; A
,nnA B
nullablennC K
:nnK L
truennM Q
)nnQ R
,nnR S
LastModifiedoo  
=oo! "
tableoo# (
.oo( )
Columnoo) /
<oo/ 0
DateTimeOffsetoo0 >
>oo> ?
(oo? @
typeoo@ D
:ooD E
$strooF `
,oo` a
nullableoob j
:ooj k
falseool q
)ooq r
,oor s
LastModifiedBypp "
=pp# $
tablepp% *
.pp* +
Columnpp+ 1
<pp1 2
stringpp2 8
>pp8 9
(pp9 :
typepp: >
:pp> ?
$strpp@ F
,ppF G
nullableppH P
:ppP Q
trueppR V
)ppV W
}qq 
,qq 
constraintsrr 
:rr 
tablerr "
=>rr# %
{ss 
tablett 
.tt 

PrimaryKeytt $
(tt$ %
$strtt% 5
,tt5 6
xtt7 8
=>tt9 ;
xtt< =
.tt= >
Idtt> @
)tt@ A
;ttA B
}uu 
)uu 
;uu 
migrationBuilderww 
.ww 
CreateTableww (
(ww( )
namexx 
:xx 
$strxx 
,xx 
columnsyy 
:yy 
tableyy 
=>yy !
newyy" %
{zz 
Id{{ 
={{ 
table{{ 
.{{ 
Column{{ %
<{{% &
Guid{{& *
>{{* +
({{+ ,
type{{, 0
:{{0 1
$str{{2 8
,{{8 9
nullable{{: B
:{{B C
false{{D I
){{I J
,{{J K
	ShiftName|| 
=|| 
table||  %
.||% &
Column||& ,
<||, -
string||- 3
>||3 4
(||4 5
type||5 9
:||9 :
$str||; A
,||A B
nullable||C K
:||K L
true||M Q
)||Q R
,||R S
	StartTime}} 
=}} 
table}}  %
.}}% &
Column}}& ,
<}}, -
TimeSpan}}- 5
>}}5 6
(}}6 7
type}}7 ;
:}}; <
$str}}= G
,}}G H
nullable}}I Q
:}}Q R
true}}S W
)}}W X
,}}X Y
EndTime~~ 
=~~ 
table~~ #
.~~# $
Column~~$ *
<~~* +
TimeSpan~~+ 3
>~~3 4
(~~4 5
type~~5 9
:~~9 :
$str~~; E
,~~E F
nullable~~G O
:~~O P
true~~Q U
)~~U V
,~~V W
	IsDeleted 
= 
table  %
.% &
Column& ,
<, -
bool- 1
>1 2
(2 3
type3 7
:7 8
$str9 B
,B C
nullableD L
:L M
falseN S
)S T
,T U
Created
АА 
=
АА 
table
АА #
.
АА# $
Column
АА$ *
<
АА* +
DateTimeOffset
АА+ 9
>
АА9 :
(
АА: ;
type
АА; ?
:
АА? @
$str
ААA [
,
АА[ \
nullable
АА] e
:
ААe f
false
ААg l
)
ААl m
,
ААm n
	CreatedBy
ББ 
=
ББ 
table
ББ  %
.
ББ% &
Column
ББ& ,
<
ББ, -
string
ББ- 3
>
ББ3 4
(
ББ4 5
type
ББ5 9
:
ББ9 :
$str
ББ; A
,
ББA B
nullable
ББC K
:
ББK L
true
ББM Q
)
ББQ R
,
ББR S
LastModified
ВВ  
=
ВВ! "
table
ВВ# (
.
ВВ( )
Column
ВВ) /
<
ВВ/ 0
DateTimeOffset
ВВ0 >
>
ВВ> ?
(
ВВ? @
type
ВВ@ D
:
ВВD E
$str
ВВF `
,
ВВ` a
nullable
ВВb j
:
ВВj k
false
ВВl q
)
ВВq r
,
ВВr s
LastModifiedBy
ГГ "
=
ГГ# $
table
ГГ% *
.
ГГ* +
Column
ГГ+ 1
<
ГГ1 2
string
ГГ2 8
>
ГГ8 9
(
ГГ9 :
type
ГГ: >
:
ГГ> ?
$str
ГГ@ F
,
ГГF G
nullable
ГГH P
:
ГГP Q
true
ГГR V
)
ГГV W
}
ДД 
,
ДД 
constraints
ЕЕ 
:
ЕЕ 
table
ЕЕ "
=>
ЕЕ# %
{
ЖЖ 
table
ЗЗ 
.
ЗЗ 

PrimaryKey
ЗЗ $
(
ЗЗ$ %
$str
ЗЗ% 0
,
ЗЗ0 1
x
ЗЗ2 3
=>
ЗЗ4 6
x
ЗЗ7 8
.
ЗЗ8 9
Id
ЗЗ9 ;
)
ЗЗ; <
;
ЗЗ< =
}
ИИ 
)
ИИ 
;
ИИ 
migrationBuilder
КК 
.
КК 
CreateTable
КК (
(
КК( )
name
ЛЛ 
:
ЛЛ 
$str
ЛЛ (
,
ЛЛ( )
columns
ММ 
:
ММ 
table
ММ 
=>
ММ !
new
ММ" %
{
НН 
Id
ОО 
=
ОО 
table
ОО 
.
ОО 
Column
ОО %
<
ОО% &
int
ОО& )
>
ОО) *
(
ОО* +
type
ОО+ /
:
ОО/ 0
$str
ОО1 :
,
ОО: ;
nullable
ОО< D
:
ООD E
false
ООF K
)
ООK L
.
ПП 

Annotation
ПП #
(
ПП# $
$str
ПП$ D
,
ППD E+
NpgsqlValueGenerationStrategy
ППF c
.
ППc d%
IdentityByDefaultColumn
ППd {
)
ПП{ |
,
ПП| }
RoleId
РР 
=
РР 
table
РР "
.
РР" #
Column
РР# )
<
РР) *
string
РР* 0
>
РР0 1
(
РР1 2
type
РР2 6
:
РР6 7
$str
РР8 >
,
РР> ?
nullable
РР@ H
:
РРH I
false
РРJ O
)
РРO P
,
РРP Q
	ClaimType
СС 
=
СС 
table
СС  %
.
СС% &
Column
СС& ,
<
СС, -
string
СС- 3
>
СС3 4
(
СС4 5
type
СС5 9
:
СС9 :
$str
СС; A
,
ССA B
nullable
ССC K
:
ССK L
true
ССM Q
)
ССQ R
,
ССR S

ClaimValue
ТТ 
=
ТТ  
table
ТТ! &
.
ТТ& '
Column
ТТ' -
<
ТТ- .
string
ТТ. 4
>
ТТ4 5
(
ТТ5 6
type
ТТ6 :
:
ТТ: ;
$str
ТТ< B
,
ТТB C
nullable
ТТD L
:
ТТL M
true
ТТN R
)
ТТR S
}
УУ 
,
УУ 
constraints
ФФ 
:
ФФ 
table
ФФ "
=>
ФФ# %
{
ХХ 
table
ЦЦ 
.
ЦЦ 

PrimaryKey
ЦЦ $
(
ЦЦ$ %
$str
ЦЦ% :
,
ЦЦ: ;
x
ЦЦ< =
=>
ЦЦ> @
x
ЦЦA B
.
ЦЦB C
Id
ЦЦC E
)
ЦЦE F
;
ЦЦF G
table
ЧЧ 
.
ЧЧ 

ForeignKey
ЧЧ $
(
ЧЧ$ %
name
ШШ 
:
ШШ 
$str
ШШ F
,
ШШF G
column
ЩЩ 
:
ЩЩ 
x
ЩЩ  !
=>
ЩЩ" $
x
ЩЩ% &
.
ЩЩ& '
RoleId
ЩЩ' -
,
ЩЩ- .
principalTable
ЪЪ &
:
ЪЪ& '
$str
ЪЪ( 5
,
ЪЪ5 6
principalColumn
ЫЫ '
:
ЫЫ' (
$str
ЫЫ) -
,
ЫЫ- .
onDelete
ЬЬ  
:
ЬЬ  !
ReferentialAction
ЬЬ" 3
.
ЬЬ3 4
Cascade
ЬЬ4 ;
)
ЬЬ; <
;
ЬЬ< =
}
ЭЭ 
)
ЭЭ 
;
ЭЭ 
migrationBuilder
ЯЯ 
.
ЯЯ 
CreateTable
ЯЯ (
(
ЯЯ( )
name
аа 
:
аа 
$str
аа (
,
аа( )
columns
бб 
:
бб 
table
бб 
=>
бб !
new
бб" %
{
вв 
Id
гг 
=
гг 
table
гг 
.
гг 
Column
гг %
<
гг% &
int
гг& )
>
гг) *
(
гг* +
type
гг+ /
:
гг/ 0
$str
гг1 :
,
гг: ;
nullable
гг< D
:
ггD E
false
ггF K
)
ггK L
.
дд 

Annotation
дд #
(
дд# $
$str
дд$ D
,
ддD E+
NpgsqlValueGenerationStrategy
ддF c
.
ддc d%
IdentityByDefaultColumn
ддd {
)
дд{ |
,
дд| }
UserId
ее 
=
ее 
table
ее "
.
ее" #
Column
ее# )
<
ее) *
string
ее* 0
>
ее0 1
(
ее1 2
type
ее2 6
:
ее6 7
$str
ее8 >
,
ее> ?
nullable
ее@ H
:
ееH I
false
ееJ O
)
ееO P
,
ееP Q
	ClaimType
жж 
=
жж 
table
жж  %
.
жж% &
Column
жж& ,
<
жж, -
string
жж- 3
>
жж3 4
(
жж4 5
type
жж5 9
:
жж9 :
$str
жж; A
,
жжA B
nullable
жжC K
:
жжK L
true
жжM Q
)
жжQ R
,
жжR S

ClaimValue
зз 
=
зз  
table
зз! &
.
зз& '
Column
зз' -
<
зз- .
string
зз. 4
>
зз4 5
(
зз5 6
type
зз6 :
:
зз: ;
$str
зз< B
,
ззB C
nullable
ззD L
:
ззL M
true
ззN R
)
ззR S
}
ии 
,
ии 
constraints
йй 
:
йй 
table
йй "
=>
йй# %
{
кк 
table
лл 
.
лл 

PrimaryKey
лл $
(
лл$ %
$str
лл% :
,
лл: ;
x
лл< =
=>
лл> @
x
ллA B
.
ллB C
Id
ллC E
)
ллE F
;
ллF G
table
мм 
.
мм 

ForeignKey
мм $
(
мм$ %
name
нн 
:
нн 
$str
нн F
,
ннF G
column
оо 
:
оо 
x
оо  !
=>
оо" $
x
оо% &
.
оо& '
UserId
оо' -
,
оо- .
principalTable
пп &
:
пп& '
$str
пп( 5
,
пп5 6
principalColumn
░░ '
:
░░' (
$str
░░) -
,
░░- .
onDelete
▒▒  
:
▒▒  !
ReferentialAction
▒▒" 3
.
▒▒3 4
Cascade
▒▒4 ;
)
▒▒; <
;
▒▒< =
}
▓▓ 
)
▓▓ 
;
▓▓ 
migrationBuilder
┤┤ 
.
┤┤ 
CreateTable
┤┤ (
(
┤┤( )
name
╡╡ 
:
╡╡ 
$str
╡╡ (
,
╡╡( )
columns
╢╢ 
:
╢╢ 
table
╢╢ 
=>
╢╢ !
new
╢╢" %
{
╖╖ 
LoginProvider
╕╕ !
=
╕╕" #
table
╕╕$ )
.
╕╕) *
Column
╕╕* 0
<
╕╕0 1
string
╕╕1 7
>
╕╕7 8
(
╕╕8 9
type
╕╕9 =
:
╕╕= >
$str
╕╕? E
,
╕╕E F
nullable
╕╕G O
:
╕╕O P
false
╕╕Q V
)
╕╕V W
,
╕╕W X
ProviderKey
╣╣ 
=
╣╣  !
table
╣╣" '
.
╣╣' (
Column
╣╣( .
<
╣╣. /
string
╣╣/ 5
>
╣╣5 6
(
╣╣6 7
type
╣╣7 ;
:
╣╣; <
$str
╣╣= C
,
╣╣C D
nullable
╣╣E M
:
╣╣M N
false
╣╣O T
)
╣╣T U
,
╣╣U V!
ProviderDisplayName
║║ '
=
║║( )
table
║║* /
.
║║/ 0
Column
║║0 6
<
║║6 7
string
║║7 =
>
║║= >
(
║║> ?
type
║║? C
:
║║C D
$str
║║E K
,
║║K L
nullable
║║M U
:
║║U V
true
║║W [
)
║║[ \
,
║║\ ]
UserId
╗╗ 
=
╗╗ 
table
╗╗ "
.
╗╗" #
Column
╗╗# )
<
╗╗) *
string
╗╗* 0
>
╗╗0 1
(
╗╗1 2
type
╗╗2 6
:
╗╗6 7
$str
╗╗8 >
,
╗╗> ?
nullable
╗╗@ H
:
╗╗H I
false
╗╗J O
)
╗╗O P
}
╝╝ 
,
╝╝ 
constraints
╜╜ 
:
╜╜ 
table
╜╜ "
=>
╜╜# %
{
╛╛ 
table
┐┐ 
.
┐┐ 

PrimaryKey
┐┐ $
(
┐┐$ %
$str
┐┐% :
,
┐┐: ;
x
┐┐< =
=>
┐┐> @
new
┐┐A D
{
┐┐E F
x
┐┐G H
.
┐┐H I
LoginProvider
┐┐I V
,
┐┐V W
x
┐┐X Y
.
┐┐Y Z
ProviderKey
┐┐Z e
}
┐┐f g
)
┐┐g h
;
┐┐h i
table
└└ 
.
└└ 

ForeignKey
└└ $
(
└└$ %
name
┴┴ 
:
┴┴ 
$str
┴┴ F
,
┴┴F G
column
┬┬ 
:
┬┬ 
x
┬┬  !
=>
┬┬" $
x
┬┬% &
.
┬┬& '
UserId
┬┬' -
,
┬┬- .
principalTable
├├ &
:
├├& '
$str
├├( 5
,
├├5 6
principalColumn
── '
:
──' (
$str
──) -
,
──- .
onDelete
┼┼  
:
┼┼  !
ReferentialAction
┼┼" 3
.
┼┼3 4
Cascade
┼┼4 ;
)
┼┼; <
;
┼┼< =
}
╞╞ 
)
╞╞ 
;
╞╞ 
migrationBuilder
╚╚ 
.
╚╚ 
CreateTable
╚╚ (
(
╚╚( )
name
╔╔ 
:
╔╔ 
$str
╔╔ '
,
╔╔' (
columns
╩╩ 
:
╩╩ 
table
╩╩ 
=>
╩╩ !
new
╩╩" %
{
╦╦ 
UserId
╠╠ 
=
╠╠ 
table
╠╠ "
.
╠╠" #
Column
╠╠# )
<
╠╠) *
string
╠╠* 0
>
╠╠0 1
(
╠╠1 2
type
╠╠2 6
:
╠╠6 7
$str
╠╠8 >
,
╠╠> ?
nullable
╠╠@ H
:
╠╠H I
false
╠╠J O
)
╠╠O P
,
╠╠P Q
RoleId
══ 
=
══ 
table
══ "
.
══" #
Column
══# )
<
══) *
string
══* 0
>
══0 1
(
══1 2
type
══2 6
:
══6 7
$str
══8 >
,
══> ?
nullable
══@ H
:
══H I
false
══J O
)
══O P
}
╬╬ 
,
╬╬ 
constraints
╧╧ 
:
╧╧ 
table
╧╧ "
=>
╧╧# %
{
╨╨ 
table
╤╤ 
.
╤╤ 

PrimaryKey
╤╤ $
(
╤╤$ %
$str
╤╤% 9
,
╤╤9 :
x
╤╤; <
=>
╤╤= ?
new
╤╤@ C
{
╤╤D E
x
╤╤F G
.
╤╤G H
UserId
╤╤H N
,
╤╤N O
x
╤╤P Q
.
╤╤Q R
RoleId
╤╤R X
}
╤╤Y Z
)
╤╤Z [
;
╤╤[ \
table
╥╥ 
.
╥╥ 

ForeignKey
╥╥ $
(
╥╥$ %
name
╙╙ 
:
╙╙ 
$str
╙╙ E
,
╙╙E F
column
╘╘ 
:
╘╘ 
x
╘╘  !
=>
╘╘" $
x
╘╘% &
.
╘╘& '
RoleId
╘╘' -
,
╘╘- .
principalTable
╒╒ &
:
╒╒& '
$str
╒╒( 5
,
╒╒5 6
principalColumn
╓╓ '
:
╓╓' (
$str
╓╓) -
,
╓╓- .
onDelete
╫╫  
:
╫╫  !
ReferentialAction
╫╫" 3
.
╫╫3 4
Cascade
╫╫4 ;
)
╫╫; <
;
╫╫< =
table
╪╪ 
.
╪╪ 

ForeignKey
╪╪ $
(
╪╪$ %
name
┘┘ 
:
┘┘ 
$str
┘┘ E
,
┘┘E F
column
┌┌ 
:
┌┌ 
x
┌┌  !
=>
┌┌" $
x
┌┌% &
.
┌┌& '
UserId
┌┌' -
,
┌┌- .
principalTable
██ &
:
██& '
$str
██( 5
,
██5 6
principalColumn
▄▄ '
:
▄▄' (
$str
▄▄) -
,
▄▄- .
onDelete
▌▌  
:
▌▌  !
ReferentialAction
▌▌" 3
.
▌▌3 4
Cascade
▌▌4 ;
)
▌▌; <
;
▌▌< =
}
▐▐ 
)
▐▐ 
;
▐▐ 
migrationBuilder
рр 
.
рр 
CreateTable
рр (
(
рр( )
name
сс 
:
сс 
$str
сс (
,
сс( )
columns
тт 
:
тт 
table
тт 
=>
тт !
new
тт" %
{
уу 
UserId
фф 
=
фф 
table
фф "
.
фф" #
Column
фф# )
<
фф) *
string
фф* 0
>
фф0 1
(
фф1 2
type
фф2 6
:
фф6 7
$str
фф8 >
,
фф> ?
nullable
фф@ H
:
ффH I
false
ффJ O
)
ффO P
,
ффP Q
LoginProvider
хх !
=
хх" #
table
хх$ )
.
хх) *
Column
хх* 0
<
хх0 1
string
хх1 7
>
хх7 8
(
хх8 9
type
хх9 =
:
хх= >
$str
хх? E
,
ххE F
nullable
ххG O
:
ххO P
false
ххQ V
)
ххV W
,
ххW X
Name
цц 
=
цц 
table
цц  
.
цц  !
Column
цц! '
<
цц' (
string
цц( .
>
цц. /
(
цц/ 0
type
цц0 4
:
цц4 5
$str
цц6 <
,
цц< =
nullable
цц> F
:
ццF G
false
ццH M
)
ццM N
,
ццN O
Value
чч 
=
чч 
table
чч !
.
чч! "
Column
чч" (
<
чч( )
string
чч) /
>
чч/ 0
(
чч0 1
type
чч1 5
:
чч5 6
$str
чч7 =
,
чч= >
nullable
чч? G
:
ччG H
true
ччI M
)
ччM N
}
шш 
,
шш 
constraints
щщ 
:
щщ 
table
щщ "
=>
щщ# %
{
ъъ 
table
ыы 
.
ыы 

PrimaryKey
ыы $
(
ыы$ %
$str
ыы% :
,
ыы: ;
x
ыы< =
=>
ыы> @
new
ыыA D
{
ыыE F
x
ыыG H
.
ыыH I
UserId
ыыI O
,
ыыO P
x
ыыQ R
.
ыыR S
LoginProvider
ыыS `
,
ыы` a
x
ыыb c
.
ыыc d
Name
ыыd h
}
ыыi j
)
ыыj k
;
ыыk l
table
ьь 
.
ьь 

ForeignKey
ьь $
(
ьь$ %
name
ээ 
:
ээ 
$str
ээ F
,
ээF G
column
юю 
:
юю 
x
юю  !
=>
юю" $
x
юю% &
.
юю& '
UserId
юю' -
,
юю- .
principalTable
яя &
:
яя& '
$str
яя( 5
,
яя5 6
principalColumn
ЁЁ '
:
ЁЁ' (
$str
ЁЁ) -
,
ЁЁ- .
onDelete
ёё  
:
ёё  !
ReferentialAction
ёё" 3
.
ёё3 4
Cascade
ёё4 ;
)
ёё; <
;
ёё< =
}
ЄЄ 
)
ЄЄ 
;
ЄЄ 
migrationBuilder
ЇЇ 
.
ЇЇ 
CreateTable
ЇЇ (
(
ЇЇ( )
name
її 
:
її 
$str
її !
,
її! "
columns
ЎЎ 
:
ЎЎ 
table
ЎЎ 
=>
ЎЎ !
new
ЎЎ" %
{
ўў 
Id
°° 
=
°° 
table
°° 
.
°° 
Column
°° %
<
°°% &
Guid
°°& *
>
°°* +
(
°°+ ,
type
°°, 0
:
°°0 1
$str
°°2 8
,
°°8 9
nullable
°°: B
:
°°B C
false
°°D I
)
°°I J
,
°°J K
	IsDeleted
∙∙ 
=
∙∙ 
table
∙∙  %
.
∙∙% &
Column
∙∙& ,
<
∙∙, -
bool
∙∙- 1
>
∙∙1 2
(
∙∙2 3
type
∙∙3 7
:
∙∙7 8
$str
∙∙9 B
,
∙∙B C
nullable
∙∙D L
:
∙∙L M
false
∙∙N S
)
∙∙S T
,
∙∙T U
Address
·· 
=
·· 
table
·· #
.
··# $
Column
··$ *
<
··* +
string
··+ 1
>
··1 2
(
··2 3
type
··3 7
:
··7 8
$str
··9 ?
,
··? @
nullable
··A I
:
··I J
false
··K P
)
··P Q
,
··Q R
UserId
√√ 
=
√√ 
table
√√ "
.
√√" #
Column
√√# )
<
√√) *
string
√√* 0
>
√√0 1
(
√√1 2
type
√√2 6
:
√√6 7
$str
√√8 >
,
√√> ?
nullable
√√@ H
:
√√H I
false
√√J O
)
√√O P
,
√√P Q
Created
№№ 
=
№№ 
table
№№ #
.
№№# $
Column
№№$ *
<
№№* +
DateTimeOffset
№№+ 9
>
№№9 :
(
№№: ;
type
№№; ?
:
№№? @
$str
№№A [
,
№№[ \
nullable
№№] e
:
№№e f
false
№№g l
)
№№l m
,
№№m n
	CreatedBy
¤¤ 
=
¤¤ 
table
¤¤  %
.
¤¤% &
Column
¤¤& ,
<
¤¤, -
string
¤¤- 3
>
¤¤3 4
(
¤¤4 5
type
¤¤5 9
:
¤¤9 :
$str
¤¤; A
,
¤¤A B
nullable
¤¤C K
:
¤¤K L
true
¤¤M Q
)
¤¤Q R
,
¤¤R S
LastModified
■■  
=
■■! "
table
■■# (
.
■■( )
Column
■■) /
<
■■/ 0
DateTimeOffset
■■0 >
>
■■> ?
(
■■? @
type
■■@ D
:
■■D E
$str
■■F `
,
■■` a
nullable
■■b j
:
■■j k
false
■■l q
)
■■q r
,
■■r s
LastModifiedBy
   "
=
  # $
table
  % *
.
  * +
Column
  + 1
<
  1 2
string
  2 8
>
  8 9
(
  9 :
type
  : >
:
  > ?
$str
  @ F
,
  F G
nullable
  H P
:
  P Q
true
  R V
)
  V W
}
АА 
,
АА 
constraints
ББ 
:
ББ 
table
ББ "
=>
ББ# %
{
ВВ 
table
ГГ 
.
ГГ 

PrimaryKey
ГГ $
(
ГГ$ %
$str
ГГ% 3
,
ГГ3 4
x
ГГ5 6
=>
ГГ7 9
x
ГГ: ;
.
ГГ; <
Id
ГГ< >
)
ГГ> ?
;
ГГ? @
table
ДД 
.
ДД 

ForeignKey
ДД $
(
ДД$ %
name
ЕЕ 
:
ЕЕ 
$str
ЕЕ ?
,
ЕЕ? @
column
ЖЖ 
:
ЖЖ 
x
ЖЖ  !
=>
ЖЖ" $
x
ЖЖ% &
.
ЖЖ& '
UserId
ЖЖ' -
,
ЖЖ- .
principalTable
ЗЗ &
:
ЗЗ& '
$str
ЗЗ( 5
,
ЗЗ5 6
principalColumn
ИИ '
:
ИИ' (
$str
ИИ) -
,
ИИ- .
onDelete
ЙЙ  
:
ЙЙ  !
ReferentialAction
ЙЙ" 3
.
ЙЙ3 4
Cascade
ЙЙ4 ;
)
ЙЙ; <
;
ЙЙ< =
}
КК 
)
КК 
;
КК 
migrationBuilder
ММ 
.
ММ 
CreateTable
ММ (
(
ММ( )
name
НН 
:
НН 
$str
НН $
,
НН$ %
columns
ОО 
:
ОО 
table
ОО 
=>
ОО !
new
ОО" %
{
ПП 
Id
РР 
=
РР 
table
РР 
.
РР 
Column
РР %
<
РР% &
Guid
РР& *
>
РР* +
(
РР+ ,
type
РР, 0
:
РР0 1
$str
РР2 8
,
РР8 9
nullable
РР: B
:
РРB C
false
РРD I
)
РРI J
,
РРJ K

TotalHours
СС 
=
СС  
table
СС! &
.
СС& '
Column
СС' -
<
СС- .
decimal
СС. 5
>
СС5 6
(
СС6 7
type
СС7 ;
:
СС; <
$str
СС= F
,
ССF G
nullable
ССH P
:
ССP Q
false
ССR W
)
ССW X
,
ССX Y
TotalSalary
ТТ 
=
ТТ  !
table
ТТ" '
.
ТТ' (
Column
ТТ( .
<
ТТ. /
decimal
ТТ/ 6
>
ТТ6 7
(
ТТ7 8
type
ТТ8 <
:
ТТ< =
$str
ТТ> G
,
ТТG H
nullable
ТТI Q
:
ТТQ R
false
ТТS X
)
ТТX Y
,
ТТY Z
Status
УУ 
=
УУ 
table
УУ "
.
УУ" #
Column
УУ# )
<
УУ) *
string
УУ* 0
>
УУ0 1
(
УУ1 2
type
УУ2 6
:
УУ6 7
$str
УУ8 >
,
УУ> ?
nullable
УУ@ H
:
УУH I
true
УУJ N
)
УУN O
,
УУO P
PayDate
ФФ 
=
ФФ 
table
ФФ #
.
ФФ# $
Column
ФФ$ *
<
ФФ* +
DateTime
ФФ+ 3
>
ФФ3 4
(
ФФ4 5
type
ФФ5 9
:
ФФ9 :
$str
ФФ; U
,
ФФU V
nullable
ФФW _
:
ФФ_ `
false
ФФa f
)
ФФf g
,
ФФg h
UserId
ХХ 
=
ХХ 
table
ХХ "
.
ХХ" #
Column
ХХ# )
<
ХХ) *
string
ХХ* 0
>
ХХ0 1
(
ХХ1 2
type
ХХ2 6
:
ХХ6 7
$str
ХХ8 >
,
ХХ> ?
nullable
ХХ@ H
:
ХХH I
true
ХХJ N
)
ХХN O
,
ХХO P
Created
ЦЦ 
=
ЦЦ 
table
ЦЦ #
.
ЦЦ# $
Column
ЦЦ$ *
<
ЦЦ* +
DateTimeOffset
ЦЦ+ 9
>
ЦЦ9 :
(
ЦЦ: ;
type
ЦЦ; ?
:
ЦЦ? @
$str
ЦЦA [
,
ЦЦ[ \
nullable
ЦЦ] e
:
ЦЦe f
false
ЦЦg l
)
ЦЦl m
,
ЦЦm n
	CreatedBy
ЧЧ 
=
ЧЧ 
table
ЧЧ  %
.
ЧЧ% &
Column
ЧЧ& ,
<
ЧЧ, -
string
ЧЧ- 3
>
ЧЧ3 4
(
ЧЧ4 5
type
ЧЧ5 9
:
ЧЧ9 :
$str
ЧЧ; A
,
ЧЧA B
nullable
ЧЧC K
:
ЧЧK L
true
ЧЧM Q
)
ЧЧQ R
,
ЧЧR S
LastModified
ШШ  
=
ШШ! "
table
ШШ# (
.
ШШ( )
Column
ШШ) /
<
ШШ/ 0
DateTimeOffset
ШШ0 >
>
ШШ> ?
(
ШШ? @
type
ШШ@ D
:
ШШD E
$str
ШШF `
,
ШШ` a
nullable
ШШb j
:
ШШj k
false
ШШl q
)
ШШq r
,
ШШr s
LastModifiedBy
ЩЩ "
=
ЩЩ# $
table
ЩЩ% *
.
ЩЩ* +
Column
ЩЩ+ 1
<
ЩЩ1 2
string
ЩЩ2 8
>
ЩЩ8 9
(
ЩЩ9 :
type
ЩЩ: >
:
ЩЩ> ?
$str
ЩЩ@ F
,
ЩЩF G
nullable
ЩЩH P
:
ЩЩP Q
true
ЩЩR V
)
ЩЩV W
}
ЪЪ 
,
ЪЪ 
constraints
ЫЫ 
:
ЫЫ 
table
ЫЫ "
=>
ЫЫ# %
{
ЬЬ 
table
ЭЭ 
.
ЭЭ 

PrimaryKey
ЭЭ $
(
ЭЭ$ %
$str
ЭЭ% 6
,
ЭЭ6 7
x
ЭЭ8 9
=>
ЭЭ: <
x
ЭЭ= >
.
ЭЭ> ?
Id
ЭЭ? A
)
ЭЭA B
;
ЭЭB C
table
ЮЮ 
.
ЮЮ 

ForeignKey
ЮЮ $
(
ЮЮ$ %
name
ЯЯ 
:
ЯЯ 
$str
ЯЯ B
,
ЯЯB C
column
аа 
:
аа 
x
аа  !
=>
аа" $
x
аа% &
.
аа& '
UserId
аа' -
,
аа- .
principalTable
бб &
:
бб& '
$str
бб( 5
,
бб5 6
principalColumn
вв '
:
вв' (
$str
вв) -
)
вв- .
;
вв. /
}
гг 
)
гг 
;
гг 
migrationBuilder
ее 
.
ее 
CreateTable
ее (
(
ее( )
name
жж 
:
жж 
$str
жж '
,
жж' (
columns
зз 
:
зз 
table
зз 
=>
зз !
new
зз" %
{
ии 
Id
йй 
=
йй 
table
йй 
.
йй 
Column
йй %
<
йй% &
Guid
йй& *
>
йй* +
(
йй+ ,
type
йй, 0
:
йй0 1
$str
йй2 8
,
йй8 9
nullable
йй: B
:
ййB C
false
ййD I
)
ййI J
,
ййJ K
ProductName
кк 
=
кк  !
table
кк" '
.
кк' (
Column
кк( .
<
кк. /
string
кк/ 5
>
кк5 6
(
кк6 7
type
кк7 ;
:
кк; <
$str
кк= C
,
ккC D
nullable
ккE M
:
ккM N
false
ккO T
)
ккT U
,
ккU V 
ProductDescription
лл &
=
лл' (
table
лл) .
.
лл. /
Column
лл/ 5
<
лл5 6
string
лл6 <
>
лл< =
(
лл= >
type
лл> B
:
ллB C
$str
ллD J
,
ллJ K
nullable
ллL T
:
ллT U
false
ллV [
)
лл[ \
,
лл\ ]!
ProductImageDefault
мм '
=
мм( )
table
мм* /
.
мм/ 0
Column
мм0 6
<
мм6 7
string
мм7 =
>
мм= >
(
мм> ?
type
мм? C
:
ммC D
$str
ммE K
,
ммK L
nullable
ммM U
:
ммU V
false
ммW \
)
мм\ ]
,
мм] ^

CategoryId
нн 
=
нн  
table
нн! &
.
нн& '
Column
нн' -
<
нн- .
Guid
нн. 2
>
нн2 3
(
нн3 4
type
нн4 8
:
нн8 9
$str
нн: @
,
нн@ A
nullable
ннB J
:
ннJ K
true
ннL P
)
ннP Q
,
ннQ R
	IsDeleted
оо 
=
оо 
table
оо  %
.
оо% &
Column
оо& ,
<
оо, -
bool
оо- 1
>
оо1 2
(
оо2 3
type
оо3 7
:
оо7 8
$str
оо9 B
,
ооB C
nullable
ооD L
:
ооL M
false
ооN S
)
ооS T
,
ооT U
IsDraft
пп 
=
пп 
table
пп #
.
пп# $
Column
пп$ *
<
пп* +
bool
пп+ /
>
пп/ 0
(
пп0 1
type
пп1 5
:
пп5 6
$str
пп7 @
,
пп@ A
nullable
ппB J
:
ппJ K
false
ппL Q
)
ппQ R
,
ппR S
Created
░░ 
=
░░ 
table
░░ #
.
░░# $
Column
░░$ *
<
░░* +
DateTimeOffset
░░+ 9
>
░░9 :
(
░░: ;
type
░░; ?
:
░░? @
$str
░░A [
,
░░[ \
nullable
░░] e
:
░░e f
false
░░g l
)
░░l m
,
░░m n
	CreatedBy
▒▒ 
=
▒▒ 
table
▒▒  %
.
▒▒% &
Column
▒▒& ,
<
▒▒, -
string
▒▒- 3
>
▒▒3 4
(
▒▒4 5
type
▒▒5 9
:
▒▒9 :
$str
▒▒; A
,
▒▒A B
nullable
▒▒C K
:
▒▒K L
true
▒▒M Q
)
▒▒Q R
,
▒▒R S
LastModified
▓▓  
=
▓▓! "
table
▓▓# (
.
▓▓( )
Column
▓▓) /
<
▓▓/ 0
DateTimeOffset
▓▓0 >
>
▓▓> ?
(
▓▓? @
type
▓▓@ D
:
▓▓D E
$str
▓▓F `
,
▓▓` a
nullable
▓▓b j
:
▓▓j k
false
▓▓l q
)
▓▓q r
,
▓▓r s
LastModifiedBy
││ "
=
││# $
table
││% *
.
││* +
Column
││+ 1
<
││1 2
string
││2 8
>
││8 9
(
││9 :
type
││: >
:
││> ?
$str
││@ F
,
││F G
nullable
││H P
:
││P Q
true
││R V
)
││V W
}
┤┤ 
,
┤┤ 
constraints
╡╡ 
:
╡╡ 
table
╡╡ "
=>
╡╡# %
{
╢╢ 
table
╖╖ 
.
╖╖ 

PrimaryKey
╖╖ $
(
╖╖$ %
$str
╖╖% 9
,
╖╖9 :
x
╖╖; <
=>
╖╖= ?
x
╖╖@ A
.
╖╖A B
Id
╖╖B D
)
╖╖D E
;
╖╖E F
table
╕╕ 
.
╕╕ 

ForeignKey
╕╕ $
(
╕╕$ %
name
╣╣ 
:
╣╣ 
$str
╣╣ H
,
╣╣H I
column
║║ 
:
║║ 
x
║║  !
=>
║║" $
x
║║% &
.
║║& '

CategoryId
║║' 1
,
║║1 2
principalTable
╗╗ &
:
╗╗& '
$str
╗╗( 4
,
╗╗4 5
principalColumn
╝╝ '
:
╝╝' (
$str
╝╝) -
)
╝╝- .
;
╝╝. /
}
╜╜ 
)
╜╜ 
;
╜╜ 
migrationBuilder
┐┐ 
.
┐┐ 
CreateTable
┐┐ (
(
┐┐( )
name
└└ 
:
└└ 
$str
└└ *
,
└└* +
columns
┴┴ 
:
┴┴ 
table
┴┴ 
=>
┴┴ !
new
┴┴" %
{
┬┬ 
Id
├├ 
=
├├ 
table
├├ 
.
├├ 
Column
├├ %
<
├├% &
Guid
├├& *
>
├├* +
(
├├+ ,
type
├├, 0
:
├├0 1
$str
├├2 8
,
├├8 9
nullable
├├: B
:
├├B C
false
├├D I
)
├├I J
,
├├J K
IngredientName
── "
=
──# $
table
──% *
.
──* +
Column
──+ 1
<
──1 2
string
──2 8
>
──8 9
(
──9 :
type
──: >
:
──> ?
$str
──@ F
,
──F G
nullable
──H P
:
──P Q
false
──R W
)
──W X
,
──X Y#
IngredientDescription
┼┼ )
=
┼┼* +
table
┼┼, 1
.
┼┼1 2
Column
┼┼2 8
<
┼┼8 9
string
┼┼9 ?
>
┼┼? @
(
┼┼@ A
type
┼┼A E
:
┼┼E F
$str
┼┼G M
,
┼┼M N
nullable
┼┼O W
:
┼┼W X
false
┼┼Y ^
)
┼┼^ _
,
┼┼_ `
IngredientTypeId
╞╞ $
=
╞╞% &
table
╞╞' ,
.
╞╞, -
Column
╞╞- 3
<
╞╞3 4
Guid
╞╞4 8
>
╞╞8 9
(
╞╞9 :
type
╞╞: >
:
╞╞> ?
$str
╞╞@ F
,
╞╞F G
nullable
╞╞H P
:
╞╞P Q
false
╞╞R W
)
╞╞W X
,
╞╞X Y
	IsDeleted
╟╟ 
=
╟╟ 
table
╟╟  %
.
╟╟% &
Column
╟╟& ,
<
╟╟, -
bool
╟╟- 1
>
╟╟1 2
(
╟╟2 3
type
╟╟3 7
:
╟╟7 8
$str
╟╟9 B
,
╟╟B C
nullable
╟╟D L
:
╟╟L M
false
╟╟N S
)
╟╟S T
,
╟╟T U
IngredientMeasure
╚╚ %
=
╚╚& '
table
╚╚( -
.
╚╚- .
Column
╚╚. 4
<
╚╚4 5
byte
╚╚5 9
>
╚╚9 :
(
╚╚: ;
type
╚╚; ?
:
╚╚? @
$str
╚╚A K
,
╚╚K L
nullable
╚╚M U
:
╚╚U V
false
╚╚W \
)
╚╚\ ]
,
╚╚] ^
Created
╔╔ 
=
╔╔ 
table
╔╔ #
.
╔╔# $
Column
╔╔$ *
<
╔╔* +
DateTimeOffset
╔╔+ 9
>
╔╔9 :
(
╔╔: ;
type
╔╔; ?
:
╔╔? @
$str
╔╔A [
,
╔╔[ \
nullable
╔╔] e
:
╔╔e f
false
╔╔g l
)
╔╔l m
,
╔╔m n
	CreatedBy
╩╩ 
=
╩╩ 
table
╩╩  %
.
╩╩% &
Column
╩╩& ,
<
╩╩, -
string
╩╩- 3
>
╩╩3 4
(
╩╩4 5
type
╩╩5 9
:
╩╩9 :
$str
╩╩; A
,
╩╩A B
nullable
╩╩C K
:
╩╩K L
true
╩╩M Q
)
╩╩Q R
,
╩╩R S
LastModified
╦╦  
=
╦╦! "
table
╦╦# (
.
╦╦( )
Column
╦╦) /
<
╦╦/ 0
DateTimeOffset
╦╦0 >
>
╦╦> ?
(
╦╦? @
type
╦╦@ D
:
╦╦D E
$str
╦╦F `
,
╦╦` a
nullable
╦╦b j
:
╦╦j k
false
╦╦l q
)
╦╦q r
,
╦╦r s
LastModifiedBy
╠╠ "
=
╠╠# $
table
╠╠% *
.
╠╠* +
Column
╠╠+ 1
<
╠╠1 2
string
╠╠2 8
>
╠╠8 9
(
╠╠9 :
type
╠╠: >
:
╠╠> ?
$str
╠╠@ F
,
╠╠F G
nullable
╠╠H P
:
╠╠P Q
true
╠╠R V
)
╠╠V W
}
══ 
,
══ 
constraints
╬╬ 
:
╬╬ 
table
╬╬ "
=>
╬╬# %
{
╧╧ 
table
╨╨ 
.
╨╨ 

PrimaryKey
╨╨ $
(
╨╨$ %
$str
╨╨% <
,
╨╨< =
x
╨╨> ?
=>
╨╨@ B
x
╨╨C D
.
╨╨D E
Id
╨╨E G
)
╨╨G H
;
╨╨H I
table
╤╤ 
.
╤╤ 

ForeignKey
╤╤ $
(
╤╤$ %
name
╥╥ 
:
╥╥ 
$str
╥╥ V
,
╥╥V W
column
╙╙ 
:
╙╙ 
x
╙╙  !
=>
╙╙" $
x
╙╙% &
.
╙╙& '
IngredientTypeId
╙╙' 7
,
╙╙7 8
principalTable
╘╘ &
:
╘╘& '
$str
╘╘( 9
,
╘╘9 :
principalColumn
╒╒ '
:
╒╒' (
$str
╒╒) -
,
╒╒- .
onDelete
╓╓  
:
╓╓  !
ReferentialAction
╓╓" 3
.
╓╓3 4
Cascade
╓╓4 ;
)
╓╓; <
;
╓╓< =
}
╫╫ 
)
╫╫ 
;
╫╫ 
migrationBuilder
┘┘ 
.
┘┘ 
CreateTable
┘┘ (
(
┘┘( )
name
┌┌ 
:
┌┌ 
$str
┌┌ 
,
┌┌ 
columns
██ 
:
██ 
table
██ 
=>
██ !
new
██" %
{
▄▄ 
Id
▌▌ 
=
▌▌ 
table
▌▌ 
.
▌▌ 
Column
▌▌ %
<
▌▌% &
Guid
▌▌& *
>
▌▌* +
(
▌▌+ ,
type
▌▌, 0
:
▌▌0 1
$str
▌▌2 8
,
▌▌8 9
nullable
▌▌: B
:
▌▌B C
false
▌▌D I
)
▌▌I J
,
▌▌J K
	ComboName
▐▐ 
=
▐▐ 
table
▐▐  %
.
▐▐% &
Column
▐▐& ,
<
▐▐, -
string
▐▐- 3
>
▐▐3 4
(
▐▐4 5
type
▐▐5 9
:
▐▐9 :
$str
▐▐; A
,
▐▐A B
nullable
▐▐C K
:
▐▐K L
false
▐▐M R
)
▐▐R S
,
▐▐S T
Status
▀▀ 
=
▀▀ 
table
▀▀ "
.
▀▀" #
Column
▀▀# )
<
▀▀) *
byte
▀▀* .
>
▀▀. /
(
▀▀/ 0
type
▀▀0 4
:
▀▀4 5
$str
▀▀6 @
,
▀▀@ A
nullable
▀▀B J
:
▀▀J K
false
▀▀L Q
)
▀▀Q R
,
▀▀R S
	IsDeleted
рр 
=
рр 
table
рр  %
.
рр% &
Column
рр& ,
<
рр, -
bool
рр- 1
>
рр1 2
(
рр2 3
type
рр3 7
:
рр7 8
$str
рр9 B
,
ррB C
nullable
ррD L
:
ррL M
false
ррN S
)
ррS T
,
ррT U
Quantity
сс 
=
сс 
table
сс $
.
сс$ %
Column
сс% +
<
сс+ ,
int
сс, /
>
сс/ 0
(
сс0 1
type
сс1 5
:
сс5 6
$str
сс7 @
,
сс@ A
nullable
ссB J
:
ссJ K
false
ссL Q
)
ссQ R
,
ссR S
Price
тт 
=
тт 
table
тт !
.
тт! "
Column
тт" (
<
тт( )
decimal
тт) 0
>
тт0 1
(
тт1 2
type
тт2 6
:
тт6 7
$str
тт8 A
,
ттA B
nullable
ттC K
:
ттK L
false
ттM R
)
ттR S
,
ттS T
PercentReduce
уу !
=
уу" #
table
уу$ )
.
уу) *
Column
уу* 0
<
уу0 1
decimal
уу1 8
>
уу8 9
(
уу9 :
type
уу: >
:
уу> ?
$str
уу@ I
,
ууI J
nullable
ууK S
:
ууS T
false
ууU Z
)
ууZ [
,
уу[ \
ExpiredDate
фф 
=
фф  !
table
фф" '
.
фф' (
Column
фф( .
<
фф. /
DateTime
фф/ 7
>
фф7 8
(
фф8 9
type
фф9 =
:
фф= >
$str
фф? Y
,
ффY Z
nullable
фф[ c
:
ффc d
false
ффe j
)
ффj k
,
ффk l
RestaurantId
хх  
=
хх! "
table
хх# (
.
хх( )
Column
хх) /
<
хх/ 0
Guid
хх0 4
>
хх4 5
(
хх5 6
type
хх6 :
:
хх: ;
$str
хх< B
,
ххB C
nullable
ххD L
:
ххL M
false
ххN S
)
ххS T
,
ххT U
Created
цц 
=
цц 
table
цц #
.
цц# $
Column
цц$ *
<
цц* +
DateTimeOffset
цц+ 9
>
цц9 :
(
цц: ;
type
цц; ?
:
цц? @
$str
ццA [
,
цц[ \
nullable
цц] e
:
ццe f
false
ццg l
)
ццl m
,
ццm n
	CreatedBy
чч 
=
чч 
table
чч  %
.
чч% &
Column
чч& ,
<
чч, -
string
чч- 3
>
чч3 4
(
чч4 5
type
чч5 9
:
чч9 :
$str
чч; A
,
ччA B
nullable
ччC K
:
ччK L
true
ччM Q
)
ччQ R
,
ччR S
LastModified
шш  
=
шш! "
table
шш# (
.
шш( )
Column
шш) /
<
шш/ 0
DateTimeOffset
шш0 >
>
шш> ?
(
шш? @
type
шш@ D
:
шшD E
$str
шшF `
,
шш` a
nullable
шшb j
:
шшj k
false
шшl q
)
шшq r
,
шшr s
LastModifiedBy
щщ "
=
щщ# $
table
щщ% *
.
щщ* +
Column
щщ+ 1
<
щщ1 2
string
щщ2 8
>
щщ8 9
(
щщ9 :
type
щщ: >
:
щщ> ?
$str
щщ@ F
,
щщF G
nullable
щщH P
:
щщP Q
true
щщR V
)
щщV W
}
ъъ 
,
ъъ 
constraints
ыы 
:
ыы 
table
ыы "
=>
ыы# %
{
ьь 
table
ээ 
.
ээ 

PrimaryKey
ээ $
(
ээ$ %
$str
ээ% 0
,
ээ0 1
x
ээ2 3
=>
ээ4 6
x
ээ7 8
.
ээ8 9
Id
ээ9 ;
)
ээ; <
;
ээ< =
table
юю 
.
юю 

ForeignKey
юю $
(
юю$ %
name
яя 
:
яя 
$str
яя B
,
яяB C
column
ЁЁ 
:
ЁЁ 
x
ЁЁ  !
=>
ЁЁ" $
x
ЁЁ% &
.
ЁЁ& '
RestaurantId
ЁЁ' 3
,
ЁЁ3 4
principalTable
ёё &
:
ёё& '
$str
ёё( 5
,
ёё5 6
principalColumn
ЄЄ '
:
ЄЄ' (
$str
ЄЄ) -
,
ЄЄ- .
onDelete
єє  
:
єє  !
ReferentialAction
єє" 3
.
єє3 4
Cascade
єє4 ;
)
єє; <
;
єє< =
}
ЇЇ 
)
ЇЇ 
;
ЇЇ 
migrationBuilder
ЎЎ 
.
ЎЎ 
CreateTable
ЎЎ (
(
ЎЎ( )
name
ўў 
:
ўў 
$str
ўў !
,
ўў! "
columns
°° 
:
°° 
table
°° 
=>
°° !
new
°°" %
{
∙∙ 
Id
·· 
=
·· 
table
·· 
.
·· 
Column
·· %
<
··% &
Guid
··& *
>
··* +
(
··+ ,
type
··, 0
:
··0 1
$str
··2 8
,
··8 9
nullable
··: B
:
··B C
false
··D I
)
··I J
,
··J K
HireDate
√√ 
=
√√ 
table
√√ $
.
√√$ %
Column
√√% +
<
√√+ ,
DateTime
√√, 4
>
√√4 5
(
√√5 6
type
√√6 :
:
√√: ;
$str
√√< V
,
√√V W
nullable
√√X `
:
√√` a
false
√√b g
)
√√g h
,
√√h i
EmployeeCode
№№  
=
№№! "
table
№№# (
.
№№( )
Column
№№) /
<
№№/ 0
string
№№0 6
>
№№6 7
(
№№7 8
type
№№8 <
:
№№< =
$str
№№> D
,
№№D E
nullable
№№F N
:
№№N O
false
№№P U
)
№№U V
,
№№V W
UserId
¤¤ 
=
¤¤ 
table
¤¤ "
.
¤¤" #
Column
¤¤# )
<
¤¤) *
string
¤¤* 0
>
¤¤0 1
(
¤¤1 2
type
¤¤2 6
:
¤¤6 7
$str
¤¤8 >
,
¤¤> ?
nullable
¤¤@ H
:
¤¤H I
false
¤¤J O
)
¤¤O P
,
¤¤P Q
	IsDeleted
■■ 
=
■■ 
table
■■  %
.
■■% &
Column
■■& ,
<
■■, -
bool
■■- 1
>
■■1 2
(
■■2 3
type
■■3 7
:
■■7 8
$str
■■9 B
,
■■B C
nullable
■■D L
:
■■L M
false
■■N S
)
■■S T
,
■■T U
RestaurantId
    
=
  ! "
table
  # (
.
  ( )
Column
  ) /
<
  / 0
Guid
  0 4
>
  4 5
(
  5 6
type
  6 :
:
  : ;
$str
  < B
,
  B C
nullable
  D L
:
  L M
false
  N S
)
  S T
,
  T U
Created
АА 
=
АА 
table
АА #
.
АА# $
Column
АА$ *
<
АА* +
DateTimeOffset
АА+ 9
>
АА9 :
(
АА: ;
type
АА; ?
:
АА? @
$str
ААA [
,
АА[ \
nullable
АА] e
:
ААe f
false
ААg l
)
ААl m
,
ААm n
	CreatedBy
ББ 
=
ББ 
table
ББ  %
.
ББ% &
Column
ББ& ,
<
ББ, -
string
ББ- 3
>
ББ3 4
(
ББ4 5
type
ББ5 9
:
ББ9 :
$str
ББ; A
,
ББA B
nullable
ББC K
:
ББK L
true
ББM Q
)
ББQ R
,
ББR S
LastModified
ВВ  
=
ВВ! "
table
ВВ# (
.
ВВ( )
Column
ВВ) /
<
ВВ/ 0
DateTimeOffset
ВВ0 >
>
ВВ> ?
(
ВВ? @
type
ВВ@ D
:
ВВD E
$str
ВВF `
,
ВВ` a
nullable
ВВb j
:
ВВj k
false
ВВl q
)
ВВq r
,
ВВr s
LastModifiedBy
ГГ "
=
ГГ# $
table
ГГ% *
.
ГГ* +
Column
ГГ+ 1
<
ГГ1 2
string
ГГ2 8
>
ГГ8 9
(
ГГ9 :
type
ГГ: >
:
ГГ> ?
$str
ГГ@ F
,
ГГF G
nullable
ГГH P
:
ГГP Q
true
ГГR V
)
ГГV W
}
ДД 
,
ДД 
constraints
ЕЕ 
:
ЕЕ 
table
ЕЕ "
=>
ЕЕ# %
{
ЖЖ 
table
ЗЗ 
.
ЗЗ 

PrimaryKey
ЗЗ $
(
ЗЗ$ %
$str
ЗЗ% 3
,
ЗЗ3 4
x
ЗЗ5 6
=>
ЗЗ7 9
x
ЗЗ: ;
.
ЗЗ; <
Id
ЗЗ< >
)
ЗЗ> ?
;
ЗЗ? @
table
ИИ 
.
ИИ 

ForeignKey
ИИ $
(
ИИ$ %
name
ЙЙ 
:
ЙЙ 
$str
ЙЙ ?
,
ЙЙ? @
column
КК 
:
КК 
x
КК  !
=>
КК" $
x
КК% &
.
КК& '
UserId
КК' -
,
КК- .
principalTable
ЛЛ &
:
ЛЛ& '
$str
ЛЛ( 5
,
ЛЛ5 6
principalColumn
ММ '
:
ММ' (
$str
ММ) -
,
ММ- .
onDelete
НН  
:
НН  !
ReferentialAction
НН" 3
.
НН3 4
Cascade
НН4 ;
)
НН; <
;
НН< =
table
ОО 
.
ОО 

ForeignKey
ОО $
(
ОО$ %
name
ПП 
:
ПП 
$str
ПП E
,
ППE F
column
РР 
:
РР 
x
РР  !
=>
РР" $
x
РР% &
.
РР& '
RestaurantId
РР' 3
,
РР3 4
principalTable
СС &
:
СС& '
$str
СС( 5
,
СС5 6
principalColumn
ТТ '
:
ТТ' (
$str
ТТ) -
,
ТТ- .
onDelete
УУ  
:
УУ  !
ReferentialAction
УУ" 3
.
УУ3 4
Cascade
УУ4 ;
)
УУ; <
;
УУ< =
}
ФФ 
)
ФФ 
;
ФФ 
migrationBuilder
ЦЦ 
.
ЦЦ 
CreateTable
ЦЦ (
(
ЦЦ( )
name
ЧЧ 
:
ЧЧ 
$str
ЧЧ "
,
ЧЧ" #
columns
ШШ 
:
ШШ 
table
ШШ 
=>
ШШ !
new
ШШ" %
{
ЩЩ 
Id
ЪЪ 
=
ЪЪ 
table
ЪЪ 
.
ЪЪ 
Column
ЪЪ %
<
ЪЪ% &
Guid
ЪЪ& *
>
ЪЪ* +
(
ЪЪ+ ,
type
ЪЪ, 0
:
ЪЪ0 1
$str
ЪЪ2 8
,
ЪЪ8 9
nullable
ЪЪ: B
:
ЪЪB C
false
ЪЪD I
)
ЪЪI J
,
ЪЪJ K
	GroupName
ЫЫ 
=
ЫЫ 
table
ЫЫ  %
.
ЫЫ% &
Column
ЫЫ& ,
<
ЫЫ, -
string
ЫЫ- 3
>
ЫЫ3 4
(
ЫЫ4 5
type
ЫЫ5 9
:
ЫЫ9 :
$str
ЫЫ; A
,
ЫЫA B
nullable
ЫЫC K
:
ЫЫK L
false
ЫЫM R
)
ЫЫR S
,
ЫЫS T
RestaurantId
ЬЬ  
=
ЬЬ! "
table
ЬЬ# (
.
ЬЬ( )
Column
ЬЬ) /
<
ЬЬ/ 0
Guid
ЬЬ0 4
>
ЬЬ4 5
(
ЬЬ5 6
type
ЬЬ6 :
:
ЬЬ: ;
$str
ЬЬ< B
,
ЬЬB C
nullable
ЬЬD L
:
ЬЬL M
true
ЬЬN R
)
ЬЬR S
,
ЬЬS T
Created
ЭЭ 
=
ЭЭ 
table
ЭЭ #
.
ЭЭ# $
Column
ЭЭ$ *
<
ЭЭ* +
DateTimeOffset
ЭЭ+ 9
>
ЭЭ9 :
(
ЭЭ: ;
type
ЭЭ; ?
:
ЭЭ? @
$str
ЭЭA [
,
ЭЭ[ \
nullable
ЭЭ] e
:
ЭЭe f
false
ЭЭg l
)
ЭЭl m
,
ЭЭm n
	CreatedBy
ЮЮ 
=
ЮЮ 
table
ЮЮ  %
.
ЮЮ% &
Column
ЮЮ& ,
<
ЮЮ, -
string
ЮЮ- 3
>
ЮЮ3 4
(
ЮЮ4 5
type
ЮЮ5 9
:
ЮЮ9 :
$str
ЮЮ; A
,
ЮЮA B
nullable
ЮЮC K
:
ЮЮK L
true
ЮЮM Q
)
ЮЮQ R
,
ЮЮR S
LastModified
ЯЯ  
=
ЯЯ! "
table
ЯЯ# (
.
ЯЯ( )
Column
ЯЯ) /
<
ЯЯ/ 0
DateTimeOffset
ЯЯ0 >
>
ЯЯ> ?
(
ЯЯ? @
type
ЯЯ@ D
:
ЯЯD E
$str
ЯЯF `
,
ЯЯ` a
nullable
ЯЯb j
:
ЯЯj k
false
ЯЯl q
)
ЯЯq r
,
ЯЯr s
LastModifiedBy
аа "
=
аа# $
table
аа% *
.
аа* +
Column
аа+ 1
<
аа1 2
string
аа2 8
>
аа8 9
(
аа9 :
type
аа: >
:
аа> ?
$str
аа@ F
,
ааF G
nullable
ааH P
:
ааP Q
true
ааR V
)
ааV W
}
бб 
,
бб 
constraints
вв 
:
вв 
table
вв "
=>
вв# %
{
гг 
table
дд 
.
дд 

PrimaryKey
дд $
(
дд$ %
$str
дд% 4
,
дд4 5
x
дд6 7
=>
дд8 :
x
дд; <
.
дд< =
Id
дд= ?
)
дд? @
;
дд@ A
table
ее 
.
ее 

ForeignKey
ее $
(
ее$ %
name
жж 
:
жж 
$str
жж F
,
жжF G
column
зз 
:
зз 
x
зз  !
=>
зз" $
x
зз% &
.
зз& '
RestaurantId
зз' 3
,
зз3 4
principalTable
ии &
:
ии& '
$str
ии( 5
,
ии5 6
principalColumn
йй '
:
йй' (
$str
йй) -
)
йй- .
;
йй. /
}
кк 
)
кк 
;
кк 
migrationBuilder
мм 
.
мм 
CreateTable
мм (
(
мм( )
name
нн 
:
нн 
$str
нн #
,
нн# $
columns
оо 
:
оо 
table
оо 
=>
оо !
new
оо" %
{
пп 
Id
░░ 
=
░░ 
table
░░ 
.
░░ 
Column
░░ %
<
░░% &
Guid
░░& *
>
░░* +
(
░░+ ,
type
░░, 0
:
░░0 1
$str
░░2 8
,
░░8 9
nullable
░░: B
:
░░B C
false
░░D I
)
░░I J
,
░░J K
IngredientName
▒▒ "
=
▒▒# $
table
▒▒% *
.
▒▒* +
Column
▒▒+ 1
<
▒▒1 2
string
▒▒2 8
>
▒▒8 9
(
▒▒9 :
type
▒▒: >
:
▒▒> ?
$str
▒▒@ F
,
▒▒F G
nullable
▒▒H P
:
▒▒P Q
false
▒▒R W
)
▒▒W X
,
▒▒X Y
IngredientAmount
▓▓ $
=
▓▓% &
table
▓▓' ,
.
▓▓, -
Column
▓▓- 3
<
▓▓3 4
decimal
▓▓4 ;
>
▓▓; <
(
▓▓< =
type
▓▓= A
:
▓▓A B
$str
▓▓C L
,
▓▓L M
nullable
▓▓N V
:
▓▓V W
false
▓▓X ]
)
▓▓] ^
,
▓▓^ _
ExpriedQuantity
││ #
=
││$ %
table
││& +
.
││+ ,
Column
││, 2
<
││2 3
decimal
││3 :
>
││: ;
(
││; <
type
││< @
:
││@ A
$str
││B K
,
││K L
nullable
││M U
:
││U V
false
││W \
)
││\ ]
,
││] ^
IngredientTypeId
┤┤ $
=
┤┤% &
table
┤┤' ,
.
┤┤, -
Column
┤┤- 3
<
┤┤3 4
Guid
┤┤4 8
>
┤┤8 9
(
┤┤9 :
type
┤┤: >
:
┤┤> ?
$str
┤┤@ F
,
┤┤F G
nullable
┤┤H P
:
┤┤P Q
true
┤┤R V
)
┤┤V W
,
┤┤W X
RestaurantId
╡╡  
=
╡╡! "
table
╡╡# (
.
╡╡( )
Column
╡╡) /
<
╡╡/ 0
Guid
╡╡0 4
>
╡╡4 5
(
╡╡5 6
type
╡╡6 :
:
╡╡: ;
$str
╡╡< B
,
╡╡B C
nullable
╡╡D L
:
╡╡L M
true
╡╡N R
)
╡╡R S
,
╡╡S T
Created
╢╢ 
=
╢╢ 
table
╢╢ #
.
╢╢# $
Column
╢╢$ *
<
╢╢* +
DateTimeOffset
╢╢+ 9
>
╢╢9 :
(
╢╢: ;
type
╢╢; ?
:
╢╢? @
$str
╢╢A [
,
╢╢[ \
nullable
╢╢] e
:
╢╢e f
false
╢╢g l
)
╢╢l m
,
╢╢m n
	CreatedBy
╖╖ 
=
╖╖ 
table
╖╖  %
.
╖╖% &
Column
╖╖& ,
<
╖╖, -
string
╖╖- 3
>
╖╖3 4
(
╖╖4 5
type
╖╖5 9
:
╖╖9 :
$str
╖╖; A
,
╖╖A B
nullable
╖╖C K
:
╖╖K L
true
╖╖M Q
)
╖╖Q R
,
╖╖R S
LastModified
╕╕  
=
╕╕! "
table
╕╕# (
.
╕╕( )
Column
╕╕) /
<
╕╕/ 0
DateTimeOffset
╕╕0 >
>
╕╕> ?
(
╕╕? @
type
╕╕@ D
:
╕╕D E
$str
╕╕F `
,
╕╕` a
nullable
╕╕b j
:
╕╕j k
false
╕╕l q
)
╕╕q r
,
╕╕r s
LastModifiedBy
╣╣ "
=
╣╣# $
table
╣╣% *
.
╣╣* +
Column
╣╣+ 1
<
╣╣1 2
string
╣╣2 8
>
╣╣8 9
(
╣╣9 :
type
╣╣: >
:
╣╣> ?
$str
╣╣@ F
,
╣╣F G
nullable
╣╣H P
:
╣╣P Q
true
╣╣R V
)
╣╣V W
}
║║ 
,
║║ 
constraints
╗╗ 
:
╗╗ 
table
╗╗ "
=>
╗╗# %
{
╝╝ 
table
╜╜ 
.
╜╜ 

PrimaryKey
╜╜ $
(
╜╜$ %
$str
╜╜% 5
,
╜╜5 6
x
╜╜7 8
=>
╜╜9 ;
x
╜╜< =
.
╜╜= >
Id
╜╜> @
)
╜╜@ A
;
╜╜A B
table
╛╛ 
.
╛╛ 

ForeignKey
╛╛ $
(
╛╛$ %
name
┐┐ 
:
┐┐ 
$str
┐┐ O
,
┐┐O P
column
└└ 
:
└└ 
x
└└  !
=>
└└" $
x
└└% &
.
└└& '
IngredientTypeId
└└' 7
,
└└7 8
principalTable
┴┴ &
:
┴┴& '
$str
┴┴( 9
,
┴┴9 :
principalColumn
┬┬ '
:
┬┬' (
$str
┬┬) -
)
┬┬- .
;
┬┬. /
table
├├ 
.
├├ 

ForeignKey
├├ $
(
├├$ %
name
── 
:
── 
$str
── G
,
──G H
column
┼┼ 
:
┼┼ 
x
┼┼  !
=>
┼┼" $
x
┼┼% &
.
┼┼& '
RestaurantId
┼┼' 3
,
┼┼3 4
principalTable
╞╞ &
:
╞╞& '
$str
╞╞( 5
,
╞╞5 6
principalColumn
╟╟ '
:
╟╟' (
$str
╟╟) -
)
╟╟- .
;
╟╟. /
}
╚╚ 
)
╚╚ 
;
╚╚ 
migrationBuilder
╩╩ 
.
╩╩ 
CreateTable
╩╩ (
(
╩╩( )
name
╦╦ 
:
╦╦ 
$str
╦╦ 
,
╦╦ 
columns
╠╠ 
:
╠╠ 
table
╠╠ 
=>
╠╠ !
new
╠╠" %
{
══ 
Id
╬╬ 
=
╬╬ 
table
╬╬ 
.
╬╬ 
Column
╬╬ %
<
╬╬% &
Guid
╬╬& *
>
╬╬* +
(
╬╬+ ,
type
╬╬, 0
:
╬╬0 1
$str
╬╬2 8
,
╬╬8 9
nullable
╬╬: B
:
╬╬B C
false
╬╬D I
)
╬╬I J
,
╬╬J K
TableNumber
╧╧ 
=
╧╧  !
table
╧╧" '
.
╧╧' (
Column
╧╧( .
<
╧╧. /
int
╧╧/ 2
>
╧╧2 3
(
╧╧3 4
type
╧╧4 8
:
╧╧8 9
$str
╧╧: C
,
╧╧C D
nullable
╧╧E M
:
╧╧M N
false
╧╧O T
)
╧╧T U
,
╧╧U V
	TableCode
╨╨ 
=
╨╨ 
table
╨╨  %
.
╨╨% &
Column
╨╨& ,
<
╨╨, -
string
╨╨- 3
>
╨╨3 4
(
╨╨4 5
type
╨╨5 9
:
╨╨9 :
$str
╨╨; A
,
╨╨A B
nullable
╨╨C K
:
╨╨K L
true
╨╨M Q
)
╨╨Q R
,
╨╨R S
TableStatus
╤╤ 
=
╤╤  !
table
╤╤" '
.
╤╤' (
Column
╤╤( .
<
╤╤. /
byte
╤╤/ 3
>
╤╤3 4
(
╤╤4 5
type
╤╤5 9
:
╤╤9 :
$str
╤╤; E
,
╤╤E F
nullable
╤╤G O
:
╤╤O P
false
╤╤Q V
)
╤╤V W
,
╤╤W X
TableQRCode
╥╥ 
=
╥╥  !
table
╥╥" '
.
╥╥' (
Column
╥╥( .
<
╥╥. /
string
╥╥/ 5
>
╥╥5 6
(
╥╥6 7
type
╥╥7 ;
:
╥╥; <
$str
╥╥= C
,
╥╥C D
nullable
╥╥E M
:
╥╥M N
true
╥╥O S
)
╥╥S T
,
╥╥T U
	IsDeleted
╙╙ 
=
╙╙ 
table
╙╙  %
.
╙╙% &
Column
╙╙& ,
<
╙╙, -
bool
╙╙- 1
>
╙╙1 2
(
╙╙2 3
type
╙╙3 7
:
╙╙7 8
$str
╙╙9 B
,
╙╙B C
nullable
╙╙D L
:
╙╙L M
false
╙╙N S
)
╙╙S T
,
╙╙T U
RestaurantId
╘╘  
=
╘╘! "
table
╘╘# (
.
╘╘( )
Column
╘╘) /
<
╘╘/ 0
Guid
╘╘0 4
>
╘╘4 5
(
╘╘5 6
type
╘╘6 :
:
╘╘: ;
$str
╘╘< B
,
╘╘B C
nullable
╘╘D L
:
╘╘L M
false
╘╘N S
)
╘╘S T
,
╘╘T U
Created
╒╒ 
=
╒╒ 
table
╒╒ #
.
╒╒# $
Column
╒╒$ *
<
╒╒* +
DateTimeOffset
╒╒+ 9
>
╒╒9 :
(
╒╒: ;
type
╒╒; ?
:
╒╒? @
$str
╒╒A [
,
╒╒[ \
nullable
╒╒] e
:
╒╒e f
false
╒╒g l
)
╒╒l m
,
╒╒m n
	CreatedBy
╓╓ 
=
╓╓ 
table
╓╓  %
.
╓╓% &
Column
╓╓& ,
<
╓╓, -
string
╓╓- 3
>
╓╓3 4
(
╓╓4 5
type
╓╓5 9
:
╓╓9 :
$str
╓╓; A
,
╓╓A B
nullable
╓╓C K
:
╓╓K L
true
╓╓M Q
)
╓╓Q R
,
╓╓R S
LastModified
╫╫  
=
╫╫! "
table
╫╫# (
.
╫╫( )
Column
╫╫) /
<
╫╫/ 0
DateTimeOffset
╫╫0 >
>
╫╫> ?
(
╫╫? @
type
╫╫@ D
:
╫╫D E
$str
╫╫F `
,
╫╫` a
nullable
╫╫b j
:
╫╫j k
false
╫╫l q
)
╫╫q r
,
╫╫r s
LastModifiedBy
╪╪ "
=
╪╪# $
table
╪╪% *
.
╪╪* +
Column
╪╪+ 1
<
╪╪1 2
string
╪╪2 8
>
╪╪8 9
(
╪╪9 :
type
╪╪: >
:
╪╪> ?
$str
╪╪@ F
,
╪╪F G
nullable
╪╪H P
:
╪╪P Q
true
╪╪R V
)
╪╪V W
}
┘┘ 
,
┘┘ 
constraints
┌┌ 
:
┌┌ 
table
┌┌ "
=>
┌┌# %
{
██ 
table
▄▄ 
.
▄▄ 

PrimaryKey
▄▄ $
(
▄▄$ %
$str
▄▄% 0
,
▄▄0 1
x
▄▄2 3
=>
▄▄4 6
x
▄▄7 8
.
▄▄8 9
Id
▄▄9 ;
)
▄▄; <
;
▄▄< =
table
▌▌ 
.
▌▌ 

ForeignKey
▌▌ $
(
▌▌$ %
name
▐▐ 
:
▐▐ 
$str
▐▐ B
,
▐▐B C
column
▀▀ 
:
▀▀ 
x
▀▀  !
=>
▀▀" $
x
▀▀% &
.
▀▀& '
RestaurantId
▀▀' 3
,
▀▀3 4
principalTable
рр &
:
рр& '
$str
рр( 5
,
рр5 6
principalColumn
сс '
:
сс' (
$str
сс) -
,
сс- .
onDelete
тт  
:
тт  !
ReferentialAction
тт" 3
.
тт3 4
Cascade
тт4 ;
)
тт; <
;
тт< =
}
уу 
)
уу 
;
уу 
migrationBuilder
хх 
.
хх 
CreateTable
хх (
(
хх( )
name
цц 
:
цц 
$str
цц ,
,
цц, -
columns
чч 
:
чч 
table
чч 
=>
чч !
new
чч" %
{
шш 
Id
щщ 
=
щщ 
table
щщ 
.
щщ 
Column
щщ %
<
щщ% &
Guid
щщ& *
>
щщ* +
(
щщ+ ,
type
щщ, 0
:
щщ0 1
$str
щщ2 8
,
щщ8 9
nullable
щщ: B
:
щщB C
false
щщD I
)
щщI J
,
щщJ K
RestaurantId
ъъ  
=
ъъ! "
table
ъъ# (
.
ъъ( )
Column
ъъ) /
<
ъъ/ 0
Guid
ъъ0 4
>
ъъ4 5
(
ъъ5 6
type
ъъ6 :
:
ъъ: ;
$str
ъъ< B
,
ъъB C
nullable
ъъD L
:
ъъL M
false
ъъN S
)
ъъS T
,
ъъT U
ProductGeneralId
ыы $
=
ыы% &
table
ыы' ,
.
ыы, -
Column
ыы- 3
<
ыы3 4
Guid
ыы4 8
>
ыы8 9
(
ыы9 :
type
ыы: >
:
ыы> ?
$str
ыы@ F
,
ыыF G
nullable
ыыH P
:
ыыP Q
false
ыыR W
)
ыыW X
,
ыыX Y
Status
ьь 
=
ьь 
table
ьь "
.
ьь" #
Column
ьь# )
<
ьь) *
byte
ьь* .
>
ьь. /
(
ьь/ 0
type
ьь0 4
:
ьь4 5
$str
ьь6 @
,
ьь@ A
nullable
ььB J
:
ььJ K
false
ььL Q
)
ььQ R
,
ььR S
Created
ээ 
=
ээ 
table
ээ #
.
ээ# $
Column
ээ$ *
<
ээ* +
DateTimeOffset
ээ+ 9
>
ээ9 :
(
ээ: ;
type
ээ; ?
:
ээ? @
$str
ээA [
,
ээ[ \
nullable
ээ] e
:
ээe f
false
ээg l
)
ээl m
,
ээm n
	CreatedBy
юю 
=
юю 
table
юю  %
.
юю% &
Column
юю& ,
<
юю, -
string
юю- 3
>
юю3 4
(
юю4 5
type
юю5 9
:
юю9 :
$str
юю; A
,
ююA B
nullable
ююC K
:
ююK L
true
ююM Q
)
ююQ R
,
ююR S
LastModified
яя  
=
яя! "
table
яя# (
.
яя( )
Column
яя) /
<
яя/ 0
DateTimeOffset
яя0 >
>
яя> ?
(
яя? @
type
яя@ D
:
яяD E
$str
яяF `
,
яя` a
nullable
яяb j
:
яяj k
false
яяl q
)
яяq r
,
яяr s
LastModifiedBy
ЁЁ "
=
ЁЁ# $
table
ЁЁ% *
.
ЁЁ* +
Column
ЁЁ+ 1
<
ЁЁ1 2
string
ЁЁ2 8
>
ЁЁ8 9
(
ЁЁ9 :
type
ЁЁ: >
:
ЁЁ> ?
$str
ЁЁ@ F
,
ЁЁF G
nullable
ЁЁH P
:
ЁЁP Q
true
ЁЁR V
)
ЁЁV W
}
ёё 
,
ёё 
constraints
ЄЄ 
:
ЄЄ 
table
ЄЄ "
=>
ЄЄ# %
{
єє 
table
ЇЇ 
.
ЇЇ 

PrimaryKey
ЇЇ $
(
ЇЇ$ %
$str
ЇЇ% >
,
ЇЇ> ?
x
ЇЇ@ A
=>
ЇЇB D
x
ЇЇE F
.
ЇЇF G
Id
ЇЇG I
)
ЇЇI J
;
ЇЇJ K
table
її 
.
її 

ForeignKey
її $
(
її$ %
name
ЎЎ 
:
ЎЎ 
$str
ЎЎ X
,
ЎЎX Y
column
ўў 
:
ўў 
x
ўў  !
=>
ўў" $
x
ўў% &
.
ўў& '
ProductGeneralId
ўў' 7
,
ўў7 8
principalTable
°° &
:
°°& '
$str
°°( 9
,
°°9 :
principalColumn
∙∙ '
:
∙∙' (
$str
∙∙) -
,
∙∙- .
onDelete
··  
:
··  !
ReferentialAction
··" 3
.
··3 4
Cascade
··4 ;
)
··; <
;
··< =
table
√√ 
.
√√ 

ForeignKey
√√ $
(
√√$ %
name
№№ 
:
№№ 
$str
№№ P
,
№№P Q
column
¤¤ 
:
¤¤ 
x
¤¤  !
=>
¤¤" $
x
¤¤% &
.
¤¤& '
RestaurantId
¤¤' 3
,
¤¤3 4
principalTable
■■ &
:
■■& '
$str
■■( 5
,
■■5 6
principalColumn
   '
:
  ' (
$str
  ) -
,
  - .
onDelete
АА  
:
АА  !
ReferentialAction
АА" 3
.
АА3 4
Cascade
АА4 ;
)
АА; <
;
АА< =
}
ББ 
)
ББ 
;
ББ 
migrationBuilder
ГГ 
.
ГГ 
CreateTable
ГГ (
(
ГГ( )
name
ДД 
:
ДД 
$str
ДД  
,
ДД  !
columns
ЕЕ 
:
ЕЕ 
table
ЕЕ 
=>
ЕЕ !
new
ЕЕ" %
{
ЖЖ 
Id
ЗЗ 
=
ЗЗ 
table
ЗЗ 
.
ЗЗ 
Column
ЗЗ %
<
ЗЗ% &
Guid
ЗЗ& *
>
ЗЗ* +
(
ЗЗ+ ,
type
ЗЗ, 0
:
ЗЗ0 1
$str
ЗЗ2 8
,
ЗЗ8 9
nullable
ЗЗ: B
:
ЗЗB C
false
ЗЗD I
)
ЗЗI J
,
ЗЗJ K
ProductName
ИИ 
=
ИИ  !
table
ИИ" '
.
ИИ' (
Column
ИИ( .
<
ИИ. /
string
ИИ/ 5
>
ИИ5 6
(
ИИ6 7
type
ИИ7 ;
:
ИИ; <
$str
ИИ= C
,
ИИC D
nullable
ИИE M
:
ИИM N
false
ИИO T
)
ИИT U
,
ИИU V 
ProductDescription
ЙЙ &
=
ЙЙ' (
table
ЙЙ) .
.
ЙЙ. /
Column
ЙЙ/ 5
<
ЙЙ5 6
string
ЙЙ6 <
>
ЙЙ< =
(
ЙЙ= >
type
ЙЙ> B
:
ЙЙB C
$str
ЙЙD J
,
ЙЙJ K
nullable
ЙЙL T
:
ЙЙT U
false
ЙЙV [
)
ЙЙ[ \
,
ЙЙ\ ]
ProductType
КК 
=
КК  !
table
КК" '
.
КК' (
Column
КК( .
<
КК. /
byte
КК/ 3
>
КК3 4
(
КК4 5
type
КК5 9
:
КК9 :
$str
КК; E
,
ККE F
nullable
ККG O
:
ККO P
false
ККQ V
)
ККV W
,
ККW X

CategoryId
ЛЛ 
=
ЛЛ  
table
ЛЛ! &
.
ЛЛ& '
Column
ЛЛ' -
<
ЛЛ- .
Guid
ЛЛ. 2
>
ЛЛ2 3
(
ЛЛ3 4
type
ЛЛ4 8
:
ЛЛ8 9
$str
ЛЛ: @
,
ЛЛ@ A
nullable
ЛЛB J
:
ЛЛJ K
true
ЛЛL P
)
ЛЛP Q
,
ЛЛQ R
Price
ММ 
=
ММ 
table
ММ !
.
ММ! "
Column
ММ" (
<
ММ( )
decimal
ММ) 0
>
ММ0 1
(
ММ1 2
type
ММ2 6
:
ММ6 7
$str
ММ8 A
,
ММA B
nullable
ММC K
:
ММK L
true
ММM Q
)
ММQ R
,
ММR S
RestaurantId
НН  
=
НН! "
table
НН# (
.
НН( )
Column
НН) /
<
НН/ 0
Guid
НН0 4
>
НН4 5
(
НН5 6
type
НН6 :
:
НН: ;
$str
НН< B
,
ННB C
nullable
ННD L
:
ННL M
false
ННN S
)
ННS T
,
ННT U
ProductGeneralId
ОО $
=
ОО% &
table
ОО' ,
.
ОО, -
Column
ОО- 3
<
ОО3 4
Guid
ОО4 8
>
ОО8 9
(
ОО9 :
type
ОО: >
:
ОО> ?
$str
ОО@ F
,
ООF G
nullable
ООH P
:
ООP Q
true
ООR V
)
ООV W
,
ООW X
	IsDeleted
ПП 
=
ПП 
table
ПП  %
.
ПП% &
Column
ПП& ,
<
ПП, -
bool
ПП- 1
>
ПП1 2
(
ПП2 3
type
ПП3 7
:
ПП7 8
$str
ПП9 B
,
ППB C
nullable
ППD L
:
ППL M
false
ППN S
)
ППS T
,
ППT U
Created
РР 
=
РР 
table
РР #
.
РР# $
Column
РР$ *
<
РР* +
DateTimeOffset
РР+ 9
>
РР9 :
(
РР: ;
type
РР; ?
:
РР? @
$str
РРA [
,
РР[ \
nullable
РР] e
:
РРe f
false
РРg l
)
РРl m
,
РРm n
	CreatedBy
СС 
=
СС 
table
СС  %
.
СС% &
Column
СС& ,
<
СС, -
string
СС- 3
>
СС3 4
(
СС4 5
type
СС5 9
:
СС9 :
$str
СС; A
,
ССA B
nullable
ССC K
:
ССK L
true
ССM Q
)
ССQ R
,
ССR S
LastModified
ТТ  
=
ТТ! "
table
ТТ# (
.
ТТ( )
Column
ТТ) /
<
ТТ/ 0
DateTimeOffset
ТТ0 >
>
ТТ> ?
(
ТТ? @
type
ТТ@ D
:
ТТD E
$str
ТТF `
,
ТТ` a
nullable
ТТb j
:
ТТj k
false
ТТl q
)
ТТq r
,
ТТr s
LastModifiedBy
УУ "
=
УУ# $
table
УУ% *
.
УУ* +
Column
УУ+ 1
<
УУ1 2
string
УУ2 8
>
УУ8 9
(
УУ9 :
type
УУ: >
:
УУ> ?
$str
УУ@ F
,
УУF G
nullable
УУH P
:
УУP Q
true
УУR V
)
УУV W
}
ФФ 
,
ФФ 
constraints
ХХ 
:
ХХ 
table
ХХ "
=>
ХХ# %
{
ЦЦ 
table
ЧЧ 
.
ЧЧ 

PrimaryKey
ЧЧ $
(
ЧЧ$ %
$str
ЧЧ% 2
,
ЧЧ2 3
x
ЧЧ4 5
=>
ЧЧ6 8
x
ЧЧ9 :
.
ЧЧ: ;
Id
ЧЧ; =
)
ЧЧ= >
;
ЧЧ> ?
table
ШШ 
.
ШШ 

ForeignKey
ШШ $
(
ШШ$ %
name
ЩЩ 
:
ЩЩ 
$str
ЩЩ A
,
ЩЩA B
column
ЪЪ 
:
ЪЪ 
x
ЪЪ  !
=>
ЪЪ" $
x
ЪЪ% &
.
ЪЪ& '

CategoryId
ЪЪ' 1
,
ЪЪ1 2
principalTable
ЫЫ &
:
ЫЫ& '
$str
ЫЫ( 4
,
ЫЫ4 5
principalColumn
ЬЬ '
:
ЬЬ' (
$str
ЬЬ) -
)
ЬЬ- .
;
ЬЬ. /
table
ЭЭ 
.
ЭЭ 

ForeignKey
ЭЭ $
(
ЭЭ$ %
name
ЮЮ 
:
ЮЮ 
$str
ЮЮ L
,
ЮЮL M
column
ЯЯ 
:
ЯЯ 
x
ЯЯ  !
=>
ЯЯ" $
x
ЯЯ% &
.
ЯЯ& '
ProductGeneralId
ЯЯ' 7
,
ЯЯ7 8
principalTable
аа &
:
аа& '
$str
аа( 9
,
аа9 :
principalColumn
бб '
:
бб' (
$str
бб) -
)
бб- .
;
бб. /
table
вв 
.
вв 

ForeignKey
вв $
(
вв$ %
name
гг 
:
гг 
$str
гг D
,
ггD E
column
дд 
:
дд 
x
дд  !
=>
дд" $
x
дд% &
.
дд& '
RestaurantId
дд' 3
,
дд3 4
principalTable
ее &
:
ее& '
$str
ее( 5
,
ее5 6
principalColumn
жж '
:
жж' (
$str
жж) -
,
жж- .
onDelete
зз  
:
зз  !
ReferentialAction
зз" 3
.
зз3 4
Cascade
зз4 ;
)
зз; <
;
зз< =
}
ии 
)
ии 
;
ии 
migrationBuilder
кк 
.
кк 
CreateTable
кк (
(
кк( )
name
лл 
:
лл 
$str
лл 1
,
лл1 2
columns
мм 
:
мм 
table
мм 
=>
мм !
new
мм" %
{
нн 
Id
оо 
=
оо 
table
оо 
.
оо 
Column
оо %
<
оо% &
Guid
оо& *
>
оо* +
(
оо+ ,
type
оо, 0
:
оо0 1
$str
оо2 8
,
оо8 9
nullable
оо: B
:
ооB C
false
ооD I
)
ооI J
,
ооJ K
ProductGeneralId
пп $
=
пп% &
table
пп' ,
.
пп, -
Column
пп- 3
<
пп3 4
Guid
пп4 8
>
пп8 9
(
пп9 :
type
пп: >
:
пп> ?
$str
пп@ F
,
ппF G
nullable
ппH P
:
ппP Q
false
ппR W
)
ппW X
,
ппX Y
Quantity
░░ 
=
░░ 
table
░░ $
.
░░$ %
Column
░░% +
<
░░+ ,
decimal
░░, 3
>
░░3 4
(
░░4 5
type
░░5 9
:
░░9 :
$str
░░; D
,
░░D E
nullable
░░F N
:
░░N O
false
░░P U
)
░░U V
,
░░V W!
IngredientGeneralId
▒▒ '
=
▒▒( )
table
▒▒* /
.
▒▒/ 0
Column
▒▒0 6
<
▒▒6 7
Guid
▒▒7 ;
>
▒▒; <
(
▒▒< =
type
▒▒= A
:
▒▒A B
$str
▒▒C I
,
▒▒I J
nullable
▒▒K S
:
▒▒S T
false
▒▒U Z
)
▒▒Z [
,
▒▒[ \
	IsDeleted
▓▓ 
=
▓▓ 
table
▓▓  %
.
▓▓% &
Column
▓▓& ,
<
▓▓, -
bool
▓▓- 1
>
▓▓1 2
(
▓▓2 3
type
▓▓3 7
:
▓▓7 8
$str
▓▓9 B
,
▓▓B C
nullable
▓▓D L
:
▓▓L M
false
▓▓N S
)
▓▓S T
,
▓▓T U
Created
││ 
=
││ 
table
││ #
.
││# $
Column
││$ *
<
││* +
DateTimeOffset
││+ 9
>
││9 :
(
││: ;
type
││; ?
:
││? @
$str
││A [
,
││[ \
nullable
││] e
:
││e f
false
││g l
)
││l m
,
││m n
	CreatedBy
┤┤ 
=
┤┤ 
table
┤┤  %
.
┤┤% &
Column
┤┤& ,
<
┤┤, -
string
┤┤- 3
>
┤┤3 4
(
┤┤4 5
type
┤┤5 9
:
┤┤9 :
$str
┤┤; A
,
┤┤A B
nullable
┤┤C K
:
┤┤K L
true
┤┤M Q
)
┤┤Q R
,
┤┤R S
LastModified
╡╡  
=
╡╡! "
table
╡╡# (
.
╡╡( )
Column
╡╡) /
<
╡╡/ 0
DateTimeOffset
╡╡0 >
>
╡╡> ?
(
╡╡? @
type
╡╡@ D
:
╡╡D E
$str
╡╡F `
,
╡╡` a
nullable
╡╡b j
:
╡╡j k
false
╡╡l q
)
╡╡q r
,
╡╡r s
LastModifiedBy
╢╢ "
=
╢╢# $
table
╢╢% *
.
╢╢* +
Column
╢╢+ 1
<
╢╢1 2
string
╢╢2 8
>
╢╢8 9
(
╢╢9 :
type
╢╢: >
:
╢╢> ?
$str
╢╢@ F
,
╢╢F G
nullable
╢╢H P
:
╢╢P Q
true
╢╢R V
)
╢╢V W
}
╖╖ 
,
╖╖ 
constraints
╕╕ 
:
╕╕ 
table
╕╕ "
=>
╕╕# %
{
╣╣ 
table
║║ 
.
║║ 

PrimaryKey
║║ $
(
║║$ %
$str
║║% C
,
║║C D
x
║║E F
=>
║║G I
x
║║J K
.
║║K L
Id
║║L N
)
║║N O
;
║║O P
table
╗╗ 
.
╗╗ 

ForeignKey
╗╗ $
(
╗╗$ %
name
╝╝ 
:
╝╝ 
$str
╝╝ _
,
╝╝_ `
column
╜╜ 
:
╜╜ 
x
╜╜  !
=>
╜╜" $
x
╜╜% &
.
╜╜& '!
IngredientGeneralId
╜╜' :
,
╜╜: ;
principalTable
╛╛ &
:
╛╛& '
$str
╛╛( <
,
╛╛< =
principalColumn
┐┐ '
:
┐┐' (
$str
┐┐) -
,
┐┐- .
onDelete
└└  
:
└└  !
ReferentialAction
└└" 3
.
└└3 4
Cascade
└└4 ;
)
└└; <
;
└└< =
table
┴┴ 
.
┴┴ 

ForeignKey
┴┴ $
(
┴┴$ %
name
┬┬ 
:
┬┬ 
$str
┬┬ ]
,
┬┬] ^
column
├├ 
:
├├ 
x
├├  !
=>
├├" $
x
├├% &
.
├├& '
ProductGeneralId
├├' 7
,
├├7 8
principalTable
── &
:
──& '
$str
──( 9
,
──9 :
principalColumn
┼┼ '
:
┼┼' (
$str
┼┼) -
,
┼┼- .
onDelete
╞╞  
:
╞╞  !
ReferentialAction
╞╞" 3
.
╞╞3 4
Cascade
╞╞4 ;
)
╞╞; <
;
╞╞< =
}
╟╟ 
)
╟╟ 
;
╟╟ 
migrationBuilder
╔╔ 
.
╔╔ 
CreateTable
╔╔ (
(
╔╔( )
name
╩╩ 
:
╩╩ 
$str
╩╩ '
,
╩╩' (
columns
╦╦ 
:
╦╦ 
table
╦╦ 
=>
╦╦ !
new
╦╦" %
{
╠╠ 
Id
══ 
=
══ 
table
══ 
.
══ 
Column
══ %
<
══% &
Guid
══& *
>
══* +
(
══+ ,
type
══, 0
:
══0 1
$str
══2 8
,
══8 9
nullable
══: B
:
══B C
false
══D I
)
══I J
,
══J K
DateTime
╬╬ 
=
╬╬ 
table
╬╬ $
.
╬╬$ %
Column
╬╬% +
<
╬╬+ ,
DateOnly
╬╬, 4
>
╬╬4 5
(
╬╬5 6
type
╬╬6 :
:
╬╬: ;
$str
╬╬< B
,
╬╬B C
nullable
╬╬D L
:
╬╬L M
false
╬╬N S
)
╬╬S T
,
╬╬T U

EmployeeId
╧╧ 
=
╧╧  
table
╧╧! &
.
╧╧& '
Column
╧╧' -
<
╧╧- .
Guid
╧╧. 2
>
╧╧2 3
(
╧╧3 4
type
╧╧4 8
:
╧╧8 9
$str
╧╧: @
,
╧╧@ A
nullable
╧╧B J
:
╧╧J K
true
╧╧L P
)
╧╧P Q
,
╧╧Q R
ShiftId
╨╨ 
=
╨╨ 
table
╨╨ #
.
╨╨# $
Column
╨╨$ *
<
╨╨* +
Guid
╨╨+ /
>
╨╨/ 0
(
╨╨0 1
type
╨╨1 5
:
╨╨5 6
$str
╨╨7 =
,
╨╨= >
nullable
╨╨? G
:
╨╨G H
false
╨╨I N
)
╨╨N O
,
╨╨O P
UserId
╤╤ 
=
╤╤ 
table
╤╤ "
.
╤╤" #
Column
╤╤# )
<
╤╤) *
string
╤╤* 0
>
╤╤0 1
(
╤╤1 2
type
╤╤2 6
:
╤╤6 7
$str
╤╤8 >
,
╤╤> ?
nullable
╤╤@ H
:
╤╤H I
true
╤╤J N
)
╤╤N O
,
╤╤O P
Created
╥╥ 
=
╥╥ 
table
╥╥ #
.
╥╥# $
Column
╥╥$ *
<
╥╥* +
DateTimeOffset
╥╥+ 9
>
╥╥9 :
(
╥╥: ;
type
╥╥; ?
:
╥╥? @
$str
╥╥A [
,
╥╥[ \
nullable
╥╥] e
:
╥╥e f
false
╥╥g l
)
╥╥l m
,
╥╥m n
	CreatedBy
╙╙ 
=
╙╙ 
table
╙╙  %
.
╙╙% &
Column
╙╙& ,
<
╙╙, -
string
╙╙- 3
>
╙╙3 4
(
╙╙4 5
type
╙╙5 9
:
╙╙9 :
$str
╙╙; A
,
╙╙A B
nullable
╙╙C K
:
╙╙K L
true
╙╙M Q
)
╙╙Q R
,
╙╙R S
LastModified
╘╘  
=
╘╘! "
table
╘╘# (
.
╘╘( )
Column
╘╘) /
<
╘╘/ 0
DateTimeOffset
╘╘0 >
>
╘╘> ?
(
╘╘? @
type
╘╘@ D
:
╘╘D E
$str
╘╘F `
,
╘╘` a
nullable
╘╘b j
:
╘╘j k
false
╘╘l q
)
╘╘q r
,
╘╘r s
LastModifiedBy
╒╒ "
=
╒╒# $
table
╒╒% *
.
╒╒* +
Column
╒╒+ 1
<
╒╒1 2
string
╒╒2 8
>
╒╒8 9
(
╒╒9 :
type
╒╒: >
:
╒╒> ?
$str
╒╒@ F
,
╒╒F G
nullable
╒╒H P
:
╒╒P Q
true
╒╒R V
)
╒╒V W
}
╓╓ 
,
╓╓ 
constraints
╫╫ 
:
╫╫ 
table
╫╫ "
=>
╫╫# %
{
╪╪ 
table
┘┘ 
.
┘┘ 

PrimaryKey
┘┘ $
(
┘┘$ %
$str
┘┘% 9
,
┘┘9 :
x
┘┘; <
=>
┘┘= ?
x
┘┘@ A
.
┘┘A B
Id
┘┘B D
)
┘┘D E
;
┘┘E F
table
┌┌ 
.
┌┌ 

ForeignKey
┌┌ $
(
┌┌$ %
name
██ 
:
██ 
$str
██ E
,
██E F
column
▄▄ 
:
▄▄ 
x
▄▄  !
=>
▄▄" $
x
▄▄% &
.
▄▄& '
UserId
▄▄' -
,
▄▄- .
principalTable
▌▌ &
:
▌▌& '
$str
▌▌( 5
,
▌▌5 6
principalColumn
▐▐ '
:
▐▐' (
$str
▐▐) -
)
▐▐- .
;
▐▐. /
table
▀▀ 
.
▀▀ 

ForeignKey
▀▀ $
(
▀▀$ %
name
рр 
:
рр 
$str
рр G
,
ррG H
column
сс 
:
сс 
x
сс  !
=>
сс" $
x
сс% &
.
сс& '

EmployeeId
сс' 1
,
сс1 2
principalTable
тт &
:
тт& '
$str
тт( 3
,
тт3 4
principalColumn
уу '
:
уу' (
$str
уу) -
)
уу- .
;
уу. /
table
фф 
.
фф 

ForeignKey
фф $
(
фф$ %
name
хх 
:
хх 
$str
хх A
,
ххA B
column
цц 
:
цц 
x
цц  !
=>
цц" $
x
цц% &
.
цц& '
ShiftId
цц' .
,
цц. /
principalTable
чч &
:
чч& '
$str
чч( 0
,
чч0 1
principalColumn
шш '
:
шш' (
$str
шш) -
,
шш- .
onDelete
щщ  
:
щщ  !
ReferentialAction
щщ" 3
.
щщ3 4
Cascade
щщ4 ;
)
щщ; <
;
щщ< =
}
ъъ 
)
ъъ 
;
ъъ 
migrationBuilder
ьь 
.
ьь 
CreateTable
ьь (
(
ьь( )
name
ээ 
:
ээ 
$str
ээ %
,
ээ% &
columns
юю 
:
юю 
table
юю 
=>
юю !
new
юю" %
{
яя 
Id
ЁЁ 
=
ЁЁ 
table
ЁЁ 
.
ЁЁ 
Column
ЁЁ %
<
ЁЁ% &
Guid
ЁЁ& *
>
ЁЁ* +
(
ЁЁ+ ,
type
ЁЁ, 0
:
ЁЁ0 1
$str
ЁЁ2 8
,
ЁЁ8 9
nullable
ЁЁ: B
:
ЁЁB C
false
ЁЁD I
)
ЁЁI J
,
ЁЁJ K
GroupChatId
ёё 
=
ёё  !
table
ёё" '
.
ёё' (
Column
ёё( .
<
ёё. /
Guid
ёё/ 3
>
ёё3 4
(
ёё4 5
type
ёё5 9
:
ёё9 :
$str
ёё; A
,
ёёA B
nullable
ёёC K
:
ёёK L
false
ёёM R
)
ёёR S
,
ёёS T
UserId
ЄЄ 
=
ЄЄ 
table
ЄЄ "
.
ЄЄ" #
Column
ЄЄ# )
<
ЄЄ) *
string
ЄЄ* 0
>
ЄЄ0 1
(
ЄЄ1 2
type
ЄЄ2 6
:
ЄЄ6 7
$str
ЄЄ8 >
,
ЄЄ> ?
nullable
ЄЄ@ H
:
ЄЄH I
false
ЄЄJ O
)
ЄЄO P
,
ЄЄP Q
Content
єє 
=
єє 
table
єє #
.
єє# $
Column
єє$ *
<
єє* +
string
єє+ 1
>
єє1 2
(
єє2 3
type
єє3 7
:
єє7 8
$str
єє9 ?
,
єє? @
nullable
єєA I
:
єєI J
false
єєK P
)
єєP Q
,
єєQ R
	CreatedAt
ЇЇ 
=
ЇЇ 
table
ЇЇ  %
.
ЇЇ% &
Column
ЇЇ& ,
<
ЇЇ, -
DateTime
ЇЇ- 5
>
ЇЇ5 6
(
ЇЇ6 7
type
ЇЇ7 ;
:
ЇЇ; <
$str
ЇЇ= W
,
ЇЇW X
nullable
ЇЇY a
:
ЇЇa b
false
ЇЇc h
)
ЇЇh i
,
ЇЇi j
Created
її 
=
її 
table
її #
.
її# $
Column
її$ *
<
її* +
DateTimeOffset
її+ 9
>
її9 :
(
її: ;
type
її; ?
:
її? @
$str
їїA [
,
її[ \
nullable
її] e
:
їїe f
false
їїg l
)
їїl m
,
їїm n
	CreatedBy
ЎЎ 
=
ЎЎ 
table
ЎЎ  %
.
ЎЎ% &
Column
ЎЎ& ,
<
ЎЎ, -
string
ЎЎ- 3
>
ЎЎ3 4
(
ЎЎ4 5
type
ЎЎ5 9
:
ЎЎ9 :
$str
ЎЎ; A
,
ЎЎA B
nullable
ЎЎC K
:
ЎЎK L
true
ЎЎM Q
)
ЎЎQ R
,
ЎЎR S
LastModified
ўў  
=
ўў! "
table
ўў# (
.
ўў( )
Column
ўў) /
<
ўў/ 0
DateTimeOffset
ўў0 >
>
ўў> ?
(
ўў? @
type
ўў@ D
:
ўўD E
$str
ўўF `
,
ўў` a
nullable
ўўb j
:
ўўj k
false
ўўl q
)
ўўq r
,
ўўr s
LastModifiedBy
°° "
=
°°# $
table
°°% *
.
°°* +
Column
°°+ 1
<
°°1 2
string
°°2 8
>
°°8 9
(
°°9 :
type
°°: >
:
°°> ?
$str
°°@ F
,
°°F G
nullable
°°H P
:
°°P Q
true
°°R V
)
°°V W
}
∙∙ 
,
∙∙ 
constraints
·· 
:
·· 
table
·· "
=>
··# %
{
√√ 
table
№№ 
.
№№ 

PrimaryKey
№№ $
(
№№$ %
$str
№№% 7
,
№№7 8
x
№№9 :
=>
№№; =
x
№№> ?
.
№№? @
Id
№№@ B
)
№№B C
;
№№C D
table
¤¤ 
.
¤¤ 

ForeignKey
¤¤ $
(
¤¤$ %
name
■■ 
:
■■ 
$str
■■ C
,
■■C D
column
   
:
   
x
    !
=>
  " $
x
  % &
.
  & '
UserId
  ' -
,
  - .
principalTable
АА &
:
АА& '
$str
АА( 5
,
АА5 6
principalColumn
ББ '
:
ББ' (
$str
ББ) -
,
ББ- .
onDelete
ВВ  
:
ВВ  !
ReferentialAction
ВВ" 3
.
ВВ3 4
Cascade
ВВ4 ;
)
ВВ; <
;
ВВ< =
table
ГГ 
.
ГГ 

ForeignKey
ГГ $
(
ГГ$ %
name
ДД 
:
ДД 
$str
ДД G
,
ДДG H
column
ЕЕ 
:
ЕЕ 
x
ЕЕ  !
=>
ЕЕ" $
x
ЕЕ% &
.
ЕЕ& '
GroupChatId
ЕЕ' 2
,
ЕЕ2 3
principalTable
ЖЖ &
:
ЖЖ& '
$str
ЖЖ( 4
,
ЖЖ4 5
principalColumn
ЗЗ '
:
ЗЗ' (
$str
ЗЗ) -
,
ЗЗ- .
onDelete
ИИ  
:
ИИ  !
ReferentialAction
ИИ" 3
.
ИИ3 4
Cascade
ИИ4 ;
)
ИИ; <
;
ИИ< =
}
ЙЙ 
)
ЙЙ 
;
ЙЙ 
migrationBuilder
ЛЛ 
.
ЛЛ 
CreateTable
ЛЛ (
(
ЛЛ( )
name
ММ 
:
ММ 
$str
ММ "
,
ММ" #
columns
НН 
:
НН 
table
НН 
=>
НН !
new
НН" %
{
ОО 
Id
ПП 
=
ПП 
table
ПП 
.
ПП 
Column
ПП %
<
ПП% &
Guid
ПП& *
>
ПП* +
(
ПП+ ,
type
ПП, 0
:
ПП0 1
$str
ПП2 8
,
ПП8 9
nullable
ПП: B
:
ППB C
false
ППD I
)
ППI J
,
ППJ K
GroupChatId
РР 
=
РР  !
table
РР" '
.
РР' (
Column
РР( .
<
РР. /
Guid
РР/ 3
>
РР3 4
(
РР4 5
type
РР5 9
:
РР9 :
$str
РР; A
,
РРA B
nullable
РРC K
:
РРK L
false
РРM R
)
РРR S
,
РРS T
UserId
СС 
=
СС 
table
СС "
.
СС" #
Column
СС# )
<
СС) *
string
СС* 0
>
СС0 1
(
СС1 2
type
СС2 6
:
СС6 7
$str
СС8 >
,
СС> ?
nullable
СС@ H
:
ССH I
false
ССJ O
)
ССO P
,
ССP Q
Created
ТТ 
=
ТТ 
table
ТТ #
.
ТТ# $
Column
ТТ$ *
<
ТТ* +
DateTimeOffset
ТТ+ 9
>
ТТ9 :
(
ТТ: ;
type
ТТ; ?
:
ТТ? @
$str
ТТA [
,
ТТ[ \
nullable
ТТ] e
:
ТТe f
false
ТТg l
)
ТТl m
,
ТТm n
	CreatedBy
УУ 
=
УУ 
table
УУ  %
.
УУ% &
Column
УУ& ,
<
УУ, -
string
УУ- 3
>
УУ3 4
(
УУ4 5
type
УУ5 9
:
УУ9 :
$str
УУ; A
,
УУA B
nullable
УУC K
:
УУK L
true
УУM Q
)
УУQ R
,
УУR S
LastModified
ФФ  
=
ФФ! "
table
ФФ# (
.
ФФ( )
Column
ФФ) /
<
ФФ/ 0
DateTimeOffset
ФФ0 >
>
ФФ> ?
(
ФФ? @
type
ФФ@ D
:
ФФD E
$str
ФФF `
,
ФФ` a
nullable
ФФb j
:
ФФj k
false
ФФl q
)
ФФq r
,
ФФr s
LastModifiedBy
ХХ "
=
ХХ# $
table
ХХ% *
.
ХХ* +
Column
ХХ+ 1
<
ХХ1 2
string
ХХ2 8
>
ХХ8 9
(
ХХ9 :
type
ХХ: >
:
ХХ> ?
$str
ХХ@ F
,
ХХF G
nullable
ХХH P
:
ХХP Q
true
ХХR V
)
ХХV W
}
ЦЦ 
,
ЦЦ 
constraints
ЧЧ 
:
ЧЧ 
table
ЧЧ "
=>
ЧЧ# %
{
ШШ 
table
ЩЩ 
.
ЩЩ 

PrimaryKey
ЩЩ $
(
ЩЩ$ %
$str
ЩЩ% 4
,
ЩЩ4 5
x
ЩЩ6 7
=>
ЩЩ8 :
x
ЩЩ; <
.
ЩЩ< =
Id
ЩЩ= ?
)
ЩЩ? @
;
ЩЩ@ A
table
ЪЪ 
.
ЪЪ 

ForeignKey
ЪЪ $
(
ЪЪ$ %
name
ЫЫ 
:
ЫЫ 
$str
ЫЫ @
,
ЫЫ@ A
column
ЬЬ 
:
ЬЬ 
x
ЬЬ  !
=>
ЬЬ" $
x
ЬЬ% &
.
ЬЬ& '
UserId
ЬЬ' -
,
ЬЬ- .
principalTable
ЭЭ &
:
ЭЭ& '
$str
ЭЭ( 5
,
ЭЭ5 6
principalColumn
ЮЮ '
:
ЮЮ' (
$str
ЮЮ) -
,
ЮЮ- .
onDelete
ЯЯ  
:
ЯЯ  !
ReferentialAction
ЯЯ" 3
.
ЯЯ3 4
Cascade
ЯЯ4 ;
)
ЯЯ; <
;
ЯЯ< =
table
аа 
.
аа 

ForeignKey
аа $
(
аа$ %
name
бб 
:
бб 
$str
бб D
,
ббD E
column
вв 
:
вв 
x
вв  !
=>
вв" $
x
вв% &
.
вв& '
GroupChatId
вв' 2
,
вв2 3
principalTable
гг &
:
гг& '
$str
гг( 4
,
гг4 5
principalColumn
дд '
:
дд' (
$str
дд) -
,
дд- .
onDelete
ее  
:
ее  !
ReferentialAction
ее" 3
.
ее3 4
Cascade
ее4 ;
)
ее; <
;
ее< =
}
жж 
)
жж 
;
жж 
migrationBuilder
ии 
.
ии 
CreateTable
ии (
(
ии( )
name
йй 
:
йй 
$str
йй &
,
йй& '
columns
кк 
:
кк 
table
кк 
=>
кк !
new
кк" %
{
лл 
Id
мм 
=
мм 
table
мм 
.
мм 
Column
мм %
<
мм% &
Guid
мм& *
>
мм* +
(
мм+ ,
type
мм, 0
:
мм0 1
$str
мм2 8
,
мм8 9
nullable
мм: B
:
ммB C
false
ммD I
)
ммI J
,
ммJ K
IngredientId
нн  
=
нн! "
table
нн# (
.
нн( )
Column
нн) /
<
нн/ 0
Guid
нн0 4
>
нн4 5
(
нн5 6
type
нн6 :
:
нн: ;
$str
нн< B
,
ннB C
nullable
ннD L
:
ннL M
false
ннN S
)
ннS T
,
ннT U
UnitName
оо 
=
оо 
table
оо $
.
оо$ %
Column
оо% +
<
оо+ ,
string
оо, 2
>
оо2 3
(
оо3 4
type
оо4 8
:
оо8 9
$str
оо: @
,
оо@ A
nullable
ооB J
:
ооJ K
false
ооL Q
)
ооQ R
,
ооR S
ConversionFactor
пп $
=
пп% &
table
пп' ,
.
пп, -
Column
пп- 3
<
пп3 4
decimal
пп4 ;
>
пп; <
(
пп< =
type
пп= A
:
ппA B
$str
ппC L
,
ппL M
nullable
ппN V
:
ппV W
false
ппX ]
)
пп] ^
,
пп^ _$
IngredientUnitParentId
░░ *
=
░░+ ,
table
░░- 2
.
░░2 3
Column
░░3 9
<
░░9 :
Guid
░░: >
>
░░> ?
(
░░? @
type
░░@ D
:
░░D E
$str
░░F L
,
░░L M
nullable
░░N V
:
░░V W
true
░░X \
)
░░\ ]
,
░░] ^
Created
▒▒ 
=
▒▒ 
table
▒▒ #
.
▒▒# $
Column
▒▒$ *
<
▒▒* +
DateTimeOffset
▒▒+ 9
>
▒▒9 :
(
▒▒: ;
type
▒▒; ?
:
▒▒? @
$str
▒▒A [
,
▒▒[ \
nullable
▒▒] e
:
▒▒e f
false
▒▒g l
)
▒▒l m
,
▒▒m n
	CreatedBy
▓▓ 
=
▓▓ 
table
▓▓  %
.
▓▓% &
Column
▓▓& ,
<
▓▓, -
string
▓▓- 3
>
▓▓3 4
(
▓▓4 5
type
▓▓5 9
:
▓▓9 :
$str
▓▓; A
,
▓▓A B
nullable
▓▓C K
:
▓▓K L
true
▓▓M Q
)
▓▓Q R
,
▓▓R S
LastModified
││  
=
││! "
table
││# (
.
││( )
Column
││) /
<
││/ 0
DateTimeOffset
││0 >
>
││> ?
(
││? @
type
││@ D
:
││D E
$str
││F `
,
││` a
nullable
││b j
:
││j k
false
││l q
)
││q r
,
││r s
LastModifiedBy
┤┤ "
=
┤┤# $
table
┤┤% *
.
┤┤* +
Column
┤┤+ 1
<
┤┤1 2
string
┤┤2 8
>
┤┤8 9
(
┤┤9 :
type
┤┤: >
:
┤┤> ?
$str
┤┤@ F
,
┤┤F G
nullable
┤┤H P
:
┤┤P Q
true
┤┤R V
)
┤┤V W
}
╡╡ 
,
╡╡ 
constraints
╢╢ 
:
╢╢ 
table
╢╢ "
=>
╢╢# %
{
╖╖ 
table
╕╕ 
.
╕╕ 

PrimaryKey
╕╕ $
(
╕╕$ %
$str
╕╕% 8
,
╕╕8 9
x
╕╕: ;
=>
╕╕< >
x
╕╕? @
.
╕╕@ A
Id
╕╕A C
)
╕╕C D
;
╕╕D E
table
╣╣ 
.
╣╣ 

ForeignKey
╣╣ $
(
╣╣$ %
name
║║ 
:
║║ 
$str
║║ W
,
║║W X
column
╗╗ 
:
╗╗ 
x
╗╗  !
=>
╗╗" $
x
╗╗% &
.
╗╗& '$
IngredientUnitParentId
╗╗' =
,
╗╗= >
principalTable
╝╝ &
:
╝╝& '
$str
╝╝( 8
,
╝╝8 9
principalColumn
╜╜ '
:
╜╜' (
$str
╜╜) -
)
╜╜- .
;
╜╜. /
table
╛╛ 
.
╛╛ 

ForeignKey
╛╛ $
(
╛╛$ %
name
┐┐ 
:
┐┐ 
$str
┐┐ J
,
┐┐J K
column
└└ 
:
└└ 
x
└└  !
=>
└└" $
x
└└% &
.
└└& '
IngredientId
└└' 3
,
└└3 4
principalTable
┴┴ &
:
┴┴& '
$str
┴┴( 5
,
┴┴5 6
principalColumn
┬┬ '
:
┬┬' (
$str
┬┬) -
,
┬┬- .
onDelete
├├  
:
├├  !
ReferentialAction
├├" 3
.
├├3 4
Cascade
├├4 ;
)
├├; <
;
├├< =
}
── 
)
── 
;
── 
migrationBuilder
╞╞ 
.
╞╞ 
CreateTable
╞╞ (
(
╞╞( )
name
╟╟ 
:
╟╟ 
$str
╟╟ 
,
╟╟ 
columns
╚╚ 
:
╚╚ 
table
╚╚ 
=>
╚╚ !
new
╚╚" %
{
╔╔ 
Id
╩╩ 
=
╩╩ 
table
╩╩ 
.
╩╩ 
Column
╩╩ %
<
╩╩% &
Guid
╩╩& *
>
╩╩* +
(
╩╩+ ,
type
╩╩, 0
:
╩╩0 1
$str
╩╩2 8
,
╩╩8 9
nullable
╩╩: B
:
╩╩B C
false
╩╩D I
)
╩╩I J
,
╩╩J K
OrderStatus
╦╦ 
=
╦╦  !
table
╦╦" '
.
╦╦' (
Column
╦╦( .
<
╦╦. /
byte
╦╦/ 3
>
╦╦3 4
(
╦╦4 5
type
╦╦5 9
:
╦╦9 :
$str
╦╦; E
,
╦╦E F
nullable
╦╦G O
:
╦╦O P
true
╦╦Q U
)
╦╦U V
,
╦╦V W
	OrderType
╠╠ 
=
╠╠ 
table
╠╠  %
.
╠╠% &
Column
╠╠& ,
<
╠╠, -
byte
╠╠- 1
>
╠╠1 2
(
╠╠2 3
type
╠╠3 7
:
╠╠7 8
$str
╠╠9 C
,
╠╠C D
nullable
╠╠E M
:
╠╠M N
true
╠╠O S
)
╠╠S T
,
╠╠T U
	OrderTime
══ 
=
══ 
table
══  %
.
══% &
Column
══& ,
<
══, -
DateTime
══- 5
>
══5 6
(
══6 7
type
══7 ;
:
══; <
$str
══= W
,
══W X
nullable
══Y a
:
══a b
true
══c g
)
══g h
,
══h i

TotalPrice
╬╬ 
=
╬╬  
table
╬╬! &
.
╬╬& '
Column
╬╬' -
<
╬╬- .
decimal
╬╬. 5
>
╬╬5 6
(
╬╬6 7
type
╬╬7 ;
:
╬╬; <
$str
╬╬= F
,
╬╬F G
nullable
╬╬H P
:
╬╬P Q
false
╬╬R W
)
╬╬W X
,
╬╬X Y
TableId
╧╧ 
=
╧╧ 
table
╧╧ #
.
╧╧# $
Column
╧╧$ *
<
╧╧* +
Guid
╧╧+ /
>
╧╧/ 0
(
╧╧0 1
type
╧╧1 5
:
╧╧5 6
$str
╧╧7 =
,
╧╧= >
nullable
╧╧? G
:
╧╧G H
false
╧╧I N
)
╧╧N O
,
╧╧O P
Created
╨╨ 
=
╨╨ 
table
╨╨ #
.
╨╨# $
Column
╨╨$ *
<
╨╨* +
DateTimeOffset
╨╨+ 9
>
╨╨9 :
(
╨╨: ;
type
╨╨; ?
:
╨╨? @
$str
╨╨A [
,
╨╨[ \
nullable
╨╨] e
:
╨╨e f
false
╨╨g l
)
╨╨l m
,
╨╨m n
	CreatedBy
╤╤ 
=
╤╤ 
table
╤╤  %
.
╤╤% &
Column
╤╤& ,
<
╤╤, -
string
╤╤- 3
>
╤╤3 4
(
╤╤4 5
type
╤╤5 9
:
╤╤9 :
$str
╤╤; A
,
╤╤A B
nullable
╤╤C K
:
╤╤K L
true
╤╤M Q
)
╤╤Q R
,
╤╤R S
LastModified
╥╥  
=
╥╥! "
table
╥╥# (
.
╥╥( )
Column
╥╥) /
<
╥╥/ 0
DateTimeOffset
╥╥0 >
>
╥╥> ?
(
╥╥? @
type
╥╥@ D
:
╥╥D E
$str
╥╥F `
,
╥╥` a
nullable
╥╥b j
:
╥╥j k
false
╥╥l q
)
╥╥q r
,
╥╥r s
LastModifiedBy
╙╙ "
=
╙╙# $
table
╙╙% *
.
╙╙* +
Column
╙╙+ 1
<
╙╙1 2
string
╙╙2 8
>
╙╙8 9
(
╙╙9 :
type
╙╙: >
:
╙╙> ?
$str
╙╙@ F
,
╙╙F G
nullable
╙╙H P
:
╙╙P Q
true
╙╙R V
)
╙╙V W
}
╘╘ 
,
╘╘ 
constraints
╒╒ 
:
╒╒ 
table
╒╒ "
=>
╒╒# %
{
╓╓ 
table
╫╫ 
.
╫╫ 

PrimaryKey
╫╫ $
(
╫╫$ %
$str
╫╫% 0
,
╫╫0 1
x
╫╫2 3
=>
╫╫4 6
x
╫╫7 8
.
╫╫8 9
Id
╫╫9 ;
)
╫╫; <
;
╫╫< =
table
╪╪ 
.
╪╪ 

ForeignKey
╪╪ $
(
╪╪$ %
name
┘┘ 
:
┘┘ 
$str
┘┘ 8
,
┘┘8 9
column
┌┌ 
:
┌┌ 
x
┌┌  !
=>
┌┌" $
x
┌┌% &
.
┌┌& '
TableId
┌┌' .
,
┌┌. /
principalTable
██ &
:
██& '
$str
██( 0
,
██0 1
principalColumn
▄▄ '
:
▄▄' (
$str
▄▄) -
,
▄▄- .
onDelete
▌▌  
:
▌▌  !
ReferentialAction
▌▌" 3
.
▌▌3 4
Cascade
▌▌4 ;
)
▌▌; <
;
▌▌< =
}
▐▐ 
)
▐▐ 
;
▐▐ 
migrationBuilder
рр 
.
рр 
CreateTable
рр (
(
рр( )
name
сс 
:
сс 
$str
сс /
,
сс/ 0
columns
тт 
:
тт 
table
тт 
=>
тт !
new
тт" %
{
уу 
Id
фф 
=
фф 
table
фф 
.
фф 
Column
фф %
<
фф% &
Guid
фф& *
>
фф* +
(
фф+ ,
type
фф, 0
:
фф0 1
$str
фф2 8
,
фф8 9
nullable
фф: B
:
ффB C
false
ффD I
)
ффI J
,
ффJ K
Note
хх 
=
хх 
table
хх  
.
хх  !
Column
хх! '
<
хх' (
string
хх( .
>
хх. /
(
хх/ 0
type
хх0 4
:
хх4 5
$str
хх6 <
,
хх< =
nullable
хх> F
:
ххF G
false
ххH M
)
ххM N
,
ххN O#
NewProductRecommendId
цц )
=
цц* +
table
цц, 1
.
цц1 2
Column
цц2 8
<
цц8 9
Guid
цц9 =
>
цц= >
(
цц> ?
type
цц? C
:
ццC D
$str
ццE K
,
ццK L
nullable
ццM U
:
ццU V
false
ццW \
)
цц\ ]
,
цц] ^
LogDate
чч 
=
чч 
table
чч #
.
чч# $
Column
чч$ *
<
чч* +
DateTimeOffset
чч+ 9
>
чч9 :
(
чч: ;
type
чч; ?
:
чч? @
$str
ччA [
,
чч[ \
nullable
чч] e
:
ччe f
false
ччg l
)
ччl m
,
ччm n
LogType
шш 
=
шш 
table
шш #
.
шш# $
Column
шш$ *
<
шш* +
byte
шш+ /
>
шш/ 0
(
шш0 1
type
шш1 5
:
шш5 6
$str
шш7 A
,
шшA B
nullable
шшC K
:
шшK L
false
шшM R
)
шшR S
,
шшS T*
NewProductRecommendLogStatus
щщ 0
=
щщ1 2
table
щщ3 8
.
щщ8 9
Column
щщ9 ?
<
щщ? @
byte
щщ@ D
>
щщD E
(
щщE F
type
щщF J
:
щщJ K
$str
щщL V
,
щщV W
nullable
щщX `
:
щщ` a
false
щщb g
)
щщg h
,
щщh i
UserId
ъъ 
=
ъъ 
table
ъъ "
.
ъъ" #
Column
ъъ# )
<
ъъ) *
string
ъъ* 0
>
ъъ0 1
(
ъъ1 2
type
ъъ2 6
:
ъъ6 7
$str
ъъ8 >
,
ъъ> ?
nullable
ъъ@ H
:
ъъH I
false
ъъJ O
)
ъъO P
,
ъъP Q
Created
ыы 
=
ыы 
table
ыы #
.
ыы# $
Column
ыы$ *
<
ыы* +
DateTimeOffset
ыы+ 9
>
ыы9 :
(
ыы: ;
type
ыы; ?
:
ыы? @
$str
ыыA [
,
ыы[ \
nullable
ыы] e
:
ыыe f
false
ыыg l
)
ыыl m
,
ыыm n
	CreatedBy
ьь 
=
ьь 
table
ьь  %
.
ьь% &
Column
ьь& ,
<
ьь, -
string
ьь- 3
>
ьь3 4
(
ьь4 5
type
ьь5 9
:
ьь9 :
$str
ьь; A
,
ььA B
nullable
ььC K
:
ььK L
true
ььM Q
)
ььQ R
,
ььR S
LastModified
ээ  
=
ээ! "
table
ээ# (
.
ээ( )
Column
ээ) /
<
ээ/ 0
DateTimeOffset
ээ0 >
>
ээ> ?
(
ээ? @
type
ээ@ D
:
ээD E
$str
ээF `
,
ээ` a
nullable
ээb j
:
ээj k
false
ээl q
)
ээq r
,
ээr s
LastModifiedBy
юю "
=
юю# $
table
юю% *
.
юю* +
Column
юю+ 1
<
юю1 2
string
юю2 8
>
юю8 9
(
юю9 :
type
юю: >
:
юю> ?
$str
юю@ F
,
ююF G
nullable
ююH P
:
ююP Q
true
ююR V
)
ююV W
}
яя 
,
яя 
constraints
ЁЁ 
:
ЁЁ 
table
ЁЁ "
=>
ЁЁ# %
{
ёё 
table
ЄЄ 
.
ЄЄ 

PrimaryKey
ЄЄ $
(
ЄЄ$ %
$str
ЄЄ% A
,
ЄЄA B
x
ЄЄC D
=>
ЄЄE G
x
ЄЄH I
.
ЄЄI J
Id
ЄЄJ L
)
ЄЄL M
;
ЄЄM N
table
єє 
.
єє 

ForeignKey
єє $
(
єє$ %
name
ЇЇ 
:
ЇЇ 
$str
ЇЇ M
,
ЇЇM N
column
її 
:
її 
x
її  !
=>
її" $
x
її% &
.
її& '
UserId
її' -
,
її- .
principalTable
ЎЎ &
:
ЎЎ& '
$str
ЎЎ( 5
,
ЎЎ5 6
principalColumn
ўў '
:
ўў' (
$str
ўў) -
,
ўў- .
onDelete
°°  
:
°°  !
ReferentialAction
°°" 3
.
°°3 4
Cascade
°°4 ;
)
°°; <
;
°°< =
table
∙∙ 
.
∙∙ 

ForeignKey
∙∙ $
(
∙∙$ %
name
·· 
:
·· 
$str
·· _
,
··_ `
column
√√ 
:
√√ 
x
√√  !
=>
√√" $
x
√√% &
.
√√& '#
NewProductRecommendId
√√' <
,
√√< =
principalTable
№№ &
:
№№& '
$str
№№( >
,
№№> ?
principalColumn
¤¤ '
:
¤¤' (
$str
¤¤) -
,
¤¤- .
onDelete
■■  
:
■■  !
ReferentialAction
■■" 3
.
■■3 4
Cascade
■■4 ;
)
■■; <
;
■■< =
}
   
)
   
;
   
migrationBuilder
ББ 
.
ББ 
CreateTable
ББ (
(
ББ( )
name
ВВ 
:
ВВ 
$str
ВВ %
,
ВВ% &
columns
ГГ 
:
ГГ 
table
ГГ 
=>
ГГ !
new
ГГ" %
{
ДД 
Id
ЕЕ 
=
ЕЕ 
table
ЕЕ 
.
ЕЕ 
Column
ЕЕ %
<
ЕЕ% &
Guid
ЕЕ& *
>
ЕЕ* +
(
ЕЕ+ ,
type
ЕЕ, 0
:
ЕЕ0 1
$str
ЕЕ2 8
,
ЕЕ8 9
nullable
ЕЕ: B
:
ЕЕB C
false
ЕЕD I
)
ЕЕI J
,
ЕЕJ K
ComboId
ЖЖ 
=
ЖЖ 
table
ЖЖ #
.
ЖЖ# $
Column
ЖЖ$ *
<
ЖЖ* +
Guid
ЖЖ+ /
>
ЖЖ/ 0
(
ЖЖ0 1
type
ЖЖ1 5
:
ЖЖ5 6
$str
ЖЖ7 =
,
ЖЖ= >
nullable
ЖЖ? G
:
ЖЖG H
false
ЖЖI N
)
ЖЖN O
,
ЖЖO P
	ProductId
ЗЗ 
=
ЗЗ 
table
ЗЗ  %
.
ЗЗ% &
Column
ЗЗ& ,
<
ЗЗ, -
Guid
ЗЗ- 1
>
ЗЗ1 2
(
ЗЗ2 3
type
ЗЗ3 7
:
ЗЗ7 8
$str
ЗЗ9 ?
,
ЗЗ? @
nullable
ЗЗA I
:
ЗЗI J
false
ЗЗK P
)
ЗЗP Q
,
ЗЗQ R
	IsDeleted
ИИ 
=
ИИ 
table
ИИ  %
.
ИИ% &
Column
ИИ& ,
<
ИИ, -
bool
ИИ- 1
>
ИИ1 2
(
ИИ2 3
type
ИИ3 7
:
ИИ7 8
$str
ИИ9 B
,
ИИB C
nullable
ИИD L
:
ИИL M
false
ИИN S
)
ИИS T
,
ИИT U
Created
ЙЙ 
=
ЙЙ 
table
ЙЙ #
.
ЙЙ# $
Column
ЙЙ$ *
<
ЙЙ* +
DateTimeOffset
ЙЙ+ 9
>
ЙЙ9 :
(
ЙЙ: ;
type
ЙЙ; ?
:
ЙЙ? @
$str
ЙЙA [
,
ЙЙ[ \
nullable
ЙЙ] e
:
ЙЙe f
false
ЙЙg l
)
ЙЙl m
,
ЙЙm n
	CreatedBy
КК 
=
КК 
table
КК  %
.
КК% &
Column
КК& ,
<
КК, -
string
КК- 3
>
КК3 4
(
КК4 5
type
КК5 9
:
КК9 :
$str
КК; A
,
ККA B
nullable
ККC K
:
ККK L
true
ККM Q
)
ККQ R
,
ККR S
LastModified
ЛЛ  
=
ЛЛ! "
table
ЛЛ# (
.
ЛЛ( )
Column
ЛЛ) /
<
ЛЛ/ 0
DateTimeOffset
ЛЛ0 >
>
ЛЛ> ?
(
ЛЛ? @
type
ЛЛ@ D
:
ЛЛD E
$str
ЛЛF `
,
ЛЛ` a
nullable
ЛЛb j
:
ЛЛj k
false
ЛЛl q
)
ЛЛq r
,
ЛЛr s
LastModifiedBy
ММ "
=
ММ# $
table
ММ% *
.
ММ* +
Column
ММ+ 1
<
ММ1 2
string
ММ2 8
>
ММ8 9
(
ММ9 :
type
ММ: >
:
ММ> ?
$str
ММ@ F
,
ММF G
nullable
ММH P
:
ММP Q
true
ММR V
)
ММV W
}
НН 
,
НН 
constraints
ОО 
:
ОО 
table
ОО "
=>
ОО# %
{
ПП 
table
РР 
.
РР 

PrimaryKey
РР $
(
РР$ %
$str
РР% 7
,
РР7 8
x
РР9 :
=>
РР; =
x
РР> ?
.
РР? @
Id
РР@ B
)
РРB C
;
РРC D
table
СС 
.
СС 

ForeignKey
СС $
(
СС$ %
name
ТТ 
:
ТТ 
$str
ТТ ?
,
ТТ? @
column
УУ 
:
УУ 
x
УУ  !
=>
УУ" $
x
УУ% &
.
УУ& '
ComboId
УУ' .
,
УУ. /
principalTable
ФФ &
:
ФФ& '
$str
ФФ( 0
,
ФФ0 1
principalColumn
ХХ '
:
ХХ' (
$str
ХХ) -
,
ХХ- .
onDelete
ЦЦ  
:
ЦЦ  !
ReferentialAction
ЦЦ" 3
.
ЦЦ3 4
Cascade
ЦЦ4 ;
)
ЦЦ; <
;
ЦЦ< =
table
ЧЧ 
.
ЧЧ 

ForeignKey
ЧЧ $
(
ЧЧ$ %
name
ШШ 
:
ШШ 
$str
ШШ C
,
ШШC D
column
ЩЩ 
:
ЩЩ 
x
ЩЩ  !
=>
ЩЩ" $
x
ЩЩ% &
.
ЩЩ& '
	ProductId
ЩЩ' 0
,
ЩЩ0 1
principalTable
ЪЪ &
:
ЪЪ& '
$str
ЪЪ( 2
,
ЪЪ2 3
principalColumn
ЫЫ '
:
ЫЫ' (
$str
ЫЫ) -
,
ЫЫ- .
onDelete
ЬЬ  
:
ЬЬ  !
ReferentialAction
ЬЬ" 3
.
ЬЬ3 4
Cascade
ЬЬ4 ;
)
ЬЬ; <
;
ЬЬ< =
}
ЭЭ 
)
ЭЭ 
;
ЭЭ 
migrationBuilder
ЯЯ 
.
ЯЯ 
CreateTable
ЯЯ (
(
ЯЯ( )
name
аа 
:
аа 
$str
аа %
,
аа% &
columns
бб 
:
бб 
table
бб 
=>
бб !
new
бб" %
{
вв 
Id
гг 
=
гг 
table
гг 
.
гг 
Column
гг %
<
гг% &
Guid
гг& *
>
гг* +
(
гг+ ,
type
гг, 0
:
гг0 1
$str
гг2 8
,
гг8 9
nullable
гг: B
:
ггB C
false
ггD I
)
ггI J
,
ггJ K
ImageUrl
дд 
=
дд 
table
дд $
.
дд$ %
Column
дд% +
<
дд+ ,
string
дд, 2
>
дд2 3
(
дд3 4
type
дд4 8
:
дд8 9
$str
дд: @
,
дд@ A
nullable
ддB J
:
ддJ K
false
ддL Q
)
ддQ R
,
ддR S
IsMain
ее 
=
ее 
table
ее "
.
ее" #
Column
ее# )
<
ее) *
bool
ее* .
>
ее. /
(
ее/ 0
type
ее0 4
:
ее4 5
$str
ее6 ?
,
ее? @
nullable
ееA I
:
ееI J
false
ееK P
)
ееP Q
,
ееQ R
	ProductId
жж 
=
жж 
table
жж  %
.
жж% &
Column
жж& ,
<
жж, -
Guid
жж- 1
>
жж1 2
(
жж2 3
type
жж3 7
:
жж7 8
$str
жж9 ?
,
жж? @
nullable
жжA I
:
жжI J
false
жжK P
)
жжP Q
,
жжQ R
Created
зз 
=
зз 
table
зз #
.
зз# $
Column
зз$ *
<
зз* +
DateTimeOffset
зз+ 9
>
зз9 :
(
зз: ;
type
зз; ?
:
зз? @
$str
ззA [
,
зз[ \
nullable
зз] e
:
ззe f
false
ззg l
)
ззl m
,
ззm n
	CreatedBy
ии 
=
ии 
table
ии  %
.
ии% &
Column
ии& ,
<
ии, -
string
ии- 3
>
ии3 4
(
ии4 5
type
ии5 9
:
ии9 :
$str
ии; A
,
ииA B
nullable
ииC K
:
ииK L
true
ииM Q
)
ииQ R
,
ииR S
LastModified
йй  
=
йй! "
table
йй# (
.
йй( )
Column
йй) /
<
йй/ 0
DateTimeOffset
йй0 >
>
йй> ?
(
йй? @
type
йй@ D
:
ййD E
$str
ййF `
,
йй` a
nullable
ййb j
:
ййj k
false
ййl q
)
ййq r
,
ййr s
LastModifiedBy
кк "
=
кк# $
table
кк% *
.
кк* +
Column
кк+ 1
<
кк1 2
string
кк2 8
>
кк8 9
(
кк9 :
type
кк: >
:
кк> ?
$str
кк@ F
,
ккF G
nullable
ккH P
:
ккP Q
true
ккR V
)
ккV W
}
лл 
,
лл 
constraints
мм 
:
мм 
table
мм "
=>
мм# %
{
нн 
table
оо 
.
оо 

PrimaryKey
оо $
(
оо$ %
$str
оо% 7
,
оо7 8
x
оо9 :
=>
оо; =
x
оо> ?
.
оо? @
Id
оо@ B
)
ооB C
;
ооC D
table
пп 
.
пп 

ForeignKey
пп $
(
пп$ %
name
░░ 
:
░░ 
$str
░░ C
,
░░C D
column
▒▒ 
:
▒▒ 
x
▒▒  !
=>
▒▒" $
x
▒▒% &
.
▒▒& '
	ProductId
▒▒' 0
,
▒▒0 1
principalTable
▓▓ &
:
▓▓& '
$str
▓▓( 2
,
▓▓2 3
principalColumn
││ '
:
││' (
$str
││) -
,
││- .
onDelete
┤┤  
:
┤┤  !
ReferentialAction
┤┤" 3
.
┤┤3 4
Cascade
┤┤4 ;
)
┤┤; <
;
┤┤< =
}
╡╡ 
)
╡╡ 
;
╡╡ 
migrationBuilder
╖╖ 
.
╖╖ 
CreateTable
╖╖ (
(
╖╖( )
name
╕╕ 
:
╕╕ 
$str
╕╕ *
,
╕╕* +
columns
╣╣ 
:
╣╣ 
table
╣╣ 
=>
╣╣ !
new
╣╣" %
{
║║ 
Id
╗╗ 
=
╗╗ 
table
╗╗ 
.
╗╗ 
Column
╗╗ %
<
╗╗% &
Guid
╗╗& *
>
╗╗* +
(
╗╗+ ,
type
╗╗, 0
:
╗╗0 1
$str
╗╗2 8
,
╗╗8 9
nullable
╗╗: B
:
╗╗B C
false
╗╗D I
)
╗╗I J
,
╗╗J K
	ProductId
╝╝ 
=
╝╝ 
table
╝╝  %
.
╝╝% &
Column
╝╝& ,
<
╝╝, -
Guid
╝╝- 1
>
╝╝1 2
(
╝╝2 3
type
╝╝3 7
:
╝╝7 8
$str
╝╝9 ?
,
╝╝? @
nullable
╝╝A I
:
╝╝I J
false
╝╝K P
)
╝╝P Q
,
╝╝Q R
Quantity
╜╜ 
=
╜╜ 
table
╜╜ $
.
╜╜$ %
Column
╜╜% +
<
╜╜+ ,
decimal
╜╜, 3
>
╜╜3 4
(
╜╜4 5
type
╜╜5 9
:
╜╜9 :
$str
╜╜; D
,
╜╜D E
nullable
╜╜F N
:
╜╜N O
false
╜╜P U
)
╜╜U V
,
╜╜V W
IngredientId
╛╛  
=
╛╛! "
table
╛╛# (
.
╛╛( )
Column
╛╛) /
<
╛╛/ 0
Guid
╛╛0 4
>
╛╛4 5
(
╛╛5 6
type
╛╛6 :
:
╛╛: ;
$str
╛╛< B
,
╛╛B C
nullable
╛╛D L
:
╛╛L M
false
╛╛N S
)
╛╛S T
,
╛╛T U
Created
┐┐ 
=
┐┐ 
table
┐┐ #
.
┐┐# $
Column
┐┐$ *
<
┐┐* +
DateTimeOffset
┐┐+ 9
>
┐┐9 :
(
┐┐: ;
type
┐┐; ?
:
┐┐? @
$str
┐┐A [
,
┐┐[ \
nullable
┐┐] e
:
┐┐e f
false
┐┐g l
)
┐┐l m
,
┐┐m n
	CreatedBy
└└ 
=
└└ 
table
└└  %
.
└└% &
Column
└└& ,
<
└└, -
string
└└- 3
>
└└3 4
(
└└4 5
type
└└5 9
:
└└9 :
$str
└└; A
,
└└A B
nullable
└└C K
:
└└K L
true
└└M Q
)
└└Q R
,
└└R S
LastModified
┴┴  
=
┴┴! "
table
┴┴# (
.
┴┴( )
Column
┴┴) /
<
┴┴/ 0
DateTimeOffset
┴┴0 >
>
┴┴> ?
(
┴┴? @
type
┴┴@ D
:
┴┴D E
$str
┴┴F `
,
┴┴` a
nullable
┴┴b j
:
┴┴j k
false
┴┴l q
)
┴┴q r
,
┴┴r s
LastModifiedBy
┬┬ "
=
┬┬# $
table
┬┬% *
.
┬┬* +
Column
┬┬+ 1
<
┬┬1 2
string
┬┬2 8
>
┬┬8 9
(
┬┬9 :
type
┬┬: >
:
┬┬> ?
$str
┬┬@ F
,
┬┬F G
nullable
┬┬H P
:
┬┬P Q
true
┬┬R V
)
┬┬V W
}
├├ 
,
├├ 
constraints
── 
:
── 
table
── "
=>
──# %
{
┼┼ 
table
╞╞ 
.
╞╞ 

PrimaryKey
╞╞ $
(
╞╞$ %
$str
╞╞% <
,
╞╞< =
x
╞╞> ?
=>
╞╞@ B
x
╞╞C D
.
╞╞D E
Id
╞╞E G
)
╞╞G H
;
╞╞H I
table
╟╟ 
.
╟╟ 

ForeignKey
╟╟ $
(
╟╟$ %
name
╚╚ 
:
╚╚ 
$str
╚╚ N
,
╚╚N O
column
╔╔ 
:
╔╔ 
x
╔╔  !
=>
╔╔" $
x
╔╔% &
.
╔╔& '
IngredientId
╔╔' 3
,
╔╔3 4
principalTable
╩╩ &
:
╩╩& '
$str
╩╩( 5
,
╩╩5 6
principalColumn
╦╦ '
:
╦╦' (
$str
╦╦) -
,
╦╦- .
onDelete
╠╠  
:
╠╠  !
ReferentialAction
╠╠" 3
.
╠╠3 4
Cascade
╠╠4 ;
)
╠╠; <
;
╠╠< =
table
══ 
.
══ 

ForeignKey
══ $
(
══$ %
name
╬╬ 
:
╬╬ 
$str
╬╬ H
,
╬╬H I
column
╧╧ 
:
╧╧ 
x
╧╧  !
=>
╧╧" $
x
╧╧% &
.
╧╧& '
	ProductId
╧╧' 0
,
╧╧0 1
principalTable
╨╨ &
:
╨╨& '
$str
╨╨( 2
,
╨╨2 3
principalColumn
╤╤ '
:
╤╤' (
$str
╤╤) -
,
╤╤- .
onDelete
╥╥  
:
╥╥  !
ReferentialAction
╥╥" 3
.
╥╥3 4
Cascade
╥╥4 ;
)
╥╥; <
;
╥╥< =
}
╙╙ 
)
╙╙ 
;
╙╙ 
migrationBuilder
╒╒ 
.
╒╒ 
CreateTable
╒╒ (
(
╒╒( )
name
╓╓ 
:
╓╓ 
$str
╓╓ #
,
╓╓# $
columns
╫╫ 
:
╫╫ 
table
╫╫ 
=>
╫╫ !
new
╫╫" %
{
╪╪ 
Id
┘┘ 
=
┘┘ 
table
┘┘ 
.
┘┘ 
Column
┘┘ %
<
┘┘% &
Guid
┘┘& *
>
┘┘* +
(
┘┘+ ,
type
┘┘, 0
:
┘┘0 1
$str
┘┘2 8
,
┘┘8 9
nullable
┘┘: B
:
┘┘B C
false
┘┘D I
)
┘┘I J
,
┘┘J K
CheckInTime
┌┌ 
=
┌┌  !
table
┌┌" '
.
┌┌' (
Column
┌┌( .
<
┌┌. /
DateTimeOffset
┌┌/ =
>
┌┌= >
(
┌┌> ?
type
┌┌? C
:
┌┌C D
$str
┌┌E _
,
┌┌_ `
nullable
┌┌a i
:
┌┌i j
false
┌┌k p
)
┌┌p q
,
┌┌q r
CheckOutTime
██  
=
██! "
table
██# (
.
██( )
Column
██) /
<
██/ 0
DateTimeOffset
██0 >
>
██> ?
(
██? @
type
██@ D
:
██D E
$str
██F `
,
██` a
nullable
██b j
:
██j k
true
██l p
)
██p q
,
██q r

EmployeeId
▄▄ 
=
▄▄  
table
▄▄! &
.
▄▄& '
Column
▄▄' -
<
▄▄- .
Guid
▄▄. 2
>
▄▄2 3
(
▄▄3 4
type
▄▄4 8
:
▄▄8 9
$str
▄▄: @
,
▄▄@ A
nullable
▄▄B J
:
▄▄J K
false
▄▄L Q
)
▄▄Q R
,
▄▄R S
WaiterScheduleId
▌▌ $
=
▌▌% &
table
▌▌' ,
.
▌▌, -
Column
▌▌- 3
<
▌▌3 4
Guid
▌▌4 8
>
▌▌8 9
(
▌▌9 :
type
▌▌: >
:
▌▌> ?
$str
▌▌@ F
,
▌▌F G
nullable
▌▌H P
:
▌▌P Q
false
▌▌R W
)
▌▌W X
,
▌▌X Y
UserId
▐▐ 
=
▐▐ 
table
▐▐ "
.
▐▐" #
Column
▐▐# )
<
▐▐) *
string
▐▐* 0
>
▐▐0 1
(
▐▐1 2
type
▐▐2 6
:
▐▐6 7
$str
▐▐8 >
,
▐▐> ?
nullable
▐▐@ H
:
▐▐H I
true
▐▐J N
)
▐▐N O
,
▐▐O P
Created
▀▀ 
=
▀▀ 
table
▀▀ #
.
▀▀# $
Column
▀▀$ *
<
▀▀* +
DateTimeOffset
▀▀+ 9
>
▀▀9 :
(
▀▀: ;
type
▀▀; ?
:
▀▀? @
$str
▀▀A [
,
▀▀[ \
nullable
▀▀] e
:
▀▀e f
false
▀▀g l
)
▀▀l m
,
▀▀m n
	CreatedBy
рр 
=
рр 
table
рр  %
.
рр% &
Column
рр& ,
<
рр, -
string
рр- 3
>
рр3 4
(
рр4 5
type
рр5 9
:
рр9 :
$str
рр; A
,
ррA B
nullable
ррC K
:
ррK L
true
ррM Q
)
ррQ R
,
ррR S
LastModified
сс  
=
сс! "
table
сс# (
.
сс( )
Column
сс) /
<
сс/ 0
DateTimeOffset
сс0 >
>
сс> ?
(
сс? @
type
сс@ D
:
ссD E
$str
ссF `
,
сс` a
nullable
ссb j
:
ссj k
false
ссl q
)
ссq r
,
ссr s
LastModifiedBy
тт "
=
тт# $
table
тт% *
.
тт* +
Column
тт+ 1
<
тт1 2
string
тт2 8
>
тт8 9
(
тт9 :
type
тт: >
:
тт> ?
$str
тт@ F
,
ттF G
nullable
ттH P
:
ттP Q
true
ттR V
)
ттV W
}
уу 
,
уу 
constraints
фф 
:
фф 
table
фф "
=>
фф# %
{
хх 
table
цц 
.
цц 

PrimaryKey
цц $
(
цц$ %
$str
цц% 5
,
цц5 6
x
цц7 8
=>
цц9 ;
x
цц< =
.
цц= >
Id
цц> @
)
цц@ A
;
ццA B
table
чч 
.
чч 

ForeignKey
чч $
(
чч$ %
name
шш 
:
шш 
$str
шш A
,
шшA B
column
щщ 
:
щщ 
x
щщ  !
=>
щщ" $
x
щщ% &
.
щщ& '
UserId
щщ' -
,
щщ- .
principalTable
ъъ &
:
ъъ& '
$str
ъъ( 5
,
ъъ5 6
principalColumn
ыы '
:
ыы' (
$str
ыы) -
)
ыы- .
;
ыы. /
table
ьь 
.
ьь 

ForeignKey
ьь $
(
ьь$ %
name
ээ 
:
ээ 
$str
ээ C
,
ээC D
column
юю 
:
юю 
x
юю  !
=>
юю" $
x
юю% &
.
юю& '

EmployeeId
юю' 1
,
юю1 2
principalTable
яя &
:
яя& '
$str
яя( 3
,
яя3 4
principalColumn
ЁЁ '
:
ЁЁ' (
$str
ЁЁ) -
,
ЁЁ- .
onDelete
ёё  
:
ёё  !
ReferentialAction
ёё" 3
.
ёё3 4
Cascade
ёё4 ;
)
ёё; <
;
ёё< =
table
ЄЄ 
.
ЄЄ 

ForeignKey
ЄЄ $
(
ЄЄ$ %
name
єє 
:
єє 
$str
єє O
,
єєO P
column
ЇЇ 
:
ЇЇ 
x
ЇЇ  !
=>
ЇЇ" $
x
ЇЇ% &
.
ЇЇ& '
WaiterScheduleId
ЇЇ' 7
,
ЇЇ7 8
principalTable
її &
:
її& '
$str
її( 9
,
її9 :
principalColumn
ЎЎ '
:
ЎЎ' (
$str
ЎЎ) -
,
ЎЎ- .
onDelete
ўў  
:
ўў  !
ReferentialAction
ўў" 3
.
ўў3 4
Cascade
ўў4 ;
)
ўў; <
;
ўў< =
}
°° 
)
°° 
;
°° 
migrationBuilder
·· 
.
·· 
CreateTable
·· (
(
··( )
name
√√ 
:
√√ 
$str
√√ .
,
√√. /
columns
№№ 
:
№№ 
table
№№ 
=>
№№ !
new
№№" %
{
¤¤ 
Id
■■ 
=
■■ 
table
■■ 
.
■■ 
Column
■■ %
<
■■% &
Guid
■■& *
>
■■* +
(
■■+ ,
type
■■, 0
:
■■0 1
$str
■■2 8
,
■■8 9
nullable
■■: B
:
■■B C
false
■■D I
)
■■I J
,
■■J K
Quantity
   
=
   
table
   $
.
  $ %
Column
  % +
<
  + ,
decimal
  , 3
>
  3 4
(
  4 5
type
  5 9
:
  9 :
$str
  ; D
,
  D E
nullable
  F N
:
  N O
false
  P U
)
  U V
,
  V W
TransactionDate
АА #
=
АА$ %
table
АА& +
.
АА+ ,
Column
АА, 2
<
АА2 3
DateTime
АА3 ;
>
АА; <
(
АА< =
type
АА= A
:
ААA B
$str
ААC ]
,
АА] ^
nullable
АА_ g
:
ААg h
false
ААi n
)
ААn o
,
ААo p
Type
ББ 
=
ББ 
table
ББ  
.
ББ  !
Column
ББ! '
<
ББ' (
byte
ББ( ,
>
ББ, -
(
ББ- .
type
ББ. 2
:
ББ2 3
$str
ББ4 >
,
ББ> ?
nullable
ББ@ H
:
ББH I
false
ББJ O
)
ББO P
,
ББP Q
IngredientId
ВВ  
=
ВВ! "
table
ВВ# (
.
ВВ( )
Column
ВВ) /
<
ВВ/ 0
Guid
ВВ0 4
>
ВВ4 5
(
ВВ5 6
type
ВВ6 :
:
ВВ: ;
$str
ВВ< B
,
ВВB C
nullable
ВВD L
:
ВВL M
false
ВВN S
)
ВВS T
,
ВВT U
	IsDeleted
ГГ 
=
ГГ 
table
ГГ  %
.
ГГ% &
Column
ГГ& ,
<
ГГ, -
bool
ГГ- 1
>
ГГ1 2
(
ГГ2 3
type
ГГ3 7
:
ГГ7 8
$str
ГГ9 B
,
ГГB C
nullable
ГГD L
:
ГГL M
false
ГГN S
)
ГГS T
,
ГГT U
OrderId
ДД 
=
ДД 
table
ДД #
.
ДД# $
Column
ДД$ *
<
ДД* +
Guid
ДД+ /
>
ДД/ 0
(
ДД0 1
type
ДД1 5
:
ДД5 6
$str
ДД7 =
,
ДД= >
nullable
ДД? G
:
ДДG H
true
ДДI M
)
ДДM N
,
ДДN O
Created
ЕЕ 
=
ЕЕ 
table
ЕЕ #
.
ЕЕ# $
Column
ЕЕ$ *
<
ЕЕ* +
DateTimeOffset
ЕЕ+ 9
>
ЕЕ9 :
(
ЕЕ: ;
type
ЕЕ; ?
:
ЕЕ? @
$str
ЕЕA [
,
ЕЕ[ \
nullable
ЕЕ] e
:
ЕЕe f
false
ЕЕg l
)
ЕЕl m
,
ЕЕm n
	CreatedBy
ЖЖ 
=
ЖЖ 
table
ЖЖ  %
.
ЖЖ% &
Column
ЖЖ& ,
<
ЖЖ, -
string
ЖЖ- 3
>
ЖЖ3 4
(
ЖЖ4 5
type
ЖЖ5 9
:
ЖЖ9 :
$str
ЖЖ; A
,
ЖЖA B
nullable
ЖЖC K
:
ЖЖK L
true
ЖЖM Q
)
ЖЖQ R
,
ЖЖR S
LastModified
ЗЗ  
=
ЗЗ! "
table
ЗЗ# (
.
ЗЗ( )
Column
ЗЗ) /
<
ЗЗ/ 0
DateTimeOffset
ЗЗ0 >
>
ЗЗ> ?
(
ЗЗ? @
type
ЗЗ@ D
:
ЗЗD E
$str
ЗЗF `
,
ЗЗ` a
nullable
ЗЗb j
:
ЗЗj k
false
ЗЗl q
)
ЗЗq r
,
ЗЗr s
LastModifiedBy
ИИ "
=
ИИ# $
table
ИИ% *
.
ИИ* +
Column
ИИ+ 1
<
ИИ1 2
string
ИИ2 8
>
ИИ8 9
(
ИИ9 :
type
ИИ: >
:
ИИ> ?
$str
ИИ@ F
,
ИИF G
nullable
ИИH P
:
ИИP Q
true
ИИR V
)
ИИV W
}
ЙЙ 
,
ЙЙ 
constraints
КК 
:
КК 
table
КК "
=>
КК# %
{
ЛЛ 
table
ММ 
.
ММ 

PrimaryKey
ММ $
(
ММ$ %
$str
ММ% @
,
ММ@ A
x
ММB C
=>
ММD F
x
ММG H
.
ММH I
Id
ММI K
)
ММK L
;
ММL M
table
НН 
.
НН 

ForeignKey
НН $
(
НН$ %
name
ОО 
:
ОО 
$str
ОО R
,
ООR S
column
ПП 
:
ПП 
x
ПП  !
=>
ПП" $
x
ПП% &
.
ПП& '
IngredientId
ПП' 3
,
ПП3 4
principalTable
РР &
:
РР& '
$str
РР( 5
,
РР5 6
principalColumn
СС '
:
СС' (
$str
СС) -
,
СС- .
onDelete
ТТ  
:
ТТ  !
ReferentialAction
ТТ" 3
.
ТТ3 4
Cascade
ТТ4 ;
)
ТТ; <
;
ТТ< =
table
УУ 
.
УУ 

ForeignKey
УУ $
(
УУ$ %
name
ФФ 
:
ФФ 
$str
ФФ H
,
ФФH I
column
ХХ 
:
ХХ 
x
ХХ  !
=>
ХХ" $
x
ХХ% &
.
ХХ& '
OrderId
ХХ' .
,
ХХ. /
principalTable
ЦЦ &
:
ЦЦ& '
$str
ЦЦ( 0
,
ЦЦ0 1
principalColumn
ЧЧ '
:
ЧЧ' (
$str
ЧЧ) -
)
ЧЧ- .
;
ЧЧ. /
}
ШШ 
)
ШШ 
;
ШШ 
migrationBuilder
ЪЪ 
.
ЪЪ 
CreateTable
ЪЪ (
(
ЪЪ( )
name
ЫЫ 
:
ЫЫ 
$str
ЫЫ $
,
ЫЫ$ %
columns
ЬЬ 
:
ЬЬ 
table
ЬЬ 
=>
ЬЬ !
new
ЬЬ" %
{
ЭЭ 
Id
ЮЮ 
=
ЮЮ 
table
ЮЮ 
.
ЮЮ 
Column
ЮЮ %
<
ЮЮ% &
Guid
ЮЮ& *
>
ЮЮ* +
(
ЮЮ+ ,
type
ЮЮ, 0
:
ЮЮ0 1
$str
ЮЮ2 8
,
ЮЮ8 9
nullable
ЮЮ: B
:
ЮЮB C
false
ЮЮD I
)
ЮЮI J
,
ЮЮJ K
ComboId
ЯЯ 
=
ЯЯ 
table
ЯЯ #
.
ЯЯ# $
Column
ЯЯ$ *
<
ЯЯ* +
Guid
ЯЯ+ /
>
ЯЯ/ 0
(
ЯЯ0 1
type
ЯЯ1 5
:
ЯЯ5 6
$str
ЯЯ7 =
,
ЯЯ= >
nullable
ЯЯ? G
:
ЯЯG H
true
ЯЯI M
)
ЯЯM N
,
ЯЯN O
	ProductId
аа 
=
аа 
table
аа  %
.
аа% &
Column
аа& ,
<
аа, -
Guid
аа- 1
>
аа1 2
(
аа2 3
type
аа3 7
:
аа7 8
$str
аа9 ?
,
аа? @
nullable
ааA I
:
ааI J
true
ааK O
)
ааO P
,
ааP Q
OrderId
бб 
=
бб 
table
бб #
.
бб# $
Column
бб$ *
<
бб* +
Guid
бб+ /
>
бб/ 0
(
бб0 1
type
бб1 5
:
бб5 6
$str
бб7 =
,
бб= >
nullable
бб? G
:
ббG H
true
ббI M
)
ббM N
,
ббN O
Status
вв 
=
вв 
table
вв "
.
вв" #
Column
вв# )
<
вв) *
byte
вв* .
>
вв. /
(
вв/ 0
type
вв0 4
:
вв4 5
$str
вв6 @
,
вв@ A
nullable
ввB J
:
ввJ K
true
ввL P
)
ввP Q
,
ввQ R
Quantity
гг 
=
гг 
table
гг $
.
гг$ %
Column
гг% +
<
гг+ ,
int
гг, /
>
гг/ 0
(
гг0 1
type
гг1 5
:
гг5 6
$str
гг7 @
,
гг@ A
nullable
ггB J
:
ггJ K
false
ггL Q
)
ггQ R
,
ггR S
Price
дд 
=
дд 
table
дд !
.
дд! "
Column
дд" (
<
дд( )
decimal
дд) 0
>
дд0 1
(
дд1 2
type
дд2 6
:
дд6 7
$str
дд8 A
,
ддA B
nullable
ддC K
:
ддK L
false
ддM R
)
ддR S
,
ддS T
Created
ее 
=
ее 
table
ее #
.
ее# $
Column
ее$ *
<
ее* +
DateTimeOffset
ее+ 9
>
ее9 :
(
ее: ;
type
ее; ?
:
ее? @
$str
ееA [
,
ее[ \
nullable
ее] e
:
ееe f
false
ееg l
)
ееl m
,
ееm n
	CreatedBy
жж 
=
жж 
table
жж  %
.
жж% &
Column
жж& ,
<
жж, -
string
жж- 3
>
жж3 4
(
жж4 5
type
жж5 9
:
жж9 :
$str
жж; A
,
жжA B
nullable
жжC K
:
жжK L
true
жжM Q
)
жжQ R
,
жжR S
LastModified
зз  
=
зз! "
table
зз# (
.
зз( )
Column
зз) /
<
зз/ 0
DateTimeOffset
зз0 >
>
зз> ?
(
зз? @
type
зз@ D
:
ззD E
$str
ззF `
,
зз` a
nullable
ззb j
:
ззj k
false
ззl q
)
ззq r
,
ззr s
LastModifiedBy
ии "
=
ии# $
table
ии% *
.
ии* +
Column
ии+ 1
<
ии1 2
string
ии2 8
>
ии8 9
(
ии9 :
type
ии: >
:
ии> ?
$str
ии@ F
,
ииF G
nullable
ииH P
:
ииP Q
true
ииR V
)
ииV W
}
йй 
,
йй 
constraints
кк 
:
кк 
table
кк "
=>
кк# %
{
лл 
table
мм 
.
мм 

PrimaryKey
мм $
(
мм$ %
$str
мм% 6
,
мм6 7
x
мм8 9
=>
мм: <
x
мм= >
.
мм> ?
Id
мм? A
)
ммA B
;
ммB C
table
нн 
.
нн 

ForeignKey
нн $
(
нн$ %
name
оо 
:
оо 
$str
оо >
,
оо> ?
column
пп 
:
пп 
x
пп  !
=>
пп" $
x
пп% &
.
пп& '
ComboId
пп' .
,
пп. /
principalTable
░░ &
:
░░& '
$str
░░( 0
,
░░0 1
principalColumn
▒▒ '
:
▒▒' (
$str
▒▒) -
)
▒▒- .
;
▒▒. /
table
▓▓ 
.
▓▓ 

ForeignKey
▓▓ $
(
▓▓$ %
name
││ 
:
││ 
$str
││ >
,
││> ?
column
┤┤ 
:
┤┤ 
x
┤┤  !
=>
┤┤" $
x
┤┤% &
.
┤┤& '
OrderId
┤┤' .
,
┤┤. /
principalTable
╡╡ &
:
╡╡& '
$str
╡╡( 0
,
╡╡0 1
principalColumn
╢╢ '
:
╢╢' (
$str
╢╢) -
)
╢╢- .
;
╢╢. /
table
╖╖ 
.
╖╖ 

ForeignKey
╖╖ $
(
╖╖$ %
name
╕╕ 
:
╕╕ 
$str
╕╕ B
,
╕╕B C
column
╣╣ 
:
╣╣ 
x
╣╣  !
=>
╣╣" $
x
╣╣% &
.
╣╣& '
	ProductId
╣╣' 0
,
╣╣0 1
principalTable
║║ &
:
║║& '
$str
║║( 2
,
║║2 3
principalColumn
╗╗ '
:
╗╗' (
$str
╗╗) -
)
╗╗- .
;
╗╗. /
}
╝╝ 
)
╝╝ 
;
╝╝ 
migrationBuilder
╛╛ 
.
╛╛ 
CreateTable
╛╛ (
(
╛╛( )
name
┐┐ 
:
┐┐ 
$str
┐┐  
,
┐┐  !
columns
└└ 
:
└└ 
table
└└ 
=>
└└ !
new
└└" %
{
┴┴ 
Id
┬┬ 
=
┬┬ 
table
┬┬ 
.
┬┬ 
Column
┬┬ %
<
┬┬% &
Guid
┬┬& *
>
┬┬* +
(
┬┬+ ,
type
┬┬, 0
:
┬┬0 1
$str
┬┬2 8
,
┬┬8 9
nullable
┬┬: B
:
┬┬B C
false
┬┬D I
)
┬┬I J
,
┬┬J K
PaymentDate
├├ 
=
├├  !
table
├├" '
.
├├' (
Column
├├( .
<
├├. /
DateTime
├├/ 7
>
├├7 8
(
├├8 9
type
├├9 =
:
├├= >
$str
├├? Y
,
├├Y Z
nullable
├├[ c
:
├├c d
false
├├e j
)
├├j k
,
├├k l
Amount
── 
=
── 
table
── "
.
──" #
Column
──# )
<
──) *
decimal
──* 1
>
──1 2
(
──2 3
type
──3 7
:
──7 8
$str
──9 B
,
──B C
nullable
──D L
:
──L M
false
──N S
)
──S T
,
──T U
	VnpTxnRef
┼┼ 
=
┼┼ 
table
┼┼  %
.
┼┼% &
Column
┼┼& ,
<
┼┼, -
string
┼┼- 3
>
┼┼3 4
(
┼┼4 5
type
┼┼5 9
:
┼┼9 :
$str
┼┼; A
,
┼┼A B
nullable
┼┼C K
:
┼┼K L
false
┼┼M R
)
┼┼R S
,
┼┼S T
PaymentStatus
╞╞ !
=
╞╞" #
table
╞╞$ )
.
╞╞) *
Column
╞╞* 0
<
╞╞0 1
byte
╞╞1 5
>
╞╞5 6
(
╞╞6 7
type
╞╞7 ;
:
╞╞; <
$str
╞╞= G
,
╞╞G H
nullable
╞╞I Q
:
╞╞Q R
false
╞╞S X
)
╞╞X Y
,
╞╞Y Z
PaymentMethods
╟╟ "
=
╟╟# $
table
╟╟% *
.
╟╟* +
Column
╟╟+ 1
<
╟╟1 2
byte
╟╟2 6
>
╟╟6 7
(
╟╟7 8
type
╟╟8 <
:
╟╟< =
$str
╟╟> H
,
╟╟H I
nullable
╟╟J R
:
╟╟R S
false
╟╟T Y
)
╟╟Y Z
,
╟╟Z [
OrderId
╚╚ 
=
╚╚ 
table
╚╚ #
.
╚╚# $
Column
╚╚$ *
<
╚╚* +
Guid
╚╚+ /
>
╚╚/ 0
(
╚╚0 1
type
╚╚1 5
:
╚╚5 6
$str
╚╚7 =
,
╚╚= >
nullable
╚╚? G
:
╚╚G H
false
╚╚I N
)
╚╚N O
,
╚╚O P
Created
╔╔ 
=
╔╔ 
table
╔╔ #
.
╔╔# $
Column
╔╔$ *
<
╔╔* +
DateTimeOffset
╔╔+ 9
>
╔╔9 :
(
╔╔: ;
type
╔╔; ?
:
╔╔? @
$str
╔╔A [
,
╔╔[ \
nullable
╔╔] e
:
╔╔e f
false
╔╔g l
)
╔╔l m
,
╔╔m n
	CreatedBy
╩╩ 
=
╩╩ 
table
╩╩  %
.
╩╩% &
Column
╩╩& ,
<
╩╩, -
string
╩╩- 3
>
╩╩3 4
(
╩╩4 5
type
╩╩5 9
:
╩╩9 :
$str
╩╩; A
,
╩╩A B
nullable
╩╩C K
:
╩╩K L
true
╩╩M Q
)
╩╩Q R
,
╩╩R S
LastModified
╦╦  
=
╦╦! "
table
╦╦# (
.
╦╦( )
Column
╦╦) /
<
╦╦/ 0
DateTimeOffset
╦╦0 >
>
╦╦> ?
(
╦╦? @
type
╦╦@ D
:
╦╦D E
$str
╦╦F `
,
╦╦` a
nullable
╦╦b j
:
╦╦j k
false
╦╦l q
)
╦╦q r
,
╦╦r s
LastModifiedBy
╠╠ "
=
╠╠# $
table
╠╠% *
.
╠╠* +
Column
╠╠+ 1
<
╠╠1 2
string
╠╠2 8
>
╠╠8 9
(
╠╠9 :
type
╠╠: >
:
╠╠> ?
$str
╠╠@ F
,
╠╠F G
nullable
╠╠H P
:
╠╠P Q
true
╠╠R V
)
╠╠V W
}
══ 
,
══ 
constraints
╬╬ 
:
╬╬ 
table
╬╬ "
=>
╬╬# %
{
╧╧ 
table
╨╨ 
.
╨╨ 

PrimaryKey
╨╨ $
(
╨╨$ %
$str
╨╨% 2
,
╨╨2 3
x
╨╨4 5
=>
╨╨6 8
x
╨╨9 :
.
╨╨: ;
Id
╨╨; =
)
╨╨= >
;
╨╨> ?
table
╤╤ 
.
╤╤ 

ForeignKey
╤╤ $
(
╤╤$ %
name
╥╥ 
:
╥╥ 
$str
╥╥ :
,
╥╥: ;
column
╙╙ 
:
╙╙ 
x
╙╙  !
=>
╙╙" $
x
╙╙% &
.
╙╙& '
OrderId
╙╙' .
,
╙╙. /
principalTable
╘╘ &
:
╘╘& '
$str
╘╘( 0
,
╘╘0 1
principalColumn
╒╒ '
:
╒╒' (
$str
╒╒) -
,
╒╒- .
onDelete
╓╓  
:
╓╓  !
ReferentialAction
╓╓" 3
.
╓╓3 4
Cascade
╓╓4 ;
)
╓╓; <
;
╓╓< =
}
╫╫ 
)
╫╫ 
;
╫╫ 
migrationBuilder
┘┘ 
.
┘┘ 
CreateTable
┘┘ (
(
┘┘( )
name
┌┌ 
:
┌┌ 
$str
┌┌ 
,
┌┌  
columns
██ 
:
██ 
table
██ 
=>
██ !
new
██" %
{
▄▄ 
Id
▌▌ 
=
▌▌ 
table
▌▌ 
.
▌▌ 
Column
▌▌ %
<
▌▌% &
Guid
▌▌& *
>
▌▌* +
(
▌▌+ ,
type
▌▌, 0
:
▌▌0 1
$str
▌▌2 8
,
▌▌8 9
nullable
▌▌: B
:
▌▌B C
false
▌▌D I
)
▌▌I J
,
▌▌J K
RatingStart
▐▐ 
=
▐▐  !
table
▐▐" '
.
▐▐' (
Column
▐▐( .
<
▐▐. /
int
▐▐/ 2
>
▐▐2 3
(
▐▐3 4
type
▐▐4 8
:
▐▐8 9
$str
▐▐: C
,
▐▐C D
nullable
▐▐E M
:
▐▐M N
false
▐▐O T
)
▐▐T U
,
▐▐U V
Comment
▀▀ 
=
▀▀ 
table
▀▀ #
.
▀▀# $
Column
▀▀$ *
<
▀▀* +
string
▀▀+ 1
>
▀▀1 2
(
▀▀2 3
type
▀▀3 7
:
▀▀7 8
$str
▀▀9 ?
,
▀▀? @
nullable
▀▀A I
:
▀▀I J
false
▀▀K P
)
▀▀P Q
,
▀▀Q R
ImageUrl
рр 
=
рр 
table
рр $
.
рр$ %
Column
рр% +
<
рр+ ,
string
рр, 2
>
рр2 3
(
рр3 4
type
рр4 8
:
рр8 9
$str
рр: @
,
рр@ A
nullable
ррB J
:
ррJ K
false
ррL Q
)
ррQ R
,
ррR S
OrderId
сс 
=
сс 
table
сс #
.
сс# $
Column
сс$ *
<
сс* +
Guid
сс+ /
>
сс/ 0
(
сс0 1
type
сс1 5
:
сс5 6
$str
сс7 =
,
сс= >
nullable
сс? G
:
ссG H
false
ссI N
)
ссN O
,
ссO P
UsefulQuantity
тт "
=
тт# $
table
тт% *
.
тт* +
Column
тт+ 1
<
тт1 2
int
тт2 5
>
тт5 6
(
тт6 7
type
тт7 ;
:
тт; <
$str
тт= F
,
ттF G
nullable
ттH P
:
ттP Q
false
ттR W
)
ттW X
,
ттX Y
NonUsefulQuantity
уу %
=
уу& '
table
уу( -
.
уу- .
Column
уу. 4
<
уу4 5
int
уу5 8
>
уу8 9
(
уу9 :
type
уу: >
:
уу> ?
$str
уу@ I
,
ууI J
nullable
ууK S
:
ууS T
false
ууU Z
)
ууZ [
,
уу[ \
Created
фф 
=
фф 
table
фф #
.
фф# $
Column
фф$ *
<
фф* +
DateTimeOffset
фф+ 9
>
фф9 :
(
фф: ;
type
фф; ?
:
фф? @
$str
ффA [
,
фф[ \
nullable
фф] e
:
ффe f
false
ффg l
)
ффl m
,
ффm n
	CreatedBy
хх 
=
хх 
table
хх  %
.
хх% &
Column
хх& ,
<
хх, -
string
хх- 3
>
хх3 4
(
хх4 5
type
хх5 9
:
хх9 :
$str
хх; A
,
ххA B
nullable
ххC K
:
ххK L
true
ххM Q
)
ххQ R
,
ххR S
LastModified
цц  
=
цц! "
table
цц# (
.
цц( )
Column
цц) /
<
цц/ 0
DateTimeOffset
цц0 >
>
цц> ?
(
цц? @
type
цц@ D
:
ццD E
$str
ццF `
,
цц` a
nullable
ццb j
:
ццj k
false
ццl q
)
ццq r
,
ццr s
LastModifiedBy
чч "
=
чч# $
table
чч% *
.
чч* +
Column
чч+ 1
<
чч1 2
string
чч2 8
>
чч8 9
(
чч9 :
type
чч: >
:
чч> ?
$str
чч@ F
,
ччF G
nullable
ччH P
:
ччP Q
true
ччR V
)
ччV W
}
шш 
,
шш 
constraints
щщ 
:
щщ 
table
щщ "
=>
щщ# %
{
ъъ 
table
ыы 
.
ыы 

PrimaryKey
ыы $
(
ыы$ %
$str
ыы% 1
,
ыы1 2
x
ыы3 4
=>
ыы5 7
x
ыы8 9
.
ыы9 :
Id
ыы: <
)
ыы< =
;
ыы= >
table
ьь 
.
ьь 

ForeignKey
ьь $
(
ьь$ %
name
ээ 
:
ээ 
$str
ээ 9
,
ээ9 :
column
юю 
:
юю 
x
юю  !
=>
юю" $
x
юю% &
.
юю& '
OrderId
юю' .
,
юю. /
principalTable
яя &
:
яя& '
$str
яя( 0
,
яя0 1
principalColumn
ЁЁ '
:
ЁЁ' (
$str
ЁЁ) -
,
ЁЁ- .
onDelete
ёё  
:
ёё  !
ReferentialAction
ёё" 3
.
ёё3 4
Cascade
ёё4 ;
)
ёё; <
;
ёё< =
}
ЄЄ 
)
ЄЄ 
;
ЄЄ 
migrationBuilder
ЇЇ 
.
ЇЇ 

InsertData
ЇЇ '
(
ЇЇ' (
table
її 
:
її 
$str
її $
,
її$ %
columns
ЎЎ 
:
ЎЎ 
new
ЎЎ 
[
ЎЎ 
]
ЎЎ 
{
ЎЎ  
$str
ЎЎ! %
,
ЎЎ% &
$str
ЎЎ' :
,
ЎЎ: ;
$str
ЎЎ< N
,
ЎЎN O
$str
ЎЎP W
,
ЎЎW X
$str
ЎЎY i
,
ЎЎi j
$str
ЎЎk v
,
ЎЎv w
$strЎЎx В
,ЎЎВ Г
$strЎЎД Ф
,ЎЎФ Х
$strЎЎЦ в
,ЎЎв г
$strЎЎд ╡
,ЎЎ╡ ╢
$strЎЎ╖ ╦
,ЎЎ╦ ╠
$strЎЎ═ █
,ЎЎ█ ▄
$strЎЎ▌ ъ
,ЎЎъ ы
$strЎЎь В
,ЎЎВ Г
$strЎЎД У
,ЎЎУ Ф
$strЎЎХ з
,ЎЎз и
$strЎЎй │
}ЎЎ┤ ╡
,ЎЎ╡ ╢
values
ўў 
:
ўў 
new
ўў 
object
ўў "
[
ўў" #
,
ўў# $
]
ўў$ %
{
°° 
{
∙∙ 
$str
∙∙ <
,
∙∙< =
$num
∙∙> ?
,
∙∙? @
$str
∙∙A O
,
∙∙O P
$str
∙∙Q e
,
∙∙e f
true
∙∙g k
,
∙∙k l
$str
∙∙m t
,
∙∙t u
$str
∙∙v 
,∙∙ А
true∙∙Б Е
,∙∙Е Ж
null∙∙З Л
,∙∙Л М
$str∙∙Н б
,∙∙б в
$str∙∙г л
,∙∙л м
$str∙∙н В
,∙∙В Г
$str∙∙Д Р
,∙∙Р С
true∙∙Т Ц
,∙∙Ц Ч
$str∙∙Ш д
,∙∙д е
false∙∙ж л
,∙∙л м
$str∙∙н ╡
}∙∙╢ ╖
,∙∙╖ ╕
{
·· 
$str
·· <
,
··< =
$num
··> ?
,
··? @
$str
··A O
,
··O P
$str
··Q f
,
··f g
true
··h l
,
··l m
$str
··n v
,
··v w
$str
··x }
,
··} ~
true·· Г
,··Г Д
null··Е Й
,··Й К
$str··Л а
,··а б
$str··в н
,··н о
$str··п Е
,··Е Ж
$str··З У
,··У Ф
true··Х Щ
,··Щ Ъ
$str··Ы з
,··з и
false··й о
,··о п
$str··░ ╗
}··╝ ╜
,··╜ ╛
{
√√ 
$str
√√ <
,
√√< =
$num
√√> ?
,
√√? @
$str
√√A O
,
√√O P
$str
√√Q e
,
√√e f
true
√√g k
,
√√k l
$str
√√m t
,
√√t u
$str
√√v {
,
√√{ |
true√√} Б
,√√Б В
null√√Г З
,√√З И
$str√√Й Э
,√√Э Ю
$str√√Я й
,√√й к
$str√√л А
,√√А Б
$str√√В О
,√√О П
true√√Р Ф
,√√Ф Х
$str√√Ц в
,√√в г
false√√д й
,√√й к
$str√√л ╡
}√√╢ ╖
}
№№ 
)
№№ 
;
№№ 
migrationBuilder
■■ 
.
■■ 

InsertData
■■ '
(
■■' (
table
   
:
   
$str
   #
,
  # $
columns
АА 
:
АА 
new
АА 
[
АА 
]
АА 
{
АА  
$str
АА! %
,
АА% &
$str
АА' 5
,
АА5 6
$str
АА7 @
,
АА@ A
$str
ААB M
,
ААM N
$str
ААO Z
,
ААZ [
$str
АА\ j
,
ААj k
$str
ААl |
}
АА} ~
,
АА~ 
values
ББ 
:
ББ 
new
ББ 
object
ББ "
[
ББ" #
,
ББ# $
]
ББ$ %
{
ВВ 
{
ГГ 
new
ГГ 
Guid
ГГ 
(
ГГ 
$str
ГГ E
)
ГГE F
,
ГГF G
$str
ГГH S
,
ГГS T
new
ГГU X
DateTimeOffset
ГГY g
(
ГГg h
new
ГГh k
DateTime
ГГl t
(
ГГt u
$num
ГГu v
,
ГГv w
$num
ГГx y
,
ГГy z
$num
ГГ{ |
,
ГГ| }
$num
ГГ~ 
,ГГ А
$numГГБ В
,ГГВ Г
$numГГД Е
,ГГЕ Ж
$numГГЗ И
,ГГИ Й
DateTimeKindГГК Ц
.ГГЦ Ч
UnspecifiedГГЧ в
)ГГв г
,ГГг д
newГГе и
TimeSpanГГй ▒
(ГГ▒ ▓
$numГГ▓ │
,ГГ│ ┤
$numГГ╡ ╢
,ГГ╢ ╖
$numГГ╕ ╣
,ГГ╣ ║
$numГГ╗ ╝
,ГГ╝ ╜
$numГГ╛ ┐
)ГГ┐ └
)ГГ└ ┴
,ГГ┴ ┬
nullГГ├ ╟
,ГГ╟ ╚
falseГГ╔ ╬
,ГГ╬ ╧
newГГ╨ ╙
DateTimeOffsetГГ╘ т
(ГГт у
newГГу ц
DateTimeГГч я
(ГГя Ё
$numГГЁ ё
,ГГё Є
$numГГє Ї
,ГГЇ ї
$numГГЎ ў
,ГГў °
$numГГ∙ ·
,ГГ· √
$numГГ№ ¤
,ГГ¤ ■
$numГГ  А
,ГГА Б
$numГГВ Г
,ГГГ Д
DateTimeKindГГЕ С
.ГГС Т
UnspecifiedГГТ Э
)ГГЭ Ю
,ГГЮ Я
newГГа г
TimeSpanГГд м
(ГГм н
$numГГн о
,ГГо п
$numГГ░ ▒
,ГГ▒ ▓
$numГГ│ ┤
,ГГ┤ ╡
$numГГ╢ ╖
,ГГ╖ ╕
$numГГ╣ ║
)ГГ║ ╗
)ГГ╗ ╝
,ГГ╝ ╜
nullГГ╛ ┬
}ГГ├ ─
,ГГ─ ┼
{
ДД 
new
ДД 
Guid
ДД 
(
ДД 
$str
ДД E
)
ДДE F
,
ДДF G
$str
ДДH Q
,
ДДQ R
new
ДДS V
DateTimeOffset
ДДW e
(
ДДe f
new
ДДf i
DateTime
ДДj r
(
ДДr s
$num
ДДs t
,
ДДt u
$num
ДДv w
,
ДДw x
$num
ДДy z
,
ДДz {
$num
ДД| }
,
ДД} ~
$numДД А
,ДДА Б
$numДДВ Г
,ДДГ Д
$numДДЕ Ж
,ДДЖ З
DateTimeKindДДИ Ф
.ДДФ Х
UnspecifiedДДХ а
)ДДа б
,ДДб в
newДДг ж
TimeSpanДДз п
(ДДп ░
$numДД░ ▒
,ДД▒ ▓
$numДД│ ┤
,ДД┤ ╡
$numДД╢ ╖
,ДД╖ ╕
$numДД╣ ║
,ДД║ ╗
$numДД╝ ╜
)ДД╜ ╛
)ДД╛ ┐
,ДД┐ └
nullДД┴ ┼
,ДД┼ ╞
falseДД╟ ╠
,ДД╠ ═
newДД╬ ╤
DateTimeOffsetДД╥ р
(ДДр с
newДДс ф
DateTimeДДх э
(ДДэ ю
$numДДю я
,ДДя Ё
$numДДё Є
,ДДЄ є
$numДДЇ ї
,ДДї Ў
$numДДў °
,ДД° ∙
$numДД· √
,ДД√ №
$numДД¤ ■
,ДД■  
$numДДА Б
,ДДБ В
DateTimeKindДДГ П
.ДДП Р
UnspecifiedДДР Ы
)ДДЫ Ь
,ДДЬ Э
newДДЮ б
TimeSpanДДв к
(ДДк л
$numДДл м
,ДДм н
$numДДо п
,ДДп ░
$numДД▒ ▓
,ДД▓ │
$numДД┤ ╡
,ДД╡ ╢
$numДД╖ ╕
)ДД╕ ╣
)ДД╣ ║
,ДД║ ╗
nullДД╝ └
}ДД┴ ┬
}
ЕЕ 
)
ЕЕ 
;
ЕЕ 
migrationBuilder
ЗЗ 
.
ЗЗ 

InsertData
ЗЗ '
(
ЗЗ' (
table
ИИ 
:
ИИ 
$str
ИИ (
,
ИИ( )
columns
ЙЙ 
:
ЙЙ 
new
ЙЙ 
[
ЙЙ 
]
ЙЙ 
{
ЙЙ  
$str
ЙЙ! %
,
ЙЙ% &
$str
ЙЙ' 0
,
ЙЙ0 1
$str
ЙЙ2 =
,
ЙЙ= >
$str
ЙЙ? L
,
ЙЙL M
$str
ЙЙN e
,
ЙЙe f
$str
ЙЙg w
,
ЙЙw x
$strЙЙy Й
,ЙЙЙ К
$strЙЙЛ Ц
,ЙЙЦ Ч
$strЙЙШ ж
,ЙЙж з
$strЙЙи ╕
,ЙЙ╕ ╣
$strЙЙ║ └
,ЙЙ└ ┴
$strЙЙ┬ ╠
,ЙЙ╠ ═
$strЙЙ╬ ╒
}ЙЙ╓ ╫
,ЙЙ╫ ╪
values
КК 
:
КК 
new
КК 
object
КК "
[
КК" #
,
КК# $
]
КК$ %
{
ЛЛ 
{
ММ 
new
ММ 
Guid
ММ 
(
ММ 
$str
ММ E
)
ММE F
,
ММF G
new
ММH K
DateTimeOffset
ММL Z
(
ММZ [
new
ММ[ ^
DateTime
ММ_ g
(
ММg h
$num
ММh i
,
ММi j
$num
ММk l
,
ММl m
$num
ММn o
,
ММo p
$num
ММq r
,
ММr s
$num
ММt u
,
ММu v
$num
ММw x
,
ММx y
$num
ММz {
,
ММ{ |
DateTimeKindММ} Й
.ММЙ К
UnspecifiedММК Х
)ММХ Ц
,ММЦ Ч
newММШ Ы
TimeSpanММЬ д
(ММд е
$numММе ж
,ММж з
$numММи й
,ММй к
$numММл м
,ММм н
$numММо п
,ММп ░
$numММ▒ ▓
)ММ▓ │
)ММ│ ┤
,ММ┤ ╡
nullММ╢ ║
,ММ║ ╗
$numММ╝ ╛
,ММ╛ ┐
$strММ└ ┬
,ММ┬ ├
$strММ─ ╥
,ММ╥ ╙
$strММ╘ ю
,ММю я
falseММЁ ї
,ММї Ў
newММў ·
DateTimeOffsetММ√ Й
(ММЙ К
newММК Н
DateTimeММО Ц
(ММЦ Ч
$numММЧ Ш
,ММШ Щ
$numММЪ Ы
,ММЫ Ь
$numММЭ Ю
,ММЮ Я
$numММа б
,ММб в
$numММг д
,ММд е
$numММж з
,ММз и
$numММй к
,ММк л
DateTimeKindММм ╕
.ММ╕ ╣
UnspecifiedММ╣ ─
)ММ─ ┼
,ММ┼ ╞
newММ╟ ╩
TimeSpanММ╦ ╙
(ММ╙ ╘
$numММ╘ ╒
,ММ╒ ╓
$numММ╫ ╪
,ММ╪ ┘
$numММ┌ █
,ММ█ ▄
$numММ▌ ▐
,ММ▐ ▀
$numММр с
)ММс т
)ММт у
,ММу ф
nullММх щ
,ММщ ъ
$numММы ь
,ММь э
nullММю Є
,ММЄ є
$numММЇ ї
}ММЎ ў
,ММў °
{
НН 
new
НН 
Guid
НН 
(
НН 
$str
НН E
)
ННE F
,
ННF G
new
ННH K
DateTimeOffset
ННL Z
(
ННZ [
new
НН[ ^
DateTime
НН_ g
(
ННg h
$num
ННh i
,
ННi j
$num
ННk l
,
ННl m
$num
ННn o
,
ННo p
$num
ННq r
,
ННr s
$num
ННt u
,
ННu v
$num
ННw x
,
ННx y
$num
ННz {
,
НН{ |
DateTimeKindНН} Й
.ННЙ К
UnspecifiedННК Х
)ННХ Ц
,ННЦ Ч
newННШ Ы
TimeSpanННЬ д
(ННд е
$numННе ж
,ННж з
$numННи й
,ННй к
$numННл м
,ННм н
$numННо п
,ННп ░
$numНН▒ ▓
)НН▓ │
)НН│ ┤
,НН┤ ╡
nullНН╢ ║
,НН║ ╗
$numНН╝ ╛
,НН╛ ┐
$strНН└ ┬
,НН┬ ├
$strНН─ ╙
,НН╙ ╘
$strНН╒ Ё
,ННЁ ё
falseННЄ ў
,ННў °
newНН∙ №
DateTimeOffsetНН¤ Л
(ННЛ М
newННМ П
DateTimeННР Ш
(ННШ Щ
$numННЩ Ъ
,ННЪ Ы
$numННЬ Э
,ННЭ Ю
$numННЯ а
,ННа б
$numННв г
,ННг д
$numННе ж
,ННж з
$numННи й
,ННй к
$numННл м
,ННм н
DateTimeKindННо ║
.НН║ ╗
UnspecifiedНН╗ ╞
)НН╞ ╟
,НН╟ ╚
newНН╔ ╠
TimeSpanНН═ ╒
(НН╒ ╓
$numНН╓ ╫
,НН╫ ╪
$numНН┘ ┌
,НН┌ █
$numНН▄ ▌
,НН▌ ▐
$numНН▀ р
,ННр с
$numННт у
)ННу ф
)ННф х
,ННх ц
nullННч ы
,ННы ь
$numННэ ю
,ННю я
nullННЁ Ї
,ННЇ ї
$numННЎ ў
}НН° ∙
}
ОО 
)
ОО 
;
ОО 
migrationBuilder
РР 
.
РР 

InsertData
РР '
(
РР' (
table
СС 
:
СС 
$str
СС $
,
СС$ %
columns
ТТ 
:
ТТ 
new
ТТ 
[
ТТ 
]
ТТ 
{
ТТ  
$str
ТТ! %
,
ТТ% &
$str
ТТ' 0
,
ТТ0 1
$str
ТТ2 ;
,
ТТ; <
$str
ТТ= H
,
ТТH I
$str
ТТJ U
,
ТТU V
$str
ТТW e
,
ТТe f
$str
ТТg w
,
ТТw x
$strТТy Л
,ТТЛ М
$strТТН Э
,ТТЭ Ю
$strТТЯ ░
,ТТ░ ▒
$strТТ▓ ║
}ТТ╗ ╝
,ТТ╝ ╜
values
УУ 
:
УУ 
new
УУ 
object
УУ "
[
УУ" #
,
УУ# $
]
УУ$ %
{
ФФ 
{
ХХ 
new
ХХ 
Guid
ХХ 
(
ХХ 
$str
ХХ E
)
ХХE F
,
ХХF G
$str
ХХH P
,
ХХP Q
new
ХХR U
DateTimeOffset
ХХV d
(
ХХd e
new
ХХe h
DateTime
ХХi q
(
ХХq r
$num
ХХr s
,
ХХs t
$num
ХХu v
,
ХХv w
$num
ХХx y
,
ХХy z
$num
ХХ{ |
,
ХХ| }
$num
ХХ~ 
,ХХ А
$numХХБ В
,ХХВ Г
$numХХД Е
,ХХЕ Ж
DateTimeKindХХЗ У
.ХХУ Ф
UnspecifiedХХФ Я
)ХХЯ а
,ХХа б
newХХв е
TimeSpanХХж о
(ХХо п
$numХХп ░
,ХХ░ ▒
$numХХ▓ │
,ХХ│ ┤
$numХХ╡ ╢
,ХХ╢ ╖
$numХХ╕ ╣
,ХХ╣ ║
$numХХ╗ ╝
)ХХ╝ ╜
)ХХ╜ ╛
,ХХ╛ ┐
nullХХ└ ─
,ХХ─ ┼
falseХХ╞ ╦
,ХХ╦ ╠
newХХ═ ╨
DateTimeOffsetХХ╤ ▀
(ХХ▀ р
newХХр у
DateTimeХХф ь
(ХХь э
$numХХэ ю
,ХХю я
$numХХЁ ё
,ХХё Є
$numХХє Ї
,ХХЇ ї
$numХХЎ ў
,ХХў °
$numХХ∙ ·
,ХХ· √
$numХХ№ ¤
,ХХ¤ ■
$numХХ  А
,ХХА Б
DateTimeKindХХВ О
.ХХО П
UnspecifiedХХП Ъ
)ХХЪ Ы
,ХХЫ Ь
newХХЭ а
TimeSpanХХб й
(ХХй к
$numХХк л
,ХХл м
$numХХн о
,ХХо п
$numХХ░ ▒
,ХХ▒ ▓
$numХХ│ ┤
,ХХ┤ ╡
$numХХ╢ ╖
)ХХ╖ ╕
)ХХ╕ ╣
,ХХ╣ ║
nullХХ╗ ┐
,ХХ┐ └
$strХХ┴ ╔
,ХХ╔ ╩
$strХХ╦ ▀
,ХХ▀ р
$strХХс э
,ХХэ ю
(ХХя Ё
byteХХЁ Ї
)ХХЇ ї
$numХХї Ў
}ХХў °
,ХХ° ∙
{
ЦЦ 
new
ЦЦ 
Guid
ЦЦ 
(
ЦЦ 
$str
ЦЦ E
)
ЦЦE F
,
ЦЦF G
$str
ЦЦH Q
,
ЦЦQ R
new
ЦЦS V
DateTimeOffset
ЦЦW e
(
ЦЦe f
new
ЦЦf i
DateTime
ЦЦj r
(
ЦЦr s
$num
ЦЦs t
,
ЦЦt u
$num
ЦЦv w
,
ЦЦw x
$num
ЦЦy z
,
ЦЦz {
$num
ЦЦ| }
,
ЦЦ} ~
$numЦЦ А
,ЦЦА Б
$numЦЦВ Г
,ЦЦГ Д
$numЦЦЕ Ж
,ЦЦЖ З
DateTimeKindЦЦИ Ф
.ЦЦФ Х
UnspecifiedЦЦХ а
)ЦЦа б
,ЦЦб в
newЦЦг ж
TimeSpanЦЦз п
(ЦЦп ░
$numЦЦ░ ▒
,ЦЦ▒ ▓
$numЦЦ│ ┤
,ЦЦ┤ ╡
$numЦЦ╢ ╖
,ЦЦ╖ ╕
$numЦЦ╣ ║
,ЦЦ║ ╗
$numЦЦ╝ ╜
)ЦЦ╜ ╛
)ЦЦ╛ ┐
,ЦЦ┐ └
nullЦЦ┴ ┼
,ЦЦ┼ ╞
falseЦЦ╟ ╠
,ЦЦ╠ ═
newЦЦ╬ ╤
DateTimeOffsetЦЦ╥ р
(ЦЦр с
newЦЦс ф
DateTimeЦЦх э
(ЦЦэ ю
$numЦЦю я
,ЦЦя Ё
$numЦЦё Є
,ЦЦЄ є
$numЦЦЇ ї
,ЦЦї Ў
$numЦЦў °
,ЦЦ° ∙
$numЦЦ· √
,ЦЦ√ №
$numЦЦ¤ ■
,ЦЦ■  
$numЦЦА Б
,ЦЦБ В
DateTimeKindЦЦГ П
.ЦЦП Р
UnspecifiedЦЦР Ы
)ЦЦЫ Ь
,ЦЦЬ Э
newЦЦЮ б
TimeSpanЦЦв к
(ЦЦк л
$numЦЦл м
,ЦЦм н
$numЦЦо п
,ЦЦп ░
$numЦЦ▒ ▓
,ЦЦ▓ │
$numЦЦ┤ ╡
,ЦЦ╡ ╢
$numЦЦ╖ ╕
)ЦЦ╕ ╣
)ЦЦ╣ ║
,ЦЦ║ ╗
nullЦЦ╝ └
,ЦЦ└ ┴
$strЦЦ┬ ╩
,ЦЦ╩ ╦
$strЦЦ╠ ┌
,ЦЦ┌ █
$strЦЦ▄ ш
,ЦЦш щ
(ЦЦъ ы
byteЦЦы я
)ЦЦя Ё
$numЦЦЁ ё
}ЦЦЄ є
}
ЧЧ 
)
ЧЧ 
;
ЧЧ 
migrationBuilder
ЩЩ 
.
ЩЩ 

InsertData
ЩЩ '
(
ЩЩ' (
table
ЪЪ 
:
ЪЪ 
$str
ЪЪ 
,
ЪЪ  
columns
ЫЫ 
:
ЫЫ 
new
ЫЫ 
[
ЫЫ 
]
ЫЫ 
{
ЫЫ  
$str
ЫЫ! %
,
ЫЫ% &
$str
ЫЫ' 2
,
ЫЫ2 3
$str
ЫЫ4 =
,
ЫЫ= >
$str
ЫЫ? J
,
ЫЫJ K
$str
ЫЫL Y
,
ЫЫY Z
$str
ЫЫ[ f
,
ЫЫf g
$str
ЫЫh v
,
ЫЫv w
$strЫЫx И
,ЫЫИ Й
$strЫЫК Щ
,ЫЫЩ Ъ
$strЫЫЫ в
,ЫЫв г
$strЫЫд о
,ЫЫо п
$strЫЫ░ ╛
,ЫЫ╛ ┐
$strЫЫ└ ╚
}ЫЫ╔ ╩
,ЫЫ╩ ╦
values
ЬЬ 
:
ЬЬ 
new
ЬЬ 
object
ЬЬ "
[
ЬЬ" #
,
ЬЬ# $
]
ЬЬ$ %
{
ЭЭ 
{
ЮЮ 
new
ЮЮ 
Guid
ЮЮ 
(
ЮЮ 
$str
ЮЮ E
)
ЮЮE F
,
ЮЮF G
$str
ЮЮH Q
,
ЮЮQ R
new
ЮЮS V
DateTimeOffset
ЮЮW e
(
ЮЮe f
new
ЮЮf i
DateTime
ЮЮj r
(
ЮЮr s
$num
ЮЮs t
,
ЮЮt u
$num
ЮЮv w
,
ЮЮw x
$num
ЮЮy z
,
ЮЮz {
$num
ЮЮ| }
,
ЮЮ} ~
$numЮЮ А
,ЮЮА Б
$numЮЮВ Г
,ЮЮГ Д
$numЮЮЕ Ж
,ЮЮЖ З
DateTimeKindЮЮИ Ф
.ЮЮФ Х
UnspecifiedЮЮХ а
)ЮЮа б
,ЮЮб в
newЮЮг ж
TimeSpanЮЮз п
(ЮЮп ░
$numЮЮ░ ▒
,ЮЮ▒ ▓
$numЮЮ│ ┤
,ЮЮ┤ ╡
$numЮЮ╢ ╖
,ЮЮ╖ ╕
$numЮЮ╣ ║
,ЮЮ║ ╗
$numЮЮ╝ ╜
)ЮЮ╜ ╛
)ЮЮ╛ ┐
,ЮЮ┐ └
nullЮЮ┴ ┼
,ЮЮ┼ ╞
newЮЮ╟ ╩
DateTimeЮЮ╦ ╙
(ЮЮ╙ ╘
$numЮЮ╘ ╪
,ЮЮ╪ ┘
$numЮЮ┌ ▄
,ЮЮ▄ ▌
$numЮЮ▐ р
,ЮЮр с
$numЮЮт у
,ЮЮу ф
$numЮЮх ч
,ЮЮч ш
$numЮЮщ ъ
,ЮЮъ ы
$numЮЮь я
,ЮЮя Ё
DateTimeKindЮЮё ¤
.ЮЮ¤ ■
UtcЮЮ■ Б
)ЮЮБ В
.ЮЮВ Г
AddTicksЮЮГ Л
(ЮЮЛ М
$numЮЮМ Р
)ЮЮР С
,ЮЮС Т
falseЮЮУ Ш
,ЮЮШ Щ
newЮЮЪ Э
DateTimeOffsetЮЮЮ м
(ЮЮм н
newЮЮн ░
DateTimeЮЮ▒ ╣
(ЮЮ╣ ║
$numЮЮ║ ╗
,ЮЮ╗ ╝
$numЮЮ╜ ╛
,ЮЮ╛ ┐
$numЮЮ└ ┴
,ЮЮ┴ ┬
$numЮЮ├ ─
,ЮЮ─ ┼
$numЮЮ╞ ╟
,ЮЮ╟ ╚
$numЮЮ╔ ╩
,ЮЮ╩ ╦
$numЮЮ╠ ═
,ЮЮ═ ╬
DateTimeKindЮЮ╧ █
.ЮЮ█ ▄
UnspecifiedЮЮ▄ ч
)ЮЮч ш
,ЮЮш щ
newЮЮъ э
TimeSpanЮЮю Ў
(ЮЮЎ ў
$numЮЮў °
,ЮЮ° ∙
$numЮЮ· √
,ЮЮ√ №
$numЮЮ¤ ■
,ЮЮ■  
$numЮЮА Б
,ЮЮБ В
$numЮЮГ Д
)ЮЮД Е
)ЮЮЕ Ж
,ЮЮЖ З
nullЮЮИ М
,ЮЮМ Н
$numЮЮО Т
,ЮЮТ У
$numЮЮФ Ъ
,ЮЮЪ Ы
$numЮЮЬ Ю
,ЮЮЮ Я
newЮЮа г
GuidЮЮд и
(ЮЮи й
$strЮЮй ╧
)ЮЮ╧ ╨
,ЮЮ╨ ╤
(ЮЮ╥ ╙
byteЮЮ╙ ╫
)ЮЮ╫ ╪
$numЮЮ╪ ┘
}ЮЮ┌ █
,ЮЮ█ ▄
{
ЯЯ 
new
ЯЯ 
Guid
ЯЯ 
(
ЯЯ 
$str
ЯЯ E
)
ЯЯE F
,
ЯЯF G
$str
ЯЯH Q
,
ЯЯQ R
new
ЯЯS V
DateTimeOffset
ЯЯW e
(
ЯЯe f
new
ЯЯf i
DateTime
ЯЯj r
(
ЯЯr s
$num
ЯЯs t
,
ЯЯt u
$num
ЯЯv w
,
ЯЯw x
$num
ЯЯy z
,
ЯЯz {
$num
ЯЯ| }
,
ЯЯ} ~
$numЯЯ А
,ЯЯА Б
$numЯЯВ Г
,ЯЯГ Д
$numЯЯЕ Ж
,ЯЯЖ З
DateTimeKindЯЯИ Ф
.ЯЯФ Х
UnspecifiedЯЯХ а
)ЯЯа б
,ЯЯб в
newЯЯг ж
TimeSpanЯЯз п
(ЯЯп ░
$numЯЯ░ ▒
,ЯЯ▒ ▓
$numЯЯ│ ┤
,ЯЯ┤ ╡
$numЯЯ╢ ╖
,ЯЯ╖ ╕
$numЯЯ╣ ║
,ЯЯ║ ╗
$numЯЯ╝ ╜
)ЯЯ╜ ╛
)ЯЯ╛ ┐
,ЯЯ┐ └
nullЯЯ┴ ┼
,ЯЯ┼ ╞
newЯЯ╟ ╩
DateTimeЯЯ╦ ╙
(ЯЯ╙ ╘
$numЯЯ╘ ╪
,ЯЯ╪ ┘
$numЯЯ┌ ▄
,ЯЯ▄ ▌
$numЯЯ▐ р
,ЯЯр с
$numЯЯт у
,ЯЯу ф
$numЯЯх ч
,ЯЯч ш
$numЯЯщ ъ
,ЯЯъ ы
$numЯЯь я
,ЯЯя Ё
DateTimeKindЯЯё ¤
.ЯЯ¤ ■
UtcЯЯ■ Б
)ЯЯБ В
.ЯЯВ Г
AddTicksЯЯГ Л
(ЯЯЛ М
$numЯЯМ Р
)ЯЯР С
,ЯЯС Т
falseЯЯУ Ш
,ЯЯШ Щ
newЯЯЪ Э
DateTimeOffsetЯЯЮ м
(ЯЯм н
newЯЯн ░
DateTimeЯЯ▒ ╣
(ЯЯ╣ ║
$numЯЯ║ ╗
,ЯЯ╗ ╝
$numЯЯ╜ ╛
,ЯЯ╛ ┐
$numЯЯ└ ┴
,ЯЯ┴ ┬
$numЯЯ├ ─
,ЯЯ─ ┼
$numЯЯ╞ ╟
,ЯЯ╟ ╚
$numЯЯ╔ ╩
,ЯЯ╩ ╦
$numЯЯ╠ ═
,ЯЯ═ ╬
DateTimeKindЯЯ╧ █
.ЯЯ█ ▄
UnspecifiedЯЯ▄ ч
)ЯЯч ш
,ЯЯш щ
newЯЯъ э
TimeSpanЯЯю Ў
(ЯЯЎ ў
$numЯЯў °
,ЯЯ° ∙
$numЯЯ· √
,ЯЯ√ №
$numЯЯ¤ ■
,ЯЯ■  
$numЯЯА Б
,ЯЯБ В
$numЯЯГ Д
)ЯЯД Е
)ЯЯЕ Ж
,ЯЯЖ З
nullЯЯИ М
,ЯЯМ Н
$numЯЯО Т
,ЯЯТ У
$numЯЯФ Ъ
,ЯЯЪ Ы
$numЯЯЬ Ю
,ЯЯЮ Я
newЯЯа г
GuidЯЯд и
(ЯЯи й
$strЯЯй ╧
)ЯЯ╧ ╨
,ЯЯ╨ ╤
(ЯЯ╥ ╙
byteЯЯ╙ ╫
)ЯЯ╫ ╪
$numЯЯ╪ ┘
}ЯЯ┌ █
,ЯЯ█ ▄
{
аа 
new
аа 
Guid
аа 
(
аа 
$str
аа E
)
ааE F
,
ааF G
$str
ааH Q
,
ааQ R
new
ааS V
DateTimeOffset
ааW e
(
ааe f
new
ааf i
DateTime
ааj r
(
ааr s
$num
ааs t
,
ааt u
$num
ааv w
,
ааw x
$num
ааy z
,
ааz {
$num
аа| }
,
аа} ~
$numаа А
,ааА Б
$numааВ Г
,ааГ Д
$numааЕ Ж
,ааЖ З
DateTimeKindааИ Ф
.ааФ Х
UnspecifiedааХ а
)ааа б
,ааб в
newааг ж
TimeSpanааз п
(аап ░
$numаа░ ▒
,аа▒ ▓
$numаа│ ┤
,аа┤ ╡
$numаа╢ ╖
,аа╖ ╕
$numаа╣ ║
,аа║ ╗
$numаа╝ ╜
)аа╜ ╛
)аа╛ ┐
,аа┐ └
nullаа┴ ┼
,аа┼ ╞
newаа╟ ╩
DateTimeаа╦ ╙
(аа╙ ╘
$numаа╘ ╪
,аа╪ ┘
$numаа┌ ▄
,аа▄ ▌
$numаа▐ р
,аар с
$numаат у
,аау ф
$numаах ч
,аач ш
$numаащ ъ
,ааъ ы
$numааь я
,аая Ё
DateTimeKindааё ¤
.аа¤ ■
Utcаа■ Б
)ааБ В
.ааВ Г
AddTicksааГ Л
(ааЛ М
$numааМ Р
)ааР С
,ааС Т
falseааУ Ш
,ааШ Щ
newааЪ Э
DateTimeOffsetааЮ м
(аам н
newаан ░
DateTimeаа▒ ╣
(аа╣ ║
$numаа║ ╗
,аа╗ ╝
$numаа╜ ╛
,аа╛ ┐
$numаа└ ┴
,аа┴ ┬
$numаа├ ─
,аа─ ┼
$numаа╞ ╟
,аа╟ ╚
$numаа╔ ╩
,аа╩ ╦
$numаа╠ ═
,аа═ ╬
DateTimeKindаа╧ █
.аа█ ▄
Unspecifiedаа▄ ч
)аач ш
,ааш щ
newааъ э
TimeSpanааю Ў
(ааЎ ў
$numааў °
,аа° ∙
$numаа· √
,аа√ №
$numаа¤ ■
,аа■  
$numааА Б
,ааБ В
$numааГ Д
)ааД Е
)ааЕ Ж
,ааЖ З
nullааИ М
,ааМ Н
$numааО У
,ааУ Ф
$numааХ Ы
,ааЫ Ь
$numааЭ Я
,ааЯ а
newааб д
Guidаае й
(аай к
$strаак ╨
)аа╨ ╤
,аа╤ ╥
(аа╙ ╘
byteаа╘ ╪
)аа╪ ┘
$numаа┘ ┌
}аа█ ▄
}
бб 
)
бб 
;
бб 
migrationBuilder
гг 
.
гг 

InsertData
гг '
(
гг' (
table
дд 
:
дд 
$str
дд "
,
дд" #
columns
ее 
:
ее 
new
ее 
[
ее 
]
ее 
{
ее  
$str
ее! %
,
ее% &
$str
ее' 0
,
ее0 1
$str
ее2 =
,
ее= >
$str
ее? M
,
ееM N
$str
ееO Y
,
ееY Z
$str
ее[ f
,
ееf g
$str
ееh v
,
ееv w
$strееx И
,ееИ Й
$strееК Ш
,ееШ Щ
$strееЪ в
}еег д
,еед е
values
жж 
:
жж 
new
жж 
object
жж "
[
жж" #
,
жж# $
]
жж$ %
{
зз 
{
ии 
new
ии 
Guid
ии 
(
ии 
$str
ии E
)
ииE F
,
ииF G
new
ииH K
DateTimeOffset
ииL Z
(
ииZ [
new
ии[ ^
DateTime
ии_ g
(
ииg h
$num
ииh l
,
ииl m
$num
ииn o
,
ииo p
$num
ииq s
,
ииs t
$num
ииu v
,
ииv w
$num
ииx z
,
ииz {
$num
ии| }
,
ии} ~
$numии А
,ииА Б
DateTimeKindииВ О
.ииО П
UnspecifiedииП Ъ
)ииЪ Ы
,ииЫ Ь
newииЭ а
TimeSpanииб й
(иий к
$numиик л
,иил м
$numиин о
,иио п
$numии░ ▒
,ии▒ ▓
$numии│ ┤
,ии┤ ╡
$numии╢ ╖
)ии╖ ╕
)ии╕ ╣
,ии╣ ║
$strии╗ ─
,ии─ ┼
$strии╞ ╬
,ии╬ ╧
newии╨ ╙
DateTimeии╘ ▄
(ии▄ ▌
$numии▌ с
,иис т
$numииу ф
,ииф х
$numииц ш
,ииш щ
$numииъ ы
,ииы ь
$numииэ я
,иия Ё
$numииё Є
,ииЄ є
$numииЇ ў
,ииў °
DateTimeKindии∙ Е
.ииЕ Ж
UtcииЖ Й
)ииЙ К
.ииК Л
AddTicksииЛ У
(ииУ Ф
$numииФ Ш
)ииШ Щ
,ииЩ Ъ
falseииЫ а
,ииа б
newиив е
DateTimeOffsetииж ┤
(ии┤ ╡
newии╡ ╕
DateTimeии╣ ┴
(ии┴ ┬
$numии┬ ╞
,ии╞ ╟
$numии╚ ╔
,ии╔ ╩
$numии╦ ═
,ии═ ╬
$numии╧ ╨
,ии╨ ╤
$numии╥ ╘
,ии╘ ╒
$numии╓ ╫
,ии╫ ╪
$numии┘ ┌
,ии┌ █
DateTimeKindии▄ ш
.ииш щ
Unspecifiedиищ Ї
)ииЇ ї
,ииї Ў
newииў ·
TimeSpanии√ Г
(ииГ Д
$numииД Е
,ииЕ Ж
$numииЗ И
,ииИ Й
$numииК Л
,ииЛ М
$numииН О
,ииО П
$numииР С
)ииС Т
)ииТ У
,ииУ Ф
$strииХ Ю
,ииЮ Я
newииа г
Guidиид и
(иии й
$strиий ╧
)ии╧ ╨
,ии╨ ╤
$strии╥ °
}ии∙ ·
,ии· √
{
йй 
new
йй 
Guid
йй 
(
йй 
$str
йй E
)
ййE F
,
ййF G
new
ййH K
DateTimeOffset
ййL Z
(
ййZ [
new
йй[ ^
DateTime
йй_ g
(
ййg h
$num
ййh l
,
ййl m
$num
ййn o
,
ййo p
$num
ййq s
,
ййs t
$num
ййu w
,
ййw x
$num
ййy z
,
ййz {
$num
йй| }
,
йй} ~
$numйй А
,ййА Б
DateTimeKindййВ О
.ййО П
UnspecifiedййП Ъ
)ййЪ Ы
,ййЫ Ь
newййЭ а
TimeSpanййб й
(ййй к
$numййк л
,ййл м
$numййн о
,ййо п
$numйй░ ▒
,йй▒ ▓
$numйй│ ┤
,йй┤ ╡
$numйй╢ ╖
)йй╖ ╕
)йй╕ ╣
,йй╣ ║
$strйй╗ ┬
,йй┬ ├
$strйй─ ╠
,йй╠ ═
newйй╬ ╤
DateTimeйй╥ ┌
(йй┌ █
$numйй█ ▀
,йй▀ р
$numййс т
,ййт у
$numййф ц
,ййц ч
$numййш щ
,ййщ ъ
$numййы э
,ййэ ю
$numййя Ё
,ййЁ ё
$numййЄ ї
,ййї Ў
DateTimeKindййў Г
.ййГ Д
UtcййД З
)ййЗ И
.ййИ Й
AddTicksййЙ С
(ййС Т
$numййТ Ц
)ййЦ Ч
,ййЧ Ш
falseййЩ Ю
,ййЮ Я
newййа г
DateTimeOffsetййд ▓
(йй▓ │
newйй│ ╢
DateTimeйй╖ ┐
(йй┐ └
$numйй└ ─
,йй─ ┼
$numйй╞ ╟
,йй╟ ╚
$numйй╔ ╦
,йй╦ ╠
$numйй═ ╧
,йй╧ ╨
$numйй╤ ╥
,йй╥ ╙
$numйй╘ ╒
,йй╒ ╓
$numйй╫ ╪
,йй╪ ┘
DateTimeKindйй┌ ц
.ййц ч
Unspecifiedййч Є
)ййЄ є
,ййє Ї
newййї °
TimeSpanйй∙ Б
(ййБ В
$numййВ Г
,ййГ Д
$numййЕ Ж
,ййЖ З
$numййИ Й
,ййЙ К
$numййЛ М
,ййМ Н
$numййО П
)ййП Р
)ййР С
,ййС Т
$strййУ Ъ
,ййЪ Ы
newййЬ Я
Guidййа д
(ййд е
$strййе ╦
)йй╦ ╠
,йй╠ ═
$strйй╬ Ї
}ййї Ў
,ййЎ ў
{
кк 
new
кк 
Guid
кк 
(
кк 
$str
кк E
)
ккE F
,
ккF G
new
ккH K
DateTimeOffset
ккL Z
(
ккZ [
new
кк[ ^
DateTime
кк_ g
(
ккg h
$num
ккh l
,
ккl m
$num
ккn o
,
ккo p
$num
ккq s
,
ккs t
$num
ккu w
,
ккw x
$num
ккy {
,
кк{ |
$num
кк} ~
,
кк~ 
$numккА Б
,ккБ В
DateTimeKindккГ П
.ккП Р
UnspecifiedккР Ы
)ккЫ Ь
,ккЬ Э
newккЮ б
TimeSpanккв к
(ккк л
$numккл м
,ккм н
$numкко п
,ккп ░
$numкк▒ ▓
,кк▓ │
$numкк┤ ╡
,кк╡ ╢
$numкк╖ ╕
)кк╕ ╣
)кк╣ ║
,кк║ ╗
$strкк╝ ├
,кк├ ─
$strкк┼ ═
,кк═ ╬
newкк╧ ╥
DateTimeкк╙ █
(кк█ ▄
$numкк▄ р
,ккр с
$numккт у
,кку ф
$numккх ч
,ккч ш
$numккщ ъ
,ккъ ы
$numккь ю
,ккю я
$numккЁ ё
,ккё Є
$numккє Ў
,ккЎ ў
DateTimeKindкк° Д
.ккД Е
UtcккЕ И
)ккИ Й
.ккЙ К
AddTicksккК Т
(ккТ У
$numккУ Ч
)ккЧ Ш
,ккШ Щ
falseккЪ Я
,ккЯ а
newккб д
DateTimeOffsetкке │
(кк│ ┤
newкк┤ ╖
DateTimeкк╕ └
(кк└ ┴
$numкк┴ ┼
,кк┼ ╞
$numкк╟ ╚
,кк╚ ╔
$numкк╩ ╠
,кк╠ ═
$numкк╬ ╨
,кк╨ ╤
$numкк╥ ╘
,кк╘ ╒
$numкк╓ ╫
,кк╫ ╪
$numкк┘ ┌
,кк┌ █
DateTimeKindкк▄ ш
.ккш щ
Unspecifiedккщ Ї
)ккЇ ї
,ккї Ў
newккў ·
TimeSpanкк√ Г
(ккГ Д
$numккД Е
,ккЕ Ж
$numккЗ И
,ккИ Й
$numккК Л
,ккЛ М
$numккН О
,ккО П
$numккР С
)ккС Т
)ккТ У
,ккУ Ф
$strккХ Ь
,ккЬ Э
newккЮ б
Guidккв ж
(ккж з
$strккз ═
)кк═ ╬
,кк╬ ╧
$strкк╨ Ў
}ккў °
}
лл 
)
лл 
;
лл 
migrationBuilder
нн 
.
нн 

InsertData
нн '
(
нн' (
table
оо 
:
оо 
$str
оо #
,
оо# $
columns
пп 
:
пп 
new
пп 
[
пп 
]
пп 
{
пп  
$str
пп! %
,
пп% &
$str
пп' 0
,
пп0 1
$str
пп2 =
,
пп= >
$str
пп? J
,
ппJ K
$str
ппL Z
,
ппZ [
$str
пп\ l
,
ппl m
$str
ппn |
}
пп} ~
,
пп~ 
values
░░ 
:
░░ 
new
░░ 
object
░░ "
[
░░" #
]
░░# $
{
░░% &
new
░░' *
Guid
░░+ /
(
░░/ 0
$str
░░0 V
)
░░V W
,
░░W X
new
░░Y \
DateTimeOffset
░░] k
(
░░k l
new
░░l o
DateTime
░░p x
(
░░x y
$num
░░y z
,
░░z {
$num
░░| }
,
░░} ~
$num░░ А
,░░А Б
$num░░В Г
,░░Г Д
$num░░Е Ж
,░░Ж З
$num░░И Й
,░░Й К
$num░░Л М
,░░М Н
DateTimeKind░░О Ъ
.░░Ъ Ы
Unspecified░░Ы ж
)░░ж з
,░░з и
new░░й м
TimeSpan░░н ╡
(░░╡ ╢
$num░░╢ ╖
,░░╖ ╕
$num░░╣ ║
,░░║ ╗
$num░░╝ ╜
,░░╜ ╛
$num░░┐ └
,░░└ ┴
$num░░┬ ├
)░░├ ─
)░░─ ┼
,░░┼ ╞
null░░╟ ╦
,░░╦ ╠
$str░░═ ▀
,░░▀ р
new░░с ф
DateTimeOffset░░х є
(░░є Ї
new░░Ї ў
DateTime░░° А
(░░А Б
$num░░Б В
,░░В Г
$num░░Д Е
,░░Е Ж
$num░░З И
,░░И Й
$num░░К Л
,░░Л М
$num░░Н О
,░░О П
$num░░Р С
,░░С Т
$num░░У Ф
,░░Ф Х
DateTimeKind░░Ц в
.░░в г
Unspecified░░г о
)░░о п
,░░п ░
new░░▒ ┤
TimeSpan░░╡ ╜
(░░╜ ╛
$num░░╛ ┐
,░░┐ └
$num░░┴ ┬
,░░┬ ├
$num░░─ ┼
,░░┼ ╞
$num░░╟ ╚
,░░╚ ╔
$num░░╩ ╦
)░░╦ ╠
)░░╠ ═
,░░═ ╬
null░░╧ ╙
,░░╙ ╘
new░░╒ ╪
Guid░░┘ ▌
(░░▌ ▐
$str░░▐ Д
)░░Д Е
}░░Ж З
)░░З И
;░░И Й
migrationBuilder
▓▓ 
.
▓▓ 

InsertData
▓▓ '
(
▓▓' (
table
││ 
:
││ 
$str
││ +
,
││+ ,
columns
┤┤ 
:
┤┤ 
new
┤┤ 
[
┤┤ 
]
┤┤ 
{
┤┤  
$str
┤┤! %
,
┤┤% &
$str
┤┤' 0
,
┤┤0 1
$str
┤┤2 =
,
┤┤= >
$str
┤┤? V
,
┤┤V W
$str
┤┤X k
,
┤┤k l
$str
┤┤m }
,
┤┤} ~
$str┤┤ С
,┤┤С Т
$str┤┤У Ю
,┤┤Ю Я
$str┤┤а о
,┤┤о п
$str┤┤░ └
}┤┤┴ ┬
,┤┤┬ ├
values
╡╡ 
:
╡╡ 
new
╡╡ 
object
╡╡ "
[
╡╡" #
,
╡╡# $
]
╡╡$ %
{
╢╢ 
{
╖╖ 
new
╖╖ 
Guid
╖╖ 
(
╖╖ 
$str
╖╖ E
)
╖╖E F
,
╖╖F G
new
╖╖H K
DateTimeOffset
╖╖L Z
(
╖╖Z [
new
╖╖[ ^
DateTime
╖╖_ g
(
╖╖g h
$num
╖╖h i
,
╖╖i j
$num
╖╖k l
,
╖╖l m
$num
╖╖n o
,
╖╖o p
$num
╖╖q r
,
╖╖r s
$num
╖╖t u
,
╖╖u v
$num
╖╖w x
,
╖╖x y
$num
╖╖z {
,
╖╖{ |
DateTimeKind╖╖} Й
.╖╖Й К
Unspecified╖╖К Х
)╖╖Х Ц
,╖╖Ц Ч
new╖╖Ш Ы
TimeSpan╖╖Ь д
(╖╖д е
$num╖╖е ж
,╖╖ж з
$num╖╖и й
,╖╖й к
$num╖╖л м
,╖╖м н
$num╖╖о п
,╖╖п ░
$num╖╖▒ ▓
)╖╖▓ │
)╖╖│ ┤
,╖╖┤ ╡
null╖╖╢ ║
,╖╖║ ╗
$str╖╖╝ ■
,╖╖■  
(╖╖А Б
byte╖╖Б Е
)╖╖Е Ж
$num╖╖Ж З
,╖╖З И
$str╖╖Й Р
,╖╖Р С
new╖╖Т Х
Guid╖╖Ц Ъ
(╖╖Ъ Ы
$str╖╖Ы ┴
)╖╖┴ ┬
,╖╖┬ ├
false╖╖─ ╔
,╖╖╔ ╩
new╖╖╦ ╬
DateTimeOffset╖╖╧ ▌
(╖╖▌ ▐
new╖╖▐ с
DateTime╖╖т ъ
(╖╖ъ ы
$num╖╖ы ь
,╖╖ь э
$num╖╖ю я
,╖╖я Ё
$num╖╖ё Є
,╖╖Є є
$num╖╖Ї ї
,╖╖ї Ў
$num╖╖ў °
,╖╖° ∙
$num╖╖· √
,╖╖√ №
$num╖╖¤ ■
,╖╖■  
DateTimeKind╖╖А М
.╖╖М Н
Unspecified╖╖Н Ш
)╖╖Ш Щ
,╖╖Щ Ъ
new╖╖Ы Ю
TimeSpan╖╖Я з
(╖╖з и
$num╖╖и й
,╖╖й к
$num╖╖л м
,╖╖м н
$num╖╖о п
,╖╖п ░
$num╖╖▒ ▓
,╖╖▓ │
$num╖╖┤ ╡
)╖╖╡ ╢
)╖╖╢ ╖
,╖╖╖ ╕
null╖╖╣ ╜
}╖╖╛ ┐
,╖╖┐ └
{
╕╕ 
new
╕╕ 
Guid
╕╕ 
(
╕╕ 
$str
╕╕ E
)
╕╕E F
,
╕╕F G
new
╕╕H K
DateTimeOffset
╕╕L Z
(
╕╕Z [
new
╕╕[ ^
DateTime
╕╕_ g
(
╕╕g h
$num
╕╕h i
,
╕╕i j
$num
╕╕k l
,
╕╕l m
$num
╕╕n o
,
╕╕o p
$num
╕╕q r
,
╕╕r s
$num
╕╕t u
,
╕╕u v
$num
╕╕w x
,
╕╕x y
$num
╕╕z {
,
╕╕{ |
DateTimeKind╕╕} Й
.╕╕Й К
Unspecified╕╕К Х
)╕╕Х Ц
,╕╕Ц Ч
new╕╕Ш Ы
TimeSpan╕╕Ь д
(╕╕д е
$num╕╕е ж
,╕╕ж з
$num╕╕и й
,╕╕й к
$num╕╕л м
,╕╕м н
$num╕╕о п
,╕╕п ░
$num╕╕▒ ▓
)╕╕▓ │
)╕╕│ ┤
,╕╕┤ ╡
null╕╕╢ ║
,╕╕║ ╗
$str╕╕╝  
,╕╕  А
(╕╕Б В
byte╕╕В Ж
)╕╕Ж З
$num╕╕З И
,╕╕И Й
$str╕╕К Р
,╕╕Р С
new╕╕Т Х
Guid╕╕Ц Ъ
(╕╕Ъ Ы
$str╕╕Ы ┴
)╕╕┴ ┬
,╕╕┬ ├
false╕╕─ ╔
,╕╕╔ ╩
new╕╕╦ ╬
DateTimeOffset╕╕╧ ▌
(╕╕▌ ▐
new╕╕▐ с
DateTime╕╕т ъ
(╕╕ъ ы
$num╕╕ы ь
,╕╕ь э
$num╕╕ю я
,╕╕я Ё
$num╕╕ё Є
,╕╕Є є
$num╕╕Ї ї
,╕╕ї Ў
$num╕╕ў °
,╕╕° ∙
$num╕╕· √
,╕╕√ №
$num╕╕¤ ■
,╕╕■  
DateTimeKind╕╕А М
.╕╕М Н
Unspecified╕╕Н Ш
)╕╕Ш Щ
,╕╕Щ Ъ
new╕╕Ы Ю
TimeSpan╕╕Я з
(╕╕з и
$num╕╕и й
,╕╕й к
$num╕╕л м
,╕╕м н
$num╕╕о п
,╕╕п ░
$num╕╕▒ ▓
,╕╕▓ │
$num╕╕┤ ╡
)╕╕╡ ╢
)╕╕╢ ╖
,╕╕╖ ╕
null╕╕╣ ╜
}╕╕╛ ┐
,╕╕┐ └
{
╣╣ 
new
╣╣ 
Guid
╣╣ 
(
╣╣ 
$str
╣╣ E
)
╣╣E F
,
╣╣F G
new
╣╣H K
DateTimeOffset
╣╣L Z
(
╣╣Z [
new
╣╣[ ^
DateTime
╣╣_ g
(
╣╣g h
$num
╣╣h i
,
╣╣i j
$num
╣╣k l
,
╣╣l m
$num
╣╣n o
,
╣╣o p
$num
╣╣q r
,
╣╣r s
$num
╣╣t u
,
╣╣u v
$num
╣╣w x
,
╣╣x y
$num
╣╣z {
,
╣╣{ |
DateTimeKind╣╣} Й
.╣╣Й К
Unspecified╣╣К Х
)╣╣Х Ц
,╣╣Ц Ч
new╣╣Ш Ы
TimeSpan╣╣Ь д
(╣╣д е
$num╣╣е ж
,╣╣ж з
$num╣╣и й
,╣╣й к
$num╣╣л м
,╣╣м н
$num╣╣о п
,╣╣п ░
$num╣╣▒ ▓
)╣╣▓ │
)╣╣│ ┤
,╣╣┤ ╡
null╣╣╢ ║
,╣╣║ ╗
$str╣╣╝ ■
,╣╣■  
(╣╣А Б
byte╣╣Б Е
)╣╣Е Ж
$num╣╣Ж З
,╣╣З И
$str╣╣Й Т
,╣╣Т У
new╣╣Ф Ч
Guid╣╣Ш Ь
(╣╣Ь Э
$str╣╣Э ├
)╣╣├ ─
,╣╣─ ┼
false╣╣╞ ╦
,╣╣╦ ╠
new╣╣═ ╨
DateTimeOffset╣╣╤ ▀
(╣╣▀ р
new╣╣р у
DateTime╣╣ф ь
(╣╣ь э
$num╣╣э ю
,╣╣ю я
$num╣╣Ё ё
,╣╣ё Є
$num╣╣є Ї
,╣╣Ї ї
$num╣╣Ў ў
,╣╣ў °
$num╣╣∙ ·
,╣╣· √
$num╣╣№ ¤
,╣╣¤ ■
$num╣╣  А
,╣╣А Б
DateTimeKind╣╣В О
.╣╣О П
Unspecified╣╣П Ъ
)╣╣Ъ Ы
,╣╣Ы Ь
new╣╣Э а
TimeSpan╣╣б й
(╣╣й к
$num╣╣к л
,╣╣л м
$num╣╣н о
,╣╣о п
$num╣╣░ ▒
,╣╣▒ ▓
$num╣╣│ ┤
,╣╣┤ ╡
$num╣╣╢ ╖
)╣╣╖ ╕
)╣╣╕ ╣
,╣╣╣ ║
null╣╣╗ ┐
}╣╣└ ┴
}
║║ 
)
║║ 
;
║║ 
migrationBuilder
╝╝ 
.
╝╝ 

InsertData
╝╝ '
(
╝╝' (
table
╜╜ 
:
╜╜ 
$str
╜╜ (
,
╜╜( )
columns
╛╛ 
:
╛╛ 
new
╛╛ 
[
╛╛ 
]
╛╛ 
{
╛╛  
$str
╛╛! %
,
╛╛% &
$str
╛╛' 3
,
╛╛3 4
$str
╛╛5 >
,
╛╛> ?
$str
╛╛@ K
,
╛╛K L
$str
╛╛M X
,
╛╛X Y
$str
╛╛Z c
,
╛╛c d
$str
╛╛e s
,
╛╛s t
$str╛╛u Е
,╛╛Е Ж
$str╛╛З Ы
,╛╛Ы Ь
$str╛╛Э ▓
,╛╛▓ │
$str╛╛┤ ┴
}╛╛┬ ├
,╛╛├ ─
values
┐┐ 
:
┐┐ 
new
┐┐ 
object
┐┐ "
[
┐┐" #
,
┐┐# $
]
┐┐$ %
{
└└ 
{
┴┴ 
new
┴┴ 
Guid
┴┴ 
(
┴┴ 
$str
┴┴ E
)
┴┴E F
,
┴┴F G
new
┴┴H K
Guid
┴┴L P
(
┴┴P Q
$str
┴┴Q w
)
┴┴w x
,
┴┴x y
new
┴┴z }
DateTimeOffset┴┴~ М
(┴┴М Н
new┴┴Н Р
DateTime┴┴С Щ
(┴┴Щ Ъ
$num┴┴Ъ Ы
,┴┴Ы Ь
$num┴┴Э Ю
,┴┴Ю Я
$num┴┴а б
,┴┴б в
$num┴┴г д
,┴┴д е
$num┴┴ж з
,┴┴з и
$num┴┴й к
,┴┴к л
$num┴┴м н
,┴┴н о
DateTimeKind┴┴п ╗
.┴┴╗ ╝
Unspecified┴┴╝ ╟
)┴┴╟ ╚
,┴┴╚ ╔
new┴┴╩ ═
TimeSpan┴┴╬ ╓
(┴┴╓ ╫
$num┴┴╫ ╪
,┴┴╪ ┘
$num┴┴┌ █
,┴┴█ ▄
$num┴┴▌ ▐
,┴┴▐ ▀
$num┴┴р с
,┴┴с т
$num┴┴у ф
)┴┴ф х
)┴┴х ц
,┴┴ц ч
null┴┴ш ь
,┴┴ь э
false┴┴ю є
,┴┴є Ї
true┴┴ї ∙
,┴┴∙ ·
new┴┴√ ■
DateTimeOffset┴┴  Н
(┴┴Н О
new┴┴О С
DateTime┴┴Т Ъ
(┴┴Ъ Ы
$num┴┴Ы Ь
,┴┴Ь Э
$num┴┴Ю Я
,┴┴Я а
$num┴┴б в
,┴┴в г
$num┴┴д е
,┴┴е ж
$num┴┴з и
,┴┴и й
$num┴┴к л
,┴┴л м
$num┴┴н о
,┴┴о п
DateTimeKind┴┴░ ╝
.┴┴╝ ╜
Unspecified┴┴╜ ╚
)┴┴╚ ╔
,┴┴╔ ╩
new┴┴╦ ╬
TimeSpan┴┴╧ ╫
(┴┴╫ ╪
$num┴┴╪ ┘
,┴┴┘ ┌
$num┴┴█ ▄
,┴┴▄ ▌
$num┴┴▐ ▀
,┴┴▀ р
$num┴┴с т
,┴┴т у
$num┴┴ф х
)┴┴х ц
)┴┴ц ч
,┴┴ч ш
null┴┴щ э
,┴┴э ю
$str┴┴я ■
,┴┴■  
$str┴┴А В
,┴┴В Г
$str┴┴Д Т
}┴┴У Ф
,┴┴Ф Х
{
┬┬ 
new
┬┬ 
Guid
┬┬ 
(
┬┬ 
$str
┬┬ E
)
┬┬E F
,
┬┬F G
new
┬┬H K
Guid
┬┬L P
(
┬┬P Q
$str
┬┬Q w
)
┬┬w x
,
┬┬x y
new
┬┬z }
DateTimeOffset┬┬~ М
(┬┬М Н
new┬┬Н Р
DateTime┬┬С Щ
(┬┬Щ Ъ
$num┬┬Ъ Ы
,┬┬Ы Ь
$num┬┬Э Ю
,┬┬Ю Я
$num┬┬а б
,┬┬б в
$num┬┬г д
,┬┬д е
$num┬┬ж з
,┬┬з и
$num┬┬й к
,┬┬к л
$num┬┬м н
,┬┬н о
DateTimeKind┬┬п ╗
.┬┬╗ ╝
Unspecified┬┬╝ ╟
)┬┬╟ ╚
,┬┬╚ ╔
new┬┬╩ ═
TimeSpan┬┬╬ ╓
(┬┬╓ ╫
$num┬┬╫ ╪
,┬┬╪ ┘
$num┬┬┌ █
,┬┬█ ▄
$num┬┬▌ ▐
,┬┬▐ ▀
$num┬┬р с
,┬┬с т
$num┬┬у ф
)┬┬ф х
)┬┬х ц
,┬┬ц ч
null┬┬ш ь
,┬┬ь э
false┬┬ю є
,┬┬є Ї
true┬┬ї ∙
,┬┬∙ ·
new┬┬√ ■
DateTimeOffset┬┬  Н
(┬┬Н О
new┬┬О С
DateTime┬┬Т Ъ
(┬┬Ъ Ы
$num┬┬Ы Ь
,┬┬Ь Э
$num┬┬Ю Я
,┬┬Я а
$num┬┬б в
,┬┬в г
$num┬┬д е
,┬┬е ж
$num┬┬з и
,┬┬и й
$num┬┬к л
,┬┬л м
$num┬┬н о
,┬┬о п
DateTimeKind┬┬░ ╝
.┬┬╝ ╜
Unspecified┬┬╜ ╚
)┬┬╚ ╔
,┬┬╔ ╩
new┬┬╦ ╬
TimeSpan┬┬╧ ╫
(┬┬╫ ╪
$num┬┬╪ ┘
,┬┬┘ ┌
$num┬┬█ ▄
,┬┬▄ ▌
$num┬┬▐ ▀
,┬┬▀ р
$num┬┬с т
,┬┬т у
$num┬┬ф х
)┬┬х ц
)┬┬ц ч
,┬┬ч ш
null┬┬щ э
,┬┬э ю
$str┬┬я А
,┬┬А Б
$str┬┬В Д
,┬┬Д Е
$str┬┬Ж С
}┬┬Т У
,┬┬У Ф
{
├├ 
new
├├ 
Guid
├├ 
(
├├ 
$str
├├ E
)
├├E F
,
├├F G
new
├├H K
Guid
├├L P
(
├├P Q
$str
├├Q w
)
├├w x
,
├├x y
new
├├z }
DateTimeOffset├├~ М
(├├М Н
new├├Н Р
DateTime├├С Щ
(├├Щ Ъ
$num├├Ъ Ы
,├├Ы Ь
$num├├Э Ю
,├├Ю Я
$num├├а б
,├├б в
$num├├г д
,├├д е
$num├├ж з
,├├з и
$num├├й к
,├├к л
$num├├м н
,├├н о
DateTimeKind├├п ╗
.├├╗ ╝
Unspecified├├╝ ╟
)├├╟ ╚
,├├╚ ╔
new├├╩ ═
TimeSpan├├╬ ╓
(├├╓ ╫
$num├├╫ ╪
,├├╪ ┘
$num├├┌ █
,├├█ ▄
$num├├▌ ▐
,├├▐ ▀
$num├├р с
,├├с т
$num├├у ф
)├├ф х
)├├х ц
,├├ц ч
null├├ш ь
,├├ь э
false├├ю є
,├├є Ї
true├├ї ∙
,├├∙ ·
new├├√ ■
DateTimeOffset├├  Н
(├├Н О
new├├О С
DateTime├├Т Ъ
(├├Ъ Ы
$num├├Ы Ь
,├├Ь Э
$num├├Ю Я
,├├Я а
$num├├б в
,├├в г
$num├├д е
,├├е ж
$num├├з и
,├├и й
$num├├к л
,├├л м
$num├├н о
,├├о п
DateTimeKind├├░ ╝
.├├╝ ╜
Unspecified├├╜ ╚
)├├╚ ╔
,├├╔ ╩
new├├╦ ╬
TimeSpan├├╧ ╫
(├├╫ ╪
$num├├╪ ┘
,├├┘ ┌
$num├├█ ▄
,├├▄ ▌
$num├├▐ ▀
,├├▀ р
$num├├с т
,├├т у
$num├├ф х
)├├х ц
)├├ц ч
,├├ч ш
null├├щ э
,├├э ю
$str├├я ·
,├├· √
$str├├№ ■
,├├■  
$str├├А Е
}├├Ж З
,├├З И
{
── 
new
── 
Guid
── 
(
── 
$str
── E
)
──E F
,
──F G
new
──H K
Guid
──L P
(
──P Q
$str
──Q w
)
──w x
,
──x y
new
──z }
DateTimeOffset──~ М
(──М Н
new──Н Р
DateTime──С Щ
(──Щ Ъ
$num──Ъ Ы
,──Ы Ь
$num──Э Ю
,──Ю Я
$num──а б
,──б в
$num──г д
,──д е
$num──ж з
,──з и
$num──й к
,──к л
$num──м н
,──н о
DateTimeKind──п ╗
.──╗ ╝
Unspecified──╝ ╟
)──╟ ╚
,──╚ ╔
new──╩ ═
TimeSpan──╬ ╓
(──╓ ╫
$num──╫ ╪
,──╪ ┘
$num──┌ █
,──█ ▄
$num──▌ ▐
,──▐ ▀
$num──р с
,──с т
$num──у ф
)──ф х
)──х ц
,──ц ч
null──ш ь
,──ь э
false──ю є
,──є Ї
true──ї ∙
,──∙ ·
new──√ ■
DateTimeOffset──  Н
(──Н О
new──О С
DateTime──Т Ъ
(──Ъ Ы
$num──Ы Ь
,──Ь Э
$num──Ю Я
,──Я а
$num──б в
,──в г
$num──д е
,──е ж
$num──з и
,──и й
$num──к л
,──л м
$num──н о
,──о п
DateTimeKind──░ ╝
.──╝ ╜
Unspecified──╜ ╚
)──╚ ╔
,──╔ ╩
new──╦ ╬
TimeSpan──╧ ╫
(──╫ ╪
$num──╪ ┘
,──┘ ┌
$num──█ ▄
,──▄ ▌
$num──▐ ▀
,──▀ р
$num──с т
,──т у
$num──ф х
)──х ц
)──ц ч
,──ч ш
null──щ э
,──э ю
$str──я Е
,──Е Ж
$str──З Й
,──Й К
$str──Л Ы
}──Ь Э
,──Э Ю
{
┼┼ 
new
┼┼ 
Guid
┼┼ 
(
┼┼ 
$str
┼┼ E
)
┼┼E F
,
┼┼F G
new
┼┼H K
Guid
┼┼L P
(
┼┼P Q
$str
┼┼Q w
)
┼┼w x
,
┼┼x y
new
┼┼z }
DateTimeOffset┼┼~ М
(┼┼М Н
new┼┼Н Р
DateTime┼┼С Щ
(┼┼Щ Ъ
$num┼┼Ъ Ы
,┼┼Ы Ь
$num┼┼Э Ю
,┼┼Ю Я
$num┼┼а б
,┼┼б в
$num┼┼г д
,┼┼д е
$num┼┼ж з
,┼┼з и
$num┼┼й к
,┼┼к л
$num┼┼м н
,┼┼н о
DateTimeKind┼┼п ╗
.┼┼╗ ╝
Unspecified┼┼╝ ╟
)┼┼╟ ╚
,┼┼╚ ╔
new┼┼╩ ═
TimeSpan┼┼╬ ╓
(┼┼╓ ╫
$num┼┼╫ ╪
,┼┼╪ ┘
$num┼┼┌ █
,┼┼█ ▄
$num┼┼▌ ▐
,┼┼▐ ▀
$num┼┼р с
,┼┼с т
$num┼┼у ф
)┼┼ф х
)┼┼х ц
,┼┼ц ч
null┼┼ш ь
,┼┼ь э
false┼┼ю є
,┼┼є Ї
true┼┼ї ∙
,┼┼∙ ·
new┼┼√ ■
DateTimeOffset┼┼  Н
(┼┼Н О
new┼┼О С
DateTime┼┼Т Ъ
(┼┼Ъ Ы
$num┼┼Ы Ь
,┼┼Ь Э
$num┼┼Ю Я
,┼┼Я а
$num┼┼б в
,┼┼в г
$num┼┼д е
,┼┼е ж
$num┼┼з и
,┼┼и й
$num┼┼к л
,┼┼л м
$num┼┼н о
,┼┼о п
DateTimeKind┼┼░ ╝
.┼┼╝ ╜
Unspecified┼┼╜ ╚
)┼┼╚ ╔
,┼┼╔ ╩
new┼┼╦ ╬
TimeSpan┼┼╧ ╫
(┼┼╫ ╪
$num┼┼╪ ┘
,┼┼┘ ┌
$num┼┼█ ▄
,┼┼▄ ▌
$num┼┼▐ ▀
,┼┼▀ р
$num┼┼с т
,┼┼т у
$num┼┼ф х
)┼┼х ц
)┼┼ц ч
,┼┼ч ш
null┼┼щ э
,┼┼э ю
$str┼┼я ∙
,┼┼∙ ·
$str┼┼√ ¤
,┼┼¤ ■
$str┼┼  К
}┼┼Л М
}
╞╞ 
)
╞╞ 
;
╞╞ 
migrationBuilder
╚╚ 
.
╚╚ 

InsertData
╚╚ '
(
╚╚' (
table
╔╔ 
:
╔╔ 
$str
╔╔ 2
,
╔╔2 3
columns
╩╩ 
:
╩╩ 
new
╩╩ 
[
╩╩ 
]
╩╩ 
{
╩╩  
$str
╩╩! %
,
╩╩% &
$str
╩╩' 0
,
╩╩0 1
$str
╩╩2 =
,
╩╩= >
$str
╩╩? T
,
╩╩T U
$str
╩╩V a
,
╩╩a b
$str
╩╩c q
,
╩╩q r
$str╩╩s Г
,╩╩Г Д
$str╩╩Е Ч
,╩╩Ч Ш
$str╩╩Щ г
}╩╩д е
,╩╩е ж
values
╦╦ 
:
╦╦ 
new
╦╦ 
object
╦╦ "
[
╦╦" #
]
╦╦# $
{
╦╦% &
new
╦╦' *
Guid
╦╦+ /
(
╦╦/ 0
$str
╦╦0 V
)
╦╦V W
,
╦╦W X
new
╦╦Y \
DateTimeOffset
╦╦] k
(
╦╦k l
new
╦╦l o
DateTime
╦╦p x
(
╦╦x y
$num
╦╦y z
,
╦╦z {
$num
╦╦| }
,
╦╦} ~
$num╦╦ А
,╦╦А Б
$num╦╦В Г
,╦╦Г Д
$num╦╦Е Ж
,╦╦Ж З
$num╦╦И Й
,╦╦Й К
$num╦╦Л М
,╦╦М Н
DateTimeKind╦╦О Ъ
.╦╦Ъ Ы
Unspecified╦╦Ы ж
)╦╦ж з
,╦╦з и
new╦╦й м
TimeSpan╦╦н ╡
(╦╦╡ ╢
$num╦╦╢ ╖
,╦╦╖ ╕
$num╦╦╣ ║
,╦╦║ ╗
$num╦╦╝ ╜
,╦╦╜ ╛
$num╦╦┐ └
,╦╦└ ┴
$num╦╦┬ ├
)╦╦├ ─
)╦╦─ ┼
,╦╦┼ ╞
null╦╦╟ ╦
,╦╦╦ ╠
new╦╦═ ╨
Guid╦╦╤ ╒
(╦╦╒ ╓
$str╦╦╓ №
)╦╦№ ¤
,╦╦¤ ■
false╦╦  Д
,╦╦Д Е
new╦╦Ж Й
DateTimeOffset╦╦К Ш
(╦╦Ш Щ
new╦╦Щ Ь
DateTime╦╦Э е
(╦╦е ж
$num╦╦ж з
,╦╦з и
$num╦╦й к
,╦╦к л
$num╦╦м н
,╦╦н о
$num╦╦п ░
,╦╦░ ▒
$num╦╦▓ │
,╦╦│ ┤
$num╦╦╡ ╢
,╦╦╢ ╖
$num╦╦╕ ╣
,╦╦╣ ║
DateTimeKind╦╦╗ ╟
.╦╦╟ ╚
Unspecified╦╦╚ ╙
)╦╦╙ ╘
,╦╦╘ ╒
new╦╦╓ ┘
TimeSpan╦╦┌ т
(╦╦т у
$num╦╦у ф
,╦╦ф х
$num╦╦ц ч
,╦╦ч ш
$num╦╦щ ъ
,╦╦ъ ы
$num╦╦ь э
,╦╦э ю
$num╦╦я Ё
)╦╦Ё ё
)╦╦ё Є
,╦╦Є є
null╦╦Ї °
,╦╦° ∙
new╦╦· ¤
Guid╦╦■ В
(╦╦В Г
$str╦╦Г й
)╦╦й к
,╦╦к л
$num╦╦м о
}╦╦п ░
)╦╦░ ▒
;╦╦▒ ▓
migrationBuilder
══ 
.
══ 

InsertData
══ '
(
══' (
table
╬╬ 
:
╬╬ 
$str
╬╬ !
,
╬╬! "
columns
╧╧ 
:
╧╧ 
new
╧╧ 
[
╧╧ 
]
╧╧ 
{
╧╧  
$str
╧╧! %
,
╧╧% &
$str
╧╧' 3
,
╧╧3 4
$str
╧╧5 >
,
╧╧> ?
$str
╧╧@ K
,
╧╧K L
$str
╧╧M X
,
╧╧X Y
$str
╧╧Z h
,
╧╧h i
$str
╧╧j z
,
╧╧z {
$str╧╧| Г
,╧╧Г Д
$str╧╧Е Щ
,╧╧Щ Ъ
$str╧╧Ы н
,╧╧н о
$str╧╧п ╝
,╧╧╝ ╜
$str╧╧╛ ╦
,╧╧╦ ╠
$str╧╧═ █
}╧╧▄ ▌
,╧╧▌ ▐
values
╨╨ 
:
╨╨ 
new
╨╨ 
object
╨╨ "
[
╨╨" #
,
╨╨# $
]
╨╨$ %
{
╤╤ 
{
╥╥ 
new
╥╥ 
Guid
╥╥ 
(
╥╥ 
$str
╥╥ E
)
╥╥E F
,
╥╥F G
new
╥╥H K
Guid
╥╥L P
(
╥╥P Q
$str
╥╥Q w
)
╥╥w x
,
╥╥x y
new
╥╥z }
DateTimeOffset╥╥~ М
(╥╥М Н
new╥╥Н Р
DateTime╥╥С Щ
(╥╥Щ Ъ
$num╥╥Ъ Ы
,╥╥Ы Ь
$num╥╥Э Ю
,╥╥Ю Я
$num╥╥а б
,╥╥б в
$num╥╥г д
,╥╥д е
$num╥╥ж з
,╥╥з и
$num╥╥й к
,╥╥к л
$num╥╥м н
,╥╥н о
DateTimeKind╥╥п ╗
.╥╥╗ ╝
Unspecified╥╥╝ ╟
)╥╥╟ ╚
,╥╥╚ ╔
new╥╥╩ ═
TimeSpan╥╥╬ ╓
(╥╥╓ ╫
$num╥╥╫ ╪
,╥╥╪ ┘
$num╥╥┌ █
,╥╥█ ▄
$num╥╥▌ ▐
,╥╥▐ ▀
$num╥╥р с
,╥╥с т
$num╥╥у ф
)╥╥ф х
)╥╥х ц
,╥╥ц ч
null╥╥ш ь
,╥╥ь э
false╥╥ю є
,╥╥є Ї
new╥╥ї °
DateTimeOffset╥╥∙ З
(╥╥З И
new╥╥И Л
DateTime╥╥М Ф
(╥╥Ф Х
$num╥╥Х Ц
,╥╥Ц Ч
$num╥╥Ш Щ
,╥╥Щ Ъ
$num╥╥Ы Ь
,╥╥Ь Э
$num╥╥Ю Я
,╥╥Я а
$num╥╥б в
,╥╥в г
$num╥╥д е
,╥╥е ж
$num╥╥з и
,╥╥и й
DateTimeKind╥╥к ╢
.╥╥╢ ╖
Unspecified╥╥╖ ┬
)╥╥┬ ├
,╥╥├ ─
new╥╥┼ ╚
TimeSpan╥╥╔ ╤
(╥╥╤ ╥
$num╥╥╥ ╙
,╥╥╙ ╘
$num╥╥╒ ╓
,╥╥╓ ╫
$num╥╥╪ ┘
,╥╥┘ ┌
$num╥╥█ ▄
,╥╥▄ ▌
$num╥╥▐ ▀
)╥╥▀ р
)╥╥р с
,╥╥с т
null╥╥у ч
,╥╥ч ш
$num╥╥щ ы
,╥╥ы ь
$str╥╥э ·
,╥╥· √
new╥╥№  
Guid╥╥А Д
(╥╥Д Е
$str╥╥Е л
)╥╥л м
,╥╥м н
$str╥╥о ╣
,╥╥╣ ║
(╥╥╗ ╝
byte╥╥╝ └
)╥╥└ ┴
$num╥╥┴ ┬
,╥╥┬ ├
new╥╥─ ╟
Guid╥╥╚ ╠
(╥╥╠ ═
$str╥╥═ є
)╥╥є Ї
}╥╥ї Ў
,╥╥Ў ў
{
╙╙ 
new
╙╙ 
Guid
╙╙ 
(
╙╙ 
$str
╙╙ E
)
╙╙E F
,
╙╙F G
new
╙╙H K
Guid
╙╙L P
(
╙╙P Q
$str
╙╙Q w
)
╙╙w x
,
╙╙x y
new
╙╙z }
DateTimeOffset╙╙~ М
(╙╙М Н
new╙╙Н Р
DateTime╙╙С Щ
(╙╙Щ Ъ
$num╙╙Ъ Ы
,╙╙Ы Ь
$num╙╙Э Ю
,╙╙Ю Я
$num╙╙а б
,╙╙б в
$num╙╙г д
,╙╙д е
$num╙╙ж з
,╙╙з и
$num╙╙й к
,╙╙к л
$num╙╙м н
,╙╙н о
DateTimeKind╙╙п ╗
.╙╙╗ ╝
Unspecified╙╙╝ ╟
)╙╙╟ ╚
,╙╙╚ ╔
new╙╙╩ ═
TimeSpan╙╙╬ ╓
(╙╙╓ ╫
$num╙╙╫ ╪
,╙╙╪ ┘
$num╙╙┌ █
,╙╙█ ▄
$num╙╙▌ ▐
,╙╙▐ ▀
$num╙╙р с
,╙╙с т
$num╙╙у ф
)╙╙ф х
)╙╙х ц
,╙╙ц ч
null╙╙ш ь
,╙╙ь э
false╙╙ю є
,╙╙є Ї
new╙╙ї °
DateTimeOffset╙╙∙ З
(╙╙З И
new╙╙И Л
DateTime╙╙М Ф
(╙╙Ф Х
$num╙╙Х Ц
,╙╙Ц Ч
$num╙╙Ш Щ
,╙╙Щ Ъ
$num╙╙Ы Ь
,╙╙Ь Э
$num╙╙Ю Я
,╙╙Я а
$num╙╙б в
,╙╙в г
$num╙╙д е
,╙╙е ж
$num╙╙з и
,╙╙и й
DateTimeKind╙╙к ╢
.╙╙╢ ╖
Unspecified╙╙╖ ┬
)╙╙┬ ├
,╙╙├ ─
new╙╙┼ ╚
TimeSpan╙╙╔ ╤
(╙╙╤ ╥
$num╙╙╥ ╙
,╙╙╙ ╘
$num╙╙╒ ╓
,╙╙╓ ╫
$num╙╙╪ ┘
,╙╙┘ ┌
$num╙╙█ ▄
,╙╙▄ ▌
$num╙╙▐ ▀
)╙╙▀ р
)╙╙р с
,╙╙с т
null╙╙у ч
,╙╙ч ш
$num╙╙щ ы
,╙╙ы ь
$str╙╙э ·
,╙╙· √
new╙╙№  
Guid╙╙А Д
(╙╙Д Е
$str╙╙Е л
)╙╙л м
,╙╙м н
$str╙╙о │
,╙╙│ ┤
(╙╙╡ ╢
byte╙╙╢ ║
)╙╙║ ╗
$num╙╙╗ ╝
,╙╙╝ ╜
new╙╙╛ ┴
Guid╙╙┬ ╞
(╙╙╞ ╟
$str╙╙╟ э
)╙╙э ю
}╙╙я Ё
,╙╙Ё ё
{
╘╘ 
new
╘╘ 
Guid
╘╘ 
(
╘╘ 
$str
╘╘ E
)
╘╘E F
,
╘╘F G
new
╘╘H K
Guid
╘╘L P
(
╘╘P Q
$str
╘╘Q w
)
╘╘w x
,
╘╘x y
new
╘╘z }
DateTimeOffset╘╘~ М
(╘╘М Н
new╘╘Н Р
DateTime╘╘С Щ
(╘╘Щ Ъ
$num╘╘Ъ Ы
,╘╘Ы Ь
$num╘╘Э Ю
,╘╘Ю Я
$num╘╘а б
,╘╘б в
$num╘╘г д
,╘╘д е
$num╘╘ж з
,╘╘з и
$num╘╘й к
,╘╘к л
$num╘╘м н
,╘╘н о
DateTimeKind╘╘п ╗
.╘╘╗ ╝
Unspecified╘╘╝ ╟
)╘╘╟ ╚
,╘╘╚ ╔
new╘╘╩ ═
TimeSpan╘╘╬ ╓
(╘╘╓ ╫
$num╘╘╫ ╪
,╘╘╪ ┘
$num╘╘┌ █
,╘╘█ ▄
$num╘╘▌ ▐
,╘╘▐ ▀
$num╘╘р с
,╘╘с т
$num╘╘у ф
)╘╘ф х
)╘╘х ц
,╘╘ц ч
null╘╘ш ь
,╘╘ь э
false╘╘ю є
,╘╘є Ї
new╘╘ї °
DateTimeOffset╘╘∙ З
(╘╘З И
new╘╘И Л
DateTime╘╘М Ф
(╘╘Ф Х
$num╘╘Х Ц
,╘╘Ц Ч
$num╘╘Ш Щ
,╘╘Щ Ъ
$num╘╘Ы Ь
,╘╘Ь Э
$num╘╘Ю Я
,╘╘Я а
$num╘╘б в
,╘╘в г
$num╘╘д е
,╘╘е ж
$num╘╘з и
,╘╘и й
DateTimeKind╘╘к ╢
.╘╘╢ ╖
Unspecified╘╘╖ ┬
)╘╘┬ ├
,╘╘├ ─
new╘╘┼ ╚
TimeSpan╘╘╔ ╤
(╘╘╤ ╥
$num╘╘╥ ╙
,╘╘╙ ╘
$num╘╘╒ ╓
,╘╘╓ ╫
$num╘╘╪ ┘
,╘╘┘ ┌
$num╘╘█ ▄
,╘╘▄ ▌
$num╘╘▐ ▀
)╘╘▀ р
)╘╘р с
,╘╘с т
null╘╘у ч
,╘╘ч ш
$num╘╘щ ы
,╘╘ы ь
$str╘╘э Ў
,╘╘Ў ў
new╘╘° √
Guid╘╘№ А
(╘╘А Б
$str╘╘Б з
)╘╘з и
,╘╘и й
$str╘╘к ╝
,╘╘╝ ╜
(╘╘╛ ┐
byte╘╘┐ ├
)╘╘├ ─
$num╘╘─ ┼
,╘╘┼ ╞
new╘╘╟ ╩
Guid╘╘╦ ╧
(╘╘╧ ╨
$str╘╘╨ Ў
)╘╘Ў ў
}╘╘° ∙
}
╒╒ 
)
╒╒ 
;
╒╒ 
migrationBuilder
╫╫ 
.
╫╫ 
CreateIndex
╫╫ (
(
╫╫( )
name
╪╪ 
:
╪╪ 
$str
╪╪ 2
,
╪╪2 3
table
┘┘ 
:
┘┘ 
$str
┘┘ )
,
┘┘) *
column
┌┌ 
:
┌┌ 
$str
┌┌  
)
┌┌  !
;
┌┌! "
migrationBuilder
▄▄ 
.
▄▄ 
CreateIndex
▄▄ (
(
▄▄( )
name
▌▌ 
:
▌▌ 
$str
▌▌ %
,
▌▌% &
table
▐▐ 
:
▐▐ 
$str
▐▐ $
,
▐▐$ %
column
▀▀ 
:
▀▀ 
$str
▀▀ (
,
▀▀( )
unique
рр 
:
рр 
true
рр 
)
рр 
;
рр 
migrationBuilder
тт 
.
тт 
CreateIndex
тт (
(
тт( )
name
уу 
:
уу 
$str
уу 2
,
уу2 3
table
фф 
:
фф 
$str
фф )
,
фф) *
column
хх 
:
хх 
$str
хх  
)
хх  !
;
хх! "
migrationBuilder
чч 
.
чч 
CreateIndex
чч (
(
чч( )
name
шш 
:
шш 
$str
шш 2
,
шш2 3
table
щщ 
:
щщ 
$str
щщ )
,
щщ) *
column
ъъ 
:
ъъ 
$str
ъъ  
)
ъъ  !
;
ъъ! "
migrationBuilder
ьь 
.
ьь 
CreateIndex
ьь (
(
ьь( )
name
ээ 
:
ээ 
$str
ээ 1
,
ээ1 2
table
юю 
:
юю 
$str
юю (
,
юю( )
column
яя 
:
яя 
$str
яя  
)
яя  !
;
яя! "
migrationBuilder
ёё 
.
ёё 
CreateIndex
ёё (
(
ёё( )
name
ЄЄ 
:
ЄЄ 
$str
ЄЄ "
,
ЄЄ" #
table
єє 
:
єє 
$str
єє $
,
єє$ %
column
ЇЇ 
:
ЇЇ 
$str
ЇЇ )
)
ЇЇ) *
;
ЇЇ* +
migrationBuilder
ЎЎ 
.
ЎЎ 
CreateIndex
ЎЎ (
(
ЎЎ( )
name
ўў 
:
ўў 
$str
ўў %
,
ўў% &
table
°° 
:
°° 
$str
°° $
,
°°$ %
column
∙∙ 
:
∙∙ 
$str
∙∙ ,
,
∙∙, -
unique
·· 
:
·· 
true
·· 
)
·· 
;
·· 
migrationBuilder
№№ 
.
№№ 
CreateIndex
№№ (
(
№№( )
name
¤¤ 
:
¤¤ 
$str
¤¤ 1
,
¤¤1 2
table
■■ 
:
■■ 
$str
■■ $
,
■■$ %
column
   
:
   
$str
   $
)
  $ %
;
  % &
migrationBuilder
Б	Б	 
.
Б	Б	 
CreateIndex
Б	Б	 (
(
Б	Б	( )
name
В	В	 
:
В	В	 
$str
В	В	 -
,
В	В	- .
table
Г	Г	 
:
Г	Г	 
$str
Г	Г	 $
,
Г	Г	$ %
column
Д	Д	 
:
Д	Д	 
$str
Д	Д	  
)
Д	Д	  !
;
Д	Д	! "
migrationBuilder
Ж	Ж	 
.
Ж	Ж	 
CreateIndex
Ж	Ж	 (
(
Ж	Ж	( )
name
З	З	 
:
З	З	 
$str
З	З	 7
,
З	З	7 8
table
И	И	 
:
И	И	 
$str
И	И	 $
,
И	И	$ %
column
Й	Й	 
:
Й	Й	 
$str
Й	Й	 *
)
Й	Й	* +
;
Й	Й	+ ,
migrationBuilder
Л	Л	 
.
Л	Л	 
CreateIndex
Л	Л	 (
(
Л	Л	( )
name
М	М	 
:
М	М	 
$str
М	М	 .
,
М	М	. /
table
Н	Н	 
:
Н	Н	 
$str
Н	Н	 
,
Н	Н	  
column
О	О	 
:
О	О	 
$str
О	О	 &
)
О	О	& '
;
О	О	' (
migrationBuilder
Р	Р	 
.
Р	Р	 
CreateIndex
Р	Р	 (
(
Р	Р	( )
name
С	С	 
:
С	С	 
$str
С	С	 +
,
С	С	+ ,
table
Т	Т	 
:
Т	Т	 
$str
Т	Т	 "
,
Т	Т	" #
column
У	У	 
:
У	У	 
$str
У	У	  
,
У	У	  !
unique
Ф	Ф	 
:
Ф	Ф	 
true
Ф	Ф	 
)
Ф	Ф	 
;
Ф	Ф	 
migrationBuilder
Ц	Ц	 
.
Ц	Ц	 
CreateIndex
Ц	Ц	 (
(
Ц	Ц	( )
name
Ч	Ч	 
:
Ч	Ч	 
$str
Ч	Ч	 1
,
Ч	Ч	1 2
table
Ш	Ш	 
:
Ш	Ш	 
$str
Ш	Ш	 "
,
Ш	Ш	" #
column
Щ	Щ	 
:
Щ	Щ	 
$str
Щ	Щ	 &
)
Щ	Щ	& '
;
Щ	Щ	' (
migrationBuilder
Ы	Ы	 
.
Ы	Ы	 
CreateIndex
Ы	Ы	 (
(
Ы	Ы	( )
name
Ь	Ь	 
:
Ь	Ь	 
$str
Ь	Ь	 +
,
Ь	Ь	+ ,
table
Э	Э	 
:
Э	Э	 
$str
Э	Э	 "
,
Э	Э	" #
column
Ю	Ю	 
:
Ю	Ю	 
$str
Ю	Ю	  
,
Ю	Ю	  !
unique
Я	Я	 
:
Я	Я	 
true
Я	Я	 
)
Я	Я	 
;
Я	Я	 
migrationBuilder
б	б	 
.
б	б	 
CreateIndex
б	б	 (
(
б	б	( )
name
в	в	 
:
в	в	 
$str
в	в	 2
,
в	в	2 3
table
г	г	 
:
г	г	 
$str
г	г	 #
,
г	г	# $
column
д	д	 
:
д	д	 
$str
д	д	 &
)
д	д	& '
;
д	д	' (
migrationBuilder
ж	ж	 
.
ж	ж	 
CreateIndex
ж	ж	 (
(
ж	ж	( )
name
з	з	 
:
з	з	 
$str
з	з	 4
,
з	з	4 5
table
и	и	 
:
и	и	 
$str
и	и	 &
,
и	и	& '
column
й	й	 
:
й	й	 
$str
й	й	 %
)
й	й	% &
;
й	й	& '
migrationBuilder
л	л	 
.
л	л	 
CreateIndex
л	л	 (
(
л	л	( )
name
м	м	 
:
м	м	 
$str
м	м	 /
,
м	м	/ 0
table
н	н	 
:
н	н	 
$str
н	н	 &
,
н	н	& '
column
о	о	 
:
о	о	 
$str
о	о	  
)
о	о	  !
;
о	о	! "
migrationBuilder
░	░	 
.
░	░	 
CreateIndex
░	░	 (
(
░	░	( )
name
▒	▒	 
:
▒	▒	 
$str
▒	▒	 1
,
▒	▒	1 2
table
▓	▓	 
:
▓	▓	 
$str
▓	▓	 #
,
▓	▓	# $
column
│	│	 
:
│	│	 
$str
│	│	 %
)
│	│	% &
;
│	│	& '
migrationBuilder
╡	╡	 
.
╡	╡	 
CreateIndex
╡	╡	 (
(
╡	╡	( )
name
╢	╢	 
:
╢	╢	 
$str
╢	╢	 ,
,
╢	╢	, -
table
╖	╖	 
:
╖	╖	 
$str
╖	╖	 #
,
╖	╖	# $
column
╕	╕	 
:
╕	╕	 
$str
╕	╕	  
)
╕	╕	  !
;
╕	╕	! "
migrationBuilder
║	║	 
.
║	║	 
CreateIndex
║	║	 (
(
║	║	( )
name
╗	╗	 
:
╗	╗	 
$str
╗	╗	 >
,
╗	╗	> ?
table
╝	╝	 
:
╝	╝	 
$str
╝	╝	 +
,
╝	╝	+ ,
column
╜	╜	 
:
╜	╜	 
$str
╜	╜	 *
)
╜	╜	* +
;
╜	╜	+ ,
migrationBuilder
┐	┐	 
.
┐	┐	 
CreateIndex
┐	┐	 (
(
┐	┐	( )
name
└	└	 
:
└	└	 
$str
└	└	 7
,
└	└	7 8
table
┴	┴	 
:
┴	┴	 
$str
┴	┴	 $
,
┴	┴	$ %
column
┬	┬	 
:
┬	┬	 
$str
┬	┬	 *
)
┬	┬	* +
;
┬	┬	+ ,
migrationBuilder
─	─	 
.
─	─	 
CreateIndex
─	─	 (
(
─	─	( )
name
┼	┼	 
:
┼	┼	 
$str
┼	┼	 3
,
┼	┼	3 4
table
╞	╞	 
:
╞	╞	 
$str
╞	╞	 $
,
╞	╞	$ %
column
╟	╟	 
:
╟	╟	 
$str
╟	╟	 &
)
╟	╟	& '
;
╟	╟	' (
migrationBuilder
╔	╔	 
.
╔	╔	 
CreateIndex
╔	╔	 (
(
╔	╔	( )
name
╩	╩	 
:
╩	╩	 
$str
╩	╩	 >
,
╩	╩	> ?
table
╦	╦	 
:
╦	╦	 
$str
╦	╦	 /
,
╦	╦	/ 0
column
╠	╠	 
:
╠	╠	 
$str
╠	╠	 &
)
╠	╠	& '
;
╠	╠	' (
migrationBuilder
╬	╬	 
.
╬	╬	 
CreateIndex
╬	╬	 (
(
╬	╬	( )
name
╧	╧	 
:
╧	╧	 
$str
╧	╧	 9
,
╧	╧	9 :
table
╨	╨	 
:
╨	╨	 
$str
╨	╨	 /
,
╨	╨	/ 0
column
╤	╤	 
:
╤	╤	 
$str
╤	╤	 !
)
╤	╤	! "
;
╤	╤	" #
migrationBuilder
╙	╙	 
.
╙	╙	 
CreateIndex
╙	╙	 (
(
╙	╙	( )
name
╘	╘	 
:
╘	╘	 
$str
╘	╘	 6
,
╘	╘	6 7
table
╒	╒	 
:
╒	╒	 
$str
╒	╒	 '
,
╒	╒	' (
column
╓	╓	 
:
╓	╓	 
$str
╓	╓	 &
)
╓	╓	& '
;
╓	╓	' (
migrationBuilder
╪	╪	 
.
╪	╪	 
CreateIndex
╪	╪	 (
(
╪	╪	( )
name
┘	┘	 
:
┘	┘	 
$str
┘	┘	 @
,
┘	┘	@ A
table
┌	┌	 
:
┌	┌	 
$str
┌	┌	 '
,
┌	┌	' (
column
█	█	 
:
█	█	 
$str
█	█	 0
)
█	█	0 1
;
█	█	1 2
migrationBuilder
▌	▌	 
.
▌	▌	 
CreateIndex
▌	▌	 (
(
▌	▌	( )
name
▐	▐	 
:
▐	▐	 
$str
▐	▐	 H
,
▐	▐	H I
table
▀	▀	 
:
▀	▀	 
$str
▀	▀	 0
,
▀	▀	0 1
column
р	р	 
:
р	р	 
$str
р	р	 /
)
р	р	/ 0
;
р	р	0 1
migrationBuilder
т	т	 
.
т	т	 
CreateIndex
т	т	 (
(
т	т	( )
name
у	у	 
:
у	у	 
$str
у	у	 9
,
у	у	9 :
table
ф	ф	 
:
ф	ф	 
$str
ф	ф	 0
,
ф	ф	0 1
column
х	х	 
:
х	х	 
$str
х	х	  
)
х	х	  !
;
х	х	! "
migrationBuilder
ч	ч	 
.
ч	ч	 
CreateIndex
ч	ч	 (
(
ч	ч	( )
name
ш	ш	 
:
ш	ш	 
$str
ш	ш	 @
,
ш	ш	@ A
table
щ	щ	 
:
щ	щ	 
$str
щ	щ	 -
,
щ	щ	- .
column
ъ	ъ	 
:
ъ	ъ	 
$str
ъ	ъ	 *
)
ъ	ъ	* +
;
ъ	ъ	+ ,
migrationBuilder
ь	ь	 
.
ь	ь	 
CreateIndex
ь	ь	 (
(
ь	ь	( )
name
э	э	 
:
э	э	 
$str
э	э	 <
,
э	э	< =
table
ю	ю	 
:
ю	ю	 
$str
ю	ю	 -
,
ю	ю	- .
column
я	я	 
:
я	я	 
$str
я	я	 &
)
я	я	& '
;
я	я	' (
migrationBuilder
ё	ё	 
.
ё	ё	 
CreateIndex
ё	ё	 (
(
ё	ё	( )
name
Є	Є	 
:
Є	Є	 
$str
Є	Є	 /
,
Є	Є	/ 0
table
є	є	 
:
є	є	 
$str
є	є	 %
,
є	є	% &
column
Ї	Ї	 
:
Ї	Ї	 
$str
Ї	Ї	 !
)
Ї	Ї	! "
;
Ї	Ї	" #
migrationBuilder
Ў	Ў	 
.
Ў	Ў	 
CreateIndex
Ў	Ў	 (
(
Ў	Ў	( )
name
ў	ў	 
:
ў	ў	 
$str
ў	ў	 /
,
ў	ў	/ 0
table
°	°	 
:
°	°	 
$str
°	°	 %
,
°	°	% &
column
∙	∙	 
:
∙	∙	 
$str
∙	∙	 !
)
∙	∙	! "
;
∙	∙	" #
migrationBuilder
√	√	 
.
√	√	 
CreateIndex
√	√	 (
(
√	√	( )
name
№	№	 
:
№	№	 
$str
№	№	 1
,
№	№	1 2
table
¤	¤	 
:
¤	¤	 
$str
¤	¤	 %
,
¤	¤	% &
column
■	■	 
:
■	■	 
$str
■	■	 #
)
■	■	# $
;
■	■	$ %
migrationBuilder
А
А
 
.
А
А
 
CreateIndex
А
А
 (
(
А
А
( )
name
Б
Б
 
:
Б
Б
 
$str
Б
Б
 )
,
Б
Б
) *
table
В
В
 
:
В
В
 
$str
В
В
 
,
В
В
  
column
Г
Г
 
:
Г
Г
 
$str
Г
Г
 !
)
Г
Г
! "
;
Г
Г
" #
migrationBuilder
Е
Е
 
.
Е
Е
 
CreateIndex
Е
Е
 (
(
Е
Е
( )
name
Ж
Ж
 
:
Ж
Ж
 
$str
Ж
Ж
 +
,
Ж
Ж
+ ,
table
З
З
 
:
З
З
 
$str
З
З
 !
,
З
З
! "
column
И
И
 
:
И
И
 
$str
И
И
 !
)
И
И
! "
;
И
И
" #
migrationBuilder
К
К
 
.
К
К
 
CreateIndex
К
К
 (
(
К
К
( )
name
Л
Л
 
:
Л
Л
 
$str
Л
Л
 0
,
Л
Л
0 1
table
М
М
 
:
М
М
 
$str
М
М
 &
,
М
М
& '
column
Н
Н
 
:
Н
Н
 
$str
Н
Н
 !
)
Н
Н
! "
;
Н
Н
" #
migrationBuilder
П
П
 
.
П
П
 
CreateIndex
П
П
 (
(
П
П
( )
name
Р
Р
 
:
Р
Р
 
$str
Р
Р
 2
,
Р
Р
2 3
table
С
С
 
:
С
С
 
$str
С
С
 &
,
С
С
& '
column
Т
Т
 
:
Т
Т
 
$str
Т
Т
 #
)
Т
Т
# $
;
Т
Т
$ %
migrationBuilder
Ф
Ф
 
.
Ф
Ф
 
CreateIndex
Ф
Ф
 (
(
Ф
Ф
( )
name
Х
Х
 
:
Х
Х
 
$str
Х
Х
 5
,
Х
Х
5 6
table
Ц
Ц
 
:
Ц
Ц
 
$str
Ц
Ц
 (
,
Ц
Ц
( )
column
Ч
Ч
 
:
Ч
Ч
 
$str
Ч
Ч
 $
)
Ч
Ч
$ %
;
Ч
Ч
% &
migrationBuilder
Щ
Щ
 
.
Щ
Щ
 
CreateIndex
Щ
Щ
 (
(
Щ
Щ
( )
name
Ъ
Ъ
 
:
Ъ
Ъ
 
$str
Ъ
Ъ
 2
,
Ъ
Ъ
2 3
table
Ы
Ы
 
:
Ы
Ы
 
$str
Ы
Ы
 &
,
Ы
Ы
& '
column
Ь
Ь
 
:
Ь
Ь
 
$str
Ь
Ь
 #
)
Ь
Ь
# $
;
Ь
Ь
$ %
migrationBuilder
Ю
Ю
 
.
Ю
Ю
 
CreateIndex
Ю
Ю
 (
(
Ю
Ю
( )
name
Я
Я
 
:
Я
Я
 
$str
Я
Я
 H
,
Я
Я
H I
table
а
а
 
:
а
а
 
$str
а
а
 2
,
а
а
2 3
column
б
б
 
:
б
б
 
$str
б
б
 -
)
б
б
- .
;
б
б
. /
migrationBuilder
г
г
 
.
г
г
 
CreateIndex
г
г
 (
(
г
г
( )
name
д
д
 
:
д
д
 
$str
д
д
 E
,
д
д
E F
table
е
е
 
:
е
е
 
$str
е
е
 2
,
е
е
2 3
column
ж
ж
 
:
ж
ж
 
$str
ж
ж
 *
)
ж
ж
* +
;
ж
ж
+ ,
migrationBuilder
и
и
 
.
и
и
 
CreateIndex
и
и
 (
(
и
и
( )
name
й
й
 
:
й
й
 
$str
й
й
 :
,
й
й
: ;
table
к
к
 
:
к
к
 
$str
к
к
 +
,
к
к
+ ,
column
л
л
 
:
л
л
 
$str
л
л
 &
)
л
л
& '
;
л
л
' (
migrationBuilder
н
н
 
.
н
н
 
CreateIndex
н
н
 (
(
н
н
( )
name
о
о
 
:
о
о
 
$str
о
о
 7
,
о
о
7 8
table
п
п
 
:
п
п
 
$str
п
п
 +
,
п
п
+ ,
column
░
░
 
:
░
░
 
$str
░
░
 #
)
░
░
# $
;
░
░
$ %
migrationBuilder
▓
▓
 
.
▓
▓
 
CreateIndex
▓
▓
 (
(
▓
▓
( )
name
│
│
 
:
│
│
 
$str
│
│
 .
,
│
│
. /
table
┤
┤
 
:
┤
┤
 
$str
┤
┤
 !
,
┤
┤
! "
column
╡
╡
 
:
╡
╡
 
$str
╡
╡
 $
)
╡
╡
$ %
;
╡
╡
% &
migrationBuilder
╖
╖
 
.
╖
╖
 
CreateIndex
╖
╖
 (
(
╖
╖
( )
name
╕
╕
 
:
╕
╕
 
$str
╕
╕
 4
,
╕
╕
4 5
table
╣
╣
 
:
╣
╣
 
$str
╣
╣
 !
,
╣
╣
! "
column
║
║
 
:
║
║
 
$str
║
║
 *
)
║
║
* +
;
║
║
+ ,
migrationBuilder
╝
╝
 
.
╝
╝
 
CreateIndex
╝
╝
 (
(
╝
╝
( )
name
╜
╜
 
:
╜
╜
 
$str
╜
╜
 0
,
╜
╜
0 1
table
╛
╛
 
:
╛
╛
 
$str
╛
╛
 !
,
╛
╛
! "
column
┐
┐
 
:
┐
┐
 
$str
┐
┐
 &
)
┐
┐
& '
;
┐
┐
' (
migrationBuilder
┴
┴
 
.
┴
┴
 
CreateIndex
┴
┴
 (
(
┴
┴
( )
name
┬
┬
 
:
┬
┬
 
$str
┬
┬
 *
,
┬
┬
* +
table
├
├
 
:
├
├
 
$str
├
├
  
,
├
├
  !
column
─
─
 
:
─
─
 
$str
─
─
 !
,
─
─
! "
unique
┼
┼
 
:
┼
┼
 
true
┼
┼
 
)
┼
┼
 
;
┼
┼
 
migrationBuilder
╟
╟
 
.
╟
╟
 
CreateIndex
╟
╟
 (
(
╟
╟
( )
name
╚
╚
 
:
╚
╚
 
$str
╚
╚
 .
,
╚
╚
. /
table
╔
╔
 
:
╔
╔
 
$str
╔
╔
 
,
╔
╔
  
column
╩
╩
 
:
╩
╩
 
$str
╩
╩
 &
)
╩
╩
& '
;
╩
╩
' (
migrationBuilder
╠
╠
 
.
╠
╠
 
CreateIndex
╠
╠
 (
(
╠
╠
( )
name
═
═
 
:
═
═
 
$str
═
═
 .
,
═
═
. /
table
╬
╬
 
:
╬
╬
 
$str
╬
╬
 %
,
╬
╬
% &
column
╧
╧
 
:
╧
╧
 
$str
╧
╧
  
)
╧
╧
  !
;
╧
╧
! "
migrationBuilder
╤
╤
 
.
╤
╤
 
CreateIndex
╤
╤
 (
(
╤
╤
( )
name
╥
╥
 
:
╥
╥
 
$str
╥
╥
 5
,
╥
╥
5 6
table
╙
╙
 
:
╙
╙
 
$str
╙
╙
 (
,
╙
╙
( )
column
╘
╘
 
:
╘
╘
 
$str
╘
╘
 $
)
╘
╘
$ %
;
╘
╘
% &
migrationBuilder
╓
╓
 
.
╓
╓
 
CreateIndex
╓
╓
 (
(
╓
╓
( )
name
╫
╫
 
:
╫
╫
 
$str
╫
╫
 2
,
╫
╫
2 3
table
╪
╪
 
:
╪
╪
 
$str
╪
╪
 (
,
╪
╪
( )
column
┘
┘
 
:
┘
┘
 
$str
┘
┘
 !
)
┘
┘
! "
;
┘
┘
" #
migrationBuilder
█
█
 
.
█
█
 
CreateIndex
█
█
 (
(
█
█
( )
name
▄
▄
 
:
▄
▄
 
$str
▄
▄
 1
,
▄
▄
1 2
table
▌
▌
 
:
▌
▌
 
$str
▌
▌
 (
,
▌
▌
( )
column
▐
▐
 
:
▐
▐
 
$str
▐
▐
  
)
▐
▐
  !
;
▐
▐
! "
}
▀
▀
 	
	protected
т
т
 
override
т
т
 
void
т
т
 
Down
т
т
  $
(
т
т
$ %
MigrationBuilder
т
т
% 5
migrationBuilder
т
т
6 F
)
т
т
F G
{
у
у
 	
migrationBuilder
ф
ф
 
.
ф
ф
 
	DropTable
ф
ф
 &
(
ф
ф
& '
name
х
х
 
:
х
х
 
$str
х
х
 (
)
х
х
( )
;
х
х
) *
migrationBuilder
ч
ч
 
.
ч
ч
 
	DropTable
ч
ч
 &
(
ч
ч
& '
name
ш
ш
 
:
ш
ш
 
$str
ш
ш
 (
)
ш
ш
( )
;
ш
ш
) *
migrationBuilder
ъ
ъ
 
.
ъ
ъ
 
	DropTable
ъ
ъ
 &
(
ъ
ъ
& '
name
ы
ы
 
:
ы
ы
 
$str
ы
ы
 (
)
ы
ы
( )
;
ы
ы
) *
migrationBuilder
э
э
 
.
э
э
 
	DropTable
э
э
 &
(
э
э
& '
name
ю
ю
 
:
ю
ю
 
$str
ю
ю
 '
)
ю
ю
' (
;
ю
ю
( )
migrationBuilder
Ё
Ё
 
.
Ё
Ё
 
	DropTable
Ё
Ё
 &
(
Ё
Ё
& '
name
ё
ё
 
:
ё
ё
 
$str
ё
ё
 (
)
ё
ё
( )
;
ё
ё
) *
migrationBuilder
є
є
 
.
є
є
 
	DropTable
є
є
 &
(
є
є
& '
name
Ї
Ї
 
:
Ї
Ї
 
$str
Ї
Ї
 #
)
Ї
Ї
# $
;
Ї
Ї
$ %
migrationBuilder
Ў
Ў
 
.
Ў
Ў
 
	DropTable
Ў
Ў
 &
(
Ў
Ў
& '
name
ў
ў
 
:
ў
ў
 
$str
ў
ў
 !
)
ў
ў
! "
;
ў
ў
" #
migrationBuilder
∙
∙
 
.
∙
∙
 
	DropTable
∙
∙
 &
(
∙
∙
& '
name
·
·
 
:
·
·
 
$str
·
·
 %
)
·
·
% &
;
·
·
& '
migrationBuilder
№
№
 
.
№
№
 
	DropTable
№
№
 &
(
№
№
& '
name
¤
¤
 
:
¤
¤
 
$str
¤
¤
 "
)
¤
¤
" #
;
¤
¤
# $
migrationBuilder
 
 
 
.
 
 
 
	DropTable
 
 
 &
(
 
 
& '
name
АА 
:
АА 
$str
АА .
)
АА. /
;
АА/ 0
migrationBuilder
ВВ 
.
ВВ 
	DropTable
ВВ &
(
ВВ& '
name
ГГ 
:
ГГ 
$str
ГГ &
)
ГГ& '
;
ГГ' (
migrationBuilder
ЕЕ 
.
ЕЕ 
	DropTable
ЕЕ &
(
ЕЕ& '
name
ЖЖ 
:
ЖЖ 
$str
ЖЖ /
)
ЖЖ/ 0
;
ЖЖ0 1
migrationBuilder
ИИ 
.
ИИ 
	DropTable
ИИ &
(
ИИ& '
name
ЙЙ 
:
ЙЙ 
$str
ЙЙ $
)
ЙЙ$ %
;
ЙЙ% &
migrationBuilder
ЛЛ 
.
ЛЛ 
	DropTable
ЛЛ &
(
ЛЛ& '
name
ММ 
:
ММ 
$str
ММ  
)
ММ  !
;
ММ! "
migrationBuilder
ОО 
.
ОО 
	DropTable
ОО &
(
ОО& '
name
ПП 
:
ПП 
$str
ПП %
)
ПП% &
;
ПП& '
migrationBuilder
СС 
.
СС 
	DropTable
СС &
(
СС& '
name
ТТ 
:
ТТ 
$str
ТТ %
)
ТТ% &
;
ТТ& '
migrationBuilder
ФФ 
.
ФФ 
	DropTable
ФФ &
(
ФФ& '
name
ХХ 
:
ХХ 
$str
ХХ 1
)
ХХ1 2
;
ХХ2 3
migrationBuilder
ЧЧ 
.
ЧЧ 
	DropTable
ЧЧ &
(
ЧЧ& '
name
ШШ 
:
ШШ 
$str
ШШ *
)
ШШ* +
;
ШШ+ ,
migrationBuilder
ЪЪ 
.
ЪЪ 
	DropTable
ЪЪ &
(
ЪЪ& '
name
ЫЫ 
:
ЫЫ 
$str
ЫЫ 
)
ЫЫ  
;
ЫЫ  !
migrationBuilder
ЭЭ 
.
ЭЭ 
	DropTable
ЭЭ &
(
ЭЭ& '
name
ЮЮ 
:
ЮЮ 
$str
ЮЮ $
)
ЮЮ$ %
;
ЮЮ% &
migrationBuilder
аа 
.
аа 
	DropTable
аа &
(
аа& '
name
бб 
:
бб 
$str
бб #
)
бб# $
;
бб$ %
migrationBuilder
гг 
.
гг 
	DropTable
гг &
(
гг& '
name
дд 
:
дд 
$str
дд '
)
дд' (
;
дд( )
migrationBuilder
жж 
.
жж 
	DropTable
жж &
(
жж& '
name
зз 
:
зз 
$str
зз "
)
зз" #
;
зз# $
migrationBuilder
йй 
.
йй 
	DropTable
йй &
(
йй& '
name
кк 
:
кк 
$str
кк ,
)
кк, -
;
кк- .
migrationBuilder
мм 
.
мм 
	DropTable
мм &
(
мм& '
name
нн 
:
нн 
$str
нн 
)
нн 
;
нн  
migrationBuilder
пп 
.
пп 
	DropTable
пп &
(
пп& '
name
░░ 
:
░░ 
$str
░░ *
)
░░* +
;
░░+ ,
migrationBuilder
▓▓ 
.
▓▓ 
	DropTable
▓▓ &
(
▓▓& '
name
││ 
:
││ 
$str
││ #
)
││# $
;
││$ %
migrationBuilder
╡╡ 
.
╡╡ 
	DropTable
╡╡ &
(
╡╡& '
name
╢╢ 
:
╢╢ 
$str
╢╢  
)
╢╢  !
;
╢╢! "
migrationBuilder
╕╕ 
.
╕╕ 
	DropTable
╕╕ &
(
╕╕& '
name
╣╣ 
:
╣╣ 
$str
╣╣ 
)
╣╣ 
;
╣╣  
migrationBuilder
╗╗ 
.
╗╗ 
	DropTable
╗╗ &
(
╗╗& '
name
╝╝ 
:
╝╝ 
$str
╝╝ !
)
╝╝! "
;
╝╝" #
migrationBuilder
╛╛ 
.
╛╛ 
	DropTable
╛╛ &
(
╛╛& '
name
┐┐ 
:
┐┐ 
$str
┐┐ 
)
┐┐ 
;
┐┐  
migrationBuilder
┴┴ 
.
┴┴ 
	DropTable
┴┴ &
(
┴┴& '
name
┬┬ 
:
┬┬ 
$str
┬┬ '
)
┬┬' (
;
┬┬( )
migrationBuilder
── 
.
── 
	DropTable
── &
(
──& '
name
┼┼ 
:
┼┼ 
$str
┼┼ '
)
┼┼' (
;
┼┼( )
migrationBuilder
╟╟ 
.
╟╟ 
	DropTable
╟╟ &
(
╟╟& '
name
╚╚ 
:
╚╚ 
$str
╚╚ 
)
╚╚ 
;
╚╚  
migrationBuilder
╩╩ 
.
╩╩ 
	DropTable
╩╩ &
(
╩╩& '
name
╦╦ 
:
╦╦ 
$str
╦╦ #
)
╦╦# $
;
╦╦$ %
migrationBuilder
══ 
.
══ 
	DropTable
══ &
(
══& '
name
╬╬ 
:
╬╬ 
$str
╬╬ "
)
╬╬" #
;
╬╬# $
migrationBuilder
╨╨ 
.
╨╨ 
	DropTable
╨╨ &
(
╨╨& '
name
╤╤ 
:
╤╤ 
$str
╤╤ #
)
╤╤# $
;
╤╤$ %
}
╥╥ 	
}
╙╙ 
}╘╘ хf
qC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Helpers\VNPayHelper\VNPayHandler.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Helpers $
.$ %
VNPayHelper% 0
;0 1
public 
class 
VnPayHandler 
{ 
private 
readonly 

SortedList 
<  
string  &
,& '
string( .
>. /
_requestData0 <
== >
new? B

SortedListC M
<M N
stringN T
,T U
stringV \
>\ ]
(] ^
new^ a
VnPayCompareb n
(n o
)o p
)p q
;q r
private 
readonly 

SortedList 
<  
string  &
,& '
string( .
>. /
_responseData0 =
=> ?
new@ C

SortedListD N
<N O
stringO U
,U V
stringW ]
>] ^
(^ _
new_ b
VnPayComparec o
(o p
)p q
)q r
;r s
public 

void 
AddRequestData 
( 
string %
key& )
,) *
string+ 1
value2 7
)7 8
{ 
if 

( 
! 
string 
. 
IsNullOrEmpty !
(! "
value" '
)' (
)( )
{ 	
_requestData 
. 
Add 
( 
key  
,  !
value" '
)' (
;( )
} 	
} 
public 

void 
AddResponseData 
(  
string  &
key' *
,* +
string, 2
value3 8
)8 9
{ 
if 

( 
! 
string 
. 
IsNullOrEmpty !
(! "
value" '
)' (
)( )
{ 	
_responseData 
. 
Add 
( 
key !
,! "
value# (
)( )
;) *
} 	
}   
public"" 

string"" 
GetResponseData"" !
(""! "
string""" (
key"") ,
)"", -
{## 
return$$ 
_responseData$$ 
.$$ 
TryGetValue$$ (
($$( )
key$$) ,
,$$, -
out$$. 1
var$$2 5
retValue$$6 >
)$$> ?
?$$@ A
retValue$$B J
:$$K L
string$$M S
.$$S T
Empty$$T Y
;$$Y Z
}%% 
public(( 

string(( 
CreateRequestUrl(( "
(((" #
string((# )
baseUrl((* 1
,((1 2
string((3 9
vnpHashSecret((: G
)((G H
{)) 
var** 
data** 
=** 
new** 
StringBuilder** $
(**$ %
)**% &
;**& '
foreach,, 
(,, 
var,, 
(,, 
key,, 
,,, 
value,,  
),,  !
in,," $
_requestData,,% 1
.,,1 2
Where,,2 7
(,,7 8
kv,,8 :
=>,,; =
!,,> ?
string,,? E
.,,E F
IsNullOrEmpty,,F S
(,,S T
kv,,T V
.,,V W
Value,,W \
),,\ ]
),,] ^
),,^ _
{-- 	
data.. 
... 
Append.. 
(.. 

WebUtility.. "
..." #
	UrlEncode..# ,
(.., -
key..- 0
)..0 1
+..2 3
$str..4 7
+..8 9

WebUtility..: D
...D E
	UrlEncode..E N
(..N O
value..O T
)..T U
+..V W
$str..X [
)..[ \
;..\ ]
}// 	
var11 
querystring11 
=11 
data11 
.11 
ToString11 '
(11' (
)11( )
;11) *
baseUrl33 
+=33 
$str33 
+33 
querystring33 $
;33$ %
var44 
signData44 
=44 
querystring44 "
;44" #
if55 

(55 
signData55 
.55 
Length55 
>55 
$num55 
)55  
{66 	
signData77 
=77 
signData77 
.77  
Remove77  &
(77& '
data77' +
.77+ ,
Length77, 2
-773 4
$num775 6
,776 7
$num778 9
)779 :
;77: ;
}88 	
var:: 
vnpSecureHash:: 
=:: 
Utils:: !
.::! "

HmacSHA512::" ,
(::, -
vnpHashSecret::- :
,::: ;
signData::< D
)::D E
;::E F
baseUrl;; 
+=;; 
$str;; $
+;;% &
vnpSecureHash;;' 4
;;;4 5
return== 
baseUrl== 
;== 
}>> 
publicBB 

boolBB 
ValidateSignatureBB !
(BB! "
stringBB" (
	inputHashBB) 2
,BB2 3
stringBB4 :
	secretKeyBB; D
)BBD E
{CC 
varDD 
rspRawDD 
=DD 
GetResponseDataDD $
(DD$ %
)DD% &
;DD& '
varEE 

myChecksumEE 
=EE 
UtilsEE 
.EE 

HmacSHA512EE )
(EE) *
	secretKeyEE* 3
,EE3 4
rspRawEE5 ;
)EE; <
;EE< =
returnFF 

myChecksumFF 
.FF 
EqualsFF  
(FF  !
	inputHashFF! *
,FF* +
StringComparisonFF, <
.FF< =&
InvariantCultureIgnoreCaseFF= W
)FFW X
;FFX Y
}GG 
privateII 
stringII 
GetResponseDataII "
(II" #
)II# $
{JJ 
varKK 
dataKK 
=KK 
newKK 
StringBuilderKK $
(KK$ %
)KK% &
;KK& '
ifLL 

(LL 
_responseDataLL 
.LL 
ContainsKeyLL %
(LL% &
$strLL& :
)LL: ;
)LL; <
{MM 	
_responseDataNN 
.NN 
RemoveNN  
(NN  !
$strNN! 5
)NN5 6
;NN6 7
}OO 	
ifQQ 

(QQ 
_responseDataQQ 
.QQ 
ContainsKeyQQ %
(QQ% &
$strQQ& 6
)QQ6 7
)QQ7 8
{RR 	
_responseDataSS 
.SS 
RemoveSS  
(SS  !
$strSS! 1
)SS1 2
;SS2 3
}TT 	
foreachVV 
(VV 
varVV 
(VV 
keyVV 
,VV 
valueVV  
)VV  !
inVV" $
_responseDataVV% 2
.VV2 3
WhereVV3 8
(VV8 9
kvVV9 ;
=>VV< >
!VV? @
stringVV@ F
.VVF G
IsNullOrEmptyVVG T
(VVT U
kvVVU W
.VVW X
ValueVVX ]
)VV] ^
)VV^ _
)VV_ `
{WW 	
dataXX 
.XX 
AppendXX 
(XX 

WebUtilityXX "
.XX" #
	UrlEncodeXX# ,
(XX, -
keyXX- 0
)XX0 1
+XX2 3
$strXX4 7
+XX8 9

WebUtilityXX: D
.XXD E
	UrlEncodeXXE N
(XXN O
valueXXO T
)XXT U
+XXV W
$strXXX [
)XX[ \
;XX\ ]
}YY 	
if\\ 

(\\ 
data\\ 
.\\ 
Length\\ 
>\\ 
$num\\ 
)\\ 
{]] 	
data^^ 
.^^ 
Remove^^ 
(^^ 
data^^ 
.^^ 
Length^^ #
-^^$ %
$num^^& '
,^^' (
$num^^) *
)^^* +
;^^+ ,
}__ 	
returnaa 
dataaa 
.aa 
ToStringaa 
(aa 
)aa 
;aa 
}bb 
}ee 
publicgg 
classgg 
Utilsgg 
{hh 
publicii 

staticii 
stringii 

HmacSHA512ii #
(ii# $
stringii$ *
keyii+ .
,ii. /
stringii0 6
	inputDataii7 @
)ii@ A
{jj 
varkk 
hashkk 
=kk 
newkk 
StringBuilderkk $
(kk$ %
)kk% &
;kk& '
varll 
keyBytesll 
=ll 
Encodingll 
.ll  
UTF8ll  $
.ll$ %
GetBytesll% -
(ll- .
keyll. 1
)ll1 2
;ll2 3
varmm 

inputBytesmm 
=mm 
Encodingmm !
.mm! "
UTF8mm" &
.mm& '
GetBytesmm' /
(mm/ 0
	inputDatamm0 9
)mm9 :
;mm: ;
usingnn 
(nn 
varnn 
hmacnn 
=nn 
newnn 

HMACSHA512nn (
(nn( )
keyBytesnn) 1
)nn1 2
)nn2 3
{oo 	
varpp 
	hashValuepp 
=pp 
hmacpp  
.pp  !
ComputeHashpp! ,
(pp, -

inputBytespp- 7
)pp7 8
;pp8 9
foreachqq 
(qq 
varqq 
theByteqq  
inqq! #
	hashValueqq$ -
)qq- .
{rr 
hashss 
.ss 
Appendss 
(ss 
theBytess #
.ss# $
ToStringss$ ,
(ss, -
$strss- 1
)ss1 2
)ss2 3
;ss3 4
}tt 
}uu 	
returnww 
hashww 
.ww 
ToStringww 
(ww 
)ww 
;ww 
}xx 
public{{ 

static{{ 
string{{ 
GetIpAddress{{ %
({{% &
){{& '
{|| 
string}} 
	ipAddress}} 
;}} 
try~~ 
{ 	
	ipAddress
АА 
=
АА 
$str
АА 
;
АА 
var
ББ 
host
ББ 
=
ББ 
Dns
ББ 
.
ББ 
GetHostEntry
ББ '
(
ББ' (
Dns
ББ( +
.
ББ+ ,
GetHostName
ББ, 7
(
ББ7 8
)
ББ8 9
)
ББ9 :
;
ББ: ;
foreach
ВВ 
(
ВВ 
var
ВВ 
ip
ВВ 
in
ВВ 
host
ВВ #
.
ВВ# $
AddressList
ВВ$ /
)
ВВ/ 0
{
ГГ 
if
ДД 
(
ДД 
ip
ДД 
.
ДД 
AddressFamily
ДД $
==
ДД% '
AddressFamily
ДД( 5
.
ДД5 6
InterNetwork
ДД6 B
)
ДДB C
{
ЕЕ 
	ipAddress
ЖЖ 
=
ЖЖ 
ip
ЖЖ  "
.
ЖЖ" #
ToString
ЖЖ# +
(
ЖЖ+ ,
)
ЖЖ, -
;
ЖЖ- .
}
ЗЗ 
}
ИИ 
}
ЙЙ 	
catch
КК 
(
КК 
	Exception
КК 
ex
КК 
)
КК 
{
ЛЛ 	
	ipAddress
ММ 
=
ММ 
$str
ММ %
+
ММ& '
ex
ММ( *
.
ММ* +
Message
ММ+ 2
;
ММ2 3
}
НН 	
return
ПП 
	ipAddress
ПП 
;
ПП 
}
РР 
}СС 
publicУУ 
class
УУ 
VnPayCompare
УУ 
:
УУ 
	IComparer
УУ %
<
УУ% &
string
УУ& ,
>
УУ, -
{ФФ 
public
ХХ 

int
ХХ 
Compare
ХХ 
(
ХХ 
string
ХХ 
x
ХХ 
,
ХХ  
string
ХХ! '
y
ХХ( )
)
ХХ) *
{
ЦЦ 
if
ЧЧ 

(
ЧЧ 
x
ЧЧ 
==
ЧЧ 
y
ЧЧ 
)
ЧЧ 
return
ЧЧ 
$num
ЧЧ 
;
ЧЧ 
if
ШШ 

(
ШШ 
x
ШШ 
==
ШШ 
null
ШШ 
)
ШШ 
return
ШШ 
-
ШШ 
$num
ШШ  
;
ШШ  !
if
ЩЩ 

(
ЩЩ 
y
ЩЩ 
==
ЩЩ 
null
ЩЩ 
)
ЩЩ 
return
ЩЩ 
$num
ЩЩ 
;
ЩЩ  
var
ЪЪ 

vnpCompare
ЪЪ 
=
ЪЪ 
CompareInfo
ЪЪ $
.
ЪЪ$ %
GetCompareInfo
ЪЪ% 3
(
ЪЪ3 4
$str
ЪЪ4 ;
)
ЪЪ; <
;
ЪЪ< =
return
ЫЫ 

vnpCompare
ЫЫ 
.
ЫЫ 
Compare
ЫЫ !
(
ЫЫ! "
x
ЫЫ" #
,
ЫЫ# $
y
ЫЫ% &
,
ЫЫ& '
CompareOptions
ЫЫ( 6
.
ЫЫ6 7
Ordinal
ЫЫ7 >
)
ЫЫ> ?
;
ЫЫ? @
}
ЬЬ 
}ЭЭ х

ЕC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Helpers\QRCodeGeneratorHelper\QRCodeGeneratorHandler.cs
	namespace		 	
FOV		
 
.		 
Infrastructure		 
.		 
Helpers		 $
.		$ %!
QRCodeGeneratorHelper		% :
;		: ;
public 
class "
QRCodeGeneratorHandler #
{ 
public 

Bitmap 
GenerateQRCode  
(  !
string! '
url( +
,+ ,
int- 0
size1 5
=6 7
$num8 :
): ;
{ 
QRCodeGenerator 
qrGenerator #
=$ %
new& )
() *
)* +
;+ ,

QRCodeData 

qrCodeData 
= 
qrGenerator  +
.+ ,
CreateQrCode, 8
(8 9
url9 <
,< =
QRCodeGenerator> M
.M N
ECCLevelN V
.V W
QW X
)X Y
;Y Z
QRCode 
qrCode 
= 
new 
( 

qrCodeData &
)& '
;' (
return 
qrCode 
. 

GetGraphic  
(  !
size! %
)% &
;& '
} 
} ю
pC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Helpers\GetHelper\PagingRequest.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Helpers $
.$ %
	GetHelper% .
;. /
public		 
class		 
PagingRequest		 
{

 
public 

int 
Page 
{ 
get 
; 
set 
; 
}  !
=" #
$num$ %
;% &
public 

int 
PageSize 
{ 
get 
; 
set "
;" #
}$ %
=& '
$num( *
;* +
public 

	SortOrder 
SortType 
{ 
get  #
;# $
set% (
;( )
}* +
public 

string 
ColName 
{ 
get 
;  
set! $
;$ %
}& '
=( )
$str* .
;. /
} є
rC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Helpers\GetHelper\PaginationUtils.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Helpers $
.$ %
	GetHelper% .
;. /
public		 
static		 
class		 
PaginationUtils		 #
{

 
public 

static 
( 
int 
page 
, 
int  
pageSize! )
,) *
	SortOrder+ 4
sortType5 =
,= >
string? E
	sortFieldF O
)O P)
GetPaginationAndSortingValuesQ n
(n o
PagingRequesto |
?| }
request	~ Е
)
Е Ж
{ 
var 
page 
= 
request 
? 
. 
Page  
??! #
$num$ %
;% &
var 
pageSize 
= 
request 
? 
.  
PageSize  (
??) +
$num, .
;. /
var 
sortType 
= 
request 
? 
.  
SortType  (
??) +
	SortOrder, 5
.5 6

Descending6 @
;@ A
var 
	sortField 
= 
request 
?  
.  !
ColName! (
??) +
$str, 0
;0 1
return 
( 
page 
, 
pageSize 
, 
sortType  (
,( )
	sortField* 3
)3 4
;4 5
} 
} ▄7
sC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Helpers\GetHelper\PaginationHelper.cs
	namespace		 	
FOV		
 
.		 
Infrastructure		 
.		 
Helpers		 $
.		$ %
	GetHelper		% .
;		. /
public

 
class

 
PaginationHelper

 
<

 
T

 
>

  
where

! &
T

' (
:

) *
class

+ 0
{ 
public 

static 
PagedResult 
< 
T 
>  
EmptyResult! ,
(, -
int- 0
pageSize1 9
)9 :
{ 
return 
new 
PagedResult 
< 
T  
>  !
{ 	
Results 
= 
new 
List 
< 
T  
>  !
(! "
)" #
,# $

PageNumber 
= 
$num 
, 
PageSize 
= 
pageSize 
,  
TotalNumberOfPages 
=  
$num! "
," # 
TotalNumberOfRecords  
=! "
$num# $
} 	
;	 

} 
public 

static 
PagedResult 
< 
T 
>  
Paging! '
(' (
List( ,
<, -
T- .
>. /
list0 4
,4 5
int6 9
?9 :
page; ?
,? @
intA D
?D E
pageSizeF N
)N O
{ 
try 
{ 	
if 
( 
page 
== 
null 
&& 
pageSize  (
==) +
null, 0
)0 1
{ 
pageSize 
= 
list 
.  
Count  %
;% &
page 
= 
$num 
; 
}   
else!! 
if"" 
("" 
page"" 
<"" 
$num"" 
||"" 
pageSize"" $
<""% &
$num""' (
)""( )
{## 
return$$ 
null$$ 
;$$ 
}%% 
var&& 

skipAmount&& 
=&& 
pageSize&& %
*&&& '
(&&( )
page&&) -
-&&. /
$num&&0 1
)&&1 2
;&&2 3
var''  
totalNumberOfRecords'' $
=''% &
list''' +
.''+ ,
Count'', 1
;''1 2
var(( 
results(( 
=(( 
list(( 
.(( 
Skip(( #
(((# $
((($ %
int((% (
)((( )

skipAmount(() 3
)((3 4
.((4 5
Take((5 9
(((9 :
(((: ;
int((; >
)((> ?
pageSize((? G
)((G H
.((H I
ToList((I O
(((O P
)((P Q
;((Q R
var)) 
mod)) 
=))  
totalNumberOfRecords)) *
%))+ ,
pageSize))- 5
;))5 6
var** 
totalPageCount** 
=**   
totalNumberOfRecords**! 5
/**6 7
pageSize**8 @
+**A B
(**C D
mod**D G
==**H J
$num**K L
?**M N
$num**O P
:**Q R
$num**S T
)**T U
;**U V
return++ 
new++ 
PagedResult++ "
<++" #
T++# $
>++$ %
{,, 
Results-- 
=-- 
results-- !
,--! "

PageNumber.. 
=.. 
(.. 
int.. !
)..! "
page.." &
,..& '
PageSize// 
=// 
(// 
int// 
)//  
pageSize//  (
,//( )
TotalNumberOfPages00 "
=00# $
(00% &
int00& )
)00) *
totalPageCount00* 8
,008 9 
TotalNumberOfRecords11 $
=11% & 
totalNumberOfRecords11' ;
,11; <
}22 
;22 
}33 	
catch44 
(44 
	Exception44 
)44 
{55 	
return66 
null66 
;66 
}77 	
}88 
public99 

static99 
List99 
<99 
T99 
>99 
Sorting99 !
(99! "
	SortOrder99" +
sortType99, 4
,994 5
IEnumerable996 A
<99A B
T99B C
>99C D
searchResult99E Q
,99Q R
string99S Y
colName99Z a
)99a b
{:: 
var;; 
property;; 
=;; 
typeof;; 
(;; 
T;; 
);;  
.;;  !
GetProperties;;! .
(;;. /
);;/ 0
.;;0 1
FirstOrDefault;;1 ?
(;;? @
x;;@ A
=>;;B D
x;;E F
.;;F G
Name;;G K
.;;K L
Equals;;L R
(;;R S
colName;;S Z
,;;Z [
StringComparison;;\ l
.;;l m%
CurrentCultureIgnoreCase	;;m Е
)
;;Е Ж
)
;;Ж З
;
;;З И
if== 

(== 
property== 
==== 
null== 
)== 
{>> 	
throw?? 
new?? 
ArgumentException?? '
(??' (
$"??( *
$str??* 2
{??2 3
colName??3 :
}??: ;
$str??; U
{??U V
typeof??V \
(??\ ]
T??] ^
)??^ _
.??_ `
Name??` d
}??d e
$str??e g
"??g h
)??h i
;??i j
}@@ 	
ifBB 

(BB 
sortTypeBB 
==BB 
	SortOrderBB !
.BB! "
	AscendingBB" +
)BB+ ,
{CC 	
returnDD 
searchResultDD 
.DD  
OrderByDD  '
(DD' (
itemDD( ,
=>DD- /
propertyDD0 8
.DD8 9
GetValueDD9 A
(DDA B
itemDDB F
)DDF G
)DDG H
.DDH I
ToListDDI O
(DDO P
)DDP Q
;DDQ R
}EE 	
elseFF 
ifFF 
(FF 
sortTypeFF 
==FF 
	SortOrderFF &
.FF& '

DescendingFF' 1
)FF1 2
{GG 	
returnHH 
searchResultHH 
.HH  
OrderByDescendingHH  1
(HH1 2
itemHH2 6
=>HH7 9
propertyHH: B
.HHB C
GetValueHHC K
(HHK L
itemHHL P
)HHP Q
)HHQ R
.HHR S
ToListHHS Y
(HHY Z
)HHZ [
;HH[ \
}II 	
elseJJ 
{KK 	
returnLL 
searchResultLL 
.LL  
ToListLL  &
(LL& '
)LL' (
;LL( )
}MM 	
}NN 
}PP с	
nC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Helpers\GetHelper\PagedResult.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Helpers $
.$ %
	GetHelper% .
;. /
public 
class 
PagedResult 
< 
T 
> 
{		 
public 

int 

PageNumber 
{ 
get 
;  
set! $
;$ %
}& '
public 

int 
PageSize 
{ 
get 
; 
set "
;" #
}$ %
public 

int 
TotalNumberOfPages !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 

int  
TotalNumberOfRecords #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public!! 

List!! 
<!! 
T!! 
>!! 
Results!! 
{!! 
get!!  
;!!  !
set!!" %
;!!% &
}!!' (
}"" Й^
oC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Helpers\GetHelper\CustomFilter.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Helpers $
.$ %
	GetHelper% .
;. /
public

 
static

 
class

 
CustomFilter

  
{ 
public 

static 

IQueryable 
< 
TEntity $
>$ %
CustomFilterV1& 4
<4 5
TEntity5 <
>< =
(= >
this> B

IQueryableC M
<M N
TEntityN U
>U V
sourceW ]
,] ^
TEntity_ f
entityg m
)m n
{ 
if 

( 
entity 
== 
null 
) 
{ 	
throw 
new !
ArgumentNullException +
(+ ,
nameof, 2
(2 3
entity3 9
)9 :
): ;
;; <
} 	
foreach 
( 
PropertyInfo 
property &
in' )
entity* 0
.0 1
GetType1 8
(8 9
)9 :
.: ;
GetProperties; H
(H I
)I J
)J K
{ 	
var 
value 
= 
property  
.  !
GetValue! )
() *
entity* 0
)0 1
;1 2
if 
( 
value 
== 
null 
||  
(! "
value" '
is( *
string+ 1
str2 5
&&6 8
string9 ?
.? @
IsNullOrEmpty@ M
(M N
strN Q
)Q R
)R S
||T V
(W X
valueX ]
is^ `
Guida e
guidf j
&&k m
guidn r
==s u
Guidv z
.z {
Empty	{ А
)
А Б
||
В Д
property
Е Н
.
Н О
CustomAttributes
О Ю
.
Ю Я
Any
Я в
(
в г
a
г д
=>
е з
a
и й
.
й к
AttributeType
к ╖
==
╕ ║
typeof
╗ ┴
(
┴ ┬
SkipAttribute
┬ ╧
)
╧ ╨
)
╨ ╤
)
╤ ╥
{ 
continue 
; 
} 
var 
propertyName 
= 
property '
.' (
Name( ,
;, -
if 
( 
property 
. 
PropertyType %
==& (
typeof) /
(/ 0
string0 6
)6 7
)7 8
{ 
var 
stringValue 
=  !
value" '
.' (
ToString( 0
(0 1
)1 2
.2 3
ToLower3 :
(: ;
); <
;< =
source   
=   
source   
.    
Where    %
(  % &
$"  & (
{  ( )
propertyName  ) 5
}  5 6
$str  6 M
"  M N
,  N O
stringValue  P [
)  [ \
;  \ ]
}!! 
else"" 
if"" 
("" 
property"" 
."" 
PropertyType"" *
==""+ -
typeof"". 4
(""4 5
Guid""5 9
)""9 :
||""; =
property""> F
.""F G
PropertyType""G S
==""T V
typeof""W ]
(""] ^
Guid""^ b
?""b c
)""c d
)""d e
{## 
if$$ 
($$ 
property$$ 
.$$ 
CustomAttributes$$ -
.$$- .
Any$$. 1
($$1 2
a$$2 3
=>$$4 6
a$$7 8
.$$8 9
AttributeType$$9 F
==$$G I
typeof$$J P
($$P Q
GuidAttribute$$Q ^
)$$^ _
)$$_ `
&&$$a c
value$$d i
is$$j l
Guid$$m q
	guidValue$$r {
&&$$| ~
	guidValue	$$ И
!=
$$Й Л
Guid
$$М Р
.
$$Р С
Empty
$$С Ц
)
$$Ц Ч
{%% 
source&& 
=&& 
source&& #
.&&# $
Where&&$ )
(&&) *
$"&&* ,
{&&, -
propertyName&&- 9
}&&9 :
$str&&: @
"&&@ A
,&&A B
	guidValue&&C L
)&&L M
;&&M N
}'' 
}(( 
else)) 
if)) 
()) 
property)) 
.)) 
PropertyType)) *
.))* +
IsEnum))+ 1
)))1 2
{** 
var++ 
	enumValue++ 
=++ 
(++  !
Enum++! %
)++% &
value++& +
;+++ ,
if-- 
(-- 
Enum-- 
.-- 
GetUnderlyingType-- *
(--* +
property--+ 3
.--3 4
PropertyType--4 @
)--@ A
==--B D
typeof--E K
(--K L
byte--L P
)--P Q
)--Q R
{.. 
var// 
	byteValue// !
=//" #
Convert//$ +
.//+ ,
ToByte//, 2
(//2 3
value//3 8
)//8 9
;//9 :
if00 
(00 
	byteValue00 !
==00" $
$num00% &
)00& '
{11 
continue22  
;22  !
}33 
source44 
=44 
source44 #
.44# $
Where44$ )
(44) *
$"44* ,
{44, -
propertyName44- 9
}449 :
$str44: @
"44@ A
,44A B
	byteValue44C L
)44L M
;44M N
}55 
else66 
{77 
source88 
=88 
source88 #
.88# $
Where88$ )
(88) *
$"88* ,
{88, -
propertyName88- 9
}889 :
$str88: @
"88@ A
,88A B
	enumValue88C L
)88L M
;88M N
}99 
}:: 
else;; 
if;; 
(;; 
property;; 
.;; 
CustomAttributes;; .
.;;. /
Any;;/ 2
(;;2 3
a;;3 4
=>;;5 7
a;;8 9
.;;9 :
AttributeType;;: G
==;;H J
typeof;;K Q
(;;Q R
IntAttribute;;R ^
);;^ _
);;_ `
);;` a
{<< 
source== 
=== 
source== 
.==  
Where==  %
(==% &
$"==& (
{==( )
propertyName==) 5
}==5 6
$str==6 <
"==< =
,=== >
value==? D
)==D E
;==E F
}>> 
else?? 
if?? 
(?? 
property?? 
.?? 
CustomAttributes?? .
.??. /
Any??/ 2
(??2 3
a??3 4
=>??5 7
a??8 9
.??9 :
AttributeType??: G
==??H J
typeof??K Q
(??Q R
BooleanAttribute??R b
)??b c
)??c d
)??d e
{@@ 
sourceAA 
=AA 
sourceAA 
.AA  
WhereAA  %
(AA% &
$"AA& (
{AA( )
propertyNameAA) 5
}AA5 6
$strAA6 <
"AA< =
,AA= >
valueAA? D
)AAD E
;AAE F
}BB 
elseCC 
ifCC 
(CC 
propertyCC 
.CC 
CustomAttributesCC .
.CC. /
AnyCC/ 2
(CC2 3
aCC3 4
=>CC5 7
aCC8 9
.CC9 :
AttributeTypeCC: G
==CCH J
typeofCCK Q
(CCQ R
DateRangeAttributeCCR d
)CCd e
)CCe f
)CCf g
{DD 
ifEE 
(EE 
valueEE 
isEE 
DateTimeEE %
dateEE& *
)EE* +
{FF 
sourceGG 
=GG 
sourceGG #
.GG# $
WhereGG$ )
(GG) *
$"GG* ,
{GG, -
propertyNameGG- 9
}GG9 :
$strGG: D
{GGD E
propertyNameGGE Q
}GGQ R
$strGGR W
"GGW X
,GGX Y
dateGGZ ^
.GG^ _
DateGG_ c
,GGc d
dateGGe i
.GGi j
DateGGj n
.GGn o
AddDaysGGo v
(GGv w
$numGGw z
)GGz {
)GG{ |
;GG| }
}HH 
}II 
elseJJ 
ifJJ 
(JJ 
propertyJJ 
.JJ 
CustomAttributesJJ .
.JJ. /
AnyJJ/ 2
(JJ2 3
aJJ3 4
=>JJ5 7
aJJ8 9
.JJ9 :
AttributeTypeJJ: G
==JJH J
typeofJJK Q
(JJQ R
ChildAttributeJJR `
)JJ` a
)JJa b
)JJb c
{KK 
foreachLL 
(LL 
varLL 
childPropertyLL *
inLL+ -
propertyLL. 6
.LL6 7
PropertyTypeLL7 C
.LLC D
GetPropertiesLLD Q
(LLQ R
)LLR S
)LLS T
{MM 
varNN 

childValueNN "
=NN# $
childPropertyNN% 2
.NN2 3
GetValueNN3 ;
(NN; <
valueNN< A
)NNA B
;NNB C
ifOO 
(OO 

childValueOO "
!=OO# %
nullOO& *
)OO* +
{PP 
sourceQQ 
=QQ  
sourceQQ! '
.QQ' (
WhereQQ( -
(QQ- .
$"QQ. 0
{QQ0 1
propertyNameQQ1 =
}QQ= >
$strQQ> ?
{QQ? @
childPropertyQQ@ M
.QQM N
NameQQN R
}QQR S
$strQQS Y
"QQY Z
,QQZ [

childValueQQ\ f
)QQf g
;QQg h
}RR 
}SS 
}TT 
elseUU 
ifUU 
(UU 
propertyUU 
.UU 
CustomAttributesUU .
.UU. /
AnyUU/ 2
(UU2 3
aUU3 4
=>UU5 7
aUU8 9
.UU9 :
AttributeTypeUU: G
==UUH J
typeofUUK Q
(UUQ R
SortAttributeUUR _
)UU_ `
)UU` a
)UUa b
{VV 
varWW 

sortParamsWW 
=WW  
valueWW! &
.WW& '
ToStringWW' /
(WW/ 0
)WW0 1
.WW1 2
SplitWW2 7
(WW7 8
$strWW8 <
)WW< =
;WW= >
ifXX 
(XX 

sortParamsXX 
.XX 
LengthXX %
==XX& (
$numXX) *
)XX* +
{YY 
varZZ 
	sortOrderZZ !
=ZZ" #

sortParamsZZ$ .
[ZZ. /
$numZZ/ 0
]ZZ0 1
.ZZ1 2
EqualsZZ2 8
(ZZ8 9
$strZZ9 >
,ZZ> ?
StringComparisonZZ@ P
.ZZP Q
OrdinalIgnoreCaseZZQ b
)ZZb c
?ZZd e
stringZZf l
.ZZl m
EmptyZZm r
:ZZs t
$str	ZZu В
;
ZZВ Г
source[[ 
=[[ 
source[[ #
.[[# $
OrderBy[[$ +
([[+ ,
$"[[, .
{[[. /

sortParams[[/ 9
[[[9 :
$num[[: ;
][[; <
}[[< =
{[[= >
	sortOrder[[> G
}[[G H
"[[H I
)[[I J
;[[J K
}\\ 
else]] 
{^^ 
source__ 
=__ 
source__ #
.__# $
OrderBy__$ +
(__+ ,

sortParams__, 6
[__6 7
$num__7 8
]__8 9
)__9 :
;__: ;
}`` 
}aa 
}bb 	
returncc 
sourcecc 
;cc 
}dd 
}ee ю-
vC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Helpers\FirebaseHelper\StorageHandler.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Helpers $
.$ %
FirebaseHandler% 4
;4 5
public 
record 
StorageFile 
{ 
public		 

string		 
FileName		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
=		) *
default		+ 2
!		2 3
;		3 4
public

 

string

 
FileUrl

 
{

 
get

 
;

  
set

! $
;

$ %
}

& '
=

( )
default

* 1
!

1 2
;

2 3
} 
public 
class 
StorageHandler 
{ 
private 
readonly 
FirebaseStorage $
_firebaseStorage% 5
;5 6
public 

StorageHandler 
( 
IConfiguration (
configuration) 6
)6 7
{ 
string 
apiKey 
= 
configuration %
[% &
$str& 7
]7 8
;8 9
string 
bucket 
= 
configuration %
[% &
$str& 7
]7 8
;8 9
_firebaseStorage 
= 
new 
FirebaseStorage .
(. /
bucket/ 5
,5 6
new7 :"
FirebaseStorageOptions; Q
{ 	!
AuthTokenAsyncFactory !
=" #
($ %
)% &
=>' )
Task* .
.. /

FromResult/ 9
(9 :
apiKey: @
)@ A
} 	
)	 

;
 
} 
public 

async 
Task 
< 
StorageFile !
>! "&
UploadQrImageForTableAsync# =
(= >
Stream> D
qrImageStreamE R
,R S
stringT Z
fileName[ c
)c d
{ 
var 
fileUrl 
= 
await 
_firebaseStorage ,
. 
Child 
( 
$str 
) 
. 
Child 
( 
fileName 
) 
. 
PutAsync 
( 
qrImageStream #
)# $
;$ %
return!! 
new!! 
StorageFile!! 
{"" 	
FileName## 
=## 
fileName## 
,##  
FileUrl$$ 
=$$ 
fileUrl$$ 
}%% 	
;%%	 

}&& 
public'' 

async'' 
Task'' 
<'' 
StorageFile'' !
>''! "+
UploadQrImageForAttendanceAsync''# B
(''B C
Stream''C I
qrImageStream''J W
,''W X
string''Y _
fileName''` h
)''h i
{(( 
var)) 
fileUrl)) 
=)) 
await)) 
_firebaseStorage)) ,
.** 
Child** 
(** 
$str** 
)**  
.++ 
Child++ 
(++ 
fileName++ 
)++ 
.,, 
PutAsync,, 
(,, 
qrImageStream,, #
),,# $
;,,$ %
return.. 
new.. 
StorageFile.. 
{// 	
FileName00 
=00 
fileName00 
,00  
FileUrl11 
=11 
fileUrl11 
}22 	
;22	 

}33 
public55 

async55 
Task55 
<55 
StorageFile55 !
>55! "
UploadImageAsync55# 3
(553 4
	IFormFile554 =
file55> B
,55B C
string55D J
fileName55K S
)55S T
{66 
if77 

(77 
file77 
==77 
null77 
||77 
file77  
.77  !
Length77! '
==77( *
$num77+ ,
)77, -
{88 	
throw99 
new99 
	Exception99 
(99  
$str99  B
)99B C
;99C D
}:: 	
using<< 
var<< 
stream<< 
=<< 
file<< 
.<<  
OpenReadStream<<  .
(<<. /
)<</ 0
;<<0 1
var== 
cancellation== 
=== 
_firebaseStorage== +
.>> 
Child>> 
(>> 
fileName>> 
)>> 
.?? 
Child?? 
(?? 
file?? 
.?? 
FileName??  
)??  !
.@@ 
PutAsync@@ 
(@@ 
stream@@ 
,@@ 
CancellationToken@@ /
.@@/ 0
None@@0 4
)@@4 5
;@@5 6
tryBB 
{CC 	
varDD 
resultDD 
=DD 
awaitDD 
cancellationDD +
;DD+ ,
returnFF 
newFF 
StorageFileFF "
{GG 
FileNameHH 
=HH 
fileNameHH #
,HH# $
FileUrlII 
=II 
resultII  
}JJ 
;JJ 
}KK 	
catchLL 
(LL 
	ExceptionLL 
exLL 
)LL 
{MM 	
throwNN 
newNN 
	ExceptionNN 
(NN  
$"NN  "
$strNN" :
{NN: ;
exNN; =
.NN= >
MessageNN> E
}NNE F
"NNF G
)NNG H
;NNH I
}OO 	
}PP 
}SS з
\C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\GlobalUsing.cs
	namespace 	
FOV
 
. 
Infrastructure 
{ 
public		 

class		 
GlobalUsing		 
{

 
} 
} ╠
sC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Elastic\Service\UserElasticService.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Elastic $
.$ %
Service% ,
;, -
public 
class 
UserElasticService 
:  !!
ElasticGenericService" 7
<7 8

UserDomain8 B
>B C
,C D
IUserElasticServiceE X
{ 
public		 

UserElasticService		 
(		 
IOptions		 &
<		& '
ElasticSettings		' 6
>		6 7
optionsMonitor		8 F
)		F G
:		H I
base		J N
(		N O
optionsMonitor		O ]
)		] ^
{

 
} 
} ╚;
vC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Elastic\Service\ElasticGenericService.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Elastic $
.$ %
Service% ,
;, -
public 
class !
ElasticGenericService "
<" #
TEntity# *
>* +
:, -"
IElasticGenericService. D
<D E
TEntityE L
>L M
whereN S
TEntityT [
:\ ]
ElasticEntity^ k
{ 
private 
readonly 
ElasticsearchClient (
_client) 0
;0 1
private 
readonly 
ElasticSettings $
_elasticSettings% 5
;5 6
public 
!
ElasticGenericService  
(  !
IOptions! )
<) *
ElasticSettings* 9
>9 :
optionsMonitor; I
)I J
{ 
_elasticSettings 
= 
optionsMonitor )
.) *
Value* /
;/ 0
var 
settings 
= 
new '
ElasticsearchClientSettings 6
(6 7
new7 :
Uri; >
(> ?
_elasticSettings? O
.O P
UrlP S
)S T
)T U
.U V
DefaultIndexV b
(b c
_elasticSettingsc s
.s t
DefaultIndex	t А
)
А Б
;
Б В
_client 
= 
new 
ElasticsearchClient )
() *
settings* 2
)2 3
;3 4
} 
public 

async 
Task 
< 
bool 
> 
AddOrUpdate '
(' (
TEntity( /
entity0 6
)6 7
{ 
var 
response 
= 
await 
_client $
.$ %

IndexAsync% /
(/ 0
entity0 6
,6 7
idx8 ;
=>< >
idx? B
.B C
IndexC H
(H I
_elasticSettingsI Y
.Y Z
DefaultIndexZ f
)f g
.g h
OpTypeh n
(n o
OpTypeo u
.u v
Indexv {
){ |
)| }
;} ~
return 
response 
. 
IsValidResponse '
;' (
} 
public!! 

async!! 
Task!! 
<!! 
bool!! 
>!! 
AddOrUpdateBulk!! +
(!!+ ,
IEnumerable!!, 7
<!!7 8
TEntity!!8 ?
>!!? @
entities!!A I
,!!I J
string!!K Q
	indexName!!R [
)!![ \
{"" 
var## 
response## 
=## 
await## 
_client## $
.##$ %
	BulkAsync##% .
(##. /
x##/ 0
=>##1 3
x##4 5
.##5 6
Index##6 ;
(##; <
_elasticSettings##< L
.##L M
DefaultIndex##M Y
)##Y Z
.##Z [

UpdateMany##[ e
(##e f
entities##f n
,##n o
(##p q
ud##q s
,##s t
u##u v
)##v w
=>##x z
ud##{ }
.##} ~
Doc	##~ Б
(
##Б В
u
##В Г
)
##Г Д
.
##Д Е
DocAsUpsert
##Е Р
(
##Р С
true
##С Х
)
##Х Ц
)
##Ц Ч
)
##Ч Ш
;
##Ш Щ
return&& 
response&& 
.&& 
IsValidResponse&& '
;&&' (
}'' 
public)) 

async)) 
Task)) &
CreateIndexIfNotExitsAsync)) 0
())0 1
string))1 7
	indexName))8 A
)))A B
{** 
if++ 

(++ 
!++ 
_client++ 
.++ 
Indices++ 
.++ 
Exists++ #
(++# $
	indexName++$ -
)++- .
.++. /
Exists++/ 5
)++5 6
await,, 
_client,, 
.,, 
Indices,, !
.,,! "
CreateAsync,," -
(,,- .
	indexName,,. 7
),,7 8
;,,8 9
}-- 
public// 

async// 
Task// 
<// 
TEntity// 
>// 
Get// "
(//" #
string//# )
key//* -
)//- .
{00 
var11 
response11 
=11 
await11 
_client11 $
.11$ %
GetAsync11% -
<11- .
TEntity11. 5
>115 6
(116 7
key117 :
,11: ;
g11< =
=>11> @
g11A B
.11B C
Index11C H
(11H I
_elasticSettings11I Y
.11Y Z
DefaultIndex11Z f
)11f g
)11g h
;11h i
return33 
response33 
.33 
Source33 
;33 
}44 
public66 

async66 
Task66 
<66 
List66 
<66 
TEntity66 "
>66" #
>66# $
GetAll66% +
(66+ ,
)66, -
{77 
var88 
response88 
=88 
await88 
_client88 $
.88$ %
SearchAsync88% 0
<880 1
TEntity881 8
>888 9
(889 :
g88: ;
=>88< >
g88? @
.88@ A
Index88A F
(88F G
_elasticSettings88G W
.88W X
DefaultIndex88X d
)88d e
)88e f
;88f g
return:: 
response:: 
.:: 
IsValidResponse:: '
?::( )
response::* 2
.::2 3
	Documents::3 <
.::< =
ToList::= C
(::C D
)::D E
:::F G
default::H O
;::O P
};; 
public== 

async== 
Task== 
<== 
bool== 
>== 
Remove== "
(==" #
string==# )
key==* -
)==- .
{>> 
var?? 
response?? 
=?? 
await?? 
_client?? $
.??$ %
DeleteAsync??% 0
<??0 1
TEntity??1 8
>??8 9
(??9 :
key??: =
,??= >
g??? @
=>??A C
g??D E
.??E F
Index??F K
(??K L
_elasticSettings??L \
.??\ ]
DefaultIndex??] i
)??i j
)??j k
;??k l
return@@ 
response@@ 
.@@ 
IsValidResponse@@ '
;@@' (
}AA 
publicCC 

asyncCC 
TaskCC 
<CC 
longCC 
?CC 
>CC 
	RemoveAllCC &
(CC& '
)CC' (
{DD 
varEE 
responseEE 
=EE 
awaitEE 
_clientEE $
.EE$ %
DeleteByQueryAsyncEE% 7
<EE7 8
TEntityEE8 ?
>EE? @
(EE@ A
xEEA B
=>EEC E
xEEF G
.EEG H
IndicesEEH O
(EEO P
_elasticSettingsEEP `
.EE` a
DefaultIndexEEa m
)EEm n
)EEn o
;EEo p
returnFF 
responseFF 
.FF 
DeletedFF 
;FF  
}GG 
}HH э
uC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Elastic\IService\IUserElasticService.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Elastic $
.$ %
IService% -
;- .
public 
	interface 
IUserElasticService $
:% &"
IElasticGenericService' =
<= >

UserDomain> H
>H I
{ 
} ё
xC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Elastic\IService\IElasticGenericService.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Elastic $
.$ %
IService% -
;- .
public		 
	interface		 "
IElasticGenericService		 '
<		' (
T		( )
>		) *
where		+ 0
T		1 2
:		3 4
ElasticEntity		5 B
{

 
Task &
CreateIndexIfNotExitsAsync	 #
(# $
string$ *
	indexName+ 4
)4 5
;5 6
Task 
< 	
bool	 
> 
AddOrUpdate 
( 
T 
entity #
)# $
;$ %
Task 
< 	
bool	 
> 
AddOrUpdateBulk 
( 
IEnumerable *
<* +
T+ ,
>, -
entities. 6
,6 7
string8 >
	indexName? H
)H I
;I J
Task 
< 	
T	 

>
 
Get 
( 
string 
key 
) 
; 
Task 
< 	
List	 
< 
T 
> 
> 
GetAll 
( 
) 
; 
Task 
< 	
bool	 
> 
Remove 
( 
string 
key  
)  !
;! "
Task 
< 	
long	 
? 
> 
	RemoveAll 
( 
) 
; 
} яA
`C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FOVContext.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
;! "
public 
class 

FOVContext 
: 
IdentityDbContext +
<+ ,
User, 0
>0 1
,1 2!
IApplicationDbContext3 H
{ 
public 


FOVContext 
( 
DbContextOptions &
<& '

FOVContext' 1
>1 2
options3 :
): ;
:< =
base> B
(B C
optionsC J
)J K
{ 
} 
public   

DbSet   
<   

Ingredient   
>   
Ingredients   (
=>  ) +
Set  , /
<  / 0

Ingredient  0 :
>  : ;
(  ; <
)  < =
;  = >
public"" 

DbSet"" 
<"" 
IngredientType"" 
>""  
IngredientTypes""! 0
=>""1 3
Set""4 7
<""7 8
IngredientType""8 F
>""F G
(""G H
)""H I
;""I J
public$$ 

DbSet$$ 
<$$ 
IngredientGeneral$$ "
>$$" #
IngredientGenerals$$$ 6
=>$$7 9
Set$$: =
<$$= >
IngredientGeneral$$> O
>$$O P
($$P Q
)$$Q R
;$$R S
public&& 

DbSet&& 
<&& $
ProductIngredientGeneral&& )
>&&) *%
ProductIngredientGenerals&&+ D
=>&&E G
Set&&H K
<&&K L$
ProductIngredientGeneral&&L d
>&&d e
(&&e f
)&&f g
;&&g h
public(( 

DbSet(( 
<(( 
ProductGeneral(( 
>((  
ProductGenerals((! 0
=>((1 3
Set((4 7
<((7 8
ProductGeneral((8 F
>((F G
(((G H
)((H I
;((I J
public** 

DbSet** 
<** 
Category** 
>** 

Categories** %
=>**& (
Set**) ,
<**, -
Category**- 5
>**5 6
(**6 7
)**7 8
;**8 9
public,, 

DbSet,, 
<,, 
ProductIngredient,, "
>,," #
ProductIngredients,,$ 6
=>,,7 9
Set,,: =
<,,= >
ProductIngredient,,> O
>,,O P
(,,P Q
),,Q R
;,,R S
public.. 

DbSet.. 
<.. 
Product.. 
>.. 
Products.. "
=>..# %
Set..& )
<..) *
Product..* 1
>..1 2
(..2 3
)..3 4
;..4 5
public// 

DbSet// 
<// 

Attendance// 
>// 
Attendances// (
=>//) +
Set//, /
</// 0

Attendance//0 :
>//: ;
(//; <
)//< =
;//= >
public00 

DbSet00 
<00 
Order00 
>00 
Orders00 
=>00 !
Set00" %
<00% &
Order00& +
>00+ ,
(00, -
)00- .
;00. /
public11 

DbSet11 
<11 
OrderDetail11 
>11 
OrderDetails11 *
=>11+ -
Set11. 1
<111 2
OrderDetail112 =
>11= >
(11> ?
)11? @
;11@ A
public22 

DbSet22 
<22 
ProductCombo22 
>22 
ProductCombos22 ,
=>22- /
Set220 3
<223 4
ProductCombo224 @
>22@ A
(22A B
)22B C
;22C D
public33 

DbSet33 
<33 
Table33 
>33 
Tables33 
=>33 !
Set33" %
<33% &
Table33& +
>33+ ,
(33, -
)33- .
;33. /
public55 

DbSet55 
<55 
Customer55 
>55 
	Customers55 $
=>55% '
Set55( +
<55+ ,
Customer55, 4
>554 5
(555 6
)556 7
;557 8
public77 

DbSet77 
<77 
Employee77 
>77 
	Employees77 $
=>77% '
Set77( +
<77+ ,
Employee77, 4
>774 5
(775 6
)776 7
;777 8
public99 

DbSet99 
<99 !
IngredientTransaction99 &
>99& '"
IngredientTransactions99( >
=>99? A
Set99B E
<99E F!
IngredientTransaction99F [
>99[ \
(99\ ]
)99] ^
;99^ _
public;; 

DbSet;; 
<;; 
Combo;; 
>;; 
Combos;; 
=>;; !
Set;;" %
<;;% &
Combo;;& +
>;;+ ,
(;;, -
);;- .
;;;. /
public<< 

DbSet<< 
<<< 
Shift<< 
><< 
Shifts<< 
=><< !
Set<<" %
<<<% &
Shift<<& +
><<+ ,
(<<, -
)<<- .
;<<. /
public== 

DbSet== 
<== 
WaiterSchedule== 
>==  
WaiterSchedules==! 0
=>==1 3
Set==4 7
<==7 8
WaiterSchedule==8 F
>==F G
(==G H
)==H I
;==I J
public?? 

DbSet?? 
<?? 
	GroupChat?? 
>?? 

GroupChats?? &
=>??' )
Set??* -
<??- .
	GroupChat??. 7
>??7 8
(??8 9
)??9 :
;??: ;
publicAA 

DbSetAA 
<AA 
	GroupUserAA 
>AA 

GroupUsersAA &
=>AA' )
SetAA* -
<AA- .
	GroupUserAA. 7
>AA7 8
(AA8 9
)AA9 :
;AA: ;
publicCC 

DbSetCC 
<CC 
GroupMessageCC 
>CC 
GroupMessagesCC ,
=>CC- /
SetCC0 3
<CC3 4
GroupMessageCC4 @
>CC@ A
(CCA B
)CCB C
;CCC D
publicEE 

DbSetEE 
<EE 

RestaurantEE 
>EE 
RestaurantsEE (
=>EE) +
SetEE, /
<EE/ 0

RestaurantEE0 :
>EE: ;
(EE; <
)EE< =
;EE= >
publicGG 

DbSetGG 
<GG 
ProductImageGG 
>GG 
ProductImagesGG ,
=>GG- /
SetGG0 3
<GG3 4
ProductImageGG4 @
>GG@ A
(GGA B
)GGB C
;GGC D
publicHH 

DbSetHH 
<HH 
PaymentsHH 
>HH 
PaymentsHH #
=>HH$ &
SetHH' *
<HH* +
PaymentsHH+ 3
>HH3 4
(HH4 5
)HH5 6
;HH6 7
publicII 

DbSetII 
<II 
RatingII 
>II 
RatingsII  
=>II! #
SetII$ '
<II' (
RatingII( .
>II. /
(II/ 0
)II0 1
;II1 2
publicKK 

DbSetKK 
<KK 
NewProductRecommendKK $
>KK$ % 
NewProductRecommendsKK& :
=>KK; =
SetKK> A
<KKA B
NewProductRecommendKKB U
>KKU V
(KKV W
)KKW X
;KKX Y
publicMM 

DbSetMM 
<MM "
NewProductRecommendLogMM '
>MM' (#
NewProductRecommendLogsMM) @
=>MMA C
SetMMD G
<MMG H"
NewProductRecommendLogMMH ^
>MM^ _
(MM_ `
)MM` a
;MMa b
	protectedOO 
overrideOO 
voidOO 
OnModelCreatingOO +
(OO+ ,
ModelBuilderOO, 8
builderOO9 @
)OO@ A
{PP 
baseQQ 
.QQ 
OnModelCreatingQQ 
(QQ 
builderQQ $
)QQ$ %
;QQ% &
builderRR 
.RR +
ApplyConfigurationsFromAssemblyRR /
(RR/ 0
AssemblyRR0 8
.RR8 9 
GetExecutingAssemblyRR9 M
(RRM N
)RRN O
)RRO P
;RRP Q
}WW 
}XX Є<
dC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\DependencyInjection.cs
	namespace 	
FOV
 
. 
Infrastructure 
; 
public 
static 
class 
DependencyInjection '
{ 
public 

static 
object 
AddInfrastructureDI ,
(, -
this- 1
IServiceCollection2 D
servicesE M
)M N
{ 
services 
. 
AddSingleton 
< 
IUserElasticService 1
,1 2
UserElasticService3 E
>E F
(F G
)G H
;H I
services 
. 
	AddScoped 
< (
IIngredientGeneralRepository 7
,7 8'
IngredientGeneralRepository9 T
>T U
(U V
)V W
;W X
services 
. 
	AddScoped 
< %
IIngredientTypeRepository 4
,4 5$
IngredientTypeRepository6 N
>N O
(O P
)P Q
;Q R
services 
. 
	AddScoped 
< 
ITableRepository +
,+ ,
TableRepository- <
>< =
(= >
)> ?
;? @
services 
. 
	AddScoped 
< !
IRestaurantRepository 0
,0 1 
RestaurantRepository2 F
>F G
(G H
)H I
;I J
services 
. 
	AddScoped 
< 
IProductRepository -
,- .
ProductRepository/ @
>@ A
(A B
)B C
;C D
services   
.   
	AddScoped   
<   !
IIngredientRepository   0
,  0 1 
IngredientRepository  2 F
>  F G
(  G H
)  H I
;  I J
services!! 
.!! 
	AddScoped!! 
<!! 
ICategoryRepository!! .
,!!. /
CategoryRepository!!0 B
>!!B C
(!!C D
)!!D E
;!!E F
services"" 
."" 
	AddScoped"" 
<"" #
IProductComboRepository"" 2
,""2 3"
ProductComboRepository""4 J
>""J K
(""K L
)""L M
;""M N
services## 
.## 
	AddScoped## 
<## 
IComboRepository## +
,##+ ,
ComboRepository##- <
>##< =
(##= >
)##> ?
;##? @
services$$ 
.$$ 
	AddScoped$$ 
<$$ (
IProductIngredientRepository$$ 7
,$$7 8'
ProductIngredientRepository$$9 T
>$$T U
($$U V
)$$V W
;$$W X
services%% 
.%% 
	AddScoped%% 
<%% 
IOrderRepository%% +
,%%+ ,
OrderRepository%%- <
>%%< =
(%%= >
)%%> ?
;%%? @
services&& 
.&& 
	AddScoped&& 
<&& "
IOrderDetailRepository&& 1
,&&1 2!
OrderDetailRepository&&3 H
>&&H I
(&&I J
)&&J K
;&&K L
services'' 
.'' 
	AddScoped'' 
<'' 
IShiftRepository'' +
,''+ ,
ShiftRepository''- <
>''< =
(''= >
)''> ?
;''? @
services(( 
.(( 
	AddScoped(( 
<(( %
IWaiterScheduleRepository(( 4
,((4 5$
WaiterScheduleRepository((6 N
>((N O
(((O P
)((P Q
;((Q R
services)) 
.)) 
	AddScoped)) 
<)) %
IProductGeneralRepository)) 4
,))4 5$
ProductGeneralRepository))6 N
>))N O
())O P
)))P Q
;))Q R
services** 
.** 
	AddScoped** 
<** /
#IProductIngredientGeneralRepository** >
,**> ?.
"ProductIngredientGeneralRepository**@ b
>**b c
(**c d
)**d e
;**e f
services++ 
.++ 
AddSingleton++ 
<++ 
StorageHandler++ ,
>++, -
(++- .
)++. /
;++/ 0
services,, 
.,, 
AddSingleton,, 
<,, "
QRCodeGeneratorHandler,, 4
>,,4 5
(,,5 6
),,6 7
;,,7 8
services-- 
.-- 
	AddScoped-- 
<-- 
IUnitOfWorks-- '
,--' (
UnitOfWorks--) 4
>--4 5
(--5 6
)--6 7
;--7 8
services// 
.// 
	AddScoped// 
<// +
IIngrdientTransactionRepository// :
,//: ;*
IngrdientTransactionRepository//< Z
>//Z [
(//[ \
)//\ ]
;//] ^
services00 
.00 
	AddScoped00 
<00 #
IProductImageRepository00 2
,002 3"
ProductImageRepository004 J
>00J K
(00K L
)00L M
;00M N
services11 
.11 
	AddScoped11 
<11 
IRatingRepository11 ,
,11, -
RatingRepository11. >
>11> ?
(11? @
)11@ A
;11A B
services22 
.22 
	AddScoped22 
<22 
ICustomerRepository22 .
,22. /
CustomerRepository220 B
>22B C
(22C D
)22D E
;22E F
services33 
.33 
	AddScoped33 
<33 
IEmployeeRepository33 .
,33. /
EmployeeRepository330 B
>33B C
(33C D
)33D E
;33E F
services44 
.44 
	AddScoped44 
<44 
IPaymentRepository44 -
,44- .
PaymentRepository44/ @
>44@ A
(44A B
)44B C
;44C D
services55 
.55 
	AddScoped55 
<55  
IGroupUserRepository55 /
,55/ 0
GroupUserRepository551 D
>55D E
(55E F
)55F G
;55G H
services66 
.66 
	AddScoped66 
<66 #
IGroupMessageRepository66 2
,662 3"
GroupMessageRepository664 J
>66J K
(66K L
)66L M
;66M N
services77 
.77 
	AddScoped77 
<77  
IGroupChatRepository77 /
,77/ 0
GroupChatRepository771 D
>77D E
(77E F
)77F G
;77G H
services88 
.88 
	AddScoped88 
<88 !
IAttendanceRepository88 0
,880 1 
AttendanceRepository882 F
>88F G
(88G H
)88H I
;88I J
services99 
.99 
	AddScoped99 
<99 %
IIngredientUnitRepository99 4
,994 5$
IngredientUnitRepository996 N
>99N O
(99O P
)99P Q
;99Q R
services:: 
.:: 
	AddScoped:: 
<:: -
!INewProductRecommendLogRepository:: <
,::< =,
 NewProductRecommendLogRepository::> ^
>::^ _
(::_ `
)::` a
;::a b
services;; 
.;; 
	AddScoped;; 
<;; *
INewProductRecommendRepository;; 9
,;;9 :)
NewProductRecommendRepository;;; X
>;;X Y
(;;Y Z
);;Z [
;;;[ \
return<< 
services<< 
;<< 
}>> 
}?? О
{C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\WaiterScheduleConfiguration.cs
	namespace

 	
FOV


 
.

 
Infrastructure

 
.

 
Data

 !
.

! "
	FluentAPI

" +
;

+ ,
public 
class '
WaiterScheduleConfiguration (
:) *$
IEntityTypeConfiguration+ C
<C D
WaiterScheduleD R
>R S
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
WaiterSchedule, :
>: ;
builder< C
)C D
{ 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
Attendances *
)* +
.+ ,
WithOne, 3
(3 4
x4 5
=>6 8
x9 :
.: ;
WaiterSchedule; I
)I J
.J K
HasForeignKeyK X
(X Y
xY Z
=>[ ]
x^ _
._ `
WaiterScheduleId` p
)p q
;q r
} 
} ї

yC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\WaiterSalaryConfiguration.cs
	namespace

 	
FOV


 
.

 
Infrastructure

 
.

 
Data

 !
.

! "
	FluentAPI

" +
;

+ ,
public 
class %
WaiterSalaryConfiguration &
:' ($
IEntityTypeConfiguration) A
<A B
WaiterSalaryB N
>N O
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
WaiterSalary, 8
>8 9
builder: A
)A B
{ 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasOne 
( 
x 
=> 
x 
. 
User "
)" #
.# $
WithMany$ ,
(, -
x- .
=>/ 1
x2 3
.3 4
WaiterSalaries4 B
)B C
.C D
HasForeignKeyD Q
(Q R
xR S
=>T V
xW X
.X Y
UserIdY _
)_ `
;` a
} 
} │
qC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\UserConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class 
UserConfiguration 
:  $
IEntityTypeConfiguration! 9
<9 :
User: >
>> ?
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
User, 0
>0 1
builder2 9
)9 :
{		 
builder

 
.

 
HasOne

 
(

 
x

 
=>

 
x

 
.

 
Customer

 &
)

& '
.

' (
WithOne

( /
(

/ 0
x

0 1
=>

2 4
x

5 6
.

6 7
User

7 ;
)

; <
.

< =
HasForeignKey

= J
<

J K
Customer

K S
>

S T
(

T U
x

U V
=>

W Y
x

Z [
.

[ \
UserId

\ b
)

b c
;

c d
builder 
. 
HasOne 
( 
x 
=> 
x 
. 
Employee &
)& '
.' (
WithOne( /
(/ 0
x0 1
=>2 4
x5 6
.6 7
User7 ;
); <
.< =
HasForeignKey= J
<J K
EmployeeK S
>S T
(T U
xU V
=>W Y
xZ [
.[ \
UserId\ b
)b c
;c d
builder 
. 
HasMany 
( 
x 
=> 
x 
. 

GroupUsers )
)) *
.* +
WithOne+ 2
(2 3
x3 4
=>5 7
x8 9
.9 :
User: >
)> ?
.? @
HasForeignKey@ M
(M N
xN O
=>P R
xS T
.T U
UserIdU [
)[ \
;\ ]
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
GroupMessages ,
), -
.- .
WithOne. 5
(5 6
x6 7
=>8 :
x; <
.< =
User= A
)A B
.B C
HasForeignKeyC P
(P Q
xQ R
=>S U
xV W
.W X
UserIdX ^
)^ _
;_ `
}KK 
}LL ╙

rC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\TableConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class 
TableConfiguration 
:  !$
IEntityTypeConfiguration" :
<: ;
Table; @
>@ A
{		 
public

 

void

 
	Configure

 
(

 
EntityTypeBuilder

 +
<

+ ,
Table

, 1
>

1 2
builder

3 :
)

: ;
{ 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
Orders %
)% &
.& '
WithOne' .
(. /
x/ 0
=>1 3
x4 5
.5 6
Table6 ;
); <
.< =
HasForeignKey= J
(J K
xK L
=>M O
xP Q
.Q R
TableIdR Y
)Y Z
;Z [
} 
} ▄

rC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\ShiftConfiguration.cs
	namespace

 	
FOV


 
.

 
Infrastructure

 
.

 
Data

 !
.

! "
	FluentAPI

" +
;

+ ,
public 
class 
ShiftConfiguration 
:  !$
IEntityTypeConfiguration" :
<: ;
Shift; @
>@ A
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
Shift, 1
>1 2
builder3 :
): ;
{ 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
WaiterSchedules .
). /
./ 0
WithOne0 7
(7 8
x8 9
=>: <
x= >
.> ?
Shift? D
)D E
.E F
HasForeignKeyF S
(S T
xT U
=>V X
xY Z
.Z [
ShiftId[ b
)b c
;c d
} 
} П,
wC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\RestaurantConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class #
RestaurantConfiguration $
:% &$
IEntityTypeConfiguration' ?
<? @

Restaurant@ J
>J K
{		 
public

 

void

 
	Configure

 
(

 
EntityTypeBuilder

 +
<

+ ,

Restaurant

, 6
>

6 7
builder

8 ?
)

? @
{ 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
Ingredients *
)* +
.+ ,
WithOne, 3
(3 4
x4 5
=>6 8
x9 :
.: ;

Restaurant; E
)E F
.F G
HasForeignKeyG T
(T U
xU V
=>W Y
xZ [
.[ \
RestaurantId\ h
)h i
;i j
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
Products '
)' (
.( )
WithOne) 0
(0 1
x1 2
=>3 5
x6 7
.7 8

Restaurant8 B
)B C
.C D
HasForeignKeyD Q
(Q R
xR S
=>T V
xW X
.X Y
RestaurantIdY e
)e f
;f g
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
Combos %
)% &
.& '
WithOne' .
(. /
x/ 0
=>1 3
x4 5
.5 6

Restaurant6 @
)@ A
.A B
HasForeignKeyB O
(O P
xP Q
=>R T
xU V
.V W
RestaurantIdW c
)c d
;d e
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
Tables %
)% &
.& '
WithOne' .
(. /
x/ 0
=>1 3
x4 5
.5 6

Restaurant6 @
)@ A
.A B
HasForeignKeyB O
(O P
xP Q
=>R T
xU V
.V W
RestaurantIdW c
)c d
;d e
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
	Employees (
)( )
.) *
WithOne* 1
(1 2
x2 3
=>4 6
x7 8
.8 9

Restaurant9 C
)C D
.D E
HasForeignKeyE R
(R S
xS T
=>U W
xX Y
.Y Z
RestaurantIdZ f
)f g
;g h
builder 
. 
HasMany 
( 
x 
=> 
x 
. 

GroupChats )
)) *
.* +
WithOne+ 2
(2 3
x3 4
=>5 7
x8 9
.9 :

Restaurant: D
)D E
.E F
HasForeignKeyF S
(S T
xT U
=>V X
xY Z
.Z [
RestaurantId[ g
)g h
;h i
builder 
. 
HasData 
( 
new 

Restaurant &
{ 	
Id 
= 
Guid 
. 
Parse 
( 
$str B
)B C
,C D
RestaurantName 
= 
$str 1
,1 2
	IsDeleted 
= 
false 
, 
RestaurantPhone 
= 
$str *
,* +
Address 
= 
$str 
, 
RestataurantCode 
= 
$str '
,' (
Status 
= 
Domain 
. 
Entities $
.$ %
TableAggregator% 4
.4 5
Enums5 :
.: ;
Status; A
.A B
ActiveB H
} 	
,	 

new 

Restaurant 
{ 	
Id   
=   
Guid   
.   
Parse   
(   
$str   B
)  B C
,  C D
RestaurantName!! 
=!! 
$str!! +
,!!+ ,
	IsDeleted"" 
="" 
false"" 
,"" 
RestaurantPhone## 
=## 
$str## *
,##* +
Address$$ 
=$$ 
$str$$ 
,$$  
RestataurantCode%% 
=%% 
$str%% '
,%%' (
Status&& 
=&& 
Domain&& 
.&& 
Entities&& $
.&&$ %
TableAggregator&&% 4
.&&4 5
Enums&&5 :
.&&: ;
Status&&; A
.&&A B
Active&&B H
}'' 	
)(( 	
;((	 

})) 
}** Ї
sC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\RatingConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class 
RatingConfiguration  
:! "$
IEntityTypeConfiguration# ;
<; <
Rating< B
>B C
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
Rating, 2
>2 3
builder4 ;
); <
{		 
builder

 
.

 
HasKey

 
(

 
x

 
=>

 
x

 
.

 
Id

  
)

  !
;

! "
} 
} ▌
ЕC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\ProductIngredientGeneralConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
internal 
class	 1
%ProductIngredientGeneralConfiguration 4
:5 6$
IEntityTypeConfiguration7 O
<O P$
ProductIngredientGeneralP h
>h i
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,$
ProductIngredientGeneral, D
>D E
builderF M
)M N
{		 
builder

 
.

 
HasKey

 
(

 
x

 
=>

 
x

 
.

 
Id

  
)

  !
;

! "
builder 
. 
HasData 
( 
new $
ProductIngredientGeneral 4
{ 	
Id 
= 
Guid 
. 
Parse 
( 
$str B
)B C
,C D
IngredientGeneralId 
=  !
Guid" &
.& '
Parse' ,
(, -
$str- S
)S T
,T U
ProductGeneralId 
= 
Guid #
.# $
Parse$ )
() *
$str* P
)P Q
,Q R
Quantity 
= 
$num 
, 
	IsDeleted 
= 
false 
, 
} 	
)	 

;
 
} 
} М
yC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\ProductImageConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class %
ProductImageConfiguration &
:' ($
IEntityTypeConfiguration) A
<A B
ProductImageB N
>N O
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
ProductImage, 8
>8 9
builder: A
)A B
{		 
builder

 
.

 
HasKey

 
(

 
x

 
=>

 
x

 
.

 
Id

  
)

  !
;

! "
} 
} ї(
{C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\ProductGeneralConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class '
ProductGeneralConfiguration (
:) *$
IEntityTypeConfiguration+ C
<C D
ProductGeneralD R
>R S
{		 
public

 

void

 
	Configure

 
(

 
EntityTypeBuilder

 +
<

+ ,
ProductGeneral

, :
>

: ;
builder

< C
)

C D
{ 
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
Products '
)' (
.( )
WithOne) 0
(0 1
x1 2
=>3 5
x6 7
.7 8
ProductGeneral8 F
)F G
.G H
HasForeignKeyH U
(U V
xV W
=>X Z
x[ \
.\ ]
ProductGeneralId] m
)m n
;n o
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
Ingredients *
)* +
.+ ,
WithOne, 3
(3 4
x4 5
=>6 8
x9 :
.: ;
ProductGeneral; I
)I J
.J K
HasForeignKeyK X
(X Y
xY Z
=>[ ]
x^ _
._ `
ProductGeneralId` p
)p q
;q r
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasData 
( 
new 
ProductGeneral 
( 
)  
{ 
Id 
= 
Guid 
. 
Parse 
(  
$str  F
)F G
,G H

CategoryId 
= 
Guid !
.! "
Parse" '
(' (
$str( N
)N O
,O P
ProductName 
= 
$str )
,) *
ProductDescription "
=# $
$str% 6
,6 7
	IsDeleted 
= 
false !
,! "
} 
, 
new 
ProductGeneral 
(  
)  !
{ 
Id 
= 
Guid 
. 
Parse  
(  !
$str! G
)G H
,H I

CategoryId 
= 
Guid "
." #
Parse# (
(( )
$str) O
)O P
,P Q
ProductName 
= 
$str $
,$ %
ProductDescription #
=$ %
$str& 1
,1 2
	IsDeleted 
= 
false "
," #
} 
, 
new   
ProductGeneral   
(    
)    !
{!! 
Id"" 
="" 
Guid"" 
."" 
Parse""  
(""  !
$str""! G
)""G H
,""H I

CategoryId## 
=## 
Guid## "
.##" #
Parse### (
(##( )
$str##) O
)##O P
,##P Q
ProductName$$ 
=$$ 
$str$$ /
,$$/ 0
ProductDescription%% #
=%%$ %
$str%%& <
,%%< =
	IsDeleted&& 
=&& 
false&& "
,&&" #
}'' 
,'' 
new(( 
ProductGeneral(( 
(((  
)((  !
{)) 
Id** 
=** 
Guid** 
.** 
Parse**  
(**  !
$str**! G
)**G H
,**H I

CategoryId++ 
=++ 
Guid++ "
.++" #
Parse++# (
(++( )
$str++) O
)++O P
,++P Q
ProductName,, 
=,, 
$str,, -
,,,- .
ProductDescription-- #
=--$ %
$str--& 5
,--5 6
	IsDeleted.. 
=.. 
false.. "
,.." #
}// 
,// 
new00 
ProductGeneral00 
(00  
)00  !
{11 
Id22 
=22 
Guid22 
.22 
Parse22  
(22  !
$str22! G
)22G H
,22H I

CategoryId33 
=33 
Guid33 "
.33" #
Parse33# (
(33( )
$str33) O
)33O P
,33P Q
ProductName44 
=44 
$str44 *
,44* +
ProductDescription55 #
=55$ %
$str55& 0
,550 1
	IsDeleted66 
=66 
false66 "
,66" #
}77 
)88 
;88 
}99 
}:: ч&
tC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\ProductConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class  
ProductConfiguration !
:" #$
IEntityTypeConfiguration$ <
<< =
Product= D
>D E
{		 
public

 

void

 
	Configure

 
(

 
EntityTypeBuilder

 +
<

+ ,
Product

, 3
>

3 4
builder

5 <
)

< =
{ 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
ProductCombos ,
), -
.- .
WithOne. 5
(5 6
x6 7
=>8 :
x; <
.< =
Product= D
)D E
.E F
HasForeignKeyF S
(S T
xT U
=>V X
xY Z
.Z [
	ProductId[ d
)d e
;e f
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
OrderDetails +
)+ ,
., -
WithOne- 4
(4 5
x5 6
=>7 9
x: ;
.; <
Product< C
)C D
.D E
HasForeignKeyE R
(R S
xS T
=>U W
xX Y
.Y Z
	ProductIdZ c
)c d
;d e
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
ProductImages ,
), -
.- .
WithOne. 5
(5 6
x6 7
=>8 :
x; <
.< =
Product= D
)D E
.E F
HasForeignKeyF S
(S T
xT U
=>V X
xY Z
.Z [
	ProductId[ d
)d e
;e f
builder 
. 
HasData 
( 
new 
Product #
{ 	
Id 
= 
Guid 
. 
Parse 
( 
$str B
)B C
,C D

CategoryId 
= 
Guid 
. 
Parse #
(# $
$str$ J
)J K
,K L
ProductName 
= 
$str 
,  
ProductDescription 
=  
$str! .
,. /
ProductGeneralId 
= 
Guid #
.# $
Parse$ )
() *
$str* P
)P Q
,Q R
RestaurantId 
= 
Guid 
.  
Parse  %
(% &
$str& L
)L M
} 	
,	 

new 
Product 
{ 	
Id 
= 
Guid 
. 
Parse 
( 
$str B
)B C
,C D

CategoryId 
= 
Guid 
. 
Parse #
(# $
$str$ J
)J K
,K L
ProductName 
= 
$str ,
,, -
ProductDescription 
=  
$str! *
,* +
ProductGeneralId 
= 
Guid #
.# $
Parse$ )
() *
$str* P
)P Q
,Q R
RestaurantId   
=   
Guid   
.    
Parse    %
(  % &
$str  & L
)  L M
}!! 	
,!!	 

new"" 
Product"" 
{## 	
Id$$ 
=$$ 
Guid$$ 
.$$ 
Parse$$ 
($$ 
$str$$ B
)$$B C
,$$C D

CategoryId%% 
=%% 
Guid%% 
.%% 
Parse%% #
(%%# $
$str%%$ J
)%%J K
,%%K L
ProductName&& 
=&& 
$str&& %
,&&% &
ProductDescription'' 
=''  
$str''! .
,''. /
ProductGeneralId(( 
=(( 
Guid(( #
.((# $
Parse(($ )
((() *
$str((* P
)((P Q
,((Q R
RestaurantId)) 
=)) 
Guid)) 
.))  
Parse))  %
())% &
$str))& L
)))L M
}** 	
)++ 	
;++	 

},, 
}-- М
yC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\ProductComboConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class %
ProductComboConfiguration &
:' ($
IEntityTypeConfiguration) A
<A B
ProductComboB N
>N O
{ 
public		 

void		 
	Configure		 
(		 
EntityTypeBuilder		 +
<		+ ,
ProductCombo		, 8
>		8 9
builder		: A
)		A B
{

 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
} 
} И
xC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\OrderDetailConfiguration.cs
	namespace

 	
FOV


 
.

 
Infrastructure

 
.

 
Data

 !
.

! "
	FluentAPI

" +
;

+ ,
public 
class $
OrderDetailConfiguration %
:& '$
IEntityTypeConfiguration( @
<@ A
OrderDetailA L
>L M
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
OrderDetail, 7
>7 8
builder9 @
)@ A
{ 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
} 
} ё
rC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\OrderConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
{ 
public 

class 
OrderConfiguration #
:$ %$
IEntityTypeConfiguration& >
<> ?
Order? D
>D E
{ 
public		 
void		 
	Configure		 
(		 
EntityTypeBuilder		 /
<		/ 0
Order		0 5
>		5 6
builder		7 >
)		> ?
{

 	
builder 
. 
HasKey 
( 
x 
=> 
x  !
.! "
Id" $
)$ %
;% &
builder 
. 
HasMany 
( 
x 
=>  
x! "
." #
OrderDetails# /
)/ 0
.0 1
WithOne1 8
(8 9
x9 :
=>; =
x> ?
.? @
Order@ E
)E F
.F G
HasForeignKeyG T
(T U
xU V
=>W Y
xZ [
.[ \
OrderId\ c
)c d
;d e
builder 
. 
HasMany 
( 
x 
=>  
x! "
." #"
IngredientTransactions# 9
)9 :
.: ;
WithOne; B
(B C
xC D
=>E G
xH I
.I J
OrderJ O
)O P
.P Q
HasForeignKeyQ ^
(^ _
x_ `
=>a c
xd e
.e f
OrderIdf m
)m n
;n o
builder 
. 
HasOne 
( 
x 
=> 
x  !
.! "
Rating" (
)( )
.) *
WithOne* 1
(1 2
x2 3
=>4 6
x7 8
.8 9
Order9 >
)> ?
.? @
HasForeignKey@ M
<M N
RatingN T
>T U
(U V
xV W
=>X Z
x[ \
.\ ]
OrderId] d
)d e
;e f
} 	
} 
} П
{C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\IngredientUnitConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class '
IngredientUnitConfiguration (
:) *$
IEntityTypeConfiguration+ C
<C D
IngredientUnitD R
>R S
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
IngredientUnit, :
>: ;
builder< C
)C D
{		 
builder

 
.

 
HasKey

 
(

 
x

 
=>

 
x

 
.

 
Id

  
)

  !
;

! "
builder 
. 
HasOne 
( 
x 
=> 
x 
. 

Ingredient (
)( )
.) *
WithMany* 2
(2 3
x3 4
=>5 7
x8 9
.9 :
IngredientUnits: I
)I J
.J K
HasForeignKeyK X
(X Y
xY Z
=>[ ]
x^ _
._ `
IngredientId` l
)l m
;m n
builder 
. 
HasOne 
( 
x 
=> 
x 
.  
IngredientUnitParent 2
)2 3
.3 4
WithMany4 <
(< =
x= >
=>? A
xB C
.C D

ChildUnitsD N
)N O
.O P
HasForeignKeyP ]
(] ^
x^ _
=>` b
xc d
.d e"
IngredientUnitParentIde {
){ |
;| }
} 
} Л
{C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\IngredientTypeConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class '
IngredientTypeConfiguration (
:) *$
IEntityTypeConfiguration+ C
<C D
IngredientTypeD R
>R S
{ 
public		 

void		 
	Configure		 
(		 
EntityTypeBuilder		 +
<		+ ,
IngredientType		, :
>		: ;
builder		< C
)		C D
{

 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
Ingredients *
)* +
.+ ,
WithOne, 3
(3 4
x4 5
=>6 8
x9 :
.: ;
IngredientType; I
)I J
.J K
HasForeignKeyK X
(X Y
xY Z
=>[ ]
x^ _
._ `
IngredientTypeId` p
)p q
;q r
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
IngredientGenerals 1
)1 2
.2 3
WithOne3 :
(: ;
x; <
=>= ?
x@ A
.A B
IngredientTypeB P
)P Q
.Q R
HasForeignKeyR _
(_ `
x` a
=>b d
xe f
.f g
IngredientTypeIdg w
)w x
;x y
builder 
. 
HasData 
( 
new 
IngredientType	 
{ 
Id	 
= 
Guid 
. 
Parse 
( 
$str ?
)? @
,@ A
IngredientName	 
= 
$str 4
,4 5
IngredientMain	 
= 
$str (
,( )
Left	 
= 
$num 
, 
Right	 
= 
$num 
, 
ExpiredTime	 
= 
$num 
, 
	IsDeleted	 
= 
false 
} 
, 
new 
IngredientType	 
{ 
Id	 
= 
Guid 
. 
Parse 
( 
$str ?
)? @
,@ A
IngredientName	 
= 
$str 5
,5 6
IngredientMain	 
= 
$str )
,) *
Left	 
= 
$num 
, 
Right	 
= 
$num 
, 
ExpiredTime  	 
=   
$num   
,   
	IsDeleted!!	 
=!! 
false!! 
}"" 
)## 
;## 
;## 
}%% 
}&& ▒
ВC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\IngredientTransactionConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class .
"IngredientTransactionConfiguration /
:0 1$
IEntityTypeConfiguration2 J
<J K!
IngredientTransactionK `
>` a
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,!
IngredientTransaction, A
>A B
builderC J
)J K
{		 
builder

 
.

 
HasKey

 
(

 
x

 
=>

 
x

 
.

 
Id

  
)

  !
;

! "
} 
} ч
~C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\IngredientGeneralConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class *
IngredientGeneralConfiguration +
:, -$
IEntityTypeConfiguration. F
<F G
IngredientGeneralG X
>X Y
{ 
public		 

void		 
	Configure		 
(		 
EntityTypeBuilder		 +
<		+ ,
IngredientGeneral		, =
>		= >
builder		? F
)		F G
{

 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasMany 
( 
x 
=> 
x 
. %
ProductIngredientGenerals 8
)8 9
.9 :
WithOne: A
(A B
xB C
=>D F
xG H
.H I
IngredientGeneralI Z
)Z [
.[ \
HasForeignKey\ i
(i j
xj k
=>l n
xo p
.p q 
IngredientGeneralId	q Д
)
Д Е
;
Е Ж
builder 
. 
HasData 
( 
new 
IngredientGeneral -
{ 	
Id 
= 
Guid 
. 
Parse 
( 
$str B
)B C
,C D
IngredientName 
= 
$str #
,# $!
IngredientDescription !
=" #
$str$ g
,g h
IngredientTypeId 
= 
Guid #
.# $
Parse$ )
() *
$str* P
)P Q
} 	
,	 

new 
IngredientGeneral  
{ 	
Id 
= 
Guid 
. 
Parse 
( 
$str B
)B C
,C D
IngredientName 
= 
$str $
,$ %!
IngredientDescription !
=" #
$str$ f
,f g
IngredientTypeId 
= 
Guid #
.# $
Parse$ )
() *
$str* P
)P Q
} 	
,	 

new	 
IngredientGeneral 
{	 

Id 
= 
Guid 
. 
Parse 
( 
$str C
)C D
,D E
IngredientName 
= 
$str '
,' (!
IngredientDescription "
=# $
$str% g
,g h
IngredientTypeId   
=   
Guid    $
.  $ %
Parse  % *
(  * +
$str  + Q
)  Q R
}!!	 

)## 	
;##	 

}$$ 
}%% Б
wC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\IngredientConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class #
IngredientConfiguration $
:% &$
IEntityTypeConfiguration' ?
<? @

Ingredient@ J
>J K
{		 
public

 

void

 
	Configure

 
(

 
EntityTypeBuilder

 +
<

+ ,

Ingredient

, 6
>

6 7
builder

8 ?
)

? @
{ 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasMany 
( 
x 
=> 
x 
. "
IngredientTransactions 5
)5 6
.6 7
WithOne7 >
(> ?
x? @
=>A C
xD E
.E F

IngredientF P
)P Q
.Q R
HasForeignKeyR _
(_ `
x` a
=>b d
xe f
.f g
IngredientIdg s
)s t
;t u
} 
} А
vC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\GroupUserConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class "
GroupUserConfiguration #
:$ %$
IEntityTypeConfiguration& >
<> ?
	GroupUser? H
>H I
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
	GroupUser, 5
>5 6
builder7 >
)> ?
{		 
builder

 
.

 
HasKey

 
(

 
x

 
=>

 
x

 
.

 
Id

  
)

  !
;

! "
} 
} М
yC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\GroupMessageConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class %
GroupMessageConfiguration &
:' ($
IEntityTypeConfiguration) A
<A B
GroupMessageB N
>N O
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
GroupMessage, 8
>8 9
builder: A
)A B
{		 
builder

 
.

 
HasKey

 
(

 
x

 
=>

 
x

 
.

 
Id

  
)

  !
;

! "
} 
} Д
vC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\GroupChatConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
internal 
class	 "
GroupChatConfiguration %
:& '$
IEntityTypeConfiguration( @
<@ A
	GroupChatA J
>J K
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
	GroupChat, 5
>5 6
builder7 >
)> ?
{		 
builder

 
.

 
HasKey

 
(

 
x

 
=>

 
x

 
.

 
Id

  
)

  !
;

! "
builder 
. 
HasMany 
( 
x 
=> 
x 
. 

GroupUsers )
)) *
.* +
WithOne+ 2
(2 3
x3 4
=>5 7
x8 9
.9 :
	GroupChat: C
)C D
.D E
HasForeignKeyE R
(R S
xS T
=>U W
xX Y
.Y Z
GroupChatIdZ e
)e f
;f g
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
GroupMessages ,
), -
.- .
WithOne. 5
(5 6
x6 7
=>8 :
x; <
.< =
	GroupChat= F
)F G
.G H
HasForeignKeyH U
(U V
xV W
=>X Z
x[ \
.\ ]
GroupChatId] h
)h i
;i j
builder 
. 
HasData 
( 
new 
	GroupChat %
{ 	
Id 
= 
Guid 
. 
Parse 
( 
$str B
)B C
,C D
	GroupName 
= 
$str *
,* +
RestaurantId 
= 
Guid 
.  
Parse  %
(% &
$str& L
)L M
,M N
} 	
)	 

;
 
} 
} Г#
uC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\EmployeeConfiguration.cs
	namespace

 	
FOV


 
.

 
Infrastructure

 
.

 
Data

 !
.

! "
	FluentAPI

" +
;

+ ,
public 
class !
EmployeeConfiguration "
:# $$
IEntityTypeConfiguration% =
<= >
Employee> F
>F G
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
Employee, 4
>4 5
builder6 =
)= >
{ 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasData 
( 
new 
Employee 
{ 
Id 
= 
Guid 
. 
Parse 
(  
$str  F
)F G
,G H
HireDate 
= 
DateTime #
.# $
UtcNow$ *
,* +
EmployeeCode 
= 
$str '
,' (
UserId 
= 
$str ?
,? @
	IsDeleted 
= 
false !
,! "
RestaurantId 
= 
Guid #
.# $
Parse$ )
() *
$str* P
)P Q
,Q R
Created 
= 
DateTimeOffset (
.( )
Parse) .
(. /
$str/ G
)G H
,H I
	CreatedBy 
= 
$str #
,# $
LastModified 
= 
DateTimeOffset -
.- .
Parse. 3
(3 4
$str4 L
)L M
,M N
LastModifiedBy 
=  
$str! (
} 
, 
new 
Employee 
{   
Id!! 
=!! 
Guid!! 
.!! 
Parse!! 
(!!  
$str!!  F
)!!F G
,!!G H
HireDate"" 
="" 
DateTime"" #
.""# $
UtcNow""$ *
,""* +
EmployeeCode## 
=## 
$str## '
,##' (
UserId$$ 
=$$ 
$str$$ ?
,$$? @
	IsDeleted%% 
=%% 
false%% !
,%%! "
RestaurantId&& 
=&& 
Guid&& #
.&&# $
Parse&&$ )
(&&) *
$str&&* P
)&&P Q
,&&Q R
Created'' 
='' 
DateTimeOffset'' (
.''( )
Parse'') .
(''. /
$str''/ G
)''G H
,''H I
	CreatedBy(( 
=(( 
$str(( %
,((% &
LastModified)) 
=)) 
DateTimeOffset)) -
.))- .
Parse)). 3
())3 4
$str))4 L
)))L M
,))M N
LastModifiedBy** 
=**  
$str**! *
}++ 
,++ 
new,, 
Employee,, 
{-- 
Id.. 
=.. 
Guid.. 
... 
Parse.. 
(..  
$str..  F
)..F G
,..G H
HireDate// 
=// 
DateTime// #
.//# $
UtcNow//$ *
,//* +
EmployeeCode00 
=00 
$str00 '
,00' (
UserId11 
=11 
$str11 ?
,11? @
	IsDeleted22 
=22 
false22 !
,22! "
RestaurantId33 
=33 
Guid33 #
.33# $
Parse33$ )
(33) *
$str33* P
)33P Q
,33Q R
Created44 
=44 
DateTimeOffset44 (
.44( )
Parse44) .
(44. /
$str44/ G
)44G H
,44H I
	CreatedBy55 
=55 
$str55 #
,55# $
LastModified66 
=66 
DateTimeOffset66 -
.66- .
Parse66. 3
(663 4
$str664 L
)66L M
,66M N
LastModifiedBy77 
=77  
$str77! (
}88 
)99 	
;99	 

}:: 
};; №
uC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\CustomerConfiguration.cs
	namespace

 	
FOV


 
.

 
Infrastructure

 
.

 
Data

 !
.

! "
	FluentAPI

" +
;

+ ,
public 
class !
CustomerConfiguration "
:# $$
IEntityTypeConfiguration% =
<= >
Customer> F
>F G
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,
Customer, 4
>4 5
builder6 =
)= >
{ 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
} 
} х*
rC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\ComboConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class 
ComboConfiguration 
:  !$
IEntityTypeConfiguration" :
<: ;
Combo; @
>@ A
{		 
public

 

void

 
	Configure

 
(

 
EntityTypeBuilder

 +
<

+ ,
Combo

, 1
>

1 2
builder

3 :
)

: ;
{ 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
ProductCombos ,
), -
.- .
WithOne. 5
(5 6
x6 7
=>8 :
x; <
.< =
Combo= B
)B C
.C D
HasForeignKeyD Q
(Q R
xR S
=>T V
xW X
.X Y
ComboIdY `
)` a
;a b
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
OrderDetails +
)+ ,
., -
WithOne- 4
(4 5
x5 6
=>7 9
x: ;
.; <
Combo< A
)A B
.B C
HasForeignKeyC P
(P Q
xQ R
=>S U
xV W
.W X
ComboIdX _
)_ `
;` a
builder 
. 
HasData 
( 
new 
Combo 
{ 
Id 
= 
Guid 
. 
Parse 
(  
$str  F
)F G
,G H
	ComboName 
= 
$str %
,% &
Status 
= 
Domain 
.  
Entities  (
.( )
ComboAggregator) 8
.8 9
Enums9 >
.> ?
Status? E
.E F
InStockF M
,M N
Quantity 
= 
$num 
, 
Price 
= 
$num 
, 
PercentReduce 
= 
$num  %
,% &
ExpiredDate 
= 
DateTime &
.& '
UtcNow' -
.- .
	AddMonths. 7
(7 8
$num8 9
)9 :
,: ;
RestaurantId 
= 
Guid #
.# $
Parse$ )
() *
$str* P
)P Q
,Q R
	IsDeleted 
= 
false !
} 
, 
new 
Combo 
{ 
Id 
= 
Guid 
. 
Parse 
(  
$str  F
)F G
,G H
	ComboName 
= 
$str %
,% &
Status   
=   
Domain   
.    
Entities    (
.  ( )
ComboAggregator  ) 8
.  8 9
Enums  9 >
.  > ?
Status  ? E
.  E F
InStock  F M
,  M N
Quantity!! 
=!! 
$num!! 
,!! 
Price"" 
="" 
$num"" 
,"" 
PercentReduce## 
=## 
$num##  $
,##$ %
ExpiredDate$$ 
=$$ 
DateTime$$ &
.$$& '
UtcNow$$' -
.$$- .
	AddMonths$$. 7
($$7 8
$num$$8 9
)$$9 :
,$$: ;
RestaurantId%% 
=%% 
Guid%% #
.%%# $
Parse%%$ )
(%%) *
$str%%* P
)%%P Q
,%%Q R
	IsDeleted&& 
=&& 
false&& !
}'' 
,'' 
new(( 
Combo(( 
{)) 
Id** 
=** 
Guid** 
.** 
Parse** 
(**  
$str**  F
)**F G
,**G H
	ComboName++ 
=++ 
$str++ %
,++% &
Status,, 
=,, 
Domain,, 
.,,  
Entities,,  (
.,,( )
ComboAggregator,,) 8
.,,8 9
Enums,,9 >
.,,> ?
Status,,? E
.,,E F
InStock,,F M
,,,M N
Quantity-- 
=-- 
$num-- 
,-- 
Price.. 
=.. 
$num.. 
,.. 
PercentReduce// 
=// 
$num//  $
,//$ %
ExpiredDate00 
=00 
DateTime00 &
.00& '
UtcNow00' -
.00- .
	AddMonths00. 7
(007 8
$num008 9
)009 :
,00: ;
RestaurantId11 
=11 
Guid11 #
.11# $
Parse11$ )
(11) *
$str11* P
)11P Q
,11Q R
	IsDeleted22 
=22 
false22 !
}33 
)44 	
;44	 

}55 
}66 ╬
uC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\CategoryConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class !
CategoryConfiguration "
:# $$
IEntityTypeConfiguration% =
<= >
Category> F
>F G
{ 
public		 

void		 
	Configure		 
(		 
EntityTypeBuilder		 +
<		+ ,
Category		, 4
>		4 5
builder		6 =
)		= >
{

 
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
ProductGenerals .
). /
./ 0
WithOne0 7
(7 8
x8 9
=>: <
x= >
.> ?
Category? G
)G H
.H I
HasForeignKeyI V
(V W
xW X
=>Y [
x\ ]
.] ^

CategoryId^ h
)h i
;i j
builder 
. 
HasMany 
( 
x 
=> 
x 
. 
Products '
)' (
.( )
WithOne) 0
(0 1
x1 2
=>3 5
x6 7
.7 8
Category8 @
)@ A
.A B
HasForeignKeyB O
(O P
xP Q
=>R T
xU V
.V W

CategoryIdW a
)a b
;b c
builder 
. 
HasData 
( 
new 
Category 
( 
$str 
) 
{ 	
Id 
= 
Guid 
. 
Parse 
( 
$str B
)B C
,C D
	IsDeleted 
= 
false 
} 	
,	 

new 
Category 
( 
$str  
)  !
{ 	
Id 
= 
Guid 
. 
Parse 
( 
$str B
)B C
,C D
	IsDeleted 
= 
false 
} 	
) 
; 
} 
} ю
wC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\AttendanceConfiguration.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
	FluentAPI" +
;+ ,
public 
class #
AttendanceConfiguration $
:% &$
IEntityTypeConfiguration' ?
<? @

Attendance@ J
>J K
{ 
public 

void 
	Configure 
( 
EntityTypeBuilder +
<+ ,

Attendance, 6
>6 7
builder8 ?
)? @
{		 
builder

 
.

 
HasKey

 
(

 
x

 
=>

 
x

 
.

 
Id

  
)

  !
;

! "
builder 
. 
HasOne 
( 
a 
=> 
a 
. 
Employee &
)& '
. 
WithMany 
( 
e 
=> 
e 
.  
Attendances  +
)+ ,
. 
HasForeignKey 
( 
a 
=>  "
a# $
.$ %

EmployeeId% /
)/ 0
;0 1
builder 
. 
HasOne 
( 
a 
=> 
a 
. 
WaiterSchedule ,
), -
. 
WithMany 
( 
ws 
=> 
ws !
.! "
Attendances" -
)- .
. 
HasForeignKey 
( 
a 
=>  "
a# $
.$ %
WaiterScheduleId% 5
)5 6
;6 7
} 
} х
zC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\Configurations\IApplicationDbContext.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Data !
.! "
Configurations" 0
;0 1
public 
	interface !
IApplicationDbContext &
{ 
Task 
< 	
int	 
> 
SaveChangesAsync 
( 
CancellationToken 0
cancellationToken1 B
)B C
;C D
DbSet 	
<	 

ProductImage
 
> 
ProductImages %
{& '
get( +
;+ ,
}- .
DbSet 	
<	 

Rating
 
> 
Ratings 
{ 
get 
;  
}! "
DbSet 	
<	 


Restaurant
 
> 
Restaurants !
{" #
get$ '
;' (
}) *
DbSet 	
<	 


Ingredient
 
> 
Ingredients !
{" #
get$ '
;' (
}) *
DbSet 	
<	 

Category
 
> 

Categories 
{  
get! $
;$ %
}& '
DbSet 	
<	 

IngredientType
 
> 
IngredientTypes )
{* +
get, /
;/ 0
}1 2
DbSet 	
<	 

IngredientGeneral
 
> 
IngredientGenerals /
{0 1
get2 5
;5 6
}7 8
DbSet 	
<	 
$
ProductIngredientGeneral
 "
>" #%
ProductIngredientGenerals$ =
{> ?
get@ C
;C D
}E F
DbSet   	
<  	 

ProductGeneral  
 
>   
ProductGenerals   )
{  * +
get  , /
;  / 0
}  1 2
DbSet"" 	
<""	 

ProductIngredient""
 
>"" 
ProductIngredients"" /
{""0 1
get""2 5
;""5 6
}""7 8
DbSet$$ 	
<$$	 

Product$$
 
>$$ 
Products$$ 
{$$ 
get$$ !
;$$! "
}$$# $
DbSet&& 	
<&&	 

Customer&&
 
>&& 
	Customers&& 
{&& 
get&&  #
;&&# $
}&&% &
DbSet(( 	
<((	 

Employee((
 
>(( 
	Employees(( 
{(( 
get((  #
;((# $
}((% &
DbSet** 	
<**	 
!
IngredientTransaction**
 
>**  "
IngredientTransactions**! 7
{**8 9
get**: =
;**= >
}**? @
DbSet,, 	
<,,	 

Combo,,
 
>,, 
Combos,, 
{,, 
get,, 
;,, 
},,  
DbSet.. 	
<..	 

ProductCombo..
 
>.. 
ProductCombos.. %
{..& '
get..( +
;..+ ,
}..- .
DbSet00 	
<00	 

	GroupChat00
 
>00 

GroupChats00 
{00  !
get00" %
;00% &
}00' (
DbSet22 	
<22	 

	GroupUser22
 
>22 

GroupUsers22 
{22  !
get22" %
;22% &
}22' (
DbSet44 	
<44	 

GroupMessage44
 
>44 
GroupMessages44 %
{44& '
get44( +
;44+ ,
}44- .
DbSet77 	
<77	 

NewProductRecommend77
 
>77  
NewProductRecommends77 3
{774 5
get776 9
;779 :
}77; <
DbSet99 	
<99	 
"
NewProductRecommendLog99
  
>99  !#
NewProductRecommendLogs99" 9
{99: ;
get99< ?
;99? @
}99A B
};; ╓F
ДC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\Configurations\ApplicationDbContextInitializer.cs
	namespace		 	
FOV		
 
.		 
Infrastructure		 
.		 
Data		 !
.		! "
Configurations		" 0
;		0 1
public 
class +
ApplicationDbContextInitializer ,
{ 
private 
readonly 
ILogger 
< +
ApplicationDbContextInitializer <
>< =
_logger> E
;E F
private 
readonly 

FOVContext 
_context  (
;( )
private 
readonly 
UserManager  
<  !
User! %
>% &
_userManager' 3
;3 4
private 
readonly 
RoleManager  
<  !
IdentityRole! -
>- .
_roleManager/ ;
;; <
public 
+
ApplicationDbContextInitializer *
(* +
ILogger+ 2
<2 3+
ApplicationDbContextInitializer3 R
>R S
loggerT Z
,Z [

FOVContext\ f
contextg n
,n o
UserManagerp {
<{ |
User	| А
>
А Б
userManager
В Н
,
Н О
RoleManager
П Ъ
<
Ъ Ы
IdentityRole
Ы з
>
з и
roleManager
й ┤
)
┤ ╡
{ 
_logger 
= 
logger 
; 
_context 
= 
context 
; 
_userManager 
= 
userManager "
;" #
_roleManager 
= 
roleManager "
;" #
} 
public 

async 
Task 
InitialiseAsync %
(% &
)& '
{ 
try 
{   	
await!! 
_context!! 
.!! 
Database!! #
.!!# $
MigrateAsync!!$ 0
(!!0 1
)!!1 2
;!!2 3
}"" 	
catch## 
(## 
Npgsql## 
.## 
PostgresException## '
ex##( *
)##* +
when##, 0
(##1 2
ex##2 4
.##4 5
SqlState##5 =
==##> @
$str##A H
)##H I
{$$ 	
_logger&& 
.&& 

LogWarning&& 
(&& 
ex&& !
,&&! "
$str&&# R
)&&R S
;&&S T
}'' 	
catch(( 
((( 
System(( 
.(( 
	Exception(( 
ex((  "
)((" #
{)) 	
_logger** 
.** 
LogError** 
(** 
ex** 
,**  
$str**! U
)**U V
;**V W
throw++ 
;++ 
},, 	
}-- 
public00 

async00 
Task00 
	SeedAsync00 
(00  
)00  !
{11 
try22 
{33 	
await44 
TrySeedAsync44 
(44 
)44  
;44  !
}55 	
catch66 
(66 
	Exception66 
ex66 
)66 
{77 	
_logger88 
.88 
LogError88 
(88 
ex88 
,88  
$str88! P
)88P Q
;88Q R
throw99 
;99 
}:: 	
};; 
public== 

async== 
Task== 
TrySeedAsync== "
(==" #
)==# $
{>> 
var?? 
administratorsRole?? 
=??  
new??! $
IdentityRole??% 1
(??1 2
Role??2 6
.??6 7
Administrator??7 D
)??D E
;??E F
var@@ 
userRole@@ 
=@@ 
new@@ 
IdentityRole@@ '
(@@' (
Role@@( ,
.@@, -
User@@- 1
)@@1 2
;@@2 3
ifBB 

(BB 
!BB 
awaitBB 
_roleManagerBB 
.BB  
RoleExistsAsyncBB  /
(BB/ 0
RoleBB0 4
.BB4 5
WaiterBB5 ;
)BB; <
)BB< =
{CC 	
awaitDD 
_roleManagerDD 
.DD 
CreateAsyncDD *
(DD* +
newDD+ .
IdentityRoleDD/ ;
(DD; <
RoleDD< @
.DD@ A
WaiterDDA G
)DDG H
)DDH I
;DDI J
}EE 	
ifFF 

(FF 
!FF 
awaitFF 
_roleManagerFF 
.FF  
RoleExistsAsyncFF  /
(FF/ 0
RoleFF0 4
.FF4 5
ManagerFF5 <
)FF< =
)FF= >
{GG 	
awaitHH 
_roleManagerHH 
.HH 
CreateAsyncHH *
(HH* +
newHH+ .
IdentityRoleHH/ ;
(HH; <
RoleHH< @
.HH@ A
ManagerHHA H
)HHH I
)HHI J
;HHJ K
}II 	
ifJJ 

(JJ 
!JJ 
awaitJJ 
_roleManagerJJ 
.JJ  
RoleExistsAsyncJJ  /
(JJ/ 0
RoleJJ0 4
.JJ4 5
CookJJ5 9
)JJ9 :
)JJ: ;
{KK 	
awaitLL 
_roleManagerLL 
.LL 
CreateAsyncLL *
(LL* +
newLL+ .
IdentityRoleLL/ ;
(LL; <
RoleLL< @
.LL@ A
CookLLA E
)LLE F
)LLF G
;LLG H
}MM 	
ifNN 

(NN 
!NN 
awaitNN 
_roleManagerNN 
.NN  
RoleExistsAsyncNN  /
(NN/ 0
administratorsRoleNN0 B
.NNB C
NameNNC G
)NNG H
)NNH I
{OO 	
awaitPP 
_roleManagerPP 
.PP 
CreateAsyncPP *
(PP* +
administratorsRolePP+ =
)PP= >
;PP> ?
}QQ 	
ifRR 

(RR 
!RR 
awaitRR 
_roleManagerRR 
.RR  
RoleExistsAsyncRR  /
(RR/ 0
userRoleRR0 8
.RR8 9
NameRR9 =
)RR= >
)RR> ?
{SS 	
awaitTT 
_roleManagerTT 
.TT 
CreateAsyncTT *
(TT* +
userRoleTT+ 3
)TT3 4
;TT4 5
}UU 	
varWW 
administratorWW 
=WW 
awaitWW !
_userManagerWW" .
.WW. /
FindByEmailAsyncWW/ ?
(WW? @
$strWW@ Y
)WWY Z
;WWZ [
ifXX 

(XX 
administratorXX 
==XX 
nullXX !
)XX! "
{YY 	
administratorZZ 
=ZZ 
newZZ 
UserZZ  $
{ZZ% &
UserNameZZ' /
=ZZ0 1
$strZZ2 K
,ZZK L
EmailZZM R
=ZZS T
$strZZU n
}ZZo p
;ZZp q
await[[ 
_userManager[[ 
.[[ 
CreateAsync[[ *
([[* +
administrator[[+ 8
,[[8 9
$str[[: K
)[[K L
;[[L M
if]] 
(]] 
!]] 
string]] 
.]] 
IsNullOrWhiteSpace]] *
(]]* +
administratorsRole]]+ =
.]]= >
Name]]> B
)]]B C
)]]C D
{^^ 
await__ 
_userManager__ "
.__" #
AddToRolesAsync__# 2
(__2 3
administrator__3 @
,__@ A
new__B E
[__E F
]__F G
{__H I
administratorsRole__J \
.__\ ]
Name__] a
}__b c
)__c d
;__d e
}`` 
awaitbb 
_userManagerbb 
.bb 
AddClaimsAsyncbb -
(bb- .
administratorbb. ;
,bb; <
newbb= @
[bb@ A
]bbA B
{cc 
newdd 
Claimdd 
(dd 
nameofdd 
(dd 
Roledd 
)dd 
,dd 
Roledd  
.dd  !
Administratordd! .
)dd. /
,dd/ 0
newee 
Claimee 
(ee 
nameofee 
(ee 
administratoree "
.ee" #
UserNameee# +
)ee+ ,
,ee, -
administratoree. ;
.ee; <
UserNameee< D
)eeD E
,eeE F
newff 
Claimff 
(ff 
nameofff 
(ff 
administratorff "
.ff" #
Emailff# (
)ff( )
,ff) *
administratorff+ 8
.ff8 9
Emailff9 >
)ff> ?
}gg 
)gg 
;gg 
}hh 	
awaitjj 
_contextjj 
.jj 
SaveChangesAsyncjj '
(jj' (
)jj( )
;jj) *
}kk 
}ll Ў
eC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Constant\CurrentTime.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Constant %
;% &
public		 
static		 
class		 
CurrentTime		 
{

 
public 

static 
readonly 
DateTimeOffset )

RecentTime* 4
=5 6
DateTime7 ?
.? @
UtcNow@ F
.F G
AddHoursG O
(O P
$numP Q
)Q R
;R S
} ┼
nC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Configuration\ElasticSettings.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Configuration *
;* +
public 
class 
ElasticSettings 
{		 
public

 

string

 
Url

 
{

 
get

 
;

 
set

  
;

  !
}

" #
public 

string 
DefaultIndex 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 

string 
UserName 
{ 
get  
;  !
set" %
;% &
}' (
public 

string 
Password 
{ 
get  
;  !
set" %
;% &
}' (
} ─
bC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Common\Pagination.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Common #
{ 
public		 

class		 

Pagination		 
<		 
T		 
>		 
{

 
public 
int 
TotalItemsCount "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
int 
PageSize 
{ 
get !
;! "
set# &
;& '
}( )
public 
int 
TotalPagesCount "
{ 	
get 
{ 
var 
temp 
= 
TotalItemsCount *
/+ ,
PageSize- 5
;5 6
if 
( 
TotalItemsCount #
%$ %
PageSize& .
==/ 1
$num2 3
)3 4
{ 
return 
temp 
;  
} 
return 
temp 
+ 
$num 
;  
} 
} 	
public 
int 
	PageIndex 
{ 
get "
;" #
set$ '
;' (
}) *
public 
bool 
Next 
=> 
	PageIndex %
+& '
$num( )
<* +
TotalPagesCount, ;
;; <
public 
bool 
Previous 
=> 
	PageIndex  )
>* +
$num, -
;- .
public   
ICollection   
<   
T   
>   
?   
Items   $
{  % &
get  ' *
;  * +
set  , /
;  / 0
}  1 2
}!! 
}"" в
cC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Chat\Setup\ChatHub.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Chat !
.! "
Setup" '
;' (
public 
class 
ChatHub 
: 
Hub 
{ 
public 

async 
Task 
SendMessageToGroup (
(( )
string) /
	groupName0 9
,9 :
string; A
userB F
,F G
stringH N
messageO V
)V W
{ 
await 
Clients 
. 
Group 
( 
	groupName %
)% &
.& '
	SendAsync' 0
(0 1
$str1 A
,A B
userC G
,G H
messageI P
)P Q
;Q R
}		 
public 

async 
Task 

AddToGroup  
(  !
string! '
	groupName( 1
)1 2
{ 
await 
Groups 
. 
AddToGroupAsync $
($ %
Context% ,
., -
ConnectionId- 9
,9 :
	groupName; D
)D E
;E F
await 
Clients 
. 
Group 
( 
	groupName %
)% &
.& '
	SendAsync' 0
(0 1
$str1 7
,7 8
$"9 ;
{; <
Context< C
.C D
ConnectionIdD P
}P Q
$strQ g
{g h
	groupNameh q
}q r
$strr s
"s t
)t u
;u v
} 
public 

async 
Task 
RemoveFromGroup %
(% &
string& ,
	groupName- 6
)6 7
{ 
await 
Groups 
.  
RemoveFromGroupAsync )
() *
Context* 1
.1 2
ConnectionId2 >
,> ?
	groupName@ I
)I J
;J K
await 
Clients 
. 
Group 
( 
	groupName %
)% &
.& '
	SendAsync' 0
(0 1
$str1 7
,7 8
$"9 ;
{; <
Context< C
.C D
ConnectionIdD P
}P Q
$strQ e
{e f
	groupNamef o
}o p
$strp q
"q r
)r s
;s t
} 
} ┌
ВC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Caching\ICachingService\IStateCacheManagerService.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Caching $
.$ %
ICachingService% 4
;4 5
public 
	interface %
IStateCacheManagerService *
{ 
	ValueTask 
SetServiceState 
( 
Guid "
tableId# *
)* +
;+ ,
	ValueTask 
< 
bool 
> 

CheckState 
( 
Guid #
tableId$ +
)+ ,
;, -
} Ь
xC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Caching\ICachingService\ILockingService.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Caching $
.$ %
ICachingService% 4
;4 5
public 
	interface 
ILockingService  
{ 
public 

Task 
< 
bool 
> 
AcquireLockAsync &
(& '
)' (
;( )
public 

Task 
ReleaseLockAsync  
(  !
)! "
;" #
} │
АC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Caching\CachingService\StateCacheManagerService.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Caching $
.$ %
CachingService% 3
;3 4
internal 
class	 $
StateCacheManagerService '
:( )%
IStateCacheManagerService* C
{ 
private 
readonly 
	IDatabase 
	_database (
;( )
public 
$
StateCacheManagerService #
(# $
	IDatabase$ -
database. 6
)6 7
{		 
	_database

 
=

 
database

 
;

 
} 
private 
static 
string 

GetLockKey $
($ %
Guid% )
tableId* 1
)1 2
=>3 5
$"6 8
{8 9
tableId9 @
}@ A
$strA K
"K L
;L M
public 

async 
	ValueTask 
< 
bool 
>  

CheckState! +
(+ ,
Guid, 0
tableId1 8
)8 9
{ 
var 
state 
= 
await 
	_database #
.# $
StringGetAsync$ 2
(2 3

GetLockKey3 =
(= >
tableId> E
)E F
)F G
;G H
return 
state 
== 
State 
( 
$num 
)  
;  !
} 
public 

async 
	ValueTask 
SetServiceState *
(* +
Guid+ /
tableId0 7
)7 8
=>9 ;
await< A
	_databaseB K
.K L
StringSetAsyncL Z
(Z [

GetLockKey[ e
(e f
tableIdf m
)m n
,n o
Statep u
(u v
$numv w
)w x
)x y
;y z
static 

string 
State 
( 
int 
stateNum $
)$ %
=>& (
stateNum) 1
switch2 8
{ 
$num 	
=>
 
$str 
, 
_ 	
=>
 
throw 
new #
NotImplementedException .
(. /
)/ 0
} 
; 
} ░
vC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Caching\CachingService\LockingService.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Caching $
.$ %
CachingService% 3
;3 4
public 
class 
LockingService 
: 
ILockingService -
,- .
IDisposable/ :
{ 
private 
readonly 
	IDatabase 
	_database (
;( )
private		 
readonly		 
string		 
_lockKey		 $
;		$ %
private

 
readonly

 
string

 

_lockValue

 &
;

& '
private 
readonly 
TimeSpan 
_expiry %
;% &
private 
bool 
_lockAcquired 
; 
public 

LockingService 
( 
	IDatabase #
database$ ,
,, -
string. 4
lockKey5 <
,< =
TimeSpan> F
expiryG M
)M N
{ 
	_database 
= 
database 
; 
_lockKey 
= 
lockKey 
; 

_lockValue 
= 
Guid 
. 
NewGuid !
(! "
)" #
.# $
ToString$ ,
(, -
)- .
;. /
_expiry 
= 
expiry 
; 
} 
public 

async 
Task 
< 
bool 
> 
AcquireLockAsync ,
(, -
)- .
{ 
_lockAcquired 
= 
await 
	_database '
.' (
StringSetAsync( 6
(6 7
_lockKey7 ?
,? @

_lockValueA K
,K L
_expiryM T
,T U
WhenV Z
.Z [
	NotExists[ d
)d e
;e f
return 
_lockAcquired 
; 
} 
public 

async 
Task 
ReleaseLockAsync &
(& '
)' (
{ 
if 

( 
_lockAcquired 
) 
{ 	
var 
tran 
= 
	_database  
.  !
CreateTransaction! 2
(2 3
)3 4
;4 5
tran   
.   
AddCondition   
(   
	Condition   '
.  ' (
StringEqual  ( 3
(  3 4
_lockKey  4 <
,  < =

_lockValue  > H
)  H I
)  I J
;  J K
_!! 
=!! 
tran!! 
.!! 
KeyDeleteAsync!! #
(!!# $
_lockKey!!$ ,
)!!, -
;!!- .
await"" 
tran"" 
."" 
ExecuteAsync"" #
(""# $
)""$ %
;""% &
}## 	
}$$ 
public%% 

void%% 
Dispose%% 
(%% 
)%% 
{&& 
if'' 

('' 
_lockAcquired'' 
)'' 
{(( 	
ReleaseLockAsync)) 
()) 
))) 
.)) 

GetAwaiter)) )
())) *
)))* +
.))+ ,
	GetResult)), 5
())5 6
)))6 7
;))7 8
}** 	
}++ 
},, Д
vC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Caching\CachingService\LockingHandler.cs
	namespace 	
FOV
 
. 
Infrastructure 
. 
Caching $
.$ %
CachingService% 3
;3 4
public		 
class		 
LockingHandler		 
:		 
IDisposable		 )
{

 
private 
readonly 
	IDatabase 
	_database (
;( )
private 
readonly 
string 
_lockKey $
;$ %
private 
readonly 
string 

_lockValue &
;& '
private 
readonly 
TimeSpan 
_expiry %
;% &
private 
bool 
_lockAcquired 
; 
public 

LockingHandler 
( 
	IDatabase #
database$ ,
,, -
string. 4
lockKey5 <
,< =
TimeSpan> F
expiryG M
)M N
{ 
	_database 
= 
database 
; 
_lockKey 
= 
lockKey 
; 

_lockValue 
= 
Guid 
. 
NewGuid !
(! "
)" #
.# $
ToString$ ,
(, -
)- .
;. /
_expiry 
= 
expiry 
; 
} 
public 

async 
Task 
< 
bool 
> 
AcquireLockAsync ,
(, -
)- .
{ 
_lockAcquired 
= 
await 
	_database '
.' (
StringSetAsync( 6
(6 7
_lockKey7 ?
,? @

_lockValueA K
,K L
_expiryM T
,T U
WhenV Z
.Z [
	NotExists[ d
)d e
;e f
return 
_lockAcquired 
; 
} 
public   

async   
Task   
ReleaseLockAsync   &
(  & '
)  ' (
{!! 
if"" 

("" 
_lockAcquired"" 
)"" 
{## 	
var$$ 
tran$$ 
=$$ 
	_database$$  
.$$  !
CreateTransaction$$! 2
($$2 3
)$$3 4
;$$4 5
tran%% 
.%% 
AddCondition%% 
(%% 
	Condition%% '
.%%' (
StringEqual%%( 3
(%%3 4
_lockKey%%4 <
,%%< =

_lockValue%%> H
)%%H I
)%%I J
;%%J K
_&& 
=&& 
tran&& 
.&& 
KeyDeleteAsync&& #
(&&# $
_lockKey&&$ ,
)&&, -
;&&- .
await'' 
tran'' 
.'' 
ExecuteAsync'' #
(''# $
)''$ %
;''% &
}(( 	
})) 
public** 

void** 
Dispose** 
(** 
)** 
{++ 
if,, 

(,, 
_lockAcquired,, 
),, 
{-- 	
ReleaseLockAsync.. 
(.. 
).. 
... 

GetAwaiter.. )
(..) *
)..* +
...+ ,
	GetResult.., 5
(..5 6
)..6 7
;..7 8
}// 	
}00 
}11 