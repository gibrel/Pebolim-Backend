ó
UC:\Users\gibre\Projects\Pebolim\Pebolim-Backend\Pebolim.Domain\Entities\BaseEntity.cs
	namespace 	
Pebolim
 
. 
Domain 
. 
Entities !
{ 
public 

class 

BaseEntity 
{ 
[ 	
Key	 
] 
public 
virtual 
int 
Id 
{ 
get  #
;# $
set% (
;( )
}* +
}		 
}

 ß
OC:\Users\gibre\Projects\Pebolim\Pebolim-Backend\Pebolim.Domain\Entities\User.cs
	namespace 	
Pebolim
 
. 
Domain 
. 
Entities !
{ 
public 

class 
User 
: 

BaseEntity "
{ 
[ 	
Required	 
] 
public 
string 
Username 
{  
get! $
;$ %
set& )
;) *
}+ ,
[		 	
Required			 
]		 
public

 
string

 
PasswordHash

 "
{

# $
get

% (
;

( )
set

* -
;

- .
}

/ 0
[ 	
Required	 
] 
public 
string 
Salt 
{ 
get  
;  !
set" %
;% &
}' (
public 
User 
( 
string 
username #
,# $
string% +
passwordHash, 8
,8 9
string: @
saltA E
)E F
{ 	
Username 
= 
username 
;  
PasswordHash 
= 
passwordHash '
;' (
Salt 
= 
salt 
; 
} 	
} 
} ∑

\C:\Users\gibre\Projects\Pebolim\Pebolim-Backend\Pebolim.Domain\Interfaces\IBaseRepository.cs
	namespace 	
Pebolim
 
. 
Domain 
. 

Interfaces #
{ 
public 

	interface 
IBaseRepository $
<$ %
TEntity% ,
>, -
where. 3
TEntity4 ;
:< =

BaseEntity> H
{ 
Task 
< 
bool 
> 
Insert 
( 
TEntity !
obj" %
)% &
;& '
Task 
< 
bool 
> 
Update 
( 
TEntity !
obj" %
)% &
;& '
Task		 
<		 
bool		 
>		 
Delete		 
(		 
int		 
id		  
)		  !
;		! "
Task

 
<

 
IList

 
<

 
TEntity

 
>

 
>

 
Select

 #
(

# $
)

$ %
;

% &
Task 
< 
TEntity 
? 
> 
Select 
( 
int !
id" $
)$ %
;% &
} 
} è
YC:\Users\gibre\Projects\Pebolim\Pebolim-Backend\Pebolim.Domain\Interfaces\IBaseService.cs
	namespace 	
Pebolim
 
. 
Domain 
. 

Interfaces #
{ 
public 

	interface 
IBaseService !
<! "
TEntity" )
>) *
where+ 0
TEntity1 8
:9 :

BaseEntity; E
{ 
public 
abstract 
Task 
< 
TOutputModel )
>) *
Add+ .
<. /
TInputModel/ :
,: ;
TOutputModel< H
,H I

TValidatorJ T
>T U
(U V
TInputModelV a

inputModelb l
)l m
where		 

TValidator		 
:		 
AbstractValidator		 0
<		0 1
TEntity		1 8
>		8 9
where

 
TInputModel

 
:

 
class

  %
where 
TOutputModel 
:  
class! &
;& '
public 
abstract 
Task 
< 
List !
<! "
TOutputModel" .
>. /
>/ 0
GetAll1 7
<7 8
TOutputModel8 D
>D E
(E F
)F G
whereH M
TOutputModelN Z
:[ \
class] b
;b c
public 
abstract 
Task 
< 
TOutputModel )
>) *
GetById+ 2
<2 3
TOutputModel3 ?
>? @
(@ A
intA D
idE G
)G H
whereI N
TOutputModelO [
:\ ]
class^ c
;c d
public 
abstract 
Task 
< 
TOutputModel )
>) *
Update+ 1
<1 2
TInputModel2 =
,= >
TOutputModel? K
,K L

TValidatorM W
>W X
(X Y
TInputModelY d

inputModele o
)o p
where 

TValidator 
: 
AbstractValidator 0
<0 1
TEntity1 8
>8 9
where 
TInputModel 
: 
class  %
where 
TOutputModel 
:  
class! &
;& '
public 
abstract 
Task 
< 
bool !
>! "
Delete# )
() *
int* -
id. 0
)0 1
;1 2
} 
} Æ
\C:\Users\gibre\Projects\Pebolim\Pebolim-Backend\Pebolim.Domain\Interfaces\IUserRepository.cs
	namespace 	
Pebolim
 
. 
Domain 
. 

Interfaces #
{ 
public 

	interface 
IUserRepository $
:% &
IBaseRepository' 6
<6 7
User7 ;
>; <
{ 
} 
} •
YC:\Users\gibre\Projects\Pebolim\Pebolim-Backend\Pebolim.Domain\Interfaces\IUserService.cs
	namespace 	
Pebolim
 
. 
Domain 
. 

Interfaces #
{ 
public 

	interface 
IUserService !
:" #
IBaseService$ 0
<0 1
User1 5
>5 6
{ 
} 
} 