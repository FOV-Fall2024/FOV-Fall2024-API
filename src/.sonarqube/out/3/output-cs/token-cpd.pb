Ô
VC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
var		 
conn		 
=			 

builder		 
.		 
Configuration		  
.		  !
GetConnectionString		! 4
(		4 5
$str		5 I
)		I J
;		J K
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. 
AddApplicationDI !
(! "
)" #
;# $
builder 
. 
Services 
. 
AddPresentationDI "
(" #
conn# '
??( *
throw+ 0
new1 4!
ArgumentNullException5 J
(J K
nameofK Q
(Q R
connR V
)V W
,W X
$strY |
)| }
,} ~
builder	 Ü
)
Ü á
;
á à
builder 
. 
Services 
. 
AddInfrastructureDI $
($ %
)% &
;& '
builder 
. 
Services 
. 
AddOpenTelemetry !
(! "
)" #
.# $
WithMetrics$ /
(/ 0
x0 1
=>2 4
{ 
x 
. !
AddPrometheusExporter 
( 
) 
; 
x 
. 
AddMeter 
( 
$str -
,- .
$str -
)- .
;. /
x 
. 
AddView 
( 
$str  
,  !
new 0
$ExplicitBucketHistogramConfiguration 0
{ 	

Boundaries 
= 
[ 
$num 
, 
$num "
," #
$num$ (
,( )
$num* /
,/ 0
$num1 5
,5 6
$num7 <
,< =
$num> A
,A B
$numC G
,G H
$numI L
,L M
$numN Q
]Q R
} 	
)	 

;
 
} 
) 
; 
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
app!! 
.!! 

UseSwagger!! 
(!! 
)!! 
;!! 
app## 
.## 
ApplyMigrations## 
(## 
)## 
;## 
await%% 
app%% 	
.%%	 
#
InitializeDatabaseAsync%%
 !
(%%! "
)%%" #
;%%# $
app(( 
.(( 
MapIdentityApi(( 
<(( 
User(( 
>(( 
((( 
)(( 
;(( 
app++ 
.++ )
MapPrometheusScrapingEndpoint++ !
(++! "
)++" #
;++# $
app,, 
.,, 
UseCookiePolicy,, 
(,, 
),, 
;,, 
app-- 
.-- 
UseAuthorization-- 
(-- 
)-- 
;-- 
app.. 
... 
UseCors.. 
(.. 
$str.. 
).. 
;.. 
app// 
.// 
MapControllers// 
(// 
)// 
;// 
app00 
.00 
UseSwaggerUI00 
(00 
c00 
=>00 
{11 
c22 
.22 
SwaggerEndpoint22 
(22 
$str22 0
,220 1
$str222 >
)22> ?
;22? @
}33 
)33 
;33 
app44 
.44 
Run44 
(44 
)44 	
;44	 
§	
wC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Infrastructure\ValidationExceptionFilter.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Infrastructure )
;) *
public 
class %
ValidationExceptionFilter &
:' (
IExceptionFilter) 9
{		 
public

 

void

 
OnException

 
(

 
ExceptionContext

 ,
context

- 4
)

4 5
{ 
if 

( 
context 
. 
	Exception 
is  
ValidationException! 4
validationException5 H
)H I
{ 	
throw 
new 
AppException "
(" #
validationException# 6
.6 7
Errors7 =
.= >
Select> D
(D E
eE F
=>G I
eJ K
.K L
ErrorMessageL X
)X Y
.Y Z
ToListZ `
(` a
)a b
)b c
;c d
} 	
} 
} Ú3
fC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Infrastructure\EndPoint.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Infrastructure )
;) *
public 
class 
LoginRequest 
{		 
public

 

string

 
Username

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
public 

string 
Password 
{ 
get  
;  !
set" %
;% &
}' (
} 
public 
class !
CustomRegisterRequest "
{ 
[ 
Required 
] 
public 

string 
Username 
{ 
get  
;  !
set" %
;% &
}' (
[ 
Required 
] 
[ 
EmailAddress 
] 
public 

string 
Email 
{ 
get 
; 
set "
;" #
}$ %
[ 
Required 
] 
[ 
StringLength 
( 
$num 
, 
ErrorMessage #
=$ %
$str& d
,d e
MinimumLengthf s
=t u
$numv w
)w x
]x y
[ 
DataType 
( 
DataType 
. 
Password 
)  
]  !
public 

string 
Password 
{ 
get  
;  !
set" %
;% &
}' (
[ 
Required 
] 
public 

string 
	FirstName 
{ 
get !
;! "
set# &
;& '
}( )
[ 
Required 
] 
public   

string   
LastName   
{   
get    
;    !
set  " %
;  % &
}  ' (
}!! 
public## 
static## 
class## 
EndPoint## 
{$$ 
public%% 

static%% 
void%% "
AuthenticationEndPoint%% -
(%%- .
this%%. 2
WebApplication%%3 A
app%%B E
)%%E F
{&& 
app'' 
.'' 
MapIdentityApi'' 
<'' 
User'' 
>''  
(''  !
)''! "
;''" #
})) 
public++ 

static++ 
void++ 
AddCustomEndpoints++ )
(++) *
this++* .
WebApplication++/ =
app++> A
)++A B
{,, 
app.. 
... 
MapPost.. 
(.. 
$str.. 
,..  
async..! &
(..' (
HttpContext..( 3
context..4 ;
,..; <
UserManager..= H
<..H I
User..I M
>..M N
userManager..O Z
,..Z [
IEmailSender..\ h
emailSender..i t
)..t u
=>..v x
{// 	
var00 
registerRequest00 
=00  !
await00" '
context00( /
.00/ 0
Request000 7
.007 8
ReadFromJsonAsync008 I
<00I J!
CustomRegisterRequest00J _
>00_ `
(00` a
)00a b
;00b c
if11 
(11 
registerRequest11 
==11  "
null11# '
)11' (
{22 
context33 
.33 
Response33  
.33  !

StatusCode33! +
=33, -
StatusCodes33. 9
.339 :
Status400BadRequest33: M
;33M N
return44 
;44 
}55 
var77 
user77 
=77 
new77 
User77 
{88 
UserName99 
=99 
registerRequest99 *
.99* +
Username99+ 3
,993 4
Email:: 
=:: 
registerRequest:: '
.::' (
Email::( -
,::- .
	FirstName;; 
=;; 
registerRequest;; +
.;;+ ,
	FirstName;;, 5
,;;5 6
LastName<< 
=<< 
registerRequest<< *
.<<* +
LastName<<+ 3
}== 
;== 
var>> 
result>> 
=>> 
await>> 
userManager>> *
.>>* +
CreateAsync>>+ 6
(>>6 7
user>>7 ;
,>>; <
registerRequest>>= L
.>>L M
Password>>M U
)>>U V
;>>V W
if?? 
(?? 
result?? 
.?? 
	Succeeded??  
)??  !
{@@ 
varBB 
codeBB 
=BB 
awaitBB  
userManagerBB! ,
.BB, -/
#GenerateEmailConfirmationTokenAsyncBB- P
(BBP Q
userBBQ U
)BBU V
;BBV W
varCC 
callbackUrlCC 
=CC  !
$"CC" $
$strCC$ l
{CCl m
codeCCm q
}CCq r
$strCCr }
"CC} ~
;CC~ 
awaitDD 
emailSenderDD !
.DD! "
SendEmailAsyncDD" 0
(DD0 1
registerRequestDD1 @
.DD@ A
EmailDDA F
,DDF G
$strDDH \
,DD\ ]
callbackUrlDD^ i
)DDi j
;DDj k
contextFF 
.FF 
ResponseFF  
.FF  !

StatusCodeFF! +
=FF, -
StatusCodesFF. 9
.FF9 :
Status201CreatedFF: J
;FFJ K
awaitGG 
contextGG 
.GG 
ResponseGG &
.GG& '
WriteAsJsonAsyncGG' 7
(GG7 8
newGG8 ;
{GG< =
SuccessGG> E
=GGF G
trueGGH L
}GGM N
)GGN O
;GGO P
}HH 
elseII 
{JJ 
contextKK 
.KK 
ResponseKK  
.KK  !

StatusCodeKK! +
=KK, -
StatusCodesKK. 9
.KK9 :
Status400BadRequestKK: M
;KKM N
awaitLL 
contextLL 
.LL 
ResponseLL &
.LL& '
WriteAsJsonAsyncLL' 7
(LL7 8
resultLL8 >
.LL> ?
ErrorsLL? E
)LLE F
;LLF G
}MM 
}NN 	
)NN	 

;NN
 
}OO 
}QQ ≥T
qC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Infrastructure\DependencyInjection.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Infrastructure )
;) *
public 
static 
class 
DependencyInjection '
{ 
public 

static 
IServiceCollection $
AddPresentationDI% 6
(6 7
this7 ;
IServiceCollection< N
servicesO W
,W X
stringY _
connectionString` p
,p q"
WebApplicationBuilder	r á
builder
à è
)
è ê
{ 
services 
. 
	Configure 
< 
ElasticSettings *
>* +
(+ ,
builder, 3
.3 4
Configuration4 A
.A B

GetSectionB L
(L M
$strM ^
)^ _
)_ `
;` a
services 
. %
AddValidatorsFromAssembly *
(* +
typeof+ 1
(1 2
Program2 9
)9 :
.: ;
Assembly; C
)C D
;D E
services 
. 

AddSignalR 
( 
) 
; 
services!! 
.!! 
AddCors!! 
(!! 
options!!  
=>!!! #
{"" 	
options## 
.## 
	AddPolicy## 
(## 
$str## /
,##/ 0
builder$$ 
=>$$ 
builder$$ "
.%% 
AllowAnyOrigin%% #
(%%# $
)%%$ %
.&& 
AllowAnyMethod&& #
(&&# $
)&&$ %
.'' 
AllowAnyHeader'' #
(''# $
)''$ %
)''% &
;''& '
}(( 	
)((	 

;((
 
services00 
.00 
AddOutputCache00 
(00  
)00  !
;00! "
services11 
.11 
AddDbContextPool11 !
<11! "

FOVContext11" ,
>11, -
(11- .
options11. 5
=>116 8
options119 @
.11@ A
	UseNpgsql11A J
(11J K
connectionString11K [
)11[ \
)11\ ]
;11] ^
services22 
.22 
	AddScoped22 
<22 +
ApplicationDbContextInitializer22 :
>22: ;
(22; <
)22< =
;22= >
services33 
.33 
AddSingleton33 
(33 
TimeProvider33 *
.33* +
System33+ 1
)331 2
;332 3
services77 
.77 
AddSingleton77 
<77 "
IConnectionMultiplexer77 4
>774 5
(775 6
sp776 8
=>779 ;
{88 	
var99 
configuration99 
=99  
ConfigurationOptions99  4
.994 5
Parse995 :
(99: ;
builder99; B
.99B C
Configuration99C P
[99P Q
$str99Q t
]99t u
,99u v
true99w {
)99{ |
;99| }
return:: !
ConnectionMultiplexer:: (
.::( )
Connect::) 0
(::0 1
configuration::1 >
)::> ?
;::? @
};; 	
);;	 

;;;
 
services<< 
.<< 
	AddScoped<< 
<<< 
	IDatabase<< $
><<$ %
(<<% &
sp<<& (
=><<) +
{== 	
var>> !
connectionMultiplexer>> %
=>>& '
sp>>( *
.>>* +
GetRequiredService>>+ =
<>>= >"
IConnectionMultiplexer>>> T
>>>T U
(>>U V
)>>V W
;>>W X
return?? !
connectionMultiplexer?? (
.??( )
GetDatabase??) 4
(??4 5
)??5 6
;??6 7
}@@ 	
)@@	 

;@@
 
servicesEE 
.EE 
AddIdentityCoreEE  
<EE  !
UserEE! %
>EE% &
(EE& '
optEE' *
=>EE+ -
optEE. 1
.EE1 2
LockoutEE2 9
.EE9 :
AllowedForNewUsersEE: L
=EEM N
falseEEO T
)EET U
.FF 
AddRolesFF 
<FF 
IdentityRoleFF (
>FF( )
(FF) *
)FF* +
.GG $
AddEntityFrameworkStoresGG +
<GG+ ,

FOVContextGG, 6
>GG6 7
(GG7 8
)GG8 9
.HH 
AddApiEndpointsHH "
(HH" #
)HH# $
;HH$ %
servicesLL 
.LL 
AddAuthenticationLL "
(LL" #
optionsLL# *
=>LL+ -
{MM 	
optionsOO 
.OO %
DefaultAuthenticateSchemeOO -
=OO. /(
CookieAuthenticationDefaultsOO0 L
.OOL M 
AuthenticationSchemeOOM a
;OOa b
optionsPP 
.PP 
DefaultSignInSchemePP '
=PP( )(
CookieAuthenticationDefaultsPP* F
.PPF G 
AuthenticationSchemePPG [
;PP[ \
optionsQQ 
.QQ "
DefaultChallengeSchemeQQ *
=QQ+ ,
GoogleDefaultsQQ- ;
.QQ; < 
AuthenticationSchemeQQ< P
;QQP Q
}RR 	
)RR	 

.SS 
	AddCookieSS 
(SS 
$strSS 
)SS 
.TT 
	AddGoogleTT 
(TT 
optionsTT 
=>TT 
{UU 
optionsVV 
.VV 
ClientIdVV 
=VV 
builderVV "
.VV" #
ConfigurationVV# 0
[VV0 1
$strVV1 Q
]VVQ R
;VVR S
optionsWW 
.WW 
ClientSecretWW 
=WW 
builderWW &
.WW& '
ConfigurationWW' 4
[WW4 5
$strWW5 Y
]WWY Z
;WWZ [
optionsXX 
.XX 
CallbackPathXX 
=XX 
$strXX /
;XX/ 0
}YY 
)YY 
.ZZ 
AddJwtBearerZZ 
(ZZ 
optionsZZ 
=>ZZ 
optionsZZ $
.ZZ$ %%
TokenValidationParametersZZ% >
=ZZ? @
newZZA D%
TokenValidationParametersZZE ^
{[[ 
ValidateIssuer\\ 
=\\ 
false\\ 
,\\ 
ValidateAudience]] 
=]] 
false]]  
,]]  !$
ValidateIssuerSigningKey^^  
=^^! "
true^^# '
,^^' (!
RequireExpirationTime__ 
=__ 
true__  $
,__$ %
IssuerSigningKey`` 
=`` 
new``  
SymmetricSecurityKey`` 3
(``3 4
Systemaa 
.aa 
Textaa 
.aa 
Encodingaa $
.aa$ %
UTF8aa% )
.aa) *
GetBytesaa* 2
(aa2 3
builderbb 
.bb 
Configurationbb )
[bb) *
$strbb* 9
]bb9 :
)bb: ;
)cc 
}dd 
)dd 
;dd 
serviceshh 
.hh 
	Configurehh 
<hh 
CookiePolicyOptionshh .
>hh. /
(hh/ 0
optionshh0 7
=>hh8 :
{ii 	
optionsjj 
.jj !
MinimumSameSitePolicyjj )
=jj* +
SameSiteModejj, 8
.jj8 9
Nonejj9 =
;jj= >
optionskk 
.kk 
Securekk 
=kk 
CookieSecurePolicykk /
.kk/ 0
Alwayskk0 6
;kk6 7
}ll 	
)ll	 

;ll
 
servicesoo 
.oo #
AddEndpointsApiExploreroo (
(oo( )
)oo) *
;oo* +
servicespp 
.pp 
AddSwaggerGenpp 
(pp 
cpp  
=>pp! #
{qq 	
crr 
.rr 

SwaggerDocrr 
(rr 
$strrr 
,rr 
newrr "
OpenApiInforr# .
{rr/ 0
Titlerr1 6
=rr7 8
$strrr9 B
,rrB C
VersionrrD K
=rrL M
$strrrN R
}rrS T
)rrT U
;rrU V
css 
.ss 
EnableAnnotationsss 
(ss  
)ss  !
;ss! "
c~~ 
.~~ "
AddSecurityRequirement~~ $
(~~$ %
new~~% (&
OpenApiSecurityRequirement~~) C
{~~C D
{ 	
new
ÄÄ #
OpenApiSecurityScheme
ÄÄ %
{
ÅÅ 
	Reference
ÇÇ 
=
ÇÇ 
new
ÇÇ 
OpenApiReference
ÇÇ  0
{
ÉÉ 
Type
ÑÑ 
=
ÑÑ 
ReferenceType
ÑÑ &
.
ÑÑ& '
SecurityScheme
ÑÑ' 5
,
ÑÑ5 6
Id
ÖÖ 
=
ÖÖ 
$str
ÖÖ 
}
ÜÜ 
}
áá 
,
áá 
Array
àà 
.
àà 
Empty
àà 
<
àà 
string
àà 
>
àà 
(
àà  
)
àà  !
}
ââ 	
}
ää 
)
ää 
;
ää 
}
ãã 	
)
ãã	 

;
ãã
 
services
åå 
.
åå 
AddDataProtection
åå "
(
åå" #
)
åå# $
;
åå$ %
return
éé 
services
éé 
;
éé 
}
èè 
public
ëë 

static
ëë 
async
ëë 
Task
ëë %
InitializeDatabaseAsync
ëë 4
(
ëë4 5
this
ëë5 9
WebApplication
ëë: H
app
ëëI L
)
ëëL M
{
íí 
app
îî 
.
îî 
UseMiddleware
îî 
<
îî $
ErrorHandlerMiddleware
îî 0
>
îî0 1
(
îî1 2
)
îî2 3
;
îî3 4
using
ññ 
var
ññ 
scope
ññ 
=
ññ 
app
ññ 
.
ññ 
Services
ññ &
.
ññ& '
CreateScope
ññ' 2
(
ññ2 3
)
ññ3 4
;
ññ4 5
var
óó 
initializer
óó 
=
óó 
scope
óó 
.
óó  
ServiceProvider
óó  /
.
óó/ 0 
GetRequiredService
óó0 B
<
óóB C-
ApplicationDbContextInitializer
óóC b
>
óób c
(
óóc d
)
óód e
;
óóe f
await
ôô 
initializer
ôô 
.
ôô 
InitialiseAsync
ôô )
(
ôô) *
)
ôô* +
;
ôô+ ,
await
õõ 
initializer
õõ 
.
õõ 
	SeedAsync
õõ #
(
õõ# $
)
õõ$ %
;
õõ% &
}
ûû 
}üü ¿.
rC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Infrastructure\Core\SuccessResponse.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Infrastructure )
.) *
Core* .
;. /
public 
static 
class 
StatusCodeConfig $
{ 
public 

const 
int 
OK 
= 
$num 
; 
public 

const 
int 
CREATED 
= 
$num "
;" #
public		 

const		 
int		 

NO_CONTENT		 
=		  !
$num		" %
;		% &
}

 
public 
static 
class "
ReasonStatusCodeConfig *
{ 
public 

const 
string 
CREATED 
=  !
$str" ,
;, -
public 

const 
string 
OK 
= 
$str &
;& '
public 

const 
string 
UPDATED 
=  !
$str" ,
;, -
public 

const 
string 
DELETED 
=  !
$str" ,
;, -
} 
public 
class 
SuccessResponse 
< 
T 
> 
{ 
public 

string 
Message 
{ 
get 
;  
set! $
;$ %
}& '
=( )
string* 0
.0 1
Empty1 6
;6 7
public 

int 

StatusCode 
{ 
get 
;  
set! $
;$ %
}& '
public 

string 
ReasonStatusCode "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 

T 
Metadata 
{ 
get 
; 
set  
;  !
}" #
=$ %
default& -
(- .
T. /
)/ 0
;0 1
public 

SuccessResponse 
( 
) 
{ 
}!! 
public## 

SuccessResponse## 
(## 
string## !
message##" )
,##) *
int##+ .

statusCode##/ 9
=##: ;
StatusCodeConfig##< L
.##L M
OK##M O
,##O P
string##Q W
reasonStatus##X d
=##e f"
ReasonStatusCodeConfig##g }
.##} ~
OK	##~ Ä
,
##Ä Å
T
##Ç É
metadata
##Ñ å
=
##ç é
default
##è ñ
(
##ñ ó
T
##ó ò
)
##ò ô
)
##ô ö
{$$ 
Message%% 
=%% 
message%% 
;%% 

StatusCode&& 
=&& 

statusCode&& 
;&&  
ReasonStatusCode'' 
='' 
reasonStatus'' '
;''' (
Metadata(( 
=(( 
metadata(( 
;(( 
})) 
}** 
public-- 
class-- 
	OK_Result-- 
<-- 
T-- 
>-- 
(-- 
string--  
message--! (
=--) *
$str--+ ?
,--? @
T--A B
metadata--C K
=--L M
default--N U
(--U V
T--V W
)--W X
)--X Y
:--Z [
SuccessResponse--\ k
<--k l
T--l m
>--m n
(--n o
message--o v
,--v w
StatusCodeConfig	--x à
.
--à â
OK
--â ã
,
--ã å$
ReasonStatusCodeConfig
--ç £
.
--£ §
OK
--§ ¶
,
--¶ ß
metadata
--® ∞
)
--∞ ±
{.. 
}// 
public11 
class11 
CREATED_Result11 
(11 
string11 "
message11# *
=11+ ,
$str11- B
,11B C
object11D J
metadata11K S
=11T U
null11V Z
)11Z [
:11\ ]
SuccessResponse11^ m
<11m n
object11n t
>11t u
(11u v
message11v }
,11} ~
StatusCodeConfig	11 è
.
11è ê
CREATED
11ê ó
,
11ó ò$
ReasonStatusCodeConfig
11ô Ø
.
11Ø ∞
CREATED
11∞ ∑
,
11∑ ∏
metadata
11π ¡
)
11¡ ¬
{22 
}33 
public55 
class55 
UPDATED_Result55 
(55 
string55 "
message55# *
,55* +
object55, 2
metadata553 ;
=55< =
null55> B
)55B C
:55D E
SuccessResponse55F U
<55U V
object55V \
>55\ ]
(55] ^
message55^ e
,55e f
StatusCodeConfig55g w
.55w x

NO_CONTENT	55x Ç
,
55Ç É$
ReasonStatusCodeConfig
55Ñ ö
.
55ö õ
UPDATED
55õ ¢
,
55¢ £
metadata
55§ ¨
)
55¨ ≠
{66 
}77 
public99 
class99 
DELETED_Result99 
(99 
string99 "
message99# *
,99* +
object99, 2
metadata993 ;
=99< =
null99> B
)99B C
:99D E
SuccessResponse99F U
<99U V
object99V \
>99\ ]
(99] ^
message99^ e
,99e f
StatusCodeConfig99g w
.99w x

NO_CONTENT	99x Ç
,
99Ç É$
ReasonStatusCodeConfig
99Ñ ö
.
99ö õ
DELETED
99õ ¢
,
99¢ £
metadata
99§ ¨
)
99¨ ≠
{:: 
};; €
pC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Infrastructure\Core\ErrorResponse.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Infrastructure )
.) *
Core* .
;. /
public 
static 
class !
ErrorStatusCodeConfig )
{ 
public 

const 
int 
BAD_REQUEST  
=! "
$num# &
;& '
public 

const 
int 
CONFLICT 
= 
$num  #
;# $
} 
public		 
static		 
class		 '
ErrorReasonStatusCodeConfig		 /
{

 
public 

const 
string 
BAD_REQUEST #
=$ %
$str& :
;: ;
public 

const 
string 
CONFLICT  
=! "
$str# 3
;3 4
} 
public 
class 
Error 
< 
T 
> 
{ 
public 

string 
Message 
{ 
get 
;  
set! $
;$ %
}& '
public 

int 

StatusCode 
{ 
get 
;  
set! $
;$ %
}& '
public 

List 
< 
T 
> 
Errors 
{ 
get 
;  
set! $
;$ %
}& '
public 

Error 
( 
) 
{ 
} 
public 

Error 
( 
string 
message 
=  !'
ErrorReasonStatusCodeConfig" =
.= >
BAD_REQUEST> I
,I J
intK N

statusCodeO Y
=Z [!
ErrorStatusCodeConfig\ q
.q r
BAD_REQUESTr }
,} ~
List	 É
<
É Ñ
T
Ñ Ö
>
Ö Ü
errors
á ç
=
é è
null
ê î
)
î ï
{ 
Message 
= 
message 
; 

StatusCode 
= 

statusCode 
;  
Errors   
=   
errors   
;   
}!! 
}"" ñ
ÑC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Infrastructure\BackgroundServer\ScheduleCronJobWorker.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Infrastructure )
.) *
BackgroundServer* :
;: ;
public 
class !
ScheduleCronJobWorker "
:# $$
CronJobBackgroundService% =
{ 
private 
readonly 
ILogger 
< !
ScheduleCronJobWorker 2
>2 3
_logger4 ;
;; <
public 
!
ScheduleCronJobWorker  
(  !
ILogger! (
<( )!
ScheduleCronJobWorker) >
>> ?
logger@ F
)		 	
{

 
_logger 
= 
logger 
; 
Cron 
= 
$str "
;" #
} 
	protected 
override 
async 
Task !
DoWork" (
(( )
CancellationToken) :
stoppingToken; H
)H I
{ 
try 
{ 	
_logger 
. 
LogInformation "
(" #
$str# >
,> ?
DateTimeOffset@ N
.N O
NowO R
)R S
;S T
await 
Task 
. 
Delay 
( 
$num !
,! "
stoppingToken# 0
)0 1
;1 2
} 	
catch 
( 
	Exception 
ex 
) 
{ 	
_logger   
.   
LogError   
(   
ex   
,    
string  ! '
.  ' (
Empty  ( -
)  - .
;  . /
}!! 	
}"" 
}## ¯
ëC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Infrastructure\BackgroundServer\ScheduleCheckIngredientDailyWorker.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Infrastructure )
.) *
BackgroundServer* :
;: ;
public 
class .
"ScheduleCheckIngredientDailyWorker /
:0 1$
CronJobBackgroundService2 J
{ 
private 
readonly 
ILogger 
_logger $
;$ %
private		 
readonly		 
	IMediator		 
	_mediator		 (
;		( )
public 
.
"ScheduleCheckIngredientDailyWorker -
(- .
ILogger. 5
<5 6.
"ScheduleCheckIngredientDailyWorker6 X
>X Y
loggerZ `
,` a
	IMediatorb k
mediatorl t
)t u
{ 
_logger 
= 
logger 
; 
	_mediator 
= 
mediator 
; 
Cron 
= 
$str 
; 
} 
	protected 
override 
async 
Task !
DoWork" (
(( )
CancellationToken) :
stoppingToken; H
)H I
{ 
try 
{ 	
_logger 
. 
LogInformation "
(" #
$str# >
,> ?
DateTimeOffset@ N
.N O
NowO R
)R S
;S T
await 
Task 
. 
Delay 
( 
$num !
,! "
stoppingToken# 0
)0 1
;1 2
} 	
catch 
( 
	Exception 
ex 
) 
{ 	
_logger 
. 
LogError 
( 
ex 
,  
string! '
.' (
Empty( -
)- .
;. /
} 	
} 
}   ù
áC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Infrastructure\BackgroundServer\CronJobBackgroundService.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Infrastructure )
.) *
BackgroundServer* :
;: ;
public 
abstract 
class $
CronJobBackgroundService .
:/ 0
BackgroundService1 B
{ 
	protected 
string 
Cron 
{ 
get 
;  
set! $
;$ %
}& '
	protected		 
override		 
async		 
Task		 !
ExecuteAsync		" .
(		. /
CancellationToken		/ @
stoppingToken		A N
)		N O
{

 
var 
cron 
= 
new 
CronExpression %
(% &
Cron& *
)* +
;+ ,
var 
next 
= 
cron 
. !
GetNextValidTimeAfter -
(- .
DateTimeOffset. <
.< =
Now= @
)@ A
;A B
} 
	protected 
abstract 
Task 
DoWork "
(" #
CancellationToken# 4
stoppingToken5 B
)B C
;C D
} ±
ÑC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Infrastructure\BackgroundServer\CheckIngredientWorker.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Infrastructure )
.) *
BackgroundServer* :
;: ;
public 
class !
CheckIngredientWorker "
:# $
BackgroundService% 6
{ 
private 
readonly 
ILogger 
< !
CheckIngredientWorker 2
>2 3
_logger4 ;
;; <
public 
!
CheckIngredientWorker  
(  !
ILogger 
< !
CheckIngredientWorker %
>% &
logger' -
)- .
{		 
_logger

 
=

 
logger

 
;

 
} 
	protected 
override 
async 
Task !
ExecuteAsync" .
(. /
CancellationToken/ @
stoppingTokenA N
)N O
{ 
_logger 
. 
LogDebug 
( 
$str 8
)8 9
;9 :
await 
DoWork 
( 
stoppingToken "
)" #
;# $
} 
private 
async 
Task 
DoWork 
( 
CancellationToken /
stoppingToken0 =
)= >
{ 
while 
( 
! 
stoppingToken 
. #
IsCancellationRequested 5
)5 6
{ 	
_logger 
. 
LogDebug 
( 
$" 
$str D
"D E
)E F
;F G
await## 
Task## 
.## 
Delay## 
(## 
$num## "
,##" #
stoppingToken##$ 1
)##1 2
;##2 3
}&& 	
_logger(( 
.(( 
LogDebug(( 
((( 
$"(( 
$str(( A
"((A B
)((B C
;((C D
})) 
}** π
mC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Infrastructure\ApplyMigrations.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Infrastructure )
;) *
public 
static 
class 
MigrationExtensions '
{		 
public

 

static

 
void

 
ApplyMigrations

 &
(

& '
this

' +
IApplicationBuilder

, ?
app

@ C
)

C D
{ 
using 
IServiceScope 
scope !
=" #
app$ '
.' (
ApplicationServices( ;
.; <
CreateScope< G
(G H
)H I
;I J
using 

FOVContext 
	dbContext "
=# $
scope% *
.* +
ServiceProvider+ :
.: ;
GetRequiredService; M
<M N

FOVContextN X
>X Y
(Y Z
)Z [
;[ \
try 
{ 	
	dbContext 
. 
Database 
. 
Migrate &
(& '
)' (
;( )
} 	
catch 
( 
NpgsqlException 
ex !
)! "
when# '
(( )
ex) +
.+ ,
Message, 3
.3 4
Contains4 <
(< =
$str= f
)f g
)g h
{ 	
Console 
. 
	WriteLine 
( 
$str I
)I J
;J K
} 	
catch 
( 
	Exception 
ex 
) 
{ 	
Console 
. 
	WriteLine 
( 
$"  
$str  3
{3 4
ex4 6
.6 7
Message7 >
}> ?
"? @
)@ A
;A B
throw 
; 
} 	
} 
}   ı)
lC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\UserController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
public 
class 
UserController 
( 
	IMediator %
mediator& .
,. /
	IDatabase0 9
database: B
)B C
:D E
DefaultControllerF W
{ 
private 
readonly 
	IMediator 
	_mediator (
=) *
mediator+ 3
;3 4
private 
readonly 
	IDatabase 
	_database (
=) *
database+ 3
;3 4
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
Create% +
(+ ,!
CreateEmployeeCommand, A
requestB I
)I J
{ 
try 
{ 	
var   
response   
=   
await    
	_mediator  ! *
.  * +
Send  + /
(  / 0
request  0 7
)  7 8
;  8 9
return!! 
Ok!! 
(!! 
new!! 
	OK_Result!! #
<!!# $
string!!$ *
>!!* +
(!!+ ,
response!!, 4
.!!4 5
Value!!5 :
,!!: ;
null!!< @
)!!@ A
)!!A B
;!!B C
}"" 	
catch""
 
("" 
AppException"" 
ex""  
)""  !
{## 	
return$$ 

BadRequest$$ 
($$ 
new$$ !
Error$$" '
<$$' (

FieldError$$( 2
>$$2 3
($$3 4
$str$$4 L
,$$L M!
ErrorStatusCodeConfig$$N c
.$$c d
BAD_REQUEST$$d o
,$$o p
ex$$q s
.$$s t
FieldErrors$$t 
)	$$ Ä
)
$$Ä Å
;
$$Å Ç
}%% 	
}&& 
[(( 
HttpGet(( 
((( 
$str(( 
)(( 
](( 
public)) 

async)) 
Task)) 
<)) 
IActionResult)) #
>))# $
Get))% (
())( )
[))) *
	FromQuery))* 3
]))3 4
GetUsersCommand))5 D
command))E L
)))L M
{** 
return++ 
Ok++ 
(++ 
await++ 
	_mediator++ !
.++! "
Send++" &
(++& '
command++' .
)++. /
)++/ 0
;++0 1
},, 
[.. 
HttpGet.. 
(.. 
$str.. 
).. 
].. 
public// 

async// 
Task// 
<// 
IActionResult// #
>//# $
GetEmployee//% 0
(//0 1
[//1 2
	FromQuery//2 ;
]//; <!
GetAllEmployeeCommand//= R
command//S Z
)//Z [
{00 
return11 
Ok11 
(11 
await11 
	_mediator11 !
.11! "
Send11" &
(11& '
command11' .
)11. /
)11/ 0
;110 1
}22 
[44 
HttpPost44 
(44 
$str44 
)44 
]44 
public55 

async55 
Task55 
<55 
IActionResult55 #
>55# $
Active55% +
(55+ ,
string55, 2
id553 5
)555 6
{66 
return77 
Ok77 
(77 
await77 
	_mediator77 !
.77! "
Send77" &
(77& '
new77' *!
ActiveEmployeeCommand77+ @
(77@ A
id77A C
)77C D
)77D E
)77E F
;77F G
}88 
[:: 
HttpPost:: 
(:: 
$str:: 
):: 
]:: 
public;; 

async;; 
Task;; 
<;; 
IActionResult;; #
>;;# $
InActive;;% -
(;;- .
string;;. 4
id;;5 7
);;7 8
{<< 
return== 
Ok== 
(== 
await== 
	_mediator== !
.==! "
Send==" &
(==& '
new==' *#
InactvieEmployeeCommand==+ B
(==B C
id==C E
)==E F
)==F G
)==G H
;==H I
}>> 
[@@ 
HttpPost@@ 
(@@ 
$str@@ 
)@@ 
]@@ 
publicAA 

asyncAA 
TaskAA 
<AA 
IActionResultAA #
>AA# $
TestAA% )
(AA) *
)AA* +
{BB 
stringCC 
testKeyCC 
=CC 
$strCC #
;CC# $
stringDD 
	testValueDD 
=DD 
$strDD *
;DD* +
awaitEE 
	_databaseEE 
.EE 
StringSetAsyncEE &
(EE& '
testKeyEE' .
,EE. /
	testValueEE0 9
)EE9 :
;EE: ;
returnFF 
OkFF 
(FF 
)FF 
;FF 
}GG 
}HH ≈+
oC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\TestELkController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
public 
class 
TestELkController 
:  
DefaultController! 2
{ 
private		 
readonly		 
ILogger		 
<		 
TestELkController		 .
>		. /
_logger		0 7
;		7 8
private

 
readonly

 
IUserElasticService

 (
_userElasticService

) <
;

< =
public 

TestELkController 
( 
ILogger $
<$ %
TestELkController% 6
>6 7
logger8 >
,> ?
IUserElasticService 
userElasticService .
). /
{ 
_userElasticService 
= 
userElasticService 0
;0 1
_logger 
= 
logger 
; 
} 
[ 
HttpPost 
( 
$str 
) 
] 
public 

async 
Task 
< 
IActionResult #
># $
CreateIndex% 0
(0 1
string1 7
	IndexName8 A
)A B
{ 
await 
_userElasticService !
.! "&
CreateIndexIfNotExitsAsync" <
(< =
	IndexName= F
)F G
;G H
return 
Created 
( 
) 
; 
} 
[ 
HttpPost 
( 
$str 
) 
] 
public 

async 
Task 
< 
IActionResult #
># $
AddUser% ,
(, -
[- .
FromBody. 6
]6 7

UserDomain8 B
userC G
)G H
{ 
var 
result 
= 
await 
_userElasticService .
.. /
AddOrUpdate/ :
(: ;
user; ?
)? @
;@ A
return 
result 
? 
Ok 
( 
) 
: 

BadRequest )
() *
)* +
;+ ,
} 
[!! 
HttpPost!! 
(!! 
$str!! 
)!! 
]!! 
public"" 

async"" 
Task"" 
<"" 
IActionResult"" #
>""# $

UpdateUser""% /
(""/ 0
[""0 1
FromBody""1 9
]""9 :

UserDomain""; E
user""F J
)""J K
{## 
var$$ 
result$$ 
=$$ 
await$$ 
_userElasticService$$ .
.$$. /
AddOrUpdate$$/ :
($$: ;
user$$; ?
)$$? @
;$$@ A
return%% 
result%% 
?%% 
Ok%% 
(%% 
)%% 
:%% 

BadRequest%% )
(%%) *
)%%* +
;%%+ ,
}&& 
[)) 
HttpGet)) 
()) 
$str)) 
))) 
])) 
public** 

async** 
Task** 
<** 
IActionResult** #
>**# $
GetUser**% ,
(**, -
string**- 3
key**4 7
)**7 8
{++ 
var,, 
user,, 
=,, 
await,, 
_userElasticService,, ,
.,,, -
Get,,- 0
(,,0 1
key,,1 4
),,4 5
;,,5 6
return-- 
user-- 
!=-- 
null-- 
?-- 
Ok--  
(--  !
user--! %
)--% &
:--' (
NotFound--) 1
(--1 2
)--2 3
;--3 4
}.. 
[00 
HttpGet00 
(00 
$str00 
)00 
]00 
public11 

async11 
Task11 
<11 
IActionResult11 #
>11# $
GetUsers11% -
(11- .
)11. /
{22 
var33 
user33 
=33 
await33 
_userElasticService33 ,
.33, -
GetAll33- 3
(333 4
)334 5
;335 6
return44 
user44 
!=44 
null44 
?44 
Ok44  
(44  !
user44! %
)44% &
:44' (
NotFound44) 1
(441 2
)442 3
;443 4
}55 
[77 

HttpDelete77 
(77 
$str77 #
)77# $
]77$ %
public88 

async88 
Task88 
<88 
IActionResult88 #
>88# $

DeleteUser88% /
(88/ 0
string880 6
key887 :
)88: ;
{99 
var:: 
result:: 
=:: 
await:: 
_userElasticService:: .
.::. /
Remove::/ 5
(::5 6
key::6 9
)::9 :
;::: ;
return;; 
result;; 
!=;; 
null;; 
?;; 
Ok;;  "
(;;" #
$str;;# 9
);;9 :
:;;; <
NotFound;;= E
(;;E F
);;F G
;;;G H
}<< 
}==  
mC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\TableController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
v1' )
;) *
public 
class 
TableController 
( 
ISender $
sender% +
)+ ,
:- .
DefaultController/ @
{ 
private 
readonly 
ISender 
_sender $
=% &
sender' -
;- .
[ 
HttpPost 
( 
$str #
)# $
]$ %
public 

async 
Task 
< 
IActionResult #
># $
Add% (
(( )
Guid) -
restaurantId. :
,: ;
[< =
FromBody= E
]E F
CreateTableCommandG Y
requestZ a
)a b
{ 
request 
. 
RestaurantId 
= 
restaurantId +
;+ ,
var 
response 
= 
await 
_sender $
.$ %
Send% )
() *
request* 1
)1 2
;2 3
return 
Ok 
( 
response 
) 
; 
} 
[ 
HttpPost 
( 
$str  
)  !
]! "
public 

async 
Task 
< 
IActionResult #
># $
Active% +
(+ ,
Guid, 0
id1 3
)3 4
{   
var!! 
response!! 
=!! 
await!! 
_sender!! $
.!!$ %
Send!!% )
(!!) *
new!!* -
ActiveTableCommand!!. @
(!!@ A
id!!A C
)!!C D
)!!D E
;!!E F
return"" 
Ok"" 
("" 
response"" 
)"" 
;"" 
}## 
[$$ 
HttpPost$$ 
($$ 
$str$$ "
)$$" #
]$$# $
public%% 

async%% 
Task%% 
<%% 
IActionResult%% #
>%%# $
Inactive%%% -
(%%- .
Guid%%. 2
id%%3 5
)%%5 6
{&& 
var'' 
response'' 
='' 
await'' 
_sender'' $
.''$ %
Send''% )
('') *
new''* - 
InactiveTableCommand''. B
(''B C
id''C E
)''E F
)''F G
;''G H
return(( 
Ok(( 
((( 
response(( 
)(( 
;(( 
})) 
[** 
HttpGet** 
]** 
public++ 

async++ 
Task++ 
<++ 
IActionResult++ #
>++# $
Get++% (
(++( )
[++) *
	FromQuery++* 3
]++3 4
GetTableCommand++5 D
command++E L
)++L M
{,, 
var-- 
response-- 
=-- 
await-- 
_sender-- $
.--$ %
Send--% )
(--) *
command--* 1
)--1 2
;--2 3
return.. 
Ok.. 
(.. 
response.. 
).. 
;.. 
}// 
}00 ›"
mC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\ShiftController.cs
	namespace		 	
FOV		
 
.		 
Presentation		 
.		 
Controllers		 &
.		& '
V1		' )
;		) *
public 
class 
ShiftController 
( 
ISender $
sender% +
)+ ,
:- .
DefaultController/ @
{ 
private 
readonly 
ISender 
_sender $
=% &
sender' -
;- .
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
Add% (
(( )
[) *
FromBody* 2
]2 3
CreateShiftCommand4 F
commandG N
)N O
{ 
var 
response 
= 
await 
_sender $
.$ %
Send% )
() *
command* 1
)1 2
;2 3
return 
Ok 
( 
response 
) 
; 
} 
[ 
	HttpPatch 
( 
$str 
) 
] 
public 

async 
Task 
< 
IActionResult #
># $
Update% +
(+ ,
Guid, 0
id1 3
,3 4
[5 6
FromBody6 >
]> ?
UpdateShiftCommand@ R
commandS Z
)Z [
{ 
var 
updateCommand 
= 
new 
UpdateShiftCommand  2
(2 3
id3 5
,5 6
command7 >
.> ?
	ShiftName? H
,H I
commandJ Q
.Q R
	StartTimeR [
,[ \
command] d
.d e
EndTimee l
)l m
;m n
var 
response 
= 
await 
_sender $
.$ %
Send% )
() *
updateCommand* 7
)7 8
;8 9
return 
Ok 
( 
response 
) 
; 
} 
[ 
HttpPost 
( 
$str  
)  !
]! "
public 

async 
Task 
< 
IActionResult #
># $
Active% +
(+ ,
Guid, 0
id1 3
)3 4
{ 
var 
response 
= 
await 
_sender $
.$ %
Send% )
() *
new* -
ActiveShiftCommand. @
(@ A
idA C
)C D
)D E
;E F
return 
Ok 
( 
response 
) 
; 
}   
[!! 
HttpPost!! 
(!! 
$str!! "
)!!" #
]!!# $
public"" 

async"" 
Task"" 
<"" 
IActionResult"" #
>""# $
Inactive""% -
(""- .
Guid"". 2
id""3 5
)""5 6
{## 
var$$ 
response$$ 
=$$ 
await$$ 
_sender$$ $
.$$$ %
Send$$% )
($$) *
new$$* - 
InactiveShiftCommand$$. B
($$B C
id$$C E
)$$E F
)$$F G
;$$G H
return%% 
Ok%% 
(%% 
response%% 
)%% 
;%% 
}&& 
['' 
HttpGet'' 
]'' 
public(( 

async(( 
Task(( 
<(( 
IActionResult(( #
>((# $
Get((% (
(((( )
[(() *
	FromQuery((* 3
]((3 4
GetShiftRequest((5 D
command((E L
)((L M
{)) 
var** 
response** 
=** 
await** 
_sender** $
.**$ %
Send**% )
(**) *
command*** 1
)**1 2
;**2 3
return++ 
Ok++ 
(++ 
response++ 
)++ 
;++ 
},, 
}-- ¡
pC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\ScheduleController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
public

 
class

 
ScheduleController

 
(

  
ISender

  '
sender

( .
)

. /
:

0 1
DefaultController

2 C
{ 
private 
readonly 
ISender 
_sender $
=% &
sender' -
;- .
[ 
HttpPost 
( 
$str 
) 
] 
public 

async 
Task 
< 
IActionResult #
># $
RegisterSchedule% 5
(5 6#
RegisterScheduleCommand6 M
commandN U
)U V
{ 
var 
result 
= 
await 
_sender "
." #
Send# '
(' (
command( /
)/ 0
;0 1
return 
Ok 
( 
result 
) 
; 
} 
[ 

HttpDelete 
( 
$str 
) 
] 
public 

async 
Task 
< 
IActionResult #
># $
UnregisterSchedule% 7
(7 8%
UnregisterScheduleCommand8 Q
commandR Y
)Y Z
{ 
var 
result 
= 
await 
_sender "
." #
Send# '
(' (
command( /
)/ 0
;0 1
return 
result 
== 
true 
? 
Ok  "
(" #
new# &
{ 	
message 
= 
$str /
} 	
)	 

: 

BadRequest 
( 
) 
; 
} 
[ 
HttpGet 
] 
public 

async 
Task 
< 
IActionResult #
># $
GetSchedule% 0
(0 1
[1 2
	FromQuery2 ;
]; <&
GetEmployeeScheduleRequest= W
requestX _
)_ `
{ 
var 
result 
= 
await 
_sender "
." #
Send# '
(' (
request( /
)/ 0
;0 1
return   
Ok   
(   
result   
)   
;   
}!! 
["" 
HttpGet"" 
("" 
$str"" 
)"" 
]"" 
public## 

async## 
Task## 
<## 
IActionResult## #
>### $
GetDailySchedule##% 5
(##5 6
[##6 7
	FromQuery##7 @
]##@ A#
GetDailyScheduleCommand##B Y
request##Z a
)##a b
{$$ 
var%% 
result%% 
=%% 
await%% 
_sender%% "
.%%" #
Send%%# '
(%%' (
request%%( /
)%%/ 0
;%%0 1
return&& 
Ok&& 
(&& 
result&& 
)&& 
;&& 
}'' 
}(( †C
rC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\RestaurantController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
public 
class  
RestaurantController !
(! "
	IMediator" +
mediator, 4
)4 5
:6 7
DefaultController8 I
{ 
private 
readonly 
	IMediator 
	_mediator (
=) *
mediator+ 3
;3 4
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
AddRestaurant% 2
(2 3#
CreateRestaurantCommand3 J
commandK R
)R S
{ 
try 
{ 	
var 
response 
= 
await  
	_mediator! *
.* +
Send+ /
(/ 0
command0 7
)7 8
;8 9
return 
Ok 
( 
new 
	OK_Result #
<# $
Guid$ (
>( )
() *
$str* H
,H I
responseJ R
)R S
)S T
;T U
} 	
catch 
( 
AppException 
ex 
) 
{ 	
return 

BadRequest 
( 
new !
Error" '
<' (

FieldError( 2
>2 3
(3 4
$str4 L
,L M!
ErrorStatusCodeConfigN c
.c d
BAD_REQUESTd o
,o p
exq s
.s t
FieldErrorst 
)	 Ä
)
Ä Å
;
Å Ç
} 	
}   
["" 
HttpGet"" 
]"" 
public## 

async## 
Task## 
<## 
IActionResult## #
>### $
GetMenu##% ,
(##, -
[##- .
	FromQuery##. 7
]##7 8 
GetRestaurantCommand##9 M
query##N S
)##S T
{$$ 
var%% 
response%% 
=%% 
await%% 
	_mediator%% &
.%%& '
Send%%' +
(%%+ ,
query%%, 1
)%%1 2
;%%2 3
return&& 
Ok&& 
(&& 
response&& 
)&& 
;&& 
}'' 
[)) 
HttpPost)) 
()) 
$str))  
)))  !
]))! "
public** 

async** 
Task** 
<** 
IActionResult** #
>**# $
ActiveRestaurant**% 5
(**5 6
Guid**6 :
id**; =
)**= >
{++ 
try,, 
{-- 	
var.. 
response.. 
=.. 
await..  
	_mediator..! *
...* +
Send..+ /
(../ 0
new..0 3#
ActiveRestaurantCommand..4 K
(..K L
id..L N
)..N O
)..O P
;..P Q
return// 
Ok// 
(// 
new// 
	OK_Result// #
<//# $
Guid//$ (
>//( )
(//) *
$str//* c
,//c d
response//e m
)//m n
)//n o
;//o p
}00 	
catch11 
(11 
	Exception11 
ex11 
)11 
{22 	
return33 

BadRequest33 
(33 
new33 !
Error33" '
<33' (
string33( .
>33. /
(33/ 0
$str330 D
,33D E!
ErrorStatusCodeConfig33F [
.33[ \
BAD_REQUEST33\ g
,33g h
new33i l
List33m q
<33q r
string33r x
>33x y
{33z {
ex33| ~
.33~ 
Message	33 Ü
}
33á à
)
33à â
)
33â ä
;
33ä ã
}44 	
}55 
[77 
HttpPost77 
(77 
$str77 "
)77" #
]77# $
public88 

async88 
Task88 
<88 
IActionResult88 #
>88# $
InactiveRestaurant88% 7
(887 8
Guid888 <
id88= ?
)88? @
{99 
try:: 
{;; 	
var<< 
response<< 
=<< 
await<<  
	_mediator<<! *
.<<* +
Send<<+ /
(<</ 0
new<<0 3%
InactiveRestaurantCommand<<4 M
(<<M N
id<<N P
)<<P Q
)<<Q R
;<<R S
return== 
Ok== 
(== 
new== 
	OK_Result== #
<==# $
Guid==$ (
>==( )
(==) *
$str==* i
,==i j
response==k s
)==s t
)==t u
;==u v
}>> 	
catch?? 
(?? 
	Exception?? 
ex?? 
)?? 
{@@ 	
returnAA 

BadRequestAA 
(AA 
newAA !
ErrorAA" '
<AA' (
stringAA( .
>AA. /
(AA/ 0
$strAA0 J
,AAJ K!
ErrorStatusCodeConfigAAL a
.AAa b
BAD_REQUESTAAb m
,AAm n
newAAo r
ListAAs w
<AAw x
stringAAx ~
>AA~ 
{
AAÄ Å
ex
AAÇ Ñ
.
AAÑ Ö
Message
AAÖ å
}
AAç é
)
AAé è
)
AAè ê
;
AAê ë
}BB 	
}CC 
[DD 
	HttpPatchDD 
(DD 
$strDD !
)DD! "
]DD" #
publicEE 

asyncEE 
TaskEE 
<EE 
IActionResultEE #
>EE# $
UpdateRestaurantEE% 5
(EE5 6
GuidEE6 :
idEE; =
,EE= >#
UpdateRestaurantCommandEE? V
commandEEW ^
)EE^ _
{FF 
tryGG 
{HH 	
commandII 
.II 
IdII 
=II 
idII 
;II 
varJJ 
responseJJ 
=JJ 
awaitJJ  
	_mediatorJJ! *
.JJ* +
SendJJ+ /
(JJ/ 0
commandJJ0 7
)JJ7 8
;JJ8 9
returnKK 
OkKK 
(KK 
newKK 
	OK_ResultKK #
<KK# $
GuidKK$ (
>KK( )
(KK) *
$strKK* H
,KKH I
responseKKJ R
)KKR S
)KKS T
;KKT U
}LL 	
catchMM 
(MM 
AppExceptionMM 
exMM 
)MM 
{NN 	
returnOO 

BadRequestOO 
(OO 
newOO !
ErrorOO" '
<OO' (

FieldErrorOO( 2
>OO2 3
(OO3 4
$strOO4 P
,OOP Q!
ErrorStatusCodeConfigOOR g
.OOg h
BAD_REQUESTOOh s
,OOs t
exOOu w
.OOw x
FieldErrors	OOx É
)
OOÉ Ñ
)
OOÑ Ö
;
OOÖ Ü
}PP 	
}QQ 
[RR 
HttpGetRR 
(RR 
$strRR 
)RR 
]RR 
publicSS 

asyncSS 
TaskSS 
<SS 
IActionResultSS #
>SS# $
GetRestaurantSS% 2
(SS2 3
GuidSS3 7
idSS8 :
)SS: ;
{TT 
tryUU 
{VV 	
varWW 
responseWW 
=WW 
awaitWW  
	_mediatorWW! *
.WW* +
SendWW+ /
(WW/ 0
newWW0 3&
GetRestaurantDetailCommandWW4 N
(WWN O
idWWO Q
)WWQ R
)WWR S
;WWS T
returnXX 
OkXX 
(XX 
responseXX 
)XX 
;XX  
}YY 	
catchZZ 
(ZZ 
AppExceptionZZ 
exZZ 
)ZZ 
{[[ 	
return\\ 

BadRequest\\ 
(\\ 
new\\ !
Error\\" '
<\\' (
string\\( .
>\\. /
(\\/ 0
$str\\0 Q
,\\Q R!
ErrorStatusCodeConfig\\S h
.\\h i
BAD_REQUEST\\i t
,\\t u
new\\v y
List\\z ~
<\\~ 
string	\\ Ö
>
\\Ö Ü
{
\\á à
ex
\\â ã
.
\\ã å
Message
\\å ì
}
\\î ï
)
\\ï ñ
)
\\ñ ó
;
\\ó ò
}]] 	
}^^ 
}ll Ù]
vC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\ProductGeneralController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public 
class $
ProductGeneralController %
:& '
DefaultController( 9
{ 
private 
readonly 
ISender 
_sender $
;$ %
public 
$
ProductGeneralController #
(# $
ISender$ +
sender, 2
)2 3
{ 
_sender 
= 
sender 
; 
} 
[   
HttpPost   
]   
[!! 
SwaggerOperation!! 
(!! 
Summary!! 
=!! 
$str!!  @
)!!@ A
]!!A B
[""  
ProducesResponseType"" 
("" 
StatusCodes"" %
.""% &
Status201Created""& 6
)""6 7
]""7 8
[##  
ProducesResponseType## 
(## 
StatusCodes## %
.##% &
Status400BadRequest##& 9
)##9 :
]##: ;
public$$ 

async$$ 
Task$$ 
<$$ 
IActionResult$$ #
>$$# $
Add$$% (
($$( )'
CreateProductGeneralCommand$$) D
command$$E L
)$$L M
{%% 
var&& 
response&& 
=&& 
await&& 
_sender&& $
.&&$ %
Send&&% )
(&&) *
command&&* 1
)&&1 2
;&&2 3
return'' 
CreatedAtAction'' 
('' 
nameof'' %
(''% &
Add''& )
)'') *
,''* +
new'', /
{''0 1
id''2 4
=''5 6
response''7 ?
}''@ A
,''A B
new''C F
CREATED_Result''G U
(''U V
$str''V v
)''v w
)''w x
;''x y
}(( 
[// 
HttpPost// 
(// 
$str// 
)// 
]// 
[00 
SwaggerOperation00 
(00 
Summary00 
=00 
$str00  3
)003 4
]004 5
[11  
ProducesResponseType11 
(11 
StatusCodes11 %
.11% &
Status201Created11& 6
)116 7
]117 8
[22  
ProducesResponseType22 
(22 
StatusCodes22 %
.22% &
Status400BadRequest22& 9
)229 :
]22: ;
public33 

async33 
Task33 
<33 
IActionResult33 #
>33# $
UploadImage33% 0
(330 1
[331 2
FromForm332 :
]33: ;+
UpdateIngredientQuantityCommand33< [
	imageFile33\ e
)33e f
{44 
return66 
CreatedAtAction66 
(66 
nameof66 %
(66% &
UploadImage66& 1
)661 2
,662 3
await664 9
_sender66: A
.66A B
Send66B F
(66F G
	imageFile66G P
)66P Q
)66Q R
;66R S
}77 
[@@ 
	HttpPatch@@ 
(@@ 
$str@@ 6
)@@6 7
]@@7 8
[AA 
SwaggerOperationAA 
(AA 
SummaryAA 
=AA 
$strAA  Y
)AAY Z
]AAZ [
[BB  
ProducesResponseTypeBB 
(BB 
StatusCodesBB %
.BB% &
Status200OKBB& 1
)BB1 2
]BB2 3
[CC  
ProducesResponseTypeCC 
(CC 
StatusCodesCC %
.CC% &
Status400BadRequestCC& 9
)CC9 :
]CC: ;
publicDD 

asyncDD 
TaskDD 
<DD 
IActionResultDD #
>DD# $
UpdateQuantityDD% 3
(DD3 4
GuidDD4 8
	productIdDD9 B
,DDB C
GuidDDD H
ingredientIdDDI U
,DDU V
[DDW X
FromBodyDDX `
]DD` a,
UpdateIngredientQuantityCommand	DDb Å
command
DDÇ â
)
DDâ ä
{EE 
commandFF 
.FF 
	ProductIdFF 
=FF 
	productIdFF %
;FF% &
commandGG 
.GG 
IngredientIdGG 
=GG 
ingredientIdGG +
;GG+ ,
varHH 
responseHH 
=HH 
awaitHH 
_senderHH $
.HH$ %
SendHH% )
(HH) *
commandHH* 1
)HH1 2
;HH2 3
returnII 
OkII 
(II 
newII 
UPDATED_ResultII $
(II$ %
$strII% O
)IIO P
)IIP Q
;IIQ R
}JJ 
[RR 
HttpPutRR 
(RR 
$strRR 
)RR 
]RR 
[SS 
SwaggerOperationSS 
(SS 
SummarySS 
=SS 
$strSS  F
)SSF G
]SSG H
[TT  
ProducesResponseTypeTT 
(TT 
StatusCodesTT %
.TT% &
Status200OKTT& 1
)TT1 2
]TT2 3
[UU  
ProducesResponseTypeUU 
(UU 
StatusCodesUU %
.UU% &
Status400BadRequestUU& 9
)UU9 :
]UU: ;
publicVV 

asyncVV 
TaskVV 
<VV 
IActionResultVV #
>VV# $
UpdateVV% +
(VV+ ,
GuidVV, 0
	productIdVV1 :
,VV: ;
[VV< =
FromBodyVV= E
]VVE F'
UpdateProductGeneralCommandVVG b
commandVVc j
)VVj k
{WW 
commandXX 
.XX 
IdXX 
=XX 
	productIdXX 
;XX 
varYY 
responseYY 
=YY 
awaitYY 
_senderYY $
.YY$ %
SendYY% )
(YY) *
commandYY* 1
)YY1 2
;YY2 3
returnZZ 
OkZZ 
(ZZ 
newZZ 
UPDATED_ResultZZ $
(ZZ$ %
$strZZ% J
,ZZJ K
responseZZL T
)ZZT U
)ZZU V
;ZZV W
}[[ 
[bb 
HttpPostbb 
(bb 
$strbb  
)bb  !
]bb! "
[cc 
SwaggerOperationcc 
(cc 
Summarycc 
=cc 
$strcc  >
)cc> ?
]cc? @
[dd  
ProducesResponseTypedd 
(dd 
StatusCodesdd %
.dd% &
Status200OKdd& 1
)dd1 2
]dd2 3
[ee  
ProducesResponseTypeee 
(ee 
StatusCodesee %
.ee% &
Status400BadRequestee& 9
)ee9 :
]ee: ;
publicff 

asyncff 
Taskff 
<ff 
IActionResultff #
>ff# $
Activeff% +
(ff+ ,
Guidff, 0
idff1 3
)ff3 4
{gg 
varhh 
responsehh 
=hh 
awaithh 
_senderhh $
.hh$ %
Sendhh% )
(hh) *
newhh* -'
ActiveProductGeneralCommandhh. I
(hhI J
idhhJ L
)hhL M
)hhM N
;hhN O
returnii 
Okii 
(ii 
newii 
UPDATED_Resultii $
(ii$ %
$strii% K
)iiK L
)iiL M
;iiM N
}jj 
[qq 
HttpPostqq 
(qq 
$strqq "
)qq" #
]qq# $
[rr 
SwaggerOperationrr 
(rr 
Summaryrr 
=rr 
$strrr  @
)rr@ A
]rrA B
[ss  
ProducesResponseTypess 
(ss 
StatusCodesss %
.ss% &
Status200OKss& 1
)ss1 2
]ss2 3
[tt  
ProducesResponseTypett 
(tt 
StatusCodestt %
.tt% &
Status400BadRequesttt& 9
)tt9 :
]tt: ;
publicuu 

asyncuu 
Taskuu 
<uu 
IActionResultuu #
>uu# $
Inactiveuu% -
(uu- .
Guiduu. 2
iduu3 5
)uu5 6
{vv 
varww 
responseww 
=ww 
awaitww 
_senderww $
.ww$ %
Sendww% )
(ww) *
newww* -)
InactiveProductGeneralCommandww. K
(wwK L
idwwL N
)wwN O
)wwO P
;wwP Q
returnxx 
Okxx 
(xx 
newxx 
DELETED_Resultxx $
(xx$ %
$strxx% M
)xxM N
)xxN O
;xxO P
}yy 
[
ÄÄ 
HttpGet
ÄÄ 
]
ÄÄ 
[
ÅÅ 
SwaggerOperation
ÅÅ 
(
ÅÅ 
Summary
ÅÅ 
=
ÅÅ 
$str
ÅÅ  A
)
ÅÅA B
]
ÅÅB C
[
ÇÇ "
ProducesResponseType
ÇÇ 
(
ÇÇ 
StatusCodes
ÇÇ %
.
ÇÇ% &
Status200OK
ÇÇ& 1
)
ÇÇ1 2
]
ÇÇ2 3
[
ÉÉ "
ProducesResponseType
ÉÉ 
(
ÉÉ 
StatusCodes
ÉÉ %
.
ÉÉ% &!
Status400BadRequest
ÉÉ& 9
)
ÉÉ9 :
]
ÉÉ: ;
public
ÑÑ 

async
ÑÑ 
Task
ÑÑ 
<
ÑÑ 
IActionResult
ÑÑ #
>
ÑÑ# $
Get
ÑÑ% (
(
ÑÑ( )
[
ÑÑ) *
	FromQuery
ÑÑ* 3
]
ÑÑ3 4&
GetProductGeneralCommand
ÑÑ5 M
command
ÑÑN U
)
ÑÑU V
{
ÖÖ 
var
ÜÜ 
response
ÜÜ 
=
ÜÜ 
await
ÜÜ 
_sender
ÜÜ $
.
ÜÜ$ %
Send
ÜÜ% )
(
ÜÜ) *
command
ÜÜ* 1
)
ÜÜ1 2
;
ÜÜ2 3
return
áá 
Ok
áá 
(
áá 
new
áá 
	OK_Result
áá 
<
áá  
PagedResult
áá  +
<
áá+ ,'
GetProductGeneralResponse
áá, E
>
ááE F
>
ááF G
(
ááG H
$str
ááH i
,
áái j
response
áák s
)
áás t
)
áát u
;
ááu v
}
àà 
[
èè 
HttpGet
èè 
(
èè 
$str
èè 
)
èè 
]
èè 
[
êê 
SwaggerOperation
êê 
(
êê 
Summary
êê 
=
êê 
$str
êê  b
)
êêb c
]
êêc d
[
ëë "
ProducesResponseType
ëë 
(
ëë 
StatusCodes
ëë %
.
ëë% &
Status200OK
ëë& 1
)
ëë1 2
]
ëë2 3
[
íí "
ProducesResponseType
íí 
(
íí 
StatusCodes
íí %
.
íí% &
Status404NotFound
íí& 7
)
íí7 8
]
íí8 9
public
ìì 

async
ìì 
Task
ìì 
<
ìì 
IActionResult
ìì #
>
ìì# $
	GetDetail
ìì% .
(
ìì. /
Guid
ìì/ 3
id
ìì4 6
)
ìì6 7
{
îî 
var
ïï 
response
ïï 
=
ïï 
await
ïï 
_sender
ïï $
.
ïï$ %
Send
ïï% )
(
ïï) *
new
ïï* -,
GetProductGeneralDetailCommand
ïï. L
(
ïïL M
id
ïïM O
)
ïïO P
)
ïïP Q
;
ïïQ R
return
ññ 
Ok
ññ 
(
ññ 
new
ññ 
	OK_Result
ññ 
<
ññ  -
GetProductGeneralDetailResponse
ññ  ?
>
ññ? @
(
ññ@ A
$str
ññA j
,
ññj k
response
ññl t
)
ññt u
)
ññu v
;
ññv w
}
óó 
}òò ÄD
oC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\ProductController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public 
class 
ProductController 
:  
DefaultController! 2
{ 
private 
readonly 
	IMediator 
	_mediator (
;( )
public 

ProductController 
( 
	IMediator &
mediator' /
)/ 0
{ 
	_mediator 
= 
mediator 
; 
} 
[ 
HttpPost 
( 
$str 
) 
] 
[ 
SwaggerOperation 
( 
Summary 
= 
$str  5
)5 6
]6 7
[    
ProducesResponseType   
(   
StatusCodes   %
.  % &
Status200OK  & 1
)  1 2
]  2 3
[!!  
ProducesResponseType!! 
(!! 
StatusCodes!! %
.!!% &
Status400BadRequest!!& 9
)!!9 :
]!!: ;
public"" 

async"" 
Task"" 
<"" 
IActionResult"" #
>""# $
AddNewProduct""% 2
(""2 3
AddProductCommand""3 D
command""E L
)""L M
{## 
var$$ 
response$$ 
=$$ 
await$$ 
	_mediator$$ &
.$$& '
Send$$' +
($$+ ,
command$$, 3
)$$3 4
;$$4 5
return%% 
Created%% 
(%% 
$str%% 
,%% 
new%% 
CREATED_Result%% -
(%%- .
$str%%. E
,%%E F
response%%G O
)%%O P
)%%P Q
;%%Q R
}&& 
[-- 
HttpPost-- 
(-- 
$str-- 
)-- 
]-- 
[.. 
SwaggerOperation.. 
(.. 
Summary.. 
=.. 
$str..  6
)..6 7
]..7 8
[//  
ProducesResponseType// 
(// 
StatusCodes// %
.//% &
Status200OK//& 1
)//1 2
]//2 3
[00  
ProducesResponseType00 
(00 
StatusCodes00 %
.00% &
Status400BadRequest00& 9
)009 :
]00: ;
public11 

async11 
Task11 
<11 
IActionResult11 #
>11# $
Active11% +
(11+ , 
ActiveProductCommand11, @
command11A H
)11H I
{22 
var33 
response33 
=33 
await33 
	_mediator33 &
.33& '
Send33' +
(33+ ,
command33, 3
)333 4
;334 5
return44 
Ok44 
(44 
new44 
UPDATED_Result44 $
(44$ %
$str44% E
,44E F
response44G O
)44O P
)44P Q
;44Q R
}55 
[<< 
HttpPost<< 
(<< 
$str<< 
)<< 
]<< 
[== 
SwaggerOperation== 
(== 
Summary== 
=== 
$str==  8
)==8 9
]==9 :
[>>  
ProducesResponseType>> 
(>> 
StatusCodes>> %
.>>% &
Status200OK>>& 1
)>>1 2
]>>2 3
[??  
ProducesResponseType?? 
(?? 
StatusCodes?? %
.??% &
Status400BadRequest??& 9
)??9 :
]??: ;
public@@ 

async@@ 
Task@@ 
<@@ 
IActionResult@@ #
>@@# $
Inactive@@% -
(@@- ."
InactiveProductCommand@@. D
command@@E L
)@@L M
{AA 
varBB 
responseBB 
=BB 
awaitBB 
	_mediatorBB &
.BB& '
SendBB' +
(BB+ ,
commandBB, 3
)BB3 4
;BB4 5
returnCC 
OkCC 
(CC 
newCC 
UPDATED_ResultCC $
(CC$ %
$strCC% G
,CCG H
responseCCI Q
)CCQ R
)CCR S
;CCS T
}DD 
[KK 
HttpGetKK 
(KK 
$strKK 
)KK 
]KK 
[LL 
SwaggerOperationLL 
(LL 
SummaryLL 
=LL 
$strLL  A
)LLA B
]LLB C
[MM  
ProducesResponseTypeMM 
(MM 
StatusCodesMM %
.MM% &
Status200OKMM& 1
)MM1 2
]MM2 3
[NN  
ProducesResponseTypeNN 
(NN 
StatusCodesNN %
.NN% &
Status400BadRequestNN& 9
)NN9 :
]NN: ;
publicOO 

asyncOO 
TaskOO 
<OO 
IActionResultOO #
>OO# $
GetMenuOO% ,
(OO, -
[OO- .
	FromQueryOO. 7
]OO7 8
GetMenuCommandOO9 G
commandOOH O
)OOO P
{PP 
varQQ 
responseQQ 
=QQ 
awaitQQ 
	_mediatorQQ &
.QQ& '
SendQQ' +
(QQ+ ,
commandQQ, 3
)QQ3 4
;QQ4 5
returnRR 
OkRR 
(RR 
newRR 
	OK_ResultRR 
<RR  
ListRR  $
<RR$ %
GetMenuResponseRR% 4
>RR4 5
>RR5 6
(RR6 7
$strRR7 L
,RRL M
responseRRN V
)RRV W
)RRW X
;RRX Y
}SS 
[ZZ 
HttpGetZZ 
]ZZ 
[[[ 
SwaggerOperation[[ 
([[ 
Summary[[ 
=[[ 
$str[[  ?
)[[? @
][[@ A
[\\  
ProducesResponseType\\ 
(\\ 
StatusCodes\\ %
.\\% &
Status200OK\\& 1
)\\1 2
]\\2 3
[]]  
ProducesResponseType]] 
(]] 
StatusCodes]] %
.]]% &
Status400BadRequest]]& 9
)]]9 :
]]]: ;
public^^ 

async^^ 
Task^^ 
<^^ 
IActionResult^^ #
>^^# $
Get^^% (
(^^( )
[^^) *
	FromQuery^^* 3
]^^3 4
GetProductCommand^^5 F
command^^G N
)^^N O
{__ 
var`` 
response`` 
=`` 
await`` 
	_mediator`` &
.``& '
Send``' +
(``+ ,
command``, 3
)``3 4
;``4 5
returnaa 
Okaa 
(aa 
newaa 
	OK_Resultaa 
<aa  
Listaa  $
<aa$ %
GetProductResponseaa% 7
>aa7 8
>aa8 9
(aa9 :
$straa: Q
,aaQ R
responseaaS [
)aa[ \
)aa\ ]
;aa] ^
}bb 
[jj 
HttpPutjj 
(jj 
$strjj 
)jj 
]jj 
[kk 
SwaggerOperationkk 
(kk 
Summarykk 
=kk 
$strkk  >
)kk> ?
]kk? @
[ll  
ProducesResponseTypell 
(ll 
StatusCodesll %
.ll% &
Status200OKll& 1
)ll1 2
]ll2 3
[mm  
ProducesResponseTypemm 
(mm 
StatusCodesmm %
.mm% &
Status400BadRequestmm& 9
)mm9 :
]mm: ;
publicnn 

asyncnn 
Tasknn 
<nn 
IActionResultnn #
>nn# $
Updatenn% +
(nn+ ,
Guidnn, 0
idnn1 3
,nn3 4 
UpdateProductCommandnn5 I
commandnnJ Q
)nnQ R
{oo 
commandpp 
.pp 
	ProductIdpp 
=pp 
idpp 
;pp 
varqq 
responseqq 
=qq 
awaitqq 
	_mediatorqq &
.qq& '
Sendqq' +
(qq+ ,
commandqq, 3
)qq3 4
;qq4 5
returnrr 
Okrr 
(rr 
newrr 
UPDATED_Resultrr $
(rr$ %
$strrr% A
,rrA B
responserrC K
)rrK L
)rrL M
;rrM N
}ss 
}tt ´:
oC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\PaymentController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
public 
class 
PaymentController 
( 
ISender &
sender' -
)- .
:/ 0
DefaultController1 B
{ 
private 
readonly 
ISender 
_sender $
=% &
sender' -
;- .
[ 
HttpPost 
( 
$str #
)# $
]$ %
public 

async 
Task 
< 
IActionResult #
># $
CreatePayment% 2
(2 3
Guid3 7
orderId8 ?
,? @!
CreatePaymentCommandsA V
commandW ^
)^ _
{ 
command 
= 
command 
with 
{  
OrderId! (
=) *
orderId+ 2
}3 4
;4 5
var 
response 
= 
await 
_sender $
.$ %
Send% )
() *
command* 1
)1 2
;2 3
return 
Ok 
( 
response 
) 
; 
} 
[ 
HttpPost 
( 
$str %
)% &
]& '
public 

