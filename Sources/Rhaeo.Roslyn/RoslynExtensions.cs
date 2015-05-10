// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoslynExtensions.cs" company="Rhaeo.org">
//   Licenced under the MIT license.
// </copyright>
// <summary>
//   Defines the RoslynExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.CodeAnalysis;

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
    public static TSyntaxNode WithLeadingDocumentationTrivia<TSyntaxNode>(this TSyntaxNode syntaxNode, String summary = null) where TSyntaxNode : SyntaxNode
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}