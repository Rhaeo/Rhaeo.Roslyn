// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoslynExtensions.cs" company="Rhaeo.org">
//   Licenced under the MIT license.
// </copyright>
// <summary>
//   Defines the RoslynExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Rhaeo.Roslyn
{
  /// <summary>
  /// Contains extension methods for Roslyn code analysis types simplifying some common code generation tasks.
  /// </summary>
  public static class RoslynExtensions
  {
    #region Methods

    /// <summary>
    /// Creates a new node from this node with the leading trivia replaced with a XML documentation.
    /// </summary>
    /// <typeparam name="TSyntaxNode">
    /// The type of the syntax node.
    /// </typeparam>
    /// <param name="syntaxNode">
    /// The syntax node.
    /// </param>
    /// <param name="summary">
    /// The documentation <code>summary</code> element content.
    /// </param>
    /// <returns>
    /// The new syntax node.
    /// </returns>
    [
    SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1008:OpeningParenthesisMustBeSpacedCorrectly", Justification = "Ignored for more tree-like fluent syntax usage."),
    SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1009:ClosingParenthesisMustBeSpacedCorrectly", Justification = "Ignored for more tree-like fluent syntax usage."),
    SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1110:OpeningParenthesisMustBeOnDeclarationLine", Justification = "Ignored for more tree-like fluent syntax usage."),
    SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1111:ClosingParenthesisMustBeOnLineOfLastParameter", Justification = "Ignored for more tree-like fluent syntax usage."),
    SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Ignored for more tree-like fluent syntax usage.")
    ]
    public static TSyntaxNode WithLeadingDocumentationTrivia<TSyntaxNode>(this TSyntaxNode syntaxNode, String summary = null) where TSyntaxNode : SyntaxNode
    {
      // TODO: Include the summary element text content and expand the optional parameters for more elements of use auto-documenting methods instead as per #2.
      return syntaxNode.WithLeadingTrivia
      (
        SyntaxFactory.Trivia
        (
          SyntaxFactory.DocumentationCommentTrivia
          (
            SyntaxKind.MultiLineDocumentationCommentTrivia,
            new SyntaxList<XmlNodeSyntax>().Add
            (
              SyntaxFactory.XmlElement
              (
                SyntaxFactory.XmlElementStartTag
                (
                  SyntaxFactory.XmlName("summary")
                ),
                SyntaxFactory.XmlElementEndTag
                (
                  SyntaxFactory.XmlName("summary")
                )
              ).WithLeadingTrivia
              (
                SyntaxFactory.DocumentationCommentExterior("/// ")
              )
            )
          )
        )
      );
    }

    #endregion
  }
}