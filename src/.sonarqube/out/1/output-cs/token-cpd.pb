�v
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
ingredientGeneralRepository	((| �
,
((� �'
IProductGeneralRepository
((� �&
productGeneralRepository
((� �
,
((� �1
#IProductIngredientGeneralRepository
((� �0
"productIngredientGeneralRepository
((� �
,
((� �
ITableRepository
((� �
tableRepository
((� �
,
((� �#
IRestaurantRepository
((� �"
restaurantRepository
((� �
,
((� �!
ICategoryRepository
((� � 
categoryRepository
((� �
,
((� � 
IProductRepository
((� �
productRepository
((� �
,
((� �#
IIngredientRepository
((� �"
ingredientRepository
((� �
,
((� �*
IProductIngredientRepository
((� �)
productIngredientRepository
((� �
,
((� �!
ICustomerRepository
((� � 
customerRepository
((� �
,
((� �!
IEmployeeRepository
((� � 
employeeRepository
((� �
,
((� �-
IIngrdientTransactionRepository
((� �,
ingrdientTransactionRepository
((� �
,
((� �%
IProductComboRepository
((� �$
productComboRepository
((� �
,
((� �
IComboRepository
((� �
comboRepository
((� �
,
((� �
IOrderRepository
((� �
orderRepository
((� �
,
((� �$
IOrderDetailRepository
((� �#
orderDetailRepository
((� �
,
((� �
IShiftRepository
((� �
shiftRepository
((� �
,
((� �'
IWaiterScheduleRepository
((� �&
waiterScheduleRepository
((� �
,
((� � 
IGroupChatRepository)) 
groupChatRepository)) 0
,))0 1#
IGroupMessageRepository))2 I"
groupMessageRepository))J `
,))` a 
IGroupUserRepository))b v 
groupUserRepository	))w �
,
))� �#
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
IIngredientUnitRepository	++~ �&
ingredientUnitRepository
++� �
,
++� �,
INewProductRecommendRepository
++� �+
newProductRecommendRepository
++� �
,
++� �/
!INewProductRecommendLogRepository
++� �.
 newProductRecommendLogRepository
++� �
)
++� �
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
�� 

async
�� 
Task
�� 
<
�� 
int
�� 
>
�� 
SaveChangeAsync
�� *
(
��* +
)
��+ ,
{
�� 
return
�� 
await
�� 
_context
�� 
.
�� 
SaveChangesAsync
�� .
(
��. /
)
��/ 0
;
��0 1
}
�� 
}�� �&
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
}66 �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\WaiterScheduleRepository.cs
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
} �
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
} �
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
} �
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
} �
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
} �
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\ProductIngredientRepository.cs
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\ProductIngredientGeneralRepository.cs
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
#IProductIngredientGeneralRepository	_ �
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
} �
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
} �B
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\ProductGeneralRepository.cs
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
}bb �
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
} �
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
} �
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
} �
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\NewProductRecommendRepository.cs
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\NewProductRecommendLogRepository.cs
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\IngredientUnitRepository.cs
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\IngredientTypeRepository.cs
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
� �
.
� �
SetProperty
� �
(
� �
b
� �
=>
� �
b
� �
.
� �
Right
� �
,
� �
b
� �
=>
� �
b
� �
.
� �
Right
� �
+
� �
$num
� �
)
� �
)
� �
;
� �
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
.	 �
SetProperty
� �
(
� �
b
� �
=>
� �
b
� �
.
� �
Left
� �
,
� �
b
� �
=>
� �
b
� �
.
� �
Right
� �
+
� �
$num
� �
)
� �
)
� �
;
� �
} 
} �
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
Id	~ �
)
� �
??
� �
throw
� �
new
� �
	Exception
� �
(
� �
)
� �
;
� �
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
}(( �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\IngredientGeneralRepository.cs
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\Repositories\IngrdientTransactionRepository.cs
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
} �
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
} �
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
} �
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
} �T
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
##� �
>
##� �
>
##� �
[
##� �
]
##� �
includes
##� �
)
##� �
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
object	^^| �
>
^^� �
>
^^� �
[
^^� �
]
^^� �
includes
^^� �
)
^^� �
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
}dd �
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
} �
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
} �
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
} �
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
} �
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IWaiterScheduleRepository.cs
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
} �
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
} �
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
} �
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
} �
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
} �
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IProductIngredientRepository.cs
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
}X Y�
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IProductIngredientGeneralRepository.cs
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IProductImageRepository.cs
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IProductGeneralRepository.cs
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
}		 �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IProductComboRepository.cs
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
} �
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
} �
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IOrderDetailRepository.cs
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\INewProductRecommendRepository.cs
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\INewProductRecommendLogRepository.cs
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IIngredientUnitRepository.cs
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IIngredientTypeRepository.cs
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
} �
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IIngredientGeneralRepository.cs
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IIngrdientTransactionRepository.cs
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
} �
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Repository\IRepositories\IGroupMessageRepository.cs
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
} �
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
} �
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
includes	~ �
)
� �
;
� �
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
[	 �
]
� �
includes
� �
)
� �
;
� �
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
} �
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
} �
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
} �
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
} �
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
} �
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
} ��
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
$str	||x �
,
||� �
$str
||� �
,
||� �
$str
||� �
,
||� �
$str
||� �
,
||� �
$str
||� �
,
||� �
$str
||� �
,
||� �
$str
||� �
,
||� �
$str
||� �
,
||� �
$str
||� �
,
||� �
$str
||� �
,
||� �
$str
||� �
}
||� �
,
||� �
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
,	 �
true
� �
,
� �
null
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
true
� �
,
� �
$str
� �
,
� �
false
� �
,
� �
$str
� �
}
� �
,
� �
{
�� 
$str
�� <
,
��< =
$num
��> ?
,
��? @
$str
��A O
,
��O P
$str
��Q f
,
��f g
true
��h l
,
��l m
$str
��n v
,
��v w
$str
��x }
,
��} ~
true�� �
,��� �
null��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
true��� �
,��� �
$str��� �
,��� �
false��� �
,��� �
$str��� �
}��� �
,��� �
{
�� 
$str
�� <
,
��< =
$num
��> ?
,
��? @
$str
��A O
,
��O P
$str
��Q e
,
��e f
true
��g k
,
��k l
$str
��m t
,
��t u
$str
��v {
,
��{ |
true��} �
,��� �
null��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
true��� �
,��� �
$str��� �
,��� �
false��� �
,��� �
$str��� �
}��� �
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 

UpdateData
�� '
(
��' (
table
�� 
:
�� 
$str
�� 
,
��  
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
,
��J K
column
�� 
:
�� 
$str
�� %
,
��% &
value
�� 
:
�� 
new
�� 
DateTime
�� #
(
��# $
$num
��$ (
,
��( )
$num
��* ,
,
��, -
$num
��. 0
,
��0 1
$num
��2 3
,
��3 4
$num
��5 7
,
��7 8
$num
��9 :
,
��: ;
$num
��< ?
,
��? @
DateTimeKind
��A M
.
��M N
Utc
��N Q
)
��Q R
.
��R S
AddTicks
��S [
(
��[ \
$num
��\ `
)
��` a
)
��a b
;
��b c
migrationBuilder
�� 
.
�� 

UpdateData
�� '
(
��' (
table
�� 
:
�� 
$str
�� 
,
��  
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
,
��J K
column
�� 
:
�� 
$str
�� %
,
��% &
value
�� 
:
�� 
new
�� 
DateTime
�� #
(
��# $
$num
��$ (
,
��( )
$num
��* ,
,
��, -
$num
��. 0
,
��0 1
$num
��2 3
,
��3 4
$num
��5 7
,
��7 8
$num
��9 :
,
��: ;
$num
��< ?
,
��? @
DateTimeKind
��A M
.
��M N
Utc
��N Q
)
��Q R
.
��R S
AddTicks
��S [
(
��[ \
$num
��\ `
)
��` a
)
��a b
;
��b c
migrationBuilder
�� 
.
�� 

UpdateData
�� '
(
��' (
table
�� 
:
�� 
$str
�� 
,
��  
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
,
��J K
column
�� 
:
�� 
$str
�� %
,
��% &
value
�� 
:
�� 
new
�� 
DateTime
�� #
(
��# $
$num
��$ (
,
��( )
$num
��* ,
,
��, -
$num
��. 0
,
��0 1
$num
��2 3
,
��3 4
$num
��5 7
,
��7 8
$num
��9 :
,
��: ;
$num
��< ?
,
��? @
DateTimeKind
��A M
.
��M N
Utc
��N Q
)
��Q R
.
��R S
AddTicks
��S [
(
��[ \
$num
��\ `
)
��` a
)
��a b
;
��b c
migrationBuilder
�� 
.
�� 

UpdateData
�� '
(
��' (
table
�� 
:
�� 
$str
�� "
,
��" #
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
,
��J K
column
�� 
:
�� 
$str
�� "
,
��" #
value
�� 
:
�� 
new
�� 
DateTime
�� #
(
��# $
$num
��$ (
,
��( )
$num
��* +
,
��+ ,
$num
��- /
,
��/ 0
$num
��1 2
,
��2 3
$num
��4 6
,
��6 7
$num
��8 9
,
��9 :
$num
��; >
,
��> ?
DateTimeKind
��@ L
.
��L M
Utc
��M P
)
��P Q
.
��Q R
AddTicks
��R Z
(
��Z [
$num
��[ _
)
��_ `
)
��` a
;
��a b
migrationBuilder
�� 
.
�� 

UpdateData
�� '
(
��' (
table
�� 
:
�� 
$str
�� "
,
��" #
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
,
��J K
column
�� 
:
�� 
$str
�� "
,
��" #
value
�� 
:
�� 
new
�� 
DateTime
�� #
(
��# $
$num
��$ (
,
��( )
$num
��* +
,
��+ ,
$num
��- /
,
��/ 0
$num
��1 2
,
��2 3
$num
��4 6
,
��6 7
$num
��8 9
,
��9 :
$num
��; >
,
��> ?
DateTimeKind
��@ L
.
��L M
Utc
��M P
)
��P Q
.
��Q R
AddTicks
��R Z
(
��Z [
$num
��[ _
)
��_ `
)
��` a
;
��a b
migrationBuilder
�� 
.
�� 

UpdateData
�� '
(
��' (
table
�� 
:
�� 
$str
�� "
,
��" #
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
,
��J K
column
�� 
:
�� 
$str
�� "
,
��" #
value
�� 
:
�� 
new
�� 
DateTime
�� #
(
��# $
$num
��$ (
,
��( )
$num
��* +
,
��+ ,
$num
��- /
,
��/ 0
$num
��1 2
,
��2 3
$num
��4 6
,
��6 7
$num
��8 9
,
��9 :
$num
��; >
,
��> ?
DateTimeKind
��@ L
.
��L M
Utc
��M P
)
��P Q
.
��Q R
AddTicks
��R Z
(
��Z [
$num
��[ _
)
��_ `
)
��` a
;
��a b
migrationBuilder
�� 
.
�� 
AddForeignKey
�� *
(
��* +
name
�� 
:
�� 
$str
�� ?
,
��? @
table
�� 
:
�� 
$str
�� (
,
��( )
column
�� 
:
�� 
$str
�� $
,
��$ %
principalTable
�� 
:
�� 
$str
��  +
,
��+ ,
principalColumn
�� 
:
��  
$str
��! %
)
��% &
;
��& '
}
�� 	
}
�� 
}�� ��
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
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 0
,
��0 1
x
��2 3
=>
��4 6
x
��7 8
.
��8 9
Id
��9 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� (
,
��( )
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
int
��& )
>
��) *
(
��* +
type
��+ /
:
��/ 0
$str
��1 :
,
��: ;
nullable
��< D
:
��D E
false
��F K
)
��K L
.
�� 

Annotation
�� #
(
��# $
$str
��$ D
,
��D E+
NpgsqlValueGenerationStrategy
��F c
.
��c d%
IdentityByDefaultColumn
��d {
)
��{ |
,
��| }
RoleId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
,
��P Q
	ClaimType
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S

ClaimValue
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
string
��. 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
true
��N R
)
��R S
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% :
,
��: ;
x
��< =
=>
��> @
x
��A B
.
��B C
Id
��C E
)
��E F
;
��F G
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� F
,
��F G
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
RoleId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� (
,
��( )
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
int
��& )
>
��) *
(
��* +
type
��+ /
:
��/ 0
$str
��1 :
,
��: ;
nullable
��< D
:
��D E
false
��F K
)
��K L
.
�� 

Annotation
�� #
(
��# $
$str
��$ D
,
��D E+
NpgsqlValueGenerationStrategy
��F c
.
��c d%
IdentityByDefaultColumn
��d {
)
��{ |
,
��| }
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
,
��P Q
	ClaimType
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S

ClaimValue
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
string
��. 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
true
��N R
)
��R S
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% :
,
��: ;
x
��< =
=>
��> @
x
��A B
.
��B C
Id
��C E
)
��E F
;
��F G
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� F
,
��F G
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� (
,
��( )
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
LoginProvider
�� !
=
��" #
table
��$ )
.
��) *
Column
��* 0
<
��0 1
string
��1 7
>
��7 8
(
��8 9
type
��9 =
:
��= >
$str
��? E
,
��E F
nullable
��G O
:
��O P
false
��Q V
)
��V W
,
��W X
ProviderKey
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
string
��/ 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= C
,
��C D
nullable
��E M
:
��M N
false
��O T
)
��T U
,
��U V!
ProviderDisplayName
�� '
=
��( )
table
��* /
.
��/ 0
Column
��0 6
<
��6 7
string
��7 =
>
��= >
(
��> ?
type
��? C
:
��C D
$str
��E K
,
��K L
nullable
��M U
:
��U V
true
��W [
)
��[ \
,
��\ ]
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% :
,
��: ;
x
��< =
=>
��> @
new
��A D
{
��E F
x
��G H
.
��H I
LoginProvider
��I V
,
��V W
x
��X Y
.
��Y Z
ProviderKey
��Z e
}
��f g
)
��g h
;
��h i
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� F
,
��F G
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� '
,
��' (
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
,
��P Q
RoleId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 9
,
��9 :
x
��; <
=>
��= ?
new
��@ C
{
��D E
x
��F G
.
��G H
UserId
��H N
,
��N O
x
��P Q
.
��Q R
RoleId
��R X
}
��Y Z
)
��Z [
;
��[ \
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� E
,
��E F
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
RoleId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� E
,
��E F
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� (
,
��( )
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
,
��P Q
LoginProvider
�� !
=
��" #
table
��$ )
.
��) *
Column
��* 0
<
��0 1
string
��1 7
>
��7 8
(
��8 9
type
��9 =
:
��= >
$str
��? E
,
��E F
nullable
��G O
:
��O P
false
��Q V
)
��V W
,
��W X
Name
�� 
=
�� 
table
��  
.
��  !
Column
��! '
<
��' (
string
��( .
>
��. /
(
��/ 0
type
��0 4
:
��4 5
$str
��6 <
,
��< =
nullable
��> F
:
��F G
false
��H M
)
��M N
,
��N O
Value
�� 
=
�� 
table
�� !
.
��! "
Column
��" (
<
��( )
string
��) /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 =
,
��= >
nullable
��? G
:
��G H
true
��I M
)
��M N
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% :
,
��: ;
x
��< =
=>
��> @
new
��A D
{
��E F
x
��G H
.
��H I
UserId
��I O
,
��O P
x
��Q R
.
��R S
LoginProvider
��S `
,
��` a
x
��b c
.
��c d
Name
��d h
}
��i j
)
��j k
;
��k l
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� F
,
��F G
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� !
,
��! "
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
	IsDeleted
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
bool
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
Address
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
string
��+ 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 ?
,
��? @
nullable
��A I
:
��I J
false
��K P
)
��P Q
,
��Q R
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
,
��P Q
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 3
,
��3 4
x
��5 6
=>
��7 9
x
��: ;
.
��; <
Id
��< >
)
��> ?
;
��? @
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� ?
,
��? @
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� $
,
��$ %
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K

TotalHours
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
decimal
��. 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
,
��X Y
TotalSalary
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
decimal
��/ 6
>
��6 7
(
��7 8
type
��8 <
:
��< =
$str
��> G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
,
��Y Z
Status
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
true
��J N
)
��N O
,
��O P
PayDate
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTime
��+ 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; U
,
��U V
nullable
��W _
:
��_ `
false
��a f
)
��f g
,
��g h
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
true
��J N
)
��N O
,
��O P
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 6
,
��6 7
x
��8 9
=>
��: <
x
��= >
.
��> ?
Id
��? A
)
��A B
;
��B C
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� B
,
��B C
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� '
,
��' (
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
ProductName
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
string
��/ 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= C
,
��C D
nullable
��E M
:
��M N
false
��O T
)
��T U
,
��U V 
ProductDescription
�� &
=
��' (
table
��) .
.
��. /
Column
��/ 5
<
��5 6
string
��6 <
>
��< =
(
��= >
type
��> B
:
��B C
$str
��D J
,
��J K
nullable
��L T
:
��T U
false
��V [
)
��[ \
,
��\ ]!
ProductImageDefault
�� '
=
��( )
table
��* /
.
��/ 0
Column
��0 6
<
��6 7
string
��7 =
>
��= >
(
��> ?
type
��? C
:
��C D
$str
��E K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
,
��] ^

CategoryId
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
Guid
��. 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: @
,
��@ A
nullable
��B J
:
��J K
true
��L P
)
��P Q
,
��Q R
	IsDeleted
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
bool
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
IsDraft
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
bool
��+ /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 @
,
��@ A
nullable
��B J
:
��J K
false
��L Q
)
��Q R
,
��R S
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 9
,
��9 :
x
��; <
=>
��= ?
x
��@ A
.
��A B
Id
��B D
)
��D E
;
��E F
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� H
,
��H I
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '

CategoryId
��' 1
,
��1 2
principalTable
�� &
:
��& '
$str
��( 4
,
��4 5
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� *
,
��* +
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
IngredientName
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
,
��X Y#
IngredientDescription
�� )
=
��* +
table
��, 1
.
��1 2
Column
��2 8
<
��8 9
string
��9 ?
>
��? @
(
��@ A
type
��A E
:
��E F
$str
��G M
,
��M N
nullable
��O W
:
��W X
false
��Y ^
)
��^ _
,
��_ `
IngredientTypeId
�� $
=
��% &
table
��' ,
.
��, -
Column
��- 3
<
��3 4
Guid
��4 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
,
��X Y
	IsDeleted
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
bool
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
IngredientMeasure
�� %
=
��& '
table
��( -
.
��- .
Column
��. 4
<
��4 5
byte
��5 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
,
��] ^
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% <
,
��< =
x
��> ?
=>
��@ B
x
��C D
.
��D E
Id
��E G
)
��G H
;
��H I
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� V
,
��V W
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
IngredientTypeId
��' 7
,
��7 8
principalTable
�� &
:
��& '
$str
��( 9
,
��9 :
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� 
,
�� 
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
	ComboName
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
false
��M R
)
��R S
,
��S T
Status
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
byte
��* .
>
��. /
(
��/ 0
type
��0 4
:
��4 5
$str
��6 @
,
��@ A
nullable
��B J
:
��J K
false
��L Q
)
��Q R
,
��R S
	IsDeleted
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
bool
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
Quantity
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
int
��, /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 @
,
��@ A
nullable
��B J
:
��J K
false
��L Q
)
��Q R
,
��R S
Price
�� 
=
�� 
table
�� !
.
��! "
Column
��" (
<
��( )
decimal
��) 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 A
,
��A B
nullable
��C K
:
��K L
false
��M R
)
��R S
,
��S T
PercentReduce
�� !
=
��" #
table
��$ )
.
��) *
Column
��* 0
<
��0 1
decimal
��1 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ I
,
��I J
nullable
��K S
:
��S T
false
��U Z
)
��Z [
,
��[ \
ExpiredDate
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
DateTime
��/ 7
>
��7 8
(
��8 9
type
��9 =
:
��= >
$str
��? Y
,
��Y Z
nullable
��[ c
:
��c d
false
��e j
)
��j k
,
��k l
RestaurantId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 0
,
��0 1
x
��2 3
=>
��4 6
x
��7 8
.
��8 9
Id
��9 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� B
,
��B C
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
RestaurantId
��' 3
,
��3 4
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� !
,
��! "
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
HireDate
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
DateTime
��, 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< V
,
��V W
nullable
��X `
:
��` a
false
��b g
)
��g h
,
��h i
EmployeeCode
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
string
��0 6
>
��6 7
(
��7 8
type
��8 <
:
��< =
$str
��> D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
,
��P Q
	IsDeleted
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
bool
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
RestaurantId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 3
,
��3 4
x
��5 6
=>
��7 9
x
��: ;
.
��; <
Id
��< >
)
��> ?
;
��? @
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� ?
,
��? @
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� E
,
��E F
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
RestaurantId
��' 3
,
��3 4
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� "
,
��" #
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
	GroupName
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
false
��M R
)
��R S
,
��S T
RestaurantId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
true
��N R
)
��R S
,
��S T
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 4
,
��4 5
x
��6 7
=>
��8 :
x
��; <
.
��< =
Id
��= ?
)
��? @
;
��@ A
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� F
,
��F G
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
RestaurantId
��' 3
,
��3 4
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� #
,
��# $
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
IngredientName
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
,
��X Y
IngredientAmount
�� $
=
��% &
table
��' ,
.
��, -
Column
��- 3
<
��3 4
decimal
��4 ;
>
��; <
(
��< =
type
��= A
:
��A B
$str
��C L
,
��L M
nullable
��N V
:
��V W
false
��X ]
)
��] ^
,
��^ _
ExpriedQuantity
�� #
=
��$ %
table
��& +
.
��+ ,
Column
��, 2
<
��2 3
decimal
��3 :
>
��: ;
(
��; <
type
��< @
:
��@ A
$str
��B K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
,
��] ^
IngredientTypeId
�� $
=
��% &
table
��' ,
.
��, -
Column
��- 3
<
��3 4
Guid
��4 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
,
��W X
RestaurantId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
true
��N R
)
��R S
,
��S T
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 5
,
��5 6
x
��7 8
=>
��9 ;
x
��< =
.
��= >
Id
��> @
)
��@ A
;
��A B
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� O
,
��O P
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
IngredientTypeId
��' 7
,
��7 8
principalTable
�� &
:
��& '
$str
��( 9
,
��9 :
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� G
,
��G H
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
RestaurantId
��' 3
,
��3 4
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� 
,
�� 
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
TableNumber
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
int
��/ 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: C
,
��C D
nullable
��E M
:
��M N
false
��O T
)
��T U
,
��U V
	TableCode
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
TableStatus
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
byte
��/ 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; E
,
��E F
nullable
��G O
:
��O P
false
��Q V
)
��V W
,
��W X
TableQRCode
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
string
��/ 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= C
,
��C D
nullable
��E M
:
��M N
true
��O S
)
��S T
,
��T U
	IsDeleted
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
bool
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
RestaurantId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 0
,
��0 1
x
��2 3
=>
��4 6
x
��7 8
.
��8 9
Id
��9 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� B
,
��B C
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
RestaurantId
��' 3
,
��3 4
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� ,
,
��, -
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
RestaurantId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
ProductGeneralId
�� $
=
��% &
table
��' ,
.
��, -
Column
��- 3
<
��3 4
Guid
��4 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
,
��X Y
Status
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
byte
��* .
>
��. /
(
��/ 0
type
��0 4
:
��4 5
$str
��6 @
,
��@ A
nullable
��B J
:
��J K
false
��L Q
)
��Q R
,
��R S
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% >
,
��> ?
x
��@ A
=>
��B D
x
��E F
.
��F G
Id
��G I
)
��I J
;
��J K
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� X
,
��X Y
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
ProductGeneralId
��' 7
,
��7 8
principalTable
�� &
:
��& '
$str
��( 9
,
��9 :
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� P
,
��P Q
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
RestaurantId
��' 3
,
��3 4
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
��  
,
��  !
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
ProductName
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
string
��/ 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= C
,
��C D
nullable
��E M
:
��M N
false
��O T
)
��T U
,
��U V 
ProductDescription
�� &
=
��' (
table
��) .
.
��. /
Column
��/ 5
<
��5 6
string
��6 <
>
��< =
(
��= >
type
��> B
:
��B C
$str
��D J
,
��J K
nullable
��L T
:
��T U
false
��V [
)
��[ \
,
��\ ]
ProductType
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
byte
��/ 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; E
,
��E F
nullable
��G O
:
��O P
false
��Q V
)
��V W
,
��W X

CategoryId
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
Guid
��. 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: @
,
��@ A
nullable
��B J
:
��J K
true
��L P
)
��P Q
,
��Q R
Price
�� 
=
�� 
table
�� !
.
��! "
Column
��" (
<
��( )
decimal
��) 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
RestaurantId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
ProductGeneralId
�� $
=
��% &
table
��' ,
.
��, -
Column
��- 3
<
��3 4
Guid
��4 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
,
��W X
	IsDeleted
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
bool
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 2
,
��2 3
x
��4 5
=>
��6 8
x
��9 :
.
��: ;
Id
��; =
)
��= >
;
��> ?
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� A
,
��A B
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '

CategoryId
��' 1
,
��1 2
principalTable
�� &
:
��& '
$str
��( 4
,
��4 5
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� L
,
��L M
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
ProductGeneralId
��' 7
,
��7 8
principalTable
�� &
:
��& '
$str
��( 9
,
��9 :
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� D
,
��D E
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
RestaurantId
��' 3
,
��3 4
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� 1
,
��1 2
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
ProductGeneralId
�� $
=
��% &
table
��' ,
.
��, -
Column
��- 3
<
��3 4
Guid
��4 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
,
��X Y
Quantity
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
decimal
��, 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W!
IngredientGeneralId
�� '
=
��( )
table
��* /
.
��/ 0
Column
��0 6
<
��6 7
Guid
��7 ;
>
��; <
(
��< =
type
��= A
:
��A B
$str
��C I
,
��I J
nullable
��K S
:
��S T
false
��U Z
)
��Z [
,
��[ \
	IsDeleted
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
bool
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% C
,
��C D
x
��E F
=>
��G I
x
��J K
.
��K L
Id
��L N
)
��N O
;
��O P
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� _
,
��_ `
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '!
IngredientGeneralId
��' :
,
��: ;
principalTable
�� &
:
��& '
$str
��( <
,
��< =
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� ]
,
��] ^
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
ProductGeneralId
��' 7
,
��7 8
principalTable
�� &
:
��& '
$str
��( 9
,
��9 :
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� '
,
��' (
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
DateTime
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
DateOnly
��, 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U

EmployeeId
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
Guid
��. 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: @
,
��@ A
nullable
��B J
:
��J K
true
��L P
)
��P Q
,
��Q R
ShiftId
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
Guid
��+ /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 =
,
��= >
nullable
��? G
:
��G H
false
��I N
)
��N O
,
��O P
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
true
��J N
)
��N O
,
��O P
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 9
,
��9 :
x
��; <
=>
��= ?
x
��@ A
.
��A B
Id
��B D
)
��D E
;
��E F
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� E
,
��E F
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� G
,
��G H
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '

EmployeeId
��' 1
,
��1 2
principalTable
�� &
:
��& '
$str
��( 3
,
��3 4
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� A
,
��A B
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
ShiftId
��' .
,
��. /
principalTable
�� &
:
��& '
$str
��( 0
,
��0 1
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� %
,
��% &
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
GroupChatId
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
Guid
��/ 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
false
��M R
)
��R S
,
��S T
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
,
��P Q
Content
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
string
��+ 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 ?
,
��? @
nullable
��A I
:
��I J
false
��K P
)
��P Q
,
��Q R
	CreatedAt
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
DateTime
��- 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= W
,
��W X
nullable
��Y a
:
��a b
false
��c h
)
��h i
,
��i j
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 7
,
��7 8
x
��9 :
=>
��; =
x
��> ?
.
��? @
Id
��@ B
)
��B C
;
��C D
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� C
,
��C D
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� G
,
��G H
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
GroupChatId
��' 2
,
��2 3
principalTable
�� &
:
��& '
$str
��( 4
,
��4 5
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� "
,
��" #
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
GroupChatId
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
Guid
��/ 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
false
��M R
)
��R S
,
��S T
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
,
��P Q
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 4
,
��4 5
x
��6 7
=>
��8 :
x
��; <
.
��< =
Id
��= ?
)
��? @
;
��@ A
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� @
,
��@ A
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� D
,
��D E
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
GroupChatId
��' 2
,
��2 3
principalTable
�� &
:
��& '
$str
��( 4
,
��4 5
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� &
,
��& '
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
IngredientId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
UnitName
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
string
��, 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: @
,
��@ A
nullable
��B J
:
��J K
false
��L Q
)
��Q R
,
��R S
ConversionFactor
�� $
=
��% &
table
��' ,
.
��, -
Column
��- 3
<
��3 4
decimal
��4 ;
>
��; <
(
��< =
type
��= A
:
��A B
$str
��C L
,
��L M
nullable
��N V
:
��V W
false
��X ]
)
��] ^
,
��^ _$
IngredientUnitParentId
�� *
=
��+ ,
table
��- 2
.
��2 3
Column
��3 9
<
��9 :
Guid
��: >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F L
,
��L M
nullable
��N V
:
��V W
true
��X \
)
��\ ]
,
��] ^
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 8
,
��8 9
x
��: ;
=>
��< >
x
��? @
.
��@ A
Id
��A C
)
��C D
;
��D E
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� W
,
��W X
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '$
IngredientUnitParentId
��' =
,
��= >
principalTable
�� &
:
��& '
$str
��( 8
,
��8 9
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� J
,
��J K
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
IngredientId
��' 3
,
��3 4
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� 
,
�� 
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
OrderStatus
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
byte
��/ 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; E
,
��E F
nullable
��G O
:
��O P
true
��Q U
)
��U V
,
��V W
	OrderType
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
byte
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 C
,
��C D
nullable
��E M
:
��M N
true
��O S
)
��S T
,
��T U
	OrderTime
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
DateTime
��- 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= W
,
��W X
nullable
��Y a
:
��a b
true
��c g
)
��g h
,
��h i

TotalPrice
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
decimal
��. 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
,
��X Y
TableId
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
Guid
��+ /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 =
,
��= >
nullable
��? G
:
��G H
false
��I N
)
��N O
,
��O P
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 0
,
��0 1
x
��2 3
=>
��4 6
x
��7 8
.
��8 9
Id
��9 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� 8
,
��8 9
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
TableId
��' .
,
��. /
principalTable
�� &
:
��& '
$str
��( 0
,
��0 1
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� /
,
��/ 0
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
Note
�� 
=
�� 
table
��  
.
��  !
Column
��! '
<
��' (
string
��( .
>
��. /
(
��/ 0
type
��0 4
:
��4 5
$str
��6 <
,
��< =
nullable
��> F
:
��F G
false
��H M
)
��M N
,
��N O#
NewProductRecommendId
�� )
=
��* +
table
��, 1
.
��1 2
Column
��2 8
<
��8 9
Guid
��9 =
>
��= >
(
��> ?
type
��? C
:
��C D
$str
��E K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
,
��] ^
LogDate
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
LogType
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
byte
��+ /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 A
,
��A B
nullable
��C K
:
��K L
false
��M R
)
��R S
,
��S T*
NewProductRecommendLogStatus
�� 0
=
��1 2
table
��3 8
.
��8 9
Column
��9 ?
<
��? @
byte
��@ D
>
��D E
(
��E F
type
��F J
:
��J K
$str
��L V
,
��V W
nullable
��X `
:
��` a
false
��b g
)
��g h
,
��h i
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
,
��P Q
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% A
,
��A B
x
��C D
=>
��E G
x
��H I
.
��I J
Id
��J L
)
��L M
;
��M N
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� M
,
��M N
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� _
,
��_ `
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '#
NewProductRecommendId
��' <
,
��< =
principalTable
�� &
:
��& '
$str
��( >
,
��> ?
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� %
,
��% &
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
ComboId
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
Guid
��+ /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 =
,
��= >
nullable
��? G
:
��G H
false
��I N
)
��N O
,
��O P
	ProductId
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
Guid
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 ?
,
��? @
nullable
��A I
:
��I J
false
��K P
)
��P Q
,
��Q R
	IsDeleted
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
bool
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 7
,
��7 8
x
��9 :
=>
��; =
x
��> ?
.
��? @
Id
��@ B
)
��B C
;
��C D
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� ?
,
��? @
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
ComboId
��' .
,
��. /
principalTable
�� &
:
��& '
$str
��( 0
,
��0 1
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� C
,
��C D
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
	ProductId
��' 0
,
��0 1
principalTable
�� &
:
��& '
$str
��( 2
,
��2 3
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� %
,
��% &
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
ImageUrl
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
string
��, 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: @
,
��@ A
nullable
��B J
:
��J K
false
��L Q
)
��Q R
,
��R S
IsMain
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
bool
��* .
>
��. /
(
��/ 0
type
��0 4
:
��4 5
$str
��6 ?
,
��? @
nullable
��A I
:
��I J
false
��K P
)
��P Q
,
��Q R
	ProductId
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
Guid
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 ?
,
��? @
nullable
��A I
:
��I J
false
��K P
)
��P Q
,
��Q R
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 7
,
��7 8
x
��9 :
=>
��; =
x
��> ?
.
��? @
Id
��@ B
)
��B C
;
��C D
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� C
,
��C D
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
	ProductId
��' 0
,
��0 1
principalTable
�� &
:
��& '
$str
��( 2
,
��2 3
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� *
,
��* +
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
	ProductId
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
Guid
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 ?
,
��? @
nullable
��A I
:
��I J
false
��K P
)
��P Q
,
��Q R
Quantity
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
decimal
��, 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
IngredientId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% <
,
��< =
x
��> ?
=>
��@ B
x
��C D
.
��D E
Id
��E G
)
��G H
;
��H I
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� N
,
��N O
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
IngredientId
��' 3
,
��3 4
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� H
,
��H I
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
	ProductId
��' 0
,
��0 1
principalTable
�� &
:
��& '
$str
��( 2
,
��2 3
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� #
,
��# $
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
CheckInTime
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
DateTimeOffset
��/ =
>
��= >
(
��> ?
type
��? C
:
��C D
$str
��E _
,
��_ `
nullable
��a i
:
��i j
false
��k p
)
��p q
,
��q r
CheckOutTime
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
true
��l p
)
��p q
,
��q r

EmployeeId
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
Guid
��. 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: @
,
��@ A
nullable
��B J
:
��J K
false
��L Q
)
��Q R
,
��R S
WaiterScheduleId
�� $
=
��% &
table
��' ,
.
��, -
Column
��- 3
<
��3 4
Guid
��4 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
,
��X Y
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 >
,
��> ?
nullable
��@ H
:
��H I
true
��J N
)
��N O
,
��O P
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 5
,
��5 6
x
��7 8
=>
��9 ;
x
��< =
.
��= >
Id
��> @
)
��@ A
;
��A B
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� A
,
��A B
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� C
,
��C D
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '

EmployeeId
��' 1
,
��1 2
principalTable
�� &
:
��& '
$str
��( 3
,
��3 4
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� O
,
��O P
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
WaiterScheduleId
��' 7
,
��7 8
principalTable
�� &
:
��& '
$str
��( 9
,
��9 :
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� .
,
��. /
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
Quantity
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
decimal
��, 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
TransactionDate
�� #
=
��$ %
table
��& +
.
��+ ,
Column
��, 2
<
��2 3
DateTime
��3 ;
>
��; <
(
��< =
type
��= A
:
��A B
$str
��C ]
,
��] ^
nullable
��_ g
:
��g h
false
��i n
)
��n o
,
��o p
Type
�� 
=
�� 
table
��  
.
��  !
Column
��! '
<
��' (
byte
��( ,
>
��, -
(
��- .
type
��. 2
:
��2 3
$str
��4 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
,
��P Q
IngredientId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
	IsDeleted
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
bool
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
OrderId
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
Guid
��+ /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 =
,
��= >
nullable
��? G
:
��G H
true
��I M
)
��M N
,
��N O
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% @
,
��@ A
x
��B C
=>
��D F
x
��G H
.
��H I
Id
��I K
)
��K L
;
��L M
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� R
,
��R S
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
IngredientId
��' 3
,
��3 4
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� H
,
��H I
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
OrderId
��' .
,
��. /
principalTable
�� &
:
��& '
$str
��( 0
,
��0 1
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� $
,
��$ %
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
ComboId
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
Guid
��+ /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 =
,
��= >
nullable
��? G
:
��G H
true
��I M
)
��M N
,
��N O
	ProductId
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
Guid
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 ?
,
��? @
nullable
��A I
:
��I J
true
��K O
)
��O P
,
��P Q
OrderId
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
Guid
��+ /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 =
,
��= >
nullable
��? G
:
��G H
true
��I M
)
��M N
,
��N O
Status
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
byte
��* .
>
��. /
(
��/ 0
type
��0 4
:
��4 5
$str
��6 @
,
��@ A
nullable
��B J
:
��J K
true
��L P
)
��P Q
,
��Q R
Quantity
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
int
��, /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 @
,
��@ A
nullable
��B J
:
��J K
false
��L Q
)
��Q R
,
��R S
Price
�� 
=
�� 
table
�� !
.
��! "
Column
��" (
<
��( )
decimal
��) 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 A
,
��A B
nullable
��C K
:
��K L
false
��M R
)
��R S
,
��S T
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 6
,
��6 7
x
��8 9
=>
��: <
x
��= >
.
��> ?
Id
��? A
)
��A B
;
��B C
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� >
,
��> ?
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
ComboId
��' .
,
��. /
principalTable
�� &
:
��& '
$str
��( 0
,
��0 1
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� >
,
��> ?
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
OrderId
��' .
,
��. /
principalTable
�� &
:
��& '
$str
��( 0
,
��0 1
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� B
,
��B C
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
	ProductId
��' 0
,
��0 1
principalTable
�� &
:
��& '
$str
��( 2
,
��2 3
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
��  
,
��  !
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
PaymentDate
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
DateTime
��/ 7
>
��7 8
(
��8 9
type
��9 =
:
��= >
$str
��? Y
,
��Y Z
nullable
��[ c
:
��c d
false
��e j
)
��j k
,
��k l
Amount
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
decimal
��* 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 B
,
��B C
nullable
��D L
:
��L M
false
��N S
)
��S T
,
��T U
	VnpTxnRef
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
false
��M R
)
��R S
,
��S T
PaymentStatus
�� !
=
��" #
table
��$ )
.
��) *
Column
��* 0
<
��0 1
byte
��1 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
,
��Y Z
PaymentMethods
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
byte
��2 6
>
��6 7
(
��7 8
type
��8 <
:
��< =
$str
��> H
,
��H I
nullable
��J R
:
��R S
false
��T Y
)
��Y Z
,
��Z [
OrderId
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
Guid
��+ /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 =
,
��= >
nullable
��? G
:
��G H
false
��I N
)
��N O
,
��O P
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 2
,
��2 3
x
��4 5
=>
��6 8
x
��9 :
.
��: ;
Id
��; =
)
��= >
;
��> ?
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� :
,
��: ;
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
OrderId
��' .
,
��. /
principalTable
�� &
:
��& '
$str
��( 0
,
��0 1
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� 
,
��  
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 8
,
��8 9
nullable
��: B
:
��B C
false
��D I
)
��I J
,
��J K
RatingStart
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
int
��/ 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: C
,
��C D
nullable
��E M
:
��M N
false
��O T
)
��T U
,
��U V
Comment
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
string
��+ 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 ?
,
��? @
nullable
��A I
:
��I J
false
��K P
)
��P Q
,
��Q R
ImageUrl
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
string
��, 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: @
,
��@ A
nullable
��B J
:
��J K
false
��L Q
)
��Q R
,
��R S
OrderId
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
Guid
��+ /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 =
,
��= >
nullable
��? G
:
��G H
false
��I N
)
��N O
,
��O P
UsefulQuantity
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
int
��2 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
,
��X Y
NonUsefulQuantity
�� %
=
��& '
table
��( -
.
��- .
Column
��. 4
<
��4 5
int
��5 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ I
,
��I J
nullable
��K S
:
��S T
false
��U Z
)
��Z [
,
��[ \
Created
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTimeOffset
��+ 9
>
��9 :
(
��: ;
type
��; ?
:
��? @
$str
��A [
,
��[ \
nullable
��] e
:
��e f
false
��g l
)
��l m
,
��m n
	CreatedBy
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
string
��- 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; A
,
��A B
nullable
��C K
:
��K L
true
��M Q
)
��Q R
,
��R S
LastModified
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTimeOffset
��0 >
>
��> ?
(
��? @
type
��@ D
:
��D E
$str
��F `
,
��` a
nullable
��b j
:
��j k
false
��l q
)
��q r
,
��r s
LastModifiedBy
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 1
,
��1 2
x
��3 4
=>
��5 7
x
��8 9
.
��9 :
Id
��: <
)
��< =
;
��= >
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� 9
,
��9 :
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
OrderId
��' .
,
��. /
principalTable
�� &
:
��& '
$str
��( 0
,
��0 1
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 

InsertData
�� '
(
��' (
table
�� 
:
�� 
$str
�� $
,
��$ %
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! %
,
��% &
$str
��' :
,
��: ;
$str
��< N
,
��N O
$str
��P W
,
��W X
$str
��Y i
,
��i j
$str
��k v
,
��v w
$str��x �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
,
��# $
]
��$ %
{
�� 
{
�� 
$str
�� <
,
��< =
$num
��> ?
,
��? @
$str
��A O
,
��O P
$str
��Q e
,
��e f
true
��g k
,
��k l
$str
��m t
,
��t u
$str
��v 
,�� �
true��� �
,��� �
null��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
true��� �
,��� �
$str��� �
,��� �
false��� �
,��� �
$str��� �
}��� �
,��� �
{
�� 
$str
�� <
,
��< =
$num
��> ?
,
��? @
$str
��A O
,
��O P
$str
��Q f
,
��f g
true
��h l
,
��l m
$str
��n v
,
��v w
$str
��x }
,
��} ~
true�� �
,��� �
null��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
true��� �
,��� �
$str��� �
,��� �
false��� �
,��� �
$str��� �
}��� �
,��� �
{
�� 
$str
�� <
,
��< =
$num
��> ?
,
��? @
$str
��A O
,
��O P
$str
��Q e
,
��e f
true
��g k
,
��k l
$str
��m t
,
��t u
$str
��v {
,
��{ |
true��} �
,��� �
null��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
true��� �
,��� �
$str��� �
,��� �
false��� �
,��� �
$str��� �
}��� �
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 

InsertData
�� '
(
��' (
table
�� 
:
�� 
$str
�� #
,
��# $
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! %
,
��% &
$str
��' 5
,
��5 6
$str
��7 @
,
��@ A
$str
��B M
,
��M N
$str
��O Z
,
��Z [
$str
��\ j
,
��j k
$str
��l |
}
��} ~
,
��~ 
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
,
��# $
]
��$ %
{
�� 
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str
��H S
,
��S T
new
��U X
DateTimeOffset
��Y g
(
��g h
new
��h k
DateTime
��l t
(
��t u
$num
��u v
,
��v w
$num
��x y
,
��y z
$num
��{ |
,
��| }
$num
��~ 
,�� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str
��H Q
,
��Q R
new
��S V
DateTimeOffset
��W e
(
��e f
new
��f i
DateTime
��j r
(
��r s
$num
��s t
,
��t u
$num
��v w
,
��w x
$num
��y z
,
��z {
$num
��| }
,
��} ~
$num�� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
}��� �
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 

InsertData
�� '
(
��' (
table
�� 
:
�� 
$str
�� (
,
��( )
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! %
,
��% &
$str
��' 0
,
��0 1
$str
��2 =
,
��= >
$str
��? L
,
��L M
$str
��N e
,
��e f
$str
��g w
,
��w x
$str��y �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
,
��# $
]
��$ %
{
�� 
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
DateTimeOffset
��L Z
(
��Z [
new
��[ ^
DateTime
��_ g
(
��g h
$num
��h i
,
��i j
$num
��k l
,
��l m
$num
��n o
,
��o p
$num
��q r
,
��r s
$num
��t u
,
��u v
$num
��w x
,
��x y
$num
��z {
,
��{ |
DateTimeKind��} �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$num��� �
,��� �
null��� �
,��� �
$num��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
DateTimeOffset
��L Z
(
��Z [
new
��[ ^
DateTime
��_ g
(
��g h
$num
��h i
,
��i j
$num
��k l
,
��l m
$num
��n o
,
��o p
$num
��q r
,
��r s
$num
��t u
,
��u v
$num
��w x
,
��x y
$num
��z {
,
��{ |
DateTimeKind��} �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$num��� �
,��� �
null��� �
,��� �
$num��� �
}��� �
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 

InsertData
�� '
(
��' (
table
�� 
:
�� 
$str
�� $
,
��$ %
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! %
,
��% &
$str
��' 0
,
��0 1
$str
��2 ;
,
��; <
$str
��= H
,
��H I
$str
��J U
,
��U V
$str
��W e
,
��e f
$str
��g w
,
��w x
$str��y �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
,
��# $
]
��$ %
{
�� 
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str
��H P
,
��P Q
new
��R U
DateTimeOffset
��V d
(
��d e
new
��e h
DateTime
��i q
(
��q r
$num
��r s
,
��s t
$num
��u v
,
��v w
$num
��x y
,
��y z
$num
��{ |
,
��| }
$num
��~ 
,�� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
(��� �
byte��� �
)��� �
$num��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str
��H Q
,
��Q R
new
��S V
DateTimeOffset
��W e
(
��e f
new
��f i
DateTime
��j r
(
��r s
$num
��s t
,
��t u
$num
��v w
,
��w x
$num
��y z
,
��z {
$num
��| }
,
��} ~
$num�� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
(��� �
byte��� �
)��� �
$num��� �
}��� �
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 

InsertData
�� '
(
��' (
table
�� 
:
�� 
$str
�� 
,
��  
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! %
,
��% &
$str
��' 2
,
��2 3
$str
��4 =
,
��= >
$str
��? J
,
��J K
$str
��L Y
,
��Y Z
$str
��[ f
,
��f g
$str
��h v
,
��v w
$str��x �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
,
��# $
]
��$ %
{
�� 
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str
��H Q
,
��Q R
new
��S V
DateTimeOffset
��W e
(
��e f
new
��f i
DateTime
��j r
(
��r s
$num
��s t
,
��t u
$num
��v w
,
��w x
$num
��y z
,
��z {
$num
��| }
,
��} ~
$num�� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Utc��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
(��� �
byte��� �
)��� �
$num��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str
��H Q
,
��Q R
new
��S V
DateTimeOffset
��W e
(
��e f
new
��f i
DateTime
��j r
(
��r s
$num
��s t
,
��t u
$num
��v w
,
��w x
$num
��y z
,
��z {
$num
��| }
,
��} ~
$num�� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Utc��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
(��� �
byte��� �
)��� �
$num��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str
��H Q
,
��Q R
new
��S V
DateTimeOffset
��W e
(
��e f
new
��f i
DateTime
��j r
(
��r s
$num
��s t
,
��t u
$num
��v w
,
��w x
$num
��y z
,
��z {
$num
��| }
,
��} ~
$num�� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Utc��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
(��� �
byte��� �
)��� �
$num��� �
}��� �
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 

InsertData
�� '
(
��' (
table
�� 
:
�� 
$str
�� "
,
��" #
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! %
,
��% &
$str
��' 0
,
��0 1
$str
��2 =
,
��= >
$str
��? M
,
��M N
$str
��O Y
,
��Y Z
$str
��[ f
,
��f g
$str
��h v
,
��v w
$str��x �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
,
��# $
]
��$ %
{
�� 
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
DateTimeOffset
��L Z
(
��Z [
new
��[ ^
DateTime
��_ g
(
��g h
$num
��h l
,
��l m
$num
��n o
,
��o p
$num
��q s
,
��s t
$num
��u v
,
��v w
$num
��x z
,
��z {
$num
��| }
,
��} ~
$num�� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Utc��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
$str��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
$str��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
DateTimeOffset
��L Z
(
��Z [
new
��[ ^
DateTime
��_ g
(
��g h
$num
��h l
,
��l m
$num
��n o
,
��o p
$num
��q s
,
��s t
$num
��u w
,
��w x
$num
��y z
,
��z {
$num
��| }
,
��} ~
$num�� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Utc��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
$str��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
$str��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
DateTimeOffset
��L Z
(
��Z [
new
��[ ^
DateTime
��_ g
(
��g h
$num
��h l
,
��l m
$num
��n o
,
��o p
$num
��q s
,
��s t
$num
��u w
,
��w x
$num
��y {
,
��{ |
$num
��} ~
,
��~ 
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Utc��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
$str��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
$str��� �
}��� �
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 

InsertData
�� '
(
��' (
table
�� 
:
�� 
$str
�� #
,
��# $
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! %
,
��% &
$str
��' 0
,
��0 1
$str
��2 =
,
��= >
$str
��? J
,
��J K
$str
��L Z
,
��Z [
$str
��\ l
,
��l m
$str
��n |
}
��} ~
,
��~ 
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
]
��# $
{
��% &
new
��' *
Guid
��+ /
(
��/ 0
$str
��0 V
)
��V W
,
��W X
new
��Y \
DateTimeOffset
��] k
(
��k l
new
��l o
DateTime
��p x
(
��x y
$num
��y z
,
��z {
$num
��| }
,
��} ~
$num�� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$str��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
}��� �
)��� �
;��� �
migrationBuilder
�� 
.
�� 

InsertData
�� '
(
��' (
table
�� 
:
�� 
$str
�� +
,
��+ ,
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! %
,
��% &
$str
��' 0
,
��0 1
$str
��2 =
,
��= >
$str
��? V
,
��V W
$str
��X k
,
��k l
$str
��m }
,
��} ~
$str�� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
,
��# $
]
��$ %
{
�� 
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
DateTimeOffset
��L Z
(
��Z [
new
��[ ^
DateTime
��_ g
(
��g h
$num
��h i
,
��i j
$num
��k l
,
��l m
$num
��n o
,
��o p
$num
��q r
,
��r s
$num
��t u
,
��u v
$num
��w x
,
��x y
$num
��z {
,
��{ |
DateTimeKind��} �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$str��� �
,��� �
(��� �
byte��� �
)��� �
$num��� �
,��� �
$str��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
DateTimeOffset
��L Z
(
��Z [
new
��[ ^
DateTime
��_ g
(
��g h
$num
��h i
,
��i j
$num
��k l
,
��l m
$num
��n o
,
��o p
$num
��q r
,
��r s
$num
��t u
,
��u v
$num
��w x
,
��x y
$num
��z {
,
��{ |
DateTimeKind��} �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$str��� �
,��� �
(��� �
byte��� �
)��� �
$num��� �
,��� �
$str��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
DateTimeOffset
��L Z
(
��Z [
new
��[ ^
DateTime
��_ g
(
��g h
$num
��h i
,
��i j
$num
��k l
,
��l m
$num
��n o
,
��o p
$num
��q r
,
��r s
$num
��t u
,
��u v
$num
��w x
,
��x y
$num
��z {
,
��{ |
DateTimeKind��} �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$str��� �
,��� �
(��� �
byte��� �
)��� �
$num��� �
,��� �
$str��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
}��� �
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 

InsertData
�� '
(
��' (
table
�� 
:
�� 
$str
�� (
,
��( )
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! %
,
��% &
$str
��' 3
,
��3 4
$str
��5 >
,
��> ?
$str
��@ K
,
��K L
$str
��M X
,
��X Y
$str
��Z c
,
��c d
$str
��e s
,
��s t
$str��u �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
,
��# $
]
��$ %
{
�� 
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
Guid
��L P
(
��P Q
$str
��Q w
)
��w x
,
��x y
new
��z }
DateTimeOffset��~ �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
false��� �
,��� �
true��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
Guid
��L P
(
��P Q
$str
��Q w
)
��w x
,
��x y
new
��z }
DateTimeOffset��~ �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
false��� �
,��� �
true��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
Guid
��L P
(
��P Q
$str
��Q w
)
��w x
,
��x y
new
��z }
DateTimeOffset��~ �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
false��� �
,��� �
true��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
Guid
��L P
(
��P Q
$str
��Q w
)
��w x
,
��x y
new
��z }
DateTimeOffset��~ �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
false��� �
,��� �
true��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
Guid
��L P
(
��P Q
$str
��Q w
)
��w x
,
��x y
new
��z }
DateTimeOffset��~ �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
false��� �
,��� �
true��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 

InsertData
�� '
(
��' (
table
�� 
:
�� 
$str
�� 2
,
��2 3
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! %
,
��% &
$str
��' 0
,
��0 1
$str
��2 =
,
��= >
$str
��? T
,
��T U
$str
��V a
,
��a b
$str
��c q
,
��q r
$str��s �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
]
��# $
{
��% &
new
��' *
Guid
��+ /
(
��/ 0
$str
��0 V
)
��V W
,
��W X
new
��Y \
DateTimeOffset
��] k
(
��k l
new
��l o
DateTime
��p x
(
��x y
$num
��y z
,
��z {
$num
��| }
,
��} ~
$num�� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
$num��� �
}��� �
)��� �
;��� �
migrationBuilder
�� 
.
�� 

InsertData
�� '
(
��' (
table
�� 
:
�� 
$str
�� !
,
��! "
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! %
,
��% &
$str
��' 3
,
��3 4
$str
��5 >
,
��> ?
$str
��@ K
,
��K L
$str
��M X
,
��X Y
$str
��Z h
,
��h i
$str
��j z
,
��z {
$str��| �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
,
��# $
]
��$ %
{
�� 
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
Guid
��L P
(
��P Q
$str
��Q w
)
��w x
,
��x y
new
��z }
DateTimeOffset��~ �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
$str��� �
,��� �
(��� �
byte��� �
)��� �
$num��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
Guid
��L P
(
��P Q
$str
��Q w
)
��w x
,
��x y
new
��z }
DateTimeOffset��~ �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
$str��� �
,��� �
(��� �
byte��� �
)��� �
$num��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
new
��H K
Guid
��L P
(
��P Q
$str
��Q w
)
��w x
,
��x y
new
��z }
DateTimeOffset��~ �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
false��� �
,��� �
new��� �
DateTimeOffset��� �
(��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Unspecified��� �
)��� �
,��� �
new��� �
TimeSpan��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
)��� �
,��� �
null��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
,��� �
$str��� �
,��� �
(��� �
byte��� �
)��� �
$num��� �
,��� �
new��� �
Guid��� �
(��� �
$str��� �
)��� �
}��� �
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 2
,
��2 3
table
�� 
:
�� 
$str
�� )
,
��) *
column
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� %
,
��% &
table
�� 
:
�� 
$str
�� $
,
��$ %
column
�� 
:
�� 
$str
�� (
,
��( )
unique
�� 
:
�� 
true
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 2
,
��2 3
table
�� 
:
�� 
$str
�� )
,
��) *
column
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 2
,
��2 3
table
�� 
:
�� 
$str
�� )
,
��) *
column
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 1
,
��1 2
table
�� 
:
�� 
$str
�� (
,
��( )
column
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
�� $
,
��$ %
column
�� 
:
�� 
$str
�� )
)
��) *
;
��* +
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� %
,
��% &
table
�� 
:
�� 
$str
�� $
,
��$ %
column
�� 
:
�� 
$str
�� ,
,
��, -
unique
�� 
:
�� 
true
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 1
,
��1 2
table
�� 
:
�� 
$str
�� $
,
��$ %
column
�� 
:
�� 
$str
�� $
)
��$ %
;
��% &
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 -
,
�	�	- .
table
�	�	 
:
�	�	 
$str
�	�	 $
,
�	�	$ %
column
�	�	 
:
�	�	 
$str
�	�	  
)
�	�	  !
;
�	�	! "
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 7
,
�	�	7 8
table
�	�	 
:
�	�	 
$str
�	�	 $
,
�	�	$ %
column
�	�	 
:
�	�	 
$str
�	�	 *
)
�	�	* +
;
�	�	+ ,
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 .
,
�	�	. /
table
�	�	 
:
�	�	 
$str
�	�	 
,
�	�	  
column
�	�	 
:
�	�	 
$str
�	�	 &
)
�	�	& '
;
�	�	' (
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 +
,
�	�	+ ,
table
�	�	 
:
�	�	 
$str
�	�	 "
,
�	�	" #
column
�	�	 
:
�	�	 
$str
�	�	  
,
�	�	  !
unique
�	�	 
:
�	�	 
true
�	�	 
)
�	�	 
;
�	�	 
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 1
,
�	�	1 2
table
�	�	 
:
�	�	 
$str
�	�	 "
,
�	�	" #
column
�	�	 
:
�	�	 
$str
�	�	 &
)
�	�	& '
;
�	�	' (
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 +
,
�	�	+ ,
table
�	�	 
:
�	�	 
$str
�	�	 "
,
�	�	" #
column
�	�	 
:
�	�	 
$str
�	�	  
,
�	�	  !
unique
�	�	 
:
�	�	 
true
�	�	 
)
�	�	 
;
�	�	 
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 2
,
�	�	2 3
table
�	�	 
:
�	�	 
$str
�	�	 #
,
�	�	# $
column
�	�	 
:
�	�	 
$str
�	�	 &
)
�	�	& '
;
�	�	' (
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 4
,
�	�	4 5
table
�	�	 
:
�	�	 
$str
�	�	 &
,
�	�	& '
column
�	�	 
:
�	�	 
$str
�	�	 %
)
�	�	% &
;
�	�	& '
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 /
,
�	�	/ 0
table
�	�	 
:
�	�	 
$str
�	�	 &
,
�	�	& '
column
�	�	 
:
�	�	 
$str
�	�	  
)
�	�	  !
;
�	�	! "
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 1
,
�	�	1 2
table
�	�	 
:
�	�	 
$str
�	�	 #
,
�	�	# $
column
�	�	 
:
�	�	 
$str
�	�	 %
)
�	�	% &
;
�	�	& '
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 ,
,
�	�	, -
table
�	�	 
:
�	�	 
$str
�	�	 #
,
�	�	# $
column
�	�	 
:
�	�	 
$str
�	�	  
)
�	�	  !
;
�	�	! "
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 >
,
�	�	> ?
table
�	�	 
:
�	�	 
$str
�	�	 +
,
�	�	+ ,
column
�	�	 
:
�	�	 
$str
�	�	 *
)
�	�	* +
;
�	�	+ ,
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 7
,
�	�	7 8
table
�	�	 
:
�	�	 
$str
�	�	 $
,
�	�	$ %
column
�	�	 
:
�	�	 
$str
�	�	 *
)
�	�	* +
;
�	�	+ ,
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 3
,
�	�	3 4
table
�	�	 
:
�	�	 
$str
�	�	 $
,
�	�	$ %
column
�	�	 
:
�	�	 
$str
�	�	 &
)
�	�	& '
;
�	�	' (
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 >
,
�	�	> ?
table
�	�	 
:
�	�	 
$str
�	�	 /
,
�	�	/ 0
column
�	�	 
:
�	�	 
$str
�	�	 &
)
�	�	& '
;
�	�	' (
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 9
,
�	�	9 :
table
�	�	 
:
�	�	 
$str
�	�	 /
,
�	�	/ 0
column
�	�	 
:
�	�	 
$str
�	�	 !
)
�	�	! "
;
�	�	" #
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 6
,
�	�	6 7
table
�	�	 
:
�	�	 
$str
�	�	 '
,
�	�	' (
column
�	�	 
:
�	�	 
$str
�	�	 &
)
�	�	& '
;
�	�	' (
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 @
,
�	�	@ A
table
�	�	 
:
�	�	 
$str
�	�	 '
,
�	�	' (
column
�	�	 
:
�	�	 
$str
�	�	 0
)
�	�	0 1
;
�	�	1 2
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 H
,
�	�	H I
table
�	�	 
:
�	�	 
$str
�	�	 0
,
�	�	0 1
column
�	�	 
:
�	�	 
$str
�	�	 /
)
�	�	/ 0
;
�	�	0 1
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 9
,
�	�	9 :
table
�	�	 
:
�	�	 
$str
�	�	 0
,
�	�	0 1
column
�	�	 
:
�	�	 
$str
�	�	  
)
�	�	  !
;
�	�	! "
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 @
,
�	�	@ A
table
�	�	 
:
�	�	 
$str
�	�	 -
,
�	�	- .
column
�	�	 
:
�	�	 
$str
�	�	 *
)
�	�	* +
;
�	�	+ ,
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 <
,
�	�	< =
table
�	�	 
:
�	�	 
$str
�	�	 -
,
�	�	- .
column
�	�	 
:
�	�	 
$str
�	�	 &
)
�	�	& '
;
�	�	' (
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 /
,
�	�	/ 0
table
�	�	 
:
�	�	 
$str
�	�	 %
,
�	�	% &
column
�	�	 
:
�	�	 
$str
�	�	 !
)
�	�	! "
;
�	�	" #
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 /
,
�	�	/ 0
table
�	�	 
:
�	�	 
$str
�	�	 %
,
�	�	% &
column
�	�	 
:
�	�	 
$str
�	�	 !
)
�	�	! "
;
�	�	" #
migrationBuilder
�	�	 
.
�	�	 
CreateIndex
�	�	 (
(
�	�	( )
name
�	�	 
:
�	�	 
$str
�	�	 1
,
�	�	1 2
table
�	�	 
:
�	�	 
$str
�	�	 %
,
�	�	% &
column
�	�	 
:
�	�	 
$str
�	�	 #
)
�	�	# $
;
�	�	$ %
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 )
,
�
�
) *
table
�
�
 
:
�
�
 
$str
�
�
 
,
�
�
  
column
�
�
 
:
�
�
 
$str
�
�
 !
)
�
�
! "
;
�
�
" #
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 +
,
�
�
+ ,
table
�
�
 
:
�
�
 
$str
�
�
 !
,
�
�
! "
column
�
�
 
:
�
�
 
$str
�
�
 !
)
�
�
! "
;
�
�
" #
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 0
,
�
�
0 1
table
�
�
 
:
�
�
 
$str
�
�
 &
,
�
�
& '
column
�
�
 
:
�
�
 
$str
�
�
 !
)
�
�
! "
;
�
�
" #
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 2
,
�
�
2 3
table
�
�
 
:
�
�
 
$str
�
�
 &
,
�
�
& '
column
�
�
 
:
�
�
 
$str
�
�
 #
)
�
�
# $
;
�
�
$ %
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 5
,
�
�
5 6
table
�
�
 
:
�
�
 
$str
�
�
 (
,
�
�
( )
column
�
�
 
:
�
�
 
$str
�
�
 $
)
�
�
$ %
;
�
�
% &
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 2
,
�
�
2 3
table
�
�
 
:
�
�
 
$str
�
�
 &
,
�
�
& '
column
�
�
 
:
�
�
 
$str
�
�
 #
)
�
�
# $
;
�
�
$ %
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 H
,
�
�
H I
table
�
�
 
:
�
�
 
$str
�
�
 2
,
�
�
2 3
column
�
�
 
:
�
�
 
$str
�
�
 -
)
�
�
- .
;
�
�
. /
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 E
,
�
�
E F
table
�
�
 
:
�
�
 
$str
�
�
 2
,
�
�
2 3
column
�
�
 
:
�
�
 
$str
�
�
 *
)
�
�
* +
;
�
�
+ ,
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 :
,
�
�
: ;
table
�
�
 
:
�
�
 
$str
�
�
 +
,
�
�
+ ,
column
�
�
 
:
�
�
 
$str
�
�
 &
)
�
�
& '
;
�
�
' (
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 7
,
�
�
7 8
table
�
�
 
:
�
�
 
$str
�
�
 +
,
�
�
+ ,
column
�
�
 
:
�
�
 
$str
�
�
 #
)
�
�
# $
;
�
�
$ %
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 .
,
�
�
. /
table
�
�
 
:
�
�
 
$str
�
�
 !
,
�
�
! "
column
�
�
 
:
�
�
 
$str
�
�
 $
)
�
�
$ %
;
�
�
% &
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 4
,
�
�
4 5
table
�
�
 
:
�
�
 
$str
�
�
 !
,
�
�
! "
column
�
�
 
:
�
�
 
$str
�
�
 *
)
�
�
* +
;
�
�
+ ,
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 0
,
�
�
0 1
table
�
�
 
:
�
�
 
$str
�
�
 !
,
�
�
! "
column
�
�
 
:
�
�
 
$str
�
�
 &
)
�
�
& '
;
�
�
' (
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 *
,
�
�
* +
table
�
�
 
:
�
�
 
$str
�
�
  
,
�
�
  !
column
�
�
 
:
�
�
 
$str
�
�
 !
,
�
�
! "
unique
�
�
 
:
�
�
 
true
�
�
 
)
�
�
 
;
�
�
 
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 .
,
�
�
. /
table
�
�
 
:
�
�
 
$str
�
�
 
,
�
�
  
column
�
�
 
:
�
�
 
$str
�
�
 &
)
�
�
& '
;
�
�
' (
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 .
,
�
�
. /
table
�
�
 
:
�
�
 
$str
�
�
 %
,
�
�
% &
column
�
�
 
:
�
�
 
$str
�
�
  
)
�
�
  !
;
�
�
! "
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 5
,
�
�
5 6
table
�
�
 
:
�
�
 
$str
�
�
 (
,
�
�
( )
column
�
�
 
:
�
�
 
$str
�
�
 $
)
�
�
$ %
;
�
�
% &
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 2
,
�
�
2 3
table
�
�
 
:
�
�
 
$str
�
�
 (
,
�
�
( )
column
�
�
 
:
�
�
 
$str
�
�
 !
)
�
�
! "
;
�
�
" #
migrationBuilder
�
�
 
.
�
�
 
CreateIndex
�
�
 (
(
�
�
( )
name
�
�
 
:
�
�
 
$str
�
�
 1
,
�
�
1 2
table
�
�
 
:
�
�
 
$str
�
�
 (
,
�
�
( )
column
�
�
 
:
�
�
 
$str
�
�
  
)
�
�
  !
;
�
�
! "
}
�
�
 	
	protected
�
�
 
override
�
�
 
void
�
�
 
Down
�
�
  $
(
�
�
$ %
MigrationBuilder
�
�
% 5
migrationBuilder
�
�
6 F
)
�
�
F G
{
�
�
 	
migrationBuilder
�
�
 
.
�
�
 
	DropTable
�
�
 &
(
�
�
& '
name
�
�
 
:
�
�
 
$str
�
�
 (
)
�
�
( )
;
�
�
) *
migrationBuilder
�
�
 
.
�
�
 
	DropTable
�
�
 &
(
�
�
& '
name
�
�
 
:
�
�
 
$str
�
�
 (
)
�
�
( )
;
�
�
) *
migrationBuilder
�
�
 
.
�
�
 
	DropTable
�
�
 &
(
�
�
& '
name
�
�
 
:
�
�
 
$str
�
�
 (
)
�
�
( )
;
�
�
) *
migrationBuilder
�
�
 
.
�
�
 
	DropTable
�
�
 &
(
�
�
& '
name
�
�
 
:
�
�
 
$str
�
�
 '
)
�
�
' (
;
�
�
( )
migrationBuilder
�
�
 
.
�
�
 
	DropTable
�
�
 &
(
�
�
& '
name
�
�
 
:
�
�
 
$str
�
�
 (
)
�
�
( )
;
�
�
) *
migrationBuilder
�
�
 
.
�
�
 
	DropTable
�
�
 &
(
�
�
& '
name
�
�
 
:
�
�
 
$str
�
�
 #
)
�
�
# $
;
�
�
$ %
migrationBuilder
�
�
 
.
�
�
 
	DropTable
�
�
 &
(
�
�
& '
name
�
�
 
:
�
�
 
$str
�
�
 !
)
�
�
! "
;
�
�
" #
migrationBuilder
�
�
 
.
�
�
 
	DropTable
�
�
 &
(
�
�
& '
name
�
�
 
:
�
�
 
$str
�
�
 %
)
�
�
% &
;
�
�
& '
migrationBuilder
�
�
 
.
�
�
 
	DropTable
�
�
 &
(
�
�
& '
name
�
�
 
:
�
�
 
$str
�
�
 "
)
�
�
" #
;
�
�
# $
migrationBuilder
�
�
 
.
�
�
 
	DropTable
�
�
 &
(
�
�
& '
name
�� 
:
�� 
$str
�� .
)
��. /
;
��/ 0
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� &
)
��& '
;
��' (
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� /
)
��/ 0
;
��0 1
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� $
)
��$ %
;
��% &
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� %
)
��% &
;
��& '
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� %
)
��% &
;
��& '
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� 1
)
��1 2
;
��2 3
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� *
)
��* +
;
��+ ,
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� 
)
��  
;
��  !
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� $
)
��$ %
;
��% &
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� #
)
��# $
;
��$ %
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� '
)
��' (
;
��( )
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� "
)
��" #
;
��# $
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� ,
)
��, -
;
��- .
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� 
)
�� 
;
��  
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� *
)
��* +
;
��+ ,
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� #
)
��# $
;
��$ %
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� 
)
�� 
;
��  
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� 
)
�� 
;
��  
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� '
)
��' (
;
��( )
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� '
)
��' (
;
��( )
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� 
)
�� 
;
��  
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� #
)
��# $
;
��$ %
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� "
)
��" #
;
��# $
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� #
)
��# $
;
��$ %
}
�� 	
}
�� 
}�� �f
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
�� 
=
�� 
$str
�� 
;
�� 
var
�� 
host
�� 
=
�� 
Dns
�� 
.
�� 
GetHostEntry
�� '
(
��' (
Dns
��( +
.
��+ ,
GetHostName
��, 7
(
��7 8
)
��8 9
)
��9 :
;
��: ;
foreach
�� 
(
�� 
var
�� 
ip
�� 
in
�� 
host
�� #
.
��# $
AddressList
��$ /
)
��/ 0
{
�� 
if
�� 
(
�� 
ip
�� 
.
�� 
AddressFamily
�� $
==
��% '
AddressFamily
��( 5
.
��5 6
InterNetwork
��6 B
)
��B C
{
�� 
	ipAddress
�� 
=
�� 
ip
��  "
.
��" #
ToString
��# +
(
��+ ,
)
��, -
;
��- .
}
�� 
}
�� 
}
�� 	
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
�� 
{
�� 	
	ipAddress
�� 
=
�� 
$str
�� %
+
��& '
ex
��( *
.
��* +
Message
��+ 2
;
��2 3
}
�� 	
return
�� 
	ipAddress
�� 
;
�� 
}
�� 
}�� 
public�� 
class
�� 
VnPayCompare
�� 
:
�� 
	IComparer
�� %
<
��% &
string
��& ,
>
��, -
{�� 
public
�� 

int
�� 
Compare
�� 
(
�� 
string
�� 
x
�� 
,
��  
string
��! '
y
��( )
)
��) *
{
�� 
if
�� 

(
�� 
x
�� 
==
�� 
y
�� 
)
�� 
return
�� 
$num
�� 
;
�� 
if
�� 

(
�� 
x
�� 
==
�� 
null
�� 
)
�� 
return
�� 
-
�� 
$num
��  
;
��  !
if
�� 

(
�� 
y
�� 
==
�� 
null
�� 
)
�� 
return
�� 
$num
�� 
;
��  
var
�� 

vnpCompare
�� 
=
�� 
CompareInfo
�� $
.
��$ %
GetCompareInfo
��% 3
(
��3 4
$str
��4 ;
)
��; <
;
��< =
return
�� 

vnpCompare
�� 
.
�� 
Compare
�� !
(
��! "
x
��" #
,
��# $
y
��% &
,
��& '
CompareOptions
��( 6
.
��6 7
Ordinal
��7 >
)
��> ?
;
��? @
}
�� 
}�� �

�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Helpers\QRCodeGeneratorHelper\QRCodeGeneratorHandler.cs
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
} �
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
} �
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
request	~ �
)
� �
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
} �7
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
CurrentCultureIgnoreCase	;;m �
)
;;� �
)
;;� �
;
;;� �
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
}PP �	
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
}"" �^
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
Empty	{ �
)
� �
||
� �
property
� �
.
� �
CustomAttributes
� �
.
� �
Any
� �
(
� �
a
� �
=>
� �
a
� �
.
� �
AttributeType
� �
==
� �
typeof
� �
(
� �
SkipAttribute
� �
)
� �
)
� �
)
� �
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
	guidValue	$$ �
!=
$$� �
Guid
$$� �
.
$$� �
Empty
$$� �
)
$$� �
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
$str	ZZu �
;
ZZ� �
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
}ee �-
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
}SS �
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
} �
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
} �;
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
DefaultIndex	t �
)
� �
;
� �
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
Doc	##~ �
(
##� �
u
##� �
)
##� �
.
##� �
DocAsUpsert
##� �
(
##� �
true
##� �
)
##� �
)
##� �
)
##� �
;
##� �
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
}HH �
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
} �
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
} �A
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
}XX �<
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
}?? �
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
} �

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
} �
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
}LL �

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
} �

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
} �,
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
}** �
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\ProductIngredientGeneralConfiguration.cs
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
} �
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
} �(
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
}:: �&
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
}-- �
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
} �
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
} �
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
} �
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
} �
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
}&& �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\FluentAPI\IngredientTransactionConfiguration.cs
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
} �
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
IngredientGeneralId	q �
)
� �
;
� �
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
}%% �
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
} �
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
} �
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
} �
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
} �#
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
};; �
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
} �*
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
}66 �
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
} �
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
} �
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
};; �F
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Data\Configurations\ApplicationDbContextInitializer.cs
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
User	| �
>
� �
userManager
� �
,
� �
RoleManager
� �
<
� �
IdentityRole
� �
>
� �
roleManager
� �
)
� �
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
}ll �
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
} �
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
} �
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
}"" �
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Caching\ICachingService\IStateCacheManagerService.cs
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
} �
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
} �
�C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Infrastructure\Caching\CachingService\StateCacheManagerService.cs
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
} �
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
},, �
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