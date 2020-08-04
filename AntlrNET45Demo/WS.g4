grammar WS;

/*
 * Parser Rules
 */

// program
prog
    : stat*
;

// statement
stat
    : singleExpression ';'
;

assign
    : ID '=' singleExpression
;

call
    : ID '(' (singleExpression (',' singleExpression)*)* ')'
;

// singleExpression
singleExpression
    : singleExpression operate = ('*' | '/') singleExpression   #MultiplyDivide
    | singleExpression operate = ('+' | '-') singleExpression   #AddSubtraction    
    | INT                                                       #NumberLiteral
    | bool                                                      #BooleanLiteral
    | assign                                                    #Assignment
    | call                                                      #CallExpression
    | '(' singleExpression ')'                                  #Parenthesis
;

bool
    : 'true'
    | 'false'
;

/*
 * Lexer Rules
 */

// Identifier
ID : [a-zA-Z][a-zA-Z0-9]*;

ADD : '+' ;
SUB : '-' ;
MUL : '*' ;
DIV : '/' ;

INT : '0'..'9'+ ;

WS : [ \t\r\n]+ -> skip ;