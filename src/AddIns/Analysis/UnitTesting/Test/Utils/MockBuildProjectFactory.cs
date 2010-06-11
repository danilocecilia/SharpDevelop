﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections.Generic;
using ICSharpCode.SharpDevelop.Project;
using ICSharpCode.UnitTesting;

namespace UnitTesting.Tests.Utils
{
	public class MockBuildProjectFactory : IBuildProjectFactory
	{
		List<MockBuildProjectBeforeTestRun> buildProjectInstances = new List<MockBuildProjectBeforeTestRun>();
		
		public BuildProjectBeforeTestRun CreateBuildProjectBeforeTestRun(IProject project)
		{
			MockBuildProjectBeforeTestRun buildProject = RemoveBuildProjectInstance();
			if (buildProject != null) {
				buildProject.Project = project;
			}
			return buildProject;
		}
		
		MockBuildProjectBeforeTestRun RemoveBuildProjectInstance()
		{
			if (buildProjectInstances.Count > 0) {
				MockBuildProjectBeforeTestRun buildProject = buildProjectInstances[0];
				buildProjectInstances.RemoveAt(0);
				return buildProject;
			}
			return null;
		}
		
		public void AddBuildProjectBeforeTestRun(MockBuildProjectBeforeTestRun buildBeforeTestRun)
		{
			buildProjectInstances.Add(buildBeforeTestRun);
		}
	}
}