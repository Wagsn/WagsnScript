grammar WS;

/// Parser Rules

// program
prog: stat* ;
// statement
stat
    : expr ';'  #PrintExpr
    | ID '=' expr ';'  #Assign
;
expr
    : addExpr  #AddExpression
;
addExpr
    : multExpr 
    | addExpr op=('+'|'-') multExpr 
;
multExpr
    : miniExpr 
    | multExpr op=('*'|'/') miniExpr 
;
miniExpr
    : INT     #Int
    | ID      #Ident
    | '(' expr ')'  #Parens
;

///  Lexer Rules

INT : '0'..'9'+ ;

// Identifier
ID
    : [a-zA-Z][a-zA-Z0-9]*
;

ADD : '+' ;
SUB : '-' ;
MUL : '*' ;
DIV : '/' ;

WS : [ \t\r\n]+ -> skip ;