async 
Task 
< 
IActionResult #
># $
CreateVNPayPayment% 7
(7 8
Guid8 <
orderId= D
)D E
{ 
var 
command 
= 
new 
VNPayPaymentCommand -
{ 	
OrderId 
= 
orderId 
} 	
;	 

var 
response 
= 
await 
_sender $
.$ %
Send% )
() *
command* 1
)1 2
;2 3
return   
Ok   
(   
response   
)   
;   
}!! 
["" 
	HttpPatch"" 
("" 
$str"" '
)""' (
]""( )
public## 

async## 
Task## 
<## 
IActionResult## #
>### $
ConfirmPayment##% 3
(##3 4
Guid##4 8
orderId##9 @
)##@ A
{$$ 
var%% 
command%% 
=%% 
new%%  
FinishPaymentCommand%% .
(%%. /
orderId%%/ 6
)%%6 7
;%%7 8
var&& 
response&& 
=&& 
await&& 
_sender&& $
.&&$ %
Send&&% )
(&&) *
command&&* 1
)&&1 2
;&&2 3
return'' 
Ok'' 
('' 
response'' 
)'' 
;'' 
}(( 
[)) 
HttpGet)) 
])) 
public** 

async** 
Task** 
<** 
IActionResult** #
>**# $
Get**% (
(**( )
[**) *
	FromQuery*** 3
]**3 4
GetPaymentsRequest**5 G
command**H O
)**O P
{++ 
var,, 
response,, 
=,, 
await,, 
_sender,, $
.,,$ %
Send,,% )
(,,) *
command,,* 1
),,1 2
;,,2 3
return-- 
Ok-- 
(-- 
response-- 
)-- 
;-- 
}.. 
[// 
HttpGet// 
(// 
$str// 
)// 
]//  
public00 

