¶
ÅC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Users\Queries\GetAllUser\GetAllUserHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Users# (
.( )
Queries) 0
.0 1

GetAllUser1 ;
;; <
public		 
sealed		 
record		 
GetUsersCommand		 $
(		$ %
string		% +
?		+ ,
UserName		- 5
,		5 6
string		7 =
?		= >
LastName		? G
,		G H
string		I O
?		O P
	FirstName		Q Z
,		Z [
string		\ b
?		b c
Email		d i
)		i j
:		k l
IRequest		m u
<		u v
List		v z
<		z {
GetUsersResponse			{ ã
>
		ã å
>
		å ç
;
		ç é
public 
sealed 
record 
GetUsersResponse %
(% &
string& ,
Id- /
,/ 0
string1 7
Name8 <
,< =
string> D
LastNameE M
,M N
stringO U
	FirstNameV _
,_ `
stringa g
Emailh m
)m n
;n o
public 
class 
GetAllUserHandler 
( 
UserManager *
<* +
User+ /
>/ 0
userManager1 <
)< =
:> ?
IRequestHandler@ O
<O P
GetUsersCommandP _
,_ `
Lista e
<e f
GetUsersResponsef v
>v w
>w x
{ 
private 
readonly 
UserManager  
<  !
User! %
>% &
_userManager' 3
=4 5
userManager6 A
;A B
public 

async 
Task 
< 
List 
< 
GetUsersResponse +
>+ ,
>, -
Handle. 4
(4 5
GetUsersCommand5 D
requestE L
,L M
CancellationTokenN _
cancellationToken` q
)q r
{ 
var 
users 
= 
await 
_userManager &
.& '
GetUsersInRoleAsync' :
(: ;
Domain; A
.A B
EntitiesB J
.J K
UserAggregatorK Y
.Y Z
EnumsZ _
._ `
Role` d
.d e
Usere i
)i j
;j k
;l m
var 

filterUser 
= 
users 
. 
AsQueryable *
(* +
)+ ,
., -
CustomFilterV1- ;
(; <
new< ?
User@ D
{ 	
UserName 
= 
request 
. 
UserName '
??( *
string+ 1
.1 2
Empty2 7
,7 8
	FirstName 
= 
request 
.  
	FirstName  )
??* ,
string- 3
.3 4
Empty4 9
,9 :
Email 
= 
request 
. 
Email !
??" $
string% +
.+ ,
Empty, 1
,1 2
LastName 
= 
request 
. 
LastName '
??( *
string+ 1
.1 2
Empty2 7
,7 8
} 	
)	 

;
 
return 
[ 
.. 

filterUser 
. 
Select $
($ %
x% &
=>' )
x* +
.+ ,
	MapAllDTO, 5
(5 6
)6 7
)7 8
]8 9
;9 :
} 
} øH
âC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Users\Queries\GetAllEmployee\GetAllEmployeeHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" #
Users		# (
.		( )
Queries		) 0
.		0 1
GetAllEmployee		1 ?
;		? @
public 
sealed 
record !
GetAllEmployeeCommand *
(* +
PagingRequest+ 8
?8 9
PagingRequest: G
,G H
stringI O
?O P
RoleQ U
,U V
GuidW [
?[ \
RestaurantId] i
,i j
stringk q
?q r
	FirstNames |
,| }
string	~ Ñ
?
Ñ Ö
Email
Ü ã
,
ã å
string
ç ì
?
ì î
EmployeeCode
ï °
,
° ¢
Status
£ ©
?
© ™
Status
´ ±
)
± ≤
:
≥ ¥
IRequest
µ Ω
<
Ω æ
PagedResult
æ …
<
…  $
GetAllEmployeeResponse
  ‡
>
‡ ·
>
· ‚
;
‚ „
public 
sealed 
record "
GetAllEmployeeResponse +
(+ ,
string, 2
Id3 5
,5 6
string7 =
UserName> F
,F G
stringH N
	FirstNameO X
,X Y
stringZ `
LastNamea i
,i j
stringk q
Emailr w
,w x
stringy 
EmployeeCode
Ä å
,
å ç
DateTime
é ñ
HireDate
ó ü
,
ü †
string
° ß
RoleName
® ∞
,
∞ ±
Guid
≤ ∂
RestaurantId
∑ √
,
√ ƒ
Status
≈ À
Status
Ã “
,
“ ”
DateTimeOffset
‘ ‚
Created
„ Í
)
Í Î
;
Î Ï
public 
class !
GetAllEmployeeHandler "
(" #
IUnitOfWorks# /
unitOfWorks0 ;
,; <
UserManager= H
<H I
UserI M
>M N
userManagerO Z
)Z [
:\ ]
IRequestHandler^ m
<m n"
GetAllEmployeeCommand	n É
,
É Ñ
PagedResult
Ö ê
<
ê ë$
GetAllEmployeeResponse
ë ß
>
ß ®
>
® ©
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
UserManager  
<  !
User! %
>% &
_userManager' 3
=4 5
userManager6 A
;A B
public 

async 
Task 
< 
PagedResult !
<! ""
GetAllEmployeeResponse" 8
>8 9
>9 :
Handle; A
(A B!
GetAllEmployeeCommandB W
requestX _
,_ `
CancellationTokena r
cancellationToken	s Ñ
)
Ñ Ö
{ 
var 
	employees 
= 
await 
_unitOfWorks *
.* +
EmployeeRepository+ =
.= >
GetAllAsync> I
(I J
xJ K
=>L N
xO P
.P Q
UserQ U
)U V
;V W
if 

( 
request 
. 
RestaurantId  
.  !
HasValue! )
)) *
{ 	
	employees 
= 
	employees !
.! "
Where" '
(' (
x( )
=>* ,
x- .
.. /
RestaurantId/ ;
==< >
request? F
.F G
RestaurantIdG S
)S T
.T U
ToListU [
([ \
)\ ]
;] ^
} 	
if 

( 
! 
string 
. 
IsNullOrEmpty !
(! "
request" )
.) *
	FirstName* 3
)3 4
)4 5
{ 	
	employees 
= 
	employees !
.! "
Where" '
(' (
x( )
=>* ,
x- .
.. /
User/ 3
.3 4
	FirstName4 =
.= >
Contains> F
(F G
requestG N
.N O
	FirstNameO X
)X Y
)Y Z
.Z [
ToList[ a
(a b
)b c
;c d
} 	
var   
filterEntity   
=   
	employees   $
.  $ %
AsQueryable  % 0
(  0 1
)  1 2
.  2 3
CustomFilterV1  3 A
(  A B
new  B E
Employee  F N
{!! 	
User"" 
="" 
new"" 
User"" 
{## 
	FirstName$$ 
=$$ 
request$$ #
.$$# $
	FirstName$$$ -
,$$- .
Email%% 
=%% 
request%% 
.%%  
Email%%  %
,%%% &
}&& 
,&& 
EmployeeCode'' 
='' 
request'' "
.''" #
EmployeeCode''# /
??''0 2
string''3 9
.''9 :
Empty'': ?
,''? @
}(( 	
)((	 

;((
 
var** 
result** 
=** 
new** 
List** 
<** "
GetAllEmployeeResponse** 4
>**4 5
(**5 6
)**6 7
;**7 8
foreach,, 
(,, 
var,, 
employee,, 
in,,  
filterEntity,,! -
),,- .
{-- 	
var.. 
roles.. 
=.. 
await.. 
_userManager.. *
...* +
GetRolesAsync..+ 8
(..8 9
employee..9 A
...A B
User..B F
)..F G
;..G H
var// 
roleName// 
=// 
roles//  
.//  !
FirstOrDefault//! /
(/// 0
)//0 1
??//2 4
string//5 ;
.//; <
Empty//< A
;//A B
if11 
(11 
string11 
.11 
IsNullOrEmpty11 $
(11$ %
request11% ,
.11, -
Role11- 1
)111 2
||113 5
roles116 ;
.11; <
Contains11< D
(11D E
request11E L
.11L M
Role11M Q
)11Q R
)11R S
{22 
result33 
.33 
Add33 
(33 
new33 "
GetAllEmployeeResponse33 5
(335 6
employee44 
.44 
User44 !
.44! "
Id44" $
,44$ %
employee55 
.55 
User55 !
.55! "
UserName55" *
,55* +
employee66 
.66 
User66 !
.66! "
	FirstName66" +
,66+ ,
employee77 
.77 
User77 !
.77! "
LastName77" *
,77* +
employee88 
.88 
User88 !
.88! "
Email88" '
,88' (
employee99 
.99 
EmployeeCode99 )
,99) *
employee:: 
.:: 
HireDate:: %
,::% &
roleName;; 
,;; 
employee<< 
.<< 
RestaurantId<< )
,<<) *
employee== 
.== 
Status== #
,==# $
employee>> 
.>> 
Created>> $
)?? 
)?? 
;?? 
}@@ 
}AA 	
varCC 
(CC 
pageCC 
,CC 
pageSizeCC 
,CC 
sortTypeCC %
,CC% &
	sortFieldCC' 0
)CC0 1
=CC2 3
PaginationUtilsCC4 C
.CCC D)
GetPaginationAndSortingValuesCCD a
(CCa b
requestCCb i
.CCi j
PagingRequestCCj w
)CCw x
;CCx y
sortTypeDD 
=DD 
DomainDD 
.DD 
CommonDD  
.DD  !
	SortOrderDD! *
.DD* +

DescendingDD+ 5
;DD5 6
varFF 
sortedResultsFF 
=FF 
PaginationHelperFF ,
<FF, -"
GetAllEmployeeResponseFF- C
>FFC D
.FFD E
SortingFFE L
(FFL M
sortTypeFFM U
,FFU V
resultFFW ]
,FF] ^
	sortFieldFF_ h
=FFi j
$strFFk u
)FFu v
;FFv w
varGG 
pagedResultGG 
=GG 
PaginationHelperGG *
<GG* +"
GetAllEmployeeResponseGG+ A
>GGA B
.GGB C
PagingGGC I
(GGI J
sortedResultsGGJ W
,GGW X
pageGGY ]
,GG] ^
pageSizeGG_ g
)GGg h
;GGh i
returnII 
pagedResultII 
;II 
}JJ 
}KK ®
nC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Users\Mapper\UserMapper.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" #
Users		# (
.		( )
Mapper		) /
;		/ 0
public

 
static

 
class

 

UserMapper

 
{ 
public 

static 
GetUsersResponse "
	MapAllDTO# ,
(, -
this- 1
User2 6
user7 ;
); <
{ 
return 
new 
GetUsersResponse #
(# $
user$ (
.( )
Id) +
,+ ,
user- 1
.1 2
UserName2 :
,: ;
user< @
.@ A
LastNameA I
,I J
userK O
.O P
	FirstNameP Y
,Y Z
user[ _
._ `
Email` e
)e f
;f g
} 
} ˛
ÜC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Users\Commands\Inactive\InactiveEmployeeHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Users# (
.( )
Commands) 1
.1 2
Inactive2 :
;: ;
public		 
sealed		 
record		 #
InactvieEmployeeCommand		 ,
(		, -
string		- 3
Id		4 6
)		6 7
:		8 9
IRequest		: B
<		B C
Result		C I
>		I J
;		J K
public

 
class

 #
InactiveEmployeeHandler

 $
(

$ %
IUnitOfWorks

% 1
unitOfWorks

2 =
,

= >
UserManager

? J
<

J K
User

K O
>

O P
userManager

Q \
)

\ ]
:

^ _
IRequestHandler

` o
<

o p$
InactvieEmployeeCommand	

p á
,


á à
Result


â è
>


è ê
{ 
private 
readonly 
UserManager  
<  !
User! %
>% &
_userManager' 3
=4 5
userManager6 A
;A B
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %#
InactvieEmployeeCommand% <
request= D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
{ 
var 
user 
= 
await 
_userManager %
.% &
Users& +
. 
Include 
( 
u 
=> 
u 
. 
Employee $
)$ %
. 
FirstOrDefaultAsync  
(  !
u! "
=># %
u& '
.' (
Id( *
==+ -
request. 5
.5 6
Id6 8
)8 9
;9 :
if 

( 
user 
== 
null 
) 
{ 	
return 
Result 
. 
Fail 
( 
$str 0
)0 1
;1 2
} 	
if 

( 
user 
. 
Employee 
== 
null !
)! "
{ 	
return 
Result 
. 
Fail 
( 
$str K
)K L
;L M
} 	
user 
. 
Employee 
. 
UpdateState !
(! "
false" '
)' (
;( )
_unitOfWorks!! 
.!! 
EmployeeRepository!! '
.!!' (
Update!!( .
(!!. /
user!!/ 3
.!!3 4
Employee!!4 <
)!!< =
;!!= >
await## 
_userManager## 
.## "
SetLockoutEnabledAsync## 1
(##1 2
user##2 6
,##6 7
true##8 <
)##< =
;##= >
await$$ 
_userManager$$ 
.$$ "
SetLockoutEndDateAsync$$ 1
($$1 2
user$$2 6
,$$6 7
DateTimeOffset$$8 F
.$$F G
UtcNow$$G M
.$$M N
AddYears$$N V
($$V W
$num$$W Y
)$$Y Z
)$$Z [
;$$[ \
await%% 
_unitOfWorks%% 
.%% 
SaveChangeAsync%% *
(%%* +
)%%+ ,
;%%, -
return'' 
Result'' 
.'' 
Ok'' 
('' 
)'' 
;'' 
}(( 
}** î
{C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Users\Commands\CreateUser\CreateUser.cs
	namespace

 	
FOV


 
.

 
Application

 
.

 
Features

 "
.

" #
Users

# (
.

( )
Commands

) 1
.

1 2

CreateUser

2 <
{ 
public 

class 
CreateUseCommand !
:" #
IRequest$ ,
<, -
string- 3
>3 4
{ 
public 
required 
string 
UserName '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
required 
string 
Email $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
required 
string 
PasswordDefault .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
} 
public 

class $
CreateUserCommandHandler )
:* +
IRequestHandler, ;
<; <
CreateUseCommand< L
,L M
stringN T
>T U
{ 
private 
readonly 
UserManager $
<$ %
User% )
>) *
_userManager+ 7
;7 8
public $
CreateUserCommandHandler '
(' (
UserManager( 3
<3 4
User4 8
>8 9
userManager: E
)E F
{ 	
_userManager 
= 
userManager &
;& '
} 	
public 
async 
Task 
< 
string  
>  !
Handle" (
(( )
CreateUseCommand) 9
request: A
,A B
CancellationTokenC T
cancellationTokenU f
)f g
{ 	
User 
user 
= 
new 
( 
) 
{ 
UserName 
= 
request "
." #
UserName# +
,+ ,
Email 
= 
request 
.  
Email  %
,% &
}   
;   
var!! 
result!! 
=!! 
await!! 
_userManager!! +
.!!+ ,
CreateAsync!!, 7
(!!7 8
user!!8 <
,!!< =
request!!> E
.!!E F
PasswordDefault!!F U
)!!U V
;!!V W
return## 
user## 
.## 
Id## 
;## 
}$$ 	
}%% 
}&& ≥
åC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Users\Commands\CreateEmployee\CreateEmployeeValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Users# (
.( )
Commands) 1
.1 2
CreateEmployee2 @
;@ A
public 
class #
CreateEmployeeValidator $
:% &
AbstractValidator' 8
<8 9!
CreateEmployeeCommand9 N
>N O
{ 
public		 
#
CreateEmployeeValidator		 "
(		" #
RestaurantValidator		# 6
validations		7 B
)		B C
{

 
RuleFor 
( 
x 
=> 
x 
. 
RoleId 
) 
. 	
NotEmpty	 
( 
) 
. 	
When	 
( 
x 
=> 
x 
. 
RoleId 
>= 
$num  
&&! #
x$ %
.% &
RoleId& ,
<=- /
$num0 1
)1 2
;2 3
RuleFor 
( 
x 
=> 
x 
. 
Email 
) 
. 
NotNull 
( 
) 
. 
Matches 
( 
$str 3
)3 4
. 
WithMessage 
( 
$str /
)/ 0
;0 1
RuleFor 
( 
x 
=> 
x 
. 
RestaurantId #
)# $
.$ %
NotNull% ,
(, -
)- .
.. /
SetValidator/ ;
(; <
validations< G
)G H
;H I
} 
} 
public 
sealed 
class 
RestaurantValidator '
:( )
AbstractValidator* ;
<; <
Guid< @
>@ A
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
public 

RestaurantValidator 
( 
IUnitOfWorks +
unitOfWorks, 7
)7 8
{ 
_unitOfWorks   
=   
unitOfWorks   "
;  " #
RuleFor!! 
(!! 
id!! 
=>!! 
id!! 
)!! 
.!! 
	MustAsync!! #
(!!# $
CheckIsExistId!!$ 2
)!!2 3
.!!3 4
WithMessage!!4 ?
(!!? @
$str!!@ Y
)!!Y Z
;!!Z [
}"" 
private$$ 
async$$ 
Task$$ 
<$$ 
bool$$ 
>$$ 
CheckIsExistId$$ +
($$+ ,
Guid$$, 0
restaurantId$$1 =
,$$= >
CancellationToken$$? P
token$$Q V
)$$V W
{%% 

Restaurant&& 
?&& 

restaurant&& 
=&&  
await&&! &
_unitOfWorks&&' 3
.&&3 4 
RestaurantRepository&&4 H
.&&H I
GetByIdAsync&&I U
(&&U V
restaurantId&&V b
)&&b c
;&&c d
return'' 

restaurant'' 
!='' 
null'' !
;''! "
}(( 
})) ⁄r
äC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Users\Commands\CreateEmployee\CreateEmployeeHandler.cs
	namespace

 	
FOV


 
.

 
Application

 
.

 
Features

 "
.

" #
	Authorize

# ,
.

, -
Commands

- 5
.

5 6
CreateEmployee

6 D
;

D E
public 
sealed 
record !
CreateEmployeeCommand *
(* +
string+ 1
LastName2 :
,: ;
string< B
	FirstNameC L
,L M
stringN T
AddressU \
,\ ]
string^ d
Emaile j
,j k
intl o
RoleIdp v
,v w
Guidx |
RestaurantId	} â
)
â ä
:
ã å
IRequest
ç ï
<
ï ñ
Result
ñ ú
<
ú ù
string
ù £
>
£ §
>
§ •
;
• ¶
public 
sealed 
record 
GenerateRole !
(! "
string" (
RoleName) 1
,1 2
string3 9
Code: >
)> ?
;? @
public 
partial 
class !
CreateEmployeeHandler *
(* +
IUnitOfWorks+ 7
unitOfWorks8 C
,C D
UserManagerE P
<P Q
UserQ U
>U V
userManagerW b
,b c
RoleManagerd o
<o p
IdentityRolep |
>| }
roleManager	~ â
)
â ä
:
ã å
IRequestHandler
ç ú
<
ú ù#
CreateEmployeeCommand
ù ≤
,
≤ ≥
Result
¥ ∫
<
∫ ª
string
ª ¡
>
¡ ¬
>
¬ √
{ 
private 
readonly 
UserManager  
<  !
User! %
>% &
_userManager' 3
=4 5
userManager6 A
;A B
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
RoleManager  
<  !
IdentityRole! -
>- .
_roleManager/ ;
=< =
roleManager> I
;I J
public 

async 
Task 
< 
Result 
< 
string #
># $
>$ %
Handle& ,
(, -!
CreateEmployeeCommand- B
requestC J
,J K
CancellationTokenL ]
cancellationToken^ o
)o p
{ 
var 
fieldErrors 
= 
new 
List "
<" #

FieldError# -
>- .
(. /
)/ 0
;0 1
var 
existingUser 
= 
await  
_userManager! -
.- .
FindByEmailAsync. >
(> ?
request? F
.F G
EmailG L
)L M
;M N
if 

( 
existingUser 
!= 
null  
)  !
{ 	
fieldErrors 
. 
Add 
( 
new 

FieldError  *
{ 
Field 
= 
$str 
,  
Message 
= 
$str 5
}   
)   
;   
}!! 	
var## 
roleName## 
=## 
UserRole## 
(##  
request##  '
.##' (
RoleId##( .
)##. /
;##/ 0
if$$ 

($$ 
!$$ 
await$$ 
_roleManager$$ 
.$$  
RoleExistsAsync$$  /
($$/ 0
roleName$$0 8
)$$8 9
)$$9 :
{%% 	
fieldErrors&& 
.&& 
Add&& 
(&& 
new&& 

FieldError&&  *
{'' 
Field(( 
=(( 
$str((  
,((  !
Message)) 
=)) 
$str)) @
}** 
)** 
;** 
}++ 	
if-- 

(-- 
fieldErrors-- 
.-- 
Any-- 
(-- 
)-- 
)-- 
{.. 	
throw// 
new// 
AppException// "
(//" #
$str//# D
,//D E
fieldErrors//F Q
)//Q R
;//R S
}00 	
var22 
generate22 
=22 
await22 
GenerateCode22 )
(22) *
request22* 1
.221 2
RoleId222 8
)228 9
;229 :
User44 
user44 
=44 
new44 
(44 
)44 
{55 	
	FirstName66 
=66 
request66 
.66  
	FirstName66  )
,66) *
LastName77 
=77 
request77 
.77 
LastName77 '
,77' (
Email88 
=88 
request88 
.88 
Email88 !
,88! "
UserName99 
=99 
request99 
.99 
Email99 $
}:: 	
;::	 

var<< 
result<< 
=<< 
await<< 
_userManager<< '
.<<' (
CreateAsync<<( 3
(<<3 4
user<<4 8
,<<8 9
$str<<: H
)<<H I
;<<I J
if== 

(== 
!== 
result== 
.== 
	Succeeded== 
)== 
{>> 	
var?? 

userErrors?? 
=?? 
result?? #
.??# $
Errors??$ *
.??* +
Select??+ 1
(??1 2
e??2 3
=>??4 6
new??7 :

FieldError??; E
{@@ 
FieldAA 
=AA 
$strAA &
,AA& '
MessageBB 
=BB 
eBB 
.BB 
DescriptionBB '
}CC 
)CC 
.CC 
ToListCC 
(CC 
)CC 
;CC 
throwEE 
newEE 
AppExceptionEE "
(EE" #
$strEE# D
,EED E

userErrorsEEF P
)EEP Q
;EEQ R
}FF 	
varHH 
roleAssignResultHH 
=HH 
awaitHH $
_userManagerHH% 1
.HH1 2
AddToRoleAsyncHH2 @
(HH@ A
userHHA E
,HHE F
roleNameHHG O
)HHO P
;HHP Q
ifII 

(II 
!II 
roleAssignResultII 
.II 
	SucceededII '
)II' (
{JJ 	
varKK 
roleAssignErrorsKK  
=KK! "
roleAssignResultKK# 3
.KK3 4
ErrorsKK4 :
.KK: ;
SelectKK; A
(KKA B
eKKB C
=>KKD F
newKKG J

FieldErrorKKK U
{LL 
FieldMM 
=MM 
$strMM (
,MM( )
MessageNN 
=NN 
eNN 
.NN 
DescriptionNN '
}OO 
)OO 
.OO 
ToListOO 
(OO 
)OO 
;OO 
throwQQ 
newQQ 
AppExceptionQQ "
(QQ" #
$strQQ# 8
,QQ8 9
roleAssignErrorsQQ: J
)QQJ K
;QQK L
}RR 	
EmployeeTT 
employeeTT 
=TT 
newTT 
(TT  
generateTT  (
.TT( )
CodeTT) -
,TT- .
userTT/ 3
.TT3 4
IdTT4 6
,TT6 7
requestTT8 ?
.TT? @
RestaurantIdTT@ L
)TTL M
;TTM N
awaitUU 
_unitOfWorksUU 
.UU 
EmployeeRepositoryUU -
.UU- .
AddAsyncUU. 6
(UU6 7
employeeUU7 ?
)UU? @
;UU@ A
awaitVV 
_unitOfWorksVV 
.VV 
SaveChangeAsyncVV *
(VV* +
)VV+ ,
;VV, -
stringYY 
messageYY 
=YY 
requestYY  
.YY  !
RoleIdYY! '
switchYY( .
{ZZ 	
$num[[ 
=>[[ 
$str[[ 3
,[[3 4
$num\\ 
=>\\ 
$str\\ 5
,\\5 6
_]] 
=>]] 
$str]] +
}^^ 	
;^^	 

return`` 
Result`` 
.`` 
Ok`` 
(`` 
message``  
)``  !
;``! "
}aa 
publicff 

staticff 
stringff 
UserRoleff !
(ff! "
intff" %
roleff& *
)ff* +
=>ff, .
roleff/ 3
switchff4 :
{gg 
$numhh 	
=>hh
 
Rolehh 
.hh 
Managerhh 
,hh 
$numii 	
=>ii
 
Roleii 
.ii 
Waiterii 
,ii 
$numjj 	
=>jj
 
Rolejj 
.jj 
Cookjj 
,jj 
_kk 	
=>kk
 
throwkk 
newkk #
NotImplementedExceptionkk .
(kk. /
)kk/ 0
,kk0 1
}ll 
;ll 
publicnn 

staticnn 
stringnn 
DefaultRoleValuenn )
(nn) *
intnn* -
rolenn. 2
)nn2 3
=>nn4 6
rolenn7 ;
switchnn< B
{oo 
$numpp 	
=>pp
 
$strpp 
,pp 
$numqq 	
=>qq
 
$strqq 
,qq 
$numrr 	
=>rr
 
$strrr 
,rr 
_ss 	
=>ss
 
throwss 
newss #
NotImplementedExceptionss .
(ss. /
)ss/ 0
,ss0 1
}tt 
;tt 
publicvv 

asyncvv 
Taskvv 
<vv 
GenerateRolevv "
>vv" #
GenerateCodevv$ 0
(vv0 1
intvv1 4
roleIdvv5 ;
)vv; <
{ww 
ifxx 

(xx 
!xx 
awaitxx 
_roleManagerxx 
.xx  
RoleExistsAsyncxx  /
(xx/ 0
UserRolexx0 8
(xx8 9
roleIdxx9 ?
)xx? @
)xx@ A
)xxA B
{yy 	
varzz 

roleResultzz 
=zz 
awaitzz "
_roleManagerzz# /
.zz/ 0
CreateAsynczz0 ;
(zz; <
newzz< ?
IdentityRolezz@ L
(zzL M
UserRolezzM U
(zzU V
roleIdzzV \
)zz\ ]
)zz] ^
)zz^ _
;zz_ `
if{{ 
({{ 
!{{ 

roleResult{{ 
.{{ 
	Succeeded{{ %
){{% &
{|| 
throw}} 
new}} 
	Exception}} #
(}}# $
)}}$ %
;}}% &
}~~ 
}
ÄÄ 	
await
ÅÅ 
_unitOfWorks
ÅÅ 
.
ÅÅ 
SaveChangeAsync
ÅÅ *
(
ÅÅ* +
)
ÅÅ+ ,
;
ÅÅ, -
var
ÉÉ 
users
ÉÉ 
=
ÉÉ 
await
ÉÉ 
_userManager
ÉÉ &
.
ÉÉ& '!
GetUsersInRoleAsync
ÉÉ' :
(
ÉÉ: ;
UserRole
ÉÉ; C
(
ÉÉC D
roleId
ÉÉD J
)
ÉÉJ K
)
ÉÉK L
;
ÉÉL M
return
ÑÑ 
users
ÑÑ 
.
ÑÑ 
Count
ÑÑ 
==
ÑÑ 
$num
ÑÑ 
?
ÖÖ 
new
ÖÖ 
GenerateRole
ÖÖ 
(
ÖÖ 
UserRole
ÖÖ '
(
ÖÖ' (
roleId
ÖÖ( .
)
ÖÖ. /
,
ÖÖ/ 0
DefaultRoleValue
ÖÖ1 A
(
ÖÖA B
roleId
ÖÖB H
)
ÖÖH I
)
ÖÖI J
:
ÜÜ 
new
ÜÜ 
GenerateRole
ÜÜ 
(
ÜÜ 
UserRole
ÜÜ '
(
ÜÜ' (
roleId
ÜÜ( .
)
ÜÜ. /
,
ÜÜ/ 0
IncrementRoleCode
ÜÜ1 B
(
ÜÜB C
users
ÜÜC H
.
ÜÜH I
FirstOrDefault
ÜÜI W
(
ÜÜW X
)
ÜÜX Y
?
ÜÜY Z
.
ÜÜZ [
Employee
ÜÜ[ c
?
ÜÜc d
.
ÜÜd e
EmployeeCode
ÜÜe q
??
ÜÜr t
DefaultRoleValueÜÜu Ö
(ÜÜÖ Ü
roleIdÜÜÜ å
)ÜÜå ç
)ÜÜç é
)ÜÜé è
;ÜÜè ê
}
àà 
public
ãã 

static
ãã 
string
ãã 
IncrementRoleCode
ãã *
(
ãã* +
string
ãã+ 1
roleCode
ãã2 :
)
ãã: ;
{
åå 
var
çç 
match
çç 
=
çç 
MyRegex
çç 
(
çç 
)
çç 
.
çç 
Match
çç #
(
çç# $
roleCode
çç$ ,
)
çç, -
;
çç- .
if
éé 

(
éé 
match
éé 
.
éé 
Success
éé 
)
éé 
{
èè 	
var
êê 
prefix
êê 
=
êê 
match
êê 
.
êê 
Groups
êê %
[
êê% &
$num
êê& '
]
êê' (
.
êê( )
Value
êê) .
;
êê. /
var
ëë 

numberPart
ëë 
=
ëë 
match
ëë "
.
ëë" #
Groups
ëë# )
[
ëë) *
$num
ëë* +
]
ëë+ ,
.
ëë, -
Value
ëë- 2
;
ëë2 3
var
íí 
incrementedNumber
íí !
=
íí" #
(
íí$ %
int
íí% (
.
íí( )
Parse
íí) .
(
íí. /

numberPart
íí/ 9
)
íí9 :
+
íí; <
$num
íí= >
)
íí> ?
.
íí? @
ToString
íí@ H
(
ííH I
)
ííI J
.
ííJ K
PadLeft
ííK R
(
ííR S

numberPart
ííS ]
.
íí] ^
Length
íí^ d
,
ííd e
$char
ííf i
)
ííi j
;
ííj k
return
ìì 
prefix
ìì 
+
ìì 
incrementedNumber
ìì -
;
ìì- .
}
îî 	
return
ïï 
roleCode
ïï 
;
ïï 
}
ññ 
[
òò 
GeneratedRegex
òò 
(
òò 
$str
òò #
)
òò# $
]
òò$ %
private
ôô 
static
ôô 
partial
ôô 
Regex
ôô  
MyRegex
ôô! (
(
ôô( )
)
ôô) *
;
ôô* +
}öö û
ÇC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Users\Commands\Active\ActiveEmployeeHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Users# (
.( )
Commands) 1
.1 2
Active2 8
;8 9
public		 
sealed		 
record		 !
ActiveEmployeeCommand		 *
(		* +
string		+ 1
Id		2 4
)		4 5
:		6 7
IRequest		8 @
<		@ A
Result		A G
>		G H
;		H I
public 
class !
ActiveEmployeeHandler "
(" #
IUnitOfWorks# /
unitOfWorks0 ;
,; <
UserManager= H
<H I
UserI M
>M N
userManagerO Z
)Z [
:\ ]
IRequestHandler^ m
<m n"
ActiveEmployeeCommand	n É
,
É Ñ
Result
Ö ã
>
ã å
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
UserManager  
<  !
User! %
>% &
_userManager' 3
=4 5
userManager6 A
;A B
public 

async 
Task 
< 
Result 
> 
Handle $
($ %!
ActiveEmployeeCommand% :
request; B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 
var 
user 
= 
await 
_userManager %
.% &
Users& +
. 
Include 
( 
u 
=> 
u 
. 
Employee #
)# $
. 
FirstOrDefaultAsync 
(  
u  !
=>" $
u% &
.& '
Id' )
==* ,
request- 4
.4 5
Id5 7
)7 8
;8 9
if 

( 
user 
== 
null 
) 
{ 	
return 
Result 
. 
Fail 
( 
$str 0
)0 1
;1 2
} 	
if 

( 
user 
. 
Employee 
== 
null !
)! "
{ 	
return 
Result 
. 
Fail 
( 
$str K
)K L
;L M
} 	
user!! 
.!! 
Employee!! 
.!! 
UpdateState!! !
(!!! "
false!!" '
)!!' (
;!!( )
_unitOfWorks## 
.## 
EmployeeRepository## '
.##' (
Update##( .
(##. /
user##/ 3
.##3 4
Employee##4 <
)##< =
;##= >
await&& 
_unitOfWorks&& 
.&& 
SaveChangeAsync&& *
(&&* +
)&&+ ,
;&&, -
await)) 
_userManager)) 
.)) "
SetLockoutEnabledAsync)) 1
())1 2
user))2 6
,))6 7
false))8 =
)))= >
;))> ?
await** 
_userManager** 
.** "
SetLockoutEndDateAsync** 1
(**1 2
user**2 6
,**6 7
DateTimeOffset**8 F
.**F G
MinValue**G O
)**O P
;**P Q
return,, 
Result,, 
.,, 
Ok,, 
(,, 
),, 
;,, 
}-- 
}// Ÿ-
sC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Tables\Queries\GetTableQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Tables# )
.) *
Queries* 1
;1 2
public

 
record

 
GetTableCommand

 
(

 
PagingRequest

 +
?

+ ,
PagingRequest

- :
,

: ;
Guid

< @
?

@ A
Id

B D
,

D E
int

F I
?

I J
TableNumber

K V
,

V W
string

X ^
?

^ _
	TableCode

` i
,

i j
Status

k q
?

q r
TableStatus

s ~
,

~ 
Guid


Ä Ñ
?


Ñ Ö
RestaurantId


Ü í
,


í ì
	SortOrder


î ù
?


ù û
Sort


ü £
)


£ §
:


• ¶
IRequest


ß Ø
<


Ø ∞
PagedResult


∞ ª
<


ª º
GetTableResponse


º Ã
>


Ã Õ
>


Õ Œ
;


Œ œ
public 
record 
GetTableResponse 
( 
Guid #
Id$ &
,& '
int( +
TableNumber, 7
,7 8
string9 ?
	TableCode@ I
,I J
StatusK Q
TableStatusR ]
,] ^
Guid_ c
RestaurantIdd p
)p q
;q r
public 
class 
GetTableQuery 
( 
IUnitOfWorks '
unitOfWorks( 3
)3 4
:5 6
IRequestHandler7 F
<F G
GetTableCommandG V
,V W
PagedResultX c
<c d
GetTableResponsed t
>t u
>u v
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
PagedResult !
<! "
GetTableResponse" 2
>2 3
>3 4
Handle5 ;
(; <
GetTableCommand< K
commandL S
,S T
CancellationTokenU f
cancellationTokeng x
)x y
{ 
var 
tables 
= 
( 
await 
_unitOfWorks (
.( )
TableRepository) 8
.8 9
GetAllAsync9 D
(D E
)E F
)F G
.G H
OrderByDescendingH Y
(Y Z
tZ [
=>\ ^
t_ `
.` a
Createda h
)h i
;i j
var 
filterEntity 
= 
new 
Table $
{ 	
Id 
= 
command 
. 
Id 
?? 
Guid #
.# $
Empty$ )
,) *
TableNumber 
= 
command !
.! "
TableNumber" -
??. 0
$num1 2
,2 3
	TableCode 
= 
command 
.  
	TableCode  )
??* ,
string- 3
.3 4
Empty4 9
,9 :
TableStatus 
= 
command !
.! "
TableStatus" -
??. 0
Status1 7
.7 8
Active8 >
,> ?
RestaurantId 
= 
command "
." #
RestaurantId# /
??0 2
Guid3 7
.7 8
Empty8 =
} 	
;	 

var 
filteredTables 
= 
tables #
.# $
AsQueryable$ /
(/ 0
)0 1
.1 2
CustomFilterV12 @
(@ A
filterEntityA M
)M N
;N O
var   
mappedTables   
=   
filteredTables   )
.  ) *
Select  * 0
(  0 1
table  1 6
=>  7 9
new  : =
GetTableResponse  > N
(  N O
table!! 
.!! 
Id!! 
,!! 
table"" 
."" 
TableNumber"" 
,"" 
table## 
.## 
	TableCode## 
,## 
table$$ 
.$$ 
TableStatus$$ 
,$$ 
table%% 
.%% 
RestaurantId%% 
)&& 	
)&&	 

.&&
 
ToList&& 
(&& 
)&& 
;&& 
var(( 
((( 
page(( 
,(( 
pageSize(( 
,(( 
sortType(( %
,((% &
	sortField((' 0
)((0 1
=((2 3
PaginationUtils((4 C
.((C D)
GetPaginationAndSortingValues((D a
(((a b
command((b i
.((i j
PagingRequest((j w
)((w x
;((x y
var** 
sortedResult** 
=** 
PaginationHelper** +
<**+ ,
GetTableResponse**, <
>**< =
.**= >
Sorting**> E
(**E F
sortType**F N
,**N O
mappedTables**P \
,**\ ]
	sortField**^ g
)**g h
;**h i
var++ 
result++ 
=++ 
PaginationHelper++ %
<++% &
GetTableResponse++& 6
>++6 7
.++7 8
Paging++8 >
(++> ?
sortedResult++? K
,++K L
page++M Q
,++Q R
pageSize++S [
)++[ \
;++\ ]
return,, 
result,, 
;,, 
}-- 
}.. ™
ÑC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Tables\Commands\Inactive\InactiveTableHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Tables# )
.) *
Commands* 2
.2 3
Inactive3 ;
;; <
public 
sealed 
record  
InactiveTableCommand )
() *
Guid* .
id/ 1
)1 2
:3 4
IRequest5 =
<= >
Result> D
>D E
;E F
public 
class  
InactiveTableHandler !
(! "
IUnitOfWorks" .
unitOfWorks/ :
): ;
:< =
IRequestHandler> M
<M N 
InactiveTableCommandN b
,b c
Resultd j
>j k
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ % 
InactiveTableCommand% 9
request: A
,A B
CancellationTokenC T
cancellationTokenU f
)f g
{ 
var 
table 
= 
await 
_unitOfWorks &
.& '
TableRepository' 6
.6 7
GetByIdAsync7 C
(C D
requestD K
.K L
idL N
)N O
??P R
throwS X
newY \
	Exception] f
(f g
)g h
;h i
table 
. 
UpdateState 
( 
true 
) 
;  
_unitOfWorks 
. 
TableRepository $
.$ %
Update% +
(+ ,
table, 1
)1 2
;2 3
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ≠7
ÄC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Tables\Commands\Create\CreateTableHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Tables# )
.) *
Commands* 2
.2 3
Create3 9
;9 :
public 
record 
CreateTableCommand  
(  !
Status! '
TableStatus( 3
)3 4
:5 6
IRequest7 ?
<? @
Guid@ D
>D E
{ 
[ 

JsonIgnore 
] 
public 

Guid 
RestaurantId 
{ 
get "
;" #
set$ '
;' (
}) *
} 
public 
class 
CreateTableHandler 
(  
IUnitOfWorks  ,
unitOfWorks- 8
,8 9
StorageHandler: H
storageHandlerI W
,W X"
QRCodeGeneratorHandlerY o#
qrCodeGeneratorHandler	p Ü
)
Ü á
:
à â
IRequestHandler
ä ô
<
ô ö 
CreateTableCommand
ö ¨
,
¨ ≠
Guid
Æ ≤
>
≤ ≥
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
StorageHandler #
_storageHandler$ 3
=4 5
storageHandler6 D
;D E
private 
readonly "
QRCodeGeneratorHandler +#
_qrCodeGeneratorHandler, C
=D E"
qrCodeGeneratorHandlerF \
;\ ]
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #
CreateTableCommand# 5
request6 =
,= >
CancellationToken? P
cancellationTokenQ b
)b c
{ 
Table 
table 
= 
new 
( 
request !
.! "
TableStatus" -
)- .
;. /
int 
nextTableNumber 
= 
await ##
GetNextTableNumberAsync$ ;
(; <
request< C
.C D
RestaurantIdD P
)P Q
;Q R
string 
	tableCode 
= 
$" 
$str !
{! "
nextTableNumber" 1
.1 2
ToString2 :
(: ;
$str; ?
)? @
}@ A
"A B
;B C
table   
.   
RestaurantId   
=   
request   $
.  $ %
RestaurantId  % 1
;  1 2
table!! 
.!! 
	TableCode!! 
=!! 
	tableCode!! #
;!!# $
table"" 
."" 
TableQRCode"" 
="" 
await"" !(
GenerateAndUploadQRCodeAsync""" >
(""> ?
request""? F
.""F G
RestaurantId""G S
,""S T
	tableCode""U ^
)""^ _
;""_ `
await$$ 
_unitOfWorks$$ 
.$$ 
TableRepository$$ *
.$$* +
AddAsync$$+ 3
($$3 4
table$$4 9
)$$9 :
;$$: ;
await%% 
_unitOfWorks%% 
.%% 
SaveChangeAsync%% *
(%%* +
)%%+ ,
;%%, -
return&& 
table&& 
.&& 
Id&& 
;&& 
}'' 
private)) 
async)) 
Task)) 
<)) 
int)) 
>)) #
GetNextTableNumberAsync)) 3
())3 4
Guid))4 8
restaurantId))9 E
)))E F
{** 
var++ 
highestTableNumber++ 
=++  
await++! &
_unitOfWorks++' 3
.++3 4
TableRepository++4 C
.,, &
GetHighestTableNumberAsync,, '
(,,' (
restaurantId,,( 4
),,4 5
;,,5 6
return.. 
(.. 
highestTableNumber.. "
??..# %
$num..& '
)..' (
+..) *
$num..+ ,
;.., -
}// 
private11 
async11 
Task11 
<11 
string11 
>11 (
GenerateAndUploadQRCodeAsync11 ;
(11; <
Guid11< @
RestaurantId11A M
,11M N
string11O U
	TableCode11V _
)11_ `
{22 
var33 

restaurant33 
=33 
await33 
_unitOfWorks33 +
.33+ , 
RestaurantRepository33, @
.33@ A
GetByIdAsync33A M
(33M N
RestaurantId33N Z
)33Z [
;33[ \
if44 

(44 

restaurant44 
==44 
null44 
)44 
{55 	
throw66 
new66 
	Exception66 
(66  
$str66  8
)668 9
;669 :
}77 	
string88 
restaurantCode88 
=88 

restaurant88  *
.88* +
RestataurantCode88+ ;
;88; <
string:: 
qRUrl:: 
=:: 
$":: 
$str:: B
{::B C
restaurantCode::C Q
}::Q R
$str::R Y
{::Y Z
	TableCode::Z c
}::c d
"::d e
;::e f
string;; 
fileName;; 
=;; 
$";; 
{;; 
restaurantCode;; +
};;+ ,
$str;;, -
{;;- .
	TableCode;;. 7
};;7 8
$str;;8 <
";;< =
;;;= >
Bitmap== 
qrCodeImage== 
=== #
_qrCodeGeneratorHandler== 4
.==4 5
GenerateQRCode==5 C
(==C D
qRUrl==D I
)==I J
;==J K
using?? 
(?? 
var?? 
memoryStream?? 
=??  !
new??" %
MemoryStream??& 2
(??2 3
)??3 4
)??4 5
{@@ 	
qrCodeImageAA 
.AA 
SaveAA 
(AA 
memoryStreamAA )
,AA) *
ImageFormatAA+ 6
.AA6 7
PngAA7 :
)AA: ;
;AA; <
memoryStreamBB 
.BB 
SeekBB 
(BB 
$numBB 
,BB  

SeekOriginBB! +
.BB+ ,
BeginBB, 1
)BB1 2
;BB2 3
varDD 
storageFileDD 
=DD 
awaitDD #
_storageHandlerDD$ 3
.DD3 4&
UploadQrImageForTableAsyncDD4 N
(DDN O
memoryStreamDDO [
,DD[ \
fileNameDD] e
)DDe f
;DDf g
returnEE 
storageFileEE 
.EE 
FileUrlEE &
;EE& '
}FF 	
}GG 
}HH ù
ÄC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Tables\Commands\Active\ActiveTableHandler.cs
	namespace

 	
FOV


 
.

 
Application

 
.

 
Features

 "
.

" #
Tables

# )
.

) *
Commands

* 2
.

2 3
Active

3 9
;

9 :
public 
sealed 
record 
ActiveTableCommand '
(' (
Guid( ,
id- /
)/ 0
:1 2
IRequest3 ;
<; <
Result< B
>B C
;C D
public 
class 
ActiveTableHandler 
(  
IUnitOfWorks  ,
unitOfWorks- 8
)8 9
:: ;
IRequestHandler< K
<K L
ActiveTableCommandL ^
,^ _
Result` f
>f g
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %
ActiveTableCommand% 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ 
var 
table 
= 
await 
_unitOfWorks &
.& '
TableRepository' 6
.6 7
GetByIdAsync7 C
(C D
requestD K
.K L
idL N
)N O
??P R
throwS X
newY \
	Exception] f
(f g
)g h
;h i
table 
. 
UpdateState 
( 
false 
)  
;  !
_unitOfWorks 
. 
TableRepository $
.$ %
Update% +
(+ ,
table, 1
)1 2
;2 3
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} §&
rC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Shift\Queries\GetShiftQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Shift# (
.( )
Queries) 0
;0 1
public 
record 
GetShiftRequest 
( 
Guid "
?" #
Id$ &
,& '
string( .
?. /
	ShiftName0 9
,9 :
TimeSpan; C
?C D
	StartTimeE N
,N O
TimeSpanP X
?X Y
EndTimeZ a
)a b
:c d
IRequeste m
<m n
Listn r
<r s
GetShiftResponse	s É
>
É Ñ
>
Ñ Ö
;
Ö Ü
public 
record 
GetShiftResponse 
( 
Guid #
Id$ &
,& '
string( .
	ShiftName/ 8
,8 9
TimeSpan: B
	StartTimeC L
,L M
TimeSpanN V
EndTimeW ^
)^ _
;_ `
public 
class 
GetShiftQuery 
( 
IUnitOfWorks '
unitOfWorks( 3
)3 4
:5 6
IRequestHandler7 F
<F G
GetShiftRequestG V
,V W
ListX \
<\ ]
GetShiftResponse] m
>m n
>n o
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
List 
< 
GetShiftResponse +
>+ ,
>, -
Handle. 4
(4 5
GetShiftRequest5 D
requestE L
,L M
CancellationTokenN _
cancellationToken` q
)q r
{ 
var 
shifts 
= 
await 
_unitOfWorks '
.' (
ShiftRepository( 7
.7 8
GetAllAsync8 C
(C D
)D E
;E F
var 
filterEntity 
= 
new 
Domain %
.% &
Entities& .
.. /
ShiftAggregator/ >
.> ?
Shift? D
{ 	
Id 
= 
request 
. 
Id 
. 
HasValue $
?% &
request' .
.. /
Id/ 1
.1 2
Value2 7
:8 9
Guid: >
.> ?
Empty? D
,D E
	ShiftName 
= 
string 
. 
IsNullOrEmpty ,
(, -
request- 4
.4 5
	ShiftName5 >
)> ?
?@ A
stringB H
.H I
EmptyI N
:O P
requestQ X
.X Y
	ShiftNameY b
,b c
	StartTime 
= 
request 
.  
	StartTime  )
.) *
HasValue* 2
?3 4
request5 <
.< =
	StartTime= F
.F G
ValueG L
:M N
TimeSpanO W
.W X
ZeroX \
,\ ]
EndTime 
= 
request 
. 
EndTime %
.% &
HasValue& .
?/ 0
request1 8
.8 9
EndTime9 @
.@ A
ValueA F
:G H
TimeSpanI Q
.Q R
ZeroR V
} 	
;	 

var 
filterTable 
= 
shifts  
.  !
AsQueryable! ,
(, -
)- .
.. /
CustomFilterV1/ =
(= >
filterEntity> J
)J K
;K L
return 
filterTable 
. 
Select !
(! "
shift" '
=>( *
new+ .
GetShiftResponse/ ?
(? @
shift@ E
.E F
IdF H
,H I
shiftJ O
.O P
	ShiftNameP Y
??Z \
string] c
.c d
Emptyd i
,i j
shiftk p
.p q
	StartTimeq z
??{ }
TimeSpan	~ Ü
.
Ü á
Zero
á ã
,
ã å
shift
ç í
.
í ì
EndTime
ì ö
??
õ ù
TimeSpan
û ¶
.
¶ ß
Zero
ß ´
)
´ ¨
)
¨ ≠
.
≠ Æ
ToList
Æ ¥
(
¥ µ
)
µ ∂
;
∂ ∑
} 
} ≠
C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Shift\Commands\Update\UpdateShiftHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Shift# (
.( )
Commands) 1
.1 2
Update2 8
;8 9
public 
sealed 
record 
UpdateShiftCommand '
(' (
Guid( ,
Id- /
,/ 0
string1 7
?7 8
	ShiftName9 B
,B C
TimeSpanD L
?L M
	StartTimeN W
,W X
TimeSpanY a
?a b
EndTimec j
)j k
:l m
IRequestn v
<v w
Resultw }
>} ~
;~ 
public 
class 
UpdateShiftHandler 
(  
IUnitOfWorks  ,
unitOfWorks- 8
)8 9
:: ;
IRequestHandler< K
<K L
UpdateShiftCommandL ^
,^ _
Result` f
>f g
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %
UpdateShiftCommand% 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ 
Domain 
. 
Entities 
. 
ShiftAggregator '
.' (
Shift( -
shift. 3
=4 5
await6 ;
_unitOfWorks< H
.H I
ShiftRepositoryI X
.X Y
GetByIdAsyncY e
(e f
requestf m
.m n
Idn p
)p q
??r t
throwu z
new{ ~
	Exception	 à
(
à â
)
â ä
;
ä ã
Domain 
. 
Entities 
. 
ShiftAggregator '
.' (
Shift( -
updatedShift. :
=; <
new= @
(@ A
requestA H
.H I
	ShiftNameI R
??S U
shiftV [
.[ \
	ShiftName\ e
,e f
requestg n
.n o
	StartTimeo x
??y {
shift	| Å
.
Å Ç
	StartTime
Ç ã
,
ã å
request
ç î
.
î ï
EndTime
ï ú
??
ù ü
shift
† •
.
• ¶
EndTime
¶ ≠
)
≠ Æ
;
Æ Ø
_unitOfWorks 
. 
ShiftRepository $
.$ %
Update% +
(+ ,
updatedShift, 8
)8 9
;9 :
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} æ
ÉC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Shift\Commands\Inactive\InactiveShiftHandler.cs
	namespace

 	
FOV


 
.

 
Application

 
.

 
Features

 "
.

" #
Shift

# (
.

( )
Commands

) 1
.

1 2
Inactive

2 :
;

: ;
public 
record  
InactiveShiftCommand "
(" #
Guid# '
ShiftId( /
)/ 0
:1 2
IRequest3 ;
<; <
Result< B
>B C
;C D
public 
class  
InactiveShiftHandler !
(! "
IUnitOfWorks" .
unitOfWorks/ :
): ;
:< =
IRequestHandler> M
<M N 
InactiveShiftCommandN b
,b c
Resultd j
>j k
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ % 
InactiveShiftCommand% 9
request: A
,A B
CancellationTokenC T
cancellationTokenU f
)f g
{ 
var 
shift 
= 
await 
_unitOfWorks &
.& '
ShiftRepository' 6
.6 7
GetByIdAsync7 C
(C D
requestD K
.K L
ShiftIdL S
)S T
;T U
if 

( 
shift 
== 
null 
) 
{ 	
return 
Result 
. 
Fail 
( 
$str :
): ;
;; <
} 	
shift 
. 
UpdateState 
( 
true 
) 
;  
_unitOfWorks 
. 
ShiftRepository $
.$ %
Update% +
(+ ,
shift, 1
)1 2
;2 3
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} Ø
C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Shift\Commands\Create\CreateShiftHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" #
Shift		# (
.		( )
Commands		) 1
.		1 2
Create		2 8
;		8 9
public

 
record

 
CreateShiftCommand

  
(

  !
string

! '
	ShiftName

( 1
,

1 2
TimeSpan

3 ;
	StartTime

< E
,

E F
TimeSpan

G O
EndTime

P W
)

W X
:

Y Z
IRequest

[ c
<

c d
Guid

d h
>

h i
;

i j
public 
class 
CreateShiftHandler 
(  
IUnitOfWorks  ,
unitOfWorks- 8
)8 9
:: ;
IRequestHandler< K
<K L
CreateShiftCommandL ^
,^ _
Guid` d
>d e
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #
CreateShiftCommand# 5
request6 =
,= >
CancellationToken? P
cancellationTokenQ b
)b c
{ 
Domain 
. 
Entities 
. 
ShiftAggregator '
.' (
Shift( -
shift. 3
=4 5
new6 9
(9 :
request: A
.A B
	ShiftNameB K
,K L
requestM T
.T U
	StartTimeU ^
,^ _
request` g
.g h
EndTimeh o
)o p
;p q
await 
_unitOfWorks 
. 
ShiftRepository *
.* +
AddAsync+ 3
(3 4
shift4 9
)9 :
;: ;
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
shift 
. 
Id 
; 
} 
} ∫
C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Shift\Commands\Active\ActiveShiftHandler.cs
	namespace

 	
FOV


 
.

 
Application

 
.

 
Features

 "
.

" #
Shift

# (
.

( )
Commands

) 1
.

1 2
Active

2 8
;

8 9
public 
sealed 
record 
ActiveShiftCommand '
(' (
Guid( ,
id- /
)/ 0
:1 2
IRequest3 ;
<; <
Result< B
>B C
;C D
public 
class 
ActiveShiftHandler 
(  
IUnitOfWorks  ,
unitOfWorks- 8
)8 9
:: ;
IRequestHandler< K
<K L
ActiveShiftCommandL ^
,^ _
Result` f
>f g
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %
ActiveShiftCommand% 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ 
var 
shift 
= 
await 
_unitOfWorks &
.& '
ShiftRepository' 6
.6 7
GetByIdAsync7 C
(C D
requestD K
.K L
idL N
)N O
;O P
if 

( 
shift 
== 
null 
) 
{ 	
return 
Result 
. 
Fail 
( 
$str :
): ;
;; <
} 	
shift 
. 
UpdateState 
( 
false 
)  
;  !
_unitOfWorks 
. 
ShiftRepository $
.$ %
Update% +
(+ ,
shift, 1
)1 2
;2 3
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ∫3
ñC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Schedules\Queries\GetEmployeeSchedules\GetEmployeeScheduleQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
	Schedules# ,
., -
Queries- 4
.4 5 
GetEmployeeSchedules5 I
;I J
public 
record &
GetEmployeeScheduleRequest (
(( )
PagingRequest) 6
?6 7
PagingRequest8 E
,E F
GuidG K
?K L
IdM O
,O P
GuidQ U
?U V

EmployeeIdW a
,a b
Guidc g
?g h
ShiftIdi p
)p q
:r s
IRequestt |
<| }
PagedResult	} à
<
à â)
GetEmployeeScheduleResponse
â §
>
§ •
>
• ¶
;
¶ ß
public 
record '
GetEmployeeScheduleResponse )
() *
Guid* .
Id/ 1
,1 2
EmployeeDto3 >
Employee? G
,G H
ShiftDtoI Q
ShiftR W
,W X
DateOnlyY a
Dateb f
)f g
;g h
public 
record 
ShiftDto 
( 
Guid 
ShiftId #
,# $
string% +
	ShiftName, 5
)5 6
;6 7
public 
record 
EmployeeDto 
( 
Guid 

EmployeeId )
,) *
string+ 1
EmployeeCode2 >
)> ?
;? @
public 
class $
GetEmployeeScheduleQuery %
(% &
IUnitOfWorks& 2
unitOfWorks3 >
)> ?
:@ A
IRequestHandlerB Q
<Q R&
GetEmployeeScheduleRequestR l
,l m
PagedResultn y
<y z(
GetEmployeeScheduleResponse	z ï
>
ï ñ
>
ñ ó
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
PagedResult !
<! "'
GetEmployeeScheduleResponse" =
>= >
>> ?
Handle@ F
(F G&
GetEmployeeScheduleRequestG a
requestb i
,i j
CancellationTokenk |
cancellationToken	} é
)
é è
{ 
var 
schedule 
= 
await 
_unitOfWorks )
.) *$
WaiterScheduleRepository* B
.B C
GetAllAsyncC N
(N O
sO P
=>Q S
sT U
.U V
ShiftV [
,[ \
s] ^
=>_ a
sb c
.c d
Employeed l
)l m
;m n
var 
filterEntities 
= 
new  
WaiterSchedule! /
{ 	
Id 
= 
request 
. 
Id 
. 
HasValue $
?% &
request' .
.. /
Id/ 1
.1 2
Value2 7
:8 9
Guid: >
.> ?
Empty? D
,D E

EmployeeId 
= 
request  
.  !

EmployeeId! +
.+ ,
HasValue, 4
?5 6
request7 >
.> ?

EmployeeId? I
.I J
ValueJ O
:P Q
GuidR V
.V W
EmptyW \
,\ ]
ShiftId 
= 
request 
. 
ShiftId %
.% &
HasValue& .
?/ 0
request1 8
.8 9
ShiftId9 @
.@ A
ValueA F
:G H
GuidI M
.M N
EmptyN S
,S T
} 	
;	 

var 
filterTable 
= 
schedule "
." #
AsQueryable# .
(. /
)/ 0
.0 1
CustomFilterV11 ?
(? @
filterEntities@ N
)N O
;O P
var 
mappedSchedule 
= 
filterTable (
.( )
Select) /
(/ 0
s0 1
=>2 4
new5 8'
GetEmployeeScheduleResponse9 T
(T U
sU V
.V W
IdW Y
,Y Z
new[ ^
EmployeeDto_ j
(j k
sk l
.l m

EmployeeIdm w
,w x
sy z
.z {
Employee	{ É
.
É Ñ
EmployeeCode
Ñ ê
)
ê ë
,
ë í
new
ì ñ
ShiftDto
ó ü
(
ü †
s
† °
.
° ¢
ShiftId
¢ ©
,
© ™
s
´ ¨
.
¨ ≠
Shift
≠ ≤
.
≤ ≥
	ShiftName
≥ º
)
º Ω
,
Ω æ
s
ø ¿
.
¿ ¡
DateTime
¡ …
)
…  
)
  À
.
À Ã
ToList
Ã “
(
“ ”
)
” ‘
;
‘ ’
var   
(   
page   
,   
pageSize   
,   
sortType   %
,  % &
	sortField  ' 0
)  0 1
=  2 3
PaginationUtils  4 C
.  C D)
GetPaginationAndSortingValues  D a
(  a b
request  b i
.  i j
PagingRequest  j w
)  w x
;  x y
var"" 
sortedResults"" 
="" 
PaginationHelper"" ,
<"", -'
GetEmployeeScheduleResponse""- H
>""H I
.""I J
Sorting""J Q
(""Q R
sortType""R Z
,""Z [
mappedSchedule""\ j
,""j k
	sortField""l u
)""u v
;""v w
var## 
result## 
=## 
PaginationHelper## %
<##% &'
GetEmployeeScheduleResponse##& A
>##A B
.##B C
Paging##C I
(##I J
sortedResults##J W
,##W X
page##Y ]
,##] ^
pageSize##_ g
)##g h
;##h i
return$$ 
result$$ 
;$$ 
}%% 
}&& ÿ1
ëC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Schedules\Queries\GetDailySchedules\GetDailySchedulesQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
	Schedules# ,
., -
Queries- 4
.4 5
GetDailySchedules5 F
;F G
public 
sealed 
record #
GetDailyScheduleCommand ,
(, -
PagingRequest- :
?: ;
PagingRequest< I
,I J
GuidK O
?O P
ShiftIdQ X
,X Y
GuidZ ^
?^ _
RestaurantId` l
)l m
:n o
IRequestp x
<x y
PagedResult	y Ñ
<
Ñ Ö&
GetDailyScheduleResponse
Ö ù
>
ù û
>
û ü
;
ü †
public 
sealed 
record $
GetDailyScheduleResponse -
(- .
Guid. 2
Id3 5
,5 6
EmployeeDto7 B
EmployeeC K
,K L
ShiftDtoM U
ShiftV [
)[ \
;\ ]
public 
class "
GetDailySchedulesQuery #
(# $
IUnitOfWorks$ 0
unitOfWorks1 <
)< =
:> ?
IRequestHandler@ O
<O P#
GetDailyScheduleCommandP g
,g h
PagedResulti t
<t u%
GetDailyScheduleResponse	u ç
>
ç é
>
é è
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
PagedResult !
<! "$
GetDailyScheduleResponse" :
>: ;
>; <
Handle= C
(C D#
GetDailyScheduleCommandD [
request\ c
,c d
CancellationTokene v
cancellationToken	w à
)
à â
{ 
DateOnly 
today 
= 
DateOnly !
.! "
FromDateTime" .
(. /
DateTime/ 7
.7 8
Today8 =
)= >
;> ?
var 
	schedules 
= 
await 
_unitOfWorks *
.* +$
WaiterScheduleRepository+ C
.C D
GetAllAsyncD O
(O P
xP Q
=>R T
xU V
.V W
EmployeeW _
,_ `
xa b
=>c e
xf g
.g h
Shifth m
)m n
;n o
var 
filterEntity 
= 
new 
WaiterSchedule -
{ 	
Id 
= 
request 
. 
ShiftId  
.  !
HasValue! )
?* +
request, 3
.3 4
ShiftId4 ;
.; <
Value< A
:B C
GuidD H
.H I
EmptyI N
,N O
} 	
;	 

var 
filteredSchedules 
= 
	schedules  )
.) *
AsQueryable* 5
(5 6
)6 7
.7 8
CustomFilterV18 F
(F G
filterEntityG S
)S T
.T U
WhereU Z
(Z [
	schedules[ d
=>e g
	schedulesh q
.q r
DateTimer z
=={ }
today	~ É
)
É Ñ
;
Ñ Ö
if 

( 
request 
. 
RestaurantId  
.  !
HasValue! )
)) *
{ 	
filteredSchedules   
=   
filteredSchedules    1
.  1 2
Where  2 7
(  7 8
schedule  8 @
=>  A C
schedule  D L
.  L M
Employee  M U
.  U V
RestaurantId  V b
==  c e
request  f m
.  m n
RestaurantId  n z
.  z {
Value	  { Ä
)
  Ä Å
;
  Å Ç
}!! 	
var## 
mappedSchedules## 
=## 
filteredSchedules## /
.##/ 0
Select##0 6
(##6 7
schedule##7 ?
=>##@ B
new##C F$
GetDailyScheduleResponse##G _
(##_ `
schedule$$ 
.$$  
Id$$  "
,$$" #
new%%" %
EmployeeDto%%& 1
(%%1 2
schedule%%2 :
.%%: ;

EmployeeId%%; E
,%%E F
schedule%%G O
.%%O P
Employee%%P X
.%%X Y
EmployeeCode%%Y e
)%%e f
,%%f g
new&&- 0
ShiftDto&&1 9
(&&9 :
schedule&&: B
.&&B C
ShiftId&&C J
,&&J K
schedule&&L T
.&&T U
Shift&&U Z
.&&Z [
	ShiftName&&[ d
)&&d e
)''4 5
)''5 6
.''6 7
ToList''7 =
(''= >
)''> ?
;''? @
var)) 
()) 
page)) 
,)) 
pageSize)) 
,)) 
sortType)) %
,))% &
	sortField))' 0
)))0 1
=))2 3
PaginationUtils))4 C
.))C D)
GetPaginationAndSortingValues))D a
())a b
request))b i
.))i j
PagingRequest))j w
)))w x
;))x y
var++ 
sortedResults++ 
=++ 
PaginationHelper++ ,
<++, -$
GetDailyScheduleResponse++- E
>++E F
.++F G
Sorting++G N
(++N O
sortType++O W
,++W X
mappedSchedules++Y h
,++h i
	sortField++j s
)++s t
;++t u
var,, 
result,, 
=,, 
PaginationHelper,, %
<,,% &$
GetDailyScheduleResponse,,& >
>,,> ?
.,,? @
Paging,,@ F
(,,F G
sortedResults,,G T
,,,T U
page,,V Z
,,,Z [
pageSize,,\ d
),,d e
;,,e f
return.. 
result.. 
;.. 
}// 
}00 π
äC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Schedules\Commands\Delete\UnregisterScheduleHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" #
	Schedules		# ,
.		, -
Commands		- 5
.		5 6
Delete		6 <
;		< =
public

 
record

 %
UnregisterScheduleCommand

 '
(

' (
Guid

( ,

EmployeeId

- 7
,

7 8
Guid

9 =

ScheduleId

> H
)

H I
:

J K
IRequest

L T
<

T U
bool

U Y
>

Y Z
;

Z [
public 
class %
UnregisterScheduleHandler &
(& '
IUnitOfWorks' 3
unitOfWorks4 ?
)? @
:A B
IRequestHandlerC R
<R S%
UnregisterScheduleCommandS l
,l m
booln r
>r s
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
bool 
> 
Handle "
(" #%
UnregisterScheduleCommand# <
request= D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
{ 
var 
schedule 
= 
await 
_unitOfWorks )
.) *$
WaiterScheduleRepository* B
.B C
GetByIdAsyncC O
(O P
requestP W
.W X

ScheduleIdX b
)b c
;c d
if 

( 
schedule 
. 

EmployeeId 
!=  "
request# *
.* +

EmployeeId+ 5
)5 6
{ 	
throw 
new 
	Exception 
(  
$str  S
)S T
;T U
} 	
_unitOfWorks 
. $
WaiterScheduleRepository -
.- .
Remove. 4
(4 5
schedule5 =
)= >
;> ?
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
true 
; 
} 
} ã
àC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Schedules\Commands\Create\RegisterScheduleHandler.cs
	namespace

 	
FOV


 
.

 
Application

 
.

 
Features

 "
.

" #
	Schedules

# ,
.

, -
Commands

- 5
.

5 6
Create

6 <
;

< =
public 
record #
RegisterScheduleCommand %
(% &

Dictionary 
< 
DateOnly 
, 
List 
< 
Guid "
>" #
># $
	DateShift% .
,. /
Guid 

EmployeeId	 
) 
: 
IRequest 
< 
List 
< 
Guid 
> 
> 
; 
public 
class #
RegisterScheduleHandler $
($ %
IUnitOfWorks% 1
unitOfWorks2 =
)= >
:? @
IRequestHandlerA P
<P Q#
RegisterScheduleCommandQ h
,h i
Listj n
<n o
Guido s
>s t
>t u
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
List 
< 
Guid 
>  
>  !
Handle" (
(( )#
RegisterScheduleCommand) @
requestA H
,H I
CancellationTokenJ [
cancellationToken\ m
)m n
{ 
List 
< 
Guid 
> 
scheduleIds 
=  
new! $
($ %
)% &
;& '
foreach 
( 
var 
entry 
in 
request %
.% &
	DateShift& /
)/ 0
{ 	
var 
date 
= 
entry 
. 
Key  
;  !
var 
shiftIds 
= 
entry  
.  !
Value! &
;& '
foreach 
( 
var 
shiftId  
in! #
shiftIds$ ,
), -
{ 
var 
schedule 
= 
new "
WaiterSchedule# 1
(1 2
date2 6
,6 7
shiftId8 ?
,? @
requestA H
.H I

EmployeeIdI S
)S T
;T U
await 
_unitOfWorks "
." #$
WaiterScheduleRepository# ;
.; <
AddAsync< D
(D E
scheduleE M
)M N
;N O
scheduleIds 
. 
Add 
(  
schedule  (
.( )
Id) +
)+ ,
;, -
} 
}   	
await"" 
_unitOfWorks"" 
."" 
SaveChangeAsync"" *
(""* +
)""+ ,
;"", -
return## 
scheduleIds## 
;## 
}$$ 
}%% —=
ÅC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Restaurants\Queries\Get\GetRestaurantQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Restaurants# .
.. /
Queries/ 6
.6 7
Get7 :
;: ;
public		 
record		  
GetRestaurantCommand		 "
(		" #
PagingRequest		# 0
?		0 1
PagingRequest		2 ?
,		? @
Guid		A E
?		E F
RestaurantId		G S
,		S T
string		U [
?		[ \
RestaurantName		] k
,		k l
string		m s
?		s t
Address		u |
,		| }
string			~ Ñ
?
		Ñ Ö
RestaurantPhone
		Ü ï
,
		ï ñ
string
		ó ù
?
		ù û
RestaurantCode
		ü ≠
,
		≠ Æ
Status
		Ø µ
?
		µ ∂
RestaurantStatus
		∑ «
)
		« »
:
		…  
IRequest
		À ”
<
		” ‘
PagedResult
		‘ ﬂ
<
		ﬂ ‡#
GetRestaurantResponse
		‡ ı
>
		ı ˆ
>
		ˆ ˜
;
		˜ ¯
public

 
record

 !
GetRestaurantResponse

 #
(

# $
Guid

$ (
Id

) +
,

+ ,
string

- 3
RestaurantName

4 B
,

B C
string

D J
Address

K R
,

R S
string

T Z
RestaurantPhone

[ j
,

j k
string

l r
RestaurantCode	

s Å
,


Å Ç
Status


É â
RestaurantStatus


ä ö
,


ö õ
DateTimeOffset


ú ™
Created


´ ≤
)


≤ ≥
;


≥ ¥
public 
class 
GetRestaurantQuery 
(  
IUnitOfWorks  ,
unitOfWorks- 8
)8 9
:: ;
IRequestHandler< K
<K L 
GetRestaurantCommandL `
,` a
PagedResultb m
<m n"
GetRestaurantResponse	n É
>
É Ñ
>
Ñ Ö
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
PagedResult !
<! "!
GetRestaurantResponse" 7
>7 8
>8 9
Handle: @
(@ A 
GetRestaurantCommandA U
requestV ]
,] ^
CancellationToken_ p
cancellationToken	q Ç
)
Ç É
{ 
var 
restaurants 
= 
await 
_unitOfWorks  ,
., - 
RestaurantRepository- A
.A B
GetAllAsyncB M
(M N
)N O
;O P
var 
filterEntity 
= 
new 

Restaurant )
{ 	
Id 
= 
request 
. 
RestaurantId %
.% &
HasValue& .
?/ 0
request1 8
.8 9
RestaurantId9 E
.E F
ValueF K
:L M
GuidN R
.R S
EmptyS X
,X Y
RestaurantName 
= 
string #
.# $
IsNullOrEmpty$ 1
(1 2
request2 9
.9 :
RestaurantName: H
)H I
?J K
stringL R
.R S
EmptyS X
:Y Z
request[ b
.b c
RestaurantNamec q
,q r
Address 
= 
string 
. 
IsNullOrEmpty *
(* +
request+ 2
.2 3
Address3 :
): ;
?< =
string> D
.D E
EmptyE J
:K L
requestM T
.T U
AddressU \
,\ ]
RestaurantPhone 
= 
string $
.$ %
IsNullOrEmpty% 2
(2 3
request3 :
.: ;
RestaurantPhone; J
)J K
?L M
stringN T
.T U
EmptyU Z
:[ \
request] d
.d e
RestaurantPhonee t
,t u
RestataurantCode 
= 
string %
.% &
IsNullOrEmpty& 3
(3 4
request4 ;
.; <
RestaurantCode< J
)J K
?L M
stringN T
.T U
EmptyU Z
:[ \
request] d
.d e
RestaurantCodee s
,s t
} 	
;	 

if 

( 
request 
. 
RestaurantStatus $
!=% '
null( ,
), -
{ 	
filterEntity 
. 
Status 
=  !
request" )
.) *
RestaurantStatus* :
.: ;
Value; @
;@ A
} 	
var 
filteredRestaurants 
=  !
restaurants" -
.- .
AsQueryable. 9
(9 :
): ;
.; <
CustomFilterV1< J
(J K
filterEntityK W
)W X
;X Y
var   
mappedRestaurants   
=   
filteredRestaurants    3
.  3 4
Select  4 :
(  : ;

restaurant  ; E
=>  F H
new  I L!
GetRestaurantResponse  M b
(  b c

restaurant!! 
.!! 
Id!! 
,!! 

restaurant"" 
."" 
RestaurantName"" %
??""& (
string"") /
.""/ 0
Empty""0 5
,""5 6

restaurant## 
.## 
Address## 
??## !
string##" (
.##( )
Empty##) .
,##. /

restaurant$$ 
.$$ 
RestaurantPhone$$ &
??$$' )
string$$* 0
.$$0 1
Empty$$1 6
,$$6 7

restaurant%% 
.%% 
RestataurantCode%% '
??%%( *
string%%+ 1
.%%1 2
Empty%%2 7
,%%7 8

restaurant&& 
.&& 
Status&& 
,&& 

restaurant'' 
.'' 
Created'' 
)(( 	
)((	 

.((
 
ToList(( 
((( 
)(( 
;(( 
var** 
(** 
page** 
,** 
pageSize** 
,** 
sortType** %
,**% &
	sortField**' 0
)**0 1
=**2 3
PaginationUtils**4 C
.**C D)
GetPaginationAndSortingValues**D a
(**a b
request**b i
.**i j
PagingRequest**j w
)**w x
;**x y
	sortField++ 
=++ 
$str++ $
;++$ %
pageSize,, 
=,, 
$num,, 
;,, 
var-- 
sortedResults-- 
=-- 
PaginationHelper-- ,
<--, -!
GetRestaurantResponse--- B
>--B C
.--C D
Sorting--D K
(--K L
sortType--L T
,--T U
mappedRestaurants--V g
,--g h
	sortField--i r
)--r s
;--s t
var.. 
result.. 
=.. 
PaginationHelper.. %
<..% &!
GetRestaurantResponse..& ;
>..; <
...< =
Paging..= C
(..C D
sortedResults..D Q
,..Q R
page..S W
,..W X
pageSize..Y a
)..a b
;..b c
return00 
result00 
;00 
}11 
}33 – 
äC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Restaurants\Queries\Detail\GetDetailRestaurantQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Restaurants# .
.. /
Queries/ 6
.6 7
Detail7 =
;= >
public 
sealed 
record &
GetRestaurantDetailCommand /
(/ 0
Guid0 4
Id5 7
)7 8
:9 :
IRequest; C
<C D'
GetRestaurantDetailResponseD _
>_ `
;` a
public 
sealed 
record '
GetRestaurantDetailResponse 0
(0 1
Guid1 5
Id6 8
,8 9
string: @
RestaurantNameA O
,O P
stringQ W
AddressX _
,_ `
stringa g
RestaurantPhoneh w
,w x
Statusy 
Status
Ä Ü
,
Ü á

ProductDto
à í
?
í ì
Product
î õ
)
õ ú
;
ú ù
public 
sealed 
record 

ProductDto 
(  
Guid  $
	ProductId% .
,. /
string0 6
ProductName7 B
,B C
stringD J
ProductDescriptionK ]
,] ^
ProductType_ j
ProductTypek v
,v w
decimalx 
Price
Ä Ö
)
Ö Ü
;
Ü á
public 
class $
GetDetailRestaurantQuery %
(% &
IUnitOfWorks& 2
unitOfWorks3 >
)> ?
:@ A
IRequestHandlerB Q
<Q R&
GetRestaurantDetailCommandR l
,l m(
GetRestaurantDetailResponse	n â
>
â ä
{ 
private 
IUnitOfWorks 
_unitOfWorks %
=& '
unitOfWorks( 3
;3 4
public 

async 
Task 
< '
GetRestaurantDetailResponse 1
>1 2
Handle3 9
(9 :&
GetRestaurantDetailCommand: T
requestU \
,\ ]
CancellationToken^ o
cancellationToken	p Å
)
Å Ç
{ 
var 

restaurant 
= 
await 
_unitOfWorks +
.+ , 
RestaurantRepository, @
.@ A
GetByIdAsyncA M
(M N
requestN U
.U V
IdV X
,X Y
rZ [
=>\ ^
r_ `
.` a
Productsa i
)i j
;j k
var 
product 
= 

restaurant  
.  !
Products! )
.) *
FirstOrDefault* 8
(8 9
)9 :
;: ;
var 
response 
= 
new '
GetRestaurantDetailResponse 6
(6 7

restaurant 
. 
Id 
, 

restaurant 
. 
RestaurantName %
,% &

restaurant 
. 
Address 
, 

restaurant   
.   
RestaurantPhone   &
,  & '

restaurant!! 
.!! 
Status!! 
,!! 
product"" 
!="" 
null"" 
?## 
new## 

ProductDto##  
(##  !
product$$ 
.$$ 
Id$$ 
,$$ 
product%% 
.%% 
ProductName%% '
,%%' (
product&& 
.&& 
ProductDescription&& .
,&&. /
product'' 
.'' 
ProductType'' '
,''' (
product(( 
.(( 
Price(( !
??((" $
$num((% &
))) 
:** 
null** 
)++ 	
;++	 

return-- 
response-- 
;-- 
}.. 
}// à>
âC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Restaurants\Commons\Update\UpdateRestaurantHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Restaurants# .
.. /
Commons/ 6
.6 7
Update7 =
;= >
public 
record #
UpdateRestaurantCommand %
(% &
string& ,
RestaurantName- ;
,; <
string= C
?C D
AddressE L
,L M
stringN T
?T U
RestaurantPhoneV e
)e f
:g h
IRequesti q
<q r
Guidr v
>v w
{ 
public 

Guid 
Id 
; 
}		 
public

 
class

 #
UpdateRestaurantHandler

 $
(

$ %
IUnitOfWorks

% 1
unitOfWorks

2 =
)

= >
:

? @
IRequestHandler

A P
<

P Q#
UpdateRestaurantCommand

Q h
,

h i
Guid

j n
>

n o
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" ##
UpdateRestaurantCommand# :
request; B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 
var 
fieldErrors 
= 
new 
List "
<" #

FieldError# -
>- .
(. /
)/ 0
;0 1
var 

restaurant 
= 
await 
_unitOfWorks +
.+ , 
RestaurantRepository, @
.@ A
GetByIdAsyncA M
(M N
requestN U
.U V
IdV X
)X Y
;Y Z
if 

( 

restaurant 
== 
null 
) 
{ 	
throw 
new 
AppException "
(" #
$str# ;
); <
;< =
} 	
if 

( 
! 
string 
. 
IsNullOrEmpty !
(! "
request" )
.) *
RestaurantName* 8
)8 9
&&: <

restaurant= G
.G H
RestaurantNameH V
!=W Y
requestZ a
.a b
RestaurantNameb p
)p q
{ 	
bool 
existRestaurantName $
=% &
await' ,
_unitOfWorks- 9
.9 : 
RestaurantRepository: N
.N O
AnyAsyncO W
(W X
rX Y
=>Z \
r 
. 
RestaurantName +
==, .
request/ 6
.6 7
RestaurantName7 E
)E F
;F G
if 
( 
existRestaurantName #
)# $
{ 
fieldErrors 
. 
Add 
(  
new  #

FieldError$ .
{/ 0
Field1 6
=7 8
$str9 I
,I J
MessageK R
=S T
$strU o
}p q
)q r
;r s
} 
}   	
if"" 

("" 
!"" 
string"" 
."" 
IsNullOrEmpty"" !
(""! "
request""" )
."") *
Address""* 1
)""1 2
&&""3 5

restaurant""6 @
.""@ A
Address""A H
!=""I K
request""L S
.""S T
Address""T [
)""[ \
{## 	
bool$$ 
existAddress$$ 
=$$ 
await$$  %
_unitOfWorks$$& 2
.$$2 3 
RestaurantRepository$$3 G
.$$G H
AnyAsync$$H P
($$P Q
r$$Q R
=>$$S U
r%% 
.%% 
Address%% 
==%% 
request%% $
.%%$ %
Address%%% ,
)%%, -
;%%- .
if'' 
('' 
existAddress'' 
)'' 
{(( 
fieldErrors)) 
.)) 
Add)) 
())  
new))  #

FieldError))$ .
{))/ 0
Field))1 6
=))7 8
$str))9 B
,))B C
Message))D K
=))L M
$str))N l
}))m n
)))n o
;))o p
}** 
}++ 	
if-- 

(-- 
!-- 
string-- 
.-- 
IsNullOrEmpty-- !
(--! "
request--" )
.--) *
RestaurantPhone--* 9
)--9 :
&&--; =

restaurant--> H
.--H I
RestaurantPhone--I X
!=--Y [
request--\ c
.--c d
RestaurantPhone--d s
)--s t
{.. 	
bool// 

existPhone// 
=// 
await// #
_unitOfWorks//$ 0
.//0 1 
RestaurantRepository//1 E
.//E F
AnyAsync//F N
(//N O
r//O P
=>//Q S
r00 
.00 
RestaurantPhone00 !
==00" $
request00% ,
.00, -
RestaurantPhone00- <
)00< =
;00= >
if22 
(22 

existPhone22 
)22 
{33 
fieldErrors44 
.44 
Add44 
(44  
new44  #

FieldError44$ .
{44/ 0
Field441 6
=447 8
$str449 J
,44J K
Message44L S
=44T U
$str44V z
}44{ |
)44| }
;44} ~
}55 
}66 	
if88 

(88 
fieldErrors88 
.88 
Any88 
(88 
)88 
)88 
{99 	
throw:: 
new:: 
AppException:: "
(::" #
$str::# >
,::> ?
fieldErrors::@ K
)::K L
;::L M
};; 	
if== 

(== 
!== 
string== 
.== 
IsNullOrEmpty== !
(==! "
request==" )
.==) *
RestaurantName==* 8
)==8 9
)==9 :
{>> 	

restaurant?? 
.?? 
RestaurantName?? %
=??& '
request??( /
.??/ 0
RestaurantName??0 >
;??> ?
}@@ 	
ifBB 

(BB 
!BB 
stringBB 
.BB 
IsNullOrEmptyBB !
(BB! "
requestBB" )
.BB) *
AddressBB* 1
)BB1 2
)BB2 3
{CC 	

restaurantDD 
.DD 
AddressDD 
=DD  
requestDD! (
.DD( )
AddressDD) 0
;DD0 1
}EE 	
ifGG 

(GG 
!GG 
stringGG 
.GG 
IsNullOrEmptyGG !
(GG! "
requestGG" )
.GG) *
RestaurantPhoneGG* 9
)GG9 :
)GG: ;
{HH 	

restaurantII 
.II 
RestaurantPhoneII &
=II' (
requestII) 0
.II0 1
RestaurantPhoneII1 @
;II@ A
}JJ 	
_unitOfWorksMM 
.MM  
RestaurantRepositoryMM )
.MM) *
UpdateMM* 0
(MM0 1

restaurantMM1 ;
)MM; <
;MM< =
awaitNN 
_unitOfWorksNN 
.NN 
SaveChangeAsyncNN *
(NN* +
)NN+ ,
;NN, -
returnPP 

restaurantPP 
.PP 
IdPP 
;PP 
}QQ 
}RR ‹
çC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Restaurants\Commons\Inactive\InactiveRestaurantHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" #
Restaurants		# .
.		. /
Commons		/ 6
.		6 7
Inactive		7 ?
;		? @
public

 
sealed

 
record

 %
InactiveRestaurantCommand

 .
(

. /
Guid

/ 3
Id

4 6
)

6 7
:

8 9
IRequest

: B
<

B C
Guid

C G
>

G H
;

H I
public 
class %
InactiveRestaurantHandler &
(& '
IUnitOfWorks' 3
unitOfWorks4 ?
)? @
:A B
IRequestHandlerC R
<R S%
InactiveRestaurantCommandS l
,l m
Guidn r
>r s
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #%
InactiveRestaurantCommand# <
request= D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
{ 
var 

restaurant 
= 
await 
_unitOfWorks +
.+ , 
RestaurantRepository, @
.@ A
GetByIdAsyncA M
(M N
requestN U
.U V
IdV X
)X Y
??Z \
throw] b
newc f
	Exceptiong p
(p q
$str	q â
)
â ä
;
ä ã

restaurant 
. 
UpdateState 
( 
false $
)$ %
;% &
_unitOfWorks 
.  
RestaurantRepository )
.) *
Update* 0
(0 1

restaurant1 ;
); <
;< =
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 

restaurant 
. 
Id 
; 
} 
} âv
âC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Restaurants\Commons\Create\CreateRestaurantHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Restaurants# .
.. /
Commons/ 6
.6 7
Create7 =
;= >
public 
sealed 
record #
CreateRestaurantCommand ,
:- .
IRequest/ 7
<7 8
Guid8 <
>< =
{ 
public 

required 
string 
RestaurantName )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 

required 
string 
Address "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 

required 
string 
RestaurantPhone *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 

ICollection 
< 
Guid 
> 
Products %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
[6 7
]7 8
;8 9
} 
internal 
class	 #
CreateRestaurantHandler &
(& '
IUnitOfWorks' 3
unitOfWorks4 ?
)? @
:A B
IRequestHandlerC R
<R S#
CreateRestaurantCommandS j
,j k
Guidl p
>p q
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" ##
CreateRestaurantCommand# :
request; B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 
var 
fieldErrors 
= 
new 
List "
<" #

FieldError# -
>- .
(. /
)/ 0
;0 1
bool!! 
existRestaurantName!!  
=!!! "
await!!# (
_unitOfWorks!!) 5
.!!5 6 
RestaurantRepository!!6 J
.!!J K
AnyAsync!!K S
(!!S T
r!!T U
=>!!V X
r"" 
."" 
RestaurantName"" 
=="" 
request""  '
.""' (
RestaurantName""( 6
)""6 7
;""7 8
if$$ 

($$ 
existRestaurantName$$ 
)$$  
{%% 	
fieldErrors&& 
.&& 
Add&& 
(&& 
new&& 

FieldError&&  *
{&&+ ,
Field&&- 2
=&&3 4
$str&&5 E
,&&E F
Message&&G N
=&&O P
$str&&Q k
}&&l m
)&&m n
;&&n o
}'' 	
bool)) 
existAddress)) 
=)) 
await)) !
_unitOfWorks))" .
.)). / 
RestaurantRepository))/ C
.))C D
AnyAsync))D L
())L M
r))M N
=>))O Q
r** 
.** 
Address** 
==** 
request**  
.**  !
Address**! (
)**( )
;**) *
if,, 

(,, 
existAddress,, 
),, 
{-- 	
fieldErrors.. 
... 
Add.. 
(.. 
new.. 

FieldError..  *
{..+ ,
Field..- 2
=..3 4
$str..5 >
,..> ?
Message..@ G
=..H I
$str..J h
}..i j
)..j k
;..k l
}// 	
bool11 

existPhone11 
=11 
await11 
_unitOfWorks11  ,
.11, - 
RestaurantRepository11- A
.11A B
AnyAsync11B J
(11J K
r11K L
=>11M O
r22 
.22 
RestaurantPhone22 
==22  
request22! (
.22( )
RestaurantPhone22) 8
)228 9
;229 :
if44 

(44 

existPhone44 
)44 
{55 	
fieldErrors66 
.66 
Add66 
(66 
new66 

FieldError66  *
{66+ ,
Field66- 2
=663 4
$str665 F
,66F G
Message66H O
=66P Q
$str66R v
}66w x
)66x y
;66y z
}77 	
if99 

(99 
fieldErrors99 
.99 
Any99 
(99 
)99 
)99 
{:: 	
throw;; 
new;; 
AppException;; "
(;;" #
$str;;# =
,;;= >
fieldErrors;;? J
);;J K
;;;K L
}<< 	

Restaurant?? 

restaurant?? 
=?? 
new??  #
(??# $
request??$ +
.??+ ,
RestaurantName??, :
,??: ;
request??< C
.??C D
Address??D K
,??K L
request??M T
.??T U
RestaurantPhone??U d
,??d e
await??f k
GeneratedCode??l y
(??y z
)??z {
)??{ |
;??| }
await@@ 
_unitOfWorks@@ 
.@@  
RestaurantRepository@@ /
.@@/ 0
AddAsync@@0 8
(@@8 9

restaurant@@9 C
)@@C D
;@@D E
awaitAA 
AddNewProdutAA 
(AA 
requestAA "
.AA" #
ProductsAA# +
,AA+ ,

restaurantAA- 7
.AA7 8
IdAA8 :
)AA: ;
;AA; <
awaitBB 
_unitOfWorksBB 
.BB 
SaveChangeAsyncBB *
(BB* +
)BB+ ,
;BB, -
returnDD 

restaurantDD 
.DD 
IdDD 
;DD 
}EE 
privateXX 
asyncXX 
TaskXX 
<XX 
stringXX 
>XX 
GeneratedCodeXX ,
(XX, -
)XX- .
{YY 
staticZZ 
stringZZ 
GenerateNewCodeZZ %
(ZZ% &
intZZ& )
numberZZ* 0
)ZZ0 1
{[[ 	
return\\ 
$"\\ 
$str\\ 
{\\ 
number\\ 
:\\  
$str\\  "
}\\" #
"\\# $
;\\$ %
}]] 	
string__ 
newCode__ 
;__ 
int`` 

codeNumber`` 
=`` 
$num`` 
;`` 
dobb 

{cc 	
newCodedd 
=dd 
GenerateNewCodedd %
(dd% &

codeNumberdd& 0
)dd0 1
;dd1 2

codeNumberee 
++ee 
;ee 
}ff 	
whileff
 
(ff 
awaitff 
_unitOfWorksff #
.ff# $ 
RestaurantRepositoryff$ 8
.ff8 9
AnyAsyncff9 A
(ffA B
rffB C
=>ffD F
rffG H
.ffH I
RestataurantCodeffI Y
==ffZ \
newCodeff] d
)ffd e
)ffe f
;fff g
returnhh 
newCodehh 
;hh 
}ii 
privatell 
asyncll 
Taskll 
AddNewProdutll #
(ll# $
ICollectionll$ /
<ll/ 0
Guidll0 4
>ll4 5
productsll6 >
,ll> ?
Guidll@ D
restaurantIdllE Q
)llQ R
{mm 
foreachnn 
(nn 
varnn 
productnn 
innn 
productsnn  (
)nn( )
{oo 	
ProductGeneralpp 
productGeneralpp )
=pp* +
awaitpp, 1
_unitOfWorkspp2 >
.pp> ?$
ProductGeneralRepositorypp? W
.ppW X
GetByIdAsyncppX d
(ppd e
productppe l
,ppl m
xppn o
=>ppp r
xpps t
.ppt u
Ingredients	ppu Ä
)
ppÄ Å
??
ppÇ Ñ
throw
ppÖ ä
new
ppã é
	Exception
ppè ò
(
ppò ô
)
ppô ö
;
ppö õ
varqq 
ingredientGeneralsqq "
=qq# $
awaitqq% *
_unitOfWorksqq+ 7
.qq7 8'
IngredientGeneralRepositoryqq8 S
.qqS T

WhereAsyncqqT ^
(qq^ _
xqq_ `
=>qqa c
xqqd e
.qqe f%
ProductIngredientGeneralsqqf 
.	qq Ä
Any
qqÄ É
(
qqÉ Ñ
pg
qqÑ Ü
=>
qqá â
pg
qqä å
.
qqå ç
ProductGeneralId
qqç ù
==
qqû †
productGeneral
qq° Ø
.
qqØ ∞
Id
qq∞ ≤
)
qq≤ ≥
)
qq≥ ¥
;
qq¥ µ
Productrr 
productAddingrr !
=rr" #
newrr$ '
(rr' (
productGeneralrr( 6
.rr6 7
ProductNamerr7 B
,rrB C
restaurantIdrrD P
,rrP Q
productGeneralrrR `
.rr` a

CategoryIdrra k
,rrk l
productGeneralrrm {
.rr{ |
Idrr| ~
)rr~ 
;	rr Ä
awaitss 
_unitOfWorksss 
.ss 
ProductRepositoryss 0
.ss0 1
AddAsyncss1 9
(ss9 :
productAddingss: G
)ssG H
;ssH I
awaittt  
ProductIngredientAddtt &
(tt& '
ingredientGeneralstt' 9
.tt9 :
Selecttt: @
(tt@ A
xttA B
=>ttC E
xttF G
.ttG H
IngredientNamettH V
)ttV W
.ttW X
ToListttX ^
(tt^ _
)tt_ `
,tt` a
restaurantIdttb n
,ttn o
productAddingttp }
.tt} ~
Id	tt~ Ä
)
ttÄ Å
;
ttÅ Ç
}uu 	
}vv 
privatexx 
asyncxx 
Taskxx  
ProductIngredientAddxx +
(xx+ ,
ICollectionxx, 7
<xx7 8
stringxx8 >
>xx> ?
ingredientNamesxx@ O
,xxO P
GuidxxQ U
restaurantIdxxV b
,xxb c
Guidxxd h
	productIdxxi r
)xxr s
{yy 
foreachzz 
(zz 
varzz 
itemzz 
inzz 
ingredientNameszz ,
)zz, -
{{{ 	

Ingredient|| 
?|| 

ingredient|| "
=||# $
_unitOfWorks||% 1
.||1 2 
IngredientRepository||2 F
.||F G
FirstOrDefaultAsync||G Z
(||Z [
x||[ \
=>||] _
x||` a
.||a b
IngredientName||b p
==||q s
item||t x
&&||y {
x||| }
.||} ~
RestaurantId	||~ ä
==
||ã ç
restaurantId
||é ö
)
||ö õ
.
||õ ú
Result
||ú ¢
;
||¢ £
if}} 
(}} 

ingredient}} 
==}} 
null}} "
)}}" #
{~~ 
IngredientGeneral !
ingredientGeneral" 3
=4 5
await6 ;
_unitOfWorks< H
.H I'
IngredientGeneralRepositoryI d
.d e
FirstOrDefaultAsynce x
(x y
xy z
=>{ }
x~ 
.	 Ä
IngredientName
Ä é
==
è ë
item
í ñ
)
ñ ó
??
ò ö
throw
õ †
new
° §
	Exception
• Æ
(
Æ Ø
)
Ø ∞
;
∞ ±

Ingredient
ÄÄ 
ingredient1
ÄÄ &
=
ÄÄ' (
new
ÄÄ) ,
(
ÄÄ, -
ingredientGeneral
ÄÄ- >
.
ÄÄ> ?
IngredientName
ÄÄ? M
,
ÄÄM N
ingredientGeneral
ÄÄO `
.
ÄÄ` a
IngredientTypeId
ÄÄa q
,
ÄÄq r
restaurantId
ÄÄs 
)ÄÄ Ä
;ÄÄÄ Å
await
ÇÇ 
_unitOfWorks
ÇÇ "
.
ÇÇ" #"
IngredientRepository
ÇÇ# 7
.
ÇÇ7 8
AddAsync
ÇÇ8 @
(
ÇÇ@ A
ingredient1
ÇÇA L
)
ÇÇL M
;
ÇÇM N
await
ÉÉ 
_unitOfWorks
ÉÉ "
.
ÉÉ" #)
ProductIngredientRepository
ÉÉ# >
.
ÉÉ> ?
AddAsync
ÉÉ? G
(
ÉÉG H
new
ÉÉH K
ProductIngredient
ÉÉL ]
(
ÉÉ] ^
	productId
ÉÉ^ g
,
ÉÉg h
ingredient1
ÉÉi t
.
ÉÉt u
Id
ÉÉu w
)
ÉÉw x
)
ÉÉx y
;
ÉÉy z
await
ÑÑ &
AddDefaultIngredientUnit
ÑÑ .
(
ÑÑ. /
ingredient1
ÑÑ/ :
.
ÑÑ: ;
Id
ÑÑ; =
,
ÑÑ= >
ingredientGeneral
ÑÑ? P
.
ÑÑP Q
IngredientMeasure
ÑÑQ b
)
ÑÑb c
;
ÑÑc d
}
ÖÖ 
}
ÜÜ 	
}
ââ 
private
ãã 
async
ãã 
Task
ãã &
AddDefaultIngredientUnit
ãã /
(
ãã/ 0
Guid
ãã0 4
ingredientId
ãã5 A
,
ããA B
IngredientMeasure
ããC T

minMeasure
ããU _
)
ãã_ `
{
åå 
IngredientUnit
éé 
ingredientUnit
éé %
=
éé& '
new
éé( +
(
éé+ ,
MeasureTransfer
éé, ;
.
éé; <
ToSmallUnit
éé< G
(
ééG H

minMeasure
ééH R
)
ééR S
,
ééS T
ingredientId
ééU a
)
ééa b
;
ééb c
await
èè 
_unitOfWorks
èè 
.
èè &
IngredientUnitRepository
èè 3
.
èè3 4
AddAsync
èè4 <
(
èè< =
ingredientUnit
èè= K
)
èèK L
;
èèL M
if
ëë 

(
ëë 

minMeasure
ëë 
==
ëë 
IngredientMeasure
ëë +
.
ëë+ ,
g
ëë, -
||
ëë. 0

minMeasure
ëë1 ;
==
ëë< >
IngredientMeasure
ëë? P
.
ëëP Q
ml
ëëQ S
)
ëëS T
{
íí 	
IngredientUnit
ìì 
ingredientUnit2
ìì *
=
ìì+ ,
new
ìì- 0
(
ìì0 1
MeasureTransfer
ìì1 @
.
ìì@ A
ToLargeUnit
ììA L
(
ììL M

minMeasure
ììM W
)
ììW X
,
ììX Y
ingredientId
ììZ f
,
ììf g
ingredientUnit
ììh v
.
ììv w
Id
ììw y
,
ììy z
$num
ìì{ 
)ìì Ä
;ììÄ Å
await
îî 
_unitOfWorks
îî 
.
îî &
IngredientUnitRepository
îî 7
.
îî7 8
AddAsync
îî8 @
(
îî@ A
ingredientUnit2
îîA P
)
îîP Q
;
îîQ R
}
ïï 	
await
óó 
_unitOfWorks
óó 
.
óó 
SaveChangeAsync
óó *
(
óó* +
)
óó+ ,
;
óó, -
}
ôô 
}õõ Õ
âC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Restaurants\Commons\Active\ActiveRestaurantHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" #
Restaurants		# .
.		. /
Commons		/ 6
.		6 7
Active		7 =
;		= >
public

 
sealed

 
record

 #
ActiveRestaurantCommand

 ,
(

, -
Guid

- 1
Id

2 4
)

4 5
:

6 7
IRequest

8 @
<

@ A
Guid

A E
>

E F
;

F G
public 
class #
ActiveRestaurantHandler $
($ %
IUnitOfWorks% 1
unitOfWorks2 =
)= >
:? @
IRequestHandlerA P
<P Q#
ActiveRestaurantCommandQ h
,h i
Guidj n
>n o
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" ##
ActiveRestaurantCommand# :
request; B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 
var 

restaurant 
= 
await 
_unitOfWorks +
.+ , 
RestaurantRepository, @
.@ A
GetByIdAsyncA M
(M N
requestN U
.U V
IdV X
)X Y
??Z \
throw] b
newc f
	Exceptiong p
(p q
$str	q â
)
â ä
;
ä ã

restaurant 
. 
UpdateState 
( 
true #
)# $
;$ %
_unitOfWorks 
.  
RestaurantRepository )
.) *
Update* 0
(0 1

restaurant1 ;
); <
;< =
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 

restaurant 
. 
Id 
; 
} 
} —"
ÑC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Products\Queries\GetProduct\GetProductHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Products# +
.+ ,
Queries, 3
.3 4

GetProduct4 >
;> ?
public 
sealed 
record 
GetProductCommand &
(& '
string' -
?- .
ProductName/ :
,: ;
string< B
?B C
ProductDescriptionD V
,V W
stringX ^
?^ _
RestaurantId` l
)l m
:n o
IRequestp x
<x y
Listy }
<} ~
GetProductResponse	~ ê
>
ê ë
>
ë í
;
í ì
public 
sealed 
record 
GetProductResponse '
(' (
Guid( ,
	ProductId- 6
,6 7
string8 >
ProductName? J
,J K
stringL R
ProductDescriptionS e
)e f
;f g
internal 
class	 
GetProductHandler  
(  !
IUnitOfWorks! -
unitOfWorks. 9
)9 :
:; <
IRequestHandler= L
<L M
GetProductCommandM ^
,^ _
List` d
<d e
GetProductResponsee w
>w x
>x y
{		 
private

 
readonly

 
IUnitOfWorks

 !
_unitOfWorks

" .
=

/ 0
unitOfWorks

1 <
;

< =
public 

async 
Task 
< 
List 
< 
GetProductResponse -
>- .
>. /
Handle0 6
(6 7
GetProductCommand7 H
requestI P
,P Q
CancellationTokenR c
cancellationTokend u
)u v
{ 
var 
products 
= 
await 
_unitOfWorks )
.) *
ProductRepository* ;
.; <
GetAllAsync< G
(G H
)H I
;I J
var 
filteredProducts 
= 
products '
.' (
Where( -
(- .
x. /
=>0 2
( 	
string	 
. 
IsNullOrEmpty 
( 
request %
.% &
ProductName& 1
)1 2
||3 5
x6 7
.7 8
ProductName8 C
.C D
ContainsD L
(L M
requestM T
.T U
ProductNameU `
,` a
StringComparisonb r
.r s
OrdinalIgnoreCase	s Ñ
)
Ñ Ö
)
Ö Ü
&&
á â
(	 

string
 
. 
IsNullOrEmpty 
( 
request &
.& '
ProductDescription' 9
)9 :
||; =
x> ?
.? @
ProductDescription@ R
.R S
ContainsS [
([ \
request\ c
.c d
ProductDescriptiond v
,v w
StringComparison	x à
.
à â
OrdinalIgnoreCase
â ö
)
ö õ
)
õ ú
&&
ù ü
(	 

Guid
 
. 
TryParse 
( 
request 
.  
RestaurantId  ,
,, -
out. 1
var2 5
restaurantGuid6 D
)D E
==F H
falseI N
||O Q
xR S
.S T
RestaurantIdT `
==a c
restaurantGuidd r
)r s
) 	
.	 

Select
 
( 
x 
=> 
new 
GetProductResponse ,
(, -
x 
. 
Id 
, 
x 
. 
ProductName 
, 
x 
. 
ProductDescription  
)  !
)! "
." #
ToList# )
() *
)* +
;+ ,
return 
filteredProducts 
;  
} 
}  )
~C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Products\Queries\GetMenu\GetMenuHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Products# +
.+ ,
Queries, 3
.3 4
GetMenu4 ;
;; <
public 
sealed 
record 
GetMenuCommand #
(# $
string$ *
?* +
ProductName, 7
,7 8
string9 ?
?? @
ProductDescriptionA S
,S T
stringU [
?[ \
RestaurantId] i
)i j
:k l
IRequestm u
<u v
Listv z
<z {
GetMenuResponse	{ ä
>
ä ã
>
ã å
;
å ç
public 
sealed 
record "
ProductCheckingCommand +
(+ ,
Guid, 0
	ProductId1 :
,: ;
int< ?
Quantity@ H
)H I
;I J
public 
sealed 
record 
ProductCommand #
(# $
Guid$ (
	ProductId) 2
,2 3
string4 :
ProductName; F
,F G
stringH N
ProductDescriptionO a
)a b
;b c
public		 
sealed		 
record		 
ComboCommand		 !
(		! "
Guid		" &
ComboId		' .
,		. /
string		0 6
	ComboName		7 @
,		@ A
string		B H
ComboDescription		I Y
)		Y Z
;		Z [
public

 
sealed

 
record

 
GetMenuResponse

 $
(

$ %
Guid

% )
	ProductId

* 3
,

3 4
string

5 ;
ProductName

< G
,

G H
string

I O
ProductDescription

P b
)

b c
;

c d
public 
class 
GetMenuHandler 
( 
IUnitOfWorks (
unitOfWorks) 4
)4 5
:6 7
IRequestHandler8 G
<G H
GetMenuCommandH V
,V W
ListX \
<\ ]
GetMenuResponse] l
>l m
>m n
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
List 
< 
GetMenuResponse *
>* +
>+ ,
Handle- 3
(3 4
GetMenuCommand4 B
requestC J
,J K
CancellationTokenL ]
cancellationToken^ o
)o p
{ 
var 
products 
= 
await 
_unitOfWorks )
.) *
ProductRepository* ;
.; <
GetAllAsync< G
(G H
)H I
;I J
var 
filteredProducts 
= 
products '
.' (
Where( -
(- .
x. /
=>0 2
( 	
string	 
. 
IsNullOrEmpty 
( 
request %
.% &
ProductName& 1
)1 2
||3 5
x6 7
.7 8
ProductName8 C
.C D
ContainsD L
(L M
requestM T
.T U
ProductNameU `
,` a
StringComparisonb r
.r s
OrdinalIgnoreCase	s Ñ
)
Ñ Ö
)
Ö Ü
&&
á â
(	 

string
 
. 
IsNullOrEmpty 
( 
request &
.& '
ProductDescription' 9
)9 :
||; =
x> ?
.? @
ProductDescription@ R
.R S
ContainsS [
([ \
request\ c
.c d
ProductDescriptiond v
,v w
StringComparison	x à
.
à â
OrdinalIgnoreCase
â ö
)
ö õ
)
õ ú
&&
ù ü
(	 

Guid
 
. 
TryParse 
( 
request 
.  
RestaurantId  ,
,, -
out. 1
var2 5
restaurantGuid6 D
)D E
==F H
falseI N
||O Q
xR S
.S T
RestaurantIdT `
==a c
restaurantGuidd r
)r s
&&t v
x	 

.
 
	IsDeleted 
== 
false 
) 	
.	 

Select
 
( 
x 
=> 
new 
GetMenuResponse )
() *
x 
. 
Id 
, 
x 
. 
ProductName 
, 
x 
. 
ProductDescription  
)  !
)! "
." #
ToList# )
() *
)* +
;+ ,
return 
filteredProducts 
;  
} 
} µ
ÉC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Products\Commons\Update\UpdateProductHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Products# +
.+ ,
Commons, 3
.3 4
Update4 :
;: ;
public 
sealed 
record  
UpdateProductCommand )
() *
string* 0
ProductName1 <
,< =
string> D
ProductDescriptionE W
)W X
:Y Z
IRequest[ c
<c d
Resultd j
>j k
{		 
[

 

JsonIgnore

 
]

 
public 

Guid 
	ProductId 
{ 
get 
;  
set! $
;$ %
}& '
} 
internal 
class	  
UpdateProductHandler #
(# $
IUnitOfWorks$ 0
unitOfWorks1 <
)< =
:> ?
IRequestHandler@ O
<O P 
UpdateProductCommandP d
,d e
Resultf l
>l m
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ % 
UpdateProductCommand% 9
request: A
,A B
CancellationTokenC T
cancellationTokenU f
)f g
{ 
Product 
product 
= 
await 
_unitOfWorks  ,
., -
ProductRepository- >
.> ?
GetByIdAsync? K
(K L
requestL S
.S T
	ProductIdT ]
)] ^
??_ a
throwb g
newh k
	Exceptionl u
(u v
)v w
;w x
product 
. 
Update 
( 
request 
. 
ProductName *
,* +
request, 3
.3 4
ProductDescription4 F
)F G
;G H
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ∆
áC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Products\Commons\Inactive\InactiveProductHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Products# +
.+ ,
Commons, 3
.3 4
Inactive4 <
;< =
public 
sealed 
record "
InactiveProductCommand +
(+ ,
Guid, 0
Id1 3
)3 4
:5 6
IRequest7 ?
<? @
Result@ F
>F G
;G H
internal 
class	 "
InactiveProductHandler %
(% &
IUnitOfWorks& 2
unitOfWorks3 >
)> ?
:@ A
IRequestHandlerB Q
<Q R"
InactiveProductCommandR h
,h i
Resultj p
>p q
{		 
private

 
readonly

 
IUnitOfWorks

 !
_unitOfWorks

" .
=

/ 0
unitOfWorks

1 <
;

< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %"
InactiveProductCommand% ;
request< C
,C D
CancellationTokenE V
cancellationTokenW h
)h i
{ 
Product 
product 
= 
await 
_unitOfWorks  ,
., -
ProductRepository- >
.> ?
GetByIdAsync? K
(K L
requestL S
.S T
IdT V
)V W
??X Z
throw[ `
newa d
	Exceptione n
(n o
)o p
;p q
product 
. 
UpdateState 
( 
true  
)  !
;! "
_unitOfWorks 
. 
ProductRepository &
.& '
Update' -
(- .
product. 5
)5 6
;6 7
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} œ
C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Products\Commons\Add\AddProductValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Products# +
.+ ,
Commons, 3
.3 4
Add4 7
;7 8
public		 
class		 
AddProductValidator		  
:		! "
AbstractValidator		# 4
<		4 5
AddProductCommand		5 F
>		F G
{

 
public 

AddProductValidator 
( 
ProductValidator /
validations0 ;
); <
{ 
RuleFor 
( 
x 
=> 
x 
. 
	ProductId  
)  !
.! "
NotEmpty" *
(* +
)+ ,
., -
SetValidator- 9
(9 :
validations: E
)E F
;F G
} 
} 
public 
sealed 
class 
ProductValidator $
:% &
AbstractValidator' 8
<8 9
Guid9 =
>= >
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
private 
readonly 
IClaimService "
_claimService# 0
;0 1
public 

ProductValidator 
( 
IUnitOfWorks (
unitOfWorks) 4
,4 5
IClaimService6 C
claimServiceD P
)P Q
{ 
_unitOfWorks 
= 
unitOfWorks "
;" #
_claimService 
= 
claimService $
;$ %
RuleFor 
( 
name 
=> 
name 
) 
. 
	MustAsync 
( #
CheckDuplicateProductId /
)/ 0
. 
WithMessage 
( 
$str ;
); <
;< =
} 
private 
async 
Task 
< 
bool 
> #
CheckDuplicateProductId 4
(4 5
Guid5 9
	productId: C
,C D
CancellationTokenE V
cancellationTokenW h
)h i
{ 
Product   
?   
product   
=   
await    
_unitOfWorks  ! -
.  - .
ProductRepository  . ?
.  ? @
FirstOrDefaultAsync  @ S
(  S T
x  T U
=>  V X
x  Y Z
.  Z [
RestaurantId  [ g
==  h j
_claimService  k x
.  x y
RestaurantId	  y Ö
&&
  Ü à
x
  â ä
.
  ä ã
ProductGeneralId
  ã õ
==
  ú û
	productId
  ü ®
)
  ® ©
;
  © ™
return!! 
product!! 
==!! 
null!! 
;!! 
}"" 
}## ÿ6
}C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Products\Commons\Add\AddProductHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Products# +
.+ ,
Commons, 3
.3 4
Add4 7
;7 8
public 
sealed 
record 
AddProductCommand &
(& '
Guid' +
	ProductId, 5
)5 6
:7 8
IRequest9 A
<A B
ResultB H
>H I
;I J
internal 
class	 
AddProductHandler  
(  !
IUnitOfWorks! -
unitOfWorks. 9
,9 :
IClaimService; H
claimServiceI U
)U V
:W X
IRequestHandlerY h
<h i
AddProductCommandi z
,z {
Result	| Ç
>
Ç É
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
IClaimService "
_claimService# 0
=1 2
claimService3 ?
;? @
public 

async 
Task 
< 
Result 
> 
Handle $
($ %
AddProductCommand% 6
request7 >
,> ?
CancellationToken@ Q
cancellationTokenR c
)c d
{ 
ProductGeneral 
productGeneral %
=& '
await( -
_unitOfWorks. :
.: ;$
ProductGeneralRepository; S
.S T
GetByIdAsyncT `
(` a
requesta h
.h i
	ProductIdi r
)r s
??t v
throww |
new	} Ä
	Exception
Å ä
(
ä ã
)
ã å
;
å ç
Product 
product 
= 
new 
( 
productGeneral ,
., -
ProductName- 8
,8 9
_claimService: G
.G H
RestaurantIdH T
,T U
productGeneralV d
.d e

CategoryIde o
, 
productGeneral 
. 
Id 
)  
;  !
await 
_unitOfWorks 
. 
ProductRepository ,
., -
AddAsync- 5
(5 6
product6 =
)= >
;> ?
await 
AddIngredient 
( 
request #
.# $
	ProductId$ -
)- .
;. /
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
private 
async 
Task 
AddIngredient $
($ %
Guid% )
	productId* 3
)3 4
{   
var!! 
ingredients!! 
=!! 
await!! 
_unitOfWorks!!  ,
.!!, -'
IngredientGeneralRepository!!- H
.!!H I

WhereAsync!!I S
(!!S T
x!!T U
=>!!V X
x!!Y Z
.!!Z [%
ProductIngredientGenerals!![ t
.!!t u
Any!!u x
(!!x y
pig!!y |
=>!!} 
pig
!!Ä É
.
!!É Ñ
ProductGeneralId
!!Ñ î
==
!!ï ó
	productId
!!ò °
)
!!° ¢
)
!!¢ £
;
!!£ §
foreach"" 
("" 
var"" 
item"" 
in"" 
ingredients"" (
)""( )
{## 	
if%% 
(%% 
_unitOfWorks%% 
.%%  
IngredientRepository%% 1
.%%1 2

WhereAsync%%2 <
(%%< =
x%%= >
=>%%? A
x%%B C
.%%C D
IngredientName%%D R
==%%S U
item%%V Z
.%%Z [
IngredientName%%[ i
)%%i j
is%%k m
null%%n r
)%%r s
{&& 

Ingredient'' 

ingredient'' %
=''& '
new''( +
(''+ ,
item'', 0
.''0 1
IngredientName''1 ?
,''? @
item''A E
.''E F
IngredientTypeId''F V
,''V W
_claimService''X e
.''e f
RestaurantId''f r
)''r s
;''s t
await(( 
_unitOfWorks(( "
.((" # 
IngredientRepository((# 7
.((7 8
AddAsync((8 @
(((@ A

ingredient((A K
)((K L
;((L M
await)) $
AddDefaultIngredientUnit)) .
()). /

ingredient))/ 9
.))9 :
Id)): <
,))< =
item))> B
.))B C
IngredientMeasure))C T
)))T U
;))U V
}** 
}++ 	
},, 
private// 
async// 
Task// $
AddDefaultIngredientUnit// /
(/// 0
Guid//0 4
ingredientId//5 A
,//A B
IngredientMeasure//C T

minMeasure//U _
)//_ `
{00 
IngredientUnit22 
ingredientUnit22 %
=22& '
new22( +
(22+ ,
MeasureTransfer22, ;
.22; <
ToSmallUnit22< G
(22G H

minMeasure22H R
)22R S
,22S T
ingredientId22U a
)22a b
;22b c
await33 
_unitOfWorks33 
.33 $
IngredientUnitRepository33 3
.333 4
AddAsync334 <
(33< =
ingredientUnit33= K
)33K L
;33L M
if55 

(55 

minMeasure55 
==55 
IngredientMeasure55 +
.55+ ,
g55, -
||55. 0

minMeasure551 ;
==55< >
IngredientMeasure55? P
.55P Q
ml55Q S
)55S T
{66 	
IngredientUnit77 
ingredientUnit277 *
=77+ ,
new77- 0
(770 1
MeasureTransfer771 @
.77@ A
ToLargeUnit77A L
(77L M

minMeasure77M W
)77W X
,77X Y
ingredientId77Z f
,77f g
ingredientUnit77h v
.77v w
Id77w y
,77y z
$num77{ 
)	77 Ä
;
77Ä Å
await88 
_unitOfWorks88 
.88 $
IngredientUnitRepository88 7
.887 8
AddAsync888 @
(88@ A
ingredientUnit288A P
)88P Q
;88Q R
}99 	
await;; 
_unitOfWorks;; 
.;; 
SaveChangeAsync;; *
(;;* +
);;+ ,
;;;, -
}== 
}>> π
ÉC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Products\Commons\Active\ActiveProductHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Products# +
.+ ,
Commons, 3
.3 4
Active4 :
;: ;
public 
sealed 
record  
ActiveProductCommand )
() *
Guid* .
Id/ 1
)1 2
:3 4
IRequest5 =
<= >
Result> D
>D E
;E F
internal 
class	  
ActiveProductHandler #
(# $
IUnitOfWorks$ 0
unitOfWorks1 <
)< =
:> ?
IRequestHandler@ O
<O P 
ActiveProductCommandP d
,d e
Resultf l
>l m
{		 
private

 
readonly

 
IUnitOfWorks

 !
_unitOfWorks

" .
=

/ 0
unitOfWorks

1 <
;

< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ % 
ActiveProductCommand% 9
request: A
,A B
CancellationTokenC T
cancellationTokenU f
)f g
{ 
Product 
product 
= 
await 
_unitOfWorks  ,
., -
ProductRepository- >
.> ?
GetByIdAsync? K
(K L
requestL S
.S T
IdT V
)V W
??X Z
throw[ `
newa d
	Exceptione n
(n o
)o p
;p q
product 
. 
UpdateState 
( 
false !
)! "
;" #
_unitOfWorks 
. 
ProductRepository &
.& '
Update' -
(- .
product. 5
)5 6
;6 7
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ¶/
óC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Queries\GetProductGeneral\GetProductGeneralQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Queries3 :
.: ;
GetProductGeneral; L
{ 
public 

sealed 
record $
GetProductGeneralCommand 1
(1 2
string2 8
?8 9
Name: >
,> ?
string@ F
?F G
ProductDescriptionH Z
,Z [
Guid\ `
?` a

CategoryIdb l
,l m
PagingRequestn {
PagingRequest	| â
)
â ä
:
ã å
IRequest
ç ï
<
ï ñ
PagedResult
ñ °
<
° ¢'
GetProductGeneralResponse
¢ ª
>
ª º
>
º Ω
;
Ω æ
public

 

record

 %
GetProductGeneralResponse

 +
(

+ ,
Guid

, 0
Id

1 3
,

3 4
string

5 ;
Name

< @
,

@ A
string

B H
ProductDescription

I [
,

[ \
bool

] a
	IsDeleted

b k
,

k l
string

m s
ProductImage	

t Ä
,


Ä Å
Guid


Ç Ü

CategoryId


á ë
,


ë í
DateTimeOffset


ì °
CreatedDate


¢ ≠
,


≠ Æ
DateTimeOffset


Ø Ω

UpdateTime


æ »
)


» …
;


…  
public 

class "
GetProductGeneralQuery '
:( )
IRequestHandler* 9
<9 :$
GetProductGeneralCommand: R
,R S
PagedResultT _
<_ `%
GetProductGeneralResponse` y
>y z
>z {
{ 
private 
readonly 
IUnitOfWorks %
_unitOfWorks& 2
;2 3
public "
GetProductGeneralQuery %
(% &
IUnitOfWorks& 2
unitOfWorks3 >
)> ?
{ 	
_unitOfWorks 
= 
unitOfWorks &
;& '
} 	
public 
async 
Task 
< 
PagedResult %
<% &%
GetProductGeneralResponse& ?
>? @
>@ A
HandleB H
(H I$
GetProductGeneralCommandI a
requestb i
,i j
CancellationTokenk |
cancellationToken	} é
)
é è
{ 	
var 
allProducts 
= 
await #
_unitOfWorks$ 0
.0 1$
ProductGeneralRepository1 I
.I J
GetAllAsyncJ U
(U V
)V W
;W X
var 
filteredProducts  
=! "
allProducts# .
.. /
AsQueryable/ :
(: ;
); <
.< =
CustomFilterV1= K
(K L
newL O
ProductGeneralP ^
{ 

CategoryId 
= 
request $
.$ %

CategoryId% /
??0 2
Guid3 7
.7 8
Empty8 =
,= >
ProductName 
= 
request %
.% &
Name& *
??+ -
string. 4
.4 5
Empty5 :
,: ;
ProductDescription "
=# $
request% ,
., -
ProductDescription- ?
??@ B
stringC I
.I J
EmptyJ O
,O P
}   
)   
;   
var## 
mappedProducts## 
=##  
filteredProducts##! 1
.##1 2
Select##2 8
(##8 9
x##9 :
=>##; =
new##> A%
GetProductGeneralResponse##B [
(##[ \
x$$ 
.$$ 
Id$$ 
,$$ 
x%% 
.%% 
ProductName%% 
??%%  
string%%! '
.%%' (
Empty%%( -
,%%- .
x&& 
.&& 
ProductDescription&& $
??&&% '
string&&( .
.&&. /
Empty&&/ 4
,&&4 5
x'' 
.'' 
	IsDeleted'' 
,'' 
x(( 
.(( 
ProductImageDefault(( %
,((% &
x)) 
.)) 

CategoryId)) 
??)) 
Guid))  $
.))$ %
Empty))% *
,))* +
x** 
.** 
Created** 
,** 
x++ 
.++ 
LastModified++ 
)++ 
)++  
.++  !
ToList++! '
(++' (
)++( )
;++) *
var.. 
(.. 
page.. 
,.. 
pageSize.. 
,..  
sortType..! )
,..) *
	sortField..+ 4
)..4 5
=..6 7
PaginationUtils..8 G
...G H)
GetPaginationAndSortingValues..H e
(..e f
request..f m
...m n
PagingRequest..n {
)..{ |
;..| }
var11 
sortedResults11 
=11 
PaginationHelper11  0
<110 1%
GetProductGeneralResponse111 J
>11J K
.11K L
Sorting11L S
(11S T
sortType11T \
,11\ ]
mappedProducts11^ l
,11l m
	sortField11n w
)11w x
;11x y
var22 
result22 
=22 
PaginationHelper22 )
<22) *%
GetProductGeneralResponse22* C
>22C D
.22D E
Paging22E K
(22K L
sortedResults22L Y
,22Y Z
page22[ _
,22_ `
pageSize22a i
)22i j
;22j k
return44 
result44 
;44 
}55 	
}66 
}77 é
•C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Queries\GetProductGeneralDetail\GetProductGeneralDetailHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Queries3 :
.: ;#
GetProductGeneralDetail; R
;R S
public		 
sealed		 
record		 *
GetProductGeneralDetailCommand		 3
(		3 4
Guid		4 8
Id		9 ;
)		; <
:		= >
IRequest		? G
<		G H+
GetProductGeneralDetailResponse		H g
>		g h
;		h i
public 
record +
GetProductGeneralDetailResponse -
(- .
Guid. 2
Id3 5
,5 6
string7 =
Name> B
,B C
stringD J
DescriptionK V
,V W
DateTimeOffsetX f
CreatedDateg r
,r s
DateTimeOffset	t Ç
UpdateDated
É é
,
é è
List
ê î
<
î ï#
GetIngredientResponse
ï ™
>
™ ´
GetIngredients
¨ ∫
)
∫ ª
;
ª º
public 
record !
GetIngredientResponse #
(# $
Guid$ (
Id) +
,+ ,
string- 3
Name4 8
,8 9
decimal: A
QuantityB J
)J K
;K L
public 
class *
GetProductGeneralDetailHandler +
(+ ,
IUnitOfWorks, 8
unitOfWorks9 D
)D E
:F G
IRequestHandlerH W
<W X*
GetProductGeneralDetailCommandX v
,v w,
GetProductGeneralDetailResponse	x ó
>
ó ò
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< +
GetProductGeneralDetailResponse 5
>5 6
Handle7 =
(= >*
GetProductGeneralDetailCommand> \
request] d
,d e
CancellationTokenf w
cancellationToken	x â
)
â ä
{ 
var 
response 
= 
await 
_unitOfWorks )
.) *$
ProductGeneralRepository* B
.B C
GetByIdAsyncC O
(O P
requestP W
.W X
IdX Z
)Z [
??\ ^
throw_ d
newe h
	Exceptioni r
(r s
)s t
;t u
var 
ingredients 
= 
await 
_unitOfWorks  ,
., -'
IngredientGeneralRepository- H
.H I

WhereAsyncI S
(S T
xT U
=>V X
xY Z
.Z [%
ProductIngredientGenerals[ t
.t u
Anyu x
(x y
xy z
=>{ }
x~ 
.	 Ä
ProductGeneralId
Ä ê
==
ë ì
request
î õ
.
õ ú
Id
ú û
)
û ü
,
ü †
x
° ¢
=>
£ •
x
¶ ß
.
ß ®'
ProductIngredientGenerals
® ¡
)
¡ ¬
;
¬ √
return 
response 
. 
MapperDetailDTO '
(' (
ingredients( 3
.3 4
Select4 :
(: ;
x; <
=>= ?
x@ A
.A B
MapperIngredientDTOB U
(U V
requestV ]
.] ^
Id^ `
)` a
)a b
.b c
ToListc i
(i j
)j k
)k l
;l m
} 
} Ê
ÇC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Mapper\ProductGeneralMapper.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Mapper3 9
;9 :
public 
static 
class  
ProductGeneralMapper (
{ 
public		 

static		 !
GetIngredientResponse		 '
MapperIngredientDTO		( ;
(		; <
this		< @
IngredientGeneral		A R

ingredient		S ]
,		] ^
Guid		_ c
	productId		d m
)		m n
{

 
return 
new !
GetIngredientResponse (
(( )

ingredient) 3
.3 4
Id4 6
,6 7

ingredient8 B
.B C
IngredientNameC Q
,Q R

ingredientS ]
.] ^%
ProductIngredientGenerals^ w
.w x
Wherex }
(} ~
x~ 
=>
Ä Ç
x
É Ñ
.
Ñ Ö
ProductGeneralId
Ö ï
==
ñ ò
	productId
ô ¢
)
¢ £
.
£ §
FirstOrDefault
§ ≤
(
≤ ≥
)
≥ ¥
.
¥ µ
Quantity
µ Ω
)
Ω æ
;
æ ø
} 
public 

static +
GetProductGeneralDetailResponse 1
MapperDetailDTO2 A
(A B
thisB F
ProductGeneralG U
productGeneralV d
,d e
Listf j
<j k"
GetIngredientResponse	k Ä
>
Ä Å
getIngredient
Ç è
)
è ê
{ 
return 
new +
GetProductGeneralDetailResponse 2
(2 3
productGeneral3 A
.A B
IdB D
,D E
productGeneralF T
.T U
ProductNameU `
,` a
productGeneralb p
.p q
ProductDescription	q É
,
É Ñ
productGeneral
Ö ì
.
ì î
Created
î õ
,
õ ú
productGeneral
ù ´
.
´ ¨
LastModified
¨ ∏
,
∏ π
getIngredient
∫ «
)
« »
;
» …
} 
} Ü
úC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Commands\UploadImageDefault\UploadImageDefaultHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Commands3 ;
.; <
UploadImageDefault< N
;N O
public 
sealed 
record %
UploadImageDefaultCommand .
:/ 0
IRequest1 9
<9 :
string: @
>@ A
{ 
public 

required 
	IFormFile 
Image #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
public 
class %
UploadImageDefaultHandler &
(& '
StorageHandler' 5
storageHandler6 D
)D E
:F G
IRequestHandlerH W
<W X%
UploadImageDefaultCommandX q
,q r
strings y
>y z
{ 
private 
readonly 
StorageHandler #
_storageHandler$ 3
=4 5
storageHandler6 D
;D E
public 

async 
Task 
< 
string 
> 
Handle $
($ %%
UploadImageDefaultCommand% >
request? F
,F G
CancellationTokenH Y
cancellationTokenZ k
)k l
{ 
if 

( 
request 
. 
Image 
== 
null !
)! "
{ 	
throw 
new !
ArgumentNullException +
(+ ,
$str, X
)X Y
;Y Z
} 	
StorageFile 
storageFile 
=  !
await" '
_storageHandler( 7
.7 8
UploadImageAsync8 H
(H I
requestI P
.P Q
ImageQ V
,V W
$strX f
)f g
;g h
return 
storageFile 
. 
FileName #
;# $
} 
} ˇ
óC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Commands\Update\UpdateProductIngredientValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Commands3 ;
.; <
Update< B
;B C
internal 
class	 ,
 UpdateProductIngredientValidator /
{ 
} ñ
ïC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Commands\Update\UpdateProductIngredientHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Commands3 ;
.; <
Update< B
;B C
public

 
sealed

 
record

 '
UpdateProductGeneralCommand

 0
:

1 2
IRequest

3 ;
<

; <
Result

< B
>

B C
{ 
public 

Guid 
Id 
{ 
get 
; 
set 
; 
}  
public 

string 
Name 
{ 
get 
; 
set !
;! "
}# $
=% &
string' -
.- .
Empty. 3
;3 4
public 

string 
Description 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
string. 4
.4 5
Empty5 :
;: ;
public 

Guid 

CategoryId 
{ 
get  
;  !
set" %
;% &
}' (
} 
internal 
class	 *
UpdateProductIngredientHandler -
(- .
IUnitOfWorks. :
unitOfWorks; F
)F G
:H I
IRequestHandlerJ Y
<Y Z'
UpdateProductGeneralCommandZ u
,u v
Resultw }
>} ~
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %'
UpdateProductGeneralCommand% @
requestA H
,H I
CancellationTokenJ [
cancellationToken\ m
)m n
{ 
ProductGeneral 
product 
=  
await! &
_unitOfWorks' 3
.3 4$
ProductGeneralRepository4 L
.L M
GetByIdAsyncM Y
(Y Z
requestZ a
.a b
Idb d
)d e
??f h
throwi n
newo r
	Exceptions |
(| }
)} ~
;~ 
product 
. 
Update 
( 
request 
. 
Name #
,# $
request% ,
., -
Description- 8
,8 9
request: A
.A B

CategoryIdB L
)L M
;M N
_unitOfWorks 
. $
ProductGeneralRepository -
.- .
Update. 4
(4 5
product5 <
)< =
;= >
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return   
Result   
.   
Ok   
(   
)   
;   
}!! 
}"" •
™C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Commands\UpdateIngredientQuantity\UpdateIngredientQuantityValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Commands3 ;
.; <$
UpdateIngredientQuantity< T
;T U
internal 
class	 -
!UpdateIngredientQuantityValidator 0
{		 
}

 ﬂ
®C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Commands\UpdateIngredientQuantity\UpdateIngredientQuantityHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Commands3 ;
.; <$
UpdateIngredientQuantity< T
;T U
public

 
sealed

 
record

 +
UpdateIngredientQuantityCommand

 4
:

5 6
IRequest

7 ?
<

? @
Result

@ F
>

F G
{ 
[ 

JsonIgnore 
] 
public 

Guid 
	ProductId 
{ 
get 
;  
set! $
;$ %
}& '
[ 

JsonIgnore 
] 
public 

Guid 
IngredientId 
{ 
get "
;" #
set$ '
;' (
}) *
public 

decimal 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
} 
internal 
class	 +
UpdateIngredientQuantityHandler .
(. /
IUnitOfWorks/ ;
unitOfWorks< G
)G H
:I J
IRequestHandlerK Z
<Z [+
UpdateIngredientQuantityCommand[ z
,z {
Result	| Ç
>
Ç É
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %+
UpdateIngredientQuantityCommand% D
requestE L
,L M
CancellationTokenN _
cancellationToken` q
)q r
{ $
ProductIngredientGeneral  
general! (
=) *
await+ 0
_unitOfWorks1 =
.= >.
"ProductIngredientGeneralRepository> `
.` a
FirstOrDefaultAsynca t
(t u
xu v
=>w y
xz {
.{ | 
IngredientGeneralId	| è
==
ê í
request
ì ö
.
ö õ
IngredientId
õ ß
&&
® ™
x
´ ¨
.
¨ ≠
ProductGeneralId
≠ Ω
==
æ ¿
request
¡ »
.
» …
	ProductId
… “
)
“ ”
??
‘ ÷
throw
◊ ‹
new
› ‡
	Exception
· Í
(
Í Î
)
Î Ï
;
Ï Ì
general 
. 
Update 
( 
request 
. 
	ProductId (
,( )
request* 1
.1 2
IngredientId2 >
,> ?
request@ G
.G H
QuantityH P
)P Q
;Q R
_unitOfWorks 
. .
"ProductIngredientGeneralRepository 7
.7 8
Update8 >
(> ?
general? F
)F G
;G H
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
}"" 
}## °
òC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Commands\RemoveIngredient\RemoveIngredientHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Commands3 ;
.; <
RemoveIngredient< L
;L M
public 
sealed 
record #
RemoveIngredientCommand ,
(, -
Guid- 1
	productId2 ;
,; <
Guid= A
IngredientIdB N
)N O
:P Q
IRequestR Z
<Z [
Result[ a
>a b
;b c
public

 
class

 #
RemoveIngredientHandler

 $
(

$ %
IUnitOfWorks

% 1
unitOfWorks

2 =
)

= >
:

? @
IRequestHandler

A P
<

P Q#
RemoveIngredientCommand

Q h
,

h i
Result

j p
>

p q
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %#
RemoveIngredientCommand% <
request= D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
{ $
ProductIngredientGeneral  
general! (
=) *
await+ 0
_unitOfWorks1 =
.= >.
"ProductIngredientGeneralRepository> `
.` a
FirstOrDefaultAsynca t
(t u
xu v
=>w y
xz {
.{ | 
IngredientGeneralId	| è
==
ê í
request
ì ö
.
ö õ
IngredientId
õ ß
&&
® ™
x
´ ¨
.
¨ ≠
ProductGeneralId
≠ Ω
==
æ ¿
request
¡ »
.
» …
	productId
… “
)
“ ”
??
‘ ÷
throw
◊ ‹
new
› ‡
	Exception
· Í
(
Í Î
)
Î Ï
;
Ï Ì
_unitOfWorks 
. .
"ProductIngredientGeneralRepository 7
.7 8
Remove8 >
(> ?
general? F
)F G
;G H
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} •
ñC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Commands\Inactive\InactiveProductGeneralHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Commands3 ;
.; <
Inactive< D
;D E
public 
sealed 
record )
InactiveProductGeneralCommand 2
(2 3
Guid3 7
Id8 :
): ;
:< =
IRequest> F
<F G
ResultG M
>M N
;N O
public 
class )
InactiveProductGeneralHandler *
(* +
IUnitOfWorks+ 7
unitOfWorks8 C
)C D
:E F
IRequestHandlerG V
<V W)
InactiveProductGeneralCommandW t
,t u
Resultv |
>| }
{		 
private

 
readonly

 
IUnitOfWorks

 !
_unitOfWorks

" .
=

/ 0
unitOfWorks

1 <
;

< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %)
InactiveProductGeneralCommand% B
requestC J
,J K
CancellationTokenL ]
cancellationToken^ o
)o p
{ 
ProductGeneral 
productGeneral %
=& '
await( -
_unitOfWorks. :
.: ;$
ProductGeneralRepository; S
.S T
GetByIdAsyncT `
(` a
requesta h
.h i
Idi k
)k l
??m o
throwp u
newv y
	Exception	z É
(
É Ñ
)
Ñ Ö
;
Ö Ü
productGeneral 
. 
SetState 
(  
true  $
)$ %
;% &
_unitOfWorks 
. $
ProductGeneralRepository -
.- .
Update. 4
(4 5
productGeneral5 C
)C D
;D E
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ˜
îC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Commands\Create\CreateProductGeneralValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Commands3 ;
.; <
Create< B
;B C
public 
class )
CreateProductGeneralValidator *
{ 
} Õ%
íC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Commands\Create\CreateProductGeneralHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Commands3 ;
.; <
Create< B
;B C
public		 
sealed		 
record		 '
CreateProductGeneralCommand		 0
:		1 2
IRequest		3 ;
<		; <
Guid		< @
>		@ A
{

 
public 

required 
string 
ProductName &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 

required 
string 
Description &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 

required 
Guid 

CategoryId #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 

required 
List 
<  
AddIngredientCommand -
>- .
Ingredients/ :
{; <
get= @
;@ A
setB E
;E F
}G H
public 

required 
string 
ImageDefault '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
public 
sealed 
record  
AddIngredientCommand )
() *
Guid* .

Ingredient/ 9
,9 :
decimal; B
QuantityC K
)K L
;L M
public 
class '
CreateProductGeneralHandler (
(( )
IUnitOfWorks) 5
unitOfWorks6 A
)A B
:C D
IRequestHandlerE T
<T U'
CreateProductGeneralCommandU p
,p q
Guidr v
>v w
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #'
CreateProductGeneralCommand# >
request? F
,F G
CancellationTokenH Y
cancellationTokenZ k
)k l
{ 
ProductGeneral 
productGeneral %
=& '
new( +
(+ ,
request, 3
.3 4
ProductName4 ?
,? @
requestA H
.H I
DescriptionI T
,T U
requestV ]
.] ^

CategoryId^ h
,h i
requestj q
.q r
ImageDefaultr ~
,~ 
false
Ä Ö
)
Ö Ü
;
Ü á
await 
_unitOfWorks 
. $
ProductGeneralRepository 3
.3 4
AddAsync4 <
(< =
productGeneral= K
)K L
;L M
await 
AddIngredient 
( 
request #
.# $
Ingredients$ /
,/ 0
productGeneral1 ?
.? @
Id@ B
)B C
;C D
await   
_unitOfWorks   
.   
SaveChangeAsync   *
(  * +
)  + ,
;  , -
return!! 
productGeneral!! 
.!! 
Id!!  
;!!  !
}"" 
private$$ 
async$$ 
	ValueTask$$ 
AddIngredient$$ )
($$) *
List$$* .
<$$. / 
AddIngredientCommand$$/ C
>$$C D
commands$$E M
,$$M N
Guid$$O S
	productId$$T ]
)$$] ^
{%% 
var&& %
productIngredientGenerals&& %
=&&& '
commands&&( 0
.'' 
Select'' 
('' 
command'' 
=>'' 
new'' "$
ProductIngredientGeneral''# ;
(''; <
	productId''< E
,''E F
command''G N
.''N O

Ingredient''O Y
,''Y Z
command''[ b
.''b c
Quantity''c k
)''k l
)''l m
.(( 
ToList(( 
((( 
)(( 
;(( 
await** 
_unitOfWorks** 
.** .
"ProductIngredientGeneralRepository** =
.**= >
AddRangeAsync**> K
(**K L%
productIngredientGenerals**L e
)**e f
;**f g
}++ 
},, ¿
íC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Commands\AddIngredient\AddIngredientHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
ProductGenerals# 2
.2 3
Commands3 ;
.; <
AddIngredient< I
;I J
public 
sealed 
record  
AddIngredientCommand )
:* +
IRequest, 4
<4 5
Guid5 9
>9 :
{ 
public		 

Guid		 
Id		 
{		 
get		 
;		 
set		 
;		 
}		  
public 

Guid 
IngredientId 
{ 
get "
;" #
set$ '
;' (
}) *
public 

decimal 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
} 
public 
class  
AddIngredientHandler !
(! "
IUnitOfWorks" .
unitOfWorks/ :
): ;
:< =
IRequestHandler> M
<M N 
AddIngredientCommandN b
,b c
Guidd h
>h i
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" # 
AddIngredientCommand# 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ $
ProductIngredientGeneral  
general! (
=) *
new+ .
(. /
request/ 6
.6 7
Id7 9
,9 :
request; B
.B C
IngredientIdC O
,O P
requestQ X
.X Y
QuantityY a
)a b
;b c
await 
_unitOfWorks 
. .
"ProductIngredientGeneralRepository =
.= >
AddAsync> F
(F G
generalG N
)N O
;O P
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
request 
. 
Id 
; 
} 
} î
íC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\ProductGenerals\Commands\Active\ActiveProductGeneralHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" #
ProductGenerals		# 2
.		2 3
Commands		3 ;
.		; <
Active		< B
;		B C
public 
sealed 
record '
ActiveProductGeneralCommand 0
(0 1
Guid1 5
id6 8
)8 9
:: ;
IRequest< D
<D E
ResultE K
>K L
;L Mﬁ
xC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Payments\Queries\GetPaymentsQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Payments# +
.+ ,
Queries, 3
;3 4
public 
record 
GetPaymentsRequest  
(  !
Guid! %
?% &
	PaymentId' 0
,0 1
PaymentStatus2 ?
?? @
PaymentStatusA N
,N O
PaymentMethodsP ^
?^ _
PaymentMethods` n
)n o
:p q
IRequestr z
<z {
List{ 
<	 Ä
PaymentResponse
Ä è
>
è ê
>
ê ë
;
ë í
public 
record 
PaymentResponse 
( 
Guid "
	PaymentId# ,
,, -
decimal. 5
Amount6 <
,< =
PaymentStatus> K
PaymentStatusL Y
,Y Z
PaymentMethods[ i
PaymentMethodsj x
)x y
;y z
public 
class 
GetPaymentsQuery 
( 
IUnitOfWorks *
unitOfWorks+ 6
)6 7
:8 9
IRequestHandler: I
<I J
GetPaymentsRequestJ \
,\ ]
List^ b
<b c
PaymentResponsec r
>r s
>s t
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
List 
< 
PaymentResponse *
>* +
>+ ,
Handle- 3
(3 4
GetPaymentsRequest4 F
requestG N
,N O
CancellationTokenP a
cancellationTokenb s
)s t
{ 
var 
payments 
= 
await 
_unitOfWorks )
.) *
PaymentRepository* ;
.; <
GetAllAsync< G
(G H
)H I
;I J
var 
filterEntity 
= 
new 
Domain %
.% &
Entities& .
.. /
PaymentAggregator/ @
.@ A
PaymentsA I
{ 	
Id 
= 
request 
. 
	PaymentId "
??# %
Guid& *
.* +
Empty+ 0
,0 1
PaymentStatus 
= 
request #
.# $
PaymentStatus$ 1
??2 4
PaymentStatus5 B
.B C
PendingC J
,J K
PaymentMethods 
= 
request $
.$ %
PaymentMethods% 3
??4 6
PaymentMethods7 E
.E F
CashF J
} 	
;	 

var 
filteredPayment 
= 
payments &
.& '
AsQueryable' 2
(2 3
)3 4
.4 5
CustomFilterV15 C
(C D
filterEntityD P
)P Q
;Q R
return 
filteredPayment 
. 
Select %
(% &
p& '
=>( *
new+ .
PaymentResponse/ >
(> ?
p 
. 
Id 
, 
p  " #
.  # $
Amount  $ *
,  * +
p!!- .
.!!. /
PaymentStatus!!/ <
,!!< =
p""8 9
.""9 :
PaymentMethods"": H
)""H I
)""I J
.""J K
ToList""K Q
(""Q R
)""R S
;""S T
}## 
}$$ ‡
ãC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Payments\Commands\FinishPayment\FinishPaymentHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Payments# +
.+ ,
Commands, 4
.4 5
FinishPayment5 B
;B C
public 
sealed 
record  
FinishPaymentCommand )
() *
Guid* .
OrderId/ 6
)6 7
:8 9
IRequest: B
<B C
GuidC G
>G H
;H I
public 
class  
FinishPaymentHandler !
(! "
IUnitOfWorks" .
unitOfWorks/ :
): ;
:< =
IRequestHandler> M
<M N 
FinishPaymentCommandN b
,b c
Guidd h
>h i
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" # 
FinishPaymentCommand# 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ 
var 
order 
= 
await 
_unitOfWorks &
.& '
OrderRepository' 6
.6 7
GetByIdAsync7 C
(C D
requestD K
.K L
OrderIdL S
,S T
oU V
=>W Y
oZ [
.[ \
Payments\ d
)d e
?? 
throw 
new 
	Exception "
(" #
$str# ;
); <
;< =
var 
payment 
= 
order 
. 
Payments $
.$ %
FirstOrDefault% 3
(3 4
)4 5
;5 6
if 

( 
payment 
== 
null 
) 
{ 	
throw 
new 
	Exception 
(  
$str  D
)D E
;E F
} 	
if 

( 
payment 
. 
PaymentStatus !
!=" $
PaymentStatus% 2
.2 3
Paid3 7
)7 8
{ 	
payment   
.   
PaymentStatus   !
=  " #
PaymentStatus  $ 1
.  1 2
Paid  2 6
;  6 7
_unitOfWorks!! 
.!! 
PaymentRepository!! *
.!!* +
Update!!+ 1
(!!1 2
payment!!2 9
)!!9 :
;!!: ;
}"" 	
if$$ 

($$ 
order$$ 
.$$ 
OrderStatus$$ 
!=$$  
OrderStatus$$! ,
.$$, -
Finish$$- 3
)$$3 4
{%% 	
order&& 
.&& 
OrderStatus&& 
=&& 
OrderStatus&&  +
.&&+ ,
Finish&&, 2
;&&2 3
_unitOfWorks'' 
.'' 
OrderRepository'' (
.''( )
Update'') /
(''/ 0
order''0 5
)''5 6
;''6 7
}(( 	
await** 
_unitOfWorks** 
.** 
SaveChangeAsync** *
(*** +
)**+ ,
;**, -
return,, 
payment,, 
.,, 
Id,, 
;,, 
}-- 
}..   
ÑC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Payments\Commands\Create\CreatePaymentHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Payments# +
.+ ,
Commands, 4
.4 5
Create5 ;
;; <
public 
record !
CreatePaymentCommands #
(# $
PaymentMethods$ 2
PaymentMethods3 A
)A B
:C D
IRequestE M
<M N
GuidN R
>R S
{ 
[ 

JsonIgnore 
] 
public 

Guid 
OrderId 
{ 
get 
; 
set "
;" #
}$ %
} 
public 
class  
CreatePaymentHandler !
(! "
IUnitOfWorks" .
unitOfWorks/ :
): ;
:< =
IRequestHandler> M
<M N!
CreatePaymentCommandsN c
,c d
Guide i
>i j
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #!
CreatePaymentCommands# 8
request9 @
,@ A
CancellationTokenB S
cancellationTokenT e
)e f
{ 
var 
order 
= 
await 
_unitOfWorks &
.& '
OrderRepository' 6
.6 7
GetByIdAsync7 C
(C D
requestD K
.K L
OrderIdL S
,S T
oU V
=>W Y
oZ [
.[ \
OrderDetails\ h
)h i
?? 
throw 
new 
	Exception "
(" #
$str# @
)@ A
;A B
var 
totalAmount 
= 
order 
.  
OrderDetails  ,
. 
Where 
( 
od 
=> 
od 
. 
Status "
!=# %
OrderDetailsStatus& 8
.8 9
Refund9 ?
)? @
. 
Sum 
( 
od 
=> 
od 
. 
Quantity "
*# $
od% '
.' (
Price( -
)- .
;. /
if 

( 
totalAmount 
== 
$num 
) 
{ 	
throw   
new   
	Exception   
(    
$str    =
)  = >
;  > ?
}!! 	
var## 
payment## 
=## 
new## 
Domain##  
.##  !
Entities##! )
.##) *
PaymentAggregator##* ;
.##; <
Payments##< D
{$$ 	
OrderId%% 
=%% 
request%% 
.%% 
OrderId%% %
,%%% &
PaymentMethods&& 
=&& 
request&& $
.&&$ %
PaymentMethods&&% 3
,&&3 4
PaymentDate'' 
='' 
DateTime'' "
.''" #
UtcNow''# )
,'') *
Amount(( 
=(( 
totalAmount((  
,((  !
PaymentStatus)) 
=)) 
PaymentStatus)) )
.))) *
Pending))* 1
}** 	
;**	 

await,, 
_unitOfWorks,, 
.,, 
PaymentRepository,, ,
.,,, -
AddAsync,,- 5
(,,5 6
payment,,6 =
),,= >
;,,> ?
await-- 
_unitOfWorks-- 
.-- 
SaveChangeAsync-- *
(--* +
)--+ ,
;--, -
return// 
payment// 
.// 
Id// 
;// 
}00 
}11 ı:
éC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Payments\Commands\CreateVNPayPayment\VNPayReturnHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" #
Payments		# +
.		+ ,
Commands		, 4
{

 
public 

record  
VNPayCallbackCommand &
(& '
string' -

vnp_Amount. 8
,8 9
string: @
vnp_BankCodeA M
,M N
stringO U
vnp_BankTranNoV d
,d e
stringf l
vnp_CardTypem y
,y z
string	{ Å
	orderInfo
Ç ã
,
ã å
string
ç ì
vnp_PayDate
î ü
,
ü †
string
° ß
vnp_ResponseCode
® ∏
,
∏ π
string
∫ ¿
vnp_TmnCode
¡ Ã
,
Ã Õ
long
Œ “
vnpayTranId
” ﬁ
,
ﬁ ﬂ
string
‡ Ê#
vnp_TransactionStatus
Á ¸
,
¸ ˝
string
˛ Ñ

vnp_TxnRef
Ö è
,
è ê
string
ë ó
vnp_SecureHash
ò ¶
,
¶ ß
string
® Æ
responseQuery
Ø º
)
º Ω
:
æ ø
IRequest
¿ »
<
» …#
VNPayCallbackResponse
… ﬁ
>
ﬁ ﬂ
;
ﬂ ‡
public 

record !
VNPayCallbackResponse '
{ 
public 
bool 
Success 
{ 
get !
;! "
init# '
;' (
}) *
public 
string 
Message 
{ 
get  #
;# $
init% )
;) *
}+ ,
} 
public 

class  
VNPayCallbackHandler %
:& '
IRequestHandler( 7
<7 8 
VNPayCallbackCommand8 L
,L M!
VNPayCallbackResponseN c
>c d
{ 
private 
readonly 
IUnitOfWorks %
_unitOfWorks& 2
;2 3
private 
readonly 
IConfiguration '
_configuration( 6
;6 7
public  
VNPayCallbackHandler #
(# $
IUnitOfWorks$ 0
unitOfWorks1 <
,< =
IConfiguration> L
configurationM Z
)Z [
{ 	
_unitOfWorks 
= 
unitOfWorks &
;& '
_configuration 
= 
configuration *
;* +
} 	
public 
async 
Task 
< !
VNPayCallbackResponse /
>/ 0
Handle1 7
(7 8 
VNPayCallbackCommand8 L
requestM T
,T U
CancellationTokenV g
cancellationTokenh y
)y z
{ 	
var 

hashSecret 
= 
_configuration +
[+ ,
$str, C
]C D
;D E
bool!! 
isValidSignature!! !
=!!" #
ValidateSignature!!$ 5
(!!5 6
request!!6 =
.!!= >
responseQuery!!> K
,!!K L
request!!M T
.!!T U
vnp_SecureHash!!U c
,!!c d

hashSecret!!e o
)!!o p
;!!p q
if"" 
("" 
!"" 
isValidSignature"" !
)""! "
{## 
return$$ 
new$$ !
VNPayCallbackResponse$$ 0
{%% 
Success&& 
=&& 
false&& #
,&&# $
Message'' 
='' 
$str'' 8
}(( 
;(( 
})) 
if,, 
(,, 
request,, 
.,, 
vnp_ResponseCode,, (
!=,,) +
$str,,, 0
),,0 1
{-- 
return.. 
new.. !
VNPayCallbackResponse.. 0
{// 
Success00 
=00 
false00 #
,00# $
Message11 
=11 
$str11 ?
+11@ A
request11B I
.11I J
vnp_ResponseCode11J Z
+11[ \
$str11] b
+11c d
request11e l
.11l m"
vnp_TransactionStatus	11m Ç
}22 
;22 
}33 
var55 
payment55 
=55 
await55 
_unitOfWorks55  ,
.55, -
PaymentRepository55- >
.55> ?#
GetPaymentByTxnRefAsync55? V
(55V W
request55W ^
.55^ _

vnp_TxnRef55_ i
)55i j
;55j k
if66 
(66 
payment66 
==66 
null66 
)66  
{77 
return88 
new88 !
VNPayCallbackResponse88 0
{99 
Success:: 
=:: 
false:: #
,::# $
Message;; 
=;; 
$str;; J
}<< 
;<< 
}== 
var?? 
order?? 
=?? 
await?? 
_unitOfWorks?? *
.??* +
OrderRepository??+ :
.??: ;
GetByIdAsync??; G
(??G H
payment??H O
.??O P
OrderId??P W
)??W X
;??X Y
paymentAA 
.AA 
PaymentStatusAA !
=AA" #
DomainAA$ *
.AA* +
EntitiesAA+ 3
.AA3 4
PaymentAggregatorAA4 E
.AAE F
EnumsAAF K
.AAK L
PaymentStatusAAL Y
.AAY Z
PaidAAZ ^
;AA^ _
orderBB 
.BB 
OrderStatusBB 
=BB 
DomainBB  &
.BB& '
EntitiesBB' /
.BB/ 0
OrderAggregatorBB0 ?
.BB? @
EnumsBB@ E
.BBE F
OrderStatusBBF Q
.BBQ R
FinishBBR X
;BBX Y
_unitOfWorksDD 
.DD 
PaymentRepositoryDD *
.DD* +
UpdateDD+ 1
(DD1 2
paymentDD2 9
)DD9 :
;DD: ;
_unitOfWorksEE 
.EE 
OrderRepositoryEE (
.EE( )
UpdateEE) /
(EE/ 0
orderEE0 5
)EE5 6
;EE6 7
awaitFF 
_unitOfWorksFF 
.FF 
SaveChangeAsyncFF .
(FF. /
)FF/ 0
;FF0 1
returnHH 
newHH !
VNPayCallbackResponseHH ,
{II 
SuccessJJ 
=JJ 
trueJJ 
,JJ 
MessageKK 
=KK 
$strKK @
}LL 
;LL 
}MM 	
privateNN 
boolNN 
ValidateSignatureNN &
(NN& '
stringNN' -
rsprawNN. 4
,NN4 5
stringNN6 <
	inputHashNN= F
,NNF G
stringNNH N
	secretKeyNNO X
)NNX Y
{OO 	
stringPP 

myChecksumPP 
=PP 
UtilsPP  %
.PP% &

HmacSHA512PP& 0
(PP0 1
	secretKeyPP1 :
,PP: ;
rsprawPP< B
)PPB C
;PPC D
returnQQ 

myChecksumQQ 
.QQ 
EqualsQQ $
(QQ$ %
	inputHashQQ% .
,QQ. /
StringComparisonQQ0 @
.QQ@ A&
InvariantCultureIgnoreCaseQQA [
)QQ[ \
;QQ\ ]
}RR 	
}SS 
}TT ¿I
èC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Payments\Commands\CreateVNPayPayment\VNPayPaymentHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Payments# +
.+ ,
Commands, 4
.4 5
CreateVNPayPayment5 G
;G H
public 
record 
VNPayPaymentCommand !
:" #
IRequest$ ,
<, - 
VNPayPaymentResponse- A
>A B
{ 
[ 

JsonIgnore 
] 
public 

Guid 
OrderId 
{ 
get 
; 
set "
;" #
}$ %
} 
public 
record  
VNPayPaymentResponse "
(" #
string# )

PaymentUrl* 4
,4 5
Guid6 :
	PaymentId; D
)D E
;E F
public 
class 
VNPayPaymentHandler  
:! "
IRequestHandler# 2
<2 3
VNPayPaymentCommand3 F
,F G 
VNPayPaymentResponseH \
>\ ]
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
private 
readonly 
IConfiguration #
_configuration$ 2
;2 3
public 

VNPayPaymentHandler 
( 
IUnitOfWorks +
unitOfWorks, 7
,7 8
IConfiguration9 G
configurationH U
)U V
{ 
_unitOfWorks 
= 
unitOfWorks "
;" #
_configuration 
= 
configuration &
;& '
} 
public 

async 
Task 
<  
VNPayPaymentResponse *
>* +
Handle, 2
(2 3
VNPayPaymentCommand3 F
requestG N
,N O
CancellationTokenP a
cancellationTokenb s
)s t
{   
var!! 
hash_secret!! 
=!! 
_configuration!! (
[!!( )
$str!!) @
]!!@ A
;!!A B
var"" 
tmn_code"" 
="" 
_configuration"" %
[""% &
$str""& :
]"": ;
;""; <
var## 
	returnUrl## 
=## 
_configuration## &
[##& '
$str##' =
]##= >
;##> ?
var$$ 
url$$ 
=$$ 
_configuration$$  
[$$  !
$str$$! 1
]$$1 2
;$$2 3
var&& 
order&& 
=&& 
await&& 
_unitOfWorks&& &
.&&& '
OrderRepository&&' 6
.&&6 7
GetByIdAsync&&7 C
(&&C D
request&&D K
.&&K L
OrderId&&L S
,&&S T
o&&U V
=>&&W Y
o&&Z [
.&&[ \
OrderDetails&&\ h
)&&h i
??'' 
throw'' 
new'' 
	Exception'' "
(''" #
$str''# <
)''< =
;''= >
var)) 
totalAmount)) 
=)) 
order)) 
.))  
OrderDetails))  ,
.** 
Where** 
(** 
od** 
=>** 
od** 
.** 
Status** "
!=**# %
OrderDetailsStatus**& 8
.**8 9
Refund**9 ?
)**? @
.++ 
Sum++ 
(++ 
od++ 
=>++ 
od++ 
.++ 
Quantity++ "
*++# $
od++% '
.++' (
Price++( -
)++- .
;++. /
if-- 

(-- 
totalAmount-- 
==-- 
$num-- 
)-- 
{.. 	
throw// 
new// 
	Exception// 
(//  
$str//  =
)//= >
;//> ?
}00 	
var22 
txnRef22 
=22 
$"22 
{22 
request22 
.22  
OrderId22  '
.22' (
ToString22( 0
(220 1
)221 2
}222 3
$str223 4
{224 5
DateTime225 =
.22= >
UtcNow22> D
:22D E
$str22E S
}22S T
"22T U
;22U V
Console33 
.33 
	WriteLine33 
(33 
$"33 
$str33 .
{33. /
txnRef33/ 5
}335 6
"336 7
)337 8
;338 9
var55 
payment55 
=55 
new55 
Domain55  
.55  !
Entities55! )
.55) *
PaymentAggregator55* ;
.55; <
Payments55< D
{66 	
OrderId77 
=77 
request77 
.77 
OrderId77 %
,77% &
Amount88 
=88 
totalAmount88  
,88  !
	VnpTxnRef99 
=99 
txnRef99 
,99 
PaymentDate:: 
=:: 
DateTime:: "
.::" #
UtcNow::# )
,::) *
PaymentMethods;; 
=;; 
Domain;; #
.;;# $
Entities;;$ ,
.;;, -
PaymentAggregator;;- >
.;;> ?
Enums;;? D
.;;D E
PaymentMethods;;E S
.;;S T
VNPay;;T Y
,;;Y Z
PaymentStatus<< 
=<< 
Domain<< "
.<<" #
Entities<<# +
.<<+ ,
PaymentAggregator<<, =
.<<= >
Enums<<> C
.<<C D
PaymentStatus<<D Q
.<<Q R
Pending<<R Y
}== 	
;==	 

await?? 
_unitOfWorks?? 
.?? 
PaymentRepository?? ,
.??, -
AddAsync??- 5
(??5 6
payment??6 =
)??= >
;??> ?
await@@ 
_unitOfWorks@@ 
.@@ 
SaveChangeAsync@@ *
(@@* +
)@@+ ,
;@@, -
stringBB 

formatDateBB 
=BB 
$"BB 
{BB 
DateTimeBB '
.BB' (
UtcNowBB( .
:BB. /
$strBB/ =
}BB= >
"BB> ?
;BB? @
VnPayHandlerDD 
vnPayHandlerDD !
=DD" #
newDD$ '
VnPayHandlerDD( 4
(DD4 5
)DD5 6
;DD6 7
vnPayHandlerEE 
.EE 
AddRequestDataEE #
(EE# $
$strEE$ 1
,EE1 2
$strEE3 :
)EE: ;
;EE; <
vnPayHandlerFF 
.FF 
AddRequestDataFF #
(FF# $
$strFF$ 1
,FF1 2
$strFF3 8
)FF8 9
;FF9 :
vnPayHandlerGG 
.GG 
AddRequestDataGG #
(GG# $
$strGG$ 1
,GG1 2
tmn_codeGG3 ;
)GG; <
;GG< =
vnPayHandlerHH 
.HH 
AddRequestDataHH #
(HH# $
$strHH$ 0
,HH0 1
(HH2 3
totalAmountHH3 >
*HH? @
$numHHA D
)HHD E
.HHE F
ToStringHHF N
(HHN O
)HHO P
)HHP Q
;HHQ R
vnPayHandlerII 
.II 
AddRequestDataII #
(II# $
$strII$ 2
,II2 3
$strII4 6
)II6 7
;II7 8
vnPayHandlerJJ 
.JJ 
AddRequestDataJJ #
(JJ# $
$strJJ$ 4
,JJ4 5

formatDateJJ6 @
)JJ@ A
;JJA B
vnPayHandlerKK 
.KK 
AddRequestDataKK #
(KK# $
$strKK$ 2
,KK2 3
$strKK4 9
)KK9 :
;KK: ;
vnPayHandlerLL 
.LL 
AddRequestDataLL #
(LL# $
$strLL$ 0
,LL0 1
UtilsLL2 7
.LL7 8
GetIpAddressLL8 D
(LLD E
)LLE F
)LLF G
;LLG H
vnPayHandlerMM 
.MM 
AddRequestDataMM #
(MM# $
$strMM$ 0
,MM0 1
$strMM2 6
)MM6 7
;MM7 8
vnPayHandlerNN 
.NN 
AddRequestDataNN #
(NN# $
$strNN$ 3
,NN3 4
$strNN5 H
)NNH I
;NNI J
vnPayHandlerOO 
.OO 
AddRequestDataOO #
(OO# $
$strOO$ 3
,OO3 4
$strOO5 <
)OO< =
;OO= >
vnPayHandlerPP 
.PP 
AddRequestDataPP #
(PP# $
$strPP$ 3
,PP3 4
	returnUrlPP5 >
)PP> ?
;PP? @
vnPayHandlerQQ 
.QQ 
AddRequestDataQQ #
(QQ# $
$strQQ$ 0
,QQ0 1
txnRefQQ2 8
)QQ8 9
;QQ9 :
stringTT 

paymentUrlTT 
=TT 
vnPayHandlerTT (
.TT( )
CreateRequestUrlTT) 9
(TT9 :
urlTT: =
,TT= >
hash_secretTT? J
)TTJ K
;TTK L
returnVV 
newVV  
VNPayPaymentResponseVV '
(VV' (

paymentUrlVV( 2
,VV2 3
paymentVV4 ;
.VV; <
IdVV< >
)VV> ?
;VV? @
}WW 
}XX §&
~C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Orders\Queries\GetOrders\GetOrdersQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Orders# )
.) *
Queries* 1
.1 2
	GetOrders2 ;
;; <
public 
record 
GetOrdersRequest 
( 
Guid #
?# $
Id% '
,' (
OrderStatus) 4
?4 5
OrderStatus6 A
,A B
	OrderTypeC L
?L M
	OrderTypeN W
,W X
DateTimeY a
?a b
	OrderTimec l
,l m
Guidn r
?r s
TableIdt {
){ |
:} ~
IRequest	 á
<
á à
List
à å
<
å ç
GetOrdersResponse
ç û
>
û ü
>
ü †
;
† °
public 
record 
GetOrdersResponse 
(  
Guid  $
Id% '
,' (
OrderStatus) 4
OrderStatus5 @
,@ A
	OrderTypeB K
	OrderTypeL U
,U V
decimalW ^

TotalPrice_ i
,i j
DateTimek s
	OrderTimet }
,} ~
Guid	 É
TalbeId
Ñ ã
)
ã å
;
å ç
public 
class 
GetOrdersQuery 
( 
IUnitOfWorks (
unitOfWorks) 4
)4 5
:6 7
IRequestHandler8 G
<G H
GetOrdersRequestH X
,X Y
ListZ ^
<^ _
GetOrdersResponse_ p
>p q
>q r
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
List 
< 
GetOrdersResponse ,
>, -
>- .
Handle/ 5
(5 6
GetOrdersRequest6 F
requestG N
,N O
CancellationTokenP a
cancellationTokenb s
)s t
{ 
var 
orders 
= 
await 
_unitOfWorks '
.' (
OrderRepository( 7
.7 8
GetAllAsync8 C
(C D
)D E
;E F
var 
filterEntity 
= 
new 
Domain %
.% &
Entities& .
.. /
OrderAggregator/ >
.> ?
Order? D
{ 	
Id 
= 
request 
. 
Id 
?? 
Guid #
.# $
Empty$ )
,) *
OrderStatus 
= 
request !
.! "
OrderStatus" -
??. 0
OrderStatus1 <
.< =
Finish= C
,C D
	OrderType 
= 
request 
.  
	OrderType  )
??* ,
	OrderType- 6
.6 7
OrderAtTable7 C
,C D
	OrderTime 
= 
request 
.  
	OrderTime  )
??* ,
DateTime- 5
.5 6
MinValue6 >
,> ?
TableId 
= 
request 
. 
TableId %
??& (
Guid) -
.- .
Empty. 3
} 	
;	 

var 
filteredOrder 
= 
orders "
." #
AsQueryable# .
(. /
)/ 0
.0 1
CustomFilterV11 ?
(? @
filterEntity@ L
)L M
;M N
return 
filteredOrder 
. 
Select #
(# $
o$ %
=>& (
new) ,
GetOrdersResponse- >
(> ?
o 
. 
Id 
, 
o  " #
.  # $
OrderStatus  $ /
??  0 2
OrderStatus  3 >
.  > ?
Finish  ? E
,  E F
o!!- .
.!!. /
	OrderType!!/ 8
??!!9 ;
	OrderType!!< E
.!!E F
OrderAtTable!!F R
,!!R S
o""8 9
.""9 :

TotalPrice"": D
,""D E
o##C D
.##D E
	OrderTime##E N
??##O Q
DateTime##R Z
.##Z [
MinValue##[ c
,##c d
o$$N O
.$$O P
TableId$$P W
)$$W X
)$$X Y
.$$Y Z
ToList$$Z `
($$` a
)$$a b
;$$b c
}%% 
}&& ¢
äC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Orders\Queries\GetOrderDetails\GetOrderDetailsQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Orders# )
.) *
Queries* 1
.1 2
GetOrderDetails2 A
;A B
public 
record "
GetOrderDetailsCommand $
($ %
Guid% )
OrderId* 1
)1 2
:3 4
IRequest5 =
<= >#
GetOrderDetailsResponse> U
>U V
;V W
public 
record #
GetOrderDetailsResponse %
(% &
Guid& *
OrderId+ 2
,2 3
List4 8
<8 9
OrderDetailsDto9 H
>H I
OrderDetailsJ V
)V W
;W X
public 
record 
OrderDetailsDto 
( 
Guid "
Id# %
,% &
Guid' +
?+ ,
ComboId- 4
,4 5
Guid6 :
?: ;
	ProductId< E
,E F
OrderDetailsStatusG Y
?Y Z
Status[ a
,a b
intc f
Quantityg o
,o p
decimalq x
Pricey ~
)~ 
;	 Ä
public 
class  
GetOrderDetailsQuery !
(! "
IUnitOfWorks" .
unitOfWorks/ :
): ;
:< =
IRequestHandler> M
<M N"
GetOrderDetailsCommandN d
,d e#
GetOrderDetailsResponsef }
>} ~
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< #
GetOrderDetailsResponse -
>- .
Handle/ 5
(5 6"
GetOrderDetailsCommand6 L
requestM T
,T U
CancellationTokenV g
cancellationTokenh y
)y z
{ 
var 
orderDetails 
= 
await  
_unitOfWorks! -
.- .!
OrderDetailRepository. C
.C D
GetByOrderIdAsyncD U
(U V
requestV ]
.] ^
OrderId^ e
)e f
;f g
return 
new #
GetOrderDetailsResponse *
(* +
request+ 2
.2 3
OrderId3 :
,: ;
orderDetails< H
.H I
SelectI O
(O P
oP Q
=>R T
newU X
OrderDetailsDtoY h
(h i
o 
. 
Id 
, 
o" #
.# $
ComboId$ +
,+ ,
o- .
.. /
	ProductId/ 8
,8 9
o8 9
.9 :
Status: @
,@ A
oC D
.D E
QuantityE M
,M N
oN O
.O P
PriceP U
)U V
)V W
.W X
ToListX ^
(^ _
)_ `
)` a
;a b
} 
} Å
ÄC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Orders\Commands\Update\UpdateOrderHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" #
Orders		# )
.		) *
Commands		* 2
.		2 3
Update		3 9
;		9 :
public

 
sealed

 
record

 
UpdateOrderCommand

 '
:

( )
IRequest

* 2
<

2 3
Guid

3 7
>

7 8
{ 
[ 

JsonIgnore 
] 
public 

Guid 
Id 
{ 
get 
; 
set 
; 
}  
public 

decimal 

TotalPrice 
{ 
get  #
;# $
set% (
;( )
}* +
} 
public 
class 
UpdateOrderHandler 
{ 
} Õ
ÜC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Orders\Commands\Update\UpdateOrderDetailHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Orders# )
.) *
Commands* 2
.2 3
Update3 9
;9 :
public 
class $
UpdateOrderDetailCommand %
:& '
IRequest( 0
<0 1
Guid1 5
>5 6
{ 
[ 

JsonIgnore 
] 
public 

Guid 
Id 
{ 
get 
; 
set 
; 
}  
public 

Guid 
ComboId 
{ 
get 
; 
set "
;" #
}$ %
public 

Guid 
	ProductId 
{ 
get 
;  
set! $
;$ %
}& '
public 

string 
? 
Status 
{ 
get 
;  
set! $
;$ %
}& '
public 

int 
Quantity 
{ 
get 
; 
set "
;" #
}$ %
public 

decimal 
Price 
{ 
get 
; 
set  #
;# $
}% &
} 
public 
class $
UpdateOrderDetailHandler %
:& '
IRequestHandler( 7
<7 8$
UpdateOrderDetailCommand8 P
,P Q
GuidR V
>V W
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
public 
$
UpdateOrderDetailHandler #
(# $
IUnitOfWorks$ 0
unitOfWorks1 <
)< =
{ 
_unitOfWorks 
= 
unitOfWorks "
;" #
} 
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #$
UpdateOrderDetailCommand# ;
request< C
,C D
CancellationTokenE V
cancellationTokenW h
)h i
{ 
OrderDetail 
orderDetail 
=  !
await" '
_unitOfWorks( 4
.4 5!
OrderDetailRepository5 J
.J K
GetByIdAsyncK W
(W X
requestX _
._ `
Id` b
)b c
??d f
throwg l
newm p
	Exceptionq z
(z {
){ |
;| }
orderDetail   
.   
Update   
(   
request   "
.  " #
ComboId  # *
,  * +
request  , 3
.  3 4
	ProductId  4 =
,  = >
request  ? F
.  F G
Quantity  G O
,  O P
request  Q X
.  X Y
Price  Y ^
)  ^ _
;  _ `
_unitOfWorks!! 
.!! !
OrderDetailRepository!! *
.!!* +
Update!!+ 1
(!!1 2
orderDetail!!2 =
)!!= >
;!!> ?
await"" 
_unitOfWorks"" 
."" 
SaveChangeAsync"" *
(""* +
)""+ ,
;"", -
return## 
orderDetail## 
.## 
Id## 
;## 
}$$ 
}%% Ô'
ÖC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Orders\Commands\RefundOrder\RefundOrderHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Orders# )
.) *
Commands* 2
.2 3
RefundOrder3 >
;> ?
public 
record 
RefundOrderCommand  
(  !
Guid! %
OrderDetailId& 3
,3 4
int5 8
RefundQuantity9 G
)G H
:I J
IRequestK S
<S T
GuidT X
>X Y
{ 
[ 

JsonIgnore 
] 
public 

Guid 
OrderId 
{ 
get 
; 
set "
;" #
}$ %
} 
public 
class 
RefundOrderHandler 
(  
IUnitOfWorks  ,
unitOfWorks- 8
)8 9
:: ;
IRequestHandler< K
<K L
RefundOrderCommandL ^
,^ _
Guid` d
>d e
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #
RefundOrderCommand# 5
request6 =
,= >
CancellationToken? P
cancellationTokenQ b
)b c
{ 
var 
order 
= 
await 
_unitOfWorks &
.& '
OrderRepository' 6
.6 7
GetByIdAsync7 C
(C D
requestD K
.K L
OrderIdL S
,S T
oU V
=>W Y
oZ [
.[ \
OrderDetails\ h
)h i
?? 
throw 
new 
	Exception "
(" #
$str# @
)@ A
;A B
var 
orderDetail 
= 
order 
.  
OrderDetails  ,
., -
FirstOrDefault- ;
(; <
od< >
=>? A
odB D
.D E
IdE G
==H J
requestK R
.R S
OrderDetailIdS `
)` a
?? 
throw 
new 
	Exception "
(" #
$str# M
)M N
;N O
if 

( 
request 
. 
RefundQuantity "
># $
orderDetail% 0
.0 1
Quantity1 9
||: <
request= D
.D E
RefundQuantityE S
<=T V
$numW X
)X Y
{ 	
throw 
new 
	Exception 
(  
$str  @
)@ A
;A B
}   	
if"" 

("" 
request"" 
."" 
RefundQuantity"" "
==""# %
orderDetail""& 1
.""1 2
Quantity""2 :
)"": ;
{## 	
orderDetail$$ 
.$$ 
Status$$ 
=$$  
OrderDetailsStatus$$! 3
.$$3 4
Refund$$4 :
;$$: ;
}%% 	
else&& 
{'' 	
var(( 
remainingQuantity(( !
=((" #
orderDetail(($ /
.((/ 0
Quantity((0 8
-((9 :
request((; B
.((B C
RefundQuantity((C Q
;((Q R
orderDetail** 
.** 
Quantity**  
=**! "
remainingQuantity**# 4
;**4 5
var,, 
refundedOrderDetail,, #
=,,$ %
new,,& )
OrderDetail,,* 5
(,,5 6
orderDetail-- 
.-- 
ComboId-- #
,--# $
orderDetail.. 
... 
	ProductId.. %
,..% &
orderDetail// 
.// 
OrderId// #
,//# $
request00 
.00 
RefundQuantity00 &
,00& '
orderDetail11 
.11 
Price11 !
)22 
{33 
Status44 
=44 
OrderDetailsStatus44 +
.44+ ,
Refund44, 2
}55 
;55 
order77 
.77 
OrderDetails77 
.77 
Add77 "
(77" #
refundedOrderDetail77# 6
)776 7
;777 8
}88 	
_unitOfWorks:: 
.:: 
OrderRepository:: $
.::$ %
Update::% +
(::+ ,
order::, 1
)::1 2
;::2 3
await;; 
_unitOfWorks;; 
.;; 
SaveChangeAsync;; *
(;;* +
);;+ ,
;;;, -
return== 
order== 
.== 
Id== 
;== 
}>> 
}?? ÑC
ÖC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Orders\Commands\CreateOrder\CreateOrderHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Orders# )
.) *
Commands* 2
.2 3
CreateOrder3 >
;> ?
public 
record 
OrderDetailDto 
( 
Guid !
?! "
ComboId# *
,* +
Guid, 0
?0 1
	ProductId2 ;
,; <
int= @
QuantityA I
,I J
decimalK R
PriceS X
)X Y
{ 
[ 

JsonIgnore 
] 
public 

OrderDetailsStatus 
Status $
=% &
OrderDetailsStatus' 9
.9 :
Prepare: A
;A B
} 
public 
record )
CreateOrderWithTableIdCommand +
(+ ,
	OrderType 
	OrderType 
, 
DateTime 
	OrderTime 
, 
decimal 

TotalPrice 
, 
List 
< 	
OrderDetailDto	 
> 
OrderDetails %
) 
: 
IRequest 
< 
Guid 
> 
{ 
[ 

JsonIgnore 
] 
public 

OrderStatus 
OrderStatus "
=# $
OrderStatus% 0
.0 1
Prepare1 8
;8 9
[ 

JsonIgnore 
] 
public 

Guid 
TableId 
{ 
get 
; 
set "
;" #
}$ %
}   
public"" 
class"" 
CreateOrderHandler"" 
:""  !
IRequestHandler""" 1
<""1 2)
CreateOrderWithTableIdCommand""2 O
,""O P
Guid""Q U
>""U V
{## 
private$$ 
readonly$$ 
IUnitOfWorks$$ !
_unitOfWorks$$" .
;$$. /
private%% 
readonly%% 
	IDatabase%% 
	_database%% (
;%%( )
private&& 
readonly&&  
ConcurrentDictionary&& )
<&&) *
string&&* 0
,&&0 1
LockingHandler&&2 @
>&&@ A
_lockHandlers&&B O
;&&O P
public(( 

CreateOrderHandler(( 
((( 
IUnitOfWorks(( *
unitOfWorks((+ 6
,((6 7
	IDatabase((8 A
database((B J
)((J K
{)) 
_unitOfWorks** 
=** 
unitOfWorks** "
;**" #
	_database++ 
=++ 
database++ 
;++ 
_lockHandlers,, 
=,, 
new,,  
ConcurrentDictionary,, 0
<,,0 1
string,,1 7
,,,7 8
LockingHandler,,9 G
>,,G H
(,,H I
),,I J
;,,J K
}-- 
public// 

async// 
Task// 
<// 
Guid// 
>// 
Handle// "
(//" #)
CreateOrderWithTableIdCommand//# @
request//A H
,//H I
CancellationToken//J [
cancellationToken//\ m
)//m n
{00 
string11 
lockKey11 
=11 
$"11 
$str11 &
{11& '
request11' .
.11. /
TableId11/ 6
}116 7
"117 8
;118 9
LockingHandler22 
lockService22 "
;22" #
if44 

(44 
!44 
_lockHandlers44 
.44 
TryGetValue44 &
(44& '
lockKey44' .
,44. /
out440 3
lockService444 ?
)44? @
)44@ A
{55 	
lockService66 
=66 
new66 
LockingHandler66 ,
(66, -
	_database66- 6
,666 7
lockKey668 ?
,66? @
TimeSpan66A I
.66I J
FromSeconds66J U
(66U V
$num66V X
)66X Y
)66Y Z
;66Z [
_lockHandlers77 
.77 
TryAdd77  
(77  !
lockKey77! (
,77( )
lockService77* 5
)775 6
;776 7
}88 	
if:: 

(:: 
!:: 
await:: 
lockService:: 
.:: 
AcquireLockAsync:: /
(::/ 0
)::0 1
)::1 2
{;; 	
throw<< 
new<< 
	Exception<< 
(<<  
$str<<  X
)<<X Y
;<<Y Z
}== 	
var?? 
orders?? 
=?? 
await?? 
_unitOfWorks?? '
.??' (
OrderRepository??( 7
.??7 8
GetAllAsync??8 C
(??C D
)??D E
;??E F
var@@ 
tableOrders@@ 
=@@ 
orders@@  
.@@  !
Where@@! &
(@@& '
o@@' (
=>@@) +
o@@, -
.@@- .
TableId@@. 5
==@@6 8
request@@9 @
.@@@ A
TableId@@A H
)@@H I
.@@I J
ToList@@J P
(@@P Q
)@@Q R
;@@R S
ifBB 

(BB 
tableOrdersBB 
.BB 
AnyBB 
(BB 
oBB 
=>BB  
oBB! "
.BB" #
OrderStatusBB# .
!=BB/ 1
OrderStatusBB2 =
.BB= >
FinishBB> D
)BBD E
)BBE F
{CC 	
awaitDD 
lockServiceDD 
.DD 
ReleaseLockAsyncDD .
(DD. /
)DD/ 0
;DD0 1
throwEE 
newEE 
	ExceptionEE 
(EE  
$strEE  v
)EEv w
;EEw x
}FF 	
varHH 
orderHH 
=HH 
newHH 
DomainHH 
.HH 
EntitiesHH '
.HH' (
OrderAggregatorHH( 7
.HH7 8
OrderHH8 =
(HH= >
requestHH> E
.HHE F
	OrderTypeHHF O
,HHO P
requestHHQ X
.HHX Y
	OrderTimeHHY b
,HHb c
requestHHd k
.HHk l

TotalPriceHHl v
)HHv w
{II 	
TableIdJJ 
=JJ 
requestJJ 
.JJ 
TableIdJJ %
,JJ% &
OrderStatusKK 
=KK 
requestKK !
.KK! "
OrderStatusKK" -
,KK- .
OrderDetailsLL 
=LL 
newLL 
ListLL #
<LL# $
OrderDetailLL$ /
>LL/ 0
(LL0 1
)LL1 2
}MM 	
;MM	 

foreachOO 
(OO 
varOO 
detailOO 
inOO 
requestOO &
.OO& '
OrderDetailsOO' 3
)OO3 4
{PP 	
varQQ 
orderDetailQQ 
=QQ 
newQQ !
OrderDetailQQ" -
(QQ- .
detailRR 
.RR 
ComboIdRR 
,RR 
detailSS 
.SS 
	ProductIdSS  
,SS  !
nullTT 
,TT 
detailUU 
.UU 
QuantityUU 
,UU  
detailVV 
.VV 
PriceVV 
)WW 
{XX 
StatusYY 
=YY 
detailYY 
.YY  
StatusYY  &
}ZZ 
;ZZ 
order\\ 
.\\ 
OrderDetails\\ 
.\\ 
Add\\ "
(\\" #
orderDetail\\# .
)\\. /
;\\/ 0
}]] 	
await__ 
_unitOfWorks__ 
.__ 
OrderRepository__ *
.__* +
AddAsync__+ 3
(__3 4
order__4 9
)__9 :
;__: ;
await`` 
_unitOfWorks`` 
.`` 
SaveChangeAsync`` *
(``* +
)``+ ,
;``, -
ifbb 

(bb 
requestbb 
.bb 
OrderStatusbb 
==bb  "
OrderStatusbb# .
.bb. /
Finishbb/ 5
)bb5 6
{cc 	
awaitdd 
lockServicedd 
.dd 
ReleaseLockAsyncdd .
(dd. /
)dd/ 0
;dd0 1
}ee 	
returngg 
ordergg 
.gg 
Idgg 
;gg 
}hh 
}ii ì
çC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Orders\Commands\ChangeState\ConfirmOrderToServeHandler.cs
	namespace

 	
FOV


 
.

 
Application

 
.

 
Features

 "
.

" #
Orders

# )
.

) *
Commands

* 2
.

2 3
ChangeStateOrder

3 C
;

C D
public 
record &
ConfirmOrderToServeCommand (
(( )
Guid) -
OrderId. 5
)5 6
:7 8
IRequest9 A
<A B
GuidB F
>F G
;G H
public 
class &
ConfirmOrderToServeHandler '
(' (
IUnitOfWorks( 4
unitOfWorks5 @
)@ A
:B C
IRequestHandlerD S
<S T&
ConfirmOrderToServeCommandT n
,n o
Guidp t
>t u
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #&
ConfirmOrderToServeCommand# =
request> E
,E F
CancellationTokenG X
cancellationTokenY j
)j k
{ 
var 
order 
= 
await 
_unitOfWorks &
.& '
OrderRepository' 6
.6 7
GetByIdAsync7 C
(C D
requestD K
.K L
OrderIdL S
,S T
oU V
=>W Y
oZ [
.[ \
OrderDetails\ h
)h i
?? 
throw 
new 
	Exception "
(" #
$str# <
)< =
;= >
order 
. 
OrderStatus 
= 
OrderStatus '
.' (
Service( /
;/ 0
foreach 
( 
var 
detail 
in 
order $
.$ %
OrderDetails% 1
)1 2
{ 	
detail 
. 
Status 
= 
OrderDetailsStatus .
.. /
Service/ 6
;6 7
} 	
_unitOfWorks 
. 
OrderRepository $
.$ %
Update% +
(+ ,
order, 1
)1 2
;2 3
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
order 
. 
Id 
; 
} 
}   ä
åC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Orders\Commands\ChangeState\ConfirmOrderToCookHandler.cs
	namespace

 	
FOV


 
.

 
Application

 
.

 
Features

 "
.

" #
Orders

# )
.

) *
Commands

* 2
.

2 3
ChangeStateOrder

3 C
;

C D
public 
record %
ConfirmOrderToCookCommand '
(' (
Guid( ,
OrderId- 4
)4 5
:6 7
IRequest8 @
<@ A
GuidA E
>E F
;F G
public 
class %
ConfirmOrderToCookHandler &
:' (
IRequestHandler) 8
<8 9%
ConfirmOrderToCookCommand9 R
,R S
GuidT X
>X Y
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
public 
%
ConfirmOrderToCookHandler $
($ %
IUnitOfWorks% 1
unitOfWorks2 =
)= >
{ 
_unitOfWorks 
= 
unitOfWorks "
;" #
} 
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #%
ConfirmOrderToCookCommand# <
request= D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
{ 
var 
order 
= 
await 
_unitOfWorks &
.& '
OrderRepository' 6
.6 7
GetByIdAsync7 C
(C D
requestD K
.K L
OrderIdL S
,S T
oU V
=>W Y
oZ [
.[ \
OrderDetails\ h
)h i
?? 
throw 
new 
	Exception "
(" #
$str# <
)< =
;= >
order 
. 
OrderStatus 
= 
OrderStatus '
.' (
Cook( ,
;, -
foreach 
( 
var 
detail 
in 
order $
.$ %
OrderDetails% 1
)1 2
{ 	
detail 
. 
Status 
= 
OrderDetailsStatus .
.. /
Cook/ 3
;3 4
} 	
_unitOfWorks 
. 
OrderRepository $
.$ %
Update% +
(+ ,
order, 1
)1 2
;2 3
await   
_unitOfWorks   
.   
SaveChangeAsync   *
(  * +
)  + ,
;  , -
return"" 
order"" 
."" 
Id"" 
;"" 
}## 
}$$ Ö
åC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Orders\Commands\AddProduct\AddProductsToOrdersHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Orders# )
.) *
Commands* 2
.2 3

AddProduct3 =
;= >
public 
record &
AddProductsToOrdersCommand (
(( )
List) -
<- .
OrderDetailDto. <
>< =
NewOrderDetails> M
)M N
:O P
IRequestQ Y
<Y Z
GuidZ ^
>^ _
{ 
[ 

JsonIgnore 
] 
public 

Guid 
OrderId 
{ 
get 
; 
set "
;" #
}$ %
} 
public 
class &
AddProductsToOrdersHandler '
(' (
IUnitOfWorks( 4
unitOfWorks5 @
)@ A
:B C
IRequestHandlerD S
<S T&
AddProductsToOrdersCommandT n
,n o
Guidp t
>t u
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #&
AddProductsToOrdersCommand# =
request> E
,E F
CancellationTokenG X
cancellationTokenY j
)j k
{ 
var 
orders 
= 
await 
_unitOfWorks '
.' (
OrderRepository( 7
.7 8
GetByIdAsync8 D
(D E
requestE L
.L M
OrderIdM T
,T U
oV W
=>X Z
o[ \
.\ ]
OrderDetails] i
)i j
?? 
throw 
new 
	Exception "
(" #
$str# <
)< =
;= >
foreach 
( 
var 
detail 
in 
request &
.& '
NewOrderDetails' 6
)6 7
{ 	
var 
orderDetail 
= 
new !
OrderDetail" -
(- .
detail 
. 
ComboId "
," #
detail 
. 
	ProductId $
,$ %
null   
,   
detail!! 
.!! 
Quantity!! #
,!!# $
detail"" 
."" 
Price""  
)## 
{$$ 
Status%% 
=%% 
detail%% 
.%%  
Status%%  &
}&& 
;&& 
orders(( 
.(( 
OrderDetails(( 
.((  
Add((  #
(((# $
orderDetail(($ /
)((/ 0
;((0 1
})) 	
orders** 
.** 
OrderStatus** 
=** 
Domain** #
.**# $
Entities**$ ,
.**, -
OrderAggregator**- <
.**< =
Enums**= B
.**B C
OrderStatus**C N
.**N O
Cook**O S
;**S T
_unitOfWorks,, 
.,, 
OrderRepository,, $
.,,$ %
Update,,% +
(,,+ ,
orders,,, 2
),,2 3
;,,3 4
await-- 
_unitOfWorks-- 
.-- 
SaveChangeAsync-- *
(--* +
)--+ ,
;--, -
return// 
orders// 
.// 
Id// 
;// 
}00 
}11 ˛*
ñC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\NewRecommendProducts\Queries\GetAll\GetNewProductRecommendQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." # 
NewRecommendProducts# 7
.7 8
Queries8 ?
.? @
GetAll@ F
;F G
public 
sealed 
record )
GetNewProductRecommendCommand 2
(2 3
PagingRequest3 @
?@ A
PagingRequestB O
)O P
:Q R
IRequestS [
<[ \
PagedResult\ g
<g h+
GetNewProductRecommendResponse	h Ü
>
Ü á
>
á à
;
à â
public 
sealed 
record *
GetNewProductRecommendResponse 3
(3 4
Guid4 8
Id9 ;
,; <
string= C
ProductNameD O
,O P
stringQ W
StatusX ^
)^ _
;_ `
public 
sealed 
class '
GetNewProductRecommendQuery /
(/ 0
IUnitOfWorks0 <
unitOfWorks= H
,H I
IClaimServiceJ W
claimServiceX d
)d e
:f g
IRequestHandlerh w
<w x*
GetNewProductRecommendCommand	x ï
,
ï ñ
PagedResult
ó ¢
<
¢ £,
GetNewProductRecommendResponse
£ ¡
>
¡ ¬
>
¬ √
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
IClaimService "
_claimService# 0
=1 2
claimService3 ?
;? @
public 

async 
Task 
< 
PagedResult !
<! "*
GetNewProductRecommendResponse" @
>@ A
>A B
HandleC I
(I J)
GetNewProductRecommendCommandJ g
requesth o
,o p
CancellationToken	q Ç
cancellationToken
É î
)
î ï
{ 
List 
< 
NewProductRecommend  
>  !
response" *
=+ ,
new- 0
List1 5
<5 6
NewProductRecommend6 I
>I J
(J K
)K L
;L M
if 

( 
_claimService 
. 
UserRole "
==# %
Role& *
.* +
Administrator+ 8
)8 9
response: B
=C D
awaitE J
_unitOfWorksK W
.W X)
NewProductRecommendRepositoryX u
.u v
GetAllAsync	v Å
(
Å Ç
x
Ç É
=>
Ñ Ü
x
á à
.
à â
ProductGeneral
â ó
)
ó ò
;
ò ô
if 

( 
_claimService 
. 
UserRole "
==# %
Role& *
.* +
Manager+ 2
)2 3
response4 <
== >
await? D
_unitOfWorksE Q
.Q R)
NewProductRecommendRepositoryR o
.o p

WhereAsyncp z
(z {
x{ |
=>} 
x
Ä Å
.
Å Ç
RestaurantId
Ç é
==
è ë
_claimService
í ü
.
ü †
RestaurantId
† ¨
,
¨ ≠
x
Æ Ø
=>
∞ ≤
x
≥ ¥
.
¥ µ
ProductGeneral
µ √
)
√ ƒ
;
ƒ ≈
var 
result 
= 
response 
. 
Select $
($ %
x% &
=>' )
new* -*
GetNewProductRecommendResponse. L
(L M
xM N
.N O
IdO Q
,Q R
xS T
.T U
ProductGeneralU c
.c d
ProductNamed o
,o p
xq r
.r s
Statuss y
.y z
ToString	z Ç
(
Ç É
)
É Ñ
)
Ñ Ö
)
Ö Ü
;
Ü á
var 
( 
page 
, 
pageSize 
, 
sortType %
,% &
	sortField' 0
)0 1
=2 3
PaginationUtils4 C
.C D)
GetPaginationAndSortingValuesD a
(a b
requestb i
.i j
PagingRequestj w
)w x
;x y
var 
sortedResults 
= 
PaginationHelper ,
<, -*
GetNewProductRecommendResponse- K
>K L
.L M
SortingM T
(T U
sortTypeU ]
,] ^
result_ e
,e f
	sortFieldg p
)p q
;q r
var 
resulted 
= 
PaginationHelper '
<' (*
GetNewProductRecommendResponse( F
>F G
.G H
PagingH N
(N O
sortedResultsO \
,\ ]
page^ b
,b c
pageSized l
)l m
;m n
return 
resulted 
; 
}   
}!! ¨#
óC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\NewRecommendProducts\Commands\UpdateRequest\UpdateRequestHandler.cs
	namespace

 	
FOV


 
.

 
Application

 
.

 
Features

 "
.

" # 
NewRecommendProducts

# 7
.

7 8
Commands

8 @
.

@ A
UpdateRequest

A N
;

N O
public 
sealed 
record  
UpdateRequestCommand )
() *
string* 0
Name1 5
,5 6
string7 =
Description> I
,I J
GuidK O

CategoryIdP Z
,Z [
string\ b
Imagec h
,h i
stringj p
Noteq u
)u v
:w x
IRequest	y Å
<
Å Ç
Result
Ç à
>
à â
{ 
[ 

JsonIgnore 
] 
public 

Guid !
NewRecommendProductId %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
internal 
class	  
UpdateRequestHandler #
(# $
IUnitOfWorks$ 0
unitOfWorks1 <
,< =
IClaimService> K
claimServiceL X
)X Y
:Z [
IRequestHandler\ k
<k l!
UpdateRequestCommand	l Ä
,
Ä Å
Result
Ç à
>
à â
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
IClaimService "
_claimService# 0
=1 2
claimService3 ?
;? @
public 

async 
Task 
< 
Result 
> 
Handle $
($ % 
UpdateRequestCommand% 9
request: A
,A B
CancellationTokenC T
cancellationTokenU f
)f g
{ 
NewProductRecommend 
productRecommend ,
=- .
await/ 4
_unitOfWorks5 A
.A B)
NewProductRecommendRepositoryB _
._ `
GetByIdAsync` l
(l m
requestm t
.t u"
NewRecommendProductId	u ä
)
ä ã
??
å é
throw
è î
new
ï ò
	Exception
ô ¢
(
¢ £
)
£ §
;
§ •
productRecommend 
. 
UpdateState $
($ %%
NewProductRecommendStatus% >
.> ?
Pending? F
)F G
;G H"
NewProductRecommendLog 
recommendLog +
=, -
new. 1
(1 2
request2 9
.9 :
Note: >
,> ?
productRecommend@ P
.P Q
IdQ S
,S T
LogTypeU \
.\ ]
Request] d
,d e
_claimServicef s
.s t
UserIdt z
)z {
;{ |
await 
_unitOfWorks 
. ,
 NewProductRecommendLogRepository ;
.; <
AddAsync< D
(D E
recommendLogE Q
)Q R
;R S
ProductGeneral 
productGeneral %
=& '
await( -
_unitOfWorks. :
.: ;$
ProductGeneralRepository; S
.S T
GetByIdAsyncT `
(` a
productRecommenda q
.q r
ProductGeneralId	r Ç
)
Ç É
??
Ñ Ü
throw
á å
new
ç ê
	Exception
ë ö
(
ö õ
)
õ ú
;
ú ù
productGeneral   
.   
Update   
(   
request   %
.  % &
Name  & *
,  * +
request  , 3
.  3 4
Description  4 ?
,  ? @
request  A H
.  H I
Image  I N
,  N O
request  P W
.  W X

CategoryId  X b
)  b c
;  c d
await!! 
_unitOfWorks!! 
.!! 
SaveChangeAsync!! *
(!!* +
)!!+ ,
;!!, -
return"" 
Result"" 
."" 
Ok"" 
("" 
)"" 
;"" 
}&& 
}'' ˙2
ëC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\NewRecommendProducts\Commands\NewRequest\NewRequestHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." # 
NewRecommendProducts# 7
.7 8
Commands8 @
.@ A

NewRequestA K
;K L
public

 
sealed

 
record

 
NewRequestCommand

 &
:

' (
IRequest

) 1
<

1 2
Guid

2 6
>

6 7
{ 
public 

required 
string 
ProductName &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 

required 
string 
ProductDescription -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 

required 
Guid 

CategoryId #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 

required 
string 
ProductImage '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 

string 
Note 
{ 
get 
; 
set !
;! "
}# $
=% &
string' -
.- .
Empty. 3
;3 4
public 

List 
< &
IngredientInRequestCommand *
>* +
Ingredients, 7
{8 9
get: =
;= >
set? B
;B C
}D E
=F G
[H I
]I J
;J K
} 
public 
sealed 
record &
IngredientInRequestCommand /
(/ 0
Guid0 4
IngredientId5 A
,A B
decimalC J
QuantityK S
)S T
;T U
public 
class 
NewRequestHandler 
( 
IUnitOfWorks +
unitOfWorks, 7
,7 8
IClaimService9 F
claimServiceG S
)S T
:U V
IRequestHandlerW f
<f g
NewRequestCommandg x
,x y
Guidz ~
>~ 
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private   
readonly   
IClaimService   "
_claimService  # 0
=  1 2
claimService  3 ?
;  ? @
public!! 

async!! 
Task!! 
<!! 
Guid!! 
>!! 
Handle!! "
(!!" #
NewRequestCommand!!# 4
request!!5 <
,!!< =
CancellationToken!!> O
cancellationToken!!P a
)!!a b
{"" 
ProductGeneral$$ 
productGeneral$$ %
=$$& '
new$$( +
($$+ ,
request$$, 3
.$$3 4
ProductName$$4 ?
,$$? @
request$$A H
.$$H I
ProductDescription$$I [
,$$[ \
request$$] d
.$$d e

CategoryId$$e o
,$$o p
request$$q x
.$$x y
ProductImage	$$y Ö
,
$$Ö Ü
true
$$á ã
)
$$ã å
;
$$å ç
await%% 
_unitOfWorks%% 
.%% $
ProductGeneralRepository%% 3
.%%3 4
AddAsync%%4 <
(%%< =
productGeneral%%= K
)%%K L
;%%L M
await'' 
AddIngredient'' 
('' 
request'' #
.''# $
Ingredients''$ /
,''/ 0
productGeneral''1 ?
.''? @
Id''@ B
)''B C
;''C D
NewProductRecommend)) 
newRecommend)) (
=))) *
new))+ .
()). /
_claimService))/ <
.))< =
RestaurantId))= I
,))I J
productGeneral))K Y
.))Y Z
Id))Z \
,))\ ]%
NewProductRecommendStatus))^ w
.))w x
Pending))x 
)	)) Ä
;
))Ä Å
await** 
_unitOfWorks** 
.** )
NewProductRecommendRepository** 8
.**8 9
AddAsync**9 A
(**A B
newRecommend**B N
)**N O
;**O P"
NewProductRecommendLog,, 
recommendLog,, +
=,,, -
new,,. 1
(,,1 2
request,,2 9
.,,9 :
Note,,: >
,,,> ?
newRecommend,,@ L
.,,L M
Id,,M O
,,,O P
LogType,,Q X
.,,X Y
Request,,Y `
,,,` a
_claimService,,b o
.,,o p
UserId,,p v
),,v w
;,,w x
await-- 
_unitOfWorks-- 
.-- ,
 NewProductRecommendLogRepository-- ;
.--; <
AddAsync--< D
(--D E
recommendLog--E Q
)--Q R
;--R S
await// 
_unitOfWorks// 
.// 
SaveChangeAsync// *
(//* +
)//+ ,
;//, -
return00 
newRecommend00 
.00 
Id00 
;00 
}33 
private44 
async44 
	ValueTask44 
AddIngredient44 )
(44) *
List44* .
<44. /&
IngredientInRequestCommand44/ I
>44I J
commands44K S
,44S T
Guid44U Y
	productId44Z c
)44c d
{55 
var66 %
productIngredientGenerals66 %
=66& '
commands66( 0
.77 
Select77 
(77 
command77 
=>77 
new77 "$
ProductIngredientGeneral77# ;
(77; <
	productId77< E
,77E F
command77G N
.77N O
IngredientId77O [
,77[ \
command77] d
.77d e
Quantity77e m
)77m n
)77n o
.88 
ToList88 
(88 
)88 
;88 
await:: 
_unitOfWorks:: 
.:: .
"ProductIngredientGeneralRepository:: =
.::= >
AddRangeAsync::> K
(::K L%
productIngredientGenerals::L e
)::e f
;::f g
};; 
}>> Û
£C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\NewRecommendProducts\Commands\NeedsUpdateResponse\NeedsUpdateResponseHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" # 
NewRecommendProducts		# 7
.		7 8
Commands		8 @
.		@ A
NeedsUpdateResponse		A T
;		T U
public 
sealed 
record &
NeedsUpdateResponseCommand /
(/ 0
string0 6
Note7 ;
); <
:= >
IRequest? G
<G H
ResultH N
>N O
{ 
[ 

JsonIgnore 
] 
public 

Guid !
NewRecommendProductId %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
internal 
class	 &
NeedsUpdateResponseHandler )
() *
IUnitOfWorks* 6
unitOfWorks7 B
,B C
IClaimServiceD Q
claimServiceR ^
)^ _
:` a
IRequestHandlerb q
<q r'
NeedsUpdateResponseCommand	r å
,
å ç
Result
é î
>
î ï
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
IClaimService "
_claimService# 0
=1 2
claimService3 ?
;? @
public 

async 
Task 
< 
Result 
> 
Handle $
($ %&
NeedsUpdateResponseCommand% ?
request@ G
,G H
CancellationTokenI Z
cancellationToken[ l
)l m
{ 
NewProductRecommend 
productRecommend ,
=- .
await/ 4
_unitOfWorks5 A
.A B)
NewProductRecommendRepositoryB _
._ `
GetByIdAsync` l
(l m
requestm t
.t u"
NewRecommendProductId	u ä
)
ä ã
??
å é
throw
è î
new
ï ò
	Exception
ô ¢
(
¢ £
)
£ §
;
§ •
productRecommend 
. 
UpdateState $
($ %%
NewProductRecommendStatus% >
.> ?
NeedsUpdate? J
)J K
;K L"
NewProductRecommendLog 
recommendLog +
=, -
new. 1
(1 2
request2 9
.9 :
Note: >
,> ?
productRecommend@ P
.P Q
IdQ S
,S T
LogTypeU \
.\ ]
Response] e
,e f
_claimServiceg t
.t u
UserIdu {
){ |
;| }
await 
_unitOfWorks 
. ,
 NewProductRecommendLogRepository ;
.; <
AddAsync< D
(D E
recommendLogE Q
)Q R
;R S
_unitOfWorks 
. )
NewProductRecommendRepository 2
.2 3
Update3 9
(9 :
productRecommend: J
)J K
;K L
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return   
Result   
.   
Ok   
(   
)   
;   
}!! 
}"" ∫
ïC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\NewRecommendProducts\Commands\DenyResponse\DenyResponseHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" # 
NewRecommendProducts		# 7
.		7 8
Commands		8 @
.		@ A
DenyResponse		A M
;		M N
public 
sealed 
record 
DenyResponseCommand (
(( )
string) /
Note0 4
)4 5
:6 7
IRequest8 @
<@ A
ResultA G
>G H
{ 
[ 

JsonIgnore 
] 
public 

Guid !
NewProductRecommendId %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
internal 
class	 
DenyResponseHandler "
(" #
IUnitOfWorks# /
unitOfWorks0 ;
,; <
IClaimService= J
claimServiceK W
)W X
:Y Z
IRequestHandler[ j
<j k
DenyResponseCommandk ~
,~ 
Result
Ä Ü
>
Ü á
{ 
private 
readonly 
IClaimService "
_claimService# 0
=1 2
claimService3 ?
;? @
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %
DenyResponseCommand% 8
request9 @
,@ A
CancellationTokenB S
cancellationTokenT e
)e f
{ 
NewProductRecommend 
productRecommend ,
=- .
await/ 4
_unitOfWorks5 A
.A B)
NewProductRecommendRepositoryB _
._ `
GetByIdAsync` l
(l m
requestm t
.t u"
NewProductRecommendId	u ä
)
ä ã
??
å é
throw
è î
new
ï ò
	Exception
ô ¢
(
¢ £
)
£ §
;
§ •
productRecommend 
. 
UpdateState $
($ %%
NewProductRecommendStatus% >
.> ?
Denied? E
)E F
;F G"
NewProductRecommendLog 
recommendLog +
=, -
new. 1
(1 2
request2 9
.9 :
Note: >
,> ?
productRecommend@ P
.P Q
IdQ S
,S T
LogTypeU \
.\ ]
Response] e
,e f
_claimServiceg t
.t u
UserIdu {
){ |
;| }
await 
_unitOfWorks 
. ,
 NewProductRecommendLogRepository ;
.; <
AddAsync< D
(D E
recommendLogE Q
)Q R
;R S
_unitOfWorks 
. )
NewProductRecommendRepository 2
.2 3
Update3 9
(9 :
productRecommend: J
)J K
;K L
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
}   ◊"
õC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\NewRecommendProducts\Commands\ApproveResponse\ApproveResponseHandler.cs
	namespace

 	
FOV


 
.

 
Application

 
.

 
Features

 "
.

" # 
NewRecommendProducts

# 7
.

7 8
Commands

8 @
.

@ A
ApproveResponse

A P
;

P Q
public 
sealed 
record "
ApproveResponseCommand +
(+ ,
string, 2
Note3 7
)7 8
:9 :
IRequest; C
<C D
ResultD J
>J K
{ 
[ 

JsonIgnore 
] 
public 

Guid !
NewProductRecommendId %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
public 
class "
ApproveResponseHandler #
(# $
IUnitOfWorks$ 0
unitOfWorks1 <
,< =
IClaimService> K
claimServiceL X
)X Y
:Z [
IRequestHandler\ k
<k l#
ApproveResponseCommand	l Ç
,
Ç É
Result
Ñ ä
>
ä ã
{ 
private 
readonly 
IClaimService "
_claimService# 0
=1 2
claimService3 ?
;? @
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %"
ApproveResponseCommand% ;
request< C
,C D
CancellationTokenE V
cancellationTokenW h
)h i
{ 
NewProductRecommend 
productRecommend ,
=- .
await/ 4
_unitOfWorks5 A
.A B)
NewProductRecommendRepositoryB _
._ `
GetByIdAsync` l
(l m
requestm t
.t u"
NewProductRecommendId	u ä
)
ä ã
??
å é
throw
è î
new
ï ò
	Exception
ô ¢
(
¢ £
)
£ §
;
§ •
productRecommend 
. 
UpdateState $
($ %%
NewProductRecommendStatus% >
.> ?
Approved? G
)G H
;H I"
NewProductRecommendLog 
recommendLog +
=, -
new. 1
(1 2
request2 9
.9 :
Note: >
,> ?
productRecommend@ P
.P Q
IdQ S
,S T
LogTypeU \
.\ ]
Response] e
,e f
_claimServiceg t
.t u
UserIdu {
){ |
;| }
await 
_unitOfWorks 
. ,
 NewProductRecommendLogRepository ;
.; <
AddAsync< D
(D E
recommendLogE Q
)Q R
;R S
_unitOfWorks 
. )
NewProductRecommendRepository 2
.2 3
Update3 9
(9 :
productRecommend: J
)J K
;K L
ProductGeneral 
productGeneral %
=& '
await( -
_unitOfWorks. :
.: ;$
ProductGeneralRepository; S
.S T
GetByIdAsyncT `
(` a
productRecommenda q
.q r
ProductGeneralId	r Ç
)
Ç É
??
Ñ Ü
throw
á å
new
ç ê
	Exception
ë ö
(
ö õ
)
õ ú
;
ú ù
productGeneral 
. 
SetDraftState $
($ %
false% *
)* +
;+ ,
_unitOfWorks   
.   $
ProductGeneralRepository   -
.  - .
Update  . 4
(  4 5
productGeneral  5 C
)  C D
;  D E
await"" 
_unitOfWorks"" 
."" 
SaveChangeAsync"" *
(""* +
)""+ ,
;"", -
return## 
Result## 
.## 
Ok## 
(## 
)## 
;## 
}'' 
}(( ¡
óC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\NewRecommendProducts\Commands\AdjustRequest\AdjustRequestHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." # 
NewRecommendProducts# 7
.7 8
Commands8 @
.@ A
AdjustRequestA N
;N O
public

 
sealed

 
record

  
AdjustRequestCommand

 )
(

) *
string

* 0
Name

1 5
,

5 6
string

7 =
Description

> I
,

I J
string

K Q
Image

R W
)

W X
:

Y Z
IRequest

[ c
<

c d
Result

d j
>

j k
{ 
[ 

JsonIgnore 
] 
public 

Guid 
RecommendProductId "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
internal 
class	  
AdjustRequestHandler #
(# $
IUnitOfWorks$ 0
unitOfWorks1 <
)< =
:> ?
IRequestHandler@ O
<O P 
AdjustRequestCommandP d
,d e
Resultf l
>l m
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ % 
AdjustRequestCommand% 9
request: A
,A B
CancellationTokenC T
cancellationTokenU f
)f g
{ 
NewProductRecommend 
? 
newProductRecommend 0
=1 2
await3 8
_unitOfWorks9 E
.E F)
NewProductRecommendRepositoryF c
.c d
GetByIdAsyncd p
(p q
requestq x
.x y
RecommendProductId	y ã
)
ã å
;
å ç
ProductGeneral 
? 
productGeneral &
=' (
await) .
_unitOfWorks/ ;
.; <$
ProductGeneralRepository< T
.T U
GetByIdAsyncU a
(a b
newProductRecommendb u
.u v
ProductGeneralId	v Ü
)
Ü á
;
á à
productGeneral 
. 
Update 
( 
request %
.% &
Name& *
,* +
request, 3
.3 4
Description4 ?
,? @
requestA H
.H I
ImageI N
)N O
;O P
_unitOfWorks 
. $
ProductGeneralRepository -
.- .
Update. 4
(4 5
productGeneral5 C
)C D
;D E
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} À
óC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientUnits\Queries\GetIngredientUnit\GetIngredientUnitQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientUnits# 2
.2 3
Queries3 :
.: ;
GetIngredientUnit; L
;L M
public 
sealed 
record $
GetIngredientUnitCommand -
(- .
Guid. 2
IngredientId3 ?
)? @
:A B
IRequestC K
<K L
ListL P
<P Q%
GetIngredientUnitResponseQ j
>j k
>k l
;l m
public

 
sealed

 
record

 %
GetIngredientUnitResponse

 .
(

. /
Guid

/ 3
IngredientUnitId

4 D
,

D E
Guid

F J
?

J K"
IngredientUnitParentId

L b
,

b c
string

d j
UnitName

k s
,

s t
decimal

u |
ConversionFactor	

} ç
)


ç é
;


é è
public 
class "
GetIngredientUnitQuery #
(# $
IUnitOfWorks$ 0
unitOfWorks1 <
)< =
:> ?
IRequestHandler@ O
<O P$
GetIngredientUnitCommandP h
,h i
Listj n
<n o&
GetIngredientUnitResponse	o à
>
à â
>
â ä
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
List 
< %
GetIngredientUnitResponse 4
>4 5
>5 6
Handle7 =
(= >$
GetIngredientUnitCommand> V
requestW ^
,^ _
CancellationToken` q
cancellationToken	r É
)
É Ñ
{ 
List 
< 
IngredientUnit 
> 
ingredientUnits ,
=- .
await/ 4
_unitOfWorks5 A
.A B$
IngredientUnitRepositoryB Z
.Z [

WhereAsync[ e
(e f
xf g
=>h j
xk l
.l m
IngredientIdm y
==z |
request	} Ñ
.
Ñ Ö
IngredientId
Ö ë
)
ë í
;
í ì
return 
ingredientUnits 
. 
Select %
(% &
x& '
=>( *
x+ ,
., -#
MapperIngredientUnitDTO- D
(D E
)E F
)F G
.G H
ToListH N
(N O
)O P
;P Q
} 
} â	
ÇC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientUnits\Mapper\IngredientUnitMapper.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientUnits# 2
.2 3
Mapper3 9
;9 :
public 
static 
class  
IngredientUnitMapper (
{ 
public 

static %
GetIngredientUnitResponse +#
MapperIngredientUnitDTO, C
(C D
thisD H
IngredientUnitI W
ingredientUnitX f
)f g
{ 
return		 
new		 %
GetIngredientUnitResponse		 ,
(		, -
ingredientUnit		- ;
.		; <
Id		< >
,		> ?
ingredientUnit		@ N
.		N O"
IngredientUnitParentId		O e
,		e f
ingredientUnit		g u
.		u v
UnitName		v ~
,		~ 
ingredientUnit
		Ä é
.
		é è
ConversionFactor
		è ü
)
		ü †
;
		† °
}

 
} Œ
íC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientUnits\Commands\Update\UpdateIngredientUnitHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientUnits# 2
.2 3
Commands3 ;
.; <
Update< B
;B C
public		 
sealed		 
record		 '
UpdateIngredientUnitCommand		 0
(		0 1
string		1 7
UnitName		8 @
,		@ A
decimal		B I
ConversionFactor		J Z
)		Z [
:		\ ]
IRequest		^ f
<		f g
Result		g m
>		m n
{

 
[ 
JsonInclude 
] 
public 

Guid 
IngredientUnitId  
{! "
get# &
;& '
set( +
;+ ,
}- .
} 
public 
class '
UpdateIngredientUnitHandler (
(( )
IUnitOfWorks) 5
unitOfWorks6 A
)A B
:C D
IRequestHandlerE T
<T U'
UpdateIngredientUnitCommandU p
,p q
Resultr x
>x y
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %'
UpdateIngredientUnitCommand% @
requestA H
,H I
CancellationTokenJ [
cancellationToken\ m
)m n
{ 
IngredientUnit 
ingredientUnit %
=& '
await( -
_unitOfWorks. :
.: ;$
IngredientUnitRepository; S
.S T
GetByIdAsyncT `
(` a
requesta h
.h i
IngredientUnitIdi y
)y z
??{ }
throw	~ É
new
Ñ á
	Exception
à ë
(
ë í
)
í ì
;
ì î
ingredientUnit 
. 
Update 
( 
request %
.% &
UnitName& .
,. /
request0 7
.7 8
ConversionFactor8 H
)H I
;I J
_unitOfWorks 
. $
IngredientUnitRepository -
.- .
Update. 4
(4 5
ingredientUnit5 C
)C D
;D E
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ≤
¶C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientUnits\Commands\CreateNewIngredientUnit\CreateNewIngredientUnitHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientUnits# 2
.2 3
Commands3 ;
.; <#
CreateNewIngredientUnit< S
;S T
public		 
sealed		 
record		 *
CreateNewIngredientUnitCommand		 3
(		3 4
string		4 :
UnitName		; C
,		C D
decimal		E L
ConversionFactor		M ]
,		] ^
Guid		_ c"
IngredientUnitParentId		d z
,		z {
Guid			| Ä
IngredientId
		Å ç
)
		ç é
:
		è ê
IRequest
		ë ô
<
		ô ö
Result
		ö †
>
		† °
;
		° ¢
public 
class *
CreateNewIngredientUnitHandler +
(+ ,
IUnitOfWorks, 8
unitOfWorks9 D
,D E
IClaimServiceF S
claimServiceT `
)` a
:b c
IRequestHandlerd s
<s t+
CreateNewIngredientUnitCommand	t í
,
í ì
Result
î ö
>
ö õ
{ 
private 
readonly 
IClaimService "
_claimService# 0
=1 2
claimService3 ?
;? @
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %*
CreateNewIngredientUnitCommand% C
requestD K
,K L
CancellationTokenM ^
cancellationToken_ p
)p q
{ 
IngredientUnit 
ingredientUnit %
=& '
new( +
(+ ,
request, 3
.3 4
UnitName4 <
,< =
request> E
.E F
IngredientIdF R
,R S
requestT [
.[ \"
IngredientUnitParentId\ r
,r s
requestt {
.{ |
ConversionFactor	| å
)
å ç
;
ç é
await 
_unitOfWorks 
. $
IngredientUnitRepository 3
.3 4
AddAsync4 <
(< =
ingredientUnit= K
)K L
;L M
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} Ã
¢C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientTypes\Queries\GetParentCategories\GetParentIngredientTypesHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientTypes# 2
.2 3
Queries3 :
.: ;
GetParentCategories; N
;N O
public 
sealed 
record &
GetParentCategoriesCommand /
:0 1
IRequest2 :
<: ;
List; ?
<? @'
GetParentCategoriesResponse@ [
>[ \
>\ ]
;] ^
public 
record '
GetParentCategoriesResponse )
() *
Guid* .
Id/ 1
,1 2
string3 9
Name: >
,> ?
string@ F
DesG J
)J K
;K L
public

 
class

 +
GetParentIngredientTypesHandler

 ,
(

, -
IUnitOfWorks

- 9
unitOfWorks

: E
)

E F
:

G H
IRequestHandler

I X
<

X Y&
GetParentCategoriesCommand

Y s
,

s t
List

u y
<

y z(
GetParentCategoriesResponse	

z ï
>


ï ñ
>


ñ ó
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
List 
< '
GetParentCategoriesResponse 6
>6 7
>7 8
Handle9 ?
(? @&
GetParentCategoriesCommand@ Z
request[ b
,b c
CancellationTokend u
cancellationToken	v á
)
á à
{ 
var 
data 
= 
await 
_unitOfWorks %
.% &$
IngredientTypeRepository& >
.> ?

WhereAsync? I
(I J
xJ K
=>L N
xO P
.P Q
ParentIdQ Y
==Z \
null] a
)a b
;b c
return 
data 
. 
Select 
( 
x 
=> 
new  #'
GetParentCategoriesResponse$ ?
(? @
x@ A
.A B
IdB D
,D E
xF G
.G H
IngredientNameH V
,V W
xX Y
.Y Z!
IngredientDescriptionZ o
)o p
)p q
.q r
ToListr x
(x y
)y z
;z {
} 
} ÿ
§C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientTypes\Queries\GetChildIngrdientTypes\GetChildIngredientTypesHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientTypes# 2
.2 3
Queries3 :
.: ;
GetChildCategories; M
;M N
public 
sealed 
record %
GetChildCategoriesCommand .
(. /
Guid/ 3
ParentId4 <
)< =
:> ?
IRequest@ H
<H I
ListI M
<M N%
GetChildrenIngredientTypeN g
>g h
>h i
;i j
public 
record %
GetChildrenIngredientType '
(' (
Guid( ,

CategoryId- 7
,7 8
int9 <
Left= A
,A B
intC F
RightG L
,L M
stringN T
IngredientTypeNameU g
,g h
stringi o&
ingredientTypeDescription	p â
)
â ä
;
ä ã
public

 
class

 *
GetChildIngredientTypesHandler

 +
(

+ ,
IUnitOfWorks

, 8
unitOfWorks

9 D
)

D E
:

F G
IRequestHandler

H W
<

W X%
GetChildCategoriesCommand

X q
,

q r
List

s w
<

w x&
GetChildrenIngredientType	

x ë
>


ë í
>


í ì
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
List 
< %
GetChildrenIngredientType 4
>4 5
>5 6
Handle7 =
(= >%
GetChildCategoriesCommand> W
requestX _
,_ `
CancellationTokena r
cancellationToken	s Ñ
)
Ñ Ö
{ 
var 
ingredientTypes 
= 
await #
_unitOfWorks$ 0
.0 1$
IngredientTypeRepository1 I
.I J

WhereAsyncJ T
(T U
xU V
=>W Y
xZ [
.[ \
ParentId\ d
==e g
requesth o
.o p
ParentIdp x
)x y
;y z
return 
ingredientTypes 
. 
Select %
(% &
x& '
=>( *
new+ .%
GetChildrenIngredientType/ H
(H I
x 
. 
Id 
, 
x 
. 
Left 
, 
x 
. 
Right 
, 
x 
. 
IngredientName 
, 
x 
. !
IngredientDescription "
) 
) 	
.	 

ToList
 
( 
) 
; 
} 
} Û
îC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientTypes\Commands\Update\UpdateIngredientTypeValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientTypes# 2
.2 3
Commands3 ;
.; <
Update< B
;B C
public 
class )
UpdateIngredientTypeValidator *
:+ ,
AbstractValidator- >
<> ?'
UpdateIngredientTypeCommand? Z
>Z [
{ 
public		 
)
UpdateIngredientTypeValidator		 (
(		( )#
IngredientTypeValidator		) @
	validator		A J
,		J K,
 CheckIngredientParentIdValidator		L l
validations		m x
)		x y
{

 
RuleFor 
( 
x 
=> 
x 
. 
Name 
) 
. 
NotEmpty %
(% &
)& '
.' (
SetValidator( 4
(4 5
	validator5 >
)> ?
;? @
RuleFor 
( 
x 
=> 
x 
. 
Id 
) 
. 
NotEmpty #
(# $
)$ %
.% &
SetValidator& 2
(2 3
validations3 >
)> ?
;? @
} 
} 
public 
sealed 
class #
IngredientTypeValidator +
:, -
AbstractValidator. ?
<? @
string@ F
>F G
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
public 
#
IngredientTypeValidator "
(" #
IUnitOfWorks# /
unitOfWorks0 ;
); <
{ 
_unitOfWorks 
= 
unitOfWorks "
;" #
RuleFor 
( 
name 
=> 
name 
) 
. 
	MustAsync 
( 
CheckDuplicateName )
)) *
. 
WithMessage 
( 
$str ,
), -
;- .
} 
private 
async 
Task 
< 
bool 
> 
CheckDuplicateName /
(/ 0
string0 6
name7 ;
,; <
CancellationToken= N
tokenO T
)T U
{ 
IngredientType   
?   
ingredientType   &
=  ' (
await  ) .
_unitOfWorks  / ;
.  ; <$
IngredientTypeRepository  < T
.  T U
FirstOrDefaultAsync  U h
(  h i
x  i j
=>  k m
x  n o
.  o p
IngredientName  p ~
==	   Å
name
  Ç Ü
)
  Ü á
;
  á à
return!! 
ingredientType!! 
!=!!  
null!!! %
;!!% &
}"" 
}## ◊
íC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientTypes\Commands\Update\UpdateIngredientTypeHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientTypes# 2
.2 3
Commands3 ;
.; <
Update< B
;B C
public 
sealed 
record '
UpdateIngredientTypeCommand 0
:1 2
IRequest3 ;
<; <
Guid< @
>@ A
{		 
[

 

JsonIgnore

 
]

 
public 

Guid 
Id 
{ 
get 
; 
set 
; 
}  
public 

string 
Name 
{ 
get 
; 
set !
;! "
}# $
=% &
string' -
.- .
Empty. 3
;3 4
public 

string 
Description 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
string. 4
.4 5
Empty5 :
;: ;
} 
public 
class '
UpdateIngredientTypeHandler (
(( )
IUnitOfWorks) 5

unitOfWork6 @
)@ A
:B C
IRequestHandlerD S
<S T'
UpdateIngredientTypeCommandT o
,o p
Guidq u
>u v
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWork" -
=. /

unitOfWork0 :
;: ;
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #'
UpdateIngredientTypeCommand# >
request? F
,F G
CancellationTokenH Y
cancellationTokenZ k
)k l
{ 
IngredientType 
ingredientType %
=& '
await( -
_unitOfWork. 9
.9 :$
IngredientTypeRepository: R
.R S
GetByIdAsyncS _
(_ `
request` g
.g h
Idh j
)j k
??l n
throwo t
newu x
	Exception	y Ç
(
Ç É
)
É Ñ
;
Ñ Ö
ingredientType 
. 
Update 
( 
request %
.% &
Name& *
,* +
request, 3
.3 4
Description4 ?
)? @
;@ A
_unitOfWork 
. $
IngredientTypeRepository ,
., -
Update- 3
(3 4
ingredientType4 B
)B C
;C D
await 
_unitOfWork 
. 
SaveChangeAsync )
() *
)* +
;+ ,
return 
ingredientType 
. 
Id  
;  !
} 
} ﬂ
òC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientTypes\Commands\Inactive\InactiveIngredientTypeValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientTypes# 2
.2 3
Commands3 ;
.; <
Inactive< D
;D E
internal 
class	 +
InactiveIngredientTypeValidator .
:/ 0
AbstractValidator1 B
<B C)
InactiveIngredientTypeCommandC `
>` a
{ 
public 
+
InactiveIngredientTypeValidator *
(* +!
IngredientIdValidator+ @
	validatorA J
)J K
{ 
RuleFor		 
(		 
x		 
=>		 
x		 
.		 
Id		 
)		 
.		 
NotEmpty		 #
(		# $
)		$ %
.		% &
SetValidator		& 2
(		2 3
	validator		3 <
)		< =
;		= >
}

 
} ¡
ñC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientTypes\Commands\Inactive\InactiveIngredientTypeHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientTypes# 2
.2 3
Commands3 ;
.; <
Inactive< D
;D E
public

 
sealed

 
record

 )
InactiveIngredientTypeCommand

 2
(

2 3
Guid

3 7
Id

8 :
)

: ;
:

< =
IRequest

> F
<

F G
Result

G M
>

M N
;

N O
public 
class )
InactiveIngredientTypeHandler *
(* +
IUnitOfWorks+ 7
unitOfWorks8 C
)C D
:E F
IRequestHandlerG V
<V W)
InactiveIngredientTypeCommandW t
,t u
Resultv |
>| }
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %)
InactiveIngredientTypeCommand% B
requestC J
,J K
CancellationTokenL ]
cancellationToken^ o
)o p
{ 
IngredientGeneral 
ingredientGenerals ,
=- .
await/ 4
_unitOfWorks5 A
.A B'
IngredientGeneralRepositoryB ]
.] ^
GetByIdAsync^ j
(j k
requestk r
.r s
Ids u
)u v
??w y
throwz 
new
Ä É
	Exception
Ñ ç
(
ç é
)
é è
;
è ê
ingredientGenerals 
. 
UpdateState &
(& '
false' ,
), -
;- .
_unitOfWorks 
. '
IngredientGeneralRepository 0
.0 1
Update1 7
(7 8
ingredientGenerals8 J
)J K
;K L
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} Ò
†C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientTypes\Commands\CreateParent\CreateParentIngredientTypeValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientTypes# 2
.2 3
Commands3 ;
.; <
Create< B
;B C
public 
sealed 
class /
#CreateParentIngredientTypeValidator 7
:8 9
AbstractValidator: K
<K L'
CreateIngredientTypeCommandL g
>g h
{ 
public		 
/
#CreateParentIngredientTypeValidator		 .
(		. /#
IngredientTypeValidator		/ F
	validator		G P
)		P Q
{

 
RuleFor 
( 
x 
=> 
x 
. 
Name 
) 
. 
NotEmpty %
(% &
)& '
.' (
SetValidator( 4
(4 5
	validator5 >
)> ?
;? @
RuleFor 
( 
x 
=> 
x 
. 
Description "
)" #
.# $
NotNull$ +
(+ ,
), -
;- .
} 
} 
public 
sealed 
class #
IngredientTypeValidator +
:, -
AbstractValidator. ?
<? @
string@ F
>F G
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
public 
#
IngredientTypeValidator "
(" #
IUnitOfWorks# /
unitOfWorks0 ;
); <
{ 
_unitOfWorks 
= 
unitOfWorks "
;" #
RuleFor 
( 
name 
=> 
name 
) 
. 
	MustAsync 
( 
CheckDuplicateName )
)) *
. 
WithMessage 
( 
$str >
)> ?
;? @
} 
private 
async 
Task 
< 
bool 
> 
CheckDuplicateName /
(/ 0
string0 6
name7 ;
,; <
CancellationToken= N
tokenO T
)T U
{ 
IngredientType   
?   
ingredientType   &
=  ' (
await  ) .
_unitOfWorks  / ;
.  ; <$
IngredientTypeRepository  < T
.  T U
FirstOrDefaultAsync  U h
(  h i
x  i j
=>  k m
x  n o
.  o p
IngredientName  p ~
==	   Å
name
  Ç Ü
)
  Ü á
;
  á à
return!! 
ingredientType!! 
!=!!  
null!!! %
;!!% &
}"" 
}$$ Ø
ûC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientTypes\Commands\CreateParent\CreateParentIngredientTypeHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientTypes# 2
.2 3
Commands3 ;
.; <
Create< B
;B C
public 
record '
CreateIngredientTypeCommand )
() *
string* 0
Name1 5
,5 6
string7 =
Description> I
)I J
:K L
IRequestM U
<U V
GuidV Z
>Z [
;[ \
public		 
class		 -
!CreateParentIngredientTypeHandler		 .
(		. /
IUnitOfWorks		/ ;
unitOfWorks		< G
)		G H
:		I J
IRequestHandler		K Z
<		Z ['
CreateIngredientTypeCommand		[ v
,		v w
Guid		x |
>		| }
{

 
private 
readonly 
IUnitOfWorks !
_unitOfWork" -
=. /
unitOfWorks0 ;
;; <
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #'
CreateIngredientTypeCommand# >
request? F
,F G
CancellationTokenH Y
cancellationTokenZ k
)k l
{ 
IngredientType 
ingredientType %
=& '
new( +
(+ ,
request, 3
.3 4
Name4 8
,8 9
request: A
.A B
DescriptionB M
)M N
;N O
await 
_unitOfWork 
. $
IngredientTypeRepository 2
.2 3
AddAsync3 ;
(; <
ingredientType< J
)J K
;K L
await 
_unitOfWork 
. 
SaveChangeAsync )
() *
)* +
;+ ,
return 
ingredientType 
. 
Id  
;  !
} 
}  
°C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientTypes\Commands\CreateChild\CreateChildrenIngredientTypeValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientTypes# 2
.2 3
Commands3 ;
.; <
CreateChild< G
;G H
internal 
class	 1
%CreateChildrenIngredientTypeValidator 4
:5 6
AbstractValidator7 H
<H I,
 CreateChildIngredientTypeCommandI i
>i j
{ 
public		 
1
%CreateChildrenIngredientTypeValidator		 0
(		0 1#
IngredientTypeValidator		1 H
	validator		I R
,		R S,
 CheckIngredientParentIdValidator		T t
validationRules			u Ñ
)
		Ñ Ö
{

 
RuleFor 
( 
x 
=> 
x 
. 
Name 
) 
. 
NotEmpty %
(% &
)& '
.' (
SetValidator( 4
(4 5
	validator5 >
)> ?
;? @
RuleFor 
( 
x 
=> 
x 
. 
ParentId 
)  
.  !
NotEmpty! )
() *
)* +
.+ ,
SetValidator, 8
(8 9
validationRules9 H
)H I
;I J
} 
} 
public 
sealed 
class ,
 CheckIngredientParentIdValidator 4
:5 6
AbstractValidator7 H
<H I
GuidI M
>M N
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
public 
,
 CheckIngredientParentIdValidator +
(+ ,
IUnitOfWorks, 8
unitOfWorks9 D
)D E
{ 
_unitOfWorks 
= 
unitOfWorks "
;" #
RuleFor 
( 
parentId 
=> 
parentId $
)$ %
. 
	MustAsync 
( 
CheckParentId $
)$ %
. 
WithMessage 
( 
$str -
)- .
;. /
} 
private 
async 
Task 
< 
bool 
> 
CheckParentId *
(* +
Guid+ /
parentId0 8
,8 9
CancellationToken: K
tokenL Q
)Q R
{ 
IngredientType   
?   
ingredientType   &
=  ' (
await  ) .
_unitOfWorks  / ;
.  ; <$
IngredientTypeRepository  < T
.  T U
GetByIdAsync  U a
(  a b
parentId  b j
)  j k
;  k l
return!! 
ingredientType!! 
!=!!  
null!!! %
;!!% &
}"" 
}%% ⁄
úC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientTypes\Commands\CreateChild\CreateChildIngredientTypeHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientTypes# 2
.2 3
Commands3 ;
.; <
CreateChild< G
;G H
public 
sealed 
record ,
 CreateChildIngredientTypeCommand 5
:6 7
IRequest8 @
<@ A
GuidA E
>E F
{ 
public		 

Guid		 
ParentId		 
{		 
get		 
;		 
set		  #
;		# $
}		% &
public 

string 
Name 
{ 
get 
; 
set !
;! "
}# $
=% &
string' -
.- .
Empty. 3
;3 4
public 

string 
Description 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
string. 4
.4 5
Empty5 :
;: ;
} 
public 
class ,
 CreateChildIngredientTypeHandler -
(- .
IUnitOfWorks. :
unitOfWorks; F
)F G
:H I
IRequestHandlerJ Y
<Y Z,
 CreateChildIngredientTypeCommandZ z
,z {
Guid	| Ä
>
Ä Å
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #,
 CreateChildIngredientTypeCommand# C
requestD K
,K L
CancellationTokenM ^
cancellationToken_ p
)p q
{ 
IngredientType 
parentIngredient '
=( )
await* /
_unitOfWorks0 <
.< =$
IngredientTypeRepository= U
.U V
GetByIdAsyncV b
(b c
requestc j
.j k
ParentIdk s
)s t
??u w
throwx }
new	~ Å
	Exception
Ç ã
(
ã å
)
å ç
;
ç é
IngredientType 
ingredientType %
=& '
new( +
(+ ,
request, 3
.3 4
Name4 8
,8 9
request: A
.A B
DescriptionB M
,M N
parentIngredientO _
._ `
Right` e
,e f
parentIngredientg w
.w x
IngredientMain	x Ü
,
Ü á
request
à è
.
è ê
ParentId
ê ò
)
ò ô
;
ô ö
await 
_unitOfWorks 
. $
IngredientTypeRepository 3
.3 4
AddAsync4 <
(< =
ingredientType= K
)K L
;L M
await 
_unitOfWorks 
. $
IngredientTypeRepository 3
.3 4&
UpdateParentIngredientType4 N
(N O
parentIngredientO _
._ `
Id` b
,b c
parentIngredientd t
.t u
Rightu z
)z {
;{ |
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
ingredientType 
. 
Id  
;  !
} 
} –
îC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientTypes\Commands\Active\ActiveIngredientTypeValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientTypes# 2
.2 3
Commands3 ;
.; <
Active< B
;B C
public 
class )
ActiveIngredientTypeValidator *
:+ ,
AbstractValidator- >
<> ?'
ActiveIngredientTypeCommand? Z
>Z [
{ 
public		 
)
ActiveIngredientTypeValidator		 (
(		( )!
IngredientIdValidator		) >
	validator		? H
)		H I
{

 
RuleFor 
( 
x 
=> 
x 
. 
Id 
) 
. 
NotEmpty #
(# $
)$ %
.% &
SetValidator& 2
(2 3
	validator3 <
)< =
;= >
} 
} 
public 
sealed 
class !
IngredientIdValidator )
:* +
AbstractValidator, =
<= >
Guid> B
>B C
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
public 
!
IngredientIdValidator  
(  !
IUnitOfWorks! -
unitOfWorks. 9
)9 :
{ 
_unitOfWorks 
= 
unitOfWorks "
;" #
RuleFor 
( 
id 
=> 
id 
) 
. 
	MustAsync 
( 

CheckExist !
)! "
. 
WithMessage 
( 
$str 6
)6 7
;7 8
} 
private 
async 
Task 
< 
bool 
> 

CheckExist '
(' (
Guid( ,
id- /
,/ 0
CancellationToken1 B
tokenC H
)H I
{ 
IngredientType 
? 
ingredientType &
=' (
await) .
_unitOfWorks/ ;
.; <$
IngredientTypeRepository< T
.T U
GetByIdAsyncU a
(a b
idb d
)d e
;e f
return   
ingredientType   
!=    
null  ! %
;  % &
}!! 
}"" ñ
íC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientTypes\Commands\Active\ActiveIngredientTypeHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientTypes# 2
.2 3
Commands3 ;
.; <
Active< B
;B C
public 
sealed 
record '
ActiveIngredientTypeCommand 0
(0 1
Guid1 5
Id6 8
)8 9
:: ;
IRequest< D
<D E
ResultE K
>K L
;L M
public		 
class		 '
ActiveIngredientTypeHandler		 (
(		( )
IUnitOfWorks		) 5
unitOfWorks		6 A
)		A B
:		C D
IRequestHandler		E T
<		T U'
ActiveIngredientTypeCommand		U p
,		p q
Result		r x
>		x y
{

 
private 
readonly 
IUnitOfWorks !
_unitOfWork" -
=. /
unitOfWorks0 ;
;; <
public 

async 
Task 
< 
Result 
> 
Handle $
($ %'
ActiveIngredientTypeCommand% @
requestA H
,H I
CancellationTokenJ [
cancellationToken\ m
)m n
{ 
IngredientType 
ingredientType %
=& '
await( -
_unitOfWork. 9
.9 :$
IngredientTypeRepository: R
.R S
GetByIdAsyncS _
(_ `
request` g
.g h
Idh j
)j k
??l n
throwo t
newu x
	Exception	y Ç
(
Ç É
)
É Ñ
;
Ñ Ö
ingredientType 
. 
UpdateState "
(" #
true# '
)' (
;( )
_unitOfWork 
. $
IngredientTypeRepository ,
., -
Update- 3
(3 4
ingredientType4 B
)B C
;C D
await 
_unitOfWork 
. 
SaveChangeAsync )
() *
)* +
;+ ,
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ª&
èC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Ingredients\Queries\GetIngredients\GetIngredientsHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Ingredients# .
.. /
Queries/ 6
.6 7
GetIngredients7 E
{ 
public 

sealed 
record !
GetIngredientsCommand .
(. /
string/ 5
?5 6
IngredientName7 E
,E F
PagingRequestG T
?T U
PagingRequestV c
)c d
:e f
IRequestg o
<o p
PagedResultp {
<{ |#
GetIngredientsResponse	| í
>
í ì
>
ì î
;
î ï
public		 

sealed		 
record		 "
GetIngredientsResponse		 /
(		/ 0
Guid		0 4
IngredientId		5 A
,		A B
string		C I
IngredientName		J X
,		X Y
decimal		Z a
Amount		b h
)		h i
;		i j
public 

class !
GetIngredientsHandler &
:' (
IRequestHandler) 8
<8 9!
GetIngredientsCommand9 N
,N O
PagedResultP [
<[ \"
GetIngredientsResponse\ r
>r s
>s t
{ 
private 
readonly 
IUnitOfWorks %
_unitOfWorks& 2
;2 3
public !
GetIngredientsHandler $
($ %
IUnitOfWorks% 1
unitOfWorks2 =
)= >
{ 	
_unitOfWorks 
= 
unitOfWorks &
;& '
} 	
public 
async 
Task 
< 
PagedResult %
<% &"
GetIngredientsResponse& <
>< =
>= >
Handle? E
(E F!
GetIngredientsCommandF [
request\ c
,c d
CancellationTokene v
cancellationToken	w à
)
à â
{ 	
var 
allIngredients 
=  
await! &
_unitOfWorks' 3
.3 4 
IngredientRepository4 H
.H I
GetAllAsyncI T
(T U
)U V
;V W
var 
filteredIngredients #
=$ %
allIngredients& 4
.4 5
AsQueryable5 @
(@ A
)A B
. 
Where 
( 
x 
=> 
string "
." #
IsNullOrEmpty# 0
(0 1
request1 8
.8 9
IngredientName9 G
)G H
||I K
x 
. 
IngredientName ,
., -
Contains- 5
(5 6
request6 =
.= >
IngredientName> L
,L M
StringComparisonN ^
.^ _
OrdinalIgnoreCase_ p
)p q
)q r
;r s
var 
mappedIngredients !
=" #
filteredIngredients$ 7
.7 8
Select8 >
(> ?
x? @
=>A C
newD G"
GetIngredientsResponseH ^
(^ _
x   
.   
Id   
,   
x!! 
.!! 
IngredientName!!  
??!!! #
string!!$ *
.!!* +
Empty!!+ 0
,!!0 1
x"" 
."" 
ExpriedQuantity"" !
)""! "
)""" #
.""# $
ToList""$ *
(""* +
)""+ ,
;"", -
var%% 
(%% 
page%% 
,%% 
pageSize%% 
,%%  
sortType%%! )
,%%) *
	sortField%%+ 4
)%%4 5
=%%6 7
PaginationUtils%%8 G
.%%G H)
GetPaginationAndSortingValues%%H e
(%%e f
request%%f m
.%%m n
PagingRequest%%n {
)%%{ |
;%%| }
var(( 
sortedResults(( 
=(( 
PaginationHelper((  0
<((0 1"
GetIngredientsResponse((1 G
>((G H
.((H I
Sorting((I P
(((P Q
sortType((Q Y
,((Y Z
mappedIngredients(([ l
,((l m
	sortField((n w
)((w x
;((x y
var)) 
result)) 
=)) 
PaginationHelper)) )
<))) *"
GetIngredientsResponse))* @
>))@ A
.))A B
Paging))B H
())H I
sortedResults))I V
,))V W
page))X \
,))\ ]
pageSize))^ f
)))f g
;))g h
return++ 
result++ 
;++ 
},, 	
}-- 
}.. Ñ
†C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Ingredients\Commands\CheckExpiredIngredient\CheckExpiredIngredientHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Ingredients# .
.. /
Commands/ 7
.7 8"
CheckExpiredIngredient8 N
;N O
public 
sealed 
record )
CheckExpiredIngredientCommand 2
:3 4
IRequest5 =
<= >
Result> D
>D E
;E F
public 
class )
CheckExpiredIngredientHandler *
(* +
IUnitOfWorks+ 7
unitOfWorks8 C
)C D
:E F
IRequestHandlerG V
<V W)
CheckExpiredIngredientCommandW t
,t u
Resultv |
>| }
{		 
private

 
readonly

 
IUnitOfWorks

 !
_unitOfWorks

" .
=

/ 0
unitOfWorks

1 <
;

< =
public 

Task 
< 
Result 
> 
Handle 
( )
CheckExpiredIngredientCommand <
request= D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
{ 
throw 
new #
NotImplementedException )
() *
)* +
;+ ,
} 
} ë
ñC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Ingredients\Commands\AddSingleQuantity\AddSingleQuantityHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Ingredients# .
.. /
Commands/ 7
.7 8
AddSingleQuantity8 I
;I J
public 
sealed 
record $
AddSingleQuantityCommand -
(- .
Guid. 2
IngredientId3 ?
,? @
decimalA H
QuantityI Q
)Q R
:S T
IRequestU ]
<] ^
Result^ d
>d e
;e f
public		 
class		 $
AddSingleQuantityHandler		 %
(		% &
IUnitOfWorks		& 2
unitOfWorks		3 >
)		> ?
:		@ A
IRequestHandler		B Q
<		Q R$
AddSingleQuantityCommand		R j
,		j k
Result		l r
>		r s
{

 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %$
AddSingleQuantityCommand% =
request> E
,E F
CancellationTokenG X
cancellationTokenY j
)j k
{ 

Ingredient 

ingredient 
= 
await  %
_unitOfWorks& 2
.2 3 
IngredientRepository3 G
.G H
GetByIdAsyncH T
(T U
requestU \
.\ ]
IngredientId] i
)i j
??k m
thrown s
newt w
	Exception	x Å
(
Å Ç
)
Ç É
;
É Ñ

ingredient 
. 
AddQuantity 
( 
request &
.& '
Quantity' /
)/ 0
;0 1!
IngredientTransaction !
ingredientTransaction 3
=4 5
new6 9
(9 :
request: A
.A B
QuantityB J
,J K
DomainL R
.R S
EntitiesS [
.[ \ 
IngredientAggregator\ p
.p q
Enumsq v
.v w&
IngredientTransactionType	w ê
.
ê ë
Add
ë î
,
î ï

ingredient
ñ †
.
† °
Id
° £
)
£ §
;
§ •

ingredient 
. 
AddQuantity 
( 
request &
.& '
Quantity' /
)/ 0
;0 1
await 
_unitOfWorks 
. +
IngredientTransactionRepository :
.: ;
AddAsync; C
(C D!
ingredientTransactionD Y
)Y Z
;Z [
_unitOfWorks 
.  
IngredientRepository )
.) *
Update* 0
(0 1

ingredient1 ;
); <
;< =
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ä
öC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Ingredients\Commands\AddMultipleQuantity\AddMultipleQuantityHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Ingredients# .
.. /
Commands/ 7
.7 8
AddMultipleQuantity8 K
;K L
public 
sealed 
record &
AddMultipleQuantityCommand /
(/ 0
List0 4
<4 5
ObjectAdding5 A
>A B
AddingC I
)I J
:K L
IRequestM U
<U V
ResultV \
>\ ]
;] ^
public 
sealed 
record 
ObjectAdding !
(! "
decimal" )
Quantity* 2
,2 3
Guid4 8
IngreidentId9 E
)E F
;F G
public		 
class		 &
AddMultipleQuantityHandler		 '
(		' (
IUnitOfWorks		( 4
unitOfWorks		5 @
)		@ A
:		B C
IRequestHandler		D S
<		S T&
AddMultipleQuantityCommand		T n
,		n o
Result		p v
>		v w
{

 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %&
AddMultipleQuantityCommand% ?
request@ G
,G H
CancellationTokenI Z
cancellationToken[ l
)l m
{ 
foreach 
( 
var 
item 
in 
request $
.$ %
Adding% +
)+ ,
{ 	

Ingredient 

ingredient !
=" #
await$ )
_unitOfWorks* 6
.6 7 
IngredientRepository7 K
.K L
GetByIdAsyncL X
(X Y
itemY ]
.] ^
IngreidentId^ j
)j k
??l n
throwo t
newu x
	Exception	y Ç
(
Ç É
)
É Ñ
;
Ñ Ö!
IngredientTransaction !!
ingredientTransaction" 7
=8 9
new: =
(= >
item> B
.B C
QuantityC K
,K L
DomainM S
.S T
EntitiesT \
.\ ] 
IngredientAggregator] q
.q r
Enumsr w
.w x&
IngredientTransactionType	x ë
.
ë í
Add
í ï
,
ï ñ

ingredient
ó °
.
° ¢
Id
¢ §
)
§ •
;
• ¶

ingredient 
. 
AddQuantity "
(" #
item# '
.' (
Quantity( 0
)0 1
;1 2
await 
_unitOfWorks 
. +
IngredientTransactionRepository >
.> ?
AddAsync? G
(G H!
ingredientTransactionH ]
)] ^
;^ _
_unitOfWorks 
.  
IngredientRepository -
.- .
Update. 4
(4 5

ingredient5 ?
)? @
;@ A
} 	
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ©)
®C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientGenerals\Queries\GetAllIngredientGeneral\GetAllIngredientGeneralHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientGenerals# 5
.5 6
Queries6 =
.= >#
GetAllIngredientGeneral> U
{ 
public 

sealed 
record #
GetAllIngredientCommand 0
(0 1
string1 7
?7 8
IngredientName9 G
,G H
GuidI M
?M N
IngredientTypeIdO _
,_ `
PagingRequesta n
?n o
PagingRequestp }
)} ~
:	 Ä
IRequest
Å â
<
â ä
PagedResult
ä ï
<
ï ñ&
GetAllIngredientResponse
ñ Æ
>
Æ Ø
>
Ø ∞
;
∞ ±
public

 

record

 $
GetAllIngredientResponse

 *
(

* +
Guid

+ /
Id

0 2
,

2 3
string

4 :
IngredientName

; I
,

I J
Guid

K O
IngredientTypeId

P `
,

` a
string

b h!
IngredientDescription

i ~
)

~ 
;	

 Ä
public 

class *
GetAllIngredientGeneralHandler /
:0 1
IRequestHandler2 A
<A B#
GetAllIngredientCommandB Y
,Y Z
PagedResult[ f
<f g$
GetAllIngredientResponseg 
>	 Ä
>
Ä Å
{ 
private 
readonly 
IUnitOfWorks %
_unitOfWorks& 2
;2 3
public *
GetAllIngredientGeneralHandler -
(- .
IUnitOfWorks. :
unitOfWorks; F
)F G
{ 	
_unitOfWorks 
= 
unitOfWorks &
;& '
} 	
public 
async 
Task 
< 
PagedResult %
<% &$
GetAllIngredientResponse& >
>> ?
>? @
HandleA G
(G H#
GetAllIngredientCommandH _
request` g
,g h
CancellationTokeni z
cancellationToken	{ å
)
å ç
{ 	
var 
allIngredients 
=  
await! &
_unitOfWorks' 3
.3 4'
IngredientGeneralRepository4 O
.O P
GetAllAsyncP [
([ \
)\ ]
;] ^
var 
filteredIngredients #
=$ %
allIngredients& 4
.4 5
AsQueryable5 @
(@ A
)A B
. 
CustomFilterV1 
(  
new  #
IngredientGeneral$ 5
{ 
IngredientName "
=# $
request% ,
., -
IngredientName- ;
??< >
string? E
.E F
EmptyF K
,K L
IngredientTypeId $
=% &
request' .
.. /
IngredientTypeId/ ?
??@ B
GuidC G
.G H
EmptyH M
,M N
}   
)   
;   
var## 
mappedIngredients## !
=##" #
filteredIngredients##$ 7
.##7 8
Select##8 >
(##> ?
x##? @
=>##A C
new##D G$
GetAllIngredientResponse##H `
(##` a
x$$ 
.$$ 
Id$$ 
,$$ 
x%% 
.%% 
IngredientName%%  
??%%! #
string%%$ *
.%%* +
Empty%%+ 0
,%%0 1
x&& 
.&& 
IngredientTypeId&& "
,&&" #
x'' 
.'' !
IngredientDescription'' '
??''( *
string''+ 1
.''1 2
Empty''2 7
)''7 8
)''8 9
.''9 :
ToList'': @
(''@ A
)''A B
;''B C
var** 
(** 
page** 
,** 
pageSize** 
,**  
sortType**! )
,**) *
	sortField**+ 4
)**4 5
=**6 7
PaginationUtils**8 G
.**G H)
GetPaginationAndSortingValues**H e
(**e f
request**f m
.**m n
PagingRequest**n {
)**{ |
;**| }
var-- 
sortedResults-- 
=-- 
PaginationHelper--  0
<--0 1$
GetAllIngredientResponse--1 I
>--I J
.--J K
Sorting--K R
(--R S
sortType--S [
,--[ \
mappedIngredients--] n
,--n o
	sortField--p y
)--y z
;--z {
var.. 
result.. 
=.. 
PaginationHelper.. )
<..) *$
GetAllIngredientResponse..* B
>..B C
...C D
Paging..D J
(..J K
sortedResults..K X
,..X Y
page..Z ^
,..^ _
pageSize..` h
)..h i
;..i j
return00 
result00 
;00 
}11 	
}22 
}33 •	
àC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientGenerals\Mapper\IngredientGeneralMapper.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientGenerals# 5
.5 6
Mapper6 <
;< =
public 
static 
class #
IngredientGeneralMapper +
{ 
public 

static $
GetAllIngredientResponse *
MapperGetAllDTO+ :
(: ;
this; ?
IngredientGeneral@ Q
ingredientGeneralR c
)c d
{		 
return

 
new

 $
GetAllIngredientResponse

 +
(

+ ,
ingredientGeneral

, =
.

= >
Id

> @
,

@ A
ingredientGeneral

B S
.

S T
IngredientName

T b
,

b c
ingredientGeneral

d u
.

u v
IngredientTypeId	

v Ü
,


Ü á
ingredientGeneral


à ô
.


ô ö#
IngredientDescription


ö Ø
)


Ø ∞
;


∞ ±
} 
} Å
öC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientGenerals\Commands\Update\UpdateIngredientGeneralValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientGenerals# 5
.5 6
Commands6 >
.> ?
Update? E
;E F
public 
class ,
 UpdateIngredientGeneralValidator -
:. /
AbstractValidator0 A
<A B*
UpdateIngredientGeneralCommandB `
>` a
{		 
public

 
,
 UpdateIngredientGeneralValidator

 +
(

+ ,(
IngredientGeneralIdValidator

, H
	validator

I R
,

R S#
IngredientNameValidator

T k
name

l p
)

p q
{ 
RuleFor 
( 
x 
=> 
x 
. 
Id 
) 
. 
NotEmpty #
(# $
)$ %
.% &
SetValidator& 2
(2 3
	validator3 <
)< =
;= >
RuleFor 
( 
x 
=> 
x 
. 
Name 
) 
. 
NotEmpty %
(% &
)& '
.' (
SetValidator( 4
(4 5
name5 9
)9 :
;: ;
} 
} 
public 
sealed 
class #
IngredientNameValidator +
:, -
AbstractValidator. ?
<? @
string@ F
>F G
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
public 
#
IngredientNameValidator "
(" #
IUnitOfWorks# /
unitOfWorks0 ;
); <
{ 
_unitOfWorks 
= 
unitOfWorks "
;" #
RuleFor 
( 
name 
=> 
name 
) 
. 
	MustAsync '
(' (
CheckDuplicateName( :
): ;
.; <
WithMessage< G
(G H
$strH f
)f g
;g h
} 
private 
async 
Task 
< 
bool 
> 
CheckDuplicateName /
(/ 0
string0 6
name7 ;
,; <
CancellationToken= N
tokenO T
)T U
{ 
IngredientGeneral 
? 
ingredientGeneral ,
=- .
await/ 4
_unitOfWorks5 A
.A B'
IngredientGeneralRepositoryB ]
.] ^
FirstOrDefaultAsync^ q
(q r
xr s
=>t v
xw x
.x y
IngredientName	y á
==
à ä
name
ã è
)
è ê
;
ê ë
return 
ingredientGeneral  
!=! #
null$ (
;( )
} 
}   Í
òC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientGenerals\Commands\Update\UpdateIngredientGeneralHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientGenerals# 5
.5 6
Commands6 >
.> ?
Update? E
;E F
public 
record *
UpdateIngredientGeneralCommand ,
:- .
IRequest/ 7
<7 8
Guid8 <
>< =
{		 
[

 

JsonIgnore

 
]

 
public 

Guid 
Id 
{ 
get 
; 
set 
; 
}  
public 

string 
Name 
{ 
get 
; 
set !
;! "
}# $
=% &
string' -
.- .
Empty. 3
;3 4
public 

string 
Description 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
string. 4
.4 5
Empty5 :
;: ;
public 

Guid 
IngredientTypeId  
{! "
get# &
;& '
set( +
;+ ,
}- .
} 
internal 
class	 *
UpdateIngredientGeneralHandler -
(- .
IUnitOfWorks. :
unitOfWorks; F
)F G
:H I
IRequestHandlerJ Y
<Y Z*
UpdateIngredientGeneralCommandZ x
,x y
Guidz ~
>~ 
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #*
UpdateIngredientGeneralCommand# A
requestB I
,I J
CancellationTokenK \
cancellationToken] n
)n o
{ 
IngredientGeneral 
ingredientGeneral +
=, -
await. 3
_unitOfWorks4 @
.@ A'
IngredientGeneralRepositoryA \
.\ ]
GetByIdAsync] i
(i j
requestj q
.q r
Idr t
)t u
??v x
throwy ~
new	 Ç
	Exception
É å
(
å ç
)
ç é
;
é è
ingredientGeneral 
. 
Update  
(  !
request! (
.( )
Name) -
,- .
request/ 6
.6 7
Description7 B
,B C
requestD K
.K L
IngredientTypeIdL \
)\ ]
;] ^
_unitOfWorks 
. '
IngredientGeneralRepository 0
.0 1
Update1 7
(7 8
ingredientGeneral8 I
)I J
;J K
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
ingredientGeneral  
.  !
Id! #
;# $
} 
} Ò
ûC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientGenerals\Commands\Inactive\InactiveIngredientGeneralValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientGenerals# 5
.5 6
Commands6 >
.> ?
Inactive? G
;G H
internal 
class	 .
"InactiveIngredientGeneralValidator 1
:2 3
AbstractValidator4 E
<E F)
InactiveIngredientTypeCommandF c
>c d
{ 
public 
.
"InactiveIngredientGeneralValidator -
(- .(
IngredientGeneralIdValidator. J
checkIdK R
)R S
{		 
RuleFor

 
(

 
x

 
=>

 
x

 
.

 
Id

 
)

 
.

 
NotEmpty

 #
(

# $
)

$ %
.

% &
SetValidator

& 2
(

2 3
checkId

3 :
)

: ;
;

; <
} 
} ÿ
úC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientGenerals\Commands\Inactive\InactiveIngredientGeneralHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientGenerals# 5
.5 6
Commands6 >
.> ?
Inactive? G
;G H
public 
sealed 
record ,
 InactiveIngredientGeneralCommand 5
(5 6
Guid6 :
Id; =
)= >
:? @
IRequestA I
<I J
ResultJ P
>P Q
;Q R
public 
class ,
 InactiveIngredientGeneralHandler -
(- .
IUnitOfWorks. :
unitOfWorks; F
)F G
:H I
IRequestHandlerJ Y
<Y Z,
 InactiveIngredientGeneralCommandZ z
,z {
Result	| Ç
>
Ç É
{		 
private

 
readonly

 
IUnitOfWorks

 !
_unitOfWorks

" .
=

/ 0
unitOfWorks

1 <
;

< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %,
 InactiveIngredientGeneralCommand% E
requestF M
,M N
CancellationTokenO `
cancellationTokena r
)r s
{ 
IngredientGeneral 
ingredientGenerals ,
=- .
await/ 4
_unitOfWorks5 A
.A B'
IngredientGeneralRepositoryB ]
.] ^
GetByIdAsync^ j
(j k
requestk r
.r s
Ids u
)u v
??w y
throwz 
new
Ä É
	Exception
Ñ ç
(
ç é
)
é è
;
è ê
ingredientGenerals 
. 
UpdateState &
(& '
true' +
)+ ,
;, -
_unitOfWorks 
. '
IngredientGeneralRepository 0
.0 1
Update1 7
(7 8
ingredientGenerals8 J
)J K
;K L
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ‹
öC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientGenerals\Commands\Create\CreateIngredientGeneralValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientGenerals# 5
.5 6
Commands6 >
.> ?
Create? E
;E F
public 
class ,
 CreateIngredientGeneralValidator -
:. /
AbstractValidator0 A
<A B*
CreateIngredientGeneralCommandB `
>` a
{ 
public 
,
 CreateIngredientGeneralValidator +
(+ ,#
IngredientNameValidator, C
nameD H
)H I
{		 
RuleFor

 
(

 
x

 
=>

 
x

 
.

 
Name

 
)

 
.

 
NotEmpty

 %
(

% &
)

& '
.

' (
NotNull

( /
(

/ 0
)

0 1
.

1 2
SetValidator

2 >
(

> ?
name

? C
)

C D
;

D E
RuleFor 
( 
x 
=> 
x 
. 
Description "
)" #
.# $
NotEmpty$ ,
(, -
)- .
.. /
NotNull/ 6
(6 7
)7 8
;8 9
RuleFor 
( 
x 
=> 
x 
. 
IngredientType %
)% &
.& '
NotEmpty' /
(/ 0
)0 1
.1 2
NotNull2 9
(9 :
): ;
;; <
} 
} ‹
òC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientGenerals\Commands\Create\CreateIngredientGeneralHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientGenerals# 5
.5 6
Commands6 >
.> ?
Create? E
;E F
public 
record *
CreateIngredientGeneralCommand ,
(, -
string- 3
Name4 8
,8 9
string: @
DescriptionA L
,L M
GuidN R
IngredientTypeS a
,a b
intc f!
IngredientMeasureTypeg |
)| }
:~ 
IRequest
Ä à
<
à â
Guid
â ç
>
ç é
;
é è
public		 
class		 *
CreateIngredientGeneralHandler		 +
(		+ ,
IUnitOfWorks		, 8
unitOfWorks		9 D
)		D E
:		F G
IRequestHandler		H W
<		W X*
CreateIngredientGeneralCommand		X v
,		v w
Guid		x |
>		| }
{

 
private 
readonly 
IUnitOfWorks !
_unitOfWork" -
=. /
unitOfWorks0 ;
;; <
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #*
CreateIngredientGeneralCommand# A
requestB I
,I J
CancellationTokenK \
cancellationToken] n
)n o
{ 
IngredientGeneral 
ingredientGeneral +
=, -
new. 1
(1 2
request2 9
.9 :
Name: >
,> ?
request@ G
.G H
DescriptionH S
,S T
requestU \
.\ ]
IngredientType] k
,k l
TransferTypem y
.y z
Transfer	z Ç
(
Ç É
request
É ä
.
ä ã#
IngredientMeasureType
ã †
)
† °
)
° ¢
;
¢ £
await 
_unitOfWork 
. '
IngredientGeneralRepository 5
.5 6
AddAsync6 >
(> ?
ingredientGeneral? P
)P Q
;Q R
await 
_unitOfWork 
. 
SaveChangeAsync )
() *
)* +
;+ ,
return 
ingredientGeneral  
.  !
Id! #
;# $
} 
} ¢
öC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientGenerals\Commands\Active\ActiveIngredientGeneralValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientGenerals# 5
.5 6
Commands6 >
.> ?
Active? E
;E F
public 
class ,
 ActiveIngredientGeneralValidator -
:. /
AbstractValidator0 A
<A B*
ActiveIngredientGeneralCommandB `
>` a
{ 
public 
,
 ActiveIngredientGeneralValidator +
(+ ,(
IngredientGeneralIdValidator, H
checkIdI P
)P Q
{		 
RuleFor

 
(

 
x

 
=>

 
x

 
.

 
Id

 
)

 
.

 
NotEmpty

 #
(

# $
)

$ %
.

% &
SetValidator

& 2
(

2 3
checkId

3 :
)

: ;
;

; <
} 
} 
public 
sealed 
class (
IngredientGeneralIdValidator 0
:1 2
AbstractValidator3 D
<D E
GuidE I
>I J
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
public 
(
IngredientGeneralIdValidator '
(' (
IUnitOfWorks( 4
unitOfWorks5 @
)@ A
{ 
_unitOfWorks 
= 
unitOfWorks "
;" #
RuleFor 
( 
id 
=> 
id 
) 
. 
	MustAsync 
( 

CheckExist 
) 
. 
WithMessage 
( 
$str 4
)4 5
;5 6
} 
private 
async 
Task 
< 
bool 
> 

CheckExist '
(' (
Guid( ,
ingredientGeneralId- @
,@ A
CancellationTokenB S
tokenT Y
)Y Z
{ 
IngredientGeneral 
? 
ingredientGeneral ,
=- .
await/ 4
_unitOfWorks5 A
.A B'
IngredientGeneralRepositoryB ]
.] ^
GetByIdAsync^ j
(j k
ingredientGeneralIdk ~
)~ 
;	 Ä
return 
ingredientGeneral  
!=! #
null$ (
;( )
}   
}!! «
òC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\IngredientGenerals\Commands\Active\ActiveIngredientGeneralHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
IngredientGenerals# 5
.5 6
Commands6 >
.> ?
Active? E
;E F
public 
sealed 
record *
ActiveIngredientGeneralCommand 3
(3 4
Guid4 8
Id9 ;
); <
:= >
IRequest? G
<G H
ResultH N
>N O
;O P
public 
class *
ActiveIngredientGeneralHandler +
(+ ,
IUnitOfWorks, 8
unitOfWorks9 D
)D E
:F G
IRequestHandlerH W
<W X*
ActiveIngredientGeneralCommandX v
,v w
Resultx ~
>~ 
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %*
ActiveIngredientGeneralCommand% C
requestD K
,K L
CancellationTokenM ^
cancellationToken_ p
)p q
{ 
IngredientGeneral 
ingredientGenerals ,
=- .
await/ 4
_unitOfWorks5 A
.A B'
IngredientGeneralRepositoryB ]
.] ^
GetByIdAsync^ j
(j k
requestk r
.r s
Ids u
)u v
??w y
throwz 
new
Ä É
	Exception
Ñ ç
(
ç é
)
é è
;
è ê
ingredientGenerals 
. 
UpdateState &
(& '
true' +
)+ ,
;, -
_unitOfWorks 
. '
IngredientGeneralRepository 0
.0 1
Update1 7
(7 8
ingredientGenerals8 J
)J K
;K L
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ˇ
åC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\GroupMessages\Commands\SendMessage\SendMessageHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" #
GroupMessages		# 0
.		0 1
Commands		1 9
.		9 :
SendMessage		: E
;		E F
public 
sealed 
record 
SendMessageCommand '
(' (
string( .
Content/ 6
)6 7
:8 9
IRequest: B
<B C
ResultC I
>I J
{ 
[ 

JsonIgnore 
] 
public 

Guid 
GroupId 
{ 
get 
; 
set "
;" #
}$ %
} 
; 
internal 
class	 
SendMessageHandler !
(! "
IUnitOfWorks" .
unitOfWorks/ :
,: ;
IClaimService< I
claimServiceJ V
)V W
:X Y
IRequestHandlerZ i
<i j
SendMessageCommandj |
,| }
Result	~ Ñ
>
Ñ Ö
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
IClaimService "
_claimService# 0
=1 2
claimService3 ?
;? @
public 

async 
Task 
< 
Result 
> 
Handle $
($ %
SendMessageCommand% 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ 
GroupMessage 
groupMessage !
=" #
new$ '
(' (
request( /
./ 0
Content0 7
,7 8
_claimService9 F
.F G
UserIdG M
,M N
requestO V
.V W
GroupIdW ^
)^ _
;_ `
await 
_unitOfWorks 
. "
GroupMessageRepository 1
.1 2
AddAsync2 :
(: ;
groupMessage; G
)G H
;H I
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
}   
}## Ô	
ëC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\GroupChats\Commands\RemoveGroupChat\RemoveGroupChatHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #

GroupChats# -
.- .
Commands. 6
.6 7
RemoveGroupChat7 F
;F G
public 
sealed 
record "
RemoveGroupChatCommand +
:, -
IRequest. 6
<6 7
IResult7 >
>> ?
;? @
internal 
class	 "
RemoveGroupChatHandler %
:& '
IRequestHandler( 7
<7 8"
RemoveGroupChatCommand8 N
,N O
IResultP W
>W X
{ 
public 

Task 
< 
IResult 
> 
Handle 
(  "
RemoveGroupChatCommand  6
request7 >
,> ?
CancellationToken@ Q
cancellationTokenR c
)c d
{		 
throw

 
new

 #
NotImplementedException

 )
(

) *
)

* +
;

+ ,
} 
} √
ëC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\GroupChats\Commands\CreateGroupChat\CreateGroupChatHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #

GroupChats# -
.- .
Commands. 6
.6 7
CreateGroupChat7 F
;F G
public 
sealed 
record "
CreateGroupChatCommand +
(+ ,
Guid, 0
RestaurantId1 =
)= >
:? @
IRequestA I
<I J
ResultJ P
>P Q
;Q R
internal 
class	 "
CreateGroupChatHandler %
(% &
IUnitOfWorks& 2
unitOfWorks3 >
)> ?
:@ A
IRequestHandlerB Q
<Q R"
CreateGroupChatCommandR h
,h i
Resultj p
>p q
{		 
private

 
readonly

 
IUnitOfWorks

 !
_unitOfWorks

" .
=

/ 0
unitOfWorks

1 <
;

< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %"
CreateGroupChatCommand% ;
request< C
,C D
CancellationTokenE V
cancellationTokenW h
)h i
{ 
var 
	groupChat 
= 
new 
	GroupChat %
{ 	
	GroupName 
= 
$str '
,' (
RestaurantId 
= 
request "
." #
RestaurantId# /
,/ 0
} 	
;	 

await 
_unitOfWorks 
. 
GroupChatRepository .
.. /
AddAsync/ 7
(7 8
	groupChat8 A
)A B
;B C
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ”
~C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Combos\Queries\GetCombos\GetCombosQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Combos# )
.) *
Queries* 1
.1 2
	GetCombos2 ;
;; <
public 
sealed 
record 
GetCombosCommand %
(% &
string& ,
	ComboName- 6
)6 7
:8 9
IRequest: B
<B C
ResultC I
>I J
;J K
internal 
class	 
GetCombosQuery 
{ 
} ∏
ÑC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Combos\Commands\Inactive\InactvieComboHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Combos# )
.) *
Commands* 2
.2 3
Inactive3 ;
;; <
public 
sealed 
record  
InactiveComboCommand )
() *
Guid* .
ComboId/ 6
)6 7
:8 9
IRequest: B
<B C
ResultC I
>I J
;J K
internal 
class	  
InactvieComboHandler #
(# $
IUnitOfWorks$ 0
unitOfWorks1 <
)< =
:> ?
IRequestHandler@ O
<O P 
InactiveComboCommandP d
,d e
Resultf l
>l m
{		 
private

 
readonly

 
IUnitOfWorks

 !
_unitOfWorks

" .
=

/ 0
unitOfWorks

1 <
;

< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ % 
InactiveComboCommand% 9
request: A
,A B
CancellationTokenC T
cancellationTokenU f
)f g
{ 
Combo 
combo 
= 
await 
_unitOfWorks (
.( )
ComboRepository) 8
.8 9
GetByIdAsync9 E
(E F
requestF M
.M N
ComboIdN U
)U V
??W Y
throwZ _
new` c
	Exceptiond m
(m n
)n o
;o p
combo 
. 
UpdateState 
( 
true 
) 
;  
_unitOfWorks 
. 
ComboRepository $
.$ %
Update% +
(+ ,
combo, 1
)1 2
;2 3
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ≥$
ÄC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Combos\Commands\Create\CreateComboHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Combos# )
.) *
Commands* 2
.2 3
Create3 9
;9 :
public 
sealed 
record 
CreateComboCommand '
(' (
List( ,
<, -
Guid- 1
>1 2
ProductInCombos3 B
,B C
stringD J
	ComboNameK T
,T U
stringV \
Status] c
,c d
inte h
Quantityi q
,q r
decimals z
Price	{ Ä
,
Ä Å
DateTime
Ç ä
ExpiredDate
ã ñ
)
ñ ó
:
ò ô
IRequest
ö ¢
<
¢ £
Guid
£ ß
>
ß ®
;
® ©
public		 
sealed		 
record		 
ProductInCombo		 #
(		# $
Guid		$ (
	ProductId		) 2
)		2 3
;		3 4
public

 
class

 
CreateComboHandler

 
(

  
IUnitOfWorks

  ,
unitOfWorks

- 8
,

8 9
IClaimService

: G
claimService

H T
)

T U
:

V W
IRequestHandler

X g
<

g h
CreateComboCommand

h z
,

z {
Guid	

| Ä
>


Ä Å
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
IClaimService "
_claimService# 0
=1 2
claimService3 ?
;? @
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #
CreateComboCommand# 5
request6 =
,= >
CancellationToken? P
cancellationTokenQ b
)b c
{ 
Guid 
restaurantId 
= 
_claimService )
.) *
RestaurantId* 6
;6 7
Combo 
combo 
= 
new 
( 
request !
.! "
	ComboName" +
,+ ,
request- 4
.4 5
Quantity5 =
,= >
request? F
.F G
PriceG L
,L M
requestN U
.U V
ExpiredDateV a
,a b
_claimServicec p
.p q
RestaurantIdq }
)} ~
;~ 
await 
_unitOfWorks 
. 
ComboRepository *
.* +
AddAsync+ 3
(3 4
combo4 9
)9 :
;: ;
decimal 

totalPrice 
= 
$num 
; 
foreach 
( 
var 
item 
in 
request $
.$ %
ProductInCombos% 4
)4 5
{ 	
Product 
product 
= 
await #
_unitOfWorks$ 0
.0 1
ProductRepository1 B
.B C
FirstOrDefaultAsyncC V
(V W
xW X
=>Y [
x\ ]
.] ^
RestaurantId^ j
==k m
restaurantIdn z
&&{ }
x~ 
.	 Ä
Id
Ä Ç
==
É Ö
item
Ü ä
)
ä ã
??
å é
throw
è î
new
ï ò
	Exception
ô ¢
(
¢ £
)
£ §
;
§ •

totalPrice 
+= 
( 
decimal "
)" #
product# *
.* +
Price+ 0
;0 1
await 
_unitOfWorks 
. "
ProductComboRepository 5
.5 6
AddAsync6 >
(> ?
new? B
(B C
itemC G
,G H
comboI N
.N O
IdO Q
)Q R
)R S
;S T
} 	
combo 
. 
PercentReduce 
= 

totalPrice (
;( )
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
combo 
. 
Id 
; 
} 
}   ©
ÄC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Combos\Commands\Active\ActiveComboHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Combos# )
.) *
Commands* 2
.2 3
Active3 9
;9 :
public 
sealed 
record 
ActvieComboCommand '
(' (
Guid( ,
ComboId- 4
)4 5
:6 7
IRequest8 @
<@ A
ResultA G
>G H
;H I
public		 
class		 
ActiveComboHandler		 
(		  
IUnitOfWorks		  ,
unitOfWorks		- 8
)		8 9
:		: ;
IRequestHandler		< K
<		K L
ActvieComboCommand		L ^
,		^ _
Result		` f
>		f g
{

 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %
ActvieComboCommand% 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ 
Combo 
combo 
= 
await 
_unitOfWorks (
.( )
ComboRepository) 8
.8 9
GetByIdAsync9 E
(E F
requestF M
.M N
ComboIdN U
)U V
??W Y
throwZ _
new` c
	Exceptiond m
(m n
)n o
;o p
combo 
. 
UpdateState 
( 
false 
)  
;  !
_unitOfWorks 
. 
ComboRepository $
.$ %
Update% +
(+ ,
combo, 1
)1 2
;2 3
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ¶
êC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Categories\Queries\GetCategories\GetParentCategoriesQuery.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #

Categories# -
.- .
Queries. 5
.5 6
GetParentCategories6 I
;I J
public 
sealed 
record  
GetCategoriesCommand )
:* +
IRequest, 4
<4 5
List5 9
<9 :'
GetParentCategoriesResponse: U
>U V
>V W
;W X
public 
record '
GetParentCategoriesResponse )
() *
Guid* .
Id/ 1
,1 2
string3 9
Name: >
)> ?
;? @
public

 
class

 $
GetParentCategoriesQuery

 %
(

% &
IUnitOfWorks

& 2
unitOfWorks

3 >
)

> ?
:

@ A
IRequestHandler

B Q
<

Q R 
GetCategoriesCommand

R f
,

f g
List

h l
<

l m(
GetParentCategoriesResponse	

m à
>


à â
>


â ä
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
List 
< '
GetParentCategoriesResponse 6
>6 7
>7 8
Handle9 ?
(? @ 
GetCategoriesCommand@ T
requestU \
,\ ]
CancellationToken^ o
cancellationToken	p Å
)
Å Ç
{ 
var 
	responses 
= 
await 
_unitOfWorks *
.* +
CategoryRepository+ =
.= >
GetAllAsync> I
(I J
)J K
;K L
return 
	responses 
. 
Select 
(  
x  !
=>" $
new% ('
GetParentCategoriesResponse) D
(D E
xE F
.F G
IdG I
,I J
xK L
.L M
CategoryNameM Y
)Y Z
)Z [
.[ \
ToList\ b
(b c
)c d
;d e
} 
} œ
âC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Categories\Commands\Update\UpdateCategoryValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #

Categories# -
.- .
Commands. 6
.6 7
Update7 =
;= >
public 
class #
UpdateCategoryValidator $
:% &
AbstractValidator' 8
<8 9!
UpdateCategoryCommand9 N
>N O
{ 
public		 
#
UpdateCategoryValidator		 "
(		" #$
CheckCategoryIdValidator		# ;
idValidator		< G
,		G H
CheckDuplicateName		I [
nameValidator		\ i
)		i j
{

 
RuleFor 
( 
x 
=> 
x 
. 
CategoryName #
)# $
.$ %
NotEmpty% -
(- .
). /
./ 0
SetValidator0 <
(< =
nameValidator= J
)J K
;K L
RuleFor 
( 
x 
=> 
x 
. 
Id 
) 
. 
NotEmpty #
(# $
)$ %
.% &
SetValidator& 2
(2 3
idValidator3 >
)> ?
;? @
} 
} 
public 
sealed 
class $
CheckCategoryIdValidator ,
:- .
AbstractValidator/ @
<@ A
GuidA E
>E F
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
public 
$
CheckCategoryIdValidator #
(# $
IUnitOfWorks$ 0
unitOfWorks1 <
)< =
{ 
_unitOfWorks 
= 
unitOfWorks "
;" #
RuleFor 
( 

categoryId 
=> 

categoryId (
)( )
.) *
	MustAsync* 3
(3 4
CheckExistId4 @
)@ A
.A B
WithMessageB M
(M N
$strN c
)c d
;d e
} 
private 
async 
Task 
< 
bool 
> 
CheckExistId )
() *
Guid* .

categoryId/ 9
,9 :
CancellationToken; L
tokenM R
)R S
{ 
Category 
? 
category 
= 
await "
_unitOfWorks# /
./ 0
CategoryRepository0 B
.B C
GetByIdAsyncC O
(O P

categoryIdP Z
)Z [
;[ \
return 
category 
!= 
null 
;  
} 
} ˜
áC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Categories\Commands\Update\UpdateCategoryHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #

Categories# -
.- .
Commands. 6
.6 7
Update7 =
;= >
public		 
sealed		 
record		 !
UpdateCategoryCommand		 *
:		+ ,
IRequest		- 5
<		5 6
Result		6 <
>		< =
{

 
[ 

JsonIgnore 
] 
public 

Guid 
Id 
{ 
get 
; 
set 
; 
}  
public 

string 
CategoryName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
} 
public 
class !
UpdateCategoryHandler "
(" #
IUnitOfWorks# /
unitOfWorks0 ;
); <
:= >
IRequestHandler? N
<N O!
UpdateCategoryCommandO d
,d e
Resultf l
>l m
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %!
UpdateCategoryCommand% :
request; B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 
Category 
category 
= 
await !
_unitOfWorks" .
.. /
CategoryRepository/ A
.A B
GetByIdAsyncB N
(N O
requestO V
.V W
IdW Y
)Y Z
??[ ]
throw^ c
newd g
	Exceptionh q
(q r
)r s
;s t
category 
. 
Update 
( 
request 
.  
CategoryName  ,
), -
;- .
_unitOfWorks 
. 
CategoryRepository '
.' (
Update( .
(. /
category/ 7
)7 8
;8 9
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ∆
áC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Categories\Commands\Delete\DeleteCategoryHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #

Categories# -
.- .
Commands. 6
.6 7
Delete7 =
;= >
public 
sealed 
record !
DeleteCategoryCommand *
(* +
Guid+ /
Id0 2
)2 3
:4 5
IRequest6 >
<> ?
Result? E
>E F
;F G
internal		 
class			 !
DeleteCategoryHandler		 $
(		$ %
IUnitOfWorks		% 1
unitOfWorks		2 =
)		= >
:		? @
IRequestHandler		A P
<		P Q!
DeleteCategoryCommand		Q f
,		f g
Result		h n
>		n o
{

 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Result 
> 
Handle $
($ %!
DeleteCategoryCommand% :
request; B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 
Category 
category 
= 
await !
_unitOfWorks" .
.. /
CategoryRepository/ A
.A B
GetByIdAsyncB N
(N O
requestO V
.V W
IdW Y
)Y Z
??[ ]
throw^ c
newd g
	Exceptionh q
(q r
)r s
;s t
category 
. 
SetState 
( 
true 
) 
;  
_unitOfWorks 
. 
CategoryRepository '
.' (
Update( .
(. /
category/ 7
)7 8
;8 9
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
} 
} ∂
ÜC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Categories\Commands\Add\AddNewCategoryValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #

Categories# -
.- .
Commands. 6
.6 7
Add7 :
;: ;
public 
class #
AddNewCategoryValidator $
:% &
AbstractValidator' 8
<8 9!
AddNewCategoryCommand9 N
>N O
{ 
public		 
#
AddNewCategoryValidator		 "
(		" #
CheckDuplicateName		# 5
name		6 :
)		: ;
{

 
RuleFor 
( 
x 
=> 
x 
. 
Name 
) 
. 
NotEmpty %
(% &
)& '
;' (
RuleFor 
( 
x 
=> 
x 
. 
Name 
) 
. 
SetValidator )
() *
name* .
). /
;/ 0
} 
} 
public 
sealed 
class 
CheckDuplicateName &
:' (
AbstractValidator) :
<: ;
string; A
>A B
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
;. /
public 

CheckDuplicateName 
( 
IUnitOfWorks *
unitOfWorks+ 6
)6 7
{ 
_unitOfWorks 
= 
unitOfWorks "
;" #
RuleFor 
( 
name 
=> 
name 
) 
. 
	MustAsync 
( &
CheckDuplicateCategoryName 1
)1 2
. 
WithMessage 
( 
$str <
)< =
;= >
} 
private 
async 
Task 
< 
bool 
> &
CheckDuplicateCategoryName 7
(7 8
string8 >
name? C
,C D
CancellationTokenE V
tokenW \
)\ ]
{ 
Category 
? 
ingredientType  
=! "
await# (
_unitOfWorks) 5
.5 6
CategoryRepository6 H
.H I
FirstOrDefaultAsyncI \
(\ ]
x] ^
=>_ a
xb c
.c d
CategoryNamed p
==q s
namet x
)x y
;y z
return 
ingredientType 
==  
null! %
;% &
}   
}!! Â
ÑC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Categories\Commands\Add\AddNewCategoryHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #

Categories# -
.- .
Commands. 6
.6 7
AddNewChildCategory7 J
;J K
public 
sealed 
record !
AddNewCategoryCommand *
:+ ,
IRequest- 5
<5 6
Guid6 :
>: ;
{ 
public		 

required		 
string		 
Name		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
} 
public 
class !
AddNewCategoryHandler "
(" #
IUnitOfWorks# /
unitOfWorks0 ;
); <
:= >
IRequestHandler? N
<N O!
AddNewCategoryCommandO d
,d e
Guidf j
>j k
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
Guid 
> 
Handle "
(" #!
AddNewCategoryCommand# 8
request9 @
,@ A
CancellationTokenB S
cancellationTokenT e
)e f
{ 
Category 
category 
= 
new 
(  
request  '
.' (
Name( ,
), -
;- .
await 
_unitOfWorks 
. 
CategoryRepository -
.- .
AddAsync. 6
(6 7
category7 ?
)? @
;@ A
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
category 
. 
Id 
; 
} 
} Û
ÉC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Authorize\Queries\Profile\ViewProfileHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
	Authorize# ,
., -
Queries- 4
.4 5
Profile5 <
;< =
public 
sealed 
record 
ViewProfileCommand '
:( )
IRequest* 2
<2 3
ViewProfileResponse3 F
>F G
;G H
public

 
sealed

 
record

 
ViewProfileResponse

 (
(

( )
string

) /
UserId

0 6
,

6 7
string

8 >
LastName

? G
,

G H
string

I O
	FirstName

P Y
)

Y Z
;

Z [
internal 
class	 
ViewProfileHandler !
(! "
UserManager" -
<- .
User. 2
>2 3
userManager4 ?
,? @
IClaimServiceA N
claimServiceO [
)[ \
:] ^
IRequestHandler_ n
<n o
ViewProfileCommand	o Å
,
Å Ç!
ViewProfileResponse
É ñ
>
ñ ó
{ 
private 
readonly 
UserManager  
<  !
User! %
>% &
_userManager' 3
=4 5
userManager6 A
;A B
private 
readonly 
IClaimService "
_claimService# 0
=1 2
claimService3 ?
;? @
public 

async 
Task 
< 
ViewProfileResponse )
>) *
Handle+ 1
(1 2
ViewProfileCommand2 D
requestE L
,L M
CancellationTokenN _
cancellationToken` q
)q r
{ 
User 
response 
= 
await 
_userManager *
.* +
FindByIdAsync+ 8
(8 9
_claimService9 F
.F G
UserIdG M
)M N
??O Q
throwR W
newX [
	Exception\ e
(e f
)f g
;g h
return 
new 
ViewProfileResponse &
(& '
response' /
./ 0
Id0 2
,2 3
response4 <
.< =
LastName= E
,E F
responseG O
.O P
	FirstNameP Y
)Y Z
;Z [
} 
} ·
åC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Authorize\Commands\UserRegister\UserRegisterValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
	Authorize# ,
., -
Commands- 5
.5 6
UserRegister6 B
;B C
public 
sealed 
class !
UserRegisterValidator )
:* +
AbstractValidator, =
<= >
UserRegisterCommand> Q
>Q R
{ 
public 
!
UserRegisterValidator  
(  !
)! "
{ 
RuleFor 
( 
x 
=> 
x 
. 
Email 
) 
.		 
NotNull		 
(		 
)		 
.

 
Matches

 
(

 
$str

 2
)

2 3
. 
WithMessage 
( 
$str 0
)0 1
;1 2
RuleFor 
( 
x 
=> 
x 
. 
Password 
)  
.  !
NotNull! (
(( )
)) *
;* +
RuleFor 
( 
x 
=> 
x 
. 
	FirstName  
)  !
.! "
NotNull" )
() *
)* +
;+ ,
RuleFor 
( 
x 
=> 
x 
. 
LastName 
)  
.  !
NotNull! (
(( )
)) *
;* +
} 
} †1
äC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Authorize\Commands\UserRegister\UserRegisterHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" #
	Authorize		# ,
.		, -
Commands		- 5
.		5 6
UserRegister		6 B
;		B C
public 
sealed 
record 
UserRegisterCommand (
(( )
string) /
Email0 5
,5 6
string7 =
LastName> F
,F G
stringH N
	FirstNameO X
,X Y
stringZ `
Passworda i
,i j
stringk q
Addressr y
)y z
:{ |
IRequest	} Ö
<
Ö Ü
Result
Ü å
>
å ç
;
ç é
public 
class 
UserRegisterHandler  
(  !
UserManager! ,
<, -
User- 1
>1 2
userManager3 >
,> ?
IUnitOfWorks@ L
unitOfWorksM X
,X Y
RoleManagerZ e
<e f
IdentityRolef r
>r s
roleManagert 
)	 Ä
:
Å Ç
IRequestHandler
É í
<
í ì!
UserRegisterCommand
ì ¶
,
¶ ß
Result
® Æ
>
Æ Ø
{ 
private 
readonly 
UserManager  
<  !
User! %
>% &
_userManager' 3
=4 5
userManager6 A
;A B
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
RoleManager  
<  !
IdentityRole! -
>- .
_roleManager/ ;
=< =
roleManager> I
;I J
public 

async 
Task 
< 
Result 
> 
Handle $
($ %
UserRegisterCommand% 8
request9 @
,@ A
CancellationTokenB S
cancellationTokenT e
)e f
{ 
User 
user 
= 
new 
( 
) 
{ 	
UserName 
= 
request 
. 
Email $
,$ %
Email 
= 
request 
. 
Email !
,! "
	FirstName 
= 
request 
.  
	FirstName  )
,) *
LastName 
= 
request 
. 
LastName '
} 	
;	 

var 
result 
= 
await 
_userManager '
.' (
CreateAsync( 3
(3 4
user4 8
,8 9
request: A
.A B
PasswordB J
)J K
;K L
if 

( 
! 
result 
. 
	Succeeded 
) 
throw $
new% (
AppException) 5
(5 6
result6 <
.< =
Errors= C
.C D
FirstD I
(I J
)J K
.K L
DescriptionL W
)W X
;X Y
if 

( 
! 
await 
_roleManager 
.  
RoleExistsAsync  /
(/ 0
Role0 4
.4 5
User5 9
)9 :
): ;
{   	
var!! 

roleResult!! 
=!! 
await!! "
_roleManager!!# /
.!!/ 0
CreateAsync!!0 ;
(!!; <
new!!< ?
IdentityRole!!@ L
(!!L M
Role!!M Q
.!!Q R
User!!R V
)!!V W
)!!W X
;!!X Y
if"" 
("" 
!"" 

roleResult"" 
."" 
	Succeeded"" %
)""% &
throw""' ,
new""- 0
AppException""1 =
(""= >

roleResult""> H
.""H I
Errors""I O
.""O P
First""P U
(""U V
)""V W
.""W X
Description""X c
)""c d
;""d e
}## 	
var&& 
roleAssignResult&& 
=&& 
await&& $
_userManager&&% 1
.&&1 2
AddToRoleAsync&&2 @
(&&@ A
user&&A E
,&&E F
Role&&G K
.&&K L
User&&L P
)&&P Q
;&&Q R
if'' 

('' 
!'' 
roleAssignResult'' 
.'' 
	Succeeded'' '
)''' (
throw'') .
new''/ 2
AppException''3 ?
(''? @
roleAssignResult''@ P
.''P Q
Errors''Q W
.''W X
First''X ]
(''] ^
)''^ _
.''_ `
Description''` k
)''k l
;''l m
await)) 
_unitOfWorks)) 
.)) 
SaveChangeAsync)) *
())* +
)))+ ,
;)), -
Customer++ 
customer++ 
=++ 
new++ 
(++  
)++  !
{,, 	
Address-- 
=-- 
request-- 
.-- 
Address-- %
,--% &
UserId.. 
=.. 
user.. 
... 
Id.. 
}// 	
;//	 

await11 
_unitOfWorks11 
.11 
CustomerRepository11 -
.11- .
AddAsync11. 6
(116 7
customer117 ?
)11? @
;11@ A
await22 
_unitOfWorks22 
.22 
SaveChangeAsync22 *
(22* +
)22+ ,
;22, -
return44 
Result44 
.44 
Ok44 
(44 
)44 
.44 
WithSuccess44 &
(44& '
customer44' /
.44/ 0
Id440 2
.442 3
ToString443 ;
(44; <
)44< =
)44= >
;44> ?
}66 
}77 å

ÜC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Authorize\Commands\UserLogin\UserLoginValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
	Authorize# ,
., -
Commands- 5
.5 6
	UserLogin6 ?
;? @
public 
class 
UserLoginValidator 
:  !
AbstractValidator" 3
<3 4
UserLoginCommand4 D
>D E
{ 
public 

UserLoginValidator 
( 
) 
{		 
RuleFor

 
(

 
x

 
=>

 
x

 
.

 
Email

 
)

 
. 
NotNull 
( 
) 
. 
Matches 
( 
$str 2
)2 3
. 
WithMessage 
( 
$str 0
)0 1
;1 2
RuleFor 
( 
x 
=> 
x 
. 
Password 
)  
.  !
NotNull! (
(( )
)) *
;* +
} 
} Ú<
ÑC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Authorize\Commands\UserLogin\UserLoginHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
	Authorize# ,
., -
Commands- 5
.5 6
	UserLogin6 ?
;? @
public 
sealed 
record 
UserLoginCommand %
(% &
string& ,
Email- 2
,2 3
string4 :
Password; C
)C D
:E F
IRequestG O
<O P
UserResponseP \
>\ ]
;] ^
public 
sealed 
record 
	UserToken 
( 
string %
AccessToken& 1
,1 2
string3 9
RefreshToken: F
)F G
;G H
public 
sealed 
record 
UserResponse !
(! "
string" (
Id) +
,+ ,
string- 3
	FirstName4 =
,= >
string? E
LastNameF N
,N O
stringP V
EmailW \
,\ ]
string^ d
Rolee i
,i j
stringk q
AccessTokenr }
,} ~
string	 Ö
RefreshToken
Ü í
)
í ì
;
ì î
public 
class 
UserLoginHandler 
( 
UserManager )
<) *
User* .
>. /
userManager0 ;
,; <
IConfiguration= K
configurationL Y
)Y Z
:[ \
IRequestHandler] l
<l m
UserLoginCommandm }
,} ~
UserResponse	 ã
>
ã å
{ 
private 
readonly 
UserManager  
<  !
User! %
>% &
_userManager' 3
=4 5
userManager6 A
;A B
private 
readonly 
IConfiguration #
_configuration$ 2
=3 4
configuration5 B
;B C
public 

async 
Task 
< 
UserResponse "
>" #
Handle$ *
(* +
UserLoginCommand+ ;
request< C
,C D
CancellationTokenE V
cancellationTokenW h
)h i
{ 
var 
user 
= 
await 
_userManager %
.% &
FindByEmailAsync& 6
(6 7
request7 >
.> ?
Email? D
)D E
??F H
throwI N
newO R
AppExceptionS _
(_ `
$str` k
)k l
;l m
if 

( 
! 
_userManager 
. 
CheckPasswordAsync ,
(, -
user- 1
,1 2
request3 :
.: ;
Password; C
)C D
.D E
ResultE K
)K L
throwM R
newS V 
KeyNotFoundExceptionW k
(k l
$strl z
)z {
;{ |
var 
roles 
= 
await 
_userManager &
.& '
GetRolesAsync' 4
(4 5
user5 9
)9 :
;: ;
string 
token 
= 
GenerateJWT "
(" #
user# '
,' (
roles) .
,. /
_configuration0 >
[> ?
$str? N
]N O
??P R
throwS X
newY \
AppException] i
(i j
)j k
,k l
_configurationm {
[{ |
$str	| ç
]
ç é
??
è ë
throw
í ó
new
ò õ
AppException
ú ®
(
® ©
)
© ™
,
™ ´
_configuration
¨ ∫
[
∫ ª
$str
ª Œ
]
Œ œ
??
– “
throw
” ÿ
new
Ÿ ‹
AppException
› È
(
È Í
)
Í Î
)
Î Ï
;
Ï Ì
return 
new 
UserResponse 
(  
user  $
.$ %
Id% '
,' (
user) -
.- .
	FirstName. 7
,7 8
user9 =
.= >
LastName> F
,F G
userH L
.L M
EmailM R
,R S
rolesT Y
.Y Z
FirstOrDefaultZ h
(h i
)i j
,j k
tokenl q
,q r
$strs x
)x y
;y z
}   
public## 

static## 
string## 
GenerateJWT## $
(##$ %
User##% )
user##* .
,##. /
IList##0 5
<##5 6
string##6 <
>##< =
	userRoles##> G
,##G H
string##I O
	secretKey##P Y
,##Y Z
string##[ a
issuer##b h
,##h i
string##j p
audience##q y
)##y z
{$$ 
DateTime&& 
secretKeyDatetime&& "
=&&# $
DateTime&&% -
.&&- .
UtcNow&&. 4
;&&4 5
var'' 
securityKey'' 
='' 
new''  
SymmetricSecurityKey'' 2
(''2 3
Encoding''3 ;
.''; <
UTF8''< @
.''@ A
GetBytes''A I
(''I J
	secretKey''J S
)''S T
)''T U
;''U V
var(( 
credentials(( 
=(( 
new(( 
SigningCredentials(( 0
(((0 1
securityKey((1 <
,((< =
SecurityAlgorithms((> P
.((P Q

HmacSha256((Q [
)(([ \
;((\ ]
var)) 
claims)) 
=)) 
new)) 
List)) 
<)) 
Claim)) #
>))# $
{** 
new++ 
(++ 
$str++ 
,++ 
user++ "
.++" #
Id++# %
.++% &
ToString++& .
(++. /
)++/ 0
)++0 1
,++1 2
new,, 
(,, 

ClaimTypes,, 
.,, 
Name,, #
,,,# $
user,,% )
.,,) *
UserName,,* 2
??,,3 5
throw,,6 ;
new,,< ?
AppException,,@ L
(,,L M
$str,,M a
),,a b
),,c d
,,,d e
new-- 
(-- 

ClaimTypes-- 
.--  
Role--  $
,--$ %
	userRoles--% .
.--. /
First--/ 4
(--4 5
)--5 6
)--6 7
,--7 8
}.. 
;.. 
var00 
token00 
=00 
new00 
JwtSecurityToken00 (
(00( )
issuer11 
:11 
issuer11 
,11 
audience22 
:22 
audience22 
,22 
claims33 
:33 
claims33 
,33 
expires44 
:44 
secretKeyDatetime44 &
.44& '

AddMinutes44' 1
(441 2
$num442 7
)447 8
,448 9
signingCredentials55 
:55 
credentials55  +
)55+ ,
;55, -
return77 
new77 #
JwtSecurityTokenHandler77 *
(77* +
)77+ ,
.77, -

WriteToken77- 7
(777 8
token778 =
)77= >
;77> ?
}88 
}:: ¯@
êC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Authorize\Commands\UserGoogleLogin\UserGoogleLoginHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
	Authorize# ,
., -
Commands- 5
.5 6
UserGoogleLogin6 E
;E F
public 
sealed 
record "
UserGoogleLoginCommand +
(+ ,
string, 2
UserName3 ;
,; <
string= C
EmailD I
,I J
stringK Q
GoogleIdR Z
,Z [
string\ b

PictureUrlc m
)m n
:o p
IRequestq y
<y z
Result	z Ä
<
Ä Å
	UserToken
Å ä
>
ä ã
>
ã å
;
å ç
public 
class "
UserGoogleLoginHandler #
(# $
UserManager$ /
</ 0
User0 4
>4 5
userManager6 A
,A B
IUnitOfWorksC O
unitOfWorksP [
,[ \
IConfiguration] k
configurationl y
)y z
:{ |
IRequestHandler	} å
<
å ç$
UserGoogleLoginCommand
ç £
,
£ §
Result
• ´
<
´ ¨
	UserToken
¨ µ
>
µ ∂
>
∂ ∑
{ 
private 
readonly 
UserManager  
<  !
User! %
>% &
_userManager' 3
=4 5
userManager6 A
;A B
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
IConfiguration #
_configuration$ 2
=3 4
configuration5 B
;B C
public 

async 
Task 
< 
Result 
< 
	UserToken &
>& '
>' (
Handle) /
(/ 0"
UserGoogleLoginCommand0 F
requestG N
,N O
CancellationTokenP a
cancellationTokenb s
)s t
{ 
var 
user 
= 
await 
_userManager %
.% &
FindByEmailAsync& 6
(6 7
request7 >
.> ?
UserName? G
)G H
;H I
if 

( 
user 
== 
null 
) 
{ 	
user   
=   
new   
User   
{!! 
UserName"" 
="" 
request"" "
.""" #
UserName""# +
,""+ ,
Email## 
=## 
request## 
.##  
Email##  %
,##% &
}$$ 
;$$ 
var&& 
createResult&& 
=&& 
await&& $
_userManager&&% 1
.&&1 2
CreateAsync&&2 =
(&&= >
user&&> B
)&&B C
;&&C D
var'' 
roleAssignResult''  
=''! "
await''# (
_userManager'') 5
.''5 6
AddToRoleAsync''6 D
(''D E
user''E I
,''I J
Role''K O
.''O P
User''P T
)''T U
;''U V
var(( 
	loginInfo(( 
=(( 
new(( 
UserLoginInfo((  -
(((- .
GoogleDefaults)) 
.))  
AuthenticationScheme)) 3
,))3 4
request** 
.** 
GoogleId**  
,**  !
GoogleDefaults++ 
.++ 
DisplayName++ *
)++* +
;+++ ,
var-- 
loginResult-- 
=-- 
await-- #
_userManager--$ 0
.--0 1
AddLoginAsync--1 >
(--> ?
user--? C
,--C D
	loginInfo--E N
)--N O
;--O P
}00 	
string33 
token33 
=33 
GenerateJWT33 "
(33" #
user33# '
,33' (
Role33) -
.33- .
User33. 2
,332 3
_configuration334 B
[33B C
$str33C R
]33R S
??33T V
throw33W \
new33] `
AppException33a m
(33m n
)33n o
,33o p
_configuration33q 
[	33 Ä
$str
33Ä ë
]
33ë í
??
33ì ï
throw
33ñ õ
new
33ú ü
AppException
33† ¨
(
33¨ ≠
)
33≠ Æ
,
33Æ Ø
_configuration
33∞ æ
[
33æ ø
$str
33ø “
]
33“ ”
??
33‘ ÷
throw
33◊ ‹
new
33› ‡
AppException
33· Ì
(
33Ì Ó
)
33Ó Ô
)
33Ô 
;
33 Ò
await44 
_unitOfWorks44 
.44 
SaveChangeAsync44 *
(44* +
)44+ ,
;44, -
return55 
Result55 
.55 
Ok55 
(55 
new55 
	UserToken55 &
(55& '
token55' ,
,55, -
$str55. 0
)550 1
)551 2
.66 
WithSuccess66 
(66 
new66 
Success66 #
(66# $
$str66$ =
)66= >
)66> ?
;66? @
}77 
public99 

static99 
string99 
GenerateJWT99 $
(99$ %
User99% )
user99* .
,99. /
string990 6
	userRoles997 @
,99@ A
string99B H
	secretKey99I R
,99R S
string99T Z
issuer99[ a
,99a b
string99c i
audience99j r
)99r s
{:: 
DateTime<< 
secretKeyDatetime<< "
=<<# $
DateTime<<% -
.<<- .
UtcNow<<. 4
;<<4 5
var== 
securityKey== 
=== 
new==  
SymmetricSecurityKey== 2
(==2 3
Encoding==3 ;
.==; <
UTF8==< @
.==@ A
GetBytes==A I
(==I J
	secretKey==J S
)==S T
)==T U
;==U V
var>> 
credentials>> 
=>> 
new>> 
SigningCredentials>> 0
(>>0 1
securityKey>>1 <
,>>< =
SecurityAlgorithms>>> P
.>>P Q

HmacSha256>>Q [
)>>[ \
;>>\ ]
var?? 
claims?? 
=?? 
new?? 
List?? 
<?? 
Claim?? #
>??# $
{@@ 
newAA 
(AA 
$strAA 
,AA 
userAA "
.AA" #
IdAA# %
.AA% &
ToStringAA& .
(AA. /
)AA/ 0
)AA0 1
,AA1 2
newBB 
(BB 

ClaimTypesBB 
.BB 
NameBB #
,BB# $
userBB% )
.BB) *
UserNameBB* 2
??BB3 5
throwBB6 ;
newBB< ?
AppExceptionBB@ L
(BBL M
$strBBM ]
)BB] ^
)BB_ `
,BB` a
newCC 
(CC 

ClaimTypesCC 
.CC  
RoleCC  $
,CC$ %
	userRolesCC% .
)CC. /
,CC/ 0
}DD 
;DD 
varFF 
tokenFF 
=FF 
newFF 
JwtSecurityTokenFF (
(FF( )
issuerGG 
:GG 
issuerGG 
,GG 
audienceHH 
:HH 
audienceHH 
,HH 
claimsII 
:II 
claimsII 
,II 
expiresJJ 
:JJ 
secretKeyDatetimeJJ &
.JJ& '

AddMinutesJJ' 1
(JJ1 2
$numJJ2 7
)JJ7 8
,JJ8 9
signingCredentialsKK 
:KK 
credentialsKK  +
)KK+ ,
;KK, -
returnMM 
newMM #
JwtSecurityTokenHandlerMM *
(MM* +
)MM+ ,
.MM, -

WriteTokenMM- 7
(MM7 8
tokenMM8 =
)MM= >
;MM> ?
}NN 
}OO Ò
êC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Authorize\Commands\ForgotPassword\ForgotPasswordValidator.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
	Authorize# ,
., -
Commands- 5
.5 6
ForgotPassword6 D
;D E
internal		 
class			 #
ForgotPasswordValidator		 &
{

 
} ç
éC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Authorize\Commands\ForgotPassword\ForgotPasswordHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
	Authorize# ,
., -
Commands- 5
.5 6
ForgotPassword6 D
;D E
public 
sealed 
record !
ForgotPasswordCommand *
(* +
string+ 1
Email2 7
)7 8
:9 :
IRequest; C
<C D
stringD J
>J K
;K L
public 
class !
ForgotPasswordHandler "
(" #
IUnitOfWorks# /
unitOfWorks0 ;
); <
:= >
IRequestHandler? N
<N O!
ForgotPasswordCommandO d
,d e
stringf l
>l m
{ 
private		 
readonly		 
IUnitOfWorks		 !
_unitOfWorks		" .
=		/ 0
unitOfWorks		1 <
;		< =
public

 

Task

 
<

 
string

 
>

 
Handle

 
(

 !
ForgotPasswordCommand

 4
request

5 <
,

< =
CancellationToken

> O
cancellationToken

P a
)

a b
{ 
throw 
new #
NotImplementedException )
() *
)* +
;+ ,
} 
} ƒA
åC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Authorize\Commands\EmployeeLogin\EmployeeLoginHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
	Authorize# ,
., -
Commands- 5
.5 6
EmployeeLogin6 C
;C D
public 
sealed 
record  
EmployeeLoginCommand )
() *
string* 0
Code1 5
,5 6
string7 =
Password> F
)F G
:H I
IRequestJ R
<R S!
EmployeeLoginResponseS h
>h i
;i j
public 
record !
EmployeeLoginResponse #
(# $
string$ *
AccessToken+ 6
,6 7
string8 >
RefreshToken? K
)K L
;L M
public 
class  
EmployeeLoginHandler !
(! "
IUnitOfWorks" .
unitOfWorks/ :
,: ;
UserManager< G
<G H
UserH L
>L M
userManagerN Y
,Y Z
SignInManager[ h
<h i
Useri m
>m n
signInManagero |
,| }
IConfiguration	~ å
configuration
ç ö
)
ö õ
:
ú ù
IRequestHandler
û ≠
<
≠ Æ"
EmployeeLoginCommand
Æ ¬
,
¬ √#
EmployeeLoginResponse
ƒ Ÿ
>
Ÿ ⁄
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
UserManager  
<  !
User! %
>% &
_userManager' 3
=4 5
userManager6 A
;A B
private 
readonly 
IConfiguration #
_configuration$ 2
=3 4
configuration5 B
;B C
private 
readonly 
SignInManager "
<" #
User# '
>' (
_signInManager) 7
=8 9
signInManager: G
;G H
public 

async 
Task 
< !
EmployeeLoginResponse +
>+ ,
Handle- 3
(3 4 
EmployeeLoginCommand4 H
requestI P
,P Q
CancellationTokenR c
cancellationTokend u
)u v
{ 
var 
employee 
= 
await 
_unitOfWorks )
.) *
EmployeeRepository* <
. 
FirstOrDefaultAsync  
(  !
x! "
=># %
x& '
.' (
EmployeeCode( 4
==5 7
request8 ?
.? @
Code@ D
,D E
xF G
=>H J
xK L
.L M
UserM Q
)Q R
;R S
if 

( 
employee 
== 
null 
|| 
employee  (
.( )
User) -
==. 0
null1 5
)5 6
{ 	
return 
null 
; 
} 	
var!! 
user!! 
=!! 
employee!! 
.!! 
User!!  
;!!  !
var"" 
roles"" 
="" 
await"" 
_userManager"" &
.""& '
GetRolesAsync""' 4
(""4 5
user""5 9
)""9 :
;"": ;
var## 
signIn## 
=## 
await## 
_userManager## '
.##' (
CheckPasswordAsync##( :
(##: ;
user##; ?
,##? @
request##A H
.##H I
Password##I Q
)##Q R
;##R S
if%% 

(%% 
signIn%% 
)%% 
{&& 	
string(( 
	secretKey(( 
=(( 
_configuration(( -
[((- .
$str((. =
]((= >
??((? A
throw((B G
new((H K
	Exception((L U
(((U V
$str((V p
)((p q
;((q r
string)) 
validIssuer)) 
=))  
_configuration))! /
[))/ 0
$str))0 A
]))A B
??))C E
throw))F K
new))L O
	Exception))P Y
())Y Z
$str))Z v
)))v w
;))w x
string** 
validAudience**  
=**! "
_configuration**# 1
[**1 2
$str**2 E
]**E F
??**G I
throw**J O
new**P S
	Exception**T ]
(**] ^
$str**^ |
)**| }
;**} ~
string,, 
token,, 
=,, 
GenerateJWT,, &
(,,& '
user,,' +
,,,+ ,
roles,,- 2
,,,2 3
	secretKey,,4 =
,,,= >
validIssuer,,? J
,,,J K
validAudience,,L Y
,,,Y Z
Guid,,[ _
.,,_ `
NewGuid,,` g
(,,g h
),,h i
),,i j
;,,j k
return-- 
new-- !
EmployeeLoginResponse-- ,
(--, -
token--- 2
,--2 3
$str--4 9
)--9 :
;--: ;
}.. 	
return00 
null00 
;00 
}22 
private66 
static66 
string66 
GenerateJWT66 %
(66% &
User66& *
user66+ /
,66/ 0
IList661 6
<666 7
string667 =
>66= >
	userRoles66? H
,66H I
string66J P
	secretKey66Q Z
,66Z [
string66\ b
issuer66c i
,66i j
string66k q
audience66r z
,66z {
Guid	66| Ä
restaurantId
66Å ç
)
66ç é
{77 
DateTime99 
secretKeyDatetime99 "
=99# $
DateTime99% -
.99- .
UtcNow99. 4
;994 5
var:: 
securityKey:: 
=:: 
new::  
SymmetricSecurityKey:: 2
(::2 3
Encoding::3 ;
.::; <
UTF8::< @
.::@ A
GetBytes::A I
(::I J
	secretKey::J S
)::S T
)::T U
;::U V
var;; 
credentials;; 
=;; 
new;; 
SigningCredentials;; 0
(;;0 1
securityKey;;1 <
,;;< =
SecurityAlgorithms;;> P
.;;P Q

HmacSha256;;Q [
);;[ \
;;;\ ]
var<< 
claims<< 
=<< 
new<< 
List<< 
<<< 
Claim<< #
><<# $
{== 
new>> 
(>> 
$str>> 
,>> 
user>> 
.>> 
Id>> 
.>> 
ToString>> &
(>>& '
)>>' (
)>>( )
,>>) *
new?? 
(?? 
$str?? 
,?? 
restaurantId?? (
.??( )
ToString??) 1
(??1 2
)??2 3
)??3 4
,??4 5
new@@ 
(@@ 

ClaimTypes@@ 
.@@ 
Role@@ 
,@@ 
	userRoles@@ &
.@@& '
First@@' ,
(@@, -
)@@- .
)@@. /
,@@/ 0
}AA 
;AA 
varCC 
tokenCC 
=CC 
newCC 
JwtSecurityTokenCC (
(CC( )
issuerDD 
:DD 
issuerDD 
,DD 
audienceEE 
:EE 
audienceEE 
,EE 
claimsFF 
:FF 
claimsFF 
,FF 
expiresGG 
:GG 
secretKeyDatetimeGG &
.GG& '

AddMinutesGG' 1
(GG1 2
$numGG2 7
)GG7 8
,GG8 9
signingCredentialsHH 
:HH 
credentialsHH  +
)HH+ ,
;HH, -
returnJJ 
newJJ #
JwtSecurityTokenHandlerJJ *
(JJ* +
)JJ+ ,
.JJ, -

WriteTokenJJ- 7
(JJ7 8
tokenJJ8 =
)JJ= >
;JJ> ?
}KK 
}LL õ 
àC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Authorize\Commands\EditProfile\EditProfileHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
	Authorize# ,
., -
Commands- 5
.5 6
EditProfile6 A
;A B
public

 
sealed

 
record

 
EditProfileCommand

 '
:

( )
IRequest

* 2
<

2 3
Result

3 9
>

9 :
{ 
public 

string 
Address 
{ 
get 
;  
set! $
;$ %
}& '
public 

string 
LastName 
{ 
get  
;  !
set" %
;% &
}' (
public 

string 
	FirstName 
{ 
get !
;! "
set# &
;& '
}( )
} 
; 
public 
class 
EditProfileHandler 
(  
IUnitOfWorks  ,
unitOfWorks- 8
,8 9
UserManager: E
<E F
UserF J
>J K
userManagerL W
,W X
IClaimServiceY f
claimServiceg s
)s t
:u v
IRequestHandler	w Ü
<
Ü á 
EditProfileCommand
á ô
,
ô ö
Result
õ °
>
° ¢
{ 
private 
readonly 
UserManager  
<  !
User! %
>% &
_userManager' 3
=4 5
userManager6 A
;A B
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly 
IClaimService "
_claimService# 0
=1 2
claimService3 ?
;? @
public 

async 
Task 
< 
Result 
> 
Handle $
($ %
EditProfileCommand% 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ 
string 
userId 
= 
_claimService %
.% &
UserId& ,
;, -
User 
user 
= 
await 
_userManager &
.& '
FindByIdAsync' 4
(4 5
userId5 ;
); <
??= ?
throw@ E
newF I
	ExceptionJ S
(S T
)T U
;U V
user 
. 
Update 
( 
request 
. 
	FirstName %
,% &
request' .
.. /
LastName/ 7
)7 8
;8 9
Customer 
customer 
= 
await !
_unitOfWorks" .
.. /
CustomerRepository/ A
.A B
FirstOrDefaultAsyncB U
(U V
xV W
=>X Z
x[ \
.\ ]
UserId] c
==d f
userIdg m
)m n
??o q
throwr w
newx {
	Exception	| Ö
(
Ö Ü
)
Ü á
;
á à
customer 
. 
Update 
( 
request 
.  
Address  '
)' (
;( )
_unitOfWorks 
. 
CustomerRepository '
.' (
Update( .
(. /
customer/ 7
)7 8
;8 9
await 
_unitOfWorks 
. 
SaveChangeAsync *
(* +
)+ ,
;, -
return 
Result 
. 
Ok 
( 
) 
; 
}"" 
}## ä$
éC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Authorize\Commands\ChangePassword\ChangePasswordHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
	Authorize# ,
., -
Commands- 5
.5 6
ChangePassword6 D
{ 
public		 

class		 !
ChangePasswordCommand		 &
:		' (
IRequest		) 1
<		1 2
Result		2 8
>		8 9
{

 
public 
string 
OldPassword !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
string2 8
.8 9
Empty9 >
;> ?
public 
string 
NewPassword !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
string2 8
.8 9
Empty9 >
;> ?
public 
string 
ConfirmPassword %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
string6 <
.< =
Empty= B
;B C
} 
internal 
class !
ChangePasswordHandler (
:) *
IRequestHandler+ :
<: ;!
ChangePasswordCommand; P
,P Q
ResultR X
>X Y
{ 
private 
readonly 
IClaimService &
_claimService' 4
;4 5
private 
readonly 
UserManager $
<$ %
User% )
>) *
_userManager+ 7
;7 8
public !
ChangePasswordHandler $
($ %
IClaimService% 2
claimService3 ?
,? @
UserManagerA L
<L M
UserM Q
>Q R
userManagerS ^
)^ _
{ 	
_claimService 
= 
claimService (
;( )
_userManager 
= 
userManager &
;& '
} 	
public 
async 
Task 
< 
Result  
>  !
Handle" (
(( )!
ChangePasswordCommand) >
request? F
,F G
CancellationTokenH Y
cancellationTokenZ k
)k l
{ 	
if 
( 
request 
. 
NewPassword #
!=$ &
request' .
.. /
ConfirmPassword/ >
)> ?
{ 
return   
Result   
.   
Fail   "
(  " #
$str  # V
)  V W
;  W X
}!! 
User$$ 
?$$ 
user$$ 
=$$ 
await$$ 
_userManager$$ +
.$$+ ,
FindByIdAsync$$, 9
($$9 :
_claimService$$: G
.$$G H
UserId$$H N
)$$N O
;$$O P
if%% 
(%% 
user%% 
==%% 
null%% 
)%% 
{&& 
return'' 
Result'' 
.'' 
Fail'' "
(''" #
$str''# >
)''> ?
;''? @
}(( 
var++  
changePasswordResult++ $
=++% &
await++' ,
_userManager++- 9
.++9 :
ChangePasswordAsync++: M
(++M N
user++N R
,++R S
request++T [
.++[ \
OldPassword++\ g
,++g h
request++i p
.++p q
NewPassword++q |
)++| }
;++} ~
if,, 
(,,  
changePasswordResult,, $
.,,$ %
	Succeeded,,% .
),,. /
{-- 
return.. 
Result.. 
... 
Ok..  
(..  !
)..! "
;.." #
}// 
var22 
errors22 
=22  
changePasswordResult22 -
.22- .
Errors22. 4
.224 5
Select225 ;
(22; <
e22< =
=>22> @
e22A B
.22B C
Description22C N
)22N O
.22O P
ToList22P V
(22V W
)22W X
;22X Y
return33 
Result33 
.33 
Fail33 
(33 
errors33 %
)33% &
;33& '
}44 	
}55 
}66 ¸5
ôC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Attendances\Queries\GetDailyAttendances\GetDailyAttendancesHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Attendances# .
.. /
Queries/ 6
.6 7
GetDailyAttendances7 J
;J K
public 
sealed 
record %
GetDailyAttendanceCommand .
(. /
PagingRequest/ <
?< =
PagingRequest> K
,K L
boolM Q
?Q R
	IsCheckInS \
)\ ]
:^ _
IRequest` h
<h i
PagedResulti t
<t u'
GetDailyAttendanceResponse	u è
>
è ê
>
ê ë
;
ë í
public 
sealed 
record &
GetDailyAttendanceResponse /
(/ 0
Guid0 4
Id5 7
,7 8
DateTimeOffset9 G
?G H
CheckInTimeI T
,T U
WaiterScheduleDtoV g
WaiterScheduleh v
)v w
;w x
public 
record 
WaiterScheduleDto 
(  
Guid  $
Id% '
,' (
EmployeeDto) 4
Employee5 =
,= >
ShiftDto? G
ShiftH M
)M N
;N O
public 
class &
GetDailyAttendancesHandler '
(' (
IUnitOfWorks( 4
unitOfWorks5 @
)@ A
:B C
IRequestHandlerD S
<S T%
GetDailyAttendanceCommandT m
,m n
PagedResulto z
<z {'
GetDailyAttendanceResponse	{ ï
>
ï ñ
>
ñ ó
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
PagedResult !
<! "&
GetDailyAttendanceResponse" <
>< =
>= >
Handle? E
(E F%
GetDailyAttendanceCommandF _
request` g
,g h
CancellationTokeni z
cancellationToken	{ å
)
å ç
{ 
DateOnly 
today 
= 
DateOnly !
.! "
FromDateTime" .
(. /
DateTime/ 7
.7 8
Today8 =
)= >
;> ?
var 
	schedules 
= 
( 
await 
_unitOfWorks +
.+ ,$
WaiterScheduleRepository, D
. 
GetAllAsync 
( 
s 
=> 
s 
.  
Attendances  +
,+ ,
s- .
=>/ 1
s2 3
.3 4
Employee4 <
,< =
s> ?
=>@ B
sC D
.D E
ShiftE J
)J K
)K L
. 
Where 
( 
s 
=> 
s 
. 
DateTime "
==# %
today& +
)+ ,
;, -
if 

( 
request 
. 
	IsCheckIn 
. 
HasValue &
)& '
{ 	
if 
( 
request 
. 
	IsCheckIn !
.! "
Value" '
)' (
{ 
	schedules 
= 
	schedules %
.% &
Where& +
(+ ,
s, -
=>. 0
s1 2
.2 3
Attendances3 >
.> ?
Any? B
(B C
aC D
=>E G
aH I
.I J
CheckInTimeJ U
!=V X
nullY ]
)] ^
)^ _
;_ `
}   
else!! 
{"" 
	schedules## 
=## 
	schedules## %
.##% &
Where##& +
(##+ ,
s##, -
=>##. 0
s##1 2
.##2 3
Attendances##3 >
.##> ?
All##? B
(##B C
a##C D
=>##E G
a##H I
.##I J
CheckInTime##J U
==##V X
null##Y ]
)##] ^
)##^ _
;##_ `
}$$ 
}%% 	
var&& 
attendanceList&& 
=&& 
	schedules&& &
.&&& '
Select&&' -
(&&- .
s&&. /
=>&&0 2
new&&3 6&
GetDailyAttendanceResponse&&7 Q
(&&Q R
s'' 
.'' 
Id'' 
,'' 
s(( 
.(( 
Attendances(( 
.(( 
FirstOrDefault(( (
(((( )
)(() *
?((* +
.((+ ,
CheckInTime((, 7
,((7 8
new)) 
WaiterScheduleDto)) !
())! "
s** 
.** 
Id** 
,** 
new++ 
EmployeeDto++ 
(++  
s++  !
.++! "

EmployeeId++" ,
,++, -
s++. /
.++/ 0
Employee++0 8
.++8 9
EmployeeCode++9 E
)++E F
,++F G
new,, 
ShiftDto,, 
(,, 
s,, 
.,, 
ShiftId,, &
,,,& '
s,,( )
.,,) *
Shift,,* /
.,,/ 0
	ShiftName,,0 9
),,9 :
)-- 
).. 	
)..	 

...
 
ToList.. 
(.. 
).. 
;.. 
var00 
(00 
page00 
,00 
pageSize00 
,00 
sortType00 %
,00% &
	sortField00' 0
)000 1
=002 3
PaginationUtils004 C
.00C D)
GetPaginationAndSortingValues00D a
(00a b
request00b i
.00i j
PagingRequest00j w
)00w x
;00x y
var11 
sortedResults11 
=11 
PaginationHelper11 ,
<11, -&
GetDailyAttendanceResponse11- G
>11G H
.11H I
Sorting11I P
(11P Q
sortType11Q Y
,11Y Z
attendanceList11[ i
,11i j
	sortField11k t
)11t u
;11u v
var22 
result22 
=22 
PaginationHelper22 %
<22% &&
GetDailyAttendanceResponse22& @
>22@ A
.22A B
Paging22B H
(22H I
sortedResults22I V
,22V W
page22X \
,22\ ]
pageSize22^ f
)22f g
;22g h
return44 
result44 
;44 
}55 
}66 Å*
sC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Common\Behaviours\ValidationBehaviour.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Common		  
.		  !

Behaviours		! +
;		+ ,
public 
sealed 
class 
ValidationBehavior &
<& '
TRequest' /
,/ 0
	TResponse1 :
>: ;
(; <
IServiceProvider 
serviceProvider $
,$ %
ILogger 
< 
ValidationBehavior 
< 
TRequest '
,' (
	TResponse) 2
>2 3
>3 4
logger5 ;
); <
: 
IPipelineBehavior 
< 
TRequest  
,  !
	TResponse" +
>+ ,
where 	
TRequest
 
: 
IRequest 
< 
	TResponse '
>' (
where 	
	TResponse
 
: 
notnull 
{ 
public 

async 
Task 
< 
	TResponse 
>  
Handle! '
(' (
TRequest 
request 
, "
RequestHandlerDelegate 
< 
	TResponse (
>( )
next* .
,. /
CancellationToken 
cancellationToken +
)+ ,
{ 
const 
string 
behavior 
= 
nameof  &
(& '
ValidationBehavior' 9
<9 :
TRequest: B
,B C
	TResponseD M
>M N
)N O
;O P
logger 
. 
LogInformation 
( 
$str S
,S T
behavior 
, 
typeof 
( 
TRequest %
)% &
.& '
FullName' /
,/ 0
typeof1 7
(7 8
	TResponse8 A
)A B
.B C
FullNameC K
)K L
;L M
logger 
. 
LogDebug 
( 
$str N
,N O
behavior 
, 
typeof 
( 
TRequest %
)% &
.& '
FullName' /
,/ 0
JsonSerializer1 ?
.? @
	Serialize@ I
(I J
requestJ Q
)Q R
)R S
;S T
var!! 

validators!! 
=!! 
serviceProvider!! (
."" 

GetService"" (
<""( )
IEnumerable"") 4
<""4 5

IValidator""5 ?
<""? @
TRequest""@ H
>""H I
>""I J
>""J K
(""K L
)""L M
?""M N
.""N O
ToList""O U
(""U V
)""V W
??## 
throw## !
new##" %%
InvalidOperationException##& ?
(##? @
)##@ A
;##A B
if%% 

(%% 

validators%% 
.%% 
Count%% 
!=%% 
$num%%  !
)%%! "
await&& 
Task&& 
.&& 
WhenAll&& 
(&& 

validators'' 
.'' 
Select'' !
(''! "
v''" #
=>''$ &
v''' (
.''( )!
HandleValidationAsync'') >
(''> ?
request''? F
)''F G
)''G H
)(( 
;(( 
var** 
response** 
=** 
await** 
next** !
(**! "
)**" #
;**# $
return,, 
response,, 
;,, 
}-- 
}.. 
public// 
static// 
class// 

Validation// 
{00 
public11 

static11 
async11 
Task11 !
HandleValidationAsync11 2
<112 3
TRequest113 ;
>11; <
(11< =
this11= A

IValidator11B L
<11L M
TRequest11M U
>11U V
	validator11W `
,11` a
TRequest11b j
request11k r
)11r s
{22 
var33 
validationResult33 
=33 
await33 $
	validator33% .
.33. /
ValidateAsync33/ <
(33< =
request33= D
)33D E
;33E F
var44 
failures44 
=44 
validationResult44 '
.44' (
Errors44( .
;44. /
if66 

(66 
failures66 
.66 
Any66 
(66 
)66 
)66 
{77 	
var88 
errorMessages88 
=88 
string88  &
.88& '
Join88' +
(88+ ,
$str88, 0
,880 1
failures882 :
.88: ;
Select88; A
(88A B
f88B C
=>88D F
f88G H
.88H I
ErrorMessage88I U
)88U V
)88V W
;88W X
throw99 
new99 
AppException99 "
(99" #
errorMessages99# 0
)990 1
;991 2
}:: 	
};; 
}<< ﬁ,
ûC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Attendances\Commands\GenerateCheckInQRCode\GenerateCheckinQRCodeHandler.cs
	namespace 	
FOV
 
. 
Application 
. 
Features "
." #
Attendances# .
.. /
Commands/ 7
.7 8!
GenerateCheckInQRCode8 M
;M N
public 
record (
GenerateCheckInQRCodeCommand *
:+ ,
IRequest- 5
<5 6
string6 <
>< =
{ 
public 

Guid 
RestaurantId 
{ 
get "
;" #
set$ '
;' (
}) *
public 

Guid 
WaiterScheduleId  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 

DateOnly 
Date 
{ 
get 
; 
set  #
;# $
}% &
} 
public 
class (
GenerateCheckinQRCodeHandler )
() *
IUnitOfWorks* 6
unitOfWorks7 B
,B C"
QRCodeGeneratorHandlerD Z"
qRCodeGeneratorHandler[ q
,q r
StorageHandler	s Å
storage
Ç â
)
â ä
:
ã å
IRequestHandler
ç ú
<
ú ù*
GenerateCheckInQRCodeCommand
ù π
,
π ∫
string
ª ¡
>
¡ ¬
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
private 
readonly "
QRCodeGeneratorHandler +#
_qRCodeGeneratorHandler, C
=D E"
qRCodeGeneratorHandlerF \
;\ ]
private 
readonly 
StorageHandler #
_storageHandler$ 3
=4 5
storage6 =
;= >
public 

async 
Task 
< 
string 
> 
Handle $
($ %(
GenerateCheckInQRCodeCommand% A
requestB I
,I J
CancellationTokenK \
cancellationToken] n
)n o
{ 
return 
await (
GenerateAndUploadQRCodeAsync 1
(1 2
request2 9
.9 :
Date: >
,> ?
request@ G
.G H
RestaurantIdH T
,T U
requestV ]
.] ^
WaiterScheduleId^ n
)n o
;o p
} 
private 
async 
Task 
< 
string 
> (
GenerateAndUploadQRCodeAsync ;
(; <
DateOnly< D
dateE I
,I J
GuidK O
restaurantIdP \
,\ ]
Guid^ b
waiterScheduleIdc s
)s t
{ 
var   

restaurant   
=   
_unitOfWorks   %
.  % & 
RestaurantRepository  & :
.  : ;
GetByIdAsync  ; G
(  G H
restaurantId  H T
)  T U
;  U V
if!! 

(!! 

restaurant!! 
==!! 
null!! 
)!! 
{"" 	
throw## 
new## 
	Exception## 
(##  
$str##  9
)##9 :
;##: ;
}$$ 	
var%% 
waiterSchedule%% 
=%% 
_unitOfWorks%% )
.%%) *$
WaiterScheduleRepository%%* B
.%%B C
GetByIdAsync%%C O
(%%O P
waiterScheduleId%%P `
)%%` a
??%%b d
throw%%e j
new%%k n
	Exception%%o x
(%%x y
$str	%%y ò
)
%%ò ô
;
%%ô ö
var'' 
fileName'' 
='' 
$"'' 
$str'' $
{''$ %

restaurant''% /
}''/ 0
$str''0 6
{''6 7
date''7 ;
}''; <
"''< =
;''= >
var(( 
qrUrl(( 
=(( 
$"(( 
$str(( G
{((G H
restaurantId((H T
}((T U
$str((U [
{(([ \
date((\ `
}((` a
$str((a k
{((k l
waiterScheduleId((l |
}((| }
"((} ~
;((~ 
Bitmap** 
qrCodeImage** 
=** #
_qRCodeGeneratorHandler** 4
.**4 5
GenerateQRCode**5 C
(**C D
qrUrl**D I
)**I J
;**J K
using++ 
(++ 
var++ 
memoryStream++ 
=++  !
new++" %
MemoryStream++& 2
(++2 3
)++3 4
)++4 5
{,, 	
qrCodeImage-- 
.-- 
Save-- 
(-- 
memoryStream-- )
,--) *
ImageFormat--+ 6
.--6 7
Png--7 :
)--: ;
;--; <
memoryStream.. 
... 
Seek.. 
(.. 
$num.. 
,..  

SeekOrigin..! +
...+ ,
Begin.., 1
)..1 2
;..2 3
var00 
storageFile00 
=00 
await00 #
_storageHandler00$ 3
.003 4+
UploadQrImageForAttendanceAsync004 S
(00S T
memoryStream00T `
,00` a
fileName00b j
)00j k
;00k l
return11 
storageFile11 
.11 
FileUrl11 &
;11& '
}22 	
}33 
}44 †*
íC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Features\Attendances\Commands\CheckAttendance\CheckAttendanceHandler.cs
	namespace		 	
FOV		
 
.		 
Application		 
.		 
Features		 "
.		" #
Attendances		# .
.		. /
Commands		/ 7
.		7 8
CheckAttendance		8 G
;		G H
public

 
record

 "
CheckAttendanceCommand

 $
(

$ %
Guid

% )

EmployeeId

* 4
,

4 5
Guid

6 :
RestaurantId

; G
,

G H
Guid

I M
WaiterScheduleId

N ^
,

^ _
DateOnly

` h
Date

i m
)

m n
:

o p
IRequest

q y
<

y z
string	

z Ä
>


Ä Å
;


Å Ç
public 
class "
CheckAttendanceHandler #
(# $
IUnitOfWorks$ 0
unitOfWorks1 <
)< =
:> ?
IRequestHandler@ O
<O P"
CheckAttendanceCommandP f
,f g
stringh n
>n o
{ 
private 
readonly 
IUnitOfWorks !
_unitOfWorks" .
=/ 0
unitOfWorks1 <
;< =
public 

async 
Task 
< 
string 
> 
Handle $
($ %"
CheckAttendanceCommand% ;
request< C
,C D
CancellationTokenE V
cancellationTokenW h
)h i
{ 
var 

restaurant 
= 
await 
_unitOfWorks +
.+ , 
RestaurantRepository, @
.@ A
GetByIdAsyncA M
(M N
requestN U
.U V
RestaurantIdV b
)b c
??d f
throwg l
newm p
	Exceptionq z
(z {
$str	{ î
)
î ï
;
ï ñ
var 
employee 
= 
await 
_unitOfWorks )
.) *
EmployeeRepository* <
.< =
GetByIdAsync= I
(I J
requestJ Q
.Q R

EmployeeIdR \
)\ ]
??^ `
throwa f
newg j
	Exceptionk t
(t u
$str	u è
)
è ê
;
ê ë
var 
waiterSchedule 
= 
await "
_unitOfWorks# /
./ 0$
WaiterScheduleRepository0 H
.H I
GetByIdAsyncI U
(U V
requestV ]
.] ^
WaiterScheduleId^ n
)n o
??p r
throws x
newy |
	Exception	} Ü
(
Ü á
$str
á †
)
† °
;
° ¢
if 

( 
waiterSchedule 
. 
DateTime #
!=$ &
request' .
.. /
Date/ 3
)3 4
{ 	
throw 
new 
	Exception 
(  
$str  3
)3 4
;4 5
} 	
if 

( 
waiterSchedule 
. 

EmployeeId %
!=& (
request) 0
.0 1

EmployeeId1 ;
); <
{ 	
throw 
new 
	Exception 
(  
$str  8
)8 9
;9 :
} 	
var 

attendance 
= 
await 
_unitOfWorks +
.+ , 
AttendanceRepository, @
.@ A-
!GetByEmployeeScheduleAndDateAsyncA b
(b c
requestc j
.j k

EmployeeIdk u
,u v
requestw ~
.~ 
WaiterScheduleId	 è
,
è ê
request
ë ò
.
ò ô
Date
ô ù
)
ù û
;
û ü
if 

( 

attendance 
!= 
null 
) 
{   	
throw!! 
new!! 
	Exception!! 
(!!  
$str!!  <
)!!< =
;!!= >
}"" 	
var$$ 
newAttendance$$ 
=$$ 
new$$ 
Domain$$  &
.$$& '
Entities$$' /
.$$/ 0 
AttendanceAggregator$$0 D
.$$D E

Attendance$$E O
{%% 	

EmployeeId&& 
=&& 
request&&  
.&&  !

EmployeeId&&! +
,&&+ ,
WaiterScheduleId'' 
='' 
request'' &
.''& '
WaiterScheduleId''' 7
,''7 8
CheckInTime(( 
=(( 
DateTimeOffset(( (
.((( )
UtcNow(() /
.((/ 0
AddHours((0 8
(((8 9
$num((9 :
)((: ;
})) 	
;))	 

await++ 
_unitOfWorks++ 
.++  
AttendanceRepository++ /
.++/ 0
AddAsync++0 8
(++8 9
newAttendance++9 F
)++F G
;++G H
await,, 
_unitOfWorks,, 
.,, 
SaveChangeAsync,, *
(,,* +
),,+ ,
;,,, -
return-- 
$str-- %
;--% &
}.. 
}//  
aC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\DependencyInjection.cs
	namespace

 	
FOV


 
.

 
Application

 
;

 
public 
static 
class 
DependencyInjection '
{ 
public 

static 
IServiceCollection $
AddApplicationDI% 5
(5 6
this6 :
IServiceCollection; M
servicesN V
)V W
{ 
services 
. '
AddValidatorsFromAssemblies ,
(, -
[- .
AssemblyReference. ?
.? @
	Executing@ I
]I J
)J K
;K L
services 
. 

AddMediatR 
( 
cfg 
=>  "
{ 	
cfg 
. *
RegisterServicesFromAssemblies .
(. /
	AppDomain/ 8
.8 9
CurrentDomain9 F
.F G
GetAssembliesG T
(T U
)U V
)V W
;W X
cfg 
. 
AddBehavior 
( 
typeof "
(" #
IPipelineBehavior# 4
<4 5
,5 6
>6 7
)7 8
,8 9
typeof: @
(@ A
ValidationBehaviorA S
<S T
,T U
>U V
)V W
,W X
ServiceLifetime '
.' (
Scoped( .
). /
;/ 0
} 	
)	 

;
 
services 
. 
	AddScoped 
< 
IClaimService (
,( )
ClaimService* 6
>6 7
(7 8
)8 9
;9 :
return 
services 
; 
} 
} 
public 
static 
class 
AssemblyReference %
{ 
public   

static   
readonly   
Assembly   #
	Executing  $ -
=  . /
Assembly  0 8
.  8 9 
GetExecutingAssembly  9 M
(  M N
)  N O
;  O P
public!! 

static!! 
readonly!! 
Assembly!! #
Assembly!!$ ,
=!!- .
typeof!!/ 5
(!!5 6
AssemblyReference!!6 G
)!!G H
.!!H I
Assembly!!I Q
;!!Q R
}"" û
jC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Common\Exceptions\FieldError.cs
	namespace 	
FOV
 
. 
Application 
. 
Common  
.  !

Exceptions! +
;+ ,
public 
class 

FieldError 
{		 
public

 

string

 
Field

 
{

 
get

 
;

 
set

 "
;

" #
}

$ %
public 

string 
Message 
{ 
get 
;  
set! $
;$ %
}& '
} ¯
vC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Common\Exceptions\ErrorHandlerMiddleware.cs
	namespace 	
FOV
 
. 
Application 
. 
Common  
.  !

Exceptions! +
;+ ,
public 
class "
ErrorHandlerMiddleware #
{ 
private 
readonly 
RequestDelegate $
_next% *
;* +
public		 
"
ErrorHandlerMiddleware		 !
(		! "
RequestDelegate		" 1
next		2 6
)		6 7
{

 
_next 
= 
next 
; 
} 
public 

async 
Task 
Invoke 
( 
HttpContext (
context) 0
)0 1
{ 
try 
{ 	
await 
_next 
( 
context 
)  
;  !
} 	
catch 
( 
	Exception 
error 
) 
{ 	
var 
response 
= 
context "
." #
Response# +
;+ ,
response 
. 
ContentType  
=! "
$str# 5
;5 6
response 
. 

StatusCode 
=  !
error" '
switch( .
{ 
AppException 
=> 
(  !
int! $
)$ %
HttpStatusCode% 3
.3 4

BadRequest4 >
,> ? 
KeyNotFoundException $
=>% '
(( )
int) ,
), -
HttpStatusCode- ;
.; <
NotFound< D
,D E
_ 
=> 
( 
int 
) 
HttpStatusCode (
.( )
InternalServerError) <
,< =
} 
; 
var 
result 
= 
JsonSerializer '
.' (
	Serialize( 1
(1 2
new2 5
{6 7
message8 ?
=@ A
errorB G
?G H
.H I
MessageI P
}Q R
)R S
;S T
await 
response 
. 

WriteAsync %
(% &
result& ,
), -
;- .
}   	
}!! 
}"" å1
lC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Common\Exceptions\AppException.cs
	namespace 	
FOV
 
. 
Application 
. 
Common  
.  !

Exceptions! +
;+ ,
public 
class 
AppException 
: 
	Exception %
{ 
public 

List 
< 
string 
> 
Errors 
{  
get! $
;$ %
}& '
public 

List 
< 

FieldError 
> 
FieldErrors '
{( )
get* -
;- .
}/ 0
public		 

AppException		 
(		 
)		 
:		 
base		  
(		  !
)		! "
{

 
Errors 
= 
new 
List 
< 
string  
>  !
(! "
)" #
;# $
FieldErrors 
= 
new 
List 
< 

FieldError )
>) *
(* +
)+ ,
;, -
} 
public 

AppException 
( 
string 
message &
)& '
:( )
base* .
(. /
message/ 6
)6 7
{ 
Errors 
= 
new 
List 
< 
string  
>  !
{" #
message$ +
}, -
;- .
FieldErrors 
= 
new 
List 
< 

FieldError )
>) *
(* +
)+ ,
;, -
} 
public 

AppException 
( 
List 
< 
string #
># $
errors% +
)+ ,
:- .
base/ 3
(3 4
$str4 R
)R S
{ 
Errors 
= 
errors 
?? 
new 
List #
<# $
string$ *
>* +
(+ ,
), -
;- .
FieldErrors 
= 
new 
List 
< 

FieldError )
>) *
(* +
)+ ,
;, -
} 
public 

AppException 
( 
string 
message &
,& '
List( ,
<, -
string- 3
>3 4
errors5 ;
); <
:= >
base? C
(C D
messageD K
)K L
{ 
Errors 
= 
errors 
?? 
new 
List #
<# $
string$ *
>* +
(+ ,
), -
;- .
FieldErrors 
= 
new 
List 
< 

FieldError )
>) *
(* +
)+ ,
;, -
} 
public!! 

AppException!! 
(!! 
string!! 
message!! &
,!!& '
	Exception!!( 1
innerException!!2 @
)!!@ A
:!!B C
base!!D H
(!!H I
message!!I P
,!!P Q
innerException!!R `
)!!` a
{"" 
Errors## 
=## 
new## 
List## 
<## 
string##  
>##  !
{##" #
message##$ +
}##, -
;##- .
FieldErrors$$ 
=$$ 
new$$ 
List$$ 
<$$ 

FieldError$$ )
>$$) *
($$* +
)$$+ ,
;$$, -
}%% 
public'' 

AppException'' 
('' 
string'' 
message'' &
,''& '
List''( ,
<'', -
string''- 3
>''3 4
errors''5 ;
,''; <
	Exception''= F
innerException''G U
)''U V
:''W X
base''Y ]
(''] ^
message''^ e
,''e f
innerException''g u
)''u v
{(( 
Errors)) 
=)) 
errors)) 
??)) 
new)) 
List)) #
<))# $
string))$ *
>))* +
())+ ,
))), -
;))- .
FieldErrors** 
=** 
new** 
List** 
<** 

FieldError** )
>**) *
(*** +
)**+ ,
;**, -
}++ 
public-- 

AppException-- 
(-- 
string-- 
message-- &
,--& '
List--( ,
<--, -

FieldError--- 7
>--7 8
fieldErrors--9 D
)--D E
:--F G
base--H L
(--L M
message--M T
)--T U
{.. 
Errors// 
=// 
new// 
List// 
<// 
string//  
>//  !
(//! "
)//" #
;//# $
FieldErrors00 
=00 
fieldErrors00 !
??00" $
new00% (
List00) -
<00- .

FieldError00. 8
>008 9
(009 :
)00: ;
;00; <
}11 
public33 

AppException33 
(33 
string33 
message33 &
,33& '
List33( ,
<33, -

FieldError33- 7
>337 8
fieldErrors339 D
,33D E
	Exception33F O
innerException33P ^
)33^ _
:33` a
base33b f
(33f g
message33g n
,33n o
innerException33p ~
)33~ 
{44 
Errors55 
=55 
new55 
List55 
<55 
string55  
>55  !
(55! "
)55" #
;55# $
FieldErrors66 
=66 
fieldErrors66 !
??66" $
new66% (
List66) -
<66- .

FieldError66. 8
>668 9
(669 :
)66: ;
;66; <
}77 
}88 ê
sC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Common\Behaviours\Claim\IClaimService.cs
	namespace 	
FOV
 
. 
Application 
. 
Common  
.  !

Behaviours! +
.+ ,
Claim, 1
;1 2
public 
	interface 
IClaimService 
{ 
public 

string 
UserId 
{ 
get 
; 
}  !
public 

string 
UserRole 
{ 
get  
;  !
}" #
public 

Guid 
RestaurantId 
{ 
get "
;" #
}$ %
}		 ∫
rC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Application\Common\Behaviours\Claim\ClaimService.cs
	namespace 	
FOV
 
. 
Application 
. 
Common  
.  !

Behaviours! +
.+ ,
Claim, 1
;1 2
public 
class 
ClaimService 
: 
IClaimService )
{ 
public 

ClaimService 
(  
IHttpContextAccessor ,
httpContextAccessor- @
)@ A
{		 
var

 
id

 
=

 
httpContextAccessor

 $
.

$ %
HttpContext

% 0
?

0 1
.

1 2
User

2 6
?

6 7
.

7 8
FindFirstValue

8 F
(

F G
$str

G O
)

O P
;

P Q
UserId 
= 
string 
. 
IsNullOrEmpty %
(% &
id& (
)( )
?* +
$str, R
:S T
idU W
;W X
var 
role 
= 
httpContextAccessor &
.& '
HttpContext' 2
?2 3
.3 4
User4 8
?8 9
.9 :
FindFirstValue: H
(H I

ClaimTypesI S
.S T
RoleT X
)X Y
;Y Z
UserRole 
= 
string 
. 
IsNullOrEmpty '
(' (
role( ,
), -
?. /
Role0 4
.4 5
Administrator5 B
:C D
roleE I
;I J
var 
restaurantId 
= 
httpContextAccessor .
.. /
HttpContext/ :
?: ;
.; <
User< @
?@ A
.A B
FindFirstValueB P
(P Q
$strQ _
)_ `
;` a
RestaurantId 
= 
Guid 
. 
TryParse $
($ %
restaurantId% 1
,1 2
out3 6
Guid7 ;
res< ?
)? @
?A B
RestaurantIdC O
=P Q
resR U
:V W
RestaurantIdX d
=e f
Guidg k
.k l
Parsel q
(q r
$str	r ò
)
ò ô
;
ô ö
} 
public 

string 
UserId 
{ 
get 
; 
}  !
public 

string 
UserRole 
{ 
get  
;  !
}" #
public 

Guid 
RestaurantId 
{ 
get "
;" #
}$ %
} 