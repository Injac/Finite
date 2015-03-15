﻿using System;
using Finite.Tests.TestData;
using Shouldly;
using Xunit;

namespace Finite.Tests
{
	public class StateMachineConfigurationTests
	{	 
		[Fact]
		public void When_changing_state_onEnter_and_onLeave_should_be_called()
		{
			var machine = new StateMachine<TestArgs>(new DefaultInstanceCreator());
			var enterCalled = 0;
			var leaveCalled = 0;

			machine.Configuration.OnEnterState = (args, prev, next) => { enterCalled++; };
			machine.Configuration.OnLeaveState = (args, prev, next) => { leaveCalled++; };

			machine.InitialiseFrom(new[]{ typeof(FirstState), typeof(SecondState)});
			machine.BindTo(new TestArgs());

			machine.SetStateTo<FirstState>();

			leaveCalled.ShouldBe(1);
			enterCalled.ShouldBe(1);
		}
	}
}