async00 
Task00 
<00 
IActionResult00 #
>00# $
PaymentConfirm00% 3
(003 4
)004 5
{11 
if22 

(22 
Request22 
.22 
QueryString22 
.22  
HasValue22  (
)22( )
{33 	
var44 
queryString44 
=44 
HttpUtility44 )
.44) *
ParseQueryString44* :
(44: ;
Request44; B
.44B C
QueryString44C N
.44N O
Value44O T
)44T U
;44U V
var66 
command66 
=66 
new66  
VNPayCallbackCommand66 2
(662 3

vnp_Amount77 
:77 
queryString77 '
[77' (
$str77( 4
]774 5
,775 6
vnp_BankCode88 
:88 
queryString88 )
[88) *
$str88* 8
]888 9
,889 :
vnp_BankTranNo99 
:99 
queryString99  +
[99+ ,
$str99, <
]99< =
,99= >
vnp_CardType:: 
::: 
queryString:: )
[::) *
$str::* 8
]::8 9
,::9 :
	orderInfo;; 
:;; 
queryString;; &
[;;& '
$str;;' 6
];;6 7
,;;7 8
vnp_PayDate<< 
:<< 
queryString<< (
[<<( )
$str<<) 6
]<<6 7
,<<7 8
vnp_ResponseCode==  
:==  !
queryString==" -
[==- .
$str==. @
]==@ A
,==A B
vnp_TmnCode>> 
:>> 
queryString>> (
[>>( )
$str>>) 6
]>>6 7
,>>7 8
vnpayTranId?? 
:?? 
Convert?? $
.??$ %
ToInt64??% ,
(??, -
queryString??- 8
[??8 9
$str??9 L
]??L M
)??M N
,??N O!
vnp_TransactionStatus@@ %
:@@% &
queryString@@' 2
[@@2 3
$str@@3 J
]@@J K
,@@K L

