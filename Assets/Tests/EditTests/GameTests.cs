using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTests
    {
        public GameObject player;
        [Test]
        public void CharacterShouldBeInGameSpaceOnOpen()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            Assert.IsNotNull(player);
        }

        [Test]
        public void CharacterShouldHaveRigidBody2D()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            Assert.IsNotNull(player.GetComponent<Rigidbody2D>());
        }

        [Test]
        public void CharacterShouldHaveSpriteRenderer()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            Assert.IsNotNull(player.GetComponent<SpriteRenderer>());
        }

        [Test]
        public void CharacterShouldHaveBoxCollider2D()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            Assert.IsNotNull(player.GetComponent<BoxCollider2D>());
        }

        [Test]
        public void CharacterShouldHaveAnimator()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            Assert.IsNotNull(player.GetComponent<Animator>());
        }
    }
}
