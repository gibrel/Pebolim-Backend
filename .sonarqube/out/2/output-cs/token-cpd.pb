˛9
WC:\Users\gibre\Projects\Pebolim\Pebolim-Backend\Pebolim.Service\Services\BaseService.cs
	namespace 	
Pebolim
 
. 
Service 
. 
Services "
{ 
public		 

class		 
BaseService		 
<		 
TEntity		 $
>		$ %
:		& '
IBaseService		( 4
<		4 5
TEntity		5 <
>		< =
where		> C
TEntity		D K
:		L M

BaseEntity		N X
{

 
	protected 
readonly 
IBaseRepository *
<* +
TEntity+ 2
>2 3
_baseRepository4 C
;C D
	protected 
readonly 
IMapper "
_mapper# *
;* +
public 
BaseService 
( 
IBaseRepository *
<* +
TEntity+ 2
>2 3
baseRepository4 B
,B C
IMapperD K
mapperL R
)R S
{ 	
_baseRepository 
= 
baseRepository ,
;, -
_mapper 
= 
mapper 
; 
} 	
public 
virtual 
async 
Task !
<! "
TOutputModel" .
>. /
Add0 3
<3 4
TInputModel4 ?
,? @
TOutputModelA M
,M N

TValidatorO Y
>Y Z
(Z [
TInputModel[ f

inputModelg q
)q r
where 

TValidator 
: 
AbstractValidator 0
<0 1
TEntity1 8
>8 9
where 
TInputModel 
: 
class  %
where 
TOutputModel 
:  
class! &
{ 	
TEntity 
entity 
= 
_mapper $
.$ %
Map% (
<( )
TEntity) 0
>0 1
(1 2

inputModel2 <
)< =
;= >
Validate 
( 
entity 
, 
	Activator &
.& '
CreateInstance' 5
<5 6

TValidator6 @
>@ A
(A B
)B C
)C D
;D E
await 
_baseRepository !
.! "
Insert" (
(( )
entity) /
)/ 0
;0 1
TOutputModel 
outputModel $
=% &
_mapper' .
.. /
Map/ 2
<2 3
TOutputModel3 ?
>? @
(@ A
entityA G
)G H
;H I
return   
outputModel   
;   
}!! 	
public## 
virtual## 
async## 
Task## !
<##! "
List##" &
<##& '
TOutputModel##' 3
>##3 4
>##4 5
GetAll##6 <
<##< =
TOutputModel##= I
>##I J
(##J K
)##K L
where##M R
TOutputModel##S _
:##` a
class##b g
{$$ 	
var%% 
entities%% 
=%% 
await%%  
_baseRepository%%! 0
.%%0 1
Select%%1 7
(%%7 8
)%%8 9
;%%9 :
var'' 
outputModels'' 
='' 
entities'' '
.''' (
Select''( .
(''. /
s''/ 0
=>''1 3
_mapper''4 ;
.''; <
Map''< ?
<''? @
TOutputModel''@ L
>''L M
(''M N
s''N O
)''O P
)''P Q
.''Q R
ToList''R X
(''X Y
)''Y Z
;''Z [
return)) 
outputModels)) 
;))  
}** 	
public,, 
virtual,, 
async,, 
Task,, !
<,,! "
TOutputModel,," .
>,,. /
GetById,,0 7
<,,7 8
TOutputModel,,8 D
>,,D E
(,,E F
int,,F I
id,,J L
),,L M
where,,N S
TOutputModel,,T `
:,,a b
class,,c h
{-- 	
var.. 
entity.. 
=.. 
await.. 
_baseRepository.. .
.... /
Select../ 5
(..5 6
id..6 8
)..8 9
;..9 :
var00 
outputModel00 
=00 
_mapper00 %
.00% &
Map00& )
<00) *
TOutputModel00* 6
>006 7
(007 8
entity008 >
)00> ?
;00? @
return22 
outputModel22 
;22 
}33 	
public55 
virtual55 
async55 
Task55 !
<55! "
TOutputModel55" .
>55. /
Update550 6
<556 7
TInputModel557 B
,55B C
TOutputModel55D P
,55P Q

TValidator55R \
>55\ ]
(55] ^
TInputModel55^ i

inputModel55j t
)55t u
where66 
TInputModel66 
:66 
class66  %
where77 
TOutputModel77 
:77  
class77! &
where88 

TValidator88 
:88 
AbstractValidator88 0
<880 1
TEntity881 8
>888 9
{99 	
TEntity:: 
entity:: 
=:: 
_mapper:: $
.::$ %
Map::% (
<::( )
TEntity::) 0
>::0 1
(::1 2

inputModel::2 <
)::< =
;::= >
Validate<< 
(<< 
entity<< 
,<< 
	Activator<< &
.<<& '
CreateInstance<<' 5
<<<5 6

TValidator<<6 @
><<@ A
(<<A B
)<<B C
)<<C D
;<<D E
await== 
_baseRepository== !
.==! "
Update==" (
(==( )
entity==) /
)==/ 0
;==0 1
TOutputModel?? 
outputModel?? $
=??% &
_mapper??' .
.??. /
Map??/ 2
<??2 3
TOutputModel??3 ?
>??? @
(??@ A
entity??A G
)??G H
;??H I
returnAA 
outputModelAA 
;AA 
}BB 	
publicDD 
virtualDD 
asyncDD 
TaskDD !
<DD! "
boolDD" &
>DD& '
DeleteDD( .
(DD. /
intDD/ 2
idDD3 5
)DD5 6
=>DD7 9
awaitDD: ?
_baseRepositoryDD@ O
.DDO P
DeleteDDP V
(DDV W
idDDW Y
)DDY Z
;DDZ [
	protectedFF 
voidFF 
ValidateFF 
(FF  
TEntityFF  '
objFF( +
,FF+ ,
AbstractValidatorFF- >
<FF> ?
TEntityFF? F
>FFF G
	validatorFFH Q
)FFQ R
{GG 	
ifHH 
(HH 
objHH 
==HH 
nullHH 
)HH 
throwII 
newII #
ObjectNotFoundExceptionII 1
(II1 2
$strII2 J
)IIJ K
;IIK L
	validatorKK 
.KK 
ValidateAndThrowKK &
(KK& '
objKK' *
)KK* +
;KK+ ,
}LL 	
}MM 
}NN ù
WC:\Users\gibre\Projects\Pebolim\Pebolim-Backend\Pebolim.Service\Services\UserService.cs
	namespace 	
Pebolim
 
. 
Service 
. 
Services "
{ 
public 

class 
UserService 
: 
BaseService *
<* +
User+ /
>/ 0
,0 1
IUserService2 >
{ 
public		 
UserService		 
(		 
IUserRepository

 
userRepository

 *
,

* +
IMapper 
mapper 
) 	
:
 
base 
( 
userRepository 
,  
mapper! '
)' (
{ 	
} 	
} 
} ﬂ
[C:\Users\gibre\Projects\Pebolim\Pebolim-Backend\Pebolim.Service\Validators\UserValidator.cs
	namespace 	
Pebolim
 
. 
Service 
. 

Validators $
{ 
public 

class 
UserValidator 
:  
AbstractValidator! 2
<2 3
User3 7
>7 8
{ 
public 
UserValidator 
( 
) 
{		 	
RuleFor

 
(

 
u

 
=>

 
u

 
.

 
Username

 #
)

# $
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( D
)D E
. 
NotNull 
( 
) 
. 
WithMessage &
(& '
$str' C
)C D
;D E
} 	
} 
} 