vnp_TxnRefAA 
:AA 
queryStringAA '
[AA' (
$strAA( 4
]AA4 5
,AA5 6
vnp_SecureHashBB 
:BB 
queryStringBB  +
[BB+ ,
$strBB, <
]BB< =
,BB= >
responseQueryCC 
:CC 
RequestCC &
.CC& '
QueryStringCC' 2
.CC2 3
ValueCC3 8
.CC8 9
	SubstringCC9 B
(CCB C
$numCCC D
,CCD E
RequestCCF M
.CCM N
QueryStringCCN Y
.CCY Z
ValueCCZ _
.CC_ `
IndexOfCC` g
(CCg h
$strCCh y
)CCy z
-CC{ |
$numCC} ~
)CC~ 
)DD 
;DD 
varFF 
responseFF 
=FF 
awaitFF  
_senderFF! (
.FF( )
SendFF) -
(FF- .
commandFF. 5
)FF5 6
;FF6 7
ifGG 
(GG 
responseGG 
.GG 
SuccessGG  
)GG  !
{HH 
returnII 
OkII 
(II 
responseII "
)II" #
;II# $
}JJ 
elseKK 
{LL 
returnMM 

BadRequestMM !
(MM! "
responseMM" *
)MM* +
;MM+ ,
}NN 
}OO 	
returnPP 

