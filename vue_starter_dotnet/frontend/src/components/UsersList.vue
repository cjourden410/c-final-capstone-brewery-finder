<template>
  <table>
    <thead>
      <tr>
        <td>Id</td>
        <td>Name</td>
        <td>Role</td>
      </tr>
    </thead>
    <tbody>
      <tr v-for="user in users" :key="user.id">
        <td>{{user.id}}</td>
        <td>{{user.username}}</td>
        <td>{{user.role}}</td>
      </tr>
    </tbody>
  </table>
</template>
<script>
export default {
  name: "user-list",
  props: {
    users: Array
  },
  data() {
    return {};
  },
  methods: {},
  computed: {}
};
</script>