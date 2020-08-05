//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from E:\WorkSpace\GitHub\WagsnScript\AntlrNET45Demo\WS.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace AntlrNET45Demo {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="WSParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IWSVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by the <c>Ident</c>
	/// labeled alternative in <see cref="WSParser.miniExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdent([NotNull] WSParser.IdentContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>Parens</c>
	/// labeled alternative in <see cref="WSParser.miniExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParens([NotNull] WSParser.ParensContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>Int</c>
	/// labeled alternative in <see cref="WSParser.miniExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInt([NotNull] WSParser.IntContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>Assign</c>
	/// labeled alternative in <see cref="WSParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssign([NotNull] WSParser.AssignContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>PrintExpr</c>
	/// labeled alternative in <see cref="WSParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintExpr([NotNull] WSParser.PrintExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>AddExpression</c>
	/// labeled alternative in <see cref="WSParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddExpression([NotNull] WSParser.AddExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="WSParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProg([NotNull] WSParser.ProgContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="WSParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStat([NotNull] WSParser.StatContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="WSParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] WSParser.ExprContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="WSParser.addExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddExpr([NotNull] WSParser.AddExprContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="WSParser.multExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultExpr([NotNull] WSParser.MultExprContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="WSParser.miniExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMiniExpr([NotNull] WSParser.MiniExprContext context);
}
} // namespace AntlrNET45Demo