BadRequestPP 
(PP 
)PP 
;PP 
}QQ 
}RR Ì1
mC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\OrderController.cs
	namespace

 	
FOV


 
.

 
Presentation

 
.

 
Controllers

 &
.

& '
V1

' )
;

) *
public 
class 
OrderController 
( 
ISender $
sender% +
)+ ,
:- .
DefaultController/ @
{ 
private 
readonly 
ISender 
_sender $
=% &
sender' -
;- .
[ 
HttpPost 
( 
$str $
)$ %
]% &
public 

async 
Task 
< 
IActionResult #
># $
Add% (
(( )
Guid) -
tableId. 5
,5 6
[7 8
FromBody8 @
]@ A)
CreateOrderWithTableIdCommandB _
command` g
)g h
{ 
command 
. 
TableId 
= 
tableId !
;! "
var 
response 
= 
await 
_sender $
.$ %
Send% )
() *
command* 1
)1 2
;2 3
return 
Ok 
( 
response 
) 
; 
} 
[ 
HttpGet 
] 
public 

async 
Task 
< 
IActionResult #
># $
Get% (
(( )
[) *
	FromQuery* 3
]3 4
GetOrdersRequest5 E
commandF M
)M N
{ 
var 
response 
= 
await 
_sender $
.$ %
Send% )
() *
command* 1
)1 2
;2 3
return 
Ok 
( 
response 
) 
; 
} 
[ 
	HttpPatch 
( 
$str $
)$ %
]% &
public   

async   
Task   
<   
IActionResult   #
>  # $
ConfirmOrderToCook  % 7
(  7 8
Guid  8 <
orderId  = D
)  D E
{!! 
var"" 
command"" 
="" 
new"" %
ConfirmOrderToCookCommand"" 3
(""3 4
orderId""4 ;
)""; <
;""< =
var## 
response## 
=## 
await## 
_sender## $
.##$ %
Send##% )
(##) *
command##* 1
)##1 2
;##2 3
return$$ 
Ok$$ 
($$ 
response$$ 
)$$ 
;$$ 
}%% 
['' 
	HttpPatch'' 
('' 
$str'' %
)''% &
]''& '
public(( 

async(( 
Task(( 
<(( 
IActionResult(( #
>((# $
ConfirmOrderToServe((% 8
(((8 9
Guid((9 =
orderId((> E
)((E F
{)) 
var** 
command** 
=** 
new** &
ConfirmOrderToServeCommand** 4
(**4 5
orderId**5 <
)**< =
;**= >
var++ 
response++ 
=++ 
await++ 
_sender++ $
.++$ %
Send++% )
(++) *
command++* 1
)++1 2
;++2 3
return,, 
Ok,, 
(,, 
response,, 
),, 
;,, 
}-- 
[// 
HttpGet// 
(// 
$str// %
)//% &
]//& '
public00 

async00 
Task00 
<00 
IActionResult00 #
>00# $
GetOrderDetails00% 4
(004 5
Guid005 9
orderId00: A
)00A B
{11 
var22 
command22 
=22 
new22 "
GetOrderDetailsCommand22 0
(220 1
orderId221 8
)228 9
;229 :
var33 
response33 
=33 
await33 
_sender33 $
.33$ %
Send33% )
(33) *
command33* 1
)331 2
;332 3
return44 
Ok44 
(44 
response44 
)44 
;44 
}55 
[77 
HttpPost77 
(77 
$str77 +
)77+ ,
]77, -
public88 

async88 
Task88 
<88 
IActionResult88 #
>88# $
AddProductsToOrder88% 7
(887 8
Guid888 <
orderId88= D
,88D E
[88F G
FromBody88G O
]88O P&
AddProductsToOrdersCommand88Q k
command88l s
)88s t
{99 
command:: 
.:: 
OrderId:: 
=:: 
orderId:: !
;::! "
var;; 
response;; 
=;; 
await;; 
_sender;; $
.;;$ %
Send;;% )
(;;) *
command;;* 1
);;1 2
;;;2 3
return<< 
Ok<< 
(<< 
response<< 
)<< 
;<< 
}== 
[>> 
	HttpPatch>> 
(>> 
$str>> &
)>>& '
]>>' (
public?? 

async?? 
Task?? 
<?? 
IActionResult?? #
>??# $
RefundOrder??% 0
(??0 1
Guid??1 5
orderId??6 =
,??= >
[??? @
FromBody??@ H
]??H I
RefundOrderCommand??J \
command??] d
)??d e
{@@ 
commandAA 
=AA 
commandAA 
withAA 
{AA  
OrderIdAA! (
=AA) *
orderIdAA+ 2
}AA3 4
;AA4 5
varBB 
responseBB 
=BB 
awaitBB 
_senderBB $
.BB$ %
SendBB% )
(BB) *
commandBB* 1
)BB1 2
;BB2 3
returnCC 
OkCC 
(CC 
responseCC 
)CC 
;CC 
}DD 
}EE í
~C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\NewProductRecommendLogController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
public 
class ,
 NewProductRecommendLogController -
{ 
} ˆ7
{C:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\NewProductRecommendController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
public 
class )
NewProductRecommendController *
:+ ,
DefaultController- >
{ 
private 
readonly 
ISender 
_sender $
;$ %
public 
)
NewProductRecommendController (
(( )
ISender) 0
sender1 7
)7 8
{ 
_sender 
= 
sender 
; 
} 
[ 
HttpPost 
( 
$str 
) 
] 
public 

async 
Task 
< 
IActionResult #
># $
SendRequest% 0
(0 1
NewRequestCommand1 B
commandC J
)J K
{ 
var 
response 
= 
await 
_sender $
.$ %
Send% )
() *
command* 1
)1 2
;2 3
return 
Ok 
( 
response 
) 
; 
} 
[   
HttpPut   
(   
$str   
)   
]   
public!! 

async!! 
Task!! 
<!! 
IActionResult!! #
>!!# $
AdjustRequest!!% 2
(!!2 3 
AdjustRequestCommand!!3 G
command!!H O
,!!O P
Guid!!Q U
id!!V X
)!!X Y
{"" 
command## 
.## 
RecommendProductId## "
=### $
id##% '
;##' (
var$$ 
response$$ 
=$$ 
await$$ 
_sender$$ $
.$$$ %
Send$$% )
($$) *
command$$* 1
)$$1 2
;$$2 3
return%% 
Ok%% 
(%% 
response%% 
)%% 
;%% 
}&& 
[(( 
HttpPost(( 
((( 
$str(( 
)(( 
](( 
public)) 

async)) 
Task)) 
<)) 
IActionResult)) #
>))# $
UpdateRequest))% 2
())2 3 
UpdateRequestCommand))3 G
command))H O
,))O P
Guid))Q U
id))V X
)))X Y
{** 
command++ 
.++ !
NewRecommendProductId++ %
=++& '
id++( *
;++* +
var,, 
response,, 
=,, 
await,, 
_sender,, $
.,,$ %
Send,,% )
(,,) *
command,,* 1
),,1 2
;,,2 3
return-- 
Ok-- 
(-- 
response-- 
)-- 
;-- 
}.. 
[11 
HttpPost11 
(11 
$str11 "
)11" #
]11# $
public22 

async22 
Task22 
<22 
IActionResult22 #
>22# $
ApproveRequest22% 3
(223 4"
ApproveResponseCommand224 J
command22K R
,22R S
Guid22T X
id22Y [
)22[ \
{33 
command44 
.44 !
NewProductRecommendId44 %
=44& '
id44( *
;44* +
var55 
response55 
=55 
await55 
_sender55 $
.55$ %
Send55% )
(55) *
command55* 1
)551 2
;552 3
return66 
Ok66 
(66 
response66 
)66 
;66 
}77 
[99 
HttpPost99 
(99 
$str99  
)99  !
]99! "
public:: 

async:: 
Task:: 
<:: 
IActionResult:: #
>::# $
DenyRequest::% 0
(::0 1
DenyResponseCommand::1 D
command::E L
,::L M
Guid::N R
id::S U
)::U V
{;; 
command<< 
.<< !
NewProductRecommendId<< %
=<<& '
id<<( *
;<<* +
var== 
response== 
=== 
await== 
_sender== $
.==$ %
Send==% )
(==) *
command==* 1
)==1 2
;==2 3
return>> 
Ok>> 
(>> 
response>> 
)>> 
;>> 
}?? 
[BB 
HttpPostBB 
(BB 
$strBB %
)BB% &
]BB& '
publicCC 

asyncCC 
TaskCC 
<CC 
IActionResultCC #
>CC# $
NeedsUpdateRequestCC% 7
(CC7 8&
NeedsUpdateResponseCommandCC8 R
commandCCS Z
,CCZ [
GuidCC\ `
idCCa c
)CCc d
{DD 
commandEE 
.EE !
NewRecommendProductIdEE %
=EE& '
idEE( *
;EE* +
varFF 
responseFF 
=FF 
awaitFF 
_senderFF $
.FF$ %
SendFF% )
(FF) *
commandFF* 1
)FF1 2
;FF2 3
returnGG 
OkGG 
(GG 
responseGG 
)GG 
;GG 
}HH 
[KK 
HttpGetKK 
]KK 
publicLL 

asyncLL 
TaskLL 
<LL 
IActionResultLL #
>LL# $
GetLL% (
(LL( )
[LL) *
	FromQueryLL* 3
]LL3 4
PagingRequestLL5 B
pagingRequestLLC P
)LLP Q
{MM 
tryNN 
{OO 	
varPP 
commandPP 
=PP 
newPP )
GetNewProductRecommendCommandPP ;
(PP; <
pagingRequestPP< I
)PPI J
;PPJ K
varQQ 
responseQQ 
=QQ 
awaitQQ  
_senderQQ! (
.QQ( )
SendQQ) -
(QQ- .
commandQQ. 5
)QQ5 6
;QQ6 7
returnRR 
OkRR 
(RR 
newRR 
	OK_ResultRR #
<RR# $
PagedResultRR$ /
<RR/ 0*
GetNewProductRecommendResponseRR0 N
>RRN O
>RRO P
(RRP Q
$strRRQ z
,RRz {
response	RR| Ñ
)
RRÑ Ö
)
RRÖ Ü
;
RRÜ á
}SS 	
catchTT 
(TT 
AppExceptionTT 
exTT 
)TT 
{UU 	
returnVV 

BadRequestVV 
(VV 
newVV !
ErrorVV" '
<VV' (

FieldErrorVV( 2
>VV2 3
(VV3 4
$strVV4 [
,VV[ \!
ErrorStatusCodeConfigVV] r
.VVr s
BAD_REQUESTVVs ~
,VV~ 
ex
VVÄ Ç
.
VVÇ É
FieldErrors
VVÉ é
)
VVé è
)
VVè ê
;
VVê ë
}WW 	
}XX 
}YY ƒ&
vC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\IngredientUnitController.cs
	namespace

 	
FOV


 
.

 
Presentation

 
.

 
Controllers

 &
.

& '
V1

' )
;

) *
public 
class $
IngredientUnitController %
:& '
DefaultController( 9
{ 
private 
readonly 
ISender 
_sender $
;$ %
public 
$
IngredientUnitController #
(# $
ISender$ +
sender, 2
)2 3
{ 
_sender 
= 
sender 
; 
} 
[ 
HttpGet 
( 
$str 
) 
] 
[ 
SwaggerOperation 
( 
Summary 
= 
$str  E
)E F
]F G
[  
ProducesResponseType 
( 
StatusCodes %
.% &
Status200OK& 1
)1 2
]2 3
[  
ProducesResponseType 
( 
StatusCodes %
.% &
Status404NotFound& 7
)7 8
]8 9
public 

async 
Task 
< 
IActionResult #
># $
Get% (
(( )
Guid) -
id. 0
)0 1
{ 
var 
response 
= 
await 
_sender $
.$ %
Send% )
() *
new* -$
GetIngredientUnitCommand. F
(F G
idG I
)I J
)J K
;K L
return   
Ok   
(   
new   
	OK_Result   
<    
List    $
<  $ %%
GetIngredientUnitResponse  % >
>  > ?
>  ? @
(  @ A
$str  A c
,  c d
response  e m
)  m n
)  n o
;  o p
}!! 
[(( 
HttpPost(( 
](( 
[)) 
SwaggerOperation)) 
()) 
Summary)) 
=)) 
$str))  =
)))= >
]))> ?
[**  
ProducesResponseType** 
(** 
StatusCodes** %
.**% &
Status201Created**& 6
)**6 7
]**7 8
[++  
ProducesResponseType++ 
(++ 
StatusCodes++ %
.++% &
Status400BadRequest++& 9
)++9 :
]++: ;
public,, 

async,, 
Task,, 
<,, 
IActionResult,, #
>,,# $
Add,,% (
(,,( )*
CreateNewIngredientUnitCommand,,) G
command,,H O
),,O P
{-- 
var.. 
response.. 
=.. 
await.. 
_sender.. $
...$ %
Send..% )
(..) *
command..* 1
)..1 2
;..2 3
return// 
CreatedAtAction// 
(// 
nameof// %
(//% &
Get//& )
)//) *
,//* +
new//, /
{//0 1
id//2 4
=//5 6
response//7 ?
}//@ A
,//A B
new//C F
CREATED_Result//G U
(//U V
$str//V r
,//r s
response//t |
)//| }
)//} ~
;//~ 
}00 
[88 
HttpPut88 
(88 
$str88 
)88 
]88 
[99 
SwaggerOperation99 
(99 
Summary99 
=99 
$str99  F
)99F G
]99G H
[::  
ProducesResponseType:: 
(:: 
StatusCodes:: %
.::% &
Status204NoContent::& 8
)::8 9
]::9 :
[;;  
ProducesResponseType;; 
(;; 
StatusCodes;; %
.;;% &
Status400BadRequest;;& 9
);;9 :
];;: ;
[<<  
ProducesResponseType<< 
(<< 
StatusCodes<< %
.<<% &
Status404NotFound<<& 7
)<<7 8
]<<8 9
public== 

async== 
Task== 
<== 
IActionResult== #
>==# $
Update==% +
(==+ ,
Guid==, 0
id==1 3
,==3 4'
UpdateIngredientUnitCommand==5 P
command==Q X
)==X Y
{>> 
command?? 
.?? 
IngredientUnitId??  
=??! "
id??# %
;??% &
await@@ 
_sender@@ 
.@@ 
Send@@ 
(@@ 
command@@ "
)@@" #
;@@# $
returnAA 
	NoContentAA 
(AA 
)AA 
;AA 
}BB 
}EE „Q
vC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\IngredientTypeController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public 
class $
IngredientTypeController %
:& '
DefaultController( 9
{ 
private 
readonly 
ISender 
_sender $
;$ %
public 
$
IngredientTypeController #
(# $
ISender$ +
sender, 2
)2 3
{ 
_sender 
= 
sender 
; 
} 
[ 
HttpGet 
] 
[ 
SwaggerOperation 
( 
Summary 
= 
$str  N
)N O
]O P
[    
ProducesResponseType   
(   
StatusCodes   %
.  % &
Status200OK  & 1
)  1 2
]  2 3
[!!  
ProducesResponseType!! 
(!! 
StatusCodes!! %
.!!% &
Status400BadRequest!!& 9
)!!9 :
]!!: ;
public"" 

async"" 
Task"" 
<"" 
IActionResult"" #
>""# $
Get""% (
(""( )
)"") *
{## 
List$$ 
<$$ '
GetParentCategoriesResponse$$ (
>$$( )
response$$* 2
=$$3 4
await$$5 :
_sender$$; B
.$$B C
Send$$C G
($$G H
new$$H K&
GetParentCategoriesCommand$$L f
($$f g
)$$g h
)$$h i
;$$i j
return%% 
Ok%% 
(%% 
new%% 
	OK_Result%% 
<%%  
List%%  $
<%%$ %'
GetParentCategoriesResponse%%% @
>%%@ A
>%%A B
(%%B C
$str%%C k
,%%k l
response%%m u
)%%u v
)%%v w
;%%w x
}&& 
[-- 
HttpGet-- 
(-- 
$str-- 
)-- 
]-- 
[.. 
SwaggerOperation.. 
(.. 
Summary.. 
=.. 
$str..  ]
)..] ^
]..^ _
[//  
ProducesResponseType// 
(// 
StatusCodes// %
.//% &
Status200OK//& 1
)//1 2
]//2 3
[00  
ProducesResponseType00 
(00 
StatusCodes00 %
.00% &
Status400BadRequest00& 9
)009 :
]00: ;
public11 

async11 
Task11 
<11 
IActionResult11 #
>11# $%
GetChildrenIngredientType11% >
(11> ?
Guid11? C
parentId11D L
)11L M
{22 
List33 
<33 %
GetChildrenIngredientType33 &
>33& '
response33( 0
=331 2
await333 8
_sender339 @
.33@ A
Send33A E
(33E F
new33F I%
GetChildCategoriesCommand33J c
(33c d
parentId33d l
)33l m
)33m n
;33n o
return44 
Ok44 
(44 
new44 
	OK_Result44 
<44  
List44  $
<44$ %%
GetChildrenIngredientType44% >
>44> ?
>44? @
(44@ A
$str44A k
,44k l
response44m u
)44u v
)44v w
;44w x
}55 
[<< 
HttpPost<< 
(<< 
$str<< 
)<< 
]<< 
[== 
SwaggerOperation== 
(== 
Summary== 
=== 
$str==  G
)==G H
]==H I
[>>  
ProducesResponseType>> 
(>> 
StatusCodes>> %
.>>% &
Status200OK>>& 1
)>>1 2
]>>2 3
[??  
ProducesResponseType?? 
(?? 
StatusCodes?? %
.??% &
Status400BadRequest??& 9
)??9 :
]??: ;
public@@ 

async@@ 
Task@@ 
<@@ 
IActionResult@@ #
>@@# $
Add@@% (
(@@( )'
CreateIngredientTypeCommand@@) D
request@@E L
)@@L M
{AA 
GuidBB 
responseBB 
=BB 
awaitBB 
_senderBB %
.BB% &
SendBB& *
(BB* +
requestBB+ 2
)BB2 3
;BB3 4
returnCC 
OkCC 
(CC 
newCC 
	OK_ResultCC 
<CC  
GuidCC  $
>CC$ %
(CC% &
$strCC& Q
,CCQ R
responseCCS [
)CC[ \
)CC\ ]
;CC] ^
}DD 
[KK 
HttpPostKK 
(KK 
$strKK 
)KK 
]KK 
[LL 
SwaggerOperationLL 
(LL 
SummaryLL 
=LL 
$strLL  F
)LLF G
]LLG H
[MM  
ProducesResponseTypeMM 
(MM 
StatusCodesMM %
.MM% &
Status200OKMM& 1
)MM1 2
]MM2 3
[NN  
ProducesResponseTypeNN 
(NN 
StatusCodesNN %
.NN% &
Status400BadRequestNN& 9
)NN9 :
]NN: ;
publicOO 

asyncOO 
TaskOO 
<OO 
IActionResultOO #
>OO# $
AddChildOO% -
(OO- .,
 CreateChildIngredientTypeCommandOO. N
commandOOO V
)OOV W
{PP 
GuidQQ 
responseQQ 
=QQ 
awaitQQ 
_senderQQ %
.QQ% &
SendQQ& *
(QQ* +
commandQQ+ 2
)QQ2 3
;QQ3 4
returnRR 
OkRR 
(RR 
newRR 
	OK_ResultRR 
<RR  
GuidRR  $
>RR$ %
(RR% &
$strRR& P
,RRP Q
responseRRR Z
)RRZ [
)RR[ \
;RR\ ]
}SS 
[[[ 
HttpPut[[ 
([[ 
$str[[ 
)[[ 
][[ 
[\\ 
SwaggerOperation\\ 
(\\ 
Summary\\ 
=\\ 
$str\\  F
)\\F G
]\\G H
[]]  
ProducesResponseType]] 
(]] 
StatusCodes]] %
.]]% &
Status200OK]]& 1
)]]1 2
]]]2 3
[^^  
ProducesResponseType^^ 
(^^ 
StatusCodes^^ %
.^^% &
Status400BadRequest^^& 9
)^^9 :
]^^: ;
public__ 

async__ 
Task__ 
<__ 
IActionResult__ #
>__# $
Update__% +
(__+ ,
Guid__, 0
id__1 3
,__3 4'
UpdateIngredientTypeCommand__5 P
command__Q X
)__X Y
{`` 
commandaa 
.aa 
Idaa 
=aa 
idaa 
;aa 
Guidbb 
responsebb 
=bb 
awaitbb 
_senderbb %
.bb% &
Sendbb& *
(bb* +
commandbb+ 2
)bb2 3
;bb3 4
returncc 
Okcc 
(cc 
newcc 
	OK_Resultcc 
<cc  
Guidcc  $
>cc$ %
(cc% &
$strcc& J
,ccJ K
responseccL T
)ccT U
)ccU V
;ccV W
}dd 
[kk 
HttpPostkk 
(kk 
$strkk  
)kk  !
]kk! "
[ll 
SwaggerOperationll 
(ll 
Summaryll 
=ll 
$strll  ?
)ll? @
]ll@ A
[mm  
ProducesResponseTypemm 
(mm 
StatusCodesmm %
.mm% &
Status200OKmm& 1
)mm1 2
]mm2 3
[nn  
ProducesResponseTypenn 
(nn 
StatusCodesnn %
.nn% &
Status400BadRequestnn& 9
)nn9 :
]nn: ;
publicoo 

asyncoo 
Taskoo 
<oo 
IActionResultoo #
>oo# $
Activeoo% +
(oo+ ,
Guidoo, 0
idoo1 3
)oo3 4
{pp 
varqq 
responseqq 
=qq 
awaitqq 
_senderqq $
.qq$ %
Sendqq% )
(qq) *
newqq* -'
ActiveIngredientTypeCommandqq. I
(qqI J
idqqJ L
)qqL M
)qqM N
;qqN O
returnrr 
Okrr 
(rr 
newrr 
	OK_Resultrr 
<rr  
stringrr  &
>rr& '
(rr' (
$strrr( N
,rrN O
$strrrP R
)rrR S
)rrS T
;rrT U
}ss 
[zz 
HttpPostzz 
(zz 
$strzz "
)zz" #
]zz# $
[{{ 
SwaggerOperation{{ 
({{ 
Summary{{ 
={{ 
$str{{  A
){{A B
]{{B C
[||  
ProducesResponseType|| 
(|| 
StatusCodes|| %
.||% &
Status200OK||& 1
)||1 2
]||2 3
[}}  
ProducesResponseType}} 
(}} 
StatusCodes}} %
.}}% &
Status400BadRequest}}& 9
)}}9 :
]}}: ;
public~~ 

async~~ 
Task~~ 
<~~ 
IActionResult~~ #
>~~# $
InActive~~% -
(~~- .
Guid~~. 2
id~~3 5
)~~5 6
{ 
var
ÄÄ 
response
ÄÄ 
=
ÄÄ 
await
ÄÄ 
_sender
ÄÄ $
.
ÄÄ$ %
Send
ÄÄ% )
(
ÄÄ) *
new
ÄÄ* -+
InactiveIngredientTypeCommand
ÄÄ. K
(
ÄÄK L
id
ÄÄL N
)
ÄÄN O
)
ÄÄO P
;
ÄÄP Q
return
ÅÅ 
Ok
ÅÅ 
(
ÅÅ 
new
ÅÅ 
	OK_Result
ÅÅ 
<
ÅÅ  
string
ÅÅ  &
>
ÅÅ& '
(
ÅÅ' (
$str
ÅÅ( P
,
ÅÅP Q
$str
ÅÅR T
)
ÅÅT U
)
ÅÅU V
;
ÅÅV W
}
ÇÇ 
}ÉÉ ≈:
yC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\IngredientGeneralController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public 
class '
IngredientGeneralController (
:) *
DefaultController+ <
{ 
private 
readonly 
ISender 
_sender $
;$ %
public 
'
IngredientGeneralController &
(& '
ISender' .
sender/ 5
)5 6
{ 
_sender 
= 
sender 
; 
} 
[ 
HttpPost 
] 
[ 
SwaggerOperation 
( 
Summary 
= 
$str  C
)C D
]D E
[    
ProducesResponseType   
(   
StatusCodes   %
.  % &
Status200OK  & 1
)  1 2
]  2 3
[!!  
ProducesResponseType!! 
(!! 
StatusCodes!! %
.!!% &
Status400BadRequest!!& 9
)!!9 :
]!!: ;
public"" 

async"" 
Task"" 
<"" 
IActionResult"" #
>""# $
Create""% +
(""+ ,*
CreateIngredientGeneralCommand"", J
command""K R
)""R S
{## 
var$$ 
response$$ 
=$$ 
await$$ 
_sender$$ $
.$$$ %
Send$$% )
($$) *
command$$* 1
)$$1 2
;$$2 3
return%% 
Created%% 
(%% 
$str%% 
,%% 
new%% 
CREATED_Result%% -
(%%- .
$str%%. N
)%%N O
)%%O P
;%%P Q
}&& 
[.. 
HttpPut.. 
(.. 
$str.. 
).. 
].. 
[// 
SwaggerOperation// 
(// 
Summary// 
=// 
$str//  I
)//I J
]//J K
[00  
ProducesResponseType00 
(00 
StatusCodes00 %
.00% &
Status200OK00& 1
)001 2
]002 3
[11  
ProducesResponseType11 
(11 
StatusCodes11 %
.11% &
Status400BadRequest11& 9
)119 :
]11: ;
public22 

async22 
Task22 
<22 
IActionResult22 #
>22# $
Update22% +
(22+ ,
Guid22, 0
id221 3
,223 4*
UpdateIngredientGeneralCommand225 S
command22T [
)22[ \
{33 
command44 
.44 
Id44 
=44 
id44 
;44 
var55 
response55 
=55 
await55 
_sender55 $
.55$ %
Send55% )
(55) *
command55* 1
)551 2
;552 3
return66 
Ok66 
(66 
new66 
UPDATED_Result66 $
(66$ %
$str66% J
,66J K
response66L T
)66T U
)66U V
;66V W
}77 
[>> 
HttpPost>> 
(>> 
$str>>  
)>>  !
]>>! "
[?? 
SwaggerOperation?? 
(?? 
Summary?? 
=?? 
$str??  B
)??B C
]??C D
[@@  
ProducesResponseType@@ 
(@@ 
StatusCodes@@ %
.@@% &
Status200OK@@& 1
)@@1 2
]@@2 3
[AA  
ProducesResponseTypeAA 
(AA 
StatusCodesAA %
.AA% &
Status400BadRequestAA& 9
)AA9 :
]AA: ;
publicBB 

asyncBB 
TaskBB 
<BB 
IActionResultBB #
>BB# $
ActiveBB% +
(BB+ ,
GuidBB, 0
idBB1 3
)BB3 4
{CC 
varDD 
responseDD 
=DD 
awaitDD 
_senderDD $
.DD$ %
SendDD% )
(DD) *
newDD* -*
ActiveIngredientGeneralCommandDD. L
(DDL M
idDDM O
)DDO P
)DDP Q
;DDQ R
returnEE 
OkEE 
(EE 
newEE 
	OK_ResultEE 
<EE  
stringEE  &
>EE& '
(EE' (
$strEE( `
,EE` a
$strEEb d
)EEd e
)EEe f
;EEf g
}FF 
[MM 
HttpPostMM 
(MM 
$strMM "
)MM" #
]MM# $
[NN 
SwaggerOperationNN 
(NN 
SummaryNN 
=NN 
$strNN  D
)NND E
]NNE F
[OO  
ProducesResponseTypeOO 
(OO 
StatusCodesOO %
.OO% &
Status200OKOO& 1
)OO1 2
]OO2 3
[PP  
ProducesResponseTypePP 
(PP 
StatusCodesPP %
.PP% &
Status400BadRequestPP& 9
)PP9 :
]PP: ;
publicQQ 

asyncQQ 
TaskQQ 
<QQ 
IActionResultQQ #
>QQ# $
InactiveQQ% -
(QQ- .
GuidQQ. 2
idQQ3 5
)QQ5 6
{RR 
varSS 
responseSS 
=SS 
awaitSS 
_senderSS $
.SS$ %
SendSS% )
(SS) *
newSS* -,
 InactiveIngredientGeneralCommandSS. N
(SSN O
idSSO Q
)SSQ R
)SSR S
;SSS T
returnTT 
OkTT 
(TT 
newTT 
	OK_ResultTT 
<TT  
stringTT  &
>TT& '
(TT' (
$strTT( b
,TTb c
$strTTd f
)TTf g
)TTg h
;TTh i
}UU 
[\\ 
HttpGet\\ 
]\\ 
[]] 
SwaggerOperation]] 
(]] 
Summary]] 
=]] 
$str]]  D
)]]D E
]]]E F
[^^  
ProducesResponseType^^ 
(^^ 
StatusCodes^^ %
.^^% &
Status200OK^^& 1
)^^1 2
]^^2 3
[__  
ProducesResponseType__ 
(__ 
StatusCodes__ %
.__% &
Status400BadRequest__& 9
)__9 :
]__: ;
public`` 

async`` 
Task`` 
<`` 
IActionResult`` #
>``# $
Get``% (
(``( )
[``) *
	FromQuery``* 3
]``3 4#
GetAllIngredientCommand``5 L
command``M T
)``T U
{aa 
varbb 
responsebb 
=bb 
awaitbb 
_senderbb $
.bb$ %
Sendbb% )
(bb) *
commandbb* 1
)bb1 2
;bb2 3
returncc 
Okcc 
(cc 
newcc 
	OK_Resultcc 
<cc  
PagedResultcc  +
<cc+ ,$
GetAllIngredientResponsecc, D
>ccD E
>ccE F
(ccF G
$strccG q
,ccq r
responseccs {
)cc{ |
)cc| }
;cc} ~
}dd 
}ee æ.
rC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\IngredientController.cs
	namespace		 	
FOV		
 
.		 
Presentation		 
.		 
Controllers		 &
.		& '
V1		' )
{

 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
)  
]  !
public 

class  
IngredientController %
:& '
DefaultController( 9
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public  
IngredientController #
(# $
	IMediator$ -
mediator. 6
)6 7
{ 	
	_mediator 
= 
mediator  
;  !
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
[ 	
SwaggerOperation	 
( 
Summary !
=" #
$str$ M
)M N
]N O
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status200OK* 5
)5 6
]6 7
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status400BadRequest* =
)= >
]> ?
public 
async 
Task 
< 
IActionResult '
>' (
AddMultiple) 4
(4 5&
AddMultipleQuantityCommand5 O
commandP W
)W X
{   	
var!! 
result!! 
=!! 
await!! 
	_mediator!! (
.!!( )
Send!!) -
(!!- .
command!!. 5
)!!5 6
;!!6 7
if"" 
("" 
result"" 
."" 
	IsSuccess""  
)""  !
{## 
return$$ 
Ok$$ 
($$ 
new$$ 
	OK_Result$$ '
<$$' (
string$$( .
>$$. /
($$/ 0
$str$$0 M
,$$M N
result$$O U
.$$U V
	Successes$$V _
.$$_ `
First$$` e
($$e f
)$$f g
.$$g h
Message$$h o
)$$o p
)$$p q
;$$q r
}%% 
return&& 

BadRequest&& 
(&& 
result&& $
.&&$ %
Errors&&% +
.&&+ ,
Select&&, 2
(&&2 3
e&&3 4
=>&&5 7
e&&8 9
.&&9 :
Message&&: A
)&&A B
)&&B C
;&&C D
}'' 	
[.. 	
HttpPost..	 
(.. 
$str.. 
).. 
].. 
[// 	
SwaggerOperation//	 
(// 
Summary// !
=//" #
$str//$ M
)//M N
]//N O
[00 	 
ProducesResponseType00	 
(00 
StatusCodes00 )
.00) *
Status200OK00* 5
)005 6
]006 7
[11 	 
ProducesResponseType11	 
(11 
StatusCodes11 )
.11) *
Status400BadRequest11* =
)11= >
]11> ?
public22 
async22 
Task22 
<22 
IActionResult22 '
>22' (
	AddSingle22) 2
(222 3&
AddMultipleQuantityCommand223 M
command22N U
)22U V
{33 	
var44 
result44 
=44 
await44 
	_mediator44 (
.44( )
Send44) -
(44- .
command44. 5
)445 6
;446 7
if55 
(55 
result55 
.55 
	IsSuccess55  
)55  !
{66 
return77 
Ok77 
(77 
new77 
	OK_Result77 '
<77' (
string77( .
>77. /
(77/ 0
$str770 M
,77M N
result77O U
.77U V
	Successes77V _
.77_ `
First77` e
(77e f
)77f g
.77g h
Message77h o
)77o p
)77p q
;77q r
}88 
return99 

BadRequest99 
(99 
result99 $
.99$ %
Errors99% +
.99+ ,
Select99, 2
(992 3
e993 4
=>995 7
e998 9
.999 :
Message99: A
)99A B
)99B C
;99C D
}:: 	
[AA 	
HttpGetAA	 
]AA 
[BB 	
SwaggerOperationBB	 
(BB 
SummaryBB !
=BB" #
$strBB$ E
)BBE F
]BBF G
[CC 	 
ProducesResponseTypeCC	 
(CC 
StatusCodesCC )
.CC) *
Status200OKCC* 5
)CC5 6
]CC6 7
[DD 	 
ProducesResponseTypeDD	 
(DD 
StatusCodesDD )
.DD) *
Status400BadRequestDD* =
)DD= >
]DD> ?
publicEE 
asyncEE 
TaskEE 
<EE 
IActionResultEE '
>EE' (
GetEE) ,
(EE, -
[EE- .
	FromQueryEE. 7
]EE7 8!
GetIngredientsCommandEE9 N
commandEEO V
)EEV W
{FF 	
varGG 
resultGG 
=GG 
awaitGG 
	_mediatorGG (
.GG( )
SendGG) -
(GG- .
commandGG. 5
)GG5 6
;GG6 7
returnHH 
OkHH 
(HH 
newHH 
	OK_ResultHH #
<HH# $
PagedResultHH$ /
<HH/ 0"
GetIngredientsResponseHH0 F
>HHF G
>HHG H
(HHH I
$strHHI U
,HHU V
resultHHW ]
)HH] ^
)HH^ _
;HH_ `
}II 	
}JJ 
}KK ¶
qC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\GroupChatController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
public 
class 
GroupChatController  
:! "
DefaultController# 4
{ 
} µ
oC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\DefaultController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
[ 
Route 
( 
$str 
) 
] 
[ 
ApiController 
] 
public 
class 
DefaultController 
:  
ControllerBase! /
{		 
}

 Ü1
pC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\CategoryController.cs
	namespace

 	
FOV


 
.

 
Presentation

 
.

 
Controllers

 &
.

& '
V1

' )
;

) *
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public 
class 
CategoryController 
:  !
DefaultController" 3
{ 
private 
readonly 
	IMediator 
	_mediator (
;( )
public 

CategoryController 
( 
	IMediator '
mediator( 0
)0 1
{ 
	_mediator 
= 
mediator 
; 
} 
[ 
HttpGet 
] 
[ 
SwaggerOperation 
( 
Summary 
= 
$str  B
)B C
]C D
[  
ProducesResponseType 
( 
StatusCodes %
.% &
Status200OK& 1
)1 2
]2 3
[  
ProducesResponseType 
( 
StatusCodes %
.% &
Status400BadRequest& 9
)9 :
]: ;
public 

async 
Task 
< 
IActionResult #
># $
GetCategory% 0
(0 1
)1 2
{   
var!! 
response!! 
=!! 
await!! 
	_mediator!! &
.!!& '
Send!!' +
(!!+ ,
new!!, / 
GetCategoriesCommand!!0 D
(!!D E
)!!E F
)!!F G
;!!G H
return"" 
Ok"" 
("" 
new"" 
	OK_Result"" 
<""  
List""  $
<""$ %'
GetParentCategoriesResponse""% @
>""@ A
>""A B
(""B C
$str""C \
,""\ ]
response""^ f
)""f g
)""g h
;""h i
}## 
[** 
HttpPost** 
]** 
[++ 
SwaggerOperation++ 
(++ 
Summary++ 
=++ 
$str++  <
)++< =
]++= >
[,,  
ProducesResponseType,, 
(,, 
StatusCodes,, %
.,,% &
Status200OK,,& 1
),,1 2
],,2 3
[--  
ProducesResponseType-- 
(-- 
StatusCodes-- %
.--% &
Status400BadRequest--& 9
)--9 :
]--: ;
public.. 

async.. 
Task.. 
<.. 
IActionResult.. #
>..# $
AddChildCategory..% 5
(..5 6
[..6 7
FromBody..7 ?
]..? @!
AddNewCategoryCommand..A V
command..W ^
)..^ _
{// 
var00 
response00 
=00 
await00 
	_mediator00 &
.00& '
Send00' +
(00+ ,
command00, 3
)003 4
;004 5
return11 
Ok11 
(11 
new11 
	OK_Result11 
<11  
Guid11  $
>11$ %
(11% &
$str11& D
,11D E
response11F N
)11N O
)11O P
;11P Q
}22 
[:: 
HttpPut:: 
(:: 
$str:: 
):: 
]:: 
[;; 
SwaggerOperation;; 
(;; 
Summary;; 
=;; 
$str;;  Q
);;Q R
];;R S
[<<  
ProducesResponseType<< 
(<< 
StatusCodes<< %
.<<% &
Status200OK<<& 1
)<<1 2
]<<2 3
[==  
ProducesResponseType== 
(== 
StatusCodes== %
.==% &
Status400BadRequest==& 9
)==9 :
]==: ;
public>> 

async>> 
Task>> 
<>> 
IActionResult>> #
>>># $
Update>>% +
(>>+ ,
Guid>>, 0
id>>1 3
,>>3 4
[>>5 6
FromBody>>6 >
]>>> ?!
UpdateCategoryCommand>>@ U
command>>V ]
)>>] ^
{?? 
command@@ 
.@@ 
Id@@ 
=@@ 
id@@ 
;@@ 
varAA 
responseAA 
=AA 
awaitAA 
	_mediatorAA &
.AA& '
SendAA' +
(AA+ ,
commandAA, 3
)AA3 4
;AA4 5
returnBB 
OkBB 
(BB 
newBB 
	OK_ResultBB 
<BB  
stringBB  &
>BB& '
(BB' (
$strBB( F
,BBF G
$strBBH J
)BBJ K
)BBK L
;BBL M
}CC 
[JJ 

HttpDeleteJJ 
(JJ 
$strJJ 
)JJ 
]JJ 
[KK 
SwaggerOperationKK 
(KK 
SummaryKK 
=KK 
$strKK  ;
)KK; <
]KK< =
[LL  
ProducesResponseTypeLL 
(LL 
StatusCodesLL %
.LL% &
Status200OKLL& 1
)LL1 2
]LL2 3
[MM  
ProducesResponseTypeMM 
(MM 
StatusCodesMM %
.MM% &
Status400BadRequestMM& 9
)MM9 :
]MM: ;
publicNN 

asyncNN 
TaskNN 
<NN 
IActionResultNN #
>NN# $
DeleteNN% +
(NN+ ,
GuidNN, 0
idNN1 3
)NN3 4
{OO 
varPP 
responsePP 
=PP 
awaitPP 
	_mediatorPP &
.PP& '
SendPP' +
(PP+ ,
newPP, /!
DeleteCategoryCommandPP0 E
(PPE F
idPPF H
)PPH I
)PPI J
;PPJ K
returnQQ 
OkQQ 
(QQ 
newQQ 
	OK_ResultQQ 
<QQ  
stringQQ  &
>QQ& '
(QQ' (
$strQQ( E
,QQE F
$strQQG I
)QQI J
)QQJ K
;QQK L
}RR 
}SS Õm
lC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\AuthController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public 
class 
AuthController 
: 
DefaultController /
{ 
private 
readonly 
ISender 
_sender $
;$ %
public 

AuthController 
( 
ISender !
sender" (
)( )
{ 
_sender 
= 
sender 
; 
} 
[## 
HttpPost## 
(## 
$str## 
)## 
]## 
[$$ 
SwaggerOperation$$ 
($$ 
Summary$$ 
=$$ 
$str$$  4
)$$4 5
]$$5 6
[%%  
ProducesResponseType%% 
(%% 
StatusCodes%% %
.%%% &
Status200OK%%& 1
)%%1 2
]%%2 3
[&&  
ProducesResponseType&& 
(&& 
StatusCodes&& %
.&&% &
Status400BadRequest&&& 9
)&&9 :
]&&: ;
public'' 

async'' 
Task'' 
<'' 
IActionResult'' #
>''# $
Update''% +
(''+ ,
EditProfileCommand'', >
command''? F
)''F G
{(( 
var)) 
response)) 
=)) 
await)) 
_sender)) $
.))$ %
Send))% )
())) *
command))* 1
)))1 2
;))2 3
return** 
Ok** 
(** 
new** 
	OK_Result** 
<**  
string**  &
>**& '
(**' (
$str**( K
,**K L
response**M U
.**U V
	Successes**V _
.**_ `
First**` e
(**e f
)**f g
.**g h
Message**h o
)**o p
)**p q
;**q r
}++ 
[33 
HttpPost33 
(33 
$str33 
)33  
]33  !
[44 
SwaggerOperation44 
(44 
Summary44 
=44 
$str44  7
)447 8
]448 9
[55  
ProducesResponseType55 
(55 
StatusCodes55 %
.55% &
Status200OK55& 1
)551 2
]552 3
[66  
ProducesResponseType66 
(66 
StatusCodes66 %
.66% &
Status400BadRequest66& 9
)669 :
]66: ;
public77 

async77 
Task77 
<77 
IActionResult77 #
>77# $
ChangePassword77% 3
(773 4!
ChangePasswordCommand774 I
command77J Q
)77Q R
{88 
var99 
result99 
=99 
await99 
_sender99 "
.99" #
Send99# '
(99' (
command99( /
)99/ 0
;990 1
if:: 

(:: 
result:: 
.:: 
	IsSuccess:: 
):: 
{;; 	
return<< 
Ok<< 
(<< 
new<< 
	OK_Result<< #
<<<# $
string<<$ *
><<* +
(<<+ ,
$str<<, J
,<<J K
result<<L R
.<<R S
	Successes<<S \
.<<\ ]
First<<] b
(<<b c
)<<c d
.<<d e
Message<<e l
)<<l m
)<<m n
;<<n o
}== 	
return?? 

BadRequest?? 
(?? 
result??  
.??  !
Errors??! '
.??' (
Select??( .
(??. /
e??/ 0
=>??1 3
e??4 5
.??5 6
Message??6 =
)??= >
)??> ?
;??? @
}@@ 
[GG 
HttpPostGG 
(GG 
$strGG 
)GG 
]GG 
[HH 
SwaggerOperationHH 
(HH 
SummaryHH 
=HH 
$strHH  6
)HH6 7
]HH7 8
[II  
ProducesResponseTypeII 
(II 
StatusCodesII %
.II% &
Status200OKII& 1
)II1 2
]II2 3
[JJ  
ProducesResponseTypeJJ 
(JJ 
StatusCodesJJ %
.JJ% &
Status400BadRequestJJ& 9
)JJ9 :
]JJ: ;
publicKK 

asyncKK 
TaskKK 
<KK 
IActionResultKK #
>KK# $
RegisterKK% -
(KK- .
UserRegisterCommandKK. A
commandKKB I
)KKI J
{LL 
varMM 
responseMM 
=MM 
awaitMM 
_senderMM $
.MM$ %
SendMM% )
(MM) *
commandMM* 1
)MM1 2
;MM2 3
returnNN 
responseNN 
.NN 
	IsSuccessNN !
?NN" #
OkOO 
(OO 
newOO 
	OK_ResultOO 
<OO 
stringOO #
>OO# $
(OO$ %
$strOO% 9
,OO9 :
responseOO; C
.OOC D
	SuccessesOOD M
.OOM N
FirstOON S
(OOS T
)OOT U
.OOU V
MessageOOV ]
)OO] ^
)OO^ _
:OO` a

BadRequestPP 
(PP 
newPP 
ErrorPP  
<PP  !
IReasonPP! (
>PP( )
(PP) *
$strPP* ,
,PP, -!
ErrorStatusCodeConfigPP. C
.PPC D
BAD_REQUESTPPD O
,PPO P
responsePPQ Y
.PPY Z
ReasonsPPZ a
)PPa b
)PPb c
;PPc d
}QQ 
[XX 
HttpPostXX 
(XX 
$strXX 
)XX 
]XX  
[YY 
SwaggerOperationYY 
(YY 
SummaryYY 
=YY 
$strYY  1
)YY1 2
]YY2 3
[ZZ  
ProducesResponseTypeZZ 
(ZZ 
StatusCodesZZ %
.ZZ% &
Status200OKZZ& 1
)ZZ1 2
]ZZ2 3
[[[  
ProducesResponseType[[ 
([[ 
StatusCodes[[ %
.[[% &
Status400BadRequest[[& 9
)[[9 :
][[: ;
public\\ 

async\\ 
Task\\ 
<\\ 
IActionResult\\ #
>\\# $
Login\\% *
(\\* + 
EmployeeLoginCommand\\+ ?
request\\@ G
)\\G H
{]] 
var^^ 
response^^ 
=^^ 
await^^ 
_sender^^ $
.^^$ %
Send^^% )
(^^) *
request^^* 1
)^^1 2
;^^2 3
return__ 
Ok__ 
(__ 
new__ 
	OK_Result__ 
<__  !
EmployeeLoginResponse__  5
>__5 6
(__6 7
$str__7 M
,__M N
response__O W
)__W X
)__X Y
;__Y Z
}`` 
[gg 
HttpPostgg 
(gg 
$strgg 
)gg 
]gg  
[hh 
SwaggerOperationhh 
(hh 
Summaryhh 
=hh 
$strhh  1
)hh1 2
]hh2 3
[ii  
ProducesResponseTypeii 
(ii 
StatusCodesii %
.ii% &
Status200OKii& 1
)ii1 2
]ii2 3
[jj  
ProducesResponseTypejj 
(jj 
StatusCodesjj %
.jj% &
Status400BadRequestjj& 9
)jj9 :
]jj: ;
publickk 

asynckk 
Taskkk 
<kk 
IActionResultkk #
>kk# $
CustomerLoginkk% 2
(kk2 3
UserLoginCommandkk3 C
commandkkD K
)kkK L
{ll 
varmm 
responsemm 
=mm 
awaitmm 
_sendermm $
.mm$ %
Sendmm% )
(mm) *
commandmm* 1
)mm1 2
;mm2 3
returnnn 
Oknn 
(nn 
newnn 
	OK_Resultnn 
<nn  
UserResponsenn  ,
>nn, -
(nn- .
$strnn. D
,nnD E
responsennF N
)nnN O
)nnO P
;nnP Q
}oo 
[uu 
HttpGetuu 
(uu 
$struu 
)uu 
]uu 
[vv 
SwaggerOperationvv 
(vv 
Summaryvv 
=vv 
$strvv  4
)vv4 5
]vv5 6
[ww  
ProducesResponseTypeww 
(ww 
StatusCodesww %
.ww% &
Status200OKww& 1
)ww1 2
]ww2 3
[xx  
ProducesResponseTypexx 
(xx 
StatusCodesxx %
.xx% &
Status404NotFoundxx& 7
)xx7 8
]xx8 9
publicyy 

asyncyy 
Taskyy 
<yy 
IActionResultyy #
>yy# $
Profileyy% ,
(yy, -
)yy- .
{zz 
var{{ 
response{{ 
={{ 
await{{ 
_sender{{ $
.{{$ %
Send{{% )
({{) *
new{{* -
ViewProfileCommand{{. @
({{@ A
){{A B
){{B C
;{{C D
return|| 
Ok|| 
(|| 
new|| 
	OK_Result|| 
<||  
ViewProfileResponse||  3
>||3 4
(||4 5
$str||5 W
,||W X
response||Y a
)||a b
)||b c
;||c d
}}} 
[
ÉÉ 
HttpGet
ÉÉ 
(
ÉÉ 
$str
ÉÉ 
)
ÉÉ 
]
ÉÉ 
[
ÑÑ 
SwaggerOperation
ÑÑ 
(
ÑÑ 
Summary
ÑÑ 
=
ÑÑ 
$str
ÑÑ  4
)
ÑÑ4 5
]
ÑÑ5 6
public
ÖÖ 

IActionResult
ÖÖ 
LoginWithGoogle
ÖÖ (
(
ÖÖ( )
)
ÖÖ) *
{
ÜÜ 
var
áá 
redirectUrl
áá 
=
áá 
Url
áá 
.
áá 
Action
áá $
(
áá$ %
$str
áá% 5
,
áá5 6
$str
áá7 =
)
áá= >
;
áá> ?
var
àà 

properties
àà 
=
àà 
new
àà &
AuthenticationProperties
àà 5
{
àà6 7
RedirectUri
àà8 C
=
ààD E
redirectUrl
ààF Q
}
ààR S
;
ààS T
return
ââ 
	Challenge
ââ 
(
ââ 

properties
ââ #
,
ââ# $
GoogleDefaults
ââ% 3
.
ââ3 4"
AuthenticationScheme
ââ4 H
)
ââH I
;
ââI J
}
ää 
[
êê 
HttpGet
êê 
(
êê 
$str
êê 
)
êê 
]
êê 
[
ëë 
SwaggerOperation
ëë 
(
ëë 
Summary
ëë 
=
ëë 
$str
ëë  @
)
ëë@ A
]
ëëA B
public
íí 

async
íí 
Task
íí 
<
íí 
IActionResult
íí #
>
íí# $
GoogleResponse
íí% 3
(
íí3 4
)
íí4 5
{
ìì 
var
îî 
result
îî 
=
îî 
await
îî 
HttpContext
îî &
.
îî& '
AuthenticateAsync
îî' 8
(
îî8 9
GoogleDefaults
îî9 G
.
îîG H"
AuthenticationScheme
îîH \
)
îî\ ]
;
îî] ^
if
ïï 

(
ïï 
!
ïï 
result
ïï 
.
ïï 
	Succeeded
ïï 
)
ïï 
{
ññ 	
return
óó 

BadRequest
óó 
(
óó 
$str
óó @
)
óó@ A
;
óóA B
}
òò 	
var
öö 
response
öö 
=
öö 
await
öö 
_sender
öö $
.
öö$ %
Send
öö% )
(
öö) *
new
öö* -$
UserGoogleLoginCommand
öö. D
(
ööD E
result
õõ 
.
õõ 
	Principal
õõ 
.
õõ 
FindFirstValue
õõ +
(
õõ+ ,

ClaimTypes
õõ, 6
.
õõ6 7
NameIdentifier
õõ7 E
)
õõE F
,
õõF G
result
úú 
.
úú 
	Principal
úú 
.
úú 
FindFirstValue
úú +
(
úú+ ,

ClaimTypes
úú, 6
.
úú6 7
Email
úú7 <
)
úú< =
,
úú= >
result
ùù 
.
ùù 
	Principal
ùù 
.
ùù 
FindFirstValue
ùù +
(
ùù+ ,

ClaimTypes
ùù, 6
.
ùù6 7
Name
ùù7 ;
)
ùù; <
,
ùù< =
result
ûû 
.
ûû 
	Principal
ûû 
.
ûû 
FindFirstValue
ûû +
(
ûû+ ,
$str
ûû, 5
)
ûû5 6
)
üü 	
)
üü	 

;
üü
 
var
°° 
claims
°° 
=
°° 
result
°° 
.
°° 
	Principal
°° %
.
°°% &

Identities
°°& 0
.
¢¢ 
FirstOrDefault
¢¢ 
(
¢¢ 
)
¢¢ 
?
¢¢ 
.
¢¢ 
Claims
¢¢ %
.
¢¢% &
Select
¢¢& ,
(
¢¢, -
claim
¢¢- 2
=>
¢¢3 5
new
¢¢6 9
{
££ 
claim
§§ 
.
§§ 
Issuer
§§ 
,
§§ 
claim
•• 
.
•• 
OriginalIssuer
•• $
,
••$ %
claim
¶¶ 
.
¶¶ 
Type
¶¶ 
,
¶¶ 
claim
ßß 
.
ßß 
Value
ßß 
}
®® 
)
®® 
;
®® 
return
¨¨ 
Ok
¨¨ 
(
¨¨ 
claims
¨¨ 
)
¨¨ 
;
¨¨ 
}
≠≠ 
}∞∞ ”
rC:\Code\FinalCapstionProject_Fall2024\FOV-Fall2024-API\src\FOV.Presentation\Controllers\V1\AttendanceController.cs
	namespace 	
FOV
 
. 
Presentation 
. 
Controllers &
.& '
V1' )
;) *
public		 
class		  
AttendanceController		 !
(		! "
ISender		" )
sender		* 0
)		0 1
:		2 3
DefaultController		4 E
{

 
private 
readonly 
ISender 
_sender $
=% &
sender' -
;- .
[ 
HttpPost 
( 
$str (
)( )
]) *
public 

async 
Task 
< 
IActionResult #
># $!
GenerateCheckInQRCode% :
(: ;(
GenerateCheckInQRCodeCommand; W
commandX _
)_ `
{ 
var 
result 
= 
await 
_sender "
." #
Send# '
(' (
command( /
)/ 0
;0 1
return 
Ok 
( 
result 
) 
; 
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
CheckAttendance% 4
(4 5"
CheckAttendanceCommand5 K
commandL S
)S T
{ 
var 
result 
= 
await 
_sender "
." #
Send# '
(' (
command( /
)/ 0
;0 1
return 
Ok 
( 
new 
{ 
message 
=  !
result" (
}) *
)* +
;+ ,
} 
[ 
HttpGet 
] 
public 

async 
Task 
< 
IActionResult #
># $
GetDailyAttendance% 7
(7 8
[8 9
	FromQuery9 B
]B C%
GetDailyAttendanceCommandD ]
command^ e
)e f
{ 
var 
result 
= 
await 
_sender "
." #
Send# '
(' (
command( /
)/ 0
;0 1
return 
Ok 
( 
result 
) 
; 
} 
